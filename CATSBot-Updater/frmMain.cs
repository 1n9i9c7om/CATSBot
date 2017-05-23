using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace CATSBot_Updater
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        WebClient WC = new WebClient();

        private void Form1_Load(object sender, EventArgs e)
        {
            WC.DownloadProgressChanged += WC_DownloadProgressChanged;
            WC.DownloadFileCompleted += WC_DownloadFileCompleted;

            if(!File.Exists("version"))
            {
                UpdateCats();
                return;
            }

            double installedVersion = Convert.ToDouble(File.ReadAllText("version"));
            double currentVersion = Convert.ToDouble(WC.DownloadString("https://catsbot.net/releases/version"));

            if(currentVersion > installedVersion)
            {
                UpdateCats();
                return;
            }
            
        }

        private void WC_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (File.Exists("latest_cats.zip.progress"))
            {
                if (File.Exists("latest_cats.zip")) File.Delete("latest_cats.zip");

                File.Move("latest_cats.zip.progress", "latest_cats.zip");

                ZipStorer zip = ZipStorer.Open("latest_cats.zip", FileAccess.Read);
                List<ZipStorer.ZipFileEntry> dir = zip.ReadCentralDir();

                // Look for the desired file
                foreach (ZipStorer.ZipFileEntry entry in dir)
                {
                    zip.ExtractFile(entry, entry.FilenameInZip);
                }

                zip.Close();
                File.Delete("latest_cats.zip");
            }

            System.Diagnostics.Process.Start("CATSBot.exe");
            Application.Exit();
        }

        private void WC_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            prgDownload.Value = e.ProgressPercentage;
            lblProgress.Text = "Downloaded: " + e.BytesReceived / 1024 + " / " + e.TotalBytesToReceive / 1024 + " kB";
        }

        private void UpdateCats()
        {
            WC.DownloadFileAsync(new Uri("https://catsbot.net/releases/latest.zip"), "latest_cats.zip.progress");
        }
    }
}

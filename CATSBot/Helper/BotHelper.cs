using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace CATSBot.Helper
{
    //This class provides random helper methods.
    public static class BotHelper
    {
        static Random rnd = new Random();
        public static frmMain main;
        static int resolution = 0;

        public static int getResolution(bool update = false)
        {
            if(resolution == 0 || update)
            {
                try
                {
                    resolution = ADBHelper.getScreencap(true).Height;
                }
                catch (Exception)
                {
                    resolution = 720; //720p
                }
            }

            return resolution;
        }

        public static Bitmap getResourceByName(string name)
        {
            object resourceToGet = Properties.Resources.ResourceManager.GetObject(name + "_" + getResolution());
            if (resourceToGet != null)
                return (Bitmap)resourceToGet;

            resourceToGet = Properties.Resources.ResourceManager.GetObject(name + "_720");
            if (resourceToGet != null)
                return (Bitmap)resourceToGet;

            return Properties.Resources.label_defeat_720;

        }

        // Randomize the delay for more security
        public static void randomDelay(int delay, int maxDiff, bool log = false)
        {
            /*int actualDelay = rnd.Next(delay - maxDiff, delay + maxDiff);
            if(log) Log("Using delay: " + actualDelay);
            Thread.Sleep(actualDelay);*/
        }

        public static bool isMemuRunning()
        {
            // Check if the MEmu process is running
            Process[] pname = Process.GetProcessesByName("MEmu");
            if (pname.Length == 0)
            {
                return false;
            }

            return true;
        }

        // Logger
        public static void Log(string text, bool newLine = true, bool isDebug = false)
        {
            Directory.CreateDirectory("logs"); //create logs directory if it doesn't exit.

            string formattedText = (newLine ? Environment.NewLine + "[" + DateTime.Now.ToString("dd.MM.yy H:mm:ss") + "] " : "") + text;

            if (!isDebug)
            {
                main.txtLog.Invoke((MethodInvoker)delegate {
                    main.txtLog.Text += (newLine ? Environment.NewLine + "[" + DateTime.Now.ToString("dd.MM.yy H:mm:ss") + "] " : "") + text;
                    main.txtLog.Text = main.txtLog.Text.Trim();
                    main.txtLog.SelectionStart = main.txtLog.Text.Length;
                    main.txtLog.ScrollToCaret();
                });
            }

            string dateTimeString = DateTime.Now.ToString("yyyy_MM_dd", CultureInfo.InvariantCulture);

            if (!isDebug)
                System.IO.File.AppendAllText(@"logs\CatsBot_" + dateTimeString + ".log", formattedText);
            else
                System.IO.File.AppendAllText(@"logs\CatsBot_debug_" + dateTimeString + ".log", formattedText);
        }

        // Update the stats label. To be improved in future releases
        public static void updateStats(int wins, int losses, int crowns)
        {
            main.lblStats.Invoke((MethodInvoker)delegate
            {
                main.lblStats.Text = "Wins: " + wins + " (" + crowns + " Crowns) | Losses: " + losses;
            });
        }

        public static void pickMemuDir()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Please your MEmu installation folder.";

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                // Allow both, the Microvirt folder or the MEmu folder inside
                if (File.Exists(Path.Combine(fbd.SelectedPath, "adb.exe")))
                {
                    Settings.getInstance().adbPath = Path.Combine(fbd.SelectedPath, "adb.exe");
                    main.txtCurrentMemuPath.Text = fbd.SelectedPath;
                }
                else if (File.Exists(Path.Combine(fbd.SelectedPath, @"MEmu\adb.exe")))
                {
                    Settings.getInstance().adbPath = Path.Combine(fbd.SelectedPath, @"MEmu\adb.exe");
                    main.txtCurrentMemuPath.Text = Path.Combine(fbd.SelectedPath, @"MEmu");
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(main, "Invalid folder selected. Please go into settings and try again.");
                }
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(main, "Invalid folder selected. Please go into settings and try again.");
            }
        }

        #region Debug related stuff
        public static void saveDebugInformation()
        {
            string debugInformation = "";
            debugInformation += "CATSBot Debug Information" + Environment.NewLine;
            debugInformation += "Time: " + DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss", CultureInfo.InvariantCulture) + Environment.NewLine;
            debugInformation += "Operating System: " + Environment.OSVersion.VersionString + Environment.NewLine;

#if DEBUG
            debugInformation += "A Debug Build is currently being used!" + Environment.NewLine;
#endif

            if (File.Exists("version"))
                debugInformation += "CATSBot Version: " + File.ReadAllText("version") + Environment.NewLine + Environment.NewLine;
            else
                debugInformation += "CATSBot Version: version file was deleted!" + Environment.NewLine + Environment.NewLine;


            int screenCounter = 1;
            foreach (Screen screen in Screen.AllScreens)
            {
                debugInformation += "Screen " + screenCounter + ": " + Environment.NewLine;
                debugInformation += "Name: " + screen.DeviceName + Environment.NewLine;
                debugInformation += "Resolution: " + screen.Bounds.Height + "x" + screen.WorkingArea.Width + Environment.NewLine;
                debugInformation += "Is Primary: " + screen.Primary.ToString() + Environment.NewLine + Environment.NewLine;
                screenCounter++;
            }

            debugInformation += Environment.NewLine;

            if (isMemuRunning())
            {
                debugInformation += "MEmu is running." + Environment.NewLine;
            }
            else
            {
                debugInformation += "MEmu wasn't running while collecting debug information.";
            }

            System.IO.File.WriteAllText("CATSBot_Debuginformation.txt", debugInformation);
            Process.Start("CATSBot_Debuginformation.txt");
        }
        #endregion

        #region XML (De-)Serializer
        public static bool Serialize<T>(this T value, string fileName)
        {
            if (value == null)
            {
                return false;
            }
            try
            {

                var xmlserializer = new XmlSerializer(typeof(T));
                using (StringWriter stringWriter = new StringWriter())
                {
                    using (var writer = XmlWriter.Create(stringWriter))
                    {
                        xmlserializer.Serialize(writer, value);
                        File.WriteAllText(fileName, stringWriter.ToString());
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
                return false;
            }
        }

        public static T Deserialize<T>(string fileName)
        {
            if (fileName == null || fileName == "")
            {
                return default(T); //"null"
            }
            try
            {
                var xmlserializer = new XmlSerializer(typeof(T)); 
                using (StreamReader streamReader = new StreamReader(fileName))
                {
                    using (var reader = XmlReader.Create(streamReader)) 
                    {
                        return (T)xmlserializer.Deserialize(reader); 
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return default(T); //"null"
            }
        }
        #endregion
    }
}

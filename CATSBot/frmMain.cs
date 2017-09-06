using MetroFramework;
using System;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

using CATSBot.Helper;
using System.Net;

namespace CATSBot
{
    public partial class frmMain : MetroFramework.Forms.MetroForm 
    {
        Thread thread;
        bool isRunning = false;


        public frmMain()
        {
            InitializeComponent();
            BotHelper.main = this;
            Settings.getInstance().loadSettings(this);

#if DEBUG
            this.Text = "CATSBot - DEBUG";
#endif
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if(Settings.getInstance().adbPath == "")
            {
                MetroFramework.MetroMessageBox.Show(this, "Please set your MEmu installation directory before starting the bot.");
                return;
            }

            if (!isRunning)
            {
                if (!BotHelper.isMemuRunning())
                {
                    MetroFramework.MetroMessageBox.Show(this, "MEmu is not running!");
                    return;
                }

                btnStart.Text = "Stop";
                isRunning = true;

                // Start the Bot thread
                Thread.Sleep(100);
                thread = new Thread(doLoop);
                thread.IsBackground = true;
                thread.Start();
            }
            else
            {
                if (thread.IsAlive)
                    thread.Suspend(); // TODO: Proper Multithreading

                btnStart.Text = "Start";
                isRunning = false;
            }
        }

        public void doLoop()
        {
            int fails = 0;
            do
            {
                Thread.Sleep(1500);
                BotHelper.Log("(Re-)Starting main loop.");

                if (!BotLogics.AttackLogic.doLogic())
                {
                    BotLogics.ClearScreenLogic.doLogic();
                    fails++;
                }
                else fails = 0;

                if (chkAutoReconnect.Checked)
                    BotLogics.ReconnectLogic.doLogic();

                if (chkUseChestLogic.Checked)
                    BotLogics.ChestLogic.doLogic(); // uncomment this line to test the chest opener. Please report any false-positives.


            } while (fails < 5);
            
            BotHelper.Log("Too many errors. Restarting CATS.");
            ADBHelper.stopCATS();
            BotHelper.randomDelay(1000, 5);
            ADBHelper.startCATS();
            BotHelper.Log("Waiting for CATS to restart. Waiting 30s.");
            Thread.Sleep(30000);

            doLoop();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(thread != null && thread.IsAlive)
                thread.Suspend(); // TODO: Proper Multithreading       

            //Save and exit
            Settings.getInstance().saveSettings();
            Application.Exit(); 
        }

        private void btnSaveDebug_Click(object sender, EventArgs e)
        {
            BotHelper.saveDebugInformation();
        }

        #region Style-related events
        public void changeStyle(MetroColorStyle color)
        {
            Settings.getInstance().metroStyle = (int)color;
            this.Style = color;
            metroStyle.Style = color;
        }

        public void changeTheme(MetroThemeStyle theme)
        {
            Settings.getInstance().metroTheme = (int)theme;
            if (theme == MetroThemeStyle.Light)
            {
                this.Theme = MetroThemeStyle.Light;
                metroStyle.Theme = MetroThemeStyle.Light;

                foreach (TabPage tp in tabMain.Controls)
                {
                    foreach (Control ctrl in tp.Controls)
                    {
                        if (ctrl is NumericUpDown || ctrl is TextBox)
                        {
                            ctrl.BackColor = System.Drawing.Color.White;
                            ctrl.ForeColor = System.Drawing.Color.Black;
                        }
                    }
                    tp.BackColor = System.Drawing.Color.White;
                }
            }
            else if (theme == MetroThemeStyle.Dark)
            {
                this.Theme = MetroThemeStyle.Dark;
                metroStyle.Theme = MetroThemeStyle.Dark;

                foreach (TabPage tp in tabMain.Controls)
                {
                    foreach(Control ctrl in tp.Controls)
                    {
                        if(ctrl is NumericUpDown || ctrl is TextBox)
                        {
                            ctrl.BackColor = System.Drawing.ColorTranslator.FromHtml("#111111");
                            ctrl.ForeColor = System.Drawing.Color.White;
                        }
                    }
                    tp.BackColor = System.Drawing.ColorTranslator.FromHtml("#111111");
                }
            }
        }

        private void btnChangeStyle_Click(object sender, EventArgs e)
        {
            changeStyle((MetroColorStyle)styleBox.SelectedIndex + 1);
        }

        private void btnLightTheme_Click(object sender, EventArgs e)
        {
            changeTheme(MetroThemeStyle.Light);
        }

        private void btnDarkTheme_Click(object sender, EventArgs e)
        {
            changeTheme(MetroThemeStyle.Dark);
        }
        #endregion

        #region Setting-saving "dummys"
        //These are just for setting-saving purposes
        private void chkAutoReconnect_CheckedChanged(object sender, EventArgs e)
        {
            Settings.getInstance().automaticReconnectEnabled = chkAutoReconnect.Checked;
        }

        private void nudReconnectTime_ValueChanged(object sender, EventArgs e)
        {
            Settings.getInstance().reconnectTime = Convert.ToInt32(nudReconnectTime.Value);
        }
        
        private void chkAlwaysTop_CheckedChanged(object sender, EventArgs e)
        {
            Settings.getInstance().topmost = chkAlwaysTop.Checked;
            this.TopMost = Settings.getInstance().topmost;
        }

        private void frmMain_ResizeEnd(object sender, EventArgs e)
        {
            Settings.getInstance().frmSize = this.Size;
        }

        private void frmMain_LocationChanged(object sender, EventArgs e)
        {
            if (this.Location.Y > 0)
            {
                Settings.getInstance().frmLoc = this.Location;
            }
        }
        private void chkUseChestLogic_CheckedChanged(object sender, EventArgs e)
        {
            Settings.getInstance().useChestLogic = chkUseChestLogic.Checked;
        }

        private void chkAutoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            Settings.getInstance().enableAutoUpdater = chkAutoUpdate.Checked;
        }
        #endregion

        private void btnResetStats_Click(object sender, EventArgs e)
        {
            BotLogics.AttackLogic.resetStats();
        }

        private void btnChangeMemuPath_Click(object sender, EventArgs e)
        {
            BotHelper.pickMemuDir();
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            if (Settings.getInstance().adbPath == "")
            {
                // Check default installation path
                if (File.Exists(@"C:\Program Files\Microvirt\MEmu\adb.exe"))
                {
                    Settings.getInstance().adbPath = @"C:\Program Files\Microvirt\MEmu\adb.exe";
                }
                else if (File.Exists(@"D:\Program Files\Microvirt\MEmu\adb.exe"))
                {
                    Settings.getInstance().adbPath = @"D:\Program Files\Microvirt\MEmu\adb.exe";
                }
                else
                {
                    BotHelper.pickMemuDir();
                }

                txtCurrentMemuPath.Text = Settings.getInstance().adbPath;
            }

            if(Settings.getInstance().enableAutoUpdater) checkUpdates(); 
        }

        private bool checkUpdates()
        {
            if (!File.Exists("CATSBot-Updater.exe"))
            {
                btnCheckUpdates.Visible = false;
                btnCheckUpdates.Enabled = false;
                return false;
            }
                

            double thisVersion = 0;
            if (!File.Exists("version"))
            {
                // file doesn't exist, update.
                DialogResult dr = MetroMessageBox.Show(this, "There's a new update available. Do you want to download it now?", "Update available", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start("CATSBot-Updater.exe");
                    Application.Exit();
                }

                return true; 
            }

            thisVersion = Convert.ToDouble(File.ReadAllText("version"));
            WebClient wc = new WebClient();

            double currentVersion = Convert.ToDouble(wc.DownloadString("https://catsbot.net/releases/version"));

            if(currentVersion > thisVersion)
            {
                DialogResult dr = MetroMessageBox.Show(this, "There's a new update available. Do you want to download it now?", "Update available", MessageBoxButtons.YesNo);
                if(dr == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start("CATSBot-Updater.exe");
                    Application.Exit();
                }

                return true;
            }
            else
            {
                return false;
            }


        }

        private void btnCheckUpdates_Click(object sender, EventArgs e)
        {
            if(!checkUpdates())
            {
                DialogResult dr = MetroMessageBox.Show(this, "You're already using the latest version of CATSBot. :)", "No update available");
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            BotLogics.AttackLogic.maxHealth = (int)numericUpDown1.Value;
        }
    }
}

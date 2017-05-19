using MetroFramework;
using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

using CATSBot.Helper;
using System.Drawing;

namespace CATSBot
{
    public partial class frmMain : MetroFramework.Forms.MetroForm
    {
        Thread thread;
        bool isRunning = false;
        Point? memuLocation = null;

        public frmMain()
        {
            InitializeComponent();
            BotHelper.main = this;
            Settings.getInstance().loadSettings(this);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                if (!BotHelper.setMemuIntPtr())
                {
                    MetroFramework.MetroMessageBox.Show(this, "MEmu is not running!");
                    return;
                }
                
                if (chkUseSidebar.Checked)
                    ClickOnPointTool.ResizeWindow(BotHelper.memu, 1328, 758);
                else
                    ClickOnPointTool.ResizeWindow(BotHelper.memu, 1288, 758);

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
            BotHelper.Log("(Re-)Starting main loop.");

            if (chkAutoReconnect.Checked)
                BotLogics.ReconnectLogic.doLogic();

            BotLogics.AttackLogic.doLogic();

            doLoop();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(thread != null && thread.IsAlive)
                thread.Suspend(); // TODO: Proper Multithreading

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

                txtLog.BackColor = System.Drawing.Color.White;
                txtLog.ForeColor = System.Drawing.Color.Black;

                foreach (TabPage tp in tabMain.Controls)
                {
                    tp.BackColor = System.Drawing.Color.White;
                }

                nudReconnectTime.BackColor = System.Drawing.Color.White;
                nudReconnectTime.ForeColor = System.Drawing.Color.Black;
            }
            else if (theme == MetroThemeStyle.Dark)
            {
                this.Theme = MetroThemeStyle.Dark;
                metroStyle.Theme = MetroThemeStyle.Dark;

                txtLog.BackColor = System.Drawing.ColorTranslator.FromHtml("#111111");
                txtLog.ForeColor = System.Drawing.Color.White;

                foreach (TabPage tp in tabMain.Controls)
                {
                    tp.BackColor = System.Drawing.ColorTranslator.FromHtml("#111111");
                }

                nudReconnectTime.BackColor = System.Drawing.ColorTranslator.FromHtml("#111111");
                nudReconnectTime.ForeColor = System.Drawing.Color.White;
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
        private void chkUseSidebar_CheckedChanged(object sender, EventArgs e)
        {
            Settings.getInstance().memuSidebarEnabled = chkUseSidebar.Checked;
        }

        private void chkAutoReconnect_CheckedChanged(object sender, EventArgs e)
        {
            Settings.getInstance().automaticReconnectEnabled = chkAutoReconnect.Checked;
        }

        private void nudReconnectTime_ValueChanged(object sender, EventArgs e)
        {
            Settings.getInstance().reconnectTime = Convert.ToInt32(nudReconnectTime.Value);
        }
        #endregion

        private void btnResetStats_Click(object sender, EventArgs e)
        {
            BotLogics.AttackLogic.resetStats();
        }

        private void btnHideMemu_Click(object sender, EventArgs e)
        {
            if(BotHelper.memu != IntPtr.Zero)
            {
                Point memuSize = new Point(1328, 758);
                if (!chkUseSidebar.Checked)
                    memuSize = new Point(1288, 758);

                if (memuLocation == null)
                {

                    Point tmpMemu = new Point();
                    ClickOnPointTool.ClientToScreen(BotHelper.memu, ref tmpMemu);

                    memuLocation = tmpMemu;
                    ClickOnPointTool.MoveWindow(BotHelper.memu, -10000, memuLocation.Value.Y, memuSize.X, memuSize.Y, true);

                    btnHideMemu.Text = "Show MEmu Window";
                }
                else
                {
                    ClickOnPointTool.MoveWindow(BotHelper.memu, memuLocation.Value.X, memuLocation.Value.Y, memuSize.X, memuSize.Y, true);
                    memuLocation = null;
                    btnHideMemu.Text = "Hide MEmu Window";
                }
                

            }
        }

        //DEBUG

        private void button1_Click(object sender, EventArgs e)
        {
            ADBHelper.startCATS();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ADBHelper.stopCATS();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            picDebug.Image = ADBHelper.getScreencap();
        }
    }
}

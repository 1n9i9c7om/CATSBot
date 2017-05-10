using MetroFramework;
using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

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
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if(!isRunning)
            {
                if(!BotHelper.setMemuIntPtr())
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

            Application.Exit();
        }

        private void changeStyle(MetroColorStyle color)
        {
            this.Style = color;
            metroStyle.Style = color;
        }     

        private void btnSaveDebug_Click(object sender, EventArgs e)
        {
            BotHelper.saveDebugInformation();
        }

        private void nudReconnectTime_ValueChanged(object sender, EventArgs e)
        {
            BotLogics.ReconnectLogic.reconnectTime = Convert.ToInt32(nudReconnectTime.Value);
        }

        private void btnChangeStyle_Click(object sender, EventArgs e)
        {
            changeStyle((MetroColorStyle)styleBox.SelectedIndex + 1);
        }

        private void btnLightTheme_Click(object sender, EventArgs e)
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

        private void btnDarkTheme_Click(object sender, EventArgs e)
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
}

﻿using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace CATSBot
{
    public partial class frmMain : Form
    {
        Thread thread;

        public frmMain()
        {
            InitializeComponent();
            BotHelper.main = this;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if(btnStart.Text == "Start")
            {
                if(!BotHelper.setMemuIntPtr())
                {
                    MessageBox.Show("MEmu is not running!");
                    return;
                }

                if (chkUseSidebar.Checked)
                    ClickOnPointTool.ResizeWindow(BotHelper.memu, 1328, 758);
                else
                    ClickOnPointTool.ResizeWindow(BotHelper.memu, 1288, 758);

                btnStart.Text = "Stop";

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
            }
        }

        public void doLoop()
        {
            BotHelper.Log("(Re-)Starting main loop.");
            BotLogics.AttackLogic.doLogic();

            doLoop();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(thread != null && thread.IsAlive)
                thread.Suspend(); // TODO: Proper Multithreading

            Application.Exit();
        }

        private void btnSaveDebug_Click(object sender, EventArgs e)
        {
            BotHelper.saveDebugInformation();
        }
    }
}

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

        public frmMain()
        {
            InitializeComponent();
            BotHelper.main = this;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if(btnStart.Text == "Start")
            {
                // Check if the MEmu process is running
                Process[] pname = Process.GetProcessesByName("MEmu");
                if (pname.Length == 0)
                {
                    MetroFramework.MetroMessageBox.Show(this,"MEmu is not running!");
                    return;
                }

                BotHelper.memu = Process.GetProcessesByName("MEmu").First().MainWindowHandle;

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


        //###############################################################################################
        //Down here is all the stuff for the style changer/ appereance of the program
        //Made by PalOne because i am too bad for complex stuff :P

        //The styles have a corresponding number which are as follows: 
        /*
        0 = Default
        1 = Black
        2 = White
        3 = Silver
        4 = Blue
        5 = Green
        6 = Lime
        7 = Teal
        8 = Orange
        9 = Brown
        10 = Pink
        11 = Magenta
        12 = Purple
        13 = Red
        14 = Yellow
        */


        private void changeStyle(int colorcode)
        {
            //The Framework is poorly documented (videos only wtf) which also seem to be outdated (????) 
            //so that stuff might be not the BEST of solutions

            //Change the style of every control that supports it using the colorcode number
            this.Style = (MetroFramework.MetroColorStyle)colorcode;
            btnStart.Style = (MetroFramework.MetroColorStyle)colorcode;
            tabMain.Style = (MetroFramework.MetroColorStyle)colorcode;
            chkUseSidebar.Style = (MetroFramework.MetroColorStyle)colorcode;
            Refresh();

        }

        //The buttons. Names shozuld indicate color
        private void btn_styleBlu_Click(object sender, EventArgs e)
        {
            changeStyle(4);
        }

        private void btn_styleRed_Click(object sender, EventArgs e)
        {
            changeStyle(13);
        }

        private void btn_styleBlack_Click(object sender, EventArgs e)
        {
            changeStyle(1);
        }
    }
}

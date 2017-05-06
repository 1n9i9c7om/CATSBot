using System;
using System.Threading;
using System.Windows.Forms;

namespace CATSBot
{
    public static class BotHelper
    {
        static Random rnd = new Random();
        public static IntPtr memu;
        public static frmMain main;

        // Randomize the delay for more security
        public static void randomDelay(int delay, int maxDiff)
        {
            int actualDelay = rnd.Next(delay - maxDiff, delay + maxDiff);
            Log("Using delay: " + actualDelay);
            Thread.Sleep(actualDelay);
        }

        // Logger
        public static void Log(string text, bool newLine = true)
        {
            main.txtLog.Invoke((MethodInvoker)delegate {
                main.txtLog.Text += (newLine ? Environment.NewLine + "[" + DateTime.Now.ToString("dd.MM.yy H:mm:ss") + "] " : "") + text;
                main.txtLog.Text = main.txtLog.Text.Trim();
                main.txtLog.SelectionStart = main.txtLog.Text.Length;
                main.txtLog.ScrollToCaret();
            });
        }

        // Update the stats label. To be improved in future releases
        public static void UpdateStats(int wins, int losses)
        {
            main.lblStats.Text = "Wins: " + wins + " | Losses: " + losses;
        }
    }
}

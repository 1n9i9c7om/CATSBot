using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace CATSBot.Helper
{
    public static class ADBHelper
    {
        static bool firstExecution = true;

        //It's like Process.Start but automatically starts adb
        private static void adbStart(string args)
        {
            if(firstExecution)
            {
                firstExecution = false;
                adbStart("start-server");
                BotHelper.Log("Starting ADB Server...");
            }

            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = Settings.getInstance().adbPath;
            psi.RedirectStandardInput = false;
            psi.RedirectStandardOutput = true;
            psi.Arguments = args;
            //psi.Verb = "runas";
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;

            Process proc = new Process();
            proc.StartInfo = psi;
            proc.Start();

            while (!proc.StandardOutput.EndOfStream)
            {
                string line = proc.StandardOutput.ReadLine();
                BotHelper.Log(line);
            }

        }

        public static void startCATS()
        {
            adbStart("shell monkey -p com.zeptolab.cats.google -c android.intent.category.LAUNCHER 1");
        }

        public static void stopCATS()
        {
            adbStart("shell am force-stop com.zeptolab.cats.google");
        }

        public static void simulateClick(int x, int y)
        {
            adbStart("shell input touchscreen tap " + x + " " + y);
        }

        public static void simulateClick(Point loc)
        {
            simulateClick(loc.X, loc.Y);
        }

        public static Bitmap getScreencap(bool keepSize = false)
        {
            try
            {
                
                // Grab a screenshot
                adbStart("shell screencap -p /sdcard/catsbot.png");
                //BotHelper.randomDelay(100, 5);
                // Pull it to your PC
                adbStart("pull /sdcard/catsbot.png");
                //BotHelper.randomDelay(400, 5);
                // Remove the file from MEmu
                adbStart("shell rm /sdcard/catsbot.png");
                

                //Image screencap = GetCopyImage("catsbot.png");

                Image image = Image.FromFile("catsbot.png");
                Bitmap returnImage = ImageRecognition.ConvertToFormat(image, System.Drawing.Imaging.PixelFormat.Format24bppRgb, keepSize);

                image.Dispose();
                return returnImage;
            }
            catch(Exception ex)
            {
                BotHelper.Log("An error occured during getScreencap");
                BotHelper.Log(ex.Message);
                return Properties.Resources.label_defeat_1080;
            }
        }
    }
}

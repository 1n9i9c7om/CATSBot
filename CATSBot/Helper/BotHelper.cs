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
        public static IntPtr memu;
        public static frmMain main;

        // Randomize the delay for more security
        public static void randomDelay(int delay, int maxDiff)
        {
            int actualDelay = rnd.Next(delay - maxDiff, delay + maxDiff);
            Log("Using delay: " + actualDelay);
            Thread.Sleep(actualDelay);
        }

        public static bool setMemuIntPtr()
        {
            // Check if the MEmu process is running
            Process[] pname = Process.GetProcessesByName("MEmu");
            if (pname.Length == 0)
            {
                MessageBox.Show("MEmu is not running!");
                return false;
            }

            memu = Process.GetProcessesByName("MEmu").First().MainWindowHandle;
            return true;
        }

        // Logger
        public static void Log(string text, bool newLine = true, bool isDebug = false)
        {
            string formattedText = (newLine ? Environment.NewLine + "[" + DateTime.Now.ToString("dd.MM.yy H:mm:ss") + "] " : "") + text;
            main.txtLog.Invoke((MethodInvoker)delegate {
                main.txtLog.Text += (newLine ? Environment.NewLine + "[" + DateTime.Now.ToString("dd.MM.yy H:mm:ss") + "] " : "") + text;
                main.txtLog.Text = main.txtLog.Text.Trim();
                main.txtLog.SelectionStart = main.txtLog.Text.Length;
                main.txtLog.ScrollToCaret();
            });

            string dateTimeString = DateTime.Now.ToString("yyyy_MM_dd", CultureInfo.InvariantCulture);

            if (!isDebug)
                System.IO.File.AppendAllText("CatsBot_" + dateTimeString + ".log", formattedText);
            else
                System.IO.File.AppendAllText("CatsBot_debug_" + dateTimeString + ".log", formattedText);
        }

        // Update the stats label. To be improved in future releases
        public static void updateStats(int wins, int losses, int crowns)
        {
            main.lblStats.Invoke((MethodInvoker)delegate
            {
                main.lblStats.Text = "Wins: " + wins + " (" + crowns + " Crowns) | Losses: " + losses;
            });
        }
        #region Debug Information Gathering
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;        // x position of upper-left corner
            public int Top;         // y position of upper-left corner
            public int Right;       // x position of lower-right corner
            public int Bottom;      // y position of lower-right corner
        }

        public static void saveDebugInformation()
        {
            string debugInformation = "";
            debugInformation += "CATSBot Debug Information" + Environment.NewLine;
            debugInformation += "Time: " + DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss", CultureInfo.InvariantCulture) + Environment.NewLine;
            debugInformation += "Operating System: " + Environment.OSVersion.VersionString + Environment.NewLine + Environment.NewLine;

            int screenCounter = 1;
            foreach(Screen screen in Screen.AllScreens)
            {
                debugInformation += "Screen " + screenCounter + ": " + Environment.NewLine;
                debugInformation += "Name: " + screen.DeviceName + Environment.NewLine;
                debugInformation += "Resolution: " + screen.Bounds.Height + "x" + screen.WorkingArea.Width + Environment.NewLine;
                debugInformation += "Is Primary: " + screen.Primary.ToString() + Environment.NewLine + Environment.NewLine;
                screenCounter++;
            }

            debugInformation += Environment.NewLine;

            if (setMemuIntPtr())
            {
                RECT rct = new RECT();
                GetWindowRect(memu, ref rct);

                Rectangle memuSize = new Rectangle();

                memuSize.X = rct.Left;
                memuSize.Y = rct.Top;
                memuSize.Width = rct.Right - rct.Left + 1;
                memuSize.Height = rct.Bottom - rct.Top + 1;

                debugInformation += "MEmu is running." + Environment.NewLine;
                debugInformation += "Window Size: " + memuSize.Width + "x" + memuSize.Height + Environment.NewLine;
                debugInformation += "Window Location: " + memuSize.Location.X + "x" + memuSize.Location.Y + Environment.NewLine;
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

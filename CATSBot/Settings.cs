using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CATSBot
{
    public class Settings
    {
        private static Settings settings;

        public Settings()
        {

        } //Constructor needed for XML Serialization

        public static Settings getInstance()
        {
            if (settings == null)
            {
                if(System.IO.File.Exists("settings.xml"))
                {
                    settings = Helper.BotHelper.Deserialize<Settings>("settings.xml");
                }
                else
                {
                    settings = new Settings();
                }
            }

            return settings;
        }

        //Style related settings
        public int metroStyle = 4;
        public int metroTheme = 1;
        public bool topmost = false;
        public Size frmSize = new Size(289, 605);
        public Point frmLoc = new Point(100, 100);

        //Settings found in the "Settings" tab
        public bool enableAutoUpdater = true;
        public bool automaticReconnectEnabled = true;
        public int reconnectTime = 5;
        public bool useChestLogic = false;
        public string adbPath = "";

        public bool saveSettings()
        {
           return Helper.BotHelper.Serialize(this, "settings.xml");
        }

        public void loadSettings(frmMain main)
        {
            main.changeStyle((MetroFramework.MetroColorStyle)metroStyle);
            main.changeTheme((MetroFramework.MetroThemeStyle)metroTheme);

            main.chkAutoReconnect.Checked = automaticReconnectEnabled;
            main.nudReconnectTime.Value = Convert.ToDecimal(reconnectTime);
            main.txtCurrentMemuPath.Text = (adbPath == "" ? "Not set!" : adbPath.Replace("adb.exe", ""));
            main.chkUseChestLogic.Checked = useChestLogic;

            main.chkAlwaysTop.Checked = topmost;
            main.Size = frmSize;
            main.Location = frmLoc;
        }
    }
}

using System;
using System.Collections.Generic;
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

        //Settings found in the "Settings" tab
        public bool memuSidebarEnabled = true;
        public bool automaticReconnectEnabled = true;
        public int reconnectTime = 5;

        public bool saveSettings()
        {
           return Helper.BotHelper.Serialize(this, "settings.xml");
        }

        public void loadSettings(frmMain main)
        {
            main.changeStyle((MetroFramework.MetroColorStyle)metroStyle);
            main.changeTheme((MetroFramework.MetroThemeStyle)metroTheme);

            main.chkUseSidebar.Checked = memuSidebarEnabled;
            main.chkAutoReconnect.Checked = automaticReconnectEnabled;
            main.nudReconnectTime.Value = Convert.ToDecimal(reconnectTime);
        }
    }
}

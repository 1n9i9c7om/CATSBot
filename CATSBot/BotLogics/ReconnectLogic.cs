using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CATSBot.Helper;

namespace CATSBot.BotLogics
{
    public static class ReconnectLogic
    {
        public static void doLogic()
        {
            if(checkReconnect())
            {
                int reconnectTime = Settings.getInstance().reconnectTime;
                BotHelper.Log("Reconnect Button found. Pressing it in " + reconnectTime + " minutes.");

                int sleepTime = 0;
                if (reconnectTime != 0)
                    sleepTime = reconnectTime * 1000 * 60;
                else
                    sleepTime = 5000; //wait 5 seconds anyways, just to be sure

                System.Threading.Thread.Sleep(sleepTime);

                Bitmap button_reconnect = BotHelper.getResourceByName("button_reconnect");

                Point reconnectButton = ImageRecognition.getPictureLocation(button_reconnect, 0.90f);
                ADBHelper.simulateClick(ImageRecognition.getRandomLoc(reconnectButton, button_reconnect));

                BotHelper.Log("Reconnect Button pressed.");
            }
            else
            {
                BotHelper.Log("Reconnect Button check completed; Button not found.", true, true);
            }
        }

        private static bool checkReconnect()
        {
            Bitmap button_reconnect = BotHelper.getResourceByName("button_reconnect");

            Point reconnectButton = ImageRecognition.getPictureLocation(button_reconnect, 0.90f);

            if (reconnectButton.X == 0 && reconnectButton.Y == 0)
                return false;
            else
                return true;
        }
    }
}

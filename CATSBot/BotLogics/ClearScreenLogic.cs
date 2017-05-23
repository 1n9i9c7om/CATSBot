using CATSBot.Helper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CATSBot.BotLogics
{
    public static class ClearScreenLogic
    {
        static Point pNull = new Point(0, 0);
        static Bitmap comparePic;

        // Check if we defended, if yes, click that filthy "Claim" button that's preventing us from clicking "QUICK FIGHT" ;)
        public static bool checkDefense()
        {
            Helper.BotHelper.Log("Successful defense check", true, true);
            Bitmap button_claim = BotHelper.getResourceByName("button_claim");
            Point claimPoint = ImageRecognition.getPictureLocation(button_claim);
            if (claimPoint != pNull)
            {
                ADBHelper.simulateClick(ImageRecognition.getRandomLoc(claimPoint, button_claim));
                BotHelper.Log("We defended. Free coins! :)");
                BotHelper.randomDelay(1200, 100);
                return true;
            }
            return false;
        }

        // Check if somebody got an instant promotion, because that window will be blocking the bot even after a restart
        public static bool checkInstantPromo()
        {
            Bitmap button_ok = BotHelper.getResourceByName("button_ok");

            Helper.BotHelper.Log("Instant Promo Check", true, true);
            Point claimPoint = ImageRecognition.getPictureLocation(button_ok);
            if (claimPoint != pNull)
            {
                ADBHelper.simulateClick(ImageRecognition.getRandomLoc(claimPoint, button_ok));
                BotHelper.Log("Someone got instant promoted.");
                BotHelper.randomDelay(1200, 100);
                return true;
            }
            return false;
        }

        public static void doLogic()
        {
            comparePic = ADBHelper.getScreencap();
            if (checkDefense()) comparePic = ADBHelper.getScreencap(); // update the screen if needed

            checkInstantPromo();
        }
}

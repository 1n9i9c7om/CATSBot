using CATSBot.Helper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Point okPoint = ImageRecognition.getPictureLocation(comparePic, button_ok);
            if (okPoint != pNull)
            {
                ADBHelper.simulateClick(ImageRecognition.getRandomLoc(okPoint, button_ok));
                BotHelper.Log("Someone got instant promoted.");
                BotHelper.randomDelay(1200, 100);
                return true;
            }
            return false;
        }

        public static bool checkForLeagueEnd()
        {
            // Does anything happen when you get put in a better league? Gonna have to test that.
            // If not, this should work already.

            Bitmap league_end_label = BotHelper.getResourceByName("label_league_over");

            Point labelPoint = ImageRecognition.getPictureLocation(comparePic, league_end_label);
            if (labelPoint != pNull)
            {
                // League ended. We gotta press "Claim" now and open that chest. :)
                BotHelper.randomDelay(1000, 100);

                Bitmap claimButton = BotHelper.getResourceByName("button_claim_onend");
                Point claimPoint = ImageRecognition.getPictureLocation(comparePic, claimButton);
                if(claimPoint != pNull)
                {
                    ADBHelper.simulateClick(claimPoint);
                    BotHelper.randomDelay(1000, 100);
                    ChestLogic.openChest();
                }
                else
                {
                    BotHelper.Log("Couldn't find claim button for leagueEnd. Returning to regular duty.");
                }

                return true;
            }

            return false;
        }

        public static bool checkForChampionshipEnd()
        {
            // This should work as long as you don't get promoted. If you happen to be promoted, the bot will probably be stuck at the sticker selection.

            Bitmap league_end_label = BotHelper.getResourceByName("label_championship_over");
            Point labelPoint = ImageRecognition.getPictureLocation(comparePic, league_end_label);
            if (labelPoint != pNull)
            {
                // Championship ended. We gotta press "Claim" now and open that chest. :)
                BotHelper.randomDelay(1000, 100);

                Bitmap claimButton = BotHelper.getResourceByName("button_claim_onend");
                Point claimPoint = ImageRecognition.getPictureLocation(comparePic, claimButton);
                if (claimPoint != pNull)
                {
                    ADBHelper.simulateClick(claimPoint);
                    BotHelper.randomDelay(1000, 100);
                    ChestLogic.openChest();
                    BotHelper.randomDelay(2000, 100);

                    Bitmap backButton = BotHelper.getResourceByName("button_champ_back");
                    Point backPoint = ImageRecognition.getPictureLocation(backButton);

                    ADBHelper.simulateClick(backPoint);
                    BotHelper.randomDelay(1000, 100);
                    ADBHelper.simulateClick(backPoint);
                    BotHelper.randomDelay(1000, 100);
                }
                else
                {
                    BotHelper.Log("Couldn't find claim button for champEnd. Returning to regular duty.");
                }
                return true;
            }

            return false;
        }

        public static bool checkForChestInForeground()
        {
            Bitmap regChest = BotHelper.getResourceByName("label_regularbox");
            Bitmap supChest = BotHelper.getResourceByName("label_super_box");
            Bitmap legChest = BotHelper.getResourceByName("label_legendary_box");

            Point pRegChest = ImageRecognition.getPictureLocation(comparePic, regChest);
            Point pSupChest = ImageRecognition.getPictureLocation(comparePic, supChest);
            Point pLegChest = ImageRecognition.getPictureLocation(comparePic, legChest);

            if(pRegChest != pNull || pSupChest != pNull || pLegChest != pNull)
            {
                ChestLogic.openChest();
                return true;
            }

            return false;
        }

        public static void doLogic()
        {
            comparePic = ADBHelper.getScreencap();
            if (checkDefense()) comparePic = ADBHelper.getScreencap(); // update the screen if needed
            if (checkForLeagueEnd()) comparePic = ADBHelper.getScreencap(); // update the screen if needed
            if (checkForChampionshipEnd()) comparePic = ADBHelper.getScreencap(); // update the screen if needed
            if (checkForChestInForeground()) comparePic = ADBHelper.getScreencap(); // update the screen if needed
            checkInstantPromo();
        }
    }
}

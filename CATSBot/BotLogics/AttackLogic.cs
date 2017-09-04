using System;
using System.Drawing;
using System.Threading;

using CATSBot.Helper;
using System.Linq;

namespace CATSBot.BotLogics
{
    public static class AttackLogic
    {
        static Point pNull = new Point(0, 0);
        static Random rnd = new Random();
        public static int maxHealth = 1000;

        //This is disabled until re-implemented. ;)
        static int wins = 0;
        static int losses = 0;
        static int winsInARow = 0;
        static int crowns = 0;

        public static void resetStats()
        {
            wins = 0;
            losses = 0;
            winsInARow = 0;
            crowns = 0;

            BotHelper.updateStats(0, 0, 0);
        }

        // Try to find the "Quick Fight" button and click on it.
        public static bool searchDuell()
        {
            Bitmap button_fight = BotHelper.getResourceByName("button_fight");

            BotHelper.Log("Attempting to press the Duell button", true, true);
            //BotHelper.setDebugPic(ImageRecognition.CaptureApplication(BotHelper.memu));
            //BotHelper.setDebugPic2(ImageRecognition.ConvertToFormat(Properties.Resources.button_fight, System.Drawing.Imaging.PixelFormat.Format24bppRgb, true));
            //return false;
            Point fightPoint = ImageRecognition.getPictureLocation(button_fight);
            if (fightPoint != pNull)
            {
                BotHelper.Log("Button found at: X = " + fightPoint.X + "; Y = " + fightPoint.Y, true, true);
                ADBHelper.simulateClick(ImageRecognition.getRandomLoc(fightPoint, button_fight));
                return true;
            }
            else
            {
                BotHelper.Log("Could not find the quick fight button. :/", true, false);
                return false;
            }
        }

        //Check for the skip button. If it's there, an opponent has been found.
        public static bool waitDuell()
        {
            Point skipPoint = new Point(1150, 650);
            Rectangle skipButtonRec = new Rectangle(1150, 600, 120, 110);
            Bitmap button_skip = BotHelper.getResourceByName("button_skip");

            BotHelper.Log("Searching for appropriate opponent....");
            int checks, attempts = 0, enemyHealth;
            bool opponentFound = false;

            Thread.Sleep(1000);
            do
            {
                checks = 0;
                enemyHealth = 0;
                do
                {
                    checks++;
                } while (!ImageRecognition.IsButtonThere(button_skip, skipButtonRec) && checks <= 55);

                if (checks >= 35)
                {
                    BotHelper.Log("Oops, we timed out.");
                    return false;
                }

                enemyHealth = ImageRecognition.GetEnemyHealth();

                BotHelper.Log((attempts + 1) + ". Enemy health: " + enemyHealth);

                if (enemyHealth > maxHealth)
                {
                    ADBHelper.simulateClick(ImageRecognition.getRandomLoc(skipPoint, button_skip));
                    attempts++;
                }
                else
                    opponentFound = true;

            } while (attempts < 20 && !opponentFound);

            if (!opponentFound)
            {
                BotHelper.Log("Couldn't find opponent in 20 tries");
                return false;
            }
            
            return true;
        }

        // Start the fight by clicking anywhere and wait for it to end (by searching for the "OK" button)
        public static bool startDuell(int attempt = 1)
        {
            Bitmap button_ok = BotHelper.getResourceByName("button_ok");

            ADBHelper.simulateClick(new Point(rnd.Next(670 - 100, 670 + 100), rnd.Next(400 - 100, 400 + 100))); //Click anywhere to start the battle

            // wait for the duell to end and click on ok
            BotHelper.Log("Waiting for the duell to end.");
            int checks = 0;
            Point locOK = new Point();
            do
            {
                BotHelper.Log(" " + checks, false);
                checks++;

                locOK = ImageRecognition.getPictureLocation(button_ok);
            } while ((locOK == pNull) && checks <= 55);

            if (checks >= 55)
            {
                BotHelper.Log("We timed out. :(");
            }

            BotHelper.randomDelay(500, 50);
            if (locOK.X == 0 && locOK.Y == 0) //something went wrong (note: the code should never enter this)
            {
                BotHelper.Log("Something weird happened.");
                if (attempt < 3)
                    return startDuell(attempt + 1);
                else
                    return false; // TODO: Restart CATS?
            }
            else //we won!
            {
                BotHelper.Log("Battle finished.", true, false);

                int winloss = checkWin();
                if(winloss == 1)
                {
                    BotHelper.Log(" We won!", false, false);
                    wins++;
                    winsInARow++;
                    if ((winsInARow % 5) == 0) crowns++;
                }
                else if(winloss == 2)
                {
                    BotHelper.Log(" We lost. :(", false, false);
                    losses++;
                    winsInARow = 0;
                }
                else
                {
                    BotHelper.Log("Error checking win/loss, not counting stats", true, false);
                }

                BotHelper.updateStats(wins, losses, crowns);

                Point rndP = ImageRecognition.getRandomLoc(locOK, button_ok);
                BotHelper.Log("Clicked on: X = " + rndP.X + "; Y = " + rndP.Y, true, true);
                ADBHelper.simulateClick(rndP);
            }

            //BotHelper.UpdateStats(wins, losses, crowns);
            BotHelper.Log("Returning to main screen");

            return true;
        }

        //returns 1 for win, 2 for loss and 0 for error
        private static int checkWin()
        {
            Bitmap img = ImageRecognition.CaptureApplication();
            Bitmap label_victory = BotHelper.getResourceByName("label_victory");
            Bitmap label_defeat = BotHelper.getResourceByName("label_defeat");

            Point win = ImageRecognition.GetSubPositions(img, label_victory).FirstOrDefault();
            Point defeat = ImageRecognition.GetSubPositions(img, label_defeat).FirstOrDefault();

            if (win.X != 0 && win.Y != 0)
            {
                return 1;
            }
            else if(defeat.X != 0 && defeat.Y != 0)
            {
                return 2;
            }

            return 0;
        }

        //Attack Logic
        public static bool doLogic()
        {
            if (searchDuell())
            {
                if (waitDuell())
                    if (startDuell())
                        BotHelper.Log("AttackLogic successfully completed.");
                    else
                        BotHelper.Log("AttackLogic failed during startDuell");
                else
                    BotHelper.Log("AttackLogic failed during waitDUell");
            }           
            else
            {
                return false;
            }

            return true;
        }
    }
}

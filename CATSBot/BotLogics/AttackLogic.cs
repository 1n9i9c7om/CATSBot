using System;
using System.Drawing;
using System.Threading;

using CATSBot.Helper;

namespace CATSBot.BotLogics
{
    public static class AttackLogic
    {
        static Point pNull = new Point(0, 0);
        static Random rnd = new Random();

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

        //Check if we defended, if yes, click that filthy "Claim" button that's prevent us from clicking "QUICK FIGHT" ;)
        public static void checkDefense()
        {
            Helper.BotHelper.Log("Successful defense check");

            if (ImageRecognition.getPictureLocation(Properties.Resources.button_defend, BotHelper.memu) != pNull)
            {
                ClickOnPointTool.ClickOnPoint(BotHelper.memu, ImageRecognition.getRandomLoc(Properties.Resources.button_defend, BotHelper.memu));
                BotHelper.Log("Yup, we defended");
                BotHelper.randomDelay(1000, 100);
            }
        }

        // Try to find the "Quick Fight" button and click on it.
        public static bool searchDuell()
        {
            BotHelper.Log("Attempting to press the Duell button");
            if (ImageRecognition.getPictureLocation(Properties.Resources.button_fight, BotHelper.memu) != pNull)
            {
                Point dbgPoint = ImageRecognition.getPictureLocation(Properties.Resources.button_fight, BotHelper.memu);
                BotHelper.Log("Button found! FeelsGoodMan.");
                BotHelper.Log("Button found at: X = " + dbgPoint.X + "; Y = " + dbgPoint.Y, true, true);
                ClickOnPointTool.ClickOnPoint(BotHelper.memu, ImageRecognition.getRandomLoc(Properties.Resources.button_fight, BotHelper.memu));
                return true;
            }
            else
            {
                BotHelper.Log("Button not found! FeelsBadMan.");
                return false;
            }
        }

        //Check for the skip button. If it's there, an opponent has been found.
        public static bool waitDuell()
        {
            BotHelper.Log("Waiting for the duell to start....");
            int checks = 0;
            do
            {
                BotHelper.Log(" " + checks, false);
                Thread.Sleep(100);
                checks++;
            } while (ImageRecognition.getPictureLocation(Properties.Resources.button_skip, BotHelper.memu) == pNull && checks <= 55);

            if (checks >= 55)
            {
                BotHelper.Log("Oops, we timed out.");
                return false;
            }

            BotHelper.randomDelay(500, 50);
            return true;
        }

        // Start the fight by clicking anywhere and wait for it to end (by searching for the "OK" button)
        public static bool startDuell(int attempt = 1)
        {
            ClickOnPointTool.ClickOnPoint(BotHelper.memu, new Point(rnd.Next(670 - 100, 670 + 100), rnd.Next(400 - 100, 400 + 100))); //Click anywhere to start the battle
            BotHelper.randomDelay(500, 50);

            // wait for the duell to end and click on ok
            BotHelper.Log("Waiting for the duell to end.");
            int checks = 0;
            Point locOK = new Point();
            do
            {
                BotHelper.Log(" " + checks, false);
                Thread.Sleep(500);
                checks++;

                // Apparently, there are multiple "OK"-Buttons that all look the same at a first glance,
                // but there's a difference in them that the tool is able to detect. 
                // We have to check multiple images because of this, but we got an easy detection whether 
                // we won or not. :) 

                locOK = ImageRecognition.getPictureLocation(Properties.Resources.button_ok, BotHelper.memu);
                //locOKDefeat = ImageRecognition.getPictureLocation(Properties.Resources.button_ok_defeat, BotHelper.memu);
            } while ((locOK == pNull /* && locOKDefeat == pNull */) && checks <= 55);

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
                BotHelper.Log("Battle finished.");

                int winloss = checkWin();
                if(winloss == 1)
                {
                    BotHelper.Log("We won!");
                    wins++;
                    winsInARow++;
                    if ((winsInARow % 5) == 0) crowns++;
                }
                else if(winloss == 2)
                {
                    BotHelper.Log("We lost. :(");
                    losses++;
                    winsInARow = 0;
                }
                else
                {
                    BotHelper.Log("Error checking win/loss, not counting stats");
                }

                BotHelper.updateStats(wins, losses, crowns);

                Point rndP = ImageRecognition.getRandomLoc(locOK, Properties.Resources.button_ok);
                BotHelper.Log("Clicked on: X = " + rndP.X + "; Y = " + rndP.Y, true, true);
                ClickOnPointTool.ClickOnPoint(BotHelper.memu, rndP);
            }

            //BotHelper.UpdateStats(wins, losses, crowns);
            BotHelper.Log("Returning to main screen");

            return true;
        }

        //returns 1 for win, 2 for loss and 0 for error
        private static int checkWin()
        {
            Point win = ImageRecognition.getPictureLocation(Properties.Resources.label_victory, BotHelper.memu);
            Point defeat = ImageRecognition.getPictureLocation(Properties.Resources.label_defeat, BotHelper.memu);

            if(win.X != 0 && win.Y != 0)
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
        public static void doLogic()
        {
            BotHelper.randomDelay(4000, 1000);
            checkDefense();
            if (searchDuell())
            {
                if (waitDuell())
                {
                    if (startDuell())
                    {
                        BotHelper.Log("AttackLogic successfully completed.");
                    }
                    else
                    {
                        BotHelper.Log("AttackLogic failed during startDuell");
                    }
                }
                else
                {
                    BotHelper.Log("AttackLogic failed during waitDUell");
                }
            }           
            else
            {
                BotHelper.Log("AttackLogic failed during searchDuell");
                BotHelper.Log("Please make sure that your games language is set to English and that MEmu is set to 1280x720 in windowed mode.");
                Thread.Sleep(5000); //give the user time to see this message :P
            }
        }
    }
}

using System;
using System.Drawing;
using System.Threading;

namespace CATSBot.BotLogics
{
    public static class AttackLogic
    {
        static Point pNull = new Point(0, 0);
        static Random rnd = new Random();

        static int wins = 0;
        static int losses = 0;
        static int winsInARow = 0;
        static int crowns = 0;

        //Check if we defended, if yes, click that filthy "Claim" button that's prevent us from clicking "QUICK FIGHT" ;)
        public static void checkDefense()
        {
            BotHelper.Log("Successful defense check");

            if (ImageRecognition.getPictureLocation(Properties.Resources.button_defend, BotHelper.memu) != pNull)
            {
                ClickOnPointTool.ClickOnPoint(BotHelper.memu, ImageRecognition.getRandomLoc(Properties.Resources.button_defend, BotHelper.memu));
                BotHelper.Log("Yup, we defended");
                BotHelper.randomDelay(1000, 100);
            }
        }

        // Try to find the "Quick Fight" button and click on it.
        public static void searchDuell()
        {
            BotHelper.Log("Attempting to press the Duell button");
            if (ImageRecognition.getPictureLocation(Properties.Resources.button_fight, BotHelper.memu) != pNull)
            {
                Point dbgPoint = ImageRecognition.getPictureLocation(Properties.Resources.button_fight, BotHelper.memu);
                BotHelper.Log("Button found! FeelsGoodMan.");
                BotHelper.Log("Button found at: X = " + dbgPoint.X + "; Y = " + dbgPoint.Y);
                ClickOnPointTool.ClickOnPoint(BotHelper.memu, ImageRecognition.getRandomLoc(Properties.Resources.button_fight, BotHelper.memu));
            }
            else
            {
                BotHelper.Log("Button not found! FeelsBadMan.");
            }
        }

        //Check for the skip button. If it's there, an opponent has been found.
        public static void waitDuell()
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
            }

            BotHelper.randomDelay(500, 50);
        }

        // Start the fight by clicking anywhere and wait for it to end (by searching for the "OK" button)
        public static void startDuell()
        {
            ClickOnPointTool.ClickOnPoint(BotHelper.memu, new Point(rnd.Next(670 - 100, 670 + 100), rnd.Next(400 - 100, 400 + 100))); //Click anywhere to start the battle
            BotHelper.randomDelay(500, 50);

            // wait for the duell to end and click on ok
            BotHelper.Log("Waiting for the duell to end.");
            int checks = 0;
            Point locOK = new Point();
            Point locOKDefeat = new Point();
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
                locOKDefeat = ImageRecognition.getPictureLocation(Properties.Resources.button_ok_defeat, BotHelper.memu);
            } while ((locOK == pNull && locOKDefeat == pNull) && checks <= 55);

            if (checks >= 55)
            {
                BotHelper.Log("We timed out. :(");
            }

            BotHelper.randomDelay(500, 50);
            if (locOK.X == 0 && locOK.Y == 0) //we lost :( (because the OK-button for winning couldn't be located)
            {
                if (locOKDefeat.X == 0 && locOKDefeat.Y == 0)
                {
                    // HOTFIX
                    // It still returns 0,0 sometimes. I have no idea why, but this seems to fix this issue.
                    startDuell();
                    return;
                }

                Point rndP = ImageRecognition.getRandomLoc(locOKDefeat, Properties.Resources.button_ok_defeat);
                BotHelper.Log("Clicked on: X = " + rndP.X + "; Y = " + rndP.Y);

                ClickOnPointTool.ClickOnPoint(BotHelper.memu, rndP);
                BotHelper.Log("We lost! FeelsBadMan :(");
                losses++;
                winsInARow = 0;
            }
            else //we won!
            {
                BotHelper.Log("We won! FeelsGoodMan :)");
                wins++;
                winsInARow++;
                if ((winsInARow % 5) == 0) crowns++;
                Point rndP = ImageRecognition.getRandomLoc(locOK, Properties.Resources.button_ok);
                BotHelper.Log("Clicked on: X = " + rndP.X + "; Y = " + rndP.Y);
                ClickOnPointTool.ClickOnPoint(BotHelper.memu, rndP);
            }

            BotHelper.UpdateStats(wins, losses, crowns);
            BotHelper.Log("Returning to main screen");
        }

        //Attack Logic
        public static void doLogic()
        {
            BotHelper.randomDelay(4000, 1000);
            checkDefense();
            searchDuell();
            waitDuell();
            startDuell();
        }
    }
}

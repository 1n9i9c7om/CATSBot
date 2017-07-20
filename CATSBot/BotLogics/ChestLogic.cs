using CATSBot.Helper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CATSBot.BotLogics
{
    public static class ChestLogic
    {
        static Bitmap comparePic;
        static Random rnd = new Random();

        static bool currentlyUnlocking = true;
        private static bool chestsReady()
        {
            Point chestArrow = ImageRecognition.GetSubPositions(comparePic, BotHelper.getResourceByName("arrow_chest"), 0.791f).FirstOrDefault();
            if (chestArrow.X != 0 && chestArrow.Y != 0)
                return true;

            return false;
        }

        private static bool isChestUnlocking()
        {
            Point chestTimer = ImageRecognition.GetSubPositions(comparePic, BotHelper.getResourceByName("chest_unlock"), 0.891f).FirstOrDefault();
            if (chestTimer.X != 0 && chestTimer.Y != 0)
                return true;

            return false;
        }

        private static Point getClosestChest()
        {
            Point chestArrow = ImageRecognition.GetSubPositions(comparePic, BotHelper.getResourceByName("arrow_chest"), 0.791f).FirstOrDefault();

            List<Point> regularBoxes = ImageRecognition.GetSubPositions(comparePic, BotHelper.getResourceByName("chest_regular"));
            List<Point> superBoxes = ImageRecognition.GetSubPositions(comparePic, BotHelper.getResourceByName("chest_super"));
            List<Point> sponsorBox = ImageRecognition.GetSubPositions(comparePic, BotHelper.getResourceByName("chest_sponsor"));

            List<Point> allChests = new List<Point>();
            allChests.AddRange(regularBoxes);
            allChests.AddRange(superBoxes);
            allChests.AddRange(sponsorBox);

            // Return the closest chest that's below the arrow
            return allChests.Where(pt => pt.Y > chestArrow.Y).GetClosestPoint(chestArrow);
        }

        private static void openClosestChest()
        {
            Point closestChest = getClosestChest();

            // The sponsor chest is the smallest one, so we use this for our random location algorithm to make sure won't miss a chest
            ADBHelper.simulateClick(ImageRecognition.getRandomLoc(closestChest, BotHelper.getResourceByName("chest_sponsor")));
            BotHelper.randomDelay(5000, 50); // it takes some time to open a chest sometimes
            openChest();
        }

        public static void openChest()
        {
            for (int i = 0; i < 16; i++)
            {
                // just to make sure it'll still be randomized...
                ADBHelper.simulateClick(new Point(rnd.Next(270 - 50, 270 + 50), rnd.Next(200 - 50, 200 + 50))); //Click anywhere to unbox
                BotHelper.randomDelay(200, 20);
            }

            ADBHelper.simulateClick(ImageRecognition.getRandomLoc(BotHelper.getResourceByName("button_collect_prizes"), 0.901f));

            // Check for Bonus item
            BotHelper.randomDelay(4000, 100); // it might take a second or two for the bonus chest to appear, better be safe than sorry
            comparePic = ADBHelper.getScreencap();
            Point bonusLabel = ImageRecognition.GetSubPositions(comparePic, BotHelper.getResourceByName("label_bonus")).FirstOrDefault();
            if (bonusLabel.X != 0 && bonusLabel.Y != 0)
            {
                // Bonus item, yay!
                Point watchButton = ImageRecognition.GetSubPositions(comparePic, BotHelper.getResourceByName("button_watch"), 0.901f).FirstOrDefault();
                if (watchButton.X != 0 && watchButton.Y != 0)
                {
                    // Ugh, they want us to watch an ad. Close the window.
                    Point closeButton = ImageRecognition.GetSubPositions(comparePic, BotHelper.getResourceByName("button_cancel"), 0.901f).FirstOrDefault();
                    ADBHelper.simulateClick(ImageRecognition.getRandomLoc(closeButton, BotHelper.getResourceByName("button_cancel")));
                }
                else
                {

                    ADBHelper.simulateClick(new Point(rnd.Next(270 - 50, 270 + 50), rnd.Next(200 - 50, 200 + 50))); //Click anywhere to unbox
                    BotHelper.randomDelay(300, 20);
                    ADBHelper.simulateClick(ImageRecognition.getRandomLoc(BotHelper.getResourceByName("button_collect_prizes"), 0.901f));
                }
            }
        }

        public static void doLogic()
        {
            BotHelper.randomDelay(1000, 100); //make sure to screen is cleared from previous tasks, just in case. Will probably be removed after some testing.
            currentlyUnlocking = true; 
            comparePic = ImageRecognition.CaptureApplication();

            currentlyUnlocking = isChestUnlocking();

            if (chestsReady())
            {
                BotHelper.Log("Completed box found!");
                openClosestChest();
            }

            if (!currentlyUnlocking)
            {
                BotHelper.Log("There's no box being unlocked right now, unlocking");
                List<Point> regularBoxes = ImageRecognition.GetSubPositions(comparePic, BotHelper.getResourceByName("chest_regular"));
                List<Point> superBoxes = ImageRecognition.GetSubPositions(comparePic, BotHelper.getResourceByName("chest_super"));

                Point firstReg = regularBoxes.FirstOrDefault();
                Point firstSup = superBoxes.FirstOrDefault();
                
                if (firstReg.X != 0 && firstReg.Y != 0)
                {
                    // Open a regular box
                    BotHelper.Log(" regular box", false);
                    ADBHelper.simulateClick(ImageRecognition.getRandomLoc(firstReg, BotHelper.getResourceByName("chest_regular")));
                    BotHelper.randomDelay(1000, 100);
                    ADBHelper.simulateClick(ImageRecognition.getRandomLoc(BotHelper.getResourceByName("button_unlock")));
                    BotHelper.randomDelay(1000, 100);
                    ADBHelper.simulateClick(ImageRecognition.getRandomLoc(BotHelper.getResourceByName("button_cancel"), 0.901f));
                }
                else if(firstSup.X != 0 && firstSup.Y != 0)
                {
                    // Open a super box
                    BotHelper.Log(" super box", false);
                    ADBHelper.simulateClick(ImageRecognition.getRandomLoc(firstSup, BotHelper.getResourceByName("chest_super")));
                    BotHelper.randomDelay(1000, 100);
                    ADBHelper.simulateClick(ImageRecognition.getRandomLoc(BotHelper.getResourceByName("button_unlock")));
                    BotHelper.randomDelay(1000, 100);
                    ADBHelper.simulateClick(ImageRecognition.getRandomLoc(BotHelper.getResourceByName("button_cancel"), 0.901f));
                }
                else
                {
                    BotHelper.Log(" ...nevermind. No boxes found.", false);
                }
            }

            BotHelper.Log("Finished ChestLogic!");
        }

        #region Extension Methods
        // These will be moved into their own class if we need more of them.
        public static Decimal GetDistance(this Point p1, Point p2)
        {
            return Convert.ToDecimal(Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2)));
        }

        public static Point GetClosestPoint(this IEnumerable<Point> points, Point referencePoint)
        {
            return points.OrderBy(x => x.GetDistance(referencePoint)).FirstOrDefault();
        }
        #endregion
    }
}

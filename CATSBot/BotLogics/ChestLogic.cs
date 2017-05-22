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
        private static bool chestsReady()
        {
            Point chestArrow = ImageRecognition.GetSubPositions(comparePic, BotHelper.getResourceByName("arrow_chest"), 0.776f).FirstOrDefault();
            if (chestArrow.X != 0 && chestArrow.Y != 0)
                return true;

            return false;
        }

        private static Point getClosestChest()
        {
            Point chestArrow = ImageRecognition.GetSubPositions(comparePic, BotHelper.getResourceByName("arrow_chest"), 0.771f).FirstOrDefault();

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

            for (int i = 0; i < 12; i++)
            {
                // just to make sure it'll still be randomized...
                ADBHelper.simulateClick(new Point(rnd.Next(670 - 50, 670 + 50), rnd.Next(300 - 50, 300 + 50))); //Click anywhere to unbox
                BotHelper.randomDelay(200, 20);
            }

            ADBHelper.simulateClick(ImageRecognition.getRandomLoc(BotHelper.getResourceByName("button_collect_prizes"), 0.901f));

            // Check for Bonus item
            BotHelper.randomDelay(4000, 100); // it might take a second or two for the bonus chest to appear, better be safe than sorry
            Point bonusLabel = ImageRecognition.GetSubPositions(comparePic, BotHelper.getResourceByName("label_bonus")).FirstOrDefault();
            if(bonusLabel.X != 0 && bonusLabel.Y != 0)
            {
                // Bonus item, yay!
                Point watchButton = ImageRecognition.GetSubPositions(comparePic, BotHelper.getResourceByName("button_watch"), 0.901f).FirstOrDefault();
                if (watchButton.X != 0 && watchButton.Y != 0)
                {
                    // Ugh, they want us to watch an ad. Close the window.
                    Point closeButton = ImageRecognition.GetSubPositions(comparePic, BotHelper.getResourceByName("button_cancel"), 0.901f).FirstOrDefault();
                    ADBHelper.simulateClick(ImageRecognition.getRandomLoc(closeButton, BotHelper.getResourceByName("chest_sponsor")));
                }
                else
                {

                    ADBHelper.simulateClick(new Point(rnd.Next(670 - 50, 670 + 50), rnd.Next(300 - 50, 300 + 50))); //Click anywhere to unbox
                    BotHelper.randomDelay(300, 20);
                    ADBHelper.simulateClick(ImageRecognition.getRandomLoc(BotHelper.getResourceByName("button_collect_prizes"), 0.901f));
                }
            }
        }

        public static void doLogic()
        {
            BotHelper.randomDelay(1000, 100); //make sure to screen is cleared from previous tasks, just in case. Will probably be removed after some testing.
            comparePic = ImageRecognition.CaptureApplication();
            BotHelper.setDebugPic(comparePic);
            if(chestsReady())
            {
                BotHelper.Log("Completed Chest found!");
                openClosestChest();
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

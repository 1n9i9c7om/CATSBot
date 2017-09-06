using AForge.Imaging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

namespace CATSBot.Helper
{
    public static class ImageRecognition
    {
        static Random rnd = new Random();
        static Point pNull = new Point(0, 0);

        public static Bitmap ConvertToFormat(this System.Drawing.Image image, PixelFormat format, bool keepSize = false)
        {
            Bitmap copy;
            if(keepSize)
            {
                copy = new Bitmap(image.Width, image.Height, format);
            }
            else
            {
                copy = new Bitmap(image.Width / 4, image.Height / 4, format);
            }

            using (Graphics gr = Graphics.FromImage(copy))
            {
                gr.DrawImage(image, new Rectangle(0, 0, copy.Width, copy.Height));
            } 
            return copy;
        }

        public static List<Point> GetSubPositions(Bitmap main, Bitmap sub, float similarityThreshold = 0.941f)
        {
            List<Point> possiblepos = new List<Point>();
            System.Drawing.Bitmap sourceImage = main; // ConvertToFormat(main, PixelFormat.Format24bppRgb);
            System.Drawing.Bitmap template = ConvertToFormat(sub, PixelFormat.Format24bppRgb, true);

            //BotHelper.setDebugPic(sourceImage);
            //BotHelper.setDebugPic2(template);
            // create template matching algorithm's instance

            ExhaustiveTemplateMatching tm = new ExhaustiveTemplateMatching(similarityThreshold);
            // find all matchings with specified above similarity

            TemplateMatch[] matchings = tm.ProcessImage(sourceImage, template);
            // highlight found matchings

            BitmapData data = sourceImage.LockBits(
                 new Rectangle(0, 0, sourceImage.Width, sourceImage.Height),
                 ImageLockMode.ReadWrite, sourceImage.PixelFormat);

            foreach (TemplateMatch m in matchings)
            {
                Point picPoint = m.Rectangle.Location;
                picPoint.X = picPoint.X * 4;
                picPoint.Y = picPoint.Y * 4;
                possiblepos.Add(picPoint);

                //sourceImage.UnlockBits(data);
                //return possiblepos; //1 result is enough
            }

            sourceImage.UnlockBits(data);
            return possiblepos;
        }

        public static bool IsButtonThere(Bitmap button, Rectangle whereToLook)
        {
            Bitmap screenshot = CaptureApplication();
            Rectangle smaller = new Rectangle(whereToLook.X / 4, whereToLook.Y / 4, whereToLook.Width / 4, whereToLook.Height / 4);
            Bitmap buttonBmp = screenshot.Clone(smaller, screenshot.PixelFormat);
            List<Point> buttonPoints = GetSubPositions(buttonBmp, button);
            if (buttonPoints == null) return false;
            return buttonPoints.Any();
        }

        public static int GetEnemyHealth()
        {
            Bitmap screenshot = ADBHelper.getScreencap(true);
            Rectangle enemyHealthRec = new Rectangle(642, 75, 300, 45);
            Bitmap enemyHealthBmp = screenshot.Clone(enemyHealthRec, screenshot.PixelFormat);
            int enemyhealth = 0;

            tessnet2.Tesseract ocr = new tessnet2.Tesseract();
            ocr.SetVariable("tessedit_char_whitelist", "0123456789"); // digits only
            ocr.Init(@"E:\Kunkli Richárd\Documents\GitHub\CATSBot\CATSBot\CATSBot\Resources\Tessdata\", "eng", false); // To use correct tessdata

            List<tessnet2.Word> result = ocr.DoOCR(enemyHealthBmp, Rectangle.Empty);
            if (result == null || result.Count != 1 || !int.TryParse(result.ElementAt(0).Text, out enemyhealth)) return 0;

            return enemyhealth;
        }

        public static Point getPictureLocation(Bitmap sub, float similarityThreshold = 0.941f)
        {
            Bitmap screenshot = CaptureApplication();
            return GetSubPositions(screenshot, sub, similarityThreshold).FirstOrDefault();
        }

        public static Point getPictureLocation(Bitmap main, Bitmap sub, float similarityThreshold = 0.941f)
        {
            return GetSubPositions(main, sub, similarityThreshold).FirstOrDefault();
        }

        public static Point getRandomLoc(Point loc, Bitmap sub)
        {
            if (loc == pNull)
                return pNull;

            int minX = loc.X;
            int minY = loc.Y;
            int maxX = loc.X + (sub.Width / 2);
            int maxY = loc.Y + (sub.Height / 2);

            Point rndPoint = new Point();
            rndPoint.X = rnd.Next(minX, maxX);
            rndPoint.Y = rnd.Next(minY, maxY);

            return rndPoint;
        }

        public static Point getRandomLoc(Bitmap sub, float similarityThreshold = 0.941f)
        {
            Point loc = getPictureLocation(sub, similarityThreshold);

            return getRandomLoc(loc, sub);
        }

        public static Bitmap CaptureApplication()
        {
            return ADBHelper.getScreencap();
        }
    }
}

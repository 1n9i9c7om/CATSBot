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

        public static Point getPictureLocation(Bitmap sub, float similarityThreshold = 0.941f)
        {
            Bitmap screenshot = CaptureApplication();
            return GetSubPositions(screenshot, sub, similarityThreshold).FirstOrDefault();
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

        public static Bitmap CaptureApplication()
        {
            return ADBHelper.getScreencap();
        }
    }
}

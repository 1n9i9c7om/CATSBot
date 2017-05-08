using AForge.Imaging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;

namespace CATSBot
{
    //Thanks to Wowa from StackOverflow: http://stackoverflow.com/a/11345850
    public static class ImageRecognition
    {
        static Random rnd = new Random();
        static Point pNull = new Point(0, 0);
        public static List<Point> GetSubPositions(Bitmap main, Bitmap sub, bool useNew = true)
        {
            if (useNew)
                return GetSubPositionsAForge(main, sub);

            List<Point> possiblepos = new List<Point>();

            int mainwidth = main.Width;
            int mainheight = main.Height;

            int subwidth = sub.Width;
            int subheight = sub.Height;

            int movewidth = mainwidth - subwidth;
            int moveheight = mainheight - subheight;

            BitmapData bmMainData = main.LockBits(new Rectangle(0, 0, mainwidth, mainheight), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            BitmapData bmSubData = sub.LockBits(new Rectangle(0, 0, subwidth, subheight), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

            int bytesMain = Math.Abs(bmMainData.Stride) * mainheight;
            int strideMain = bmMainData.Stride;
            System.IntPtr Scan0Main = bmMainData.Scan0;
            byte[] dataMain = new byte[bytesMain];
            System.Runtime.InteropServices.Marshal.Copy(Scan0Main, dataMain, 0, bytesMain);

            int bytesSub = Math.Abs(bmSubData.Stride) * subheight;
            int strideSub = bmSubData.Stride;
            System.IntPtr Scan0Sub = bmSubData.Scan0;
            byte[] dataSub = new byte[bytesSub];
            System.Runtime.InteropServices.Marshal.Copy(Scan0Sub, dataSub, 0, bytesSub);

            for (int y = 0; y < moveheight; ++y)
            {
                for (int x = 0; x < movewidth; ++x)
                {
                    MyColor curcolor = GetColor(x, y, strideMain, dataMain);

                    foreach (var item in possiblepos.ToArray())
                    {
                        int xsub = x - item.X;
                        int ysub = y - item.Y;
                        if (xsub >= subwidth || ysub >= subheight || xsub < 0)
                            continue;

                        MyColor subcolor = GetColor(xsub, ysub, strideSub, dataSub);

                        if (!curcolor.Equals(subcolor))
                        {
                            possiblepos.Remove(item);
                        }
                    }

                    if (curcolor.Equals(GetColor(0, 0, strideSub, dataSub)))
                        possiblepos.Add(new Point(x, y));
                }
            }

            System.Runtime.InteropServices.Marshal.Copy(dataSub, 0, Scan0Sub, bytesSub);
            sub.UnlockBits(bmSubData);

            System.Runtime.InteropServices.Marshal.Copy(dataMain, 0, Scan0Main, bytesMain);
            main.UnlockBits(bmMainData);

            return possiblepos;
        }

        public static Bitmap ConvertToFormat(this System.Drawing.Image image, PixelFormat format)
        {
            Bitmap copy = new Bitmap(image.Width/4, image.Height/4, format);
            using (Graphics gr = Graphics.FromImage(copy))
            {
                gr.DrawImage(image, new Rectangle(0, 0, copy.Width, copy.Height));
            } 
            return copy;
        }


        public static List<Point> GetSubPositionsAForge(Bitmap main, Bitmap sub)
        {
            List<Point> possiblepos = new List<Point>();
            System.Drawing.Bitmap sourceImage = ConvertToFormat(main, PixelFormat.Format24bppRgb);
            System.Drawing.Bitmap template = ConvertToFormat(sub, PixelFormat.Format24bppRgb);
            // create template matching algorithm's instance
            // (set similarity threshold to 92.1%)

            ExhaustiveTemplateMatching tm = new ExhaustiveTemplateMatching(0.941f);
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
        private static MyColor GetColor(Point point, int stride, byte[] data)
        {
            return GetColor(point.X, point.Y, stride, data);
        }

        private static MyColor GetColor(int x, int y, int stride, byte[] data)
        {
            int pos = y * stride + x * 4;
            byte a = data[pos + 3];
            byte r = data[pos + 2];
            byte g = data[pos + 1];
            byte b = data[pos + 0];
            return MyColor.FromARGB(a, r, g, b);
        }

        struct MyColor
        {
            byte A;
            byte R;
            byte G;
            byte B;

            public static MyColor FromARGB(byte a, byte r, byte g, byte b)
            {
                MyColor mc = new MyColor();
                mc.A = a;
                mc.R = r;
                mc.G = g;
                mc.B = b;
                return mc;
            }

            public override bool Equals(object obj)
            {
                if (!(obj is MyColor))
                    return false;
                MyColor color = (MyColor)obj;
                if (color.A == this.A && color.R == this.R && color.G == this.G && color.B == this.B)
                    return true;
                return false;
            }
        }

        public static Bitmap CaptureApplication(IntPtr windowHandle)
        {
            var rect = new User32.Rect();
            User32.GetWindowRect(windowHandle, ref rect);

            int width = rect.right - rect.left;
            int height = rect.bottom - rect.top;

            var bmp = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            Graphics graphics = Graphics.FromImage(bmp);
            graphics.CopyFromScreen(rect.left, rect.top, 0, 0, new Size(width, height), CopyPixelOperation.SourceCopy);

            return bmp;
        }

        private class User32
        {
            [StructLayout(LayoutKind.Sequential)]
            public struct Rect
            {
                public int left;
                public int top;
                public int right;
                public int bottom;
            }

            [DllImport("user32.dll")]
            public static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect);
        }

        public static Point getPictureLocation(Bitmap sub, IntPtr windowHandle)
        {
            Bitmap screenshot = CaptureApplication(windowHandle);
            return GetSubPositions(screenshot, sub).FirstOrDefault();
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

        public static Point getRandomLoc(Bitmap sub, IntPtr windowHandle)
        {
            return getRandomLoc(getPictureLocation(sub, windowHandle), sub);
        }
    }
}

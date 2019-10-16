using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace SampleMaker.Util
{
    public static class ImageHelper
    {
        public static Bitmap ZoomImage(Bitmap bitmap, double ratio)
        {
            System.Drawing.Image sourImage = bitmap;
            int destWidth = (int)Math.Round(bitmap.Width / ratio);
            int destHeight = (int)Math.Round(bitmap.Height / ratio);
            Bitmap destBitmap = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage(destBitmap);
            g.Clear(Color.Transparent);
            //设置画布的描绘质量         
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(sourImage, new Rectangle(0, 0, destWidth, destHeight), new Rectangle(0, 0, sourImage.Width, sourImage.Height), GraphicsUnit.Pixel);
            g.Dispose();
            return destBitmap;
        }

        public static Bitmap Rotate(Bitmap bmp, float angle, Color bkColor)
        {
            int w = bmp.Width + 2;
            int h = bmp.Height + 2;
            PixelFormat pf = bkColor == Color.Transparent ? PixelFormat.Format32bppArgb : bmp.PixelFormat;
            Bitmap tmp = new Bitmap(w, h, pf);
            Graphics g = Graphics.FromImage(tmp);
            g.Clear(bkColor);
            g.DrawImageUnscaled(bmp, 1, 1);
            g.Dispose();
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(new RectangleF(0f, 0f, w, h));
            Matrix mtrx = new Matrix();
            mtrx.Rotate(angle);
            RectangleF rct = path.GetBounds(mtrx);
            Bitmap dst = new Bitmap((int)rct.Width, (int)rct.Height, pf);
            g = Graphics.FromImage(dst);
            g.Clear(bkColor);
            g.TranslateTransform(-rct.X, -rct.Y);
            g.RotateTransform(angle);
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            g.DrawImageUnscaled(tmp, 0, 0);
            g.Dispose();
            tmp.Dispose();
            return dst;
        }

        public static void DrawImage(Bitmap src, Bitmap part, Point point)
        {
            Graphics g = Graphics.FromImage(src);
            g.DrawImage(part, point);
            g.Dispose();
        }

        public static Bitmap CloneBitmap(Bitmap src)
        {
            Bitmap bitmap = new Bitmap(src.Width, src.Height);
            DrawImage(bitmap, src, new Point(0, 0));
            return bitmap;
        }

        #region 调整光暗  
        /// <summary>  
        /// 调整光暗  
        /// </summary>  
        /// <param name="mybm">原始图片</param>  
        /// <param name="width">原始图片的长度</param>  
        /// <param name="height">原始图片的高度</param>  
        /// <param name="val">增加或减少的光暗值</param>  
        public static Bitmap LDPic(Bitmap mybm, int width, int height, int val)
        {
            Bitmap bm = new Bitmap(width, height);//初始化一个记录经过处理后的图片对象  
            int x, y, resultR, resultG, resultB;//x、y是循环次数，后面三个是记录红绿蓝三个值的  
            Color pixel;
            for (x = 0; x < width; x++)
            {
                for (y = 0; y < height; y++)
                {
                    pixel = mybm.GetPixel(x, y);//获取当前像素的值  
                    resultR = pixel.R + val;//检查红色值会不会超出[0, 255]  
                    resultG = pixel.G + val;//检查绿色值会不会超出[0, 255]  
                    resultB = pixel.B + val;//检查蓝色值会不会超出[0, 255]  
                    bm.SetPixel(x, y, Color.FromArgb(resultR, resultG, resultB));//绘图  
                }
            }
            return bm;
        }
        #endregion

        #region 反色处理  
        /// <summary>  
        /// 反色处理  
        /// </summary>  
        /// <param name="mybm">原始图片</param>  
        /// <param name="width">原始图片的长度</param>  
        /// <param name="height">原始图片的高度</param>  
        public static Bitmap RePic(Bitmap mybm, int width, int height)
        {
            Bitmap bm = new Bitmap(width, height);//初始化一个记录处理后的图片的对象  
            int x, y, resultR, resultG, resultB;
            Color pixel;
            for (x = 0; x < width; x++)
            {
                for (y = 0; y < height; y++)
                {
                    pixel = mybm.GetPixel(x, y);//获取当前坐标的像素值  
                    resultR = 255 - pixel.R;//反红  
                    resultG = 255 - pixel.G;//反绿  
                    resultB = 255 - pixel.B;//反蓝  
                    bm.SetPixel(x, y, Color.FromArgb(resultR, resultG, resultB));//绘图  
                }
            }
            return bm;
        }
        #endregion

        #region 浮雕处理  
        /// <summary>  
        /// 浮雕处理  
        /// </summary>  
        /// <param name="oldBitmap">原始图片</param>  
        /// <param name="Width">原始图片的长度</param>  
        /// <param name="Height">原始图片的高度</param>  
        public static Bitmap FD(Bitmap oldBitmap, int Width, int Height)
        {
            Bitmap newBitmap = new Bitmap(Width, Height);
            Color color1, color2;
            for (int x = 0; x < Width - 1; x++)
            {
                for (int y = 0; y < Height - 1; y++)
                {
                    int r = 0, g = 0, b = 0;
                    color1 = oldBitmap.GetPixel(x, y);
                    color2 = oldBitmap.GetPixel(x + 1, y + 1);
                    r = Math.Abs(color1.R - color2.R + 128);
                    g = Math.Abs(color1.G - color2.G + 128);
                    b = Math.Abs(color1.B - color2.B + 128);
                    if (r > 255) r = 255;
                    if (r < 0) r = 0;
                    if (g > 255) g = 255;
                    if (g < 0) g = 0;
                    if (b > 255) b = 255;
                    if (b < 0) b = 0;
                    newBitmap.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }
            return newBitmap;
        }
        #endregion

        #region 拉伸图片  
        /// <summary>  
        /// 拉伸图片  
        /// </summary>  
        /// <param name="bmp">原始图片</param>  
        /// <param name="newW">新的宽度</param>  
        /// <param name="newH">新的高度</param>  
        public static Bitmap ResizeImage(Bitmap bmp, int newW, int newH)
        {
            try
            {
                Bitmap bap = new Bitmap(newW, newH);
                Graphics g = Graphics.FromImage(bap);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(bap, new Rectangle(0, 0, newW, newH), new Rectangle(0, 0, bap.Width, bap.Height), GraphicsUnit.Pixel);
                g.Dispose();
                return bap;
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region 滤色处理  
        /// <summary>  
        /// 滤色处理  
        /// </summary>  
        /// <param name="mybm">原始图片</param>  
        /// <param name="width">原始图片的长度</param>  
        /// <param name="height">原始图片的高度</param>  
        public static Bitmap FilPic(Bitmap mybm, int width, int height)
        {
            Bitmap bm = new Bitmap(width, height);//初始化一个记录滤色效果的图片对象  
            int x, y;
            Color pixel;

            for (x = 0; x < width; x++)
            {
                for (y = 0; y < height; y++)
                {
                    pixel = mybm.GetPixel(x, y);//获取当前坐标的像素值  
                    bm.SetPixel(x, y, Color.FromArgb(0, pixel.G, pixel.B));//绘图  
                }
            }
            return bm;
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace SampleMaker.Util
{
    public static class EmguHelper
    {
        public static Mat WarpAffine(Bitmap bitmap, PointF[] points)
        {
            PointF[] srcPoints = new PointF[4];
            srcPoints[0] = new PointF(0, 0);
            srcPoints[1] = new PointF(bitmap.Width, 0);
            srcPoints[2] = new PointF(0, bitmap.Height);
            srcPoints[3] = new PointF(bitmap.Width, bitmap.Height);
            var matrix = CvInvoke.GetPerspectiveTransform(srcPoints, points);

            VectorOfPointF vectorPoints = new VectorOfPointF(points);
            var rect = CvInvoke.BoundingRectangle(vectorPoints);
            Mat dst = new Mat();
            Image<Bgra, byte> imageCV = new Image<Bgra, byte>(bitmap);
            Color color = Color.Transparent;
            var scalar = new Bgra(color.B, color.G, color.R, color.A).MCvScalar;
            CvInvoke.WarpPerspective(imageCV.Mat, dst, matrix, rect.Size, Inter.Linear, Warp.Default, BorderType.Transparent, scalar);
            matrix.Dispose();
            // imageCV.Mat.Dispose();
            imageCV.Dispose();
            return dst;
        }

        public static void AddImage(Mat src, Bitmap part, Point point)
        {
            Image<Bgra, byte> imageCV = new Image<Bgra, byte>(part);
            AddImage(src, imageCV.Mat, point);
            imageCV.Dispose();
        }

        public static Mat AddImage2(Mat src, Mat part, Point point)
        {
            Mat mask = Mat.Ones(part.Rows, part.Cols, part.Depth, part.NumberOfChannels) * 255;
            Point center = new Point(src.Width / 2, src.Height / 2);
            Mat result = new Mat();
            CvInvoke.SeamlessClone(part, src, mask, center, result, CloningMethod.Normal);
            // CvInvoke.IlluminationChange
            // CvInvoke.TextureFlattening
            // CvInvoke.ColorChange
            return result;
        }

        public static void AddImage(Mat src, Mat part, Point point)
        {
            VectorOfMat channels = new VectorOfMat();
            CvInvoke.Split(part, channels);

            Size size = part.Size;
            if (point.X + size.Width >= src.Width)
            {
                size = new Size(src.Width - point.X - 1, size.Height);
            }
            if (point.Y + size.Height >= src.Height)
            {
                size = new Size(size.Width, src.Height - point.Y - 1);
            }
            Rectangle roi = new Rectangle(point, size);

            Mat temp = new Mat(src, roi);
            Mat bgr = new Mat();
            CvInvoke.CvtColor(part, bgr, ColorConversion.Bgra2Bgr);

            if (channels.Size == 4)
            {
                Mat mask = channels[3]; // 使用透明区域做mask
                bgr.CopyTo(temp, mask);
            }
            else
            {
                bgr.CopyTo(temp);
            }
        }

        public static Mat Resize(Mat src, double ratio)
        {
            int newWidth = (int)Math.Round(src.Width / ratio);
            int newHeight = (int)Math.Round(src.Height / ratio);
            return Resize(src, newWidth, newHeight);
        }

        public static Mat Resize(Mat src, int newWidth, int newHeight)
        {
            Size newSize = new Size(newWidth, newHeight);
            Mat temp = new Mat();
            CvInvoke.Resize(src, temp, newSize, 0, 0, Inter.Area);
            return temp;
        }

        public static Mat AddColorNoise(Mat src, int offset)
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            int r = random.Next(0 - offset, offset + 1);
            int g = random.Next(0 - offset, offset + 1);
            int b = random.Next(0 - offset, offset + 1);
            return src + new MCvScalar(b, g, r);
        }

        /// <summary>
        /// 给图片增加椒盐噪点
        /// </summary>
        /// <param name="src">原图片</param>
        /// <param name="level">程度 1- 10</param>
        /// <returns></returns>
        public static Mat AddSaltNoise(Mat src, int level)
        {
            if (level < 1 || level > 10)
            {
                throw new Exception("参数level应在[1, 10]之间");
            }
            int max = level * 5;
            Mat dst = new Mat();
            src.CopyTo(dst);

            Mat temp = new Mat(dst.Size, dst.Depth, dst.NumberOfChannels);
            int high = max * 2;
            CvInvoke.Randu(temp, new MCvScalar(0, 0, 0), new MCvScalar(high, high, high));

            dst = dst - max;
            dst = dst + temp;
            return dst;
        }

        public static Mat AddGaussianNoise(Mat src, int level)
        {
            if (level < 1 || level > 10)
            {
                throw new Exception("参数level应在[1, 10]之间");
            }
            int max = level * 5;
            Mat dst = new Mat();
            src.CopyTo(dst);

            Mat temp = new Mat(dst.Size, dst.Depth, dst.NumberOfChannels);
            int high = max * 2;
            CvInvoke.Randn(temp, new MCvScalar(0, 0, 0), new MCvScalar(high, high, high));

            dst = dst - max;
            dst = dst + temp;
            return dst;
        }
    }
}

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

        /// <summary>
        /// 设置不规则透明区域，src和mask尺寸须相同
        /// </summary>
        /// <param name="src"></param>
        /// <param name="mask">黑色为透明</param>
        /// <returns></returns>
        public static Mat SetClip(Mat src, Mat mask)
        {
            VectorOfMat channels = new VectorOfMat();
            CvInvoke.Split(src, channels);
            VectorOfMat channels2 = new VectorOfMat(channels[0], channels[1], channels[2], mask);
            Mat dst = new Mat();
            CvInvoke.Merge(channels2, dst);
            channels.Dispose();
            channels2.Dispose();
            return dst;
        }

        public static Mat SetClip(Bitmap src, Mat mask)
        {
            Image<Bgra, byte> image = new Image<Bgra, byte>(src);
            Mat dst = SetClip(image.Mat, mask);
            image.Dispose();
            return dst;
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

        public static MCvScalar GetMeanColor(Mat src)
        {
            VectorOfMat channels = new VectorOfMat();
            CvInvoke.Split(src, channels);

            double meanB = CvInvoke.Mean(channels[0]).ToArray()[0];
            double meanG = CvInvoke.Mean(channels[1]).ToArray()[0];
            double meanR = CvInvoke.Mean(channels[2]).ToArray()[0];

            return new MCvScalar(meanB, meanG, meanR);
        }

        public static Mat AddPadding(Mat src, int alpha_w1, int alpha_w2, int alpha_h1, int alpha_h2, MCvScalar color)
        {
            Mat temp = Mat.Zeros(src.Height + alpha_h1 + alpha_h2, src.Width + alpha_w1 + alpha_w2, src.Depth, src.NumberOfChannels);
            Mat dst = temp + new MCvScalar(color.V0, color.V1, color.V2);
            temp.Dispose();
            AddImage(dst, src, new Point(alpha_w1, alpha_h1));
            return dst;
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
        /// <param name="offset">1-255</param>
        /// <returns></returns>
        public static Mat AddSaltNoise(Mat src, int offset)
        {
            Mat dst = new Mat();
            src.CopyTo(dst);

            Mat temp = dst - offset;

            Mat temp2 = new Mat(dst.Size, dst.Depth, dst.NumberOfChannels);
            int high = offset * 2;
            CvInvoke.Randu(temp2, new MCvScalar(0, 0, 0), new MCvScalar(high, high, high));
            dst.Dispose();
            dst = temp + temp2;
            temp.Dispose();
            temp2.Dispose();
            return dst;
        }

        public static Mat AddGaussianNoise(Mat src, int offset)
        {
            Mat dst = new Mat();
            src.CopyTo(dst);

            Mat temp = dst - offset;

            Mat temp2 = new Mat(dst.Size, dst.Depth, dst.NumberOfChannels);
            int high = offset * 2;
            CvInvoke.Randn(temp2, new MCvScalar(0, 0, 0), new MCvScalar(high, high, high));
            dst.Dispose();
            dst = temp + temp2;
            temp.Dispose();
            temp2.Dispose();
            return dst;
        }

        public static Mat AddLineNoise(Mat src, int lineNum, int thickness)
        {
            Mat dst = new Mat();
            src.CopyTo(dst);
            Random random = new Random(Guid.NewGuid().GetHashCode());
            if (thickness < 1)
            {
                thickness = 1;
            }
            for (int i = 0; i < lineNum; i++)
            {
                int x0 = random.Next(0, src.Width / 3);
                int y0 = random.Next(0, src.Height);

                int x1 = random.Next(src.Width / 2, src.Width);
                int y1 = random.Next(0, src.Height);

                int r = random.Next(0, 255);
                int g = random.Next(0, 255);
                int b = random.Next(0, 255);

                CvInvoke.Line(dst, new Point(x0, y0), new Point(x1, y1), new MCvScalar(b, g, r), thickness);
            }
            return dst;
        }

        public static Mat AddPaddingNoise(Mat src, int alpha_w, int alpha_h)
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            int alpha_w1 = random.Next(10, alpha_w + 1);
            int alpha_w2 = random.Next(10, alpha_w + 1);
            int alpha_h1 = random.Next(10, alpha_h + 1);
            int alpha_h2 = random.Next(10, alpha_h + 1);

            MCvScalar color = GetMeanColor(src);
            Mat dst = AddPadding(src, alpha_w1, alpha_w2, alpha_h1, alpha_h2, color);
            return dst;
        }
    }
}

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

        public static void AddImage(Mat src, Mat part, Point point)
        {
            VectorOfMat channels = new VectorOfMat();
            CvInvoke.Split(part, channels);

            Size size = part.Size;
            if (point.X + size.Width >= src.Width)
            {
                size = new Size(src.Width - point.X-1, size.Height);
            }
            if (point.Y + size.Height >= src.Height)
            {
                size = new Size(size.Width, src.Height - point.Y-1);
            }
            Rectangle roi = new Rectangle(point, size);
            
            Mat temp = new Mat(src, roi);
            Mat bgr = new Mat();
            CvInvoke.CvtColor(part, bgr, ColorConversion.Bgra2Bgr);
            bgr.CopyTo(temp, channels[3]);
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
    }
}

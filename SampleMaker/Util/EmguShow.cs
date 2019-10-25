using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace SampleMaker.Util
{
    public static class EmguShow
    {
        public static bool ShowEnabled = true;

        private static List<string> names = new List<string>();

        public static void Image(Mat src, string name = "lena")
        {
            if (!ShowEnabled || !IsDebug())
                return;
            if (!names.Contains(name))
            {
                CvInvoke.NamedWindow(name, Emgu.CV.CvEnum.NamedWindowType.Normal);
            }
            CvInvoke.Imshow(name, src);
            CvInvoke.WaitKey(0);
        }

        public static void Image(Mat image1, string name1, Mat image2, string name2)
        {
            if (!ShowEnabled || !IsDebug())
                return;
            if (!names.Contains(name1))
            {
                CvInvoke.NamedWindow(name1, Emgu.CV.CvEnum.NamedWindowType.Normal);
            }
            if (!names.Contains(name2))
            {
                CvInvoke.NamedWindow(name2, Emgu.CV.CvEnum.NamedWindowType.Normal);
            }
            CvInvoke.Imshow(name1, image1);
            CvInvoke.Imshow(name2, image2);
            CvInvoke.WaitKey(0);
        }

        private static bool IsDebug()
        {
#if DEBUG
            return true;
#else
            return false;
#endif
        }
    }
}

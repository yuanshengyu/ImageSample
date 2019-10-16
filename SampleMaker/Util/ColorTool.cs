using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SampleMaker.Util
{
    public static class ColorTool
    {
        public static string ToHex(Color color)
        {
            if (color.IsEmpty)
                return "#000000";
            return string.Format("#{0:X2}{1:X2}{2:X2}", color.R, color.G, color.B);
        }

        public static Color ToColor(string hex)
        {
            if(hex.Length != 7)
            {
                return Color.Black;
            }
            int r = Convert.ToInt32(hex.Substring(1, 2), 16);
            int g = Convert.ToInt32(hex.Substring(3, 2), 16);
            int b = Convert.ToInt32(hex.Substring(5, 2), 16);
            return Color.FromArgb(r, g, b);
        }
    }
}

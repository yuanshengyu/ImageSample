using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SampleMaker.Util
{
    public class WordTool
    {
        public static Bitmap GetBitmap(string words, Color color, Font font)
        {
            SizeF textSize = MeasureString(words, font);
            float textWidth = words.Length * font.Size;
            Bitmap bitmap = new Bitmap((int)textSize.Width, (int)textSize.Height);
            Brush brush = new SolidBrush(color);
            Graphics g = Graphics.FromImage(bitmap);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            RectangleF area = new RectangleF(0, 0, textSize.Width, textSize.Height);
            g.DrawString(words, font, brush, area);
            g.Dispose();
            return bitmap;
        }

        private static SizeF MeasureString(string content, Font font)
        {
            int width = (int)(content.Length * font.Size*2);
            using (Bitmap bitmap = new Bitmap(width, (int)(font.Size * 2)))
            {
                using(Graphics g = Graphics.FromImage(bitmap))
                {
                    return g.MeasureString(content, font);
                }
            }
        }
    }
}

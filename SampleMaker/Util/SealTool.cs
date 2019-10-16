using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;

namespace SampleMaker.Util
{
    public static class SealTool
    {
        private const int LETTER_SPACE = 4;//字体间距
        private const int BITMAP_SIZE = 160;
        private const int INVOICE_SEAL_W = 400;
        private const int INVOICE_SEAL_H = 300;

        public static Bitmap CreateInvoiceSeal(string company, string taxId)
        {
            Bitmap bitmap = new Bitmap(INVOICE_SEAL_W, INVOICE_SEAL_H);//画图初始化
            Graphics g = Graphics.FromImage(bitmap);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            int circularityWidth = 8;
            Pen myPen = new Pen(Color.Red, circularityWidth);//设置画笔的颜色
            Rectangle rect = new Rectangle(circularityWidth, circularityWidth, INVOICE_SEAL_W - circularityWidth * 2, INVOICE_SEAL_H - circularityWidth * 2);
            g.DrawEllipse(myPen, rect);

            int a = INVOICE_SEAL_W / 2, b = INVOICE_SEAL_H / 2;
            int company_a = a - 5 - 54, company_b = b - 5 - 54 ; // 字与边线内侧距离0.5mm，文字高4.2mm
            Font companyFont = new Font("Adobe 仿宋 Std R", 40, FontStyle.Regular, GraphicsUnit.Pixel);
            Pen textPen = new Pen(Color.Red, 1);
            var tuples = GetPositions(company.Length, company_a, company_b);
            for(int i = 0; i < company.Length; i++)
            {
                var tuple = tuples[i];
                string text = company[i].ToString();
                float angle = (i == 0 || i == company.Length - 1) ? 180 + tuple.Item2 : tuple.Item2;

                DrawRotatedText(g, text, angle, tuple.Item1, companyFont, textPen);
            }
            
            Font taxFont = new Font("Rockwell Condensed", 38, FontStyle.Regular, GraphicsUnit.Pixel);
            var taxSize = g.MeasureString(taxId, taxFont);
            PointF taxPoint = new PointF((INVOICE_SEAL_W - taxSize.Width) / 2, INVOICE_SEAL_H / 2 - taxSize.Height/2+2);
            DrawText(g, taxId, taxPoint, taxFont, textPen);
            //g.DrawString(taxId, taxFont, new SolidBrush(Color.Red), taxPoint);

            Font invoiceFont = new Font("Adobe 仿宋 Std R", 40, FontStyle.Regular, GraphicsUnit.Pixel);
            var invoiceSize = g.MeasureString("发票专用章", invoiceFont);
            PointF invoicePoint = new PointF((INVOICE_SEAL_W - invoiceSize.Width) / 2, INVOICE_SEAL_H / 2+45);
            DrawText(g, "发票专用章", invoicePoint, invoiceFont, textPen);
            //g.DrawString("发票专用章", invoiceFont, new SolidBrush(Color.Red), invoicePoint);

            g.Dispose();
            return bitmap;
        }

        /// <summary>
        /// 创建公司公共印章
        /// </summary>
        /// <param name="company">公司名字</param>
        /// <param name="department">部门名字</param>
        /// <returns></returns>
        public static Bitmap CreatePublicSeal(string company, string department)
        {
            string star_Str = "★";
            Bitmap bitmap = new Bitmap(BITMAP_SIZE, BITMAP_SIZE);//画图初始化
            Graphics g = Graphics.FromImage(bitmap);
            g.SmoothingMode = SmoothingMode.AntiAlias;//消除绘制图形的锯齿
            //g.Clear(Color.White);
            int circularityWidth = 4;
            int diameter = BITMAP_SIZE; // 圆直径
            Pen myPen = new Pen(Color.Red, circularityWidth);//设置画笔的颜色
            Rectangle rect = new Rectangle(circularityWidth, circularityWidth, diameter - circularityWidth * 2, diameter - circularityWidth * 2);
            g.DrawEllipse(myPen, rect); //绘制圆 

            Font star_Font = new Font("Arial", 30, FontStyle.Regular);//设置星号的字体样式
            SizeF star_Size = g.MeasureString(star_Str, star_Font);//对指定字符串进行测量
            //要指定的位置绘制星号
            PointF star_xy = new PointF(diameter / 2 - star_Size.Width / 2, diameter / 2 - star_Size.Height / 2);
            g.DrawString(star_Str, star_Font, myPen.Brush, star_xy);

            //绘制中间文字
            string var_txt = department;
            int var_len = var_txt.Length;
            Font Var_Font = new Font("Arial", 22 - var_len * 2, FontStyle.Bold);//定义部门字体的字体样式
            SizeF Var_Size = g.MeasureString(var_txt, Var_Font);//对指定字符串进行测量
            //要指定的位置绘制中间文字

            PointF Var_xy = new PointF(diameter / 2 - Var_Size.Width / 2, diameter / 2 + star_Size.Height / 2 - Var_Size.Height / 2 + 5);
            g.DrawString(var_txt, Var_Font, myPen.Brush, Var_xy);

            string text_txt = company + "专用";
            int text_len = text_txt.Length;//获取字符串的长度
            Font text_Font = new Font("Arial", 25 - text_len, FontStyle.Bold);//定义公司名字的字体的样式
            Pen myPenbush = new Pen(Color.White, circularityWidth);

            float[] fCharWidth = new float[text_len];
            float fTotalWidth = ComputeStringLength(text_txt, g, fCharWidth, LETTER_SPACE, CharDirection.Center, text_Font);
            // Compute arc's start-angle and end-angle
            double fStartAngle, fSweepAngle;
            int space = 16;//字体圆弧所在圆
            Rectangle NewRect = new Rectangle(new Point(rect.X + space, rect.Y + space), new Size(rect.Width - 2 * space, rect.Height - 2 * space));
            fSweepAngle = fTotalWidth * 360 / (NewRect.Width * Math.PI);
            fStartAngle = 270 - fSweepAngle / 2;
            // Compute every character's position and angle
            PointF[] pntChars = new PointF[text_len];
            double[] fCharAngle = new double[text_len];
            ComputeCharPos(NewRect, fCharWidth, pntChars, fCharAngle, fStartAngle);
            int degree = 90;
            for (int i = 0; i < text_len; i++)
            {
                DrawRotatedText(g, text_txt[i].ToString(), (float)(fCharAngle[i] + degree), pntChars[i], text_Font, myPenbush);
            }
            return bitmap;
        }

        /// <summary>
        /// 计算字符串总长度和每个字符长度
        /// </summary>
        /// <param name="text"></param>
        /// <param name="g"></param>
        /// <param name="fCharWidth"></param>
        /// <param name="fIntervalWidth"></param>
        /// <returns></returns>
        private static float ComputeStringLength(string text, Graphics g, float[] fCharWidth, float fIntervalWidth, CharDirection direction, Font textFont)
        {
            // Init字符串格式
            StringFormat sf = new StringFormat();
            sf.Trimming = StringTrimming.None;
            sf.FormatFlags = StringFormatFlags.NoClip | StringFormatFlags.NoWrap
                | StringFormatFlags.LineLimit;
            // 衡量整个字符串长度
            SizeF size = g.MeasureString(text, textFont, (int)textFont.Style);
            RectangleF rect = new RectangleF(0f, 0f, size.Width, size.Height);
            // 测量每个字符大小
            CharacterRange[] crs = new CharacterRange[text.Length];
            for (int i = 0; i < text.Length; i++)
                crs[i] = new CharacterRange(i, 1);
            // 复位字符串格式
            sf.FormatFlags = StringFormatFlags.NoClip;
            sf.SetMeasurableCharacterRanges(crs);
            sf.Alignment = StringAlignment.Near;
            // 得到每一个字符大小
            Region[] regs = g.MeasureCharacterRanges(text, textFont, rect, sf);
            // Re-compute whole string length with space interval width
            float fTotalWidth = 0f;
            for (int i = 0; i < regs.Length; i++)
            {
                if (direction == CharDirection.Center || direction == CharDirection.OutSide)
                    fCharWidth[i] = regs[i].GetBounds(g).Width;
                else
                    fCharWidth[i] = regs[i].GetBounds(g).Height;
                fTotalWidth += fCharWidth[i] + fIntervalWidth;
            }
            fTotalWidth -= fIntervalWidth;//Remove the last interval width
            return fTotalWidth;
        }

        /// <summary>
        /// 求出每个字符的所在的点，以及相对于中心的角度
        ///1．  通过字符长度，求出字符所跨的弧度；
        ///2．  根据字符所跨的弧度，以及字符起始位置，算出字符的中心位置所对应的角度；
        ///3．  由于相对中心的角度已知，根据三角公式很容易算出字符所在弧上的点，如下图所示；
        ///4．  根据字符长度以及间隔距离，算出下一个字符的起始角度；
        ///5．  重复1直至整个字符串结束。
        /// </summary>
        /// <param name="charWidth"></param>
        /// <param name="recChars"></param>
        /// <param name="charAngle"></param>
        /// <param name="startAngle"></param>
        private static void ComputeCharPos(Rectangle region, float[] charWidth, PointF[] recChars, double[] charAngle, double startAngle)
        {
            double fSweepAngle, fCircleLength;
            //Compute the circumference
            fCircleLength = region.Width * Math.PI;

            for (int i = 0; i < charWidth.Length; i++)
            {
                //Get char sweep angle
                fSweepAngle = charWidth[i] * 360 / fCircleLength;

                //Set point angle
                charAngle[i] = startAngle + fSweepAngle / 2;

                //Get char position
                if (charAngle[i] < 270f)
                    recChars[i] = new PointF(
                        region.X + region.Width / 2
                        - (float)(region.Width / 2 *
                        Math.Sin(Math.Abs(charAngle[i] - 270) * Math.PI / 180)),
                        region.Y + region.Width / 2
                        - (float)(region.Width / 2 * Math.Cos(
                        Math.Abs(charAngle[i] - 270) * Math.PI / 180)));
                else
                    recChars[i] = new PointF(
                        region.X + region.Width / 2
                        + (float)(region.Width / 2 *
                        Math.Sin(Math.Abs(charAngle[i] - 270) * Math.PI / 180)),
                        region.Y + region.Width / 2
                        - (float)(region.Width / 2 * Math.Cos(
                        Math.Abs(charAngle[i] - 270) * Math.PI / 180)));

                //Get total sweep angle with interval space
                fSweepAngle = (charWidth[i] + LETTER_SPACE) * 360 / fCircleLength;
                startAngle += fSweepAngle;

            }
        }
        
        /// <summary>
        /// 绘制每个字符
        /// </summary>
        /// <param name="g"></param>
        /// <param name="text"></param>
        /// <param name="angle"></param>
        /// <param name="textPoint"></param>
        /// <param name="textFont"></param>
        /// <param name="myPen"></param>
        private static void DrawRotatedText(Graphics g, string text, float angle, PointF textPoint, Font textFont, Pen myPen)
        {
            // Init format
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            // Create graphics path
            GraphicsPath gp = new GraphicsPath(FillMode.Winding);
            int x = (int)textPoint.X;
            int y = (int)textPoint.Y;

            // Add string
            gp.AddString(text, textFont.FontFamily, (int)textFont.Style, textFont.Size, new Point(x, y), sf);

            // Rotate string and draw it
            Matrix matrix = new Matrix();
            matrix.RotateAt(angle, new PointF(x, y));
            g.Transform = matrix;
            g.DrawPath(myPen, gp);
            g.FillPath(new SolidBrush(Color.Red), gp);
            g.ResetTransform();
        }

        private static void DrawText(Graphics g, string text, PointF textPoint, Font textFont, Pen myPen)
        {
            // Init format
            StringFormat sf = new StringFormat();

            // Create graphics path
            GraphicsPath gp = new GraphicsPath(FillMode.Winding);

            // Add string
            gp.AddString(text, textFont.FontFamily, (int)textFont.Style, textFont.Size, textPoint, sf);

            g.DrawPath(myPen, gp);
            g.FillPath(new SolidBrush(Color.Red), gp);
        }

        /// <summary>
        /// 获取发票专用章公司名称每个文字位置
        /// </summary>
        /// <param name="company">公司名称</param>
        /// <returns></returns>
        private static Tuple<PointF, float>[] GetPositions(int len, int a, int b)
        {
            if (len < 2)
            {
                return null;
            }
            Tuple<PointF, float>[] result = new Tuple<PointF, float>[len];
            float delta = 2;
            float angleDelta = 200 / (len - 1);
            for (int i = 0; i < len; i++)
            {
                float angle = 190 - angleDelta * i;
                if (i != 0 && i != len - 1)
                {
                    angle += (len * 0.5f - i) * delta;
                }

                PointF point0 = GetEllipsePoint(a, b, angle);
                float rotateDegree = GetEllipsePointSlope(a, b, point0);
                float rotateAngle = (float)(rotateDegree * 180 / Math.PI);

                float x = point0.X + INVOICE_SEAL_W / 2;
                float y = INVOICE_SEAL_H / 2 - point0.Y;
                PointF point = new PointF(x, y);

                result[i] = new Tuple<PointF, float>(point, rotateAngle);
            }
            return result;
        }

        /// <summary>
        /// 获取椭圆上某点坐标
        /// </summary>
        /// <param name="a">长轴</param>
        /// <param name="b">横轴</param>
        /// <param name="angle">与X轴逆时针扫过的角度</param>
        /// <returns></returns>
        private static PointF GetEllipsePoint(int a, int b, float angle)
        {
            float x0 = 0, y0 = 0;
            if (angle == 180)
            {
                x0 = 0 - a;
                y0 = 0;
            }
            else if (angle == 90)
            {
                x0 = 0;
                y0 = b;
            }
            else if (angle == 0)
            {
                x0 = a;
                y0 = 0;
            }
            else
            {
                double degree = angle * Math.PI / 180;
                double tan = Math.Tan(degree);
                double t = Math.Sqrt(b * b + a * a * tan * tan);
                x0 = (float)(a * b / t);
                y0 = (float)(a * b * tan / t);
                if (angle > 90)
                {
                    x0 = 0 - x0;
                    y0 = 0 - y0;
                }
            }
            PointF point = new PointF(x0, y0);
            return point;
        }

        private static float GetEllipsePointSlope(int a, int b, PointF point)
        {
            float tan = b * b * point.X / (a * a * point.Y);
            float degree = (float)Math.Atan(tan);
            return degree;
        }

        public enum CharDirection
        {
            Center = 0,
            OutSide = 1,
            ClockWise = 2,
            AntiClockWise = 3,
        }
    }
}

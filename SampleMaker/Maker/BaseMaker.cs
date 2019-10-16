using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using SampleMaker.Util;

namespace SampleMaker.Maker
{
    public abstract class BaseMaker
    {
        protected string templatePath = string.Empty;
        protected Dictionary<string, TemplateItem> templateItems = new Dictionary<string, TemplateItem>();
        protected Bitmap template = null;
        protected Random random = new Random(Guid.NewGuid().GetHashCode());

        public abstract Bitmap MakeOne();

        public abstract string getName();

        public void SetTempate(string templatePath, Dictionary<string, TemplateItem> items)
        {
            this.templatePath = templatePath;
            template = Bitmap.FromFile(templatePath) as Bitmap;
            templateItems = items;
        }

        public string Check(Dictionary<string, TemplateItem> items)
        {
            string[] keys = getNeedKeys();
            if (keys.Any(k => !items.ContainsKey(k)))
            {
                return "缺少必要项";
            }
            return "";
        }

        protected string getRandomNumbers(int len)
        {
            StringBuilder sb = new StringBuilder(len);
            for (int i = 0; i < len; i++)
            {
                sb.Append(random.Next(0, 10));
            }
            return sb.ToString();
        }

        /// <summary>
        /// 获取由数字和大写英文字母组成的字符串
        /// </summary>
        /// <param name="len">字符串长度</param>
        /// <returns></returns>
        protected string getRandomChars(int len)
        {
            List<char> chars = new List<char>();
            for(int i = 0; i < 9; i++)
            {
                chars.Add((char)(48 + i));
            }
            for (int i = 0; i < 26; i++)
            {
                chars.Add((char)(65 + i));
            }
            StringBuilder sb = new StringBuilder(len);
            for(int i = 0; i < len; i++)
            {
                sb.Append(getRandomItem(chars));
            }
            return sb.ToString();
        }

        protected T getRandomItem<T>(List<T> items)
        {
            int index = random.Next(0, items.Count);
            T item = items[index];
            return item;
        }

        protected T getRandomItem<T>(T[] items)
        {
            int index = random.Next(0, items.Length);
            T item = items[index];
            return item;
        }

        protected Color getColor(TemplateItem item)
        {
            return ColorTool.ToColor(item.ColorHex);
        }

        protected Font getFont(TemplateItem item)
        {
            return new Font(item.FontName, item.FontSize, item.FontStyle);
        }

        protected void drawImage(Graphics g, Bitmap bitmap, TemplateItem item)
        {
            double h1 = bitmap.Height;
            double h2 = item.Height;
            Bitmap temp = ImageHelper.ZoomImage(bitmap, h1/h2);
            g.DrawImage(temp, new Point(item.X, item.Y));
            temp.Dispose();
        }

        protected abstract string[] getNeedKeys();

    }
}

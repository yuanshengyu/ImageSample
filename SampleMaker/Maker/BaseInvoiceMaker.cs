using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using SampleMaker.Util;

namespace SampleMaker.Maker
{
    /// <summary>
    /// 发票基类
    /// </summary>
    public abstract class BaseInvoiceMaker : BaseMaker
    {
        private List<string> provinces = new List<string>();

        public BaseInvoiceMaker()
        {
            loadProvinces();
        }

        protected Bitmap getInvoiceSeal(string company, string taxNo, bool colorDecay = true)
        {
            // 红色随机衰减
            double rate = random.Next(3, 10) / 10.0f;
            int alpha = colorDecay?(int)(random.Next(3, 10) *25.5) : 255;
            Color color = Color.FromArgb(alpha, Color.Red.R, Color.Red.G, Color.Red.B);
            return SealTool.CreateInvoiceSeal(company, taxNo, color);
        }

        protected string getCompanyName(int minLen, int maxLen)
        {
            if (minLen <= 4 || maxLen <= minLen)
            {
                return "有限公司";
            }
            int len = random.Next(minLen - 4, maxLen - 4);
            string name = NameTool.GetRandomWord(len, random);
            return name + "有限公司";
        }

        protected string getInvoiceNo(int len)
        {
            return getRandomNumbers(len);
        }

        protected string getMachineNo(int len = 12)
        {
            return getRandomNumbers(len);
        }

        protected string getProvince()
        {
            return getRandomItem(provinces);
        }

        protected string getTaxNo()
        {
            StringBuilder sb = new StringBuilder("91");
            string str = getRandomChars(16);
            sb.Append(str);
            return sb.ToString();
        }

        protected string getSimpleTaxNo()
        {
            StringBuilder sb = new StringBuilder("91");
            string str = getRandomNumbers(16);
            sb.Append(str);
            return sb.ToString();
        }

        private void loadProvinces()
        {
            string cityPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "files\\city.txt");
            string[] lines = File.ReadAllLines(cityPath);
            foreach (var line in lines)
            {
                string[] parts = line.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 2)
                {
                    string province = parts[0].Substring(0, 2);
                    if (province != "黑龙" && !provinces.Contains(province))
                    {
                        provinces.Add(province);
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
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

        protected string getCompanyName(int minLen, int maxLen)
        {
            if (minLen <= 4 || maxLen <= minLen)
            {
                return "有限公司";
            }
            int len = random.Next(minLen - 4, maxLen - 4);
            string name = NameTool.GetRandomWord(len);
            return name + "有限公司";
        }

        protected string getInvoiceNo(int len)
        {
            StringBuilder sb = new StringBuilder(len);
            for (int i = 0; i < len; i++)
            {
                sb.Append(random.Next(0, 10));
            }
            return sb.ToString();
        }

        protected string getProvince()
        {
            return getRandomItem(provinces);
        }

        private void loadProvinces()
        {
            string cityPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "city.txt");
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

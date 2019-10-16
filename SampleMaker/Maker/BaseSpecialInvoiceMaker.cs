using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SampleMaker.Util;

namespace SampleMaker.Maker
{
    public abstract class BaseSpecialInvoiceMaker : BaseMaker
    {

        private List<string> provinces = new List<string>();

        public override Bitmap MakeOne()
        {
            return null;
        }

        private DetailItem getDetailItem()
        {
            DetailItem item = new DetailItem();
            item.Name = NameTool.GetRandomWord(random.Next(4, 8));
            int num = random.Next(1, 10);
            item.Price = random.NextDouble() * 100;
            item.Amount = num * item.Price;
            item.TaxRate = getRandomItem(new List<double> { 0, 0.3, 0.6, 0.8, 0.11, 0.16, 0.17 });
            item.Tax = item.Amount * item.TaxRate;
            return item;
        }

        private string getCipher()
        {
            StringBuilder sb = new StringBuilder();
            char[] cs = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '<', '>', '/', '*', '+', '-' };
            int len = getRandomItem(new List<int> { 84, 108, 112 });
            for(int i = 0; i < len; i++)
            {
                sb.Append(getRandomItem(cs));
            }
            return sb.ToString();
        }

        private string getBank()
        {
            int len = random.Next(4, 12);
            string name = NameTool.GetRandomWord(len);
            StringBuilder sb = new StringBuilder(name);
            sb.Append(getRandomNumbers(random.Next(12, 16)));
            return sb.ToString();
        }

        private string getAddress()
        {
            int len = random.Next(10, 18);
            string name = NameTool.GetRandomWord(len);
            StringBuilder sb = new StringBuilder();
            sb.Append(name).Append(" ");
            sb.Append(getRandomNumbers(4)).Append("-");
            sb.Append(getRandomNumbers(8));
            return sb.ToString();
        }

        private string getTaxId()
        {
            StringBuilder sb = new StringBuilder("91");
            string str = getRandomChars(16);
            sb.Append(str);
            return sb.ToString();
        }

        private string getCompanyName()
        {
            int len = random.Next(6, 15);
            string name = NameTool.GetRandomWord(len);
            return name + "有限公司";
        }

        private DateTime getInvoiceTime()
        {
            return DateTime.Now.AddMinutes(0 - random.Next(1, 500000));
        }

        private string getInvoiceNo()
        {
            int len = getRandomItem(new List<int>{ 8, 10, 12});
            StringBuilder sb = new StringBuilder(len);
            for (int i = 0; i < len; i++)
            {
                sb.Append(random.Next(0, 10));
            }
            return sb.ToString();
        }

        private string getInvoiceCode()
        {
            int len = random.Next(0, 2) == 0 ? 10 : 12;
            StringBuilder sb = new StringBuilder(len);
            if (len == 12)
            {
                sb.Append(random.Next(0, 2)); // 0或1开头
            }

            List<Tuple<int, int>> tuples = new List<Tuple<int, int>>();
            tuples.Add(new Tuple<int, int>(1100, 1600));
            tuples.Add(new Tuple<int, int>(2100, 2400));
            tuples.Add(new Tuple<int, int>(3100, 3800));
            tuples.Add(new Tuple<int, int>(4100, 4700));
            tuples.Add(new Tuple<int, int>(5000, 5500));
            tuples.Add(new Tuple<int, int>(6100, 6600));
            var tuple = getRandomItem(tuples);
            int districtNo = random.Next(tuple.Item1, tuple.Item2);
            sb.Append(districtNo);
            sb.Append(random.Next(10, 20));
            if (len == 10)
            {
                sb.Append(random.Next(0, 10));
                sb.Append(random.Next(0, 2) == 0 ? 1 : 5);
            }
            else
            {
                for(int i = 0; i < 5; i++)
                {
                    sb.Append(random.Next(0, 10));
                }
            }
            return sb.ToString();
        }

        private string getProvince()
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

        protected abstract Color getMainColor();

        public override string getName()
        {
            return "special_invoice";
        }

        protected override string[] getNeedKeys()
        {
            string[] keys = { "InvoiceCode", "InvoiceNo", "InvoiceDate", "PrintCode", "PrintNo", "Province", "P_Name",
                "P_TaxId", "P_Addr", "P_Bank", "S_Name", "S_TaxId", "S_Addr", "S_Bank", "Qrcode", "Cipher1", "Cipher2", "Cipher3", "Cipher4",
                "D_Name1", "D_Price1", "D_Num1", "D_Amount1", "D_TaxRate1", "D_Tax1",
                "D_Name2", "D_Price2", "D_Num2", "D_Amount2", "D_TaxRate2", "D_Tax2",
                "D_Name3", "D_Price3", "D_Num3", "D_Amount3", "D_TaxRate3", "D_Tax3",
                "D_Name4", "D_Price4", "D_Num4", "D_Amount4", "D_TaxRate4", "D_Tax4",
                "D_Name5", "D_Price5", "D_Num5", "D_Amount5", "D_TaxRate5", "D_Tax5",
                "TotalAmount", "TotalTax", "TotalAmountTax", "TotalAmountTaxChinese",
                "Remark", "Payee", "Check", "Drawer" };
            return keys;
        }
    }

    class DetailItem
    {
        public string Name { get; set; }

        public int Number { get; set; }

        public double Price { get; set; }

        public double Amount { get; set; }

        public double TaxRate { get; set; }

        public double Tax { get; set; }
    }
}

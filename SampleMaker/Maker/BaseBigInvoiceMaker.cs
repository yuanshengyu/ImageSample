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
    /// <summary>
    /// 增值税大票基类
    /// </summary>
    public abstract class BaseBigInvoiceMaker : BaseInvoiceMaker
    {

        protected Bitmap getQRCode(string code, string no, DateTime date, double totalAmount, Color color)
        {
            string qrcode = $"01,01,{code},{no},{totalAmount:F2},{date.ToString("yyyyMMdd")},,B0C6,";
            return QRCodeTool.CreateQRCode(qrcode, 4, color);
        }

        protected Bitmap getInvoiceSeal(string company, string taxId)
        {
            Bitmap seal = SealTool.CreateInvoiceSeal(company, taxId);
            return seal;
        }

        protected string getRemark()
        {
            return getRandomChars(random.Next(8, 20));
        }

        protected List<DetailItem> getDetailItems(int len)
        {
            List<DetailItem> items = new List<DetailItem>();
            for(int i = 0; i < len; i++)
            {
                var item = getDetailItem();
                items.Add(item);
            }
            return items;
        }

        protected DetailItem getDetailItem()
        {
            DetailItem item = new DetailItem();
            item.Name = NameTool.GetRandomWord(random.Next(4, 8));
            int num = random.Next(1, 10);
            item.Number = num;
            item.Price = Math.Round(random.NextDouble() * 100, 2);
            item.Amount = Math.Round(num * item.Price, 2);
            item.TaxRate = getRandomItem(new List<double> { 0, 0.03, 0.06, 0.08, 0.11, 0.16, 0.17, 0.03, 0.06, 0.08, 0.11, 0.16, 0.17 });
            item.Tax = Math.Round(item.Amount * item.TaxRate, 2);
            return item;
        }

        protected string getCipher(int len)
        {
            StringBuilder sb = new StringBuilder();
            char[] cs = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '<', '>', '/', '*', '+', '-' };
            //int len = getRandomItem(new List<int> { 84, 108, 112 });
            for(int i = 0; i < len; i++)
            {
                sb.Append(getRandomItem(cs));
            }
            return sb.ToString();
        }

        protected string getBank()
        {
            int len = random.Next(4, 12);
            string name = NameTool.GetRandomWord(len);
            StringBuilder sb = new StringBuilder(name);
            sb.Append(getRandomNumbers(random.Next(12, 16)));
            return sb.ToString();
        }

        protected string getAddress()
        {
            int len = random.Next(10, 18);
            string name = NameTool.GetRandomWord(len);
            StringBuilder sb = new StringBuilder();
            sb.Append(name).Append(" ");
            sb.Append(getRandomNumbers(4)).Append("-");
            sb.Append(getRandomNumbers(8));
            return sb.ToString();
        }

        protected string getTaxId()
        {
            StringBuilder sb = new StringBuilder("91");
            string str = getRandomChars(16);
            sb.Append(str);
            return sb.ToString();
        }

        protected string getSimpleTaxId()
        {
            StringBuilder sb = new StringBuilder("91");
            string str = getRandomNumbers(16);
            sb.Append(str);
            return sb.ToString();
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
                "Remark", "Payee", "Check", "Drawer", "Seal" };
            return keys;
        }
    }

    public class DetailItem
    {
        public string Name { get; set; }

        public int Number { get; set; }

        public double Price { get; set; }

        public double Amount { get; set; }

        public double TaxRate { get; set; }

        public double Tax { get; set; }
    }
}

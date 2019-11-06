using SampleMaker.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMaker.Maker
{
    /// <summary>
    /// 卷票
    /// </summary>
    public class JPInvoiceMaker : BaseInvoiceMaker
    {
        protected override Tuple<Dictionary<string, string>, Dictionary<string, Bitmap>> getTemplateValues()
        {
            Dictionary<string, string> text = new Dictionary<string, string>();
            string province = getProvince();
            text["Province"] = province;
            text["Province2"] = $"{province.Substring(0, 1)}   {province.Substring(1)}";
            string invoiceCode = getInvoiceCode();
            text["InvoiceCode"] = invoiceCode;
            string invoiceNo = getInvoiceNo(8);
            text["InvoiceNo"] = invoiceNo;
            text["PrintNo"] = invoiceNo;
            text["MachineNo"] = getMachineNo();

            CompanyInfo seller = CompanyTool.GetRandomCompany(random);
            text["SellerName"] = seller.Name;
            text["SellerTaxNo"] = seller.TaxNo;
            var invoiceTime = getRandomTimeBefore();
            text["InvoiceTime"] = invoiceTime.ToString("yyyy-MM-dd");
            text["Cashier"] = NameTool.GetRandomName(random);

            CompanyInfo buyer = CompanyTool.GetRandomCompany(random);
            text["BuyerName"] = buyer.Name;
            text["BuyerTaxNo"] = buyer.TaxNo;
            var detailItems = getDetailItems(random.Next(1, 6));
            double totalAmount = detailItems.Sum(d => d.Amount);
            text["TotalAmount"] = totalAmount.ToString("F2");
            string chinese = CommonTool.GetChineseMoney(totalAmount);
            if (chinese.EndsWith("整"))
            {
                chinese = chinese.Substring(0, chinese.Length - 1);
            }
            text["TotalAmountChinese"] = chinese;
            for (int i = 1; i < detailItems.Count + 1; i++)
            {
                text["D_Name" + i] = detailItems[i - 1].Name;
                text["D_Price" + i] = detailItems[i - 1].Price.ToString("F2");
                text["D_Num" + i] = detailItems[i - 1].Number.ToString();
                text["D_Amount" + i] = detailItems[i - 1].Amount.ToString("F2");
            }
            text["CheckCode"] = getRandomNumbers(20);

            Dictionary<string, Bitmap> image = new Dictionary<string, Bitmap>();
            image["Seal"] = getInvoiceSeal(seller.Name, seller.TaxNo);
            image["QRCode"] = getQRCode(invoiceCode, invoiceNo, Color.Black);
            return new Tuple<Dictionary<string, string>, Dictionary<string, Bitmap>>(text, image);
        }

        private string getInvoiceCode()
        {
            int len = getRandomItem(new List<int> { 10, 12 });
            StringBuilder sb = new StringBuilder(12);
            sb.Append("0");

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
            for (int i = 0; i < 3; i++)
            {
                sb.Append(random.Next(0, 10));
            }
            sb.Append(getRandomItem(new string[] { "06", "07" }));
            return sb.ToString();
        }

        protected override string[] getNeedKeys()
        {
            return new string[]{ "Province", "Province2", "InvoiceCode", "InvoiceNo", "PrintNo", "MachineNo",
                "SellerName", "SellerTaxNo", "InvoiceTime", "Cashier", "BuyerName", "BuyerTaxNo",
                "D_Name1", "D_Price1", "D_Num1", "D_Amount1", "D_Name2", "D_Price2", "D_Num2", "D_Amount2",
                "D_Name3", "D_Price3", "D_Num3", "D_Amount3", "D_Name4", "D_Price4", "D_Num4", "D_Amount4",
                "D_Name5", "D_Price5", "D_Num5", "D_Amount5", "TotalAmount", "TotalAmountChinese",
                "CheckCode", "Seal", "QRCode"};
        }

        public override string getName()
        {
            return "jp";
        }

        protected Bitmap getQRCode(string code, string no, Color color)
        {
            string qrcode = $"01,11,{code},{no},,,,7BF0,";
            return QRCodeTool.CreateQRCode(qrcode, 4, color);
        }

        protected Bitmap getInvoiceSeal(string company, string taxId)
        {
            Bitmap seal = getInvoiceSeal(company, taxId, false);
            return seal;
        }

        protected List<DetailItem> getDetailItems(int len)
        {
            List<DetailItem> items = new List<DetailItem>();
            for (int i = 0; i < len; i++)
            {
                var item = getDetailItem();
                items.Add(item);
            }
            return items;
        }

        protected DetailItem getDetailItem()
        {
            DetailItem item = new DetailItem();
            item.Name = NameTool.GetRandomWord(random.Next(4, 7));
            int num = random.Next(100, 10000);
            item.Number = num;
            item.Price = Math.Round(random.NextDouble() * 100, 2);
            item.Amount = Math.Round(num * item.Price / 100, 2);
            return item;
        }
    }
}

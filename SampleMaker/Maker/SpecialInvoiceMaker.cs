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
    /// 增值税专票
    /// </summary>
    public class SpecialInvoiceMaker : BaseBigInvoiceMaker
    {

        protected override Tuple<Dictionary<string, string>, Dictionary<string, Bitmap>> getTemplateValues()
        {
            Dictionary<string, string> text = new Dictionary<string, string>();
            Dictionary<string, Bitmap> image = new Dictionary<string, Bitmap>();
            string invoiceCode = getInvoiceCode();
            string invoiceNo = getInvoiceNo(8);
            DateTime invoiceDate = getRandomTimeBefore();
            string p_taxId = getTaxId();
            string s_name = getCompanyName(8, 11);
            string s_taxId = getSimpleTaxId();
            
            var detailItems = getDetailItems(random.Next(1, 6));
            double totalAmount = detailItems.Sum(d => d.Amount);
            double totalTax = detailItems.Sum(d => d.Tax);
            double totalAmountTax = totalAmount + totalTax;
            text["InvoiceCode"] = invoiceCode;
            text["InvoiceNo"] = invoiceNo;
            text["InvoiceDate"] = invoiceDate.ToString("yyyy年MM月dd日");
            text["PrintCode"] = invoiceCode;
            text["PrintNo"] = invoiceNo;
            text["Province"] = getProvince();
            text["P_Name"] = getCompanyName(10, 19);
            text["P_TaxId"] = p_taxId;
            text["P_Addr"] = getAddress();
            text["P_Bank"] = getBank();
            text["S_Name"] = s_name;
            text["S_TaxId"] = s_taxId;
            text["S_Addr"] = getAddress();
            text["S_Bank"] = getBank();
            int cipherLen = getRandomItem(new List<int> { 21, 27, 28 });
            text["Cipher1"] = getCipher(cipherLen);
            text["Cipher2"] = getCipher(cipherLen);
            text["Cipher3"] = getCipher(cipherLen);
            text["Cipher4"] = getCipher(cipherLen);
            if (detailItems.Count > 0)
            {
                text["D_Name1"] = detailItems[0].Name;
                text["D_Price1"] = detailItems[0].Price.ToString("F2");
                text["D_Num1"] = detailItems[0].Number.ToString();
                text["D_Amount1"] = detailItems[0].Amount.ToString("F2");
                text["D_TaxRate1"] = detailItems[0].TaxRate == 0 ? "*" : string.Format("{0:F0}%", detailItems[0].TaxRate * 100);
                text["D_Tax1"] = detailItems[0].Tax.ToString("F2");
            }
            if (detailItems.Count > 1)
            {
                text["D_Name2"] = detailItems[1].Name;
                text["D_Price2"] = detailItems[1].Price.ToString("F2");
                text["D_Num2"] = detailItems[1].Number.ToString();
                text["D_Amount2"] = detailItems[1].Amount.ToString("F2");
                text["D_TaxRate2"] = detailItems[0].TaxRate == 0 ? "*" : string.Format("{0:F0}%", detailItems[1].TaxRate * 100);
                text["D_Tax2"] = detailItems[1].Tax.ToString("F2");
            }
            if (detailItems.Count > 2)
            {
                text["D_Name3"] = detailItems[2].Name;
                text["D_Price3"] = detailItems[2].Price.ToString("F2");
                text["D_Num3"] = detailItems[2].Number.ToString();
                text["D_Amount3"] = detailItems[2].Amount.ToString("F2");
                text["D_TaxRate3"] = detailItems[0].TaxRate == 0 ? "*" : string.Format("{0:F0}%", detailItems[2].TaxRate * 100);
                text["D_Tax3"] = detailItems[2].Tax.ToString("F2");
            }
            if (detailItems.Count > 3)
            {
                text["D_Name4"] = detailItems[3].Name;
                text["D_Price4"] = detailItems[3].Price.ToString("F2");
                text["D_Num4"] = detailItems[3].Number.ToString();
                text["D_Amount4"] = detailItems[3].Amount.ToString("F2");
                text["D_TaxRate4"] = detailItems[0].TaxRate == 0 ? "*" : string.Format("{0:F0}%", detailItems[3].TaxRate * 100);
                text["D_Tax4"] = detailItems[3].Tax.ToString("F2");
            }
            if (detailItems.Count > 4)
            {
                text["D_Name5"] = detailItems[4].Name;
                text["D_Price5"] = detailItems[4].Price.ToString("F2");
                text["D_Num5"] = detailItems[4].Number.ToString();
                text["D_Amount5"] = detailItems[4].Amount.ToString("F2");
                text["D_TaxRate5"] = detailItems[0].TaxRate == 0 ? "*" : string.Format("{0:F0}%", detailItems[4].TaxRate * 100);
                text["D_Tax5"] = detailItems[4].Tax.ToString("F2");
            }
            text["TotalAmount"] = totalAmount.ToString("F2");
            text["TotalTax"] = totalTax.ToString("F2");
            text["TotalAmountTax"] = totalTax.ToString("F2");
            text["TotalAmountTaxChinese"] = CommonTool.GetChineseMoney(totalAmountTax);
            text["Remark"] = getRemark();
            text["Payee"] = NameTool.GetRandomName(true);
            text["Check"] = NameTool.GetRandomName(true);
            text["Drawer"] = NameTool.GetRandomName(true);

            Color color = ColorTool.ToColor(templateItems["PrintCode"].ColorHex);
            Bitmap qrcode = getQRCode(invoiceCode, invoiceNo, invoiceDate, totalAmount, color);
            Bitmap seal = getInvoiceSeal(s_name, s_taxId);
            image["Qrcode"] = qrcode;
            image["Seal"] = seal;

            var sealItem = templateItems["Seal"];
            sealItem.X = random.Next(template.Width / 5, (int)(template.Width * 0.8));
            sealItem.Y = random.Next(template.Height / 2, (int)(template.Height * 0.6));

            return new Tuple<Dictionary<string, string>, Dictionary<string, Bitmap>>(text, image);
        }

        private string getInvoiceCode()
        {
            int len = getRandomItem(new List<int> { 10, 12 });
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
                sb.Append(random.Next(0, 10));
                sb.Append(random.Next(0, 10));
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    sb.Append(random.Next(0, 10));
                }
            }
            return sb.ToString();
        }

        public override string getName()
        {
            return "special_invoice";
        }
    }
}

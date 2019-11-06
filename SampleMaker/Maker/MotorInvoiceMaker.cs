using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMaker.Maker
{
    /// <summary>
    /// 机动车
    /// </summary>
    public class MotorInvoiceMaker : BaseInvoiceMaker
    {
        protected override Tuple<Dictionary<string, string>, Dictionary<string, Bitmap>> getTemplateValues()
        {
            throw new NotImplementedException();
        }

        public override string getName()
        {
            return "jd";
        }

        protected override string[] getNeedKeys()
        {
            return new string[]
            {
                "InvoiceTime", "InvoiceCode", "InvoiceNo", "PrintCode", "PrintNo", "MachineNo",
                "Cipher1", "Cipher2", "Cipher3", "Cipher4", "Cipher5", "BuyerName", "BuyerId",
                "MotorType", "MotorModel", "Place", "QNumber", "CNumber", "INumber", "EngineNo",
                "VIN", "TotalAmountTaxChinese", "TotalAmountTax", "SellerName", "SellerTele",
                "SellerTaxNo", "SellerBankNo", "SellerAddr", "SellerBank", "TaxRate", "TotalTax",
                "Revenue", "RevenueCode", "TotalAmount", "Max", "Drawer", "Seal", "QRCode"
            };
        }

    }
}

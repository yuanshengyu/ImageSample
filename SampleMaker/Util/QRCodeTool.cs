using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using QRCoder;

namespace SampleMaker.Util
{
    public static class QRCodeTool
    {
        public static Bitmap CreateQRCode(string code, int pixel)
        {
            QRCodeGenerator.ECCLevel eccLevel = QRCodeGenerator.ECCLevel.Q;
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, eccLevel))
                {
                    using (QRCode qrCode = new QRCode(qrCodeData))
                    {

                        Bitmap bitmap = qrCode.GetGraphic(pixel, Color.Black, Color.Transparent, false);
                        return bitmap;
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMaker.Maker
{
    /// <summary>
    /// 增值税专票-发票联
    /// </summary>
    public class SpecialInvoiceFPMaker : BaseSpecialInvoiceMaker
    {
        protected override Color getMainColor()
        {
            return Color.FromArgb(149, 95, 51);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMaker.Maker
{
    /// <summary>
    /// 增值税专票-抵扣联
    /// </summary>
    public class SpecialInvoiceDKMaker : BaseSpecialInvoiceMaker
    {
        protected override Color getMainColor()
        {
            return Color.FromArgb(84, 168, 82);
        }
    }
}

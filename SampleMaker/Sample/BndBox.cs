using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SampleMaker.Sample
{
    public class BndBox
    {
        public int xmin { get; set; }

        public int ymin { get; set; }

        public int xmax { get; set; }

        public int ymax { get; set; }

        public Rectangle ToRect()
        {
            return new Rectangle(xmin, ymin, xmax - xmin, ymax - ymin);
        }
    }
}

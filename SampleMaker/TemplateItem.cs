using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SampleMaker
{
    public class TemplateItem
    {
        public int X { get; set; }

        public int Y { get; set; }

        public int Height { get; set; }

        public bool IsImage { get; set; }

        //若是图片，则为图片的相对路径
        public string Content { get; set; }

        public string ColorHex { get; set; }

        public string FontName { get; set; }

        public FontStyle FontStyle { get; set; }

        public float FontSize { get; set; }
    }
}

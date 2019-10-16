using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SampleMaker.Sample
{

    public class SSDSource
    {
        public string database { get; set; }

        public string annotation { get; set; }

        public string image { get; set; }

        public string flickrid { get; set; }
    }

    public class SSDSize
    {
        public int width { get; set; }

        public int height { get; set; }

        public int depth { get; set; }
    }

    [XmlRoot("annotation")]
    public class SSDModel
    {
        public string folder { get; set; }

        public string filename { get; set; }

        public SSDSource source { get; set; }

        public SSDSize size { get; set; }

        public int segmented { get; set; }

        [XmlElement("object")]
        public List<SSDObject> objects { get; set; }
    }
}

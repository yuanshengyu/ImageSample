using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMaker.Sample
{
    public class SSDObject
    {
        public string name { get; set; }

        public string pose { get; set; }

        public int truncated { get; set; }

        public int difficult { get; set; }

        public BndBox bndbox { get; set; }

        public SSDObject()
            :this("")
        {

        }

        public SSDObject(string name)
        {
            this.name = name;
            pose = "Left";
            truncated = 0;
            difficult = 0;
            bndbox = new BndBox();
        }
    }
}

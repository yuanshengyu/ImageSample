using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using SampleMaker.Util;

namespace SampleMaker.Sample
{
    public class SSDInfo
    {
        public Bitmap Bitmap { get; set; }

        public List<SSDObject> objects { get; set; }

        public SSDInfo()
        {
            Bitmap = null;
            objects = new List<SSDObject>();
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="dir">数据集文件夹</param>
        /// <param name="name">文件名，如000001，不包含扩展名</param>
        public void Save(string dir)
        {
            if(Bitmap == null)
            {
                return;
            }
            int index = 1;
            string[] files = Directory.GetFiles(Path.Combine(dir, "JPEGImages"));
            if (files.Length > 0)
            {
                List<string> names = files.Select(file => Path.GetFileNameWithoutExtension(file)).OrderByDescending(x => x).ToList();
                string temp = names[0];
                index = int.Parse(names[0]) + 1;
            }
            string name = string.Format("{0:D6}", index);

            // bitmap --> JPEGImages
            string jpegName = $"{name}.jpg";
            string jpegPath = Path.Combine(dir, "JPEGImages", jpegName);
            Bitmap.Save(jpegPath);

            // annotation.xml --> Annotations
            string annotationPath = Path.Combine(dir, "Annotations", $"{name}.xml");

            SSDModel model = new SSDModel();
            model.folder = dir;
            model.filename = jpegName;
            model.source = new SSDSource();
            model.source.database = "make";
            model.size = new SSDSize();
            model.size.width = Bitmap.Width;
            model.size.height = Bitmap.Height;
            model.size.depth = 3;
            model.segmented = 0;
            model.objects = objects;

            XmlHelper.SerializeToXml(annotationPath, model);
        }

    }
}
 
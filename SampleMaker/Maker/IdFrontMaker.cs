using SampleMaker.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Emgu.CV;

namespace SampleMaker.Maker
{
    /// <summary>
    /// 身份证头像面
    /// </summary>
    public class IdFrontMaker : BaseMaker
    {
        private List<string> photos = new List<string>();
        private Mat photoMask = CvInvoke.Imread("images\\headmask.jpg", Emgu.CV.CvEnum.ImreadModes.Grayscale);

        public IdFrontMaker()
        {
            string imageBaseDir = ConfigurationManager.AppSettings.Get("image_dir");
            string photoDir = Path.Combine(imageBaseDir, "avatar");
            photos.AddRange(Directory.GetFiles(photoDir));
        }

        public override string getName()
        {
            return "idf";
        }

        protected override string[] getNeedKeys()
        {
            return new string[] { "Name", "Sex", "Nation", "Year", "Month", "Day", "Addr", "Addr2", "Photo", "Id" };
        }

        protected override Tuple<Dictionary<string, string>, Dictionary<string, Bitmap>> getTemplateValues()
        {
            Dictionary<string, string> texts = new Dictionary<string, string>();
            texts["Name"] = NameTool.GetRandomName(true);
            texts["Sex"] = random.Next(0, 2) == 0 ? "女" : "男";
            texts["Nation"] = getNation();
            DateTime birthday = DateTime.Now.AddDays(0 - random.Next(6570, 21600));
            texts["Year"] = birthday.ToString("yyyy");
            texts["Month"] = birthday.ToString("MM");
            texts["Day"] = birthday.ToString("dd");
            texts["Addr"] = getAddr1();
            texts["Addr2"] = getAddr2();
            texts["Id"] = getId(birthday);

            Dictionary<string, Bitmap> images = new Dictionary<string, Bitmap>();
            images["Photo"] = getPhoto();

            return new Tuple<Dictionary<string, string>, Dictionary<string, Bitmap>>(texts, images);
        }

        private string getNation()
        {
            string nation = NationTool.GetRandomNation();
            return nation.Substring(0, nation.Length - 1);
        }

        private string getAddr1()
        {
            string addr1 = "";
            while (true)
            {
                var city = CityTool.GetRandomCity();
                if ((city.Item1 + city.Item2).Length <= 8) // 防止省市信息太长
                {
                    addr1 = city.Item1 + city.Item2;
                    break;
                }
            }
            addr1 += $"{NameTool.GetRandomWord(2)}区";
            return addr1;
        }

        private string getAddr2()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{NameTool.GetRandomWord(2)}镇");
            sb.Append($"{NameTool.GetRandomWord(2)}村");
            sb.Append($"{random.Next(10, 99)}号");
            return sb.ToString();
        }

        private Bitmap getPhoto()
        {
            string photoPath = getRandomItem(photos);
            using (var src = Bitmap.FromFile(photoPath))
            {
                Bitmap result = ImageHelper.ResizeImage(src as Bitmap, src.Width, (int)(src.Width * 1.23));
                Mat mask = EmguHelper.Resize(photoMask, result.Width, result.Height);
                Mat dst = EmguHelper.SetClip(result, mask);
                result.Dispose();
                mask.Dispose();
                result = ImageHelper.CloneBitmap(dst.Bitmap);
                dst.Dispose();
                return result;
            }
        }

        private string getId(DateTime birthday)
        {
            char[] chars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'X' };
            StringBuilder sb = new StringBuilder(4);
            for (int i = 0; i < 6; i++)
            {
                int index = random.Next(0, chars.Length - 1);
                char c = chars[index];
                sb.Append(c);
            }
            sb.Append(birthday.ToString("yyyyMMdd"));
            for (int i = 0; i < 3; i++)
            {
                int index = random.Next(0, chars.Length - 1);
                char c = chars[index];
                sb.Append(c);
            }
            int index2 = random.Next(0, chars.Length);
            char c2 = chars[index2];
            sb.Append(c2);
            return sb.ToString();
        }
    }
}

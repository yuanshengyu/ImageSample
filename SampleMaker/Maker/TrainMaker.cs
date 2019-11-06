using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using SampleMaker.Util;

namespace SampleMaker.Maker
{
    public class TrainMaker : BaseMaker
    {
        private List<string> stations = new List<string>();

        public TrainMaker()
        {
            loadStations();
        }

        public override string getName()
        {
            return "train";
        }

        protected override Tuple<Dictionary<string, string>, Dictionary<string, Bitmap>> getTemplateValues()
        {
            Dictionary<string, string> text = new Dictionary<string, string>();
            string windowNo = getRandomWindowNo();
            text["RedNo"] = getRedNo(windowNo);
            text["Check"] = string.Format("{0:D2}", random.Next(1, 20));
            var fromStations = getRandomStation();
            text["From1"] = fromStations.Item1;
            text["From2"] = fromStations.Item2;
            var toStations = getRandomStation();
            text["To1"] = toStations.Item1;
            text["To2"] = toStations.Item2;
            text["TrainNo"] = getTrainNo();
            DateTime dt = getRandomTimeBefore();
            text["Year"] = dt.ToString("yyyy");
            text["Month"] = dt.ToString("MM");
            text["Day"] = dt.ToString("dd");
            text["Time"] = dt.ToString("HH:mm");
            text["CarriageNo"] = string.Format("{0:D2}", random.Next(1, 19));
            text["SeatNo"] = getRandomSeatNo();
            text["Price"] = getRandomPrice();
            text["SeatType"] = getRandomSeatType();
            text["Person"] = getRandomPerson();
            text["TicketNo"] = getTicketNo(windowNo);
            text["Place"] = "沪  售";

            string qrcode = getRandomQRCode();
            Bitmap qrcodeImage = QRCodeTool.CreateQRCode(qrcode, 4, Color.Black);
            Dictionary<string, Bitmap> image = new Dictionary<string, Bitmap>();
            image["QRCode"] = qrcodeImage;

            return new Tuple<Dictionary<string, string>, Dictionary<string, Bitmap>>(text, image);
        }

        protected override string[] getNeedKeys()
        {
            string[] keys = {"RedNo", "Check", "From1", "From2", "To1", "To2", "TrainNo", "Year", "Month", "Day", "Time",
                "CarriageNo", "SeatNo", "SeatType", "Price", "Person", "QRCode", "TicketNo", "Place"};
            return keys;
        }

        private string getTrainNo()
        {
            string type = getRandomItem(new string[] { "G", "D" });
            StringBuilder sb = new StringBuilder(type);
            int len = random.Next(3, 5);
            for (int i = 0; i < len; i++)
            {
                sb.Append(random.Next(1, 10).ToString());
            }
            return sb.ToString();
        }

        private string getTicketNo(string windowNo)
        {
            string provinceId = random.Next(11, 66).ToString();
            StringBuilder sb = new StringBuilder(provinceId);
            for (int i = 0; i < 12; i++)
            {
                sb.Append(random.Next(0, 10).ToString());
            }
            sb.Append(windowNo);
            return sb.ToString();
        }

        private string getRedNo(string windowNo)
        {
            StringBuilder sb = new StringBuilder(8);
            sb.Append(random.Next(10, 20).ToString());
            sb.Append(windowNo);
            return sb.ToString();
        }

        private string getRandomWindowNo()
        {
            char c = (char)('A' + random.Next(0, 26));
            StringBuilder sb = new StringBuilder();
            sb.Append(c);
            for (int i = 0; i < 6; i++)
            {
                sb.Append(random.Next(0, 10).ToString());
            }
            return sb.ToString();
        }

        private string getRandomSeatNo()
        {
            int no = random.Next(1, 20);
            string[] types = { "A", "B", "C", "D", "F" };
            int index = random.Next(0, types.Length);
            string type = types[index];
            return string.Format("{0:D2}{1}", no, type);
        }

        private string getRandomSeatType()
        {
            string[] types = { "商务", "一等", "二等" };
            return getRandomItem(types);
        }

        private Tuple<string, string> getRandomStation()
        {
            int index = random.Next(0, stations.Count);
            string station = stations[index];
            string pinyin = PinYinTool.ConvertToAllSpell(station);
            if(station.Length == 2)
            {
                station = $"{station.Substring(0, 1)}   {station.Substring(1, 1)}";
            }
            return new Tuple<string, string>(station, pinyin.Substring(0, 1).ToUpper() + pinyin.Substring(1));
        }

        private string getRandomPrice()
        {
            float price = random.Next(100, 10000);
            return string.Format("{0:F1}", price/10);
        }

        private string getRandomQRCode()
        {
            // 长度144
            StringBuilder sb = new StringBuilder(144);
            for(int i = 0; i < 144; i++)
            {
                sb.Append(random.Next(0, 10).ToString());
            }
            return sb.ToString();
        }

        private string getRandomPerson()
        {
            string provinceId = random.Next(11, 66).ToString();
            string addressId = string.Format("{0}{1:D2}{2:D2}", provinceId, random.Next(1, 20), random.Next(1, 30));
            DateTime dt = DateTime.Now.AddYears(0-random.Next(18, 68));
            string name = NameTool.GetRandomName(true, random);

            char[] chars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'X' };
            StringBuilder sb = new StringBuilder(4);
            for(int i = 0; i < 3; i++)
            {
                int index = random.Next(0, chars.Length-1);
                char c = chars[index];
                sb.Append(c);
            }
            int index2 = random.Next(0, chars.Length);
            char c2 = chars[index2];
            sb.Append(c2);
            return $"{addressId}{dt.ToString("yyyy")}****{sb.ToString()}{name}";
        }

        private void loadStations()
        {
            string cityPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "city.txt");
            string[] lines = File.ReadAllLines(cityPath);
            foreach(var line in lines)
            {
                string[] parts = line.Split(new char[]{ '\t'}, StringSplitOptions.RemoveEmptyEntries);
                if(parts.Length == 2)
                {
                    string city = parts[1];
                    if (city.Length < 6)
                    {
                        stations.Add(city.Substring(0, city.Length - 1));
                    }
                }
            }
        }

    }
}

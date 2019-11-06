using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMaker.Util
{
    public static class CityTool
    {
        private static Tuple<string, string>[] citys = new Tuple<string, string>[0];

        static CityTool()
        {
            List<Tuple<string, string>> temp = new List<Tuple<string, string>>();
            string cityPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "files\\city.txt");
            string[] lines = File.ReadAllLines(cityPath);
            foreach (var line in lines)
            {
                string[] parts = line.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 2)
                {
                    temp.Add(new Tuple<string, string>(parts[0], parts[1]));
                }
            }
            citys = temp.ToArray();
        }

        public static Tuple<string, string> GetRandomCity()
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            int index = random.Next(0, citys.Length);
            return citys[index];
        }
    }
}

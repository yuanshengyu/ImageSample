using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace SampleMaker.Util
{
    public static class AddressTool
    {
        private static string[] address = new string[0];

        static AddressTool()
        {
            try
            {
                string json = File.ReadAllText("files\\address.json");
                var temp = JsonConvert.DeserializeObject<List<string>>(json);
                address = temp.ToArray();
            }
            catch (Exception ex) { }
        }

        public static string GetRandomAddress(Random random)
        {
            if(address.Length == 0)
            {
                return null;
            }
            int index = random.Next(0, address.Length);
            return address[index];
        }
    }
}

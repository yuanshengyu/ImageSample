using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace SampleMaker.Util
{
    public static class CompanyTool
    {
        private static CompanyInfo[] companys = new CompanyInfo[0];

        static CompanyTool()
        {
            try
            {
                string json = File.ReadAllText("files\\company.json");
                var temp = JsonConvert.DeserializeObject<Dictionary<string, CompanyInfo>>(json);
                companys = temp.Values.ToArray();
            }
            catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        public static CompanyInfo GetRandomCompany(Random random)
        {
            if(companys.Length == 0)
            {
                return null;
            }
            int index = random.Next(0, companys.Length);
            return companys[index];
        }
    }

    public class CompanyInfo
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string TaxNo { get; set; }
    }
}

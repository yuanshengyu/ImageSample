using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMaker.Util
{
    public static class CommonTool
    {
        public static void Shuffle<T>(T[] items)
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 0; i < items.Length / 2; i++)
            {
                int j = random.Next(i + 1, items.Length);
                T temp = items[i];
                items[i] = items[j];
                items[j] = temp;
            }
        }

        public static string GetChineseMoney(double digital)
        {
            string[] MyScale = { "分", "角", "圆", "拾", "佰", "仟", "万", "拾", "佰", "仟", "亿", "拾", "佰", "仟", "兆", "拾", "佰", "仟" };
            string[] MyBase = { "零", "壹", "贰", "叁", "肆", "伍", "陆", "柒", "捌", "玖" };
            string moneyStr = "";
            bool isPoint = false;
            string moneyDigital = string.Format("{0:F2}", digital);
            if (moneyDigital.IndexOf(".") != -1)
            {
                moneyDigital = moneyDigital.Remove(moneyDigital.IndexOf("."), 1);
                isPoint = true;
            }
            for (int i = moneyDigital.Length; i > 0; i--)
            {
                int MyData = Convert.ToInt16(moneyDigital[moneyDigital.Length - i].ToString());
                moneyStr += MyBase[MyData];
                if (isPoint == true)
                {
                    moneyStr += MyScale[i - 1];
                }
                else
                {
                    moneyStr += MyScale[i + 1];
                }
            }
            while (moneyStr.Contains("零零"))
                moneyStr = moneyStr.Replace("零零", "零");
            moneyStr = moneyStr.Replace("零亿", "亿");
            moneyStr = moneyStr.Replace("亿万", "亿");
            moneyStr = moneyStr.Replace("零万", "万");
            moneyStr = moneyStr.Replace("零仟", "零");
            moneyStr = moneyStr.Replace("零佰", "零");
            moneyStr = moneyStr.Replace("零拾", "零");
            while (moneyStr.Contains("零零"))
                moneyStr = moneyStr.Replace("零零", "零");
            moneyStr = moneyStr.Replace("零圆", "圆");
            moneyStr = moneyStr.Replace("零角", "");
            moneyStr = moneyStr.Replace("零分", "");
            moneyStr = moneyStr + "整";
            return moneyStr;
        }
    }
}

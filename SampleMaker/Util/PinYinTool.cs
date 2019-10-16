using Microsoft.International.Converters.PinYinConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMaker.Util
{
    public static class PinYinTool
    {
        private static Encoding gb2312 = Encoding.GetEncoding("GB2312");

        /// <summary>
        /// 汉字转全拼
        /// </summary>
        /// <param name="strChinese"></param>
        /// <returns></returns>
        public static string ConvertToAllSpell(string strChinese)
        {
            if (strChinese.Length != 0)
            {
                var fullSpell = new StringBuilder();
                for (var i = 0; i < strChinese.Length; i++)
                {
                    var chr = strChinese[i];
                    var pinyin = GetSpell(chr);
                    fullSpell.Append(pinyin);
                }
                return fullSpell.ToString().ToLower();
            }
            return string.Empty;
        }

        /// <summary>
        /// 汉字转首字母
        /// </summary>
        /// <param name="strChinese"></param>
        /// <returns></returns>
        public static string GetFirstSpell(string strChinese)
        {
            if (strChinese.Length != 0)
            {
                var fullSpell = new StringBuilder();
                for (var i = 0; i < strChinese.Length; i++)
                {
                    var chr = strChinese[i];
                    fullSpell.Append(GetSpell(chr)[0]);
                }

                return fullSpell.ToString().ToLower();
            }
            return string.Empty;
        }

        private static string GetSpell(char chr)
        {
            var coverchr = NPinyin.Pinyin.GetPinyin(chr);
            var isChineses = ChineseChar.IsValidChar(coverchr[0]);
            if (isChineses)
            {
                var chineseChar = new ChineseChar(coverchr[0]);
                foreach (var value in chineseChar.Pinyins)
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        return value.Remove(value.Length - 1, 1);
                    }
                }
            }
            return coverchr;
        }
    }
}

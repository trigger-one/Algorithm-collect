using System.Text.RegularExpressions;
namespace Yan
{
    class Methodlibrary
    {
        /// <summary>
        /// 删除字符串中的中文
        /// </summary>
        /// <param name="str">传入需要删除中文的字符串</param>
        /// <returns>删除完毕后的剩余字符串</returns>
        public string DeleteChinesecharacterstring(string str)
        {
            string retValue = str;
            if (Regex.IsMatch(str, @"[\u4e00-\u9fa5]"))
            {
                retValue = string.Empty;
                var strsStrings = str.ToCharArray();
                for (int index = 0; index < strsStrings.Length; index++)
                {
                    if (strsStrings[index] >= 0x4e00 && strsStrings[index] <= 0x9fa5)
                    {
                        continue;
                    }
                    retValue += strsStrings[index];
                }
            }
            return retValue;
        }
        /// <summary>
        /// 删除字符串中的标点符号
        /// </summary>
        /// <param name="str">传入需要删除标点符号的字符串</param>
        /// <returns>删除完毕后的剩余字符串</returns>
        public string DeletePunctuation(string str){
            str = Regex.Replace(str,"[ \\[ \\] \\^ \\-_*×――(^)（^）$%~!@#$…&%￥—+=<>【】《》!！??？:：•`·、。，；,.;\"‘’“”-]", "");
            return str;
        }

        //TODO 待添加方法处
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Security.Cryptography;
using System.Web;
using System.Net;
using System.Text;
using System.Xml;
using System.Diagnostics;
using Yan;

namespace 各种测试用
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Stopwatch sw = new Stopwatch(); //实例化计时器类
            sw.Start(); //开始计时

            String s = "Structure describing acceleration status of the device.";
            // translate(s);


            /* int[] a = { 9, 5, 4, 6, 8, 7, 1, 3, 2 };
            String[] b = { "leetcade", "leetcode", "leet", "leetco" };
            Console.WriteLine(Algorithm.longestCommonPrefix(b)); */

            // DataManager DM = new DataManager ();
            // Tool.SetDicValue (DM, 1, 3);
            //旧打印人物参数与装备方式，已弃用
            // Console.WriteLine ("\n" + Tool.PD.ToString () + "" + Tool.ED);
            sw.Stop(); //停止计时
            Console.WriteLine("耗时" + sw.ElapsedMilliseconds + "毫秒"); //打印程序总耗时
            Console.WriteLine("程序结束");
            // Console.ReadKey ();
        }

        /// <summary>
        /// 生成xml
        /// </summary>
        static void WriteXml(string s)
        {
            XmlDocument xDoc = new XmlDocument();
            XmlDeclaration declaration = xDoc.CreateXmlDeclaration("1.0", "utf-8", "yes");
            xDoc.AppendChild(declaration);
            XmlElement elem = xDoc.CreateElement("parm");
            xDoc.AppendChild(elem);
            XmlElement elem_1 = xDoc.CreateElement("parms");
            elem.AppendChild(elem_1);
            elem_1.SetAttribute("name", "张三");
            elem_1.SetAttribute("class", "三年一班");
            elem_1.InnerText = s;
            xDoc.Save("test.xml");
        }
        /// <summary>
        /// 读取XML
        /// </summary>
        static void ReadXml()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("test.xml");
            XmlNode node = xDoc.SelectSingleNode("parm");
            XmlNode node_1 = node.SelectSingleNode("parms");
            XmlElement x = (XmlElement)node_1;
            string text = x.InnerText;
            Console.WriteLine(text);
        }
        static void translate(string s)
        {
            // 原文
            string q = s;
            // 源语言
            string from = "en";
            // 目标语言
            string to = "zh";
            // 改成您的APP ID
            string appId = "20211124001008044";
            Random rd = new Random();
            string salt = rd.Next(100000).ToString();
            // 改成您的密钥
            string secretKey = "YKIfaL9MNZ6Fr4XFD8iQ";
            string sign = EncryptString(appId + q + salt + secretKey);
            string url = "http://api.fanyi.baidu.com/api/trans/vip/translate?";
            url += "q=" + HttpUtility.UrlEncode(q);
            url += "&from=" + from;
            url += "&to=" + to;
            url += "&appid=" + appId;
            url += "&salt=" + salt;
            url += "&sign=" + sign;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";
            request.UserAgent = null;
            request.Timeout = 6000;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            Console.WriteLine(retString);

            // WriteXml(retString);
            // Console.ReadLine();
        }
        public static string EncryptString(string str)
        {
            MD5 md5 = MD5.Create();
            // 将字符串转换成字节数组
            byte[] byteOld = Encoding.UTF8.GetBytes(str);
            // 调用加密方法
            byte[] byteNew = md5.ComputeHash(byteOld);
            // 将加密结果转换为字符串
            StringBuilder sb = new StringBuilder();
            foreach (byte b in byteNew)
            {
                // 将字节转换成16进制表示的字符串，
                sb.Append(b.ToString("x2"));
            }
            // 返回加密的字符串
            return sb.ToString();
        }
    }
}

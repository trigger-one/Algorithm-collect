using System.Diagnostics;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Xml;
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

            /*  String s = "Structure describing acceleration status of the device.";
             s = translate(s);
             WriteXml(s);
             Console.WriteLine(s); */

            Algorithm AL = new Algorithm();
            /* var a = AL.generateList(new int[] { 9, 9, 9, 9, 9, 9, 9 });
            var b = AL.generateList(new int[] { 9, 9, 9, 9, }); */

            String[] c = { "leetcade", "leetcode", "leet", "leetco" };
            String c2 = "PAYPALISHIRING";

            int[] a = { 1, 3, 5, 7, 9 };
            int[] b = { 2, 4, 6, 8, 0 };
            var d = AL.L_6_Convert(c2, 3);
            // AL.printList(d);
            Console.WriteLine(d);

            sw.Stop(); //停止计时
            Console.WriteLine("耗时" + sw.ElapsedMilliseconds + "毫秒"); //打印程序总耗时
            Console.WriteLine("程序结束");
            // Console.ReadKey ();
        }
    }
}
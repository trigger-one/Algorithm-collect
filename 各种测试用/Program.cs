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

            Algorithm AL = new Algorithm();
            Methodlibrary ml = new Methodlibrary();

            // ListNote链表部分使用例子
            // var a = AL.generateList(new int[] { 2,1,6,5,4,9,8,7,3});
            // var d = AL.L_25_ReverseKGroup(a,2);
            // AL.printList(d);

            //非链表部分使用例子
            // int[] a = {2,1,6,5,4,9,8,7,3};

            // int[][] a = AL.L_59_GenerateMatrix(4);
            // foreach (var item in a)
            // {
            //     // Console.Write($"{item},");
            //     foreach (var m_item in item)
            //     {

            //         Console.Write("{0}  ", m_item);
            //     }
            // }

            Console.WriteLine();
            sw.Stop(); //停止计时
            Console.WriteLine("耗时" + sw.ElapsedMilliseconds + "毫秒"); //打印程序总耗时
            Console.WriteLine("程序结束");
            // Console.ReadKey ();
        }
    }
}
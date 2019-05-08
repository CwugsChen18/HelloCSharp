using System;
using System.Diagnostics;
using System.Text;


namespace HelloDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //数据类型
            //Vars();

            //Calculator cal = new Calculator();
            //ArrayAndConti ac = new ArrayAndConti();

            //Func f = new Func();

            ClassDemo c = new ClassDemo();
           //可以设置Name的值
            c.Name = "eee";
            //访问Name的只报错 因为设置为了隐藏 从而实现只写
            // Console.WriteLine(c.Name);

            //使用自定义构造器创建对象
         //   ClassDemo c1 = new ClassDemo("c1");

            Console.Read();

            
        }

        private static void Vars() {
            //数字 sbyte  有符号字节
            sbyte sb = -1;
            Console.WriteLine(sb);
            //整型 默认int
            int i = 0;
            Console.WriteLine(i);
            //长整型 后带l
            long l = 1000L;
            Console.WriteLine(l);
            //浮点型
            float f = 0.123F;
            Console.WriteLine(f);
            //双精度 15位小数
            double d = 0.1234567890123456789;
            Console.WriteLine(d);
            //科学计数 16进制

            //大数
            //字符型  转义字符
            char c = '\a';
            Console.WriteLine(c);
            //字符串 表示 @
            string str = @"F:\\dgjhj/dgdjfhdj\jhd";
            Console.WriteLine(str);

            // string  and StringBuilder的效率问题
            // 值类型 可空 int?  主要用于字符串   可赋值null
            int? i1 = null;
            Console.WriteLine(i1);
            //隐式转换  根据所赋值来确定类型
            var i2 = 1;
            //Console.WriteLine(typeof(i2));
            //i2 = 1.1;
            //Console.WriteLine(typeof(i2));

            //checked 检查代码错误

            //    checked
            //{
            //    int i3 = int.MaxValue;
            //    i3 += 1;
            //}

            //类型转换 parse tryParse toString  Convert
            //解析字符串为int 必须是数字 否则报错
            int i3 = int.Parse("12");
            //试图转换一个字符成为int
            int.TryParse("hduu", out i3);



            Console.WriteLine(i3);
            //转换成字符串
            Console.WriteLine(i3.ToString());
            //把字符串转换成制定类型
            bool b = System.Convert.ToBoolean("false");
            Console.WriteLine(b);


            //string 和 StringBuilder效率对比
            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();

            string str1 = string.Empty;
            for (i = 0; i < 10000; i++)
            {
                str1 += i.ToString();
            }

            stopWatch.Stop();

            Console.WriteLine("string所有时间为={0}", stopWatch.ElapsedMilliseconds);

            Stopwatch stopWatch1 = new Stopwatch();
            stopWatch1.Start();

            StringBuilder sb1 = new StringBuilder();
            for (i = 0; i < 10000; i++)
            {
                sb1.Append(i.ToString());
            }

            stopWatch1.Stop();

            Console.WriteLine("StringBuilder所有时间为={0}", stopWatch1.ElapsedMilliseconds);
            Console.ReadKey();
        }
    }
}

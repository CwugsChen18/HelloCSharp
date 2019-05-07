using System;
namespace HelloDemo
{
    public class Calculator
    {
        public Calculator()
        {
            cal();
        }

        /**
         * 
         * 运算符
         */
        private void cal() {
            int a = 0;
            int b = a++;
            Console.WriteLine("a={0}   b={1}", a, b);

            //常量 
            const int c = 9;
            //改变是会报错
            //c = 0;
            //非空检测 ？？(空接合运算符) 
            string fileName = "filename";
            fileName = fileName ?? "default";
            Console.WriteLine(fileName);
            Console.Read();

        }
    }
}
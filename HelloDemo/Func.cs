using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloDemo
{
    class Func
    {
        public Func() {
            int i = 0;
            Console.WriteLine(i);
            RefField1(ref i);
            OutField(out i);
            Console.WriteLine(i);

            Console.WriteLine("文件的个数是" + CountDirOrFiles("E:/"));
            Console.Read();
        }

        /** 
           ref  共用同一内存   string作为引用类型效果同基本类型
        */
        private void RefField1(ref int i) {
            i++;
            Console.WriteLine(i);
        }

        /**
           out 单纯return 只能返回一个参数  out使用返回多个参数  用于基本类型
         */

        private void OutField(out int i) {
            i = 3;
        }

        /**
            方法重载 方法名相同 参数不同（个数 类型）  有无返回值不影响
         */

        /**
            泛型
             交换值 
         */
        private void swap<T>(ref T a, ref T b){
            T t = a;
            a = b;
            b = t;
        }

        /**
         *  可变参数 加模板  可变参数必须放在参数列表最后一个 
         */

        private void Sum<T>(params T[] arr) {
           // T sun = arr.Sum();
        }

        /**
         * 异常的捕捉
         */

        private long CountDirOrFiles(string path) {
            long count = 0;

            try
            {
                  //统计文件
                string[] files = Directory.GetFiles(path);
                count += files.Length;

                //统计目录 嵌套使用递归
               string[] dirs =  Directory.GetDirectories(path);
                count += dirs.Length;

                foreach (string dir in dirs) {
                    count += CountDirOrFiles(dir);
                }
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
                //throw;
            }

            return count;
        }

        /**
         默认参数  直接在参数列表给一个值
         命名参数  参数名 : value   的形式  可以更改顺序
         可选参数  当参数使用默认值时  方法在调用时可以不赋值  public void Test(int a , bool isTest = false)    调用Test(1) 第二个参数默认不写
         */
    }


}

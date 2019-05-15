using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloDemo
{
    class DelegateDemo
    {
        public DelegateDemo()
        {
            //返回所有偶数
            Console.WriteLine("返回所有偶数");
            this.getRes(new List<int> { 1,2,3,4,5,6,6}, isEven);
            //返回大于10的数
            Console.WriteLine("返回大于10的数");
            this.getRes(new List<int> { 1, 12, 3, 4, 5, 26, 6 }, GreaterThan);
            //lambda表达式
            //(type var, …) => { … }  参数带类型声明
            Console.WriteLine("返回小于10的数");
            this.getRes(new List<int> { 1, 12, 3, 4, 5, 26, 6 }, (int num)=> { return num < 10; });
            //(var, …) => { … }  参数不带类型声明
            Console.WriteLine("返回所有奇数");
            this.getRes(new List<int> { 1, 12, 3, 4, 5, 26, 6 }, num => { return num % 2 == 1; });
            //var => { … } 单个参数无需括号  单条语句 
            Console.WriteLine("返回所有奇数");                    //表达式Lambda
            this.getRes(new List<int> { 1, 12, 3, 4, 5, 26, 6 }, num => num % 2 == 1);
            //() => { … } //无参数

            //C#自定义委托
            //Action<> 例 List<T>.ForEach()
            List<int> lists = new List<int> { 1,2,5,7,8,9};            Console.WriteLine("Action委托 无返回值");
            lists.ForEach((ele) => { Console.WriteLine(ele); });
            //Func<> 例 List<T>.Sum()
            Console.WriteLine("Func委托 有返回值任一类型");            Console.WriteLine(lists.Sum(ele=>ele));
            //Predicate<> 例 List<T>.FindAll()
            //          例 List<T>.Find ()
            Console.WriteLine("Predicate委托 有返回值bool类型");
            Console.WriteLine(lists.Find((ele) => { return ele > 2; }));

            //使用系统自带委托
            Console.WriteLine("返回两个数之中的大数");
            Console.WriteLine(getMax(1,4, Max));

            Console.Read();
        }

        //使用系统自带委托定义
        public Func<int, int, int> Max = delegate (int x, int y) { if (x > y) return x; else return y;};

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="fun"></param>  最后一个参数为返回值
        /// <returns></returns>
        int getMax(int x, int y,Func<int, int, int> fun) {
            return fun(x, y);
        }

        //定义一个委托
        public delegate bool Fun(int num);

        //定义一个返回大于10的方法
        public Fun GreaterThan = delegate (int num) { return num > 10; };

        //返回列表中偶数的方法
        public Fun isEven = delegate (int num) { return num % 2 == 0; };

        //在方法中使用委托
        public List<int> getRes(List<int> lists, Fun fun) {
            List<int> lists1 = new List<int>();
            foreach (int list in lists) {
                if (fun(list)) {
                    lists1.Add(list);
                    Console.WriteLine(list);
                }
            }
            return lists1;
        }
    }
} 

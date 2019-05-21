using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloDemo
{
    class CollectionsInit
    {

        public CollectionsInit() {

            MyList list = new MyList(new int[] {1,6,8,2,9,45});
            IEnumerator e = list.GetEnumerator();
            while (e.MoveNext()) {
                Console.WriteLine(e.Current);
            }
            //Console.WriteLine("list的长度 = " + MyListCount(list));
            // Console.WriteLine("list的最大值 = " + Max(list));
            //获取自身属性的方法应该定义在类中
            Console.WriteLine("list的长度 = " + list.getListCount());

            //输出小于9的数  where
            var  es0 =  list.Where(num => num < 9);
            foreach (var es in es0) { Console.WriteLine(es); }
            Console.Read();       
        }

        /**
         获取MyList的长度
         */

        public int MyListCount(MyList list) {
            int len = 0;
            var e = list.GetEnumerator();
            while (e.MoveNext()) {
                len++;
            }
            return len;
        }

        /**
           获取最大值
         */

        public int Max(MyList list) {
            int max = int.MinValue;
            var e = list.GetEnumerator();
            while (e.MoveNext())
            {
                if (e.Current > max) max = e.Current;
            }
            return max;
        }
    }


    /**
     * 自定义个集合继承迭代器
     */

    public class MyList : IEnumerable<int>
    {
        public int[] NUms;
        public MyList(int[] NUms) {
            this.NUms = NUms;
        }
        public IEnumerator<int> GetEnumerator()
        {
            foreach (int num in NUms) {
                yield return num;
            }
        }

        //IEnumerator<int> IEnumerable<int>.GetEnumerator()
        //{
        //    throw new NotImplementedException();
        //}

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

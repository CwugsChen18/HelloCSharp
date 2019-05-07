using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * 数组与循环
 *
 */
namespace HelloDemo
{
    class ArrayAndConti
    {
        public ArrayAndConti() {
            //OutputFeibo();
            // OutputRandomNum();

            FastSort();
        }

        //快速排序
        private void FastSort() {
            const int N = 10;
            int[] arr = new int[N];
            var r = new Random();
            for (var i = 0; i < N; i++)
            {
                var r0 = r.Next() % 10;
                arr[i] = r0;
            }

            FastSortItem(0, N-1, arr);
            //输出
            foreach (int num in arr) {
                Console.WriteLine(num);
            }

            Console.Read();
        }

        private void FastSortItem(int start, int end, int[] arr) {
            if (start >= end) return;
                int s = start, e = end;
            int key = arr[s];
                while (start < end)
                {
                    //如果比key大 end向前移动
                    while (start < end && arr[end] > key)
                    {
                        end--;
                    }
                    //判断后往前位置是否比key小，如果小移到key的
                    if (start < end)
                    {
                        arr[start] = arr[end];
                        start++;
                    }

                    //如果比key小  start向后移
                    while (start < end && arr[start] < key)
                    {
                        start++;
                    }

                    //判断前往后位置是否比key大，如果大移到key的
                    if (start < end)
                    {
                        arr[end] = arr[start];
                        end--;
                    }
                }
                arr[start] = key;
                //key两个边继续递归
                FastSortItem(s, start - 1, arr);
                FastSortItem(start + 1, e, arr);
        }

        #region 随机输出N个随机数  预处理命令
        /**
         * 随机输出N个随机数
         */
        private void OutputRandomNum() {
            var r = new Random();
          
            const int N = 10;
            List<int> lists = new List<int>(10);
            for (var i = 0; i < N+1; i++) {
                var r0 = r.Next()%10;
                //Console.WriteLine(r0);
                lists.Add(r0);
            }
            //排序
            lists.Sort();
            //用foreach输出
            foreach (int list in lists) {
                Console.WriteLine(list);
            }

            Console.Read();
        }
        #endregion

        private void OutputFeibo() {
            //创建一个数组 输出前N个斐波那契数列  防止溢出
            const int N = 50;
            long[] arr = new long[N];
            arr[0] = arr[1] = 1L;

            Console.WriteLine("arr[{0}] = {1}", 0, arr[0]);
            Console.WriteLine("arr[{0}] = {1}", 1, arr[1]);
            for (int i = 2; i < N; i++)
            {
                arr[i] = arr[i - 1] + arr[i - 2];
                Console.WriteLine("arr[{0}] = {1}", i, arr[i]);
            }

            Console.Read();
        }
    }
}

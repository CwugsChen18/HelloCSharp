using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloDemo
{
    static class MyExtendClass
    {
        //public static int getListCount(this MyList list) {
        //    int len = 0;
        //    var e = list.GetEnumerator();
        //    while (e.MoveNext())
        //    {
        //        len++;
        //    }
        //    return len;
        //}

        //有多个类型是处理方法  面向接口
        public static int getListCount(this IEnumerable<int> list)
        {
            int len = 0;
            var e = list.GetEnumerator();
            while (e.MoveNext())
            {
                len++;
            }
            return len;
        }
    }
}

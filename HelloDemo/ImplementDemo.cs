using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloDemo
{
    class ImplementDemo
    {
        public ImplementDemo() { }

        /**
            接口编程
            同类属性用父类
            同类但不同功能使用接口（狗和鸟都是动物，但是鸟会飞，狗不会）
            fly的方法使用接口实现
         */
         //interface   接口可以继承
    }

    interface IFlyable {
        //接口不能包含字段  可以包含属性
        int I { get; set; }
    }

    class Bird : IFlyable
    {
       public int I
        {
            get ;
            set ;
        }
    }
}

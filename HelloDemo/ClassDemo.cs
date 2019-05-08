using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloDemo
{
    class ClassDemo
    {
        private string _Name;




        /**
          修饰符的使用
           字段属性  get set  public string Name {get,set}   value(上下文关键字)
           自定义构造函数
        属性初始化器 var obj = new {Name = "1", value = 2}
        构造函数可以是静态的(用于类的第一次初始化初始参数)  静态类Math
        单例模式
        readonly 只能在定义或构造函数中赋值 不能修改
        嵌套类
         */

        //设置属性的只读只写  修饰符
        public string Name {
            private get { return _Name; }
            set { _Name = value; }
        }

        //自定义构造器
        public ClassDemo(string _Name) : this() {
            Name = _Name;
            Console.WriteLine(this.Name);
            Console.WriteLine(this._Name);
        }

        public ClassDemo()
        {
            Console.WriteLine("我被调用了");

            //设置对象初始化器
            SonClass son = new SonClass() { Name = "SonClass" };
            Console.WriteLine(son.Name);

            SonClass son1 = new SonClass();
            //只读字段不能修改
            int age =  son1.age;


            //无法创建静态类的实例
            // new Math();
        }

        //定义一个嵌套类
        class SonClass {
            public string Name { set; get; }
            public SonClass() {
                Console.WriteLine("我被创建了1");
            }

            //创建一个静态构造器  (无参数 无修饰符)
            //第一次实例化被调用 
            static SonClass() {
                Console.WriteLine("我被创建了");
                SingleClass.Instance.setName();
                
            }

            //readonly 只能在声明或构造器中复制
            public readonly int age;

        }

        static class StaClass {
            //万物皆可静态
             static StaClass() {

            }
        }
    }

    //单例模式
    class SingleClass
    {
        //构造器私有不能从外部创建
        private SingleClass()
        {
            Console.WriteLine("我是一个单例类");
        }

        //持有自己的实例
        private static SingleClass _Instance = null;

        public static SingleClass Instance
        {
            get
            {
                if (_Instance == null) _Instance = new SingleClass();
                return _Instance;
            }
        }

        public void setName()
        {
            Console.WriteLine("我的名字是单例");
        }
    }
}

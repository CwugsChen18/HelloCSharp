using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloDemo
{
    class ClassOther
    {
        public ClassOther() {
            Person p = new Person(false, 10);

            Color c = new Color();
            c = Color.green;
            getColor(c);

            int a = 0;
            try
            {
                //a = 1 / a;
            }
            catch (MeException me)
            {
                //me.Message;
                //throw; 抛出给外层处理
            }
            finally {
                Console.WriteLine("close");
            }

            Location l0 = new Location() { x = 1, y = 1 };

            Location l1 = new Location() { x = 2, y = 2 };
            Location l = l0 + l1;

            using (var dis = new Disposes()) {

            }

            new TypeDemo<int>(1);
            new TypeDemo<double>(1.0);
            Console.Read();
        }

        private void getColor(Color c) {
            switch (c) {
                case Color.red:
                    Console.WriteLine("颜色是红色{0}", Color.red);
                    break;
                case Color.blue:
                    Console.WriteLine("颜色是蓝色{0}", Color.blue);
                    break;
                case Color.green:
                    Console.WriteLine("颜色是绿色{0}", Color.green);
                    break;
            }
        }


    }
    //结构体
    //struct
    struct Person {
        public bool gender;
        public int age;

        //不能定义无构造参数的构造方法
        public Person(bool gender, int age) {
            this.gender = gender;
            this.age = age;

            string sex = gender ? "男" : "女";
            Console.WriteLine("我是一个{0}生,现在{1}岁", sex, age);

        }
    }
    //枚举
    //enum
    enum Color {
        red,
        blue,
        green
    }
    //异常  catch可以有多个  可以在catch抛出异常信息
    //    try 
    //	    {	        

    //	    } 
    //catch(){
    //    }
    //	    finally
    //	    {

    //	    }
    class MeException : Exception {
        public MeException() {
            Console.WriteLine("抛出自定义异常");
        }
    }

    //泛型  值约束  where T : struct(class)
    public class TypeDemo<T> where T : struct {
        T t;
        public TypeDemo(T t) {
            this.t = t;
            Console.WriteLine("打印类型是{0}={1}", t.GetType(), t);
        }
    }
    //操作符重载
    //operator
    class Location {
        public int x;
        public int y;

        //+运算符重载
        public static Location operator +(Location lR, Location rR)
        {
            Location l = new Location();
            l.x = lR.x + rR.x;
            l.y = lR.y + rR.y;

            Console.WriteLine("Location的位置是{0},{1}", l.x, l.y);

            return l;
        }
    }

    //垃圾回收  IDisPoseable  using的三种用法 （引入外部命名空间， 设置别名   using 语句允许程序员指定使用资源的对象应当何时释放资源。
    //using 语句中使用的对象必须实现 IDisposable 接口）

    class Disposes : IDisposable
    {
        public void Dispose() {
            Console.WriteLine("我被回收了");
        }
    }
    //装箱 拆箱 弱引用  延迟初始化
}

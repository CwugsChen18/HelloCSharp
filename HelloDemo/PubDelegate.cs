using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloDemo
{
    class PubDelegate
    {
        //当多个发布者时，是否可以定义一个委托来来连接
        public static event Action<PubArgs> Pubs;
        //当有多个发布者时，需要区别时哪个发布的消息，这是需要修改委托
        //使用系统自定义委托  public delegate void EventHandler<T>(object sender, T t) where T : EventArgs; 
        public static event EventHandler<PubArgs> Subs;
        //{
            //add { Console.WriteLine("添加了一个委托"); }
           // remove { Console.WriteLine("移除一个委托"); }
       // } //= null;
        public PubDelegate() {
            Publisher pub = new Publisher("PUB_JACK");
            Publisher1 pub1 = new Publisher1("PUB1_TIM");
            Pubs += pub.PubAction;
            Pubs += pub1.PubAction;

            //添加订阅者
            Subscriber sub0 = new Subscriber("SUB_TOM");
            // pub.subs.Add(sub0);
            //绑定到委托  委托使用event 事件修饰只能使用+= -=来增减多播委托
            Subs += sub0.SubAction;
            Subscriber sub1 = new Subscriber("SUB_LUCY");
            // pub.subs.Add(sub1);
            //绑定到委托
            Subs += sub1.SubAction;
            Subscriber sub2 = new Subscriber("SUB_ALICE");
            // pub.subs.Add(sub2);
            //绑定到委托
            Subs += sub1.SubAction;


            //在多播委托中添加一个异常
            Subs += (obj, pc) => {
                throw new ApplicationException();
            };

            //上面的订阅者都是同一类型，如果再来一个类型的订阅者，如何处理 ？？
            // 这个时候把订阅的方法抽象到接口中
            Subscriber1 sub_1 = new Subscriber1("SUB_Frank");
            // pub.subs.Add(sub_1);
            //绑定到委托
            Subs += sub_1.SubAction;
            //使用委托来实现上述模式，取代接口的实现手段

            //发布
            var args1 = new PubArgs();
            args1.PC = new PubContent("Tomorrow will rains");
            // pub.PubAction(args1);
            Pubs(args1);

            //退订、取消注册
            Subs -= sub1.SubAction;
            Console.WriteLine("--------------------------------");

            var args2 = new PubArgs();
            args2.PC = new PubContent("Tomorrow will Cloudy");
            //pub.PubAction(args2);
            Pubs(args2);
            Console.Read();
        }

        //出现发布者发布方法为接口


        //订阅者模式
        // 发布者
        class Publisher
        {
            //发布者
            private string PubName;
            public Publisher(string PubName)
            {
                this.PubName = PubName;
            }

            //声明一个委托
            //  public delegate void SubAction(PubContent PC, string PubName);
            //定义一个委托
            // public SubAction Subs = null;

            //使用系统定义的委托  
            //使用事件Evnet  防止误用+ -
            // public event Action<PubContent, string> Subs = null;

            //维护一个订阅者列表
            // public List<ISubAction> subs = new List<ISubAction>();

            //发布动作
            public void PubAction(PubArgs args)
            {
                //使用list自定义的委托
                //subs.ForEach(sub => sub.SubAction(pc, PubName));
                //执行委托
                //如果没有添加订阅者 委托为空
                if (Subs != null)
                {
                    //防止在委托链中出现异常  将委托一个个拉出来执行
                    //foreach (Action<Object, PubArgs> sub in Subs.GetInvocationList())
                    foreach (EventHandler<PubArgs> sub in Subs.GetInvocationList())
                    {
                        try
                        {
                            sub(this, args);
                        }
                        catch (ApplicationException ex)
                        {
                            Console.WriteLine(ex.Message);
                            //throw;
                        }
                    }
                }
            }
        }

        class Publisher1
        {
            //发布者
            private string PubName;
            public Publisher1(string PubName)
            {
                this.PubName = PubName;
            }

            //声明一个委托
            //  public delegate void SubAction(PubContent PC, string PubName);
            //定义一个委托
            // public SubAction Subs = null;

            //使用系统定义的委托  
            //使用事件Evnet  防止误用+ -
            // public event Action<PubContent, string> Subs = null;

            //维护一个订阅者列表
            // public List<ISubAction> subs = new List<ISubAction>();

            //发布动作
            public void PubAction(PubArgs args)
            {
                //使用list自定义的委托
                //subs.ForEach(sub => sub.SubAction(pc, PubName));
                //执行委托
                //如果没有添加订阅者 委托为空
                if (Subs != null)
                {
                    //防止在委托链中出现异常  将委托一个个拉出来执行
                    foreach (EventHandler<PubArgs> sub in Subs.GetInvocationList())
                    {
                        try
                        {
                            sub(this,args);
                        }
                        catch (ApplicationException ex)
                        {
                            Console.WriteLine(ex.Message);
                            //throw;
                        }
                    }
                }
            }
        }
       

        //订阅者
        public class Subscriber //: ISubAction
        {
            //订阅者
            public string SubName { get; set; }
            public Subscriber(string SubName)
            {
                this.SubName = SubName;
            }

            public void SubAction(Object obj, PubArgs args)
            {
                Console.WriteLine("Sub{0}订阅的内容是{1}发布者的签名{2}", SubName, args.PC.content,obj.GetType());
            }
        }

        public class Subscriber1 //: ISubAction
        {
            //订阅者
            public string SubName { get; set; }
            public Subscriber1(string SubName)
            {
                this.SubName = SubName;
            }

            public void SubAction(Object obj, PubArgs args)
            {
                Console.WriteLine("Sub_1{0}订阅的内容是{1},发布者的签名{2}", SubName, args.PC.content,obj.GetType());
            }
        }

        // 发布内容
        public class PubContent
        {
            //发布的内容
            public string content;
            public PubContent(string content) { this.content = content; }
        }

        //封装委托数据
        public class PubArgs : EventArgs {
            public PubContent PC { get; set; }
        } 
    }

    //interface ISubAction
    //{
    //    //订阅方法
    //    void SubAction(PubContent PC, string PubName);

    //    string SubName { get; set; }
    //}
}

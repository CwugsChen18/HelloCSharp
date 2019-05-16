using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloDemo
{
    class PublisherDemo
    { 
        public PublisherDemo() {
            //Publisher pub = new Publisher("PUB_JACK");

            ////添加订阅者
            //Subscriber sub0 = new Subscriber("SUB_TOM");
            //pub.subs.Add(sub0);
            //Subscriber sub1 = new Subscriber("SUB_LUCY");
            //pub.subs.Add(sub1);
            //Subscriber sub2 = new Subscriber("SUB_ALICE");
            //pub.subs.Add(sub2);
            ////上面的订阅者都是同一类型，如果再来一个类型的订阅者，如何处理 ？？
            //// 这个时候把订阅的方法抽象到接口中
            //Subscriber1 sub_1 = new Subscriber1("SUB_Frank");
            //pub.subs.Add(sub_1);

            ////发布
            //pub.PubAction(new PubContent("Tomorrow will rains"));

            //Console.Read();
        }
    }

   


    ////订阅者模式
    //// 发布者
    //class Publisher {
    //    //发布者
    //    private string PubName;
    //    public Publisher(string PubName) {
    //        this.PubName = PubName;
    //    }
    //    //维护一个订阅者列表
    //    public List<ISubAction> subs = new List<ISubAction>();

    //    //发布动作
    //    public void PubAction(PubContent pc) {
    //        //使用list自定义的委托
    //        subs.ForEach(sub=>sub.SubAction(pc, PubName));
    //    }
    //}

    //interface ISubAction
    //{
    //    //订阅方法
    //    void SubAction(PubContent PC, string PubName);

    //    string SubName { get; set; }
    //}

    ////订阅者
    //public class Subscriber : ISubAction{
    //    //订阅者
    //    public string SubName { get; set; }
    //    public Subscriber(string SubName) {
    //        this.SubName = SubName;
    //    }

    //    public void SubAction(PubContent pc, string PubName) {
    //        Console.WriteLine("Sub{0}订阅的内容是{1},发布者是{2}", SubName, pc.content, PubName);
    //    }
    //}

    //public class Subscriber1 : ISubAction
    //{
    //    //订阅者
    //    public string SubName { get; set; }
    //    public Subscriber1(string SubName)
    //    {
    //        this.SubName = SubName;
    //    }

    //    public void SubAction(PubContent pc, string PubName)
    //    {
    //        Console.WriteLine("Sub_1{0}订阅的内容是{1},发布者是{2}", SubName, pc.content, PubName);
    //    }
    //}

    //// 发布内容
    //public class PubContent
    //{
    //     //发布的内容
    //    public string content;
    //   public PubContent(string content) { this.content = content; }
    //}
}
 
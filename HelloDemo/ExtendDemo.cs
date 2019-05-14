using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 工程模式解析不同的打印操作
/// </summary>
namespace HelloDemo
{
    class ExtendDemo
    {
        public ExtendDemo(string path) {
            Document doc = DocumentFactory.getPrintClass(path);
            if (doc == null) Console.WriteLine("目前不支持该文件打印");
            else {
                doc.print();
                Console.WriteLine(doc.GetType());
            }


            var pdf = doc as PDFPrint;
           //if (pdf is PDFPrint) 
           
            Console.Read();
        }
    }


    /**
     所有操作类的父类
     */
   public abstract class Document {
        //提供一个抽象方法
        public abstract void print();

        //virtual   //用于继承的父类方法
        //override  继承父类方法
        // new  使用在方法上标识不继承父类的方法
        //abstract  包含 virtual
    }

    //打印pdf文件的实现类
    public class PDFPrint : Document
    {
        //调用父类的方法和字段 base  

        public PDFPrint() : base() {

        }

        public override void print()
        {
            Console.WriteLine("print pdf file");
        }

    }
    //打印txt文件的实现类
    public class TXTPrint : Document {
        public override void print()
        {
            Console.WriteLine("print txt file");
        }
    }

    //构建工厂类  密封类不能被继承
    public sealed class DocumentFactory {
        public  static Document getPrintClass(string path) {
            if (path.ToLower().EndsWith(".pdf")) return new PDFPrint();
            else if (path.ToLower().EndsWith(".txt")) return new TXTPrint();
            return null;
        }
    }

    //public class dd : DocumentFactory {

    //}

    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            //call sevice
            //var result = new result { success = true, data = 5 };
            //var result1 = new result1 { success = false, data = "john" };
            //var result2 = new result2 { success = false, data = true };
            //Console.WriteLine(result.success);
            //Console.WriteLine(result.data);
            //Console.WriteLine(result1.success);
            //Console.WriteLine(result1.data);
            //Console.WriteLine(result2.success);
            //Console.WriteLine(result2.data);

            //generic use
            var result = new Result<int,int> { success = true, data = 6,id=6 };
            var result1 = new Result<string,int> { success = false, data = "john",id=3 };
            var result2 = new Result<bool,string> { success = false, data = true,id="56" };
            //Console.WriteLine(result1.success);
            //Console.WriteLine(result1.data);
            //Console.WriteLine(result1.id);
            //Console.WriteLine(result.success);
            //Console.WriteLine(result.data);
            //Console.WriteLine(result.id);
            //Console.WriteLine(result2.success);
            //Console.WriteLine(result2.data);
            //Console.WriteLine(result2.id);
            ResultViewer r = new ResultViewer();
            r.Print(result1);
            r.Print(result);
            r.Print(result2);
            Console.ReadLine();
        }
    }

    public class Result<T,U>
    {
        public bool success { get; set; }
        public T data { get; set; }
        public U id { get; set; }
    }


    //public class result
    //{
    //    public bool success { get; set; }
    //    public int data { get; set; }
    //}

    //public class result1
    //{
    //    public bool success { get; set; }
    //    public string data { get; set; }
    //}

    //public class result2
    //{
    //    public bool success { get; set; }
    //    public bool data { get; set; }
    //}
    public class ResultViewer
    {
        public void Print<T,U>(Result<T,U> result)
        {
            Console.WriteLine(result.success);
            Console.WriteLine(result.data);
            Console.WriteLine(result.id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace TaskParallelTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            var t1 = new Task(() => NewFunction(1, 2000));
            //{
            //    Console.WriteLine("task 1 is starting");
            //    Thread.Sleep(2000);
            //    Console.WriteLine("task 1 is completed");
            //});
            t1.Start();
            var t2 = new Task(() => NewFunction(2, 1000));
            t2.Start();
            var t3 = new Task(() => NewFunction(3, 3000));
            t3.Start();
            Console.WriteLine("Press any key to quit");
            Console.ReadKey();

        }

        static void NewFunction(int id, int sleepTime)
        {
            Console.WriteLine("task {0} is starting",id);
            Thread.Sleep(sleepTime);
            Console.WriteLine("task {0} is completed",id);
        }
    }
}

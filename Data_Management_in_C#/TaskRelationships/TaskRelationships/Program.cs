using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskRelationships
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Task<int> firstTask = Task.Factory.StartNew<int>(() =>
             {
                 Console.WriteLine("first task");
                 return 42;
             });
            //second task continues once the first task is finished
            Task secondTask = firstTask.ContinueWith((ft) => Console.WriteLine("second task, first task returned {0}", ft.Result),TaskContinuationOptions.OnlyOnRanToCompletion);
            secondTask.Wait();
            */
            Task.Factory.StartNew(() =>
            {
                Task nested = Task.Factory.StartNew(() => Console.WriteLine("nested"));
                Task child = Task.Factory.StartNew(() => Console.WriteLine("child"),TaskCreationOptions.AttachedToParent);
            }).Wait();
            Console.ReadLine();
        }
    }
}

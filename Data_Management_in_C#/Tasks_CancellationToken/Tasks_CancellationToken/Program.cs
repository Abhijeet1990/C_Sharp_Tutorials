using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks_CancellationToken
{
    class Program
    {
        //public static CancellationTokenSource ctsToken3;
        //public static CancellationTokenSource ctsToken2;
        public static CancellationTokenSource ctsToken;      
        
        static void Main(string[] args)
        {
            ctsToken = new CancellationTokenSource();
            //ctsToken2 = new CancellationTokenSource();
            //ctsToken3 = new CancellationTokenSource();
            //var t1 = new Task(() =>
            //{ DoTask(1, 1500);
            //});
            //t1.Start();
            //var t2 = new Task(() =>
            //{
            //    DoTask(2, 2000);
            //});
            //t2.Start();
            //var t3 = new Task(() =>
            //{
            //    DoTask(3, 3000);
            //});
            //t3.Start();
            try
            {
                var t1 = Task.Factory.StartNew(() => DoTask(1, 1500, ctsToken.Token)).ContinueWith((prevtask) => DoMoreTask(1, 3000, ctsToken.Token));
                var t2 = Task.Factory.StartNew(() => DoTask(2, 2000, ctsToken.Token)).ContinueWith((prevtask) => DoMoreTask(2, 7000, ctsToken.Token));
                var t3 = Task.Factory.StartNew(() => DoTask(3, 14000, ctsToken.Token)).ContinueWith((prevtask) => DoMoreTask(3, 9000, ctsToken.Token));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.GetType());
            }
            Console.WriteLine("press any key to quit");
            Console.ReadKey();
        }

        static void DoTask(int id, int sleepTime,CancellationToken ctstoken)
        {
            if(ctstoken.IsCancellationRequested)
            {
                Console.WriteLine("cancellation requested in DoTask by {0}",id);
                ctstoken.ThrowIfCancellationRequested();
            }
            Console.WriteLine("task {0} is beginning", id);
            Thread.Sleep(sleepTime);
            if (id == 2)
            { ctsToken.Cancel(); }
            Console.WriteLine("task {0} has completed", id);
            
        }
        static void DoMoreTask(int id, int sleepTime, CancellationToken ctstoken)
        {
            if (ctstoken.IsCancellationRequested)
            {
                Console.WriteLine("cancellation requested in DoMoreTask by {0}",id);
                ctstoken.ThrowIfCancellationRequested();
            }
            Console.WriteLine("task {0} is beginning", id);
            Thread.Sleep(sleepTime);
            if (id == 3)
            { ctsToken.Cancel(); }
            Console.WriteLine("task {0} has completed", id);
            
            
        }
    }
}

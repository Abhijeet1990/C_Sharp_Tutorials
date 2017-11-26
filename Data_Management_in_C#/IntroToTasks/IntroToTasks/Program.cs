using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.IO;



//Task can basically be called as an asynchronous unit of work... Queue some thread to threadpool....

//There will be two types of Tasks: CPU bound and IO bound
//CPU bound: all tasks are using the CPU continuously
//IO bound: these async task must be waiting for some resources...

//task can be created in 3 different ways
//1. create a func. 

namespace IntroToTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            //Thread pool Thread
            Task.Factory.StartNew(TypeOfThread).Wait();
            //Custom thread created
            Task.Factory.StartNew(TypeOfThread,TaskCreationOptions.LongRunning).Wait();
            //first way of creating task
            //Task t = new Task(Speak);
            //t.Start();
            //Second way of creating task
            //Task t = Task.Factory.StartNew(Speak);
            //Third way of creating Task
            Task t = Task.Run(new Action(Speak));
            Stopwatch sw = Stopwatch.StartNew();
            Console.WriteLine("waiting for completion");
            t.Wait();
            sw.Stop();
            Console.WriteLine("all done in {0} secs",sw.Elapsed);
            */
            //Use of Lambda Expression to delegate a task..passing data to a task
            Task.Factory.StartNew(() => Speak2("Hello Abhijeet")).Wait();
            //returning data from a task
            Stopwatch sw = Stopwatch.StartNew();
            Task<int> t= Task.Factory.StartNew(() => Add(50,100));
            sw.Stop();
            Console.WriteLine("To solve the answer it took {0} sec and the ans is {1}",sw.Elapsed,t.Result);
            Stopwatch sw_task = Stopwatch.StartNew();
            TaskBasedChancesToWin();
            sw_task.Stop();
            Stopwatch sw_seq = Stopwatch.StartNew();
            SequentialChancesToWin();
            sw_seq.Stop();
            Console.WriteLine("TAsk based time {0} Seq based time {1}", sw_task.Elapsed, sw_seq.Elapsed);


            Task<string> downloadTask = DownloadWebPageAsync("https://www.youtube.com/watch?v=3vg8MqmUGVU");
            while(!downloadTask.IsCompleted)
            {
                Console.Write(".");
                Thread.Sleep(250);
            }
            Console.WriteLine(downloadTask.Result);
            Console.ReadLine();

        }
        private static void Speak()
        {
            Console.WriteLine("Hello World");
            System.Threading.Thread.Sleep(5000);

        }

        private static void TypeOfThread()
        {
            Console.WriteLine("I am a {0} thread", Thread.CurrentThread.IsThreadPoolThread ? "Thread pool" : "custom thread");
        }

        private static void Speak2(string words)
        {
            Console.WriteLine(words);
        }

        public static int Add(int x,int y)
        {
            return x + y;
        }
        //Task Based chances to win
        private static void TaskBasedChancesToWin()
        {
            long x = 20;
            long y = 13;
            Task<long> A = Task<long>.Factory.StartNew(() => Factorial(x));
            Task<long> B = Task<long>.Factory.StartNew(() => Factorial(x-y));
            Task<long> C = Task<long>.Factory.StartNew(() => Factorial(y));
            if (B.Result != 0 && C.Result != 0)
            {
                decimal chances = A.Result / (B.Result * C.Result);
                Console.WriteLine(chances);
            }
        }

        //Sequential Chances to win
        private static void SequentialChancesToWin()
        {
            long x = 100;
            long y = 70;
            long A = Factorial(x);
            long B = Factorial(x - y);
            long C = Factorial(y); 
            //Console.WriteLine("{0}   {1}    {2}",A,B,C);
            if (B != 0 && C != 0)
            {
                decimal chances = A / (B * C);
                Console.WriteLine(chances);
            }
        }
        static long Factorial(long number)
        {
            long i = 1;
            while(number>1)
            {
                i *= number;
                number -= 1;
                Console.WriteLine(i);
            }
            
            return i;
        }

        private static string DownloadWebPage(string url)
        {
            WebRequest req = WebRequest.Create(url);
            WebResponse res = req.GetResponse();
            var reader = new StreamReader(res.GetResponseStream());
            {
                return reader.ReadToEnd();
            }
        }

        private static Task<string> DownloadWebPageAsync(string url)
        {
            return Task.Factory.StartNew(() => DownloadWebPage(url));
        }
    }
}

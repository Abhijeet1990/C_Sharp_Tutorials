using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace ProducerConsumerThread
{
    class Program
    {
        //Produce Threads

        static MySyncronizedQueue<int> numbers = new MySyncronizedQueue<int>();
        static Random rand = new Random();
        const int Numthreads = 3;
        static int[] sums = new int[Numthreads];
        static void ProduceNumbers()
        {
            for (int i = 0; i < 10; i++)
            {
                int numToEnqueue = rand.Next(10);
                Console.WriteLine("Producing thread adding "+numToEnqueue+" to the queue.");
                //lock (numbers)
                //{
                //    numbers.Enqueue(numToEnqueue);
                //}
                //the above commented code is equivalent to
                //Monitor.Enter(numbers);
                numbers.Enqueue(numToEnqueue);
                //Monitor.Exit(numbers);


                Thread.Sleep(rand.Next(1000));
            }

        }

        static void SumNumbers(object ThreadNumber)
        {
            DateTime startTime = DateTime.Now;
            int mySum = 0;
            
            while((DateTime.Now - startTime).Seconds<11)
            {
                int numToSum = -1;
                lock (numbers.SyncRoot)//this ensures that only one thread can have the lock on that object
                {
                    
                    if (numbers.Count != 0)
                    {
                        numToSum = numbers.Dequeue();
                        //try
                        //{
                        //    numToSum = numbers.Dequeue();
                        //}
                        //catch
                        //{
                        //    Console.WriteLine("Thread#" + ThreadNumber + " having an issue");
                        //    throw;
                        //}
                    }
                }
                if (numToSum != -1)
                {
                    mySum += numToSum;
                    Console.WriteLine("consuming thread #" + ThreadNumber + " adding " + numToSum + " to its total sum" + numToSum + " for the thread total");
                }
                
            }
            sums[(int)ThreadNumber] = mySum;
        }
        static void Main(string[] args)
        {
            //The producing Thread generates the random numbers
            var producingThread = new Thread(ProduceNumbers);
            producingThread.Start();
            //Now the array of consuming threads adds them up
            Thread[] threads = new Thread[Numthreads];
            for (int i = 0; i < Numthreads; i++)
            {
                threads[i] = new Thread(SumNumbers);
                threads[i].Start(i);
            }

            for (int i = 0; i < Numthreads; i++)
            {
                threads[i].Join();
            }
            int totalSum = 0;
            for (int i = 0; i < Numthreads; i++)
            {
                totalSum += sums[i];
            }
            Console.WriteLine( "Done adding Total is " + totalSum);
            Console.ReadLine();
        }
    }
}

class MySyncronizedQueue<T> 
{
    object baton = new object();
    Queue<T> q = new Queue<T>();
    public void Enqueue(T item)
    {
        lock(baton)
            q.Enqueue(item);
    }
    public T Dequeue()
    {
        lock (baton)
            return q.Dequeue();
    }

    public int Count
    {
        get { lock (baton) return q.Count; }
    }

    public object SyncRoot
    {
        get { return baton; }
    }

}

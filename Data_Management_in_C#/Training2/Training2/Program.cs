using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training2
{
    class Program
    {
        delegate int MyDelegate(int x);
        //Any function that has a return type as void and parameter as string can be pointed by this delegate

        static void Main(string[] args)
        {
            /*
            //DELEGATE is an object pointing to a Function
            //MyDelegate del = new MyDelegate(TestFunc);
            MyDelegate del = TestFunc;
            //adding to the delegate's invocation list
            del += TestFunc2;
            string result = del();

            Console.WriteLine(result);
            */
            //MyDelegate del = Test;
            //Annonymous method
            /*
            MyDelegate del = delegate
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(i);
                }
            };
            */
            /*
            // Expression Lambda
            MyDelegate del = (int x) => x + 5;
            //statement Lambda
            MyDelegate del2 = (int x) =>
            {
                return x + 5;
            };
            int result = del(30);
            int result2 = del2(40);
            Console.WriteLine(result);
            Console.WriteLine(result2);
            */
            Person p = new Person();
            p.cashEvent += P_cashEvent;
            p.AddCash(500);
            p.AddCash(50);
            Console.ReadLine();
        }

        private static void P_cashEvent()
        {
            Console.WriteLine("Person has gained 100$");
        }
        /*
        static string TestFunc()
        {
            return "Hello world";
        }
        static string TestFunc2()
        {
            return "Bye world";
        }
        static void Test()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(i);
            }
        }
        */
       
    }
    class Person
    {
        public delegate void MyEventHandler();

        public event MyEventHandler cashEvent;

        private int cash;

        public int Cash
        {
            get
            {
                return cash;
            }
            set
            {
                cash = value;
                if (cash >= 100)
                {
                    cashEvent();
                }
            }
        }
        public void AddCash(int amount)
        {
            cash += amount;
        }
    }
}

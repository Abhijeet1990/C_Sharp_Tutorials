using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestString
{
    class Program
    {


        class Table
        {
            public int x;
            public string m;
            public Table(int x,string m)
            {
                this.x = x;
                this.m = m;
            }
        }
        static void Main(string[] args)
        {
            Table[] testobjlist = new Table[]
        {
         new Table(67,"BASE+SI"),
         new Table(690,"BASE+DB"),
         new Table(45,"BASE+DB+SI")
        };
            Table[] testobjlist2 = new Table[]
        {
         new Table(1,"SI"),
         new Table(2,"DB")
        };
            for (int i = 0; i < testobjlist.Length; i++)
            {
                Console.WriteLine("{0} contains: ", testobjlist[i].x);
                for (int j = 0; j < testobjlist2.Length; j++)
                {
                    if(testobjlist[i].m.Contains(testobjlist2[j].m))
                    {
                        
                        Console.WriteLine("{0}", testobjlist2[j].x);
                    }
                }
            }
            Console.ReadLine();
            

        }
    }
}

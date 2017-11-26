using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linqTraining
{
    class Program
    {
        static void Main(string[] args)
        {
            var sample = "this is linq tutorial";
            /*
            var result = from c in sample
                         where c == 'e'|| c == 'a' || c == 'i' || c == 'o' || c == 'u' 
                         orderby c descending
                         select c;
                         */

            var people = new List<Person>
            {
                new Person {FirstName="abhijeet",LastName="sahu",Age=26 },
                new Person {FirstName="amar",LastName="nath",Age=25 },
                new Person {FirstName="abhishek",LastName="deb",Age=24 },
                new Person {FirstName="jaya",LastName="sahu",Age=24 },
                new Person {FirstName="thnr",LastName="karthik",Age=23 }

            };
            /*
            var result1 = from p in people
                          where p.Age > 25
                          select p;
            */
            var result1 = from p in people
                          orderby p.LastName descending
                          group p by p.LastName;
            var result = from c in sample
                         where c == 'e' || c == 'a' || c == 'i' || c == 'o' || c == 'u'
                         group c by c;
            foreach (var item in result)
            {
                //Console.WriteLine(item);
                Console.WriteLine("{0}-----{1}", item.Key, item.Count());
            }
            foreach (var items in result1)
            {
                //Console.WriteLine(item);
                Console.WriteLine(items.Key);
                //Console.WriteLine("{0}-----{1}", items.FirstName, items.LastName);
                foreach(var p in items)
                {
                    Console.WriteLine("{0},{1}", p.LastName, p.FirstName);
                }
            }
            Console.ReadLine();
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }


    }
}

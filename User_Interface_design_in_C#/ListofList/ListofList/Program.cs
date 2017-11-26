using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListofList
{
    class Program
    {
        static void Main(string[] args)
        {
            List < double> x = new  List<double>();
            List<List<double>> splittedx = new List<List<double>>();
            x.Add(23.4);
            x.Add(45.4);
            x.Add(32);
            x.Add(95.6);
            x.Add(39.6);
            x.Add(29.0);
            x.Add(69.2);
            x.Add(21.5);
            x.Add(23.4);
            x.Add(45.4);
            x.Add(32);
            x.Add(95.6);
            x.Add(39.6);
            x.Add(29.0);
            x.Add(69.2);
            x.Add(21.5);
            splittedx = splitList(x, 6);
            foreach(var item in splittedx)
            {
                foreach(var i in item)
                {
                    Console.WriteLine(i);
                    Console.WriteLine(splittedx.IndexOf(item));
                }
                Console.WriteLine("\n");
                Console.WriteLine("\n");
            }
            Console.ReadLine();


        }

        public static List<List<double>> splitList(List<double> locations, int nSize)
        {
            var list = new List<List<double>>();

            for (int i = 0; i < locations.Count; i += nSize)
            {
                list.Add(locations.GetRange(i, Math.Min(nSize, locations.Count - i)));
            }

            return list;
        }
    }
}

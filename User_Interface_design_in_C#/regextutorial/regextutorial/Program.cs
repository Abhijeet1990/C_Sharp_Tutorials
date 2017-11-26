using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace regextutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            string test = "\"red apple\" -\"black grape\" +orange";
            Regex r = new Regex("(?<sign>[\\+-]?)((?<value>\\w+)|\"(?<value>[\\w\\s]+)\")", RegexOptions.Compiled);

            foreach (Match m in r.Matches(test))
            {
                Console.WriteLine(m.Groups["sign"]);
                Console.WriteLine(m.Groups["value"]);
            }
            Console.ReadLine();
        }
    }
}

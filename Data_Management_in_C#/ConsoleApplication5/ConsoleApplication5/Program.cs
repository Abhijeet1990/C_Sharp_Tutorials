using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                string line = Console.ReadLine(); // Get string from user
                List<string> output = new List<string>();
                output.Add(DateTime.Now.ToString());
                output.Add(DateTime.Now.AddDays(1).ToString());
                output.Add(DateTime.Now.AddDays(2).ToString());
                if (line == "y") // Check string
                {
                    File.AppendAllText("date.txt",
                  String.Join("\t",output) + Environment.NewLine);
                }
                
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practiceString
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] separators = {" ","+" };
            string myString = "All GTs All Base+SI+PF+DB"; 
            var code = myString.Split(new[] { "Base" }, StringSplitOptions.None)[1];
            //string output = code.ToString();
            string[] words = code.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in words)
                Console.WriteLine(word);
            Console.ReadLine();
        }
    }
}

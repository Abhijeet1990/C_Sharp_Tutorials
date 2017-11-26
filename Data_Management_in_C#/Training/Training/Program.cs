using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Training.Student(5, 87);
            s1.Display();
            Student s2 = new Training.Student(4, 97);
            s2.Display();
            Student s3 = s1 + s2;
            s3.Display();
            Student s4 = s1 + 5;
            s4.Display();
            if(s1>s2)
            {
                Console.WriteLine("s1>s2");
            }
            else
            {
                Console.WriteLine("s1<s2");
            }
            int x = s4;//student is converted to integer
            Console.WriteLine(x);
            Console.ReadLine();
        }
    }
}

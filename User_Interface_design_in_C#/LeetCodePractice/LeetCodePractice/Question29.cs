using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice
{
    class Question29
    {
        public int Divide(int dividend, int divisor)
        {
            int count = 0;

            bool isNumPos = (dividend >= 0) ? true : false;
            bool isDenPos = (divisor >= 0) ? true : false;
            if (dividend < 0) dividend *= -1;
            if (divisor < 0) divisor *= -1;

            //if (divisor == 0) throw new Exception("Divide by 0: not an integer result");
            while (dividend >= divisor)
            {
                dividend -= divisor;
                count++;
            }
            return (isNumPos ^ isDenPos) ? -count : count;

        }
        //static void Main(string[] args)
        //{
        //    Question29 p = new Question29();
        //    int o=p.Divide(-2147483647, -1);
        //    Console.WriteLine(o.ToString());
        //    Console.ReadLine();
        //}
    }
}

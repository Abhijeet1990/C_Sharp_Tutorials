using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice
{
    class Question39
    {
        public List<List<int>> CombinationSum(int[] candidates, int target)
        {
            Array.Sort(candidates);
            int sum;
            List<List<int>> output = new List<List<int>>();
            for (int j = 0; j< candidates.GetLength(0); j++)
            {
                sum = 0;
                List<int> list = new List<int>();
                for (int i = 0; i < candidates.GetLength(0) && sum<=target; i++)
                {
                        sum += candidates[i];
                        list.Add(candidates[i]);
                        if (sum == target)
                        {
                            break;
                        }

                    
                }
                output.Add(list);

            }
            return output;
        }

        static void Main(string[] args)
        {
            int[] integerList = new int[4] {2,3,6,7};
            int target = 7;
            Question39 p = new Question39();
            List<List<int>> output = p.CombinationSum(integerList, target);
            foreach(var item in output)
            {
                foreach(var x in item)
                {
                    Console.WriteLine(x);
                }
            }
            Console.ReadLine();
        }




    }
}

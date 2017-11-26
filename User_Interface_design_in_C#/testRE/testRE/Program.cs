using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace testRE
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            //var str = "123,test,444,<don't split, this>,more test,1";
            //string[] parts = Regex.Split(str, ",(?=(?:[^<]*<[^>]*>)*[^\"]*$)");


            //var pattern = @"\<(.*?)\>";

            //var pattern2 = @"\'(.*?)\'";

            //var query = "abc,,<HSA,3269><PATH,3269>";
            //var matches = Regex.Split(query, pattern);

            //var query3 = "abc,,'HSA,3269','PATH,3269'";
            //var matches3 = Regex.Split(query3, pattern2);
            //var query2 = "'ABCDEFG', 123542, 'XYZ 99,9',,'Abhijeet'";
            //var matches2 = Regex.Split(query2, ",(?=(?:[^']*'[^']*')*[^']*$)");
            ////foreach (Match m in matches)
            ////{
            ////    Console.WriteLine(m.Groups[1]);
            ////}
            ////   |\{[^}]*}|\<[^}]*>
            //var input = "a,[1,2,3,{4,5}],,{c,d,[e,f]},g,<a,b,c,d>";
            //var result =
            //    (from Match m in Regex.Matches(input, @"\[[^]]*]|\<[^}]*>|[^,]+")
            //     select m.Value)
            //    .ToArray();

            //Console.ReadLine();
            string input = "a,,<1,2,3,6>,b,<c,d,e,f>,g,h,,";

            var delimiterPositions = new List<int>();
            int bracesDepth = 0;
            int bracketsDepth = 0;

            for (int i = 0; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case '<':
                        bracesDepth++;
                        break;
                    case '>':
                        bracesDepth--;
                        break;
                   
                    default:
                        if (bracesDepth == 0 && bracketsDepth == 0 && input[i] == ',')
                        {
                            delimiterPositions.Add(i);
                        }
                        break;
                }
            }

            var result = Program.SplitAtPositions(input, delimiterPositions);

        }

        public static string[] SplitAtPositions(string input, List<int> delimiterPositions)
        {
            var output = new List<string>();

            for (int i = 0; i < delimiterPositions.Count; i++)
            {
                int index = i == 0 ? 0 : delimiterPositions[i - 1] + 1;
                int length = delimiterPositions[i] - index;
                string s = input.Substring(index, length);
                output.Add(s);
            }

            string lastString = input.Substring(delimiterPositions.Last() + 1);
            output.Add(lastString);

            return output.ToArray();
        }
    }
}

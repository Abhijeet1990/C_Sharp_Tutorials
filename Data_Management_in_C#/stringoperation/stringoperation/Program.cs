using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stringoperation
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<int>> list = new List<List<int>>();
            String[] words = { "foo", "bar" };
            Program p = new Program();
            list = p.FindSubstring("barfoocarthefoobarmancarbarfoo",words);
            //list.Sort();
            foreach(var item in list)
            {
                foreach (var j in item)
                { Console.WriteLine(j.ToString()); }
                
            }
            Console.ReadLine();
        }

        public List<List<int>> FindSubstring(string s, string[] words)
        {
            List<List<int>> list = new List<List<int>>();
            List<string> Concatedlist = new List<string>();
            string buffer = "";
            for (int i = 0; i < words.Length; i++)
            {
                
                for (int j = 0; j < words.Length;j++)
                {
                    buffer = "";
                    if (j != i)
                    {
                        buffer += words[i] + words[j];
                        Concatedlist.Add(buffer);
                    }
                }
                for (int j = words.Length-1; j >= 0; j--)
                {
                    buffer = "";
                    if (j != i)
                    {
                        buffer += words[i] + words[j];
                        Concatedlist.Add(buffer);
                    }
                }
                foreach (var item in Concatedlist)
                {
                    IEnumerable<int> templist;
                    templist = AllIndexesOf(s,item);
                    list.Add(templist.ToList());
                }
                Concatedlist.Clear();


            }
                

            return list;
        }

        private IEnumerable<int> AllIndexesOf(string text, string query)
        {
            return Enumerable.Range(0, text.Length - query.Length+1)
                .Where(i => query.Equals(text.Substring(i, query.Length)));
        }

        
    }
}

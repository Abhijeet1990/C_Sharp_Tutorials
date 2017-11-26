using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inheritance
{
    public class x
    {

        public int Xattrib1 { get; set; }
        public double Xattrib2 { get; set; }
    }

    public class y
    {
        public int Yattrib1 { get; set; }
        public double Yattrib2 { get; set; }
    }

    public class Parent
    {
        public List<x> one = new List<x>();
        public List<y> two = new List<y>();
        public List<object> mix = new List<object>();
        public Parent()
        {
            foreach (x i in one)
            {
                one.Add(i);
            }
            foreach (y i in two)
            {
                two.Add(i);
            }
            
            mix.Add(one);
            mix.Add(two);
        }
    }
    public class child: Parent
    {
        public List<object> varlist = new List<object>();
        public child()
        {
            
            foreach (List<object> i in mix)
            {
                foreach(List<Attribute> j in i)
                {
                    varlist.Add(j);
                }

            }

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            x xobj = new x();
            xobj.Xattrib1 = 1;
            xobj.Xattrib2 = 2.34;
            y yobj = new y();
            yobj.Yattrib1 = 4;
            yobj.Yattrib2 = 78.59;
            Parent p = new Parent();
            var listEnumerator = p.mix.GetEnumerator(); // Get enumerator
            for(int i=0; listEnumerator.MoveNext()==true;i++)
            {
                
               Console.WriteLine(listEnumerator.Current.Equals(yobj));
               

            }

            /*
            child c = new child();
            
            foreach (object i in c.varlist )
            { 
                Console.WriteLine(i);
            }*/
            
            Console.Read();
        }
    }
}

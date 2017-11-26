using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RTP.Analysis;
using System.Globalization;

namespace teststringToClass
{
    class Program
    {
        
        static void Main(string[] args)
        
        {
            OperatingMode pObject = new OperatingMode();
            List<string> propertyList = new List<string>();
            string[] s = new string[4] { "qdwed", "dewedwd", "dewdwed", "34" };
            int i = 0;
            if (pObject != null)
            {
                foreach (var prop in pObject.GetType().GetProperties())
                {
                    
                    prop.SetValue(pObject, Convert.ChangeType(s[i], prop.PropertyType), null);
                    i++;
                    
                }
            }
            //Console.WriteLine("{0} {1} {2} {3}",pObject.Criteria,pObject.Description,pObject.Mode,pObject.MinDuration);

            List<string> test = new List<string>();
            test.Add("afdfsa");
            test.Add("dasd");
            string output = VariablesToString(test);
            Console.WriteLine(output);
            string[] a = StringToVariables(output);
            for (int j = 0; j < a.Count(); j++)
            {
                Console.WriteLine(a[j]);
            }
            Console.ReadLine();
            
        }

        public static string VariablesToString(List<string> variables)
        {
            string output = string.Join(",", variables);
            return output;
        }

        public static string[] StringToVariables(string variableString)
        {
            string[] list = variableString.Split(',');
            return list;
        }
    }
}

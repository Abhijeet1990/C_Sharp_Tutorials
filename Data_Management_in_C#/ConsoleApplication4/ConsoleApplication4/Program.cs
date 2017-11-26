using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RTP.Performance;
using RTP.Analysis;
using System.Reflection;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {
            OperatingMode om = new OperatingMode();
            om.Mode = "HOL";
            om.Description = "High Operating Limit";
            om.Criteria = "([CT Exhaust Gas Temp Control Curve] - [CT Exhaust Gas Temp] <= 5 or [CT Exhaust Gas Temp Control Curve] - [CT Exhaust Gas Temp] <= -5) and [CT Percentage Output] > 90 and [Unit Power Output] > 275";
            om.MinDuration = 1;


            OperatingMode om2 = new OperatingMode();
            om2.Mode = "LOL";
            om2.Description = "Low Operating Limit";
            om2.Criteria = "([CT Exhaust Gas Temp Control Curve] - [CT Exhaust Gas Temp] <= 5 or [CT Exhaust Gas Temp Control Curve] - [CT Exhaust Gas Temp] <= -5) and [CT Percentage Output] > 90 and [Unit Power Output] > 275";
            om2.MinDuration = 1;

            List<OperatingMode> omList = new List<OperatingMode>();
            omList.Add(om);
            omList.Add(om2);

            string output = Utilities.OperatingModeListToString(omList);
            Console.WriteLine(output);

            List<OperatingMode> omList1 = new List<OperatingMode>();
            omList1 = Utilities.StringToOperatingMode(output);
            
            Console.ReadLine();
        }

        //public static string OperatingModeListToString(List<OperatingMode> operatingModes)
        //{
        //    string output = "";
        //    foreach(var item in operatingModes)
        //    {
        //        output += string.Join(",", typeof(OperatingMode).GetProperties().Select(x => x.GetValue(item, null)));
        //        output += "\n";
        //    }
        //    output=output.Substring(0, output.Length - 1);
        //    return output;
        //}


        //public static List<OperatingMode> StringToOperatingMode(string operatingMode)
        //{

        //    List<OperatingMode> operatingModes = new List<OperatingMode>();
        //    if (string.IsNullOrEmpty(operatingMode)) return operatingModes;

        //    string[] list = operatingMode.Split('\n');
        //    foreach (var line in list)
        //    {
        //        OperatingMode mode = new OperatingMode();
        //        string[] items = line.Split(',');
        //        PropertyInfo[] prop = mode.GetType().GetProperties();
        //        foreach (var keyValue in prop.Zip(items, Tuple.Create))
        //        {
        //            keyValue.Item1.SetValue(mode, Convert.ChangeType(keyValue.Item2, keyValue.Item1.PropertyType), null);
        //        }
        //        operatingModes.Add(mode);
        //    }
        //    return operatingModes;
        //}
    }
}

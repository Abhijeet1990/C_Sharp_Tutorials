using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartMeterData
{
    class Program
    {
        static void Main(string[] args)
        {
            var dt = Program.ConvertCSVtoDataTable("C:\\Users\\Abhijeet\\Desktop\\apartment\\2015\\Apt1_2015.csv");
            DateTime desiredDate = new DateTime(2015, 02, 03);

            var data = dt.AsEnumerable().Where(r => (DateTime.Parse(r["Timestamp"].ToString()).Day == desiredDate.Day) &&(DateTime.Parse(r["Timestamp"].ToString()).Month == desiredDate.Month));
            var onedaydata = data.CopyToDataTable();
            Console.ReadLine();
        }

    public static DataTable ConvertCSVtoDataTable(string strFilePath)
    {
        DataTable dt = new DataTable();
        using (StreamReader sr = new StreamReader(strFilePath))
        {
            string[] headers = sr.ReadLine().Split(',');
            foreach (string header in headers)
            {
                dt.Columns.Add(header);
            }
            while (!sr.EndOfStream)
            {
                string[] rows = sr.ReadLine().Split(',');
                DataRow dr = dt.NewRow();
                for (int i = 0; i < headers.Length; i++)
                {
                    dr[i] = rows[i];
                }
                dt.Rows.Add(dr);
            }

        }


        return dt;
    }

    }

}

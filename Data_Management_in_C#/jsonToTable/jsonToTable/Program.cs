using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Data;
using System.ComponentModel;
using System.Reflection;

namespace jsonToTable
{
    class Program
    {
        class Product
        {
            public string Name;
            public DateTime Expiry;
            public decimal Price;
            public string[] Sizes;



        }

        public class ListtoDataTableConverter
        {
            public static DataTable ToDataTable<T>(List<T> items)
            {
                DataTable dataTable = new DataTable(typeof(T).Name);
                //Get all the properties
                PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (PropertyInfo prop in Props)
                {
                    //Setting column names as Property names
                    dataTable.Columns.Add(prop.Name);
                }
                foreach (T item in items)
                {
                    var values = new object[Props.Length];
                    for (int i = 0; i < Props.Length; i++)
                    {
                        //inserting property values to datatable rows
                        values[i] = Props[i].GetValue(item, null);
                    }
                    dataTable.Rows.Add(values);
                }
                //put a breakpoint here and check datatable
                return dataTable;
            }
        }
        static void Main(string[] args)
        {
            // Here we create a DataTable with four columns.
            DataTable table = new DataTable();
            table.Columns.Add("Dosage", typeof(int));
            table.Columns.Add("Drug", typeof(string));
            table.Columns.Add("Patient", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));
            table.Columns.Add("Dosage1", typeof(int));
            table.Columns.Add("Drug1", typeof(string));
            table.Columns.Add("Patient1", typeof(string));
            table.Columns.Add("Date1", typeof(DateTime));
            table.Columns.Add("Dosage2", typeof(int));
            table.Columns.Add("Drug2", typeof(string));
            table.Columns.Add("Patient2", typeof(string));
            table.Columns.Add("Date2", typeof(DateTime));
            table.Columns.Add("Dosage3", typeof(int));
            table.Columns.Add("Drug3", typeof(string));
            table.Columns.Add("Patient3", typeof(string));
            table.Columns.Add("Date3", typeof(DateTime));
            table.Columns.Add("Dosage4", typeof(int));
            table.Columns.Add("Drug4", typeof(string));
            table.Columns.Add("Patient4", typeof(string));
            table.Columns.Add("Date4", typeof(DateTime));
            table.Columns.Add("Dosage5", typeof(int));
            table.Columns.Add("Drug5", typeof(string));
            table.Columns.Add("Patient5", typeof(string));
            table.Columns.Add("Date5", typeof(DateTime));
            table.Columns.Add("Dosage6", typeof(int));
            table.Columns.Add("Drug6", typeof(string));
            table.Columns.Add("Patient6", typeof(string));
            table.Columns.Add("Date6", typeof(DateTime));
            table.Columns.Add("Dosage7", typeof(int));
            table.Columns.Add("Drug7", typeof(string));
            table.Columns.Add("Patient7", typeof(string));
            table.Columns.Add("Date7", typeof(DateTime));
            table.Columns.Add("Dosage8", typeof(int));
            table.Columns.Add("Drug8", typeof(string));
            table.Columns.Add("Patient8", typeof(string));
            table.Columns.Add("Date8", typeof(DateTime));
            table.Columns.Add("Dosage9", typeof(int));
            table.Columns.Add("Drug9", typeof(string));
            table.Columns.Add("Patient9", typeof(string));
            table.Columns.Add("Date9", typeof(DateTime));



            // Here we add five DataRows.
            table.Rows.Add( 25, "Indocin", "David", DateTime.Now, 25, "Indocin", "David", DateTime.Now, 25, "Indocin", "David", DateTime.Now, 25, "Indocin", "David", DateTime.Now, 25, "Indocin", "David", DateTime.Now, 25, "Indocin", "David", DateTime.Now, 25, "Indocin", "David", DateTime.Now, 25, "Indocin", "David", DateTime.Now, 25, "Indocin", "David", DateTime.Now, 25, "Indocin", "David", DateTime.Now);
            table.Rows.Add(50, "Enebrel", "Sam", DateTime.Now, 50, "Enebrel", "Sam", DateTime.Now, 50, "Enebrel", "Sam", DateTime.Now, 50, "Enebrel", "Sam", DateTime.Now, 50, "Enebrel", "Sam", DateTime.Now, 50, "Enebrel", "Sam", DateTime.Now, 50, "Enebrel", "Sam", DateTime.Now, 50, "Enebrel", "Sam", DateTime.Now, 50, "Enebrel", "Sam", DateTime.Now, 50, "Enebrel", "Sam", DateTime.Now);
            table.Rows.Add(10, "Hydralazine", "Christoff", DateTime.Now, 10, "Hydralazine", "Christoff", DateTime.Now, 10, "Hydralazine", "Christoff", DateTime.Now, 10, "Hydralazine", "Christoff", DateTime.Now, 10, "Hydralazine", "Christoff", DateTime.Now, 10, "Hydralazine", "Christoff", DateTime.Now, 10, "Hydralazine", "Christoff", DateTime.Now, 10, "Hydralazine", "Christoff", DateTime.Now, 10, "Hydralazine", "Christoff", DateTime.Now, 10, "Hydralazine", "Christoff", DateTime.Now);
            table.Rows.Add(21, "Combivent", "Janet", DateTime.Now, 21, "Combivent", "Janet", DateTime.Now, 21, "Combivent", "Janet", DateTime.Now, 21, "Combivent", "Janet", DateTime.Now, 21, "Combivent", "Janet", DateTime.Now, 21, "Combivent", "Janet", DateTime.Now, 21, "Combivent", "Janet", DateTime.Now, 21, "Combivent", "Janet", DateTime.Now, 21, "Combivent", "Janet", DateTime.Now, 21, "Combivent", "Janet", DateTime.Now);
            table.Rows.Add(100, "Dilantin", "Melanie", DateTime.Now, 100, "Dilantin", "Melanie", DateTime.Now, 100, "Dilantin", "Melanie", DateTime.Now, 100, "Dilantin", "Melanie", DateTime.Now, 100, "Dilantin", "Melanie", DateTime.Now, 100, "Dilantin", "Melanie", DateTime.Now, 100, "Dilantin", "Melanie", DateTime.Now, 100, "Dilantin", "Melanie", DateTime.Now, 100, "Dilantin", "Melanie", DateTime.Now, 100, "Dilantin", "Melanie", DateTime.Now);
         


            string json = JsonConvert.SerializeObject(table);

            var newdt = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));
            Console.ReadLine();


        }
    }
}

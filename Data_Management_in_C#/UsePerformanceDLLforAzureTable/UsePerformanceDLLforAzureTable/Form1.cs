using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RTP.Performance;
using System.Text.RegularExpressions;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage.RetryPolicies;
using UsePerformanceDLLforAzureTable.Infrastructure;
using System.Data.SqlClient;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.Storage.Auth;

namespace UsePerformanceDLLforAzureTable
{
    public partial class Form1 : Form
    {
        DataTable result = new DataTable();
        List<string> variablelist = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

            
        private async void OnClickCreateAzureTable(object sender, EventArgs e)
        {
            PerformanceSearch ps = new PerformanceSearch();
            DateTime tmax = new DateTime();
            tmax = dateTimePicker2.Value;
            DateTime tmin = new DateTime();
            tmin = dateTimePicker1.Value;


            //DateTime tmax = new DateTime(2016, 12, 31);
            //DateTime tmin = new DateTime(2016, 06, 01);//These parameters are used to suffice the RTP.Performance Table
            //List<string> variablelist = new List<string>();
            List<string> variablelist = null;
            //get the variable List from the VariableMaster table of RealTimePower Database
            /*
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Server=tcp:realtimepower.database.windows.net,1433;Initial Catalog=RealTimePower;Persist Security Info=False;User ID=abhijeetsahu;Password=@rtp2016saHu;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            DataTable data = new DataTable();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT Name FROM VariableMaster";
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);

            for (int i = 0; i < data.Rows.Count; i++)
            {
                variablelist.Add(data.Rows[i][0].ToString());
            }

            //Get the List of All the 
            /*
            variablelist.Add("Ambient Air Density");
            variablelist.Add("Ambient Air Dew Point");
            variablelist.Add("Ambient Air Kappa");
            variablelist.Add("Ambient Air Molar Mass");
            variablelist.Add("Ambient Air Press");
            variablelist.Add("Ambient Air Rel Humidity");
            variablelist.Add("Ambient Air Speed of Sound");
            variablelist.Add("Ambient Air Temp");*/
            List<Calculation> calculations = new List<Calculation>();
            string path = "C:\\Users\\Abhijeet\\Desktop\\Wise";
            result = GetValues(path, variablelist, calculations, tmax, tmin);
            //Just to check the status of the file locally
            dataGridView1.DataSource = result;

            string tableName = "Wise2";
            // Create or reference an existing table

            CloudTable table = await TableCreation.CreateTableAsync(tableName);
            await CRUDFunctions.BatchInsertOfDataPointEntitiesAsync(table, result);
           


        }


        public static DataTable GetValues(string directory, List<string> selectedVariables, List<Calculation> calculations, DateTime tmax, DateTime tmin)
        {
            DataTable mergedDataTables = new DataTable();

            // Get directory information
            if (!Directory.Exists(directory)) return null;

            var filenames = from f in Directory.GetFiles(directory, "*.tab", SearchOption.AllDirectories)
                            let d = PerformanceHelper.GetDateFromFileName(f)
                            where d.Date <= tmax.Date
                            where d.Date >= tmin.Date
                            select new { Path = Path.GetFullPath(f) };

            foreach (var filename in filenames)
            {
                try
                {
                    // Open the file readonly so it is not locked
                    using (FileStream fs = new FileStream(filename.Path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        using (StreamReader sr = new StreamReader(fs, PerformanceHelper.GetEncoding(filename.Path)))
                        {
                            DataTable headerTable = new DataTable();
                            DataTable testTable = new DataTable();
                            do
                            {
                                // Make sure - have to read next line or to use already read line from previous execution (In case of more than one header in a tab file)
                                string line = sr.ReadLine();

                                // Split the line into columns
                                if (line == null) continue;
                                string[] column = line.Split('\t');

                                // Process headers
                                if (column[0] == "Timestamp")
                                {
                                    // Generator column headers from tab file
                                    mergedDataTables.Merge(headerTable, false, MissingSchemaAction.Add);
                                    headerTable = GenerateColumnHeaders(selectedVariables, calculations, sr, column);

                                    // Continue if no columns are found in this collection (Header)
                                    if (headerTable.Columns.Count == 0) continue;

                                    // Move to next line after generating new headers
                                    line = sr.ReadLine();
                                    if (line == null) continue;
                                    column = line.Split('\t');
                                }
                                //testTable = headerTable.Clone();
                                // Get date
                                DateTime date = DateTime.MinValue;
                                DateTime.TryParse(column[0], out date);
                                if (date > tmax || date < tmin) continue;

                                // Add date value
                                var row = headerTable.NewRow();
                                row[0] = date;

                                // Add variable values
                                double number;
                                foreach (DataColumn dataColumn in headerTable.Columns)
                                {
                                    if (dataColumn.ColumnName == "Timestamp") continue;
                                    int col = int.Parse(dataColumn.ExtendedProperties["ColNumber"].ToString());

                                    if (col >= 0) // col of -1 means it is a calculated column
                                    {
                                        double.TryParse(column[col], out number);
                                        row[dataColumn.ColumnName] = number;
                                    }
                                }
                                //MessageBox.Show(headerTable.Columns.Count.ToString());
                                // Add new datarow to table
                                headerTable.Rows.Add(row);
                                //testTable.Rows.Add(row);
                                // Break if just looking for one data point.
                                if (tmax.Subtract(tmin).TotalMinutes < 1.5) break;

                            } while (!sr.EndOfStream);

                            // Merge the tables in a full join
                            mergedDataTables.Merge(headerTable, false, MissingSchemaAction.Add);
                        }
                    }
                }
                catch (Exception ex)
                {
                    return mergedDataTables;// Means bad search string

                }
            }
            return mergedDataTables;
        }

        public static DataTable GenerateColumnHeaders(List<string> variables, List<Calculation> calculations, StreamReader sr, string[] column)
        {
            // Read lines 1-4 and split into columns
            string[] colLine0 = column;
            string[] colLine1 = sr.ReadLine().Split('\t');
            string[] colLine2 = sr.ReadLine().Split('\t');
            string[] colLine3 = sr.ReadLine().Split('\t');

            // If no variables supplied, create new empty list so all columns will be included
            bool getAllVariables = false;
            if (variables == null)
            {
                variables = new List<string>();
                getAllVariables = true;
            }

            // Make sure that variables in calculation expression included as well
            if (calculations != null)
            {
                List<string> calculationVariables = new List<string>();
                foreach (var calc in calculations)
                {
                    var list = PerformanceHelper.ExtractVariablesFromExpression(calc.Expression);
                    calculationVariables.AddRange(list);
                }

                // Add distinct variables for datatable column headers
                variables.Union(calculationVariables);
            }

            // Add the timestamp column as a default
            DataTable variableTable = new DataTable();
            variableTable.Columns.Add("Timestamp", typeof(DateTime));
            //variableTable.Columns.Add("Hour", typeof(int));
            //variableTable.Columns["Hour"].ExtendedProperties.Add("ColNumber", 1);
            //variableTable.Columns["Hour"].ExtendedProperties.Add("EngUnits", "yyyy-MM-dd");
            variableTable.Columns["Timestamp"].ExtendedProperties.Add("EngUnits", "yyyy-MM-dd");
            variableTable.Columns["Timestamp"].ExtendedProperties.Add("ColNumber", 0);

            for (var n = 1; n < colLine0.Count(); n++)
            {
                string variable = (colLine0[n] + " " + colLine1[n] + " " + colLine2[n]).Trim();
                string engUnits = (string.IsNullOrEmpty(colLine3[n]) ? "" : colLine3[n]).Trim();

                if (!getAllVariables)
                {
                    // Get only selected variables from performance file
                    var found = variables.Where(item => item == variable);
                    if (found.Count() == 0) continue;
                }

                // Add the variable to table, but check for duplicates
                if (!variableTable.Columns.Contains(variable))
                    variableTable.Columns.Add(variable, typeof(double));

                // Add extended column properties to hold engineering units and col number for easier searching
                if (variableTable.Columns[variable].ExtendedProperties.Count == 0)
                {
                    variableTable.Columns[variable].ExtendedProperties.Add("EngUnits", engUnits);
                    variableTable.Columns[variable].ExtendedProperties.Add("ColNumber", n);
                }
            }

            // Add any calculated column expressions and test
            if (calculations != null)
            {
                int columns = variableTable.Columns.Count - 1;
                foreach (Calculation calculation in calculations)
                {
                    if (!variableTable.Columns.Contains(calculation.Name))
                        variableTable.Columns.Add(calculation.Name, typeof(double));

                    variableTable.Columns[calculation.Name].ExtendedProperties.Add("EngUnits", calculation.EngUnits);
                    variableTable.Columns[calculation.Name].ExtendedProperties.Add("ColNumber", -1);

                    // Make sure expression is valid and columns of the calculation exist
                    try { variableTable.Columns[calculation.Name].Expression = calculation.Expression; }
                    catch (Exception ex) { variableTable.Columns[calculation.Name].Expression = null; }
                }
            }

            return variableTable;
        }


        private async void FilterByVariableButton_Click(object sender, EventArgs e)
        {
            DataTable QueryResult = new DataTable();
            string tableName = "wise1";
            // Create or reference an existing table
            CloudTable table = await TableCreation.CreateTableAsync(tableName);
            //List<Task> tasks = new List<Task>();
            List<DataTable> dataTables = new List<DataTable>();

            if (selectVariableComboBox.Text != "All")
            {
                QueryResult = CRUDFunctions.ExecuteSimpleQuery(table, selectVariableComboBox.Text);
            }
            else
            {
                List<Task<DataTable>> Tasks = new List<Task<DataTable>>();
                for(int i=0;i< result.Columns.Count-1;i++)
                {
                    var t = Task.Factory.StartNew(() => CRUDFunctions.ExecuteSimpleQuery(table,variablelist[i]));
                    Tasks.Add(t);
                }
                Task.WaitAll(Tasks.ToArray());
                
                foreach(var t in Tasks)
                {
                    dataTables.Add(t.Result);
                }

                foreach (var t in dataTables)
                {
                    QueryResult.Merge(t);
                }
            }

            /*

            switch (selectVariableComboBox.Text)
            {
                case "Ambient Air Density":
                    QueryResult = CRUDFunctions.ExecuteSimpleQuery(table, "Ambient Air Density");
                    break;
                case "Ambient Air Dew Point":
                    QueryResult = CRUDFunctions.ExecuteSimpleQuery(table, "Ambient Air Dew Point");
                    break;
                case "Ambient Air Kappa":
                    QueryResult = CRUDFunctions.ExecuteSimpleQuery(table, "Ambient Air Kappa");
                    break;
                case "Ambient Air Molar Mass":
                    QueryResult = CRUDFunctions.ExecuteSimpleQuery(table, "Ambient Air Molar Mass");
                    break;
                case "Ambient Air Press":
                    QueryResult = CRUDFunctions.ExecuteSimpleQuery(table, "Ambient Air Press");
                    break;
                case "Ambient Air Rel Humidity":
                    QueryResult = CRUDFunctions.ExecuteSimpleQuery(table, "Ambient Air Rel Humidity");
                    break;
                case "Ambient Air Speed of Sound":
                    QueryResult = CRUDFunctions.ExecuteSimpleQuery(table, "Ambient Air Speed of Sound");
                    break;
                case "Ambient Air Temp":
                    QueryResult = CRUDFunctions.ExecuteSimpleQuery(table, "Ambient Air Temp");
                    break;
                case "All":
                    var t1 = Task.Factory.StartNew(() => CRUDFunctions.ExecuteSimpleQuery(table, "Ambient Air Density"));
                    var t2 = Task.Factory.StartNew(() => CRUDFunctions.ExecuteSimpleQuery(table, "Ambient Air Dew Point"));
                    var t3 = Task.Factory.StartNew(() => CRUDFunctions.ExecuteSimpleQuery(table, "Ambient Air Kappa"));
                    var t4 = Task.Factory.StartNew(() => CRUDFunctions.ExecuteSimpleQuery(table, "Ambient Air Molar Mass"));
                    var t5 = Task.Factory.StartNew(() => CRUDFunctions.ExecuteSimpleQuery(table, "Ambient Air Press"));
                    var t6 = Task.Factory.StartNew(() => CRUDFunctions.ExecuteSimpleQuery(table, "Ambient Air Rel Humidity"));
                    var t7 = Task.Factory.StartNew(() => CRUDFunctions.ExecuteSimpleQuery(table, "Ambient Air Speed of Sound"));
                    var t8 = Task.Factory.StartNew(() => CRUDFunctions.ExecuteSimpleQuery(table, "Ambient Air Temp"));
                    tasks.Add(t1);
                    tasks.Add(t2);
                    tasks.Add(t3);
                    tasks.Add(t4);
                    tasks.Add(t5);
                    tasks.Add(t6);
                    tasks.Add(t7);
                    tasks.Add(t8);

                    Task.WaitAll(tasks.ToArray());
                    dataTables.Add(t1.Result);
                    dataTables.Add(t2.Result);
                    dataTables.Add(t3.Result);
                    dataTables.Add(t4.Result);
                    dataTables.Add(t5.Result);
                    dataTables.Add(t6.Result);
                    dataTables.Add(t7.Result);
                    dataTables.Add(t8.Result);

                    foreach (var t in dataTables)
                    {
                        QueryResult.Merge(t);
                    }
                    break;

            }*/
            

            FilteredDGV.DataSource = QueryResult;
        }

        private void FilterByTimeButton_Click(object sender, EventArgs e)
        {
            DataTable QueryResult = new DataTable();
            string tableName = "wise1";
            string _accountName = "realtimepower";
            string _accountKey = "w2lEeS6wFdxTGLN032WMG0i/cQEBGbqIwT9ILMLhpj4CZnvEyu9Bgyldb5gn0XVw0JBU3j1dllcQHOPFUOH7Eg==";
            var creds = new StorageCredentials(_accountName, _accountKey);
            var account = new CloudStorageAccount(creds, useHttps: true);
            // Create or reference an existing table
            //CloudTable table = await TableCreation.CreateTableAsync(tableName);
            //var storageAccount=CloudStorageAccount.Parse("StorageConnectionString");
            //CloudStorageAccount storageAccount = CloudStorageAccount.Parse(RoleEnvironment.GetConfigurationSettingValue("StorageConnectionString"));
            CloudTableClient tableClient = account.CreateCloudTableClient();
            CloudTable table = tableClient.GetTableReference(tableName);

            List<Task> tasks = new List<Task>();
            List<DataTable> dataTables = new List<DataTable>();
            /*
            var t1 = Task.Factory.StartNew(() => CRUDFunctions.ExecuteSimpleQueryWithTimeRange(table, "Ambient Air Density", textBox4.Text,textBox3.Text));
            //var t2 = Task.Factory.StartNew(() => CRUDFunctions.ExecuteSimpleQueryWithTimeRange(table, "Ambient Air Density", textBox4.Text, textBox3.Text));
            //var t2 = Task.Factory.StartNew(() => CRUDFunctions.ExecuteSimpleQueryWithTimeRange(table, "Ambient Air Dew Point", textBox4.Text, textBox3.Text));
            //var t3 = Task.Factory.StartNew(() => CRUDFunctions.ExecuteSimpleQueryWithTimeRange(table, "Ambient Air Kappa", textBox4.Text, textBox3.Text));
            //var t4 = Task.Factory.StartNew(() => CRUDFunctions.ExecuteSimpleQueryWithTimeRange(table, "Ambient Air Molar Mass", textBox4.Text, textBox3.Text));
            //var t5 = Task.Factory.StartNew(() => CRUDFunctions.ExecuteSimpleQueryWithTimeRange(table, "Ambient Air Press", textBox4.Text, textBox3.Text));
            //var t6 = Task.Factory.StartNew(() => CRUDFunctions.ExecuteSimpleQueryWithTimeRange(table, "Ambient Air Rel Humidity", textBox4.Text, textBox3.Text));
            //var t7 = Task.Factory.StartNew(() => CRUDFunctions.ExecuteSimpleQueryWithTimeRange(table, "Ambient Air Speed of Sound", textBox4.Text, textBox3.Text));
            //var t8 = Task.Factory.StartNew(() => CRUDFunctions.ExecuteSimpleQueryWithTimeRange(table, "Ambient Air Temp", textBox4.Text, textBox3.Text));
            tasks.Add(t1);
            //tasks.Add(t2);
            //tasks.Add(t3);
            //tasks.Add(t4);
            //tasks.Add(t5);
            //tasks.Add(t6);
            //tasks.Add(t7);
            //tasks.Add(t8);

            Task.WaitAll(tasks.ToArray());

            dataTables.Add(t1.Result);
            //dataTables.Add(t2.Result);
            //dataTables.Add(t3.Result);
            //dataTables.Add(t4.Result);
            //dataTables.Add(t5.Result);
            //dataTables.Add(t6.Result);
            //dataTables.Add(t7.Result);
            //dataTables.Add(t8.Result);*/
            CRUDFunctions.ExecuteSimpleQueryWithTimeRange(table, "Ambient Air Density", textBox4.Text, textBox3.Text);
            CRUDFunctions.ExecuteSimpleQueryWithTimeRange(table, "Ambient Air Dew Point", textBox4.Text, textBox3.Text);
            CRUDFunctions.ExecuteSimpleQueryWithTimeRange(table, "Ambient Air Kappa", textBox4.Text, textBox3.Text);
            CRUDFunctions.ExecuteSimpleQueryWithTimeRange(table, "Ambient Air Molar Mass", textBox4.Text, textBox3.Text);
            CRUDFunctions.ExecuteSimpleQueryWithTimeRange(table, "Ambient Air Press", textBox4.Text, textBox3.Text);
            CRUDFunctions.ExecuteSimpleQueryWithTimeRange(table, "Ambient Air Rel Humidity", textBox4.Text, textBox3.Text);
            CRUDFunctions.ExecuteSimpleQueryWithTimeRange(table, "Ambient Air Speed of Sound", textBox4.Text, textBox3.Text);
            CRUDFunctions.ExecuteSimpleQueryWithTimeRange(table, "Ambient Air Temp", textBox4.Text, textBox3.Text);

            for (int i = 1; i < dataTables.Count; i++)
            {
             
                dataTables[0] = CRUDFunctions.JoinDataTable(dataTables[0], dataTables[i], "Time");
            }
            
            QueryResult = dataTables[0].Copy();
            
            FilteredDGV.DataSource = QueryResult;
        }

         
        //var t1 = Task.Factory.StartNew(() => ExecuteSimpleQuery(table, "Ambient Air Density", "01 05 2017 06:39:49", "01 12 2017 10:12:49", min, max));
        private async void FilterByValueRangeButton_Click(object sender, EventArgs e)
        {
            DataTable QueryResult = new DataTable();
            string tableName = "wise1";
            // Create or reference an existing table
            CloudTable table = await TableCreation.CreateTableAsync(tableName);
            
            switch (selectVariableforValueFilterComboBox.Text) {
                case "Ambient Air Density":
                    QueryResult=CRUDFunctions.ExecuteSimpleQueryWithTimeAndValueRange(table, "Ambient Air Density", textBox4.Text, textBox3.Text, Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text));
                    break;
                case "Ambient Air Dew Point":
                    QueryResult = CRUDFunctions.ExecuteSimpleQueryWithTimeAndValueRange(table, "Ambient Air Dew Point", textBox4.Text, textBox3.Text, Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text));
                    break;
                case "Ambient Air Kappa":
                    QueryResult = CRUDFunctions.ExecuteSimpleQueryWithTimeAndValueRange(table, "Ambient Air Kappa", textBox4.Text, textBox3.Text, Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text));
                    break;
                case "Ambient Air Molar Mass":
                    QueryResult = CRUDFunctions.ExecuteSimpleQueryWithTimeAndValueRange(table, "Ambient Air Molar Mass", textBox4.Text, textBox3.Text, Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text));
                    break;
                case "Ambient Air Press":
                    QueryResult = CRUDFunctions.ExecuteSimpleQueryWithTimeAndValueRange(table, "Ambient Air Press", textBox4.Text, textBox3.Text, Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text));
                    break;
                case "Ambient Air Rel Humidity":
                    QueryResult = CRUDFunctions.ExecuteSimpleQueryWithTimeAndValueRange(table, "Ambient Air Rel Humidity", textBox4.Text, textBox3.Text, Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text));
                    break;
                case "Ambient Air Speed of Sound":
                    QueryResult = CRUDFunctions.ExecuteSimpleQueryWithTimeAndValueRange(table, "Ambient Air Speed of Sound", textBox4.Text, textBox3.Text, Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text));
                    break;
                case "Ambient Air Temp":
                    QueryResult = CRUDFunctions.ExecuteSimpleQueryWithTimeAndValueRange(table, "Ambient Air Temp", textBox4.Text, textBox3.Text, Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text));
                    break;

                    
            }
            FilteredDGV.DataSource = QueryResult;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox6.Text = dateTimePicker1.Value.ToUniversalTime().ToString("u");
            
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            textBox5.Text = dateTimePicker2.Value.ToUniversalTime().ToString("u");
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            textBox4.Text = dateTimePicker3.Value.ToUniversalTime().ToString("u");
        }

        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {
            textBox3.Text = dateTimePicker4.Value.ToUniversalTime().ToString("u");
        }

        
    }
}

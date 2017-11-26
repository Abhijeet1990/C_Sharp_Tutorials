using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gridViewTutorial
{
    public partial class TestGV : System.Web.UI.Page
    {
        private SqlConnection conn = new SqlConnection("Data Source=ABHIJEET-PC\\SQLEXPRESS;Initial Catalog=EmployeeDB;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvbind();
            }
            
        }

        protected void gvbind()
        {
            //conn.Open();
            //SqlCommand cmd = new SqlCommand("Select * from Employees", conn);
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //da.Fill(ds);
            //conn.Close();
            var table = ReadDerateFileIntoDataTable("C:\\users\\abhijeet\\documents\\visual studio 2015\\Projects\\gridViewTutorial\\gridViewTutorial\\Employee.txt");

            if (table.Rows.Count > 0)
            {
                GridView1.DataSource = table;
                GridView1.DataBind();
                //GridView1.UseAccessibleHeader = true;
                //GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                table.Rows.Add(table.NewRow());
                GridView1.DataSource = table;
                GridView1.DataBind();
                int columncount = GridView1.Rows[0].Cells.Count;
                GridView1.Rows[0].Cells.Clear();
                GridView1.Rows[0].Cells.Add(new TableCell());
                GridView1.Rows[0].Cells[0].ColumnSpan = columncount;
                GridView1.Rows[0].Cells[0].Text = "No Records Found";
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var table = ReadDerateFileIntoDataTable("C:\\users\\abhijeet\\documents\\visual studio 2015\\Projects\\gridViewTutorial\\gridViewTutorial\\Employee.txt");

            for (int i = table.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = table.Rows[i];
                if (Convert.ToInt32(dr["ID"]) == Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString()))
                    dr.Delete();
            }
            WriteDataTableToFile(table, "C:\\users\\abhijeet\\documents\\visual studio 2015\\Projects\\gridViewTutorial\\gridViewTutorial\\Employee.txt", true);
            gvbind();
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            gvbind();
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int userid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            DropDownList gender = (DropDownList)row.FindControl("GenderDD");
            //TextBox txtname=(TextBox)gr.cell[].control[];  
            TextBox firstName = (TextBox)row.Cells[1].Controls[0];
            TextBox lastName = (TextBox)row.Cells[2].Controls[0];          
            TextBox salary = (TextBox)row.Cells[4].Controls[0];
 
            GridView1.EditIndex = -1;
            var table = ReadDerateFileIntoDataTable("C:\\users\\abhijeet\\documents\\visual studio 2015\\Projects\\gridViewTutorial\\gridViewTutorial\\Employee.txt");

            foreach (DataRow dr in table.Rows) // search whole table
            {
                if (Convert.ToInt32(dr["ID"]) == userid)
                {
                    dr["FirstName"] = firstName.Text;
                    dr["LastName"] = lastName.Text;
                    dr["Gender"] = gender.SelectedValue;
                    dr["Salary"] = salary.Text;
                }
            }
            //conn.Open();
            ////SqlCommand cmd = new SqlCommand("SELECT * FROM detail", conn);  
            //SqlCommand cmd = new SqlCommand("update Employees set FirstName='" + firstName.Text + "',LastName='" + secondName.Text + "',Gender='" + gender.Text + "',Salary='" + salary.Text + "'where id='" + userid + "'", conn);
            //cmd.ExecuteNonQuery();
            //conn.Close();
            WriteDataTableToFile(table, "C:\\users\\abhijeet\\documents\\visual studio 2015\\Projects\\gridViewTutorial\\gridViewTutorial\\Employee.txt", true);
            gvbind();
            //GridView1.DataBind();  
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            gvbind();
        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            gvbind();
        }



        public static DataTable ReadDerateFileIntoDataTable(string filename)
        {
            DataTable dataTable = new DataTable();

            if (string.IsNullOrEmpty(filename) || !File.Exists(filename)) return new DataTable();

            try
            {
                // Open the file readonly so it is not locked
                int index = 0;
                using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        do
                        {
                            // Read line
                            string line = sr.ReadLine();

                            // Split the line into columns
                            if (line == null) continue;
                            string[] column = line.Split('\t');

                            // Process headers and find forecast name
                            if (index == 0)
                            {
                                // Create table headers
                                dataTable = CreateDataTableHeaders(column);

                                // Read next data line
                                line = sr.ReadLine();
                                column = line.Split('\t');
                            }
                            // Add values to datatable
                            DataRow row = dataTable.NewRow();
                            for (int n = 0; n < column.Count(); n++)
                            {
                                row[n] = column[n];
                            }

                            // Add row to datatable
                            dataTable.Rows.Add(row);

                            index++;

                        } while (!sr.EndOfStream);

                    }

                    return dataTable;
                }
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }

        private static DataTable CreateDataTableHeaders(string[] headers)
        {
            DataTable dataTable = new DataTable();

            // Add column headers
            int colIndex = 0;
            foreach (var col in headers)
            {
                if (colIndex == 0 && col == "ID")
                    dataTable.Columns.Add(col, typeof(int));
                else
                    dataTable.Columns.Add(col, typeof(string));

                colIndex++;
            }           
            return dataTable;
        }

        public static void WriteDataTableToFile(DataTable sourceTable, string path, bool includeHeaders)
        {
            if (sourceTable == null) return;

            // Ensure that file is not written with Byte Order Mark so other programs can open.
            Encoding utf8WithoutBOM = new UTF8Encoding(false);

            using (FileStream stream = File.Open(path, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                using (StreamWriter writer = new StreamWriter(stream, utf8WithoutBOM))
                {
                    // Write headers first
                    if (includeHeaders)
                    {
                        var headers = sourceTable.Columns.OfType<DataColumn>().Select(r => r.ColumnName);
                        writer.WriteLine(String.Join("\t", headers));
                    }

                    // Write data rows
                    if (sourceTable.Rows.Count > 0)
                        foreach (DataRow row in sourceTable.Rows)
                        {
                            List<string> array = new List<string>();
                            foreach (DataColumn col in sourceTable.Columns)
                            {
                                // Try to catch null values
                                string column = string.Empty;
                                if (row[col.ColumnName] == null) column = string.Empty;

                                // Make sure any date column in correct format
                               
                                column = row[col.ColumnName].ToString();
                                array.Add(column);
                            }

                            // Write row separated by tab
                            writer.WriteLine(String.Join("\t", array));
                        }
                    
                    writer.Flush();
                }
            }
        }
    }
}
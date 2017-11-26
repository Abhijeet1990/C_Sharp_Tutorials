using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RTPWebForecastService
{
    public partial class TestDownLoad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[6] { new DataColumn("Id"), new DataColumn("Name"), new DataColumn("Country"), new DataColumn("Age"), new DataColumn("Sex"), new DataColumn("NickName") });
                dt.Rows.Add(1, "John Hammond", "United States", 34, "Male", "John");
                dt.Rows.Add(2, "Mudassar Khan", "India", 34, "Male", "Muds");
                dt.Rows.Add(3, "Suzanne Mathews", "France", 34, "Female", "Suzz");
                dt.Rows.Add(4, "Robert Schidner", "Russia", 34, "Male", "Rob");
                dt.Rows.Add(5, "John Hammond", "United States", 34, "Male", "John");
                dt.Rows.Add(6, "Mudassar Khan", "India", 34, "Male", "Muds");
                dt.Rows.Add(7, "Suzanne Mathews", "France", 34, "Female", "Suzz");
                dt.Rows.Add(8, "Robert Schidner", "Russia", 34, "Male", "Rob");
                dt.Rows.Add(9, "John Hammond", "United States", 34, "Male", "John");
                dt.Rows.Add(10, "Mudassar Khan", "India", 34, "Male", "Muds");
                dt.Rows.Add(11, "Suzanne Mathews", "France", 34, "Female", "Suzz");
                dt.Rows.Add(12, "Robert Schidner", "Russia", 34, "Male", "Rob");
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void ExportTextFile(object sender, EventArgs e)
        {

            //Build the Text file data.
            string txt = string.Empty;

            foreach (TableCell cell in GridView1.HeaderRow.Cells)
            {
                //Add the Header row for Text file.
                txt += cell.Text + "\t\t";
            }

            //Add new line.
            txt += "\r\n";

            foreach (GridViewRow row in GridView1.Rows)
            {
                foreach (TableCell cell in row.Cells)
                {
                    //Add the Data rows.
                    txt += cell.Text + "\t\t";
                }

                //Add new line.
                txt += "\r\n";
            }

            //Download the Text file.
            HttpResponse Response = System.Web.HttpContext.Current.Response;
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.txt");
            Response.Charset = "";
            Response.ContentType = "text/plain";
            Response.Output.Write(txt);
            Response.Flush();
            Response.End();
        }
    }
}
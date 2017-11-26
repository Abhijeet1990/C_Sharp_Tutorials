using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
    public partial class Form2 : Form
    {
        private Rectangle r1;
        private Rectangle r2;

        public Form2()
        {
            r1.X = 10;
            r1.Y = 10;
            r1.Width = 20;
            r1.Height = 203;

            r2.X = 100;
            r2.Y = 100;
            r2.Width = 200;
            r2.Height = 300;

            System.Windows.Forms.DataVisualization.Charting.Chart chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();

            InitializeComponent();

            this.chart1.PostPaint += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ChartPaintEventArgs>(this.PostPaint);
            DataTable dt = default(DataTable);
            dt = CreateDataTable();
            string[] x = new string[dt.Rows.Count];
            int[] y = new int[dt.Rows.Count];
            //Set the DataSource property of the Chart control to the DataTabel
            chart1.DataSource = dt;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                x[i] = dt.Rows[i][0].ToString();
                y[i] = Convert.ToInt32(dt.Rows[i][2]);
            }
            chart1.Series.Add("Series1");
            chart1.Series[0].Points.DataBindXY(x, y);

            
            this.chart1.MouseWheel += new MouseEventHandler(chData_MouseWheel);
        }
        private DataTable CreateDataTable()
        {
            //Create a DataTable as the data source of the Chart control
            DataTable dt = new DataTable();

            //Add three columns to the DataTable
            dt.Columns.Add("Date");
            dt.Columns.Add("Volume1");
            dt.Columns.Add("Volume2");

            DataRow dr;

            //Add rows to the table which contains some random data for demonstration
            dr = dt.NewRow();
            dr["Date"] = "Jan";
            dr["Volume1"] = 3731;
            dr["Volume2"] = 4101;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Date"] = "Feb";
            dr["Volume1"] = 6024;
            dr["Volume2"] = 4324;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Date"] = "Mar";
            dr["Volume1"] = 4935;
            dr["Volume2"] = 2935;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Date"] = "Apr";
            dr["Volume1"] = 4466;
            dr["Volume2"] = 5644;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Date"] = "May";
            dr["Volume1"] = 5117;
            dr["Volume2"] = 5671;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Date"] = "Jun";
            dr["Volume1"] = 3546;
            dr["Volume2"] = 4646;
            dt.Rows.Add(dr);

            return dt;
        }
        private void chData_MouseWheel(object sender, MouseEventArgs e)
        {
            try
            {
                double xMin = chart1.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
                double xMax = chart1.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
                if (e.Delta < 0)
                {   //chart1.ChartAreas[0].AxisX.ScaleView.ZoomReset();
                    //chart1.ChartAreas[0].AxisY.ScaleView.ZoomReset();
                }

                if (e.Delta > 0)
                {
                    double posXStart = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) - (xMax - xMin) / 2;
                    double posXFinish = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) + (xMax - xMin) / 2;
                    chart1.ChartAreas[0].AxisX.ScaleView.Zoom(posXStart, posXFinish);
                }
            }
            catch { }
        }
        private void PostPaint(object sender, System.Windows.Forms.DataVisualization.Charting.ChartPaintEventArgs e)
        {
            e.ChartGraphics.Graphics.DrawRectangle(new Pen(Color.Red, 3), r1);
            e.ChartGraphics.Graphics.DrawRectangle(new Pen(Color.Black, 5), r2);

        }

       
    }
}

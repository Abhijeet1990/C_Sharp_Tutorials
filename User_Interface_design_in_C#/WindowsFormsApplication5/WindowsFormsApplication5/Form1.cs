using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApplication5
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            
            this.chart1.MouseWheel+= new MouseEventHandler(chData_MouseWheel);
            this.chart1.PostPaint += new EventHandler<ChartPaintEventArgs>(Chart1_PostPaint);
        }


        private void chData_MouseWheel(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Delta < 0)
                {
                    chart1.ChartAreas[0].AxisX.ScaleView.ZoomReset();
                    chart1.ChartAreas[0].AxisY.ScaleView.ZoomReset();
                }

                if (e.Delta > 0)
                {
                    double xMin = chart1.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
                    double xMax = chart1.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
                    double yMin = chart1.ChartAreas[0].AxisY.ScaleView.ViewMinimum;
                    double yMax = chart1.ChartAreas[0].AxisY.ScaleView.ViewMaximum;

                    double posXStart = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) - (xMax - xMin) / 4;
                    double posXFinish = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) + (xMax - xMin) / 4;
                    double posYStart = chart1.ChartAreas[0].AxisY.PixelPositionToValue(e.Location.Y) - (yMax - yMin) / 4;
                    double posYFinish = chart1.ChartAreas[0].AxisY.PixelPositionToValue(e.Location.Y) + (yMax - yMin) / 4;

                    chart1.ChartAreas[0].AxisX.ScaleView.Zoom(posXStart, posXFinish);
                    chart1.ChartAreas[0].AxisY.ScaleView.Zoom(posYStart, posYFinish);
                }
            }
            catch { }
        }
        void Chart1_PostPaint(object sender, ChartPaintEventArgs e)
        {
            // Make sure all series have been drawn before proceeding
            if (e.ChartElement is Series && ((Series)e.ChartElement).Name == "Series2")
            {
                Series s = e.Chart.Series[0];
                ChartGraphics cg = e.ChartGraphics;
                double max = s.Points.FindMaxByValue().YValues[0];

                // Highlight the maximum sales this year
                for (int i = 0; i < s.Points.Count; i++)
                {
                    if (s.Points[i].YValues[0] == max)
                    {
                        // Get relative coordinates of the data point
                        System.Drawing.PointF pos = System.Drawing.PointF.Empty;
                        pos.X = (float)cg.GetPositionFromAxis("ChartArea1", AxisName.X, i);
                        pos.Y = (float)cg.GetPositionFromAxis("ChartArea1", AxisName.Y, max);

                        // Convert relative coordinates to absolute coordinates.
                        pos = cg.GetAbsolutePoint(pos);

                        // Draw concentric circles at the data point
                        for (int radius = 10; radius < 40; radius += 10)
                        {
                            cg.Graphics.DrawEllipse(
                               System.Drawing.Pens.Red,
                               pos.X - radius / 2,
                               pos.Y - radius / 2,
                               radius, radius);
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
        }
    }
}

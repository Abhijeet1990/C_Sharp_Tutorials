using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphDemo
{
    public partial class GraphDemo : Form
    {
        Read rr;
        public GraphDemo()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog ff = new OpenFileDialog();
            ff.InitialDirectory = "C:\\";
            ff.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            ff.FilterIndex = 1;
            ff.RestoreDirectory = true;
            if (ff.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = ff.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            rr = null;
                            rr = new Read(myStream);
                            string[] header = rr.get_Header();
                            Console.WriteLine(header);
                            List<string> lx = new List<string>();
                            List<string> ly = new List<string>();
                            for (int i =0;i < header.Length;i++)
                            {
                                lx.Add(header[i]);
                                ly.Add(header[i]);
                                
                            }

                            xbox.DataSource = lx;
                            ybox.DataSource = ly;
                            //CLose the stream
                            myStream.Close();
                        }
                    }
                }
                catch(Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
        }

        private void btnPlot_Click(object sender, EventArgs e)
        {
            if (rr!=null)
            {
                Plot pl = new Plot(rr, xbox, ybox, chart);
            }
            else
            {
                MessageBox.Show("Error, no data to plot! please load csv file");
                return;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog ff = new SaveFileDialog();
            ff.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";
            ff.FilterIndex = 1;
            ff.RestoreDirectory = true;
            if(ff.ShowDialog()==DialogResult.OK)
            {
                if((myStream=ff.OpenFile())!=null)
                {
                    using (myStream)
                    {
                        chart.SaveImage(myStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                }
            }
        }
    }
}

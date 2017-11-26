using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicComboDG
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.comboBox1.SelectedIndexChanged +=
            new System.EventHandler(comboBox1_SelectedIndexChanged);
            //PopulateComboBox2();
            this.comboBox2.SelectedIndexChanged +=
            new System.EventHandler(comboBox2_SelectedIndexChanged);
        }
        public void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            comboBox2.Items.Clear();
            string[] simple = new string[] { "Unit 1" };
            string[] OneOneSingleShaft = new string[] { "Unit 1" };
            string[] OneOneMultipleShaft = new string[] { "Unit 1", "Unit 2" };
            string[] TwoOne = new string[] { "Unit 1", "Unit 2", "Unit 3" };
            string[] ThreeOne = new string[] { "Unit 1", "Unit 2", "Unit 3", "Unit 4" };

            if ((string)comboBox1.SelectedItem == "One")
            {
                comboBox2.Items.AddRange(simple);
            }
            else if ((string)comboBox1.SelectedItem == "Two")
            {
                comboBox2.Items.AddRange(OneOneSingleShaft);
            }
            else if ((string)comboBox1.SelectedItem == "Three")
            {
                comboBox2.Items.AddRange(OneOneMultipleShaft);
            }
            else if ((string)comboBox1.SelectedItem == "Four")
            {
                comboBox2.Items.AddRange(TwoOne);
            }
            else if ((string)comboBox1.SelectedItem == "Five")
            {
                comboBox2.Items.AddRange(ThreeOne);
            }

        }
        public void comboBox2_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if ((string)comboBox1.SelectedItem == "One")
            {
                if ((string)comboBox2.SelectedItem == "Unit 1")
                {
                    dataGridView1.Rows.Clear();
                    DataRow[] r = new DataRow[3];
                    for (int i = 0; i < r.Length; i++)
                    {
                        dataGridView1.Rows.Add(r[i]);
                    }
                    dataGridView1.Rows[0].Cells[0].Value = "GT";
                    dataGridView1.Rows[1].Cells[0].Value = "Gen";
                    dataGridView1.Rows[2].Cells[0].Value = "IC";

                }
            }
            if ((string)comboBox1.SelectedItem == "Two")
            {
                if ((string)comboBox2.SelectedItem == "Unit 1")
                {
                    dataGridView1.Rows.Clear();
                    DataRow[] r = new DataRow[6];
                    for (int i = 0; i < r.Length; i++)
                    {
                        dataGridView1.Rows.Add(r[i]);
                    }
                    dataGridView1.Rows[0].Cells[0].Value = "GT";
                    dataGridView1.Rows[1].Cells[0].Value = "Gen";
                    dataGridView1.Rows[2].Cells[0].Value = "IC";
                    dataGridView1.Rows[3].Cells[0].Value = "HRSG";
                    dataGridView1.Rows[4].Cells[0].Value = "ST";
                    dataGridView1.Rows[5].Cells[0].Value = "Cond";
                }
            }
            if ((string)comboBox1.SelectedItem == "Three")
            {
                if ((string)comboBox2.SelectedItem == "Unit 1")
                {
                    dataGridView1.Rows.Clear();
                    DataRow[] r = new DataRow[4];
                    for (int i = 0; i < r.Length; i++)
                    {
                        dataGridView1.Rows.Add(r[i]);
                    }
                    dataGridView1.Rows[0].Cells[0].Value = "GT";
                    dataGridView1.Rows[1].Cells[0].Value = "Gen";
                    dataGridView1.Rows[2].Cells[0].Value = "IC";
                    dataGridView1.Rows[3].Cells[0].Value = "HRSG";

                }
                else if ((string)comboBox2.SelectedItem == "Unit 2")
                {
                    dataGridView1.Rows.Clear();
                    DataRow[] r = new DataRow[3];
                    for (int i = 0; i < r.Length; i++)
                    {
                        dataGridView1.Rows.Add(r[i]);
                    }
                    dataGridView1.Rows[0].Cells[0].Value = "ST";
                    dataGridView1.Rows[1].Cells[0].Value = "Cond";
                    dataGridView1.Rows[2].Cells[0].Value = "Gen";

                }
            }
            if ((string)comboBox1.SelectedItem == "Four")
            {
                if ((string)comboBox2.SelectedItem == "Unit 1")
                {
                    dataGridView1.Rows.Clear();
                    DataRow[] r = new DataRow[4];
                    for (int i = 0; i < r.Length; i++)
                    {
                        dataGridView1.Rows.Add(r[i]);
                    }
                    dataGridView1.Rows[0].Cells[0].Value = "GT";
                    dataGridView1.Rows[1].Cells[0].Value = "Gen";
                    dataGridView1.Rows[2].Cells[0].Value = "IC";
                    dataGridView1.Rows[3].Cells[0].Value = "HRSG";
                }
                else if ((string)comboBox2.SelectedItem == "Unit 2")
                {
                    dataGridView1.Rows.Clear();
                    DataRow[] r = new DataRow[4];
                    for (int i = 0; i < r.Length; i++)
                    {
                        dataGridView1.Rows.Add(r[i]);
                    }
                    dataGridView1.Rows[0].Cells[0].Value = "GT";
                    dataGridView1.Rows[1].Cells[0].Value = "Gen";
                    dataGridView1.Rows[2].Cells[0].Value = "IC";
                    dataGridView1.Rows[3].Cells[0].Value = "HRSG";
                }
                else if ((string)comboBox2.SelectedItem == "Unit 3")
                {
                    dataGridView1.Rows.Clear();
                    DataRow[] r = new DataRow[3];
                    for (int i = 0; i < r.Length; i++)
                    {
                        dataGridView1.Rows.Add(r[i]);
                    }
                    dataGridView1.Rows[0].Cells[0].Value = "ST";
                    dataGridView1.Rows[1].Cells[0].Value = "Cond";
                    dataGridView1.Rows[2].Cells[0].Value = "Gen";
                }

            }
            if ((string)comboBox1.SelectedItem == "Five")
            {
                if ((string)comboBox2.SelectedItem == "Unit 1")
                {
                    dataGridView1.Rows.Clear();
                    DataRow[] r = new DataRow[4];
                    for (int i = 0; i < r.Length; i++)
                    {
                        dataGridView1.Rows.Add(r[i]);
                    }
                    dataGridView1.Rows[0].Cells[0].Value = "GT";
                    dataGridView1.Rows[1].Cells[0].Value = "Gen";
                    dataGridView1.Rows[2].Cells[0].Value = "IC";
                    dataGridView1.Rows[3].Cells[0].Value = "HRSG";
                }
                else if ((string)comboBox2.SelectedItem == "Unit 2")
                {
                    dataGridView1.Rows.Clear();
                    DataRow[] r = new DataRow[4];
                    for (int i = 0; i < r.Length; i++)
                    {
                        dataGridView1.Rows.Add(r[i]);
                    }
                    dataGridView1.Rows[0].Cells[0].Value = "GT";
                    dataGridView1.Rows[1].Cells[0].Value = "Gen";
                    dataGridView1.Rows[2].Cells[0].Value = "IC";
                    dataGridView1.Rows[3].Cells[0].Value = "HRSG";
                }
                else if ((string)comboBox2.SelectedItem == "Unit 3")
                {
                    dataGridView1.Rows.Clear();
                    DataRow[] r = new DataRow[4];
                    for (int i = 0; i < r.Length; i++)
                    {
                        dataGridView1.Rows.Add(r[i]);
                    }
                    dataGridView1.Rows[0].Cells[0].Value = "GT";
                    dataGridView1.Rows[1].Cells[0].Value = "Gen";
                    dataGridView1.Rows[2].Cells[0].Value = "IC";
                    dataGridView1.Rows[3].Cells[0].Value = "HRSG";
                }
                else if ((string)comboBox2.SelectedItem == "Unit 4")
                {
                    dataGridView1.Rows.Clear();
                    DataRow[] r = new DataRow[3];
                    for (int i = 0; i < r.Length; i++)
                    {
                        dataGridView1.Rows.Add(r[i]);
                    }
                    dataGridView1.Rows[0].Cells[0].Value = "ST";
                    dataGridView1.Rows[1].Cells[0].Value = "Cond";
                    dataGridView1.Rows[2].Cells[0].Value = "Gen";
                }

            }
        }
    }
}

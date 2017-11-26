using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PlantSettingForm;

namespace PlantSettingForm
{
    public partial class Block : Form
    {
        public Block()
        {
            InitializeComponent();
        }
        public void populateIcon(int rowCount) {
            //Image gen = Image.FromFile("C:\\Users\\Abhijeet\\Documents\\visual studio 2015\\Projects\\PlantSettingForm\\PlantSettingForm\\Resources\\gen.ico");
            //Image gt = Image.FromFile("C:\\Users\\Abhijeet\\Documents\\visual studio 2015\\Projects\\PlantSettingForm\\PlantSettingForm\\Resources\\GT.ico");
            //Image hrsg = Image.FromFile("C:\\Users\\Abhijeet\\Documents\\visual studio 2015\\Projects\\PlantSettingForm\\PlantSettingForm\\Resources\\HRSG.ico");
            //Image st = Image.FromFile("C:\\Users\\Abhijeet\\Documents\\visual studio 2015\\Projects\\PlantSettingForm\\PlantSettingForm\\Resources\\ST.ico");
            //Image ic = Image.FromFile("C:\\Users\\Abhijeet\\Documents\\visual studio 2015\\Projects\\PlantSettingForm\\PlantSettingForm\\Resources\\IC.ico");
            //Image cond = Image.FromFile("C:\\Users\\Abhijeet\\Documents\\visual studio 2015\\Projects\\PlantSettingForm\\PlantSettingForm\\Resources\\cond.ico");
            //DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            //for (int i =0; i< rowCount;i++)

            //{

            //    if (dataGridView1.Rows[i].Cells[0].ToString()== "GT")
            //    {
            //        dataGridView1.Rows[i].Cells[1].Value = Bitmap.FromFile(gt);
                    
            //    }
            //    else if (dataGridView1.Rows[i].Cells[0].ToString() == "ST")
            //    {
            //        dataGridView1.Rows[i].Cells[1].Value = Bitmap.FromFile(st);
            //    }
            //    else if (dataGridView1.Rows[i].Cells[0].ToString() == "HRSG")
            //    {
            //        dataGridView1.Rows[i].Cells[1].Value = Bitmap.FromFile(hrsg);
            //    }
            //    else if (dataGridView1.Rows[i].Cells[0].ToString() == "Gen")
            //    {
            //        dataGridView1.Rows[i].Cells[1].Value = Bitmap.FromFile(gen);
            //    }
            //    else if (dataGridView1.Rows[i].Cells[0].ToString() == "IC")
            //    {
            //        dataGridView1.Rows[i].Cells[1].Value = Bitmap.FromFile(ic);
            //    }
            //    else if (dataGridView1.Rows[i].Cells[0].ToString() == "Cond")
            //    {
            //        dataGridView1.Rows[i].Cells[1].Value = Bitmap.FromFile(cond);
            //    }
            //}


        }

        public void populateObjectType()
        {
            DataGridViewComboBoxColumn cboBoxType = (DataGridViewComboBoxColumn)dataGridView1.Columns["Type"];
            for (int i = 0; i < dataGridView1.Rows.Count; i++)

            {
                if (dataGridView1.Rows[i].Cells[0].ToString() == "GT")
                {
                    cboBoxType.DataSource = Enum.GetValues(typeof(GasTurbineType));
                }
                else if(dataGridView1.Rows[i].Cells[0].ToString() == "ST")
                {
                    cboBoxType.DataSource = Enum.GetValues(typeof(SteamTurbineType));
                }
                else if (dataGridView1.Rows[i].Cells[0].ToString() == "Gen")
                {
                    cboBoxType.DataSource = Enum.GetValues(typeof(GeneratorType));
                }
                else if (dataGridView1.Rows[i].Cells[0].ToString() == "HRSG")
                {
                    cboBoxType.DataSource = Enum.GetValues(typeof(HRSGType));
                }
                else if (dataGridView1.Rows[i].Cells[0].ToString() == "IC")
                {
                    cboBoxType.DataSource = Enum.GetValues(typeof(InletCoolingType));
                }
                else if (dataGridView1.Rows[i].Cells[0].ToString() == "Cond")
                {
                    cboBoxType.DataSource = Enum.GetValues(typeof(CondenserType));
                }
            }
            

        }
        public void populateConfigure()
        {
            
            for (int i = 0; i < dataGridView1.Rows.Count; i++)

            {
                DataGridViewButtonCell b = new DataGridViewButtonCell();
                if (dataGridView1.Rows[i].Cells[0].ToString() == "GT")
                {
                    dataGridView1.Rows[i].Cells[5] = b;
                    b.ToolTipText = "Configure GT";
                }
                else if (dataGridView1.Rows[i].Cells[0].ToString() == "ST")
                {
                    dataGridView1.Rows[i].Cells[5] = b;
                    b.ToolTipText = "Configure ST";
                }
                else if (dataGridView1.Rows[i].Cells[0].ToString() == "HRSG")
                {
                    dataGridView1.Rows[i].Cells[5] = b;
                    b.ToolTipText = "Configure HRSG";
                }
                else if (dataGridView1.Rows[i].Cells[0].ToString() == "Gen")
                {
                    dataGridView1.Rows[i].Cells[5] = b;
                    b.ToolTipText = "Configure Gen";
                }
                else if (dataGridView1.Rows[i].Cells[0].ToString() == "IC")
                {
                    dataGridView1.Rows[i].Cells[5] = b;
                    b.ToolTipText = "Configure IC";
                }
                else if (dataGridView1.Rows[i].Cells[0].ToString() == "Cond")
                {
                    dataGridView1.Rows[i].Cells[5] = b;
                    b.ToolTipText = "Configure Cond";
                }


            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //code where 3 on 1 image is clicked
            //3 GT,3 Condenser,3 inlet cooling,3 HRSG,1 ST, 4 generator
            DataRow[] r = new DataRow[17];
            dataGridView1.Rows.Add(r[0]);
            dataGridView1.Rows.Add(r[1]);
            dataGridView1.Rows.Add(r[2]);
            dataGridView1.Rows.Add(r[3]);
            dataGridView1.Rows.Add(r[4]);
            dataGridView1.Rows.Add(r[5]);
            dataGridView1.Rows.Add(r[6]);
            dataGridView1.Rows.Add(r[7]);
            dataGridView1.Rows.Add(r[8]);
            dataGridView1.Rows.Add(r[9]);
            dataGridView1.Rows.Add(r[10]);
            dataGridView1.Rows.Add(r[11]);
            dataGridView1.Rows.Add(r[12]);
            dataGridView1.Rows.Add(r[13]);
            dataGridView1.Rows.Add(r[14]);
            dataGridView1.Rows.Add(r[15]);
            dataGridView1.Rows.Add(r[16]);

            dataGridView1.Rows[0].Cells[0].Value = "GT";
            dataGridView1.Rows[1].Cells[0].Value = "GT";
            dataGridView1.Rows[2].Cells[0].Value = "GT";
            dataGridView1.Rows[3].Cells[0].Value = "Gen";
            dataGridView1.Rows[4].Cells[0].Value = "Gen";
            dataGridView1.Rows[5].Cells[0].Value = "Gen";
            dataGridView1.Rows[6].Cells[0].Value = "Gen";
            dataGridView1.Rows[7].Cells[0].Value = "HRSG";
            dataGridView1.Rows[8].Cells[0].Value = "HRSG";
            dataGridView1.Rows[9].Cells[0].Value = "HRSG";
            dataGridView1.Rows[10].Cells[0].Value = "ST";
            dataGridView1.Rows[11].Cells[0].Value = "IC";
            dataGridView1.Rows[12].Cells[0].Value = "IC";
            dataGridView1.Rows[13].Cells[0].Value = "IC";
            dataGridView1.Rows[14].Cells[0].Value = "Cond";
            dataGridView1.Rows[15].Cells[0].Value = "Cond";
            dataGridView1.Rows[16].Cells[0].Value = "Cond";
            populateIcon(17);
            populateObjectType();
            populateConfigure();
            //Alias,Trains and Type are populated from the mappings
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //code where 1 on 1 image is clicked 
            //one GT,one Condenser,one inlet cooling,one HRSG,one ST, two generator
            DataRow[] r = new DataRow[7];
            dataGridView1.Rows.Add(r[0]);
            dataGridView1.Rows.Add(r[1]);
            dataGridView1.Rows.Add(r[2]);
            dataGridView1.Rows.Add(r[3]);
            dataGridView1.Rows.Add(r[4]);
            dataGridView1.Rows.Add(r[5]);
            dataGridView1.Rows.Add(r[6]);
            dataGridView1.Rows[0].Cells[0].Value = "GT";
            dataGridView1.Rows[1].Cells[0].Value = "Gen";
            dataGridView1.Rows[2].Cells[0].Value = "Gen";
            dataGridView1.Rows[3].Cells[0].Value = "HRSG";
            dataGridView1.Rows[4].Cells[0].Value = "ST";
            dataGridView1.Rows[5].Cells[0].Value = "IC";
            dataGridView1.Rows[6].Cells[0].Value = "Cond";
            populateIcon(7);
            populateObjectType();
            populateConfigure();

            //Alias,Trains and Type are populated from the mappings
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //code where 2 on 1 image is clicked
            //2 GT,2 Condenser,2 inlet cooling,2 HRSG,1 ST, 3 generator
            DataRow[] r = new DataRow[12];
            dataGridView1.Rows.Add(r[0]);
            dataGridView1.Rows.Add(r[1]);
            dataGridView1.Rows.Add(r[2]);
            dataGridView1.Rows.Add(r[3]);
            dataGridView1.Rows.Add(r[4]);
            dataGridView1.Rows.Add(r[5]);
            dataGridView1.Rows.Add(r[6]);
            dataGridView1.Rows.Add(r[7]);
            dataGridView1.Rows.Add(r[8]);
            dataGridView1.Rows.Add(r[9]);
            dataGridView1.Rows.Add(r[10]);
            dataGridView1.Rows.Add(r[11]);
            
            dataGridView1.Rows[0].Cells[0].Value = "GT";
            dataGridView1.Rows[1].Cells[0].Value = "GT";
            dataGridView1.Rows[2].Cells[0].Value = "Gen";
            dataGridView1.Rows[3].Cells[0].Value = "Gen";
            dataGridView1.Rows[4].Cells[0].Value = "Gen";
            dataGridView1.Rows[5].Cells[0].Value = "HRSG";
            dataGridView1.Rows[6].Cells[0].Value = "HRSG";
            dataGridView1.Rows[7].Cells[0].Value = "ST";
            dataGridView1.Rows[8].Cells[0].Value = "IC";
            dataGridView1.Rows[9].Cells[0].Value = "IC";
            dataGridView1.Rows[10].Cells[0].Value = "Cond";
            dataGridView1.Rows[11].Cells[0].Value = "Cond";
            populateIcon(12);
            populateObjectType();
            populateConfigure();
            //Alias,Trains and Type are populated from the mappings
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //code where a single Gas turbine block is selected
            string gt = @"C:\Users\Abhijeet\Documents\visual studio 2015\Projects\PlantSettingForm\PlantSettingForm\Resources\GT.ico";
            //one GT,one condenser,one inlet cooling,one generator
            DataRow[] r = new DataRow[4];
            dataGridView1.Rows.Add(r[0]);
            dataGridView1.Rows.Add(r[1]);
            dataGridView1.Rows.Add(r[2]);
            dataGridView1.Rows.Add(r[3]);
            dataGridView1.Rows[0].Cells[0].Value = "GT";
            dataGridView1.Rows[1].Cells[0].Value = "Gen";
            dataGridView1.Rows[2].Cells[0].Value = "IC";
            dataGridView1.Rows[3].Cells[0].Value = "Cond";
            //dataGridView1.Rows[0].Cells[1].Value = Icon.ExtractAssociatedIcon(gt).ToBitmap();
            //Icon treeIcon = new Icon(this.GetType(), Properties.Resources.("GT.ico"));
            //DataGridViewImageColumn iconColumn = new DataGridViewImageColumn();
            //iconColumn.Image = treeIcon.ToBitmap();
            //iconColumn.Name = "Tree";
            //iconColumn.HeaderText = "Nice tree";
            //dataGridView1.Columns.Insert(1, iconColumn);
            populateIcon(4);
            populateObjectType();
            populateConfigure();
            //Alias,Trains and Type are populated from the mappings
        }
    }
}

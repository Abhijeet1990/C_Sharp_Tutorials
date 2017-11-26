using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlantSettingForm
{
    public partial class TagSelectionForm : Form
    {
        public TagSelectionForm()
        {
            InitializeComponent();
        }
        public void populateDataGrid()
        {
            //fill the Tags by connecting to the PI server
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "Tag Name";
            DataGridViewCheckBoxColumn chkTags = new DataGridViewCheckBoxColumn();
            dataGridView1.Columns.Add(chkTags);
            chkTags.HeaderText = "Check Tags";
            chkTags.Name = "chk";

            //Populate the content of the 1st column from the Excel file or the PI Server
            /* if the connection with the PI server is succesfully built then PI
             * or go for the performance excel file to get the Tags
             */

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int chkBoxCount = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if ((bool)dataGridView1.Rows[i].Cells[1].Value == true)
                {
                    chkBoxCount++;
                }
            }
            if (chkBoxCount == 0)
            {
                MessageBox.Show("Select a Tag");
            }
            else if(chkBoxCount>1)
            {
                MessageBox.Show("Select Only one Tag");
            }
            else
            {
                VariableSettingForm vsf = new VariableSettingForm();
                this.Close();
                vsf.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<object> li = new List<Object>();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if ((bool)dataGridView1.Rows[i].Cells[1].Value == true)
                {
                    li.Add(dataGridView1.Rows[i].Cells[0].Value);
                }
            }
        }
    }
}

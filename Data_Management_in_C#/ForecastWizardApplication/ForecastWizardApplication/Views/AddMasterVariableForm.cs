using ForecastAppDatabase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ForecastWizardApplication.Infrastructure;

namespace ForecastWizardApplication.Views
{
    public partial class AddMasterVariableForm : Form
    {
        public AddMasterVariableForm()
        {
            InitializeComponent();
            DataTable d = new DataTable();
            d = HandleSqlQueries.HandleQueries("select * from ObjectGroups");
            for (int i = 0; i < d.Rows.Count; i++)
            {
                this.categoryComboBox.Items.Add(d.Rows[i][1].ToString());
            }
            
        }

        private void saveAddVariableButton_Click(object sender, EventArgs e)
        {
            // first check if all the fields are properly filled
            if (string.IsNullOrEmpty(addNameTextBox.Text)) MessageBox.Show("Fill the name");
            if (string.IsNullOrEmpty(addDescriptionTextBox.Text)) MessageBox.Show("Fill the Dsescription");
            else if (addDescriptionTextBox.Text.Length >= 50) MessageBox.Show("Message Length must be less than 50 characters");
            if (string.IsNullOrEmpty(selectPlantObject.SelectedItem.ToString())) MessageBox.Show("User must select a Plant Object Type");
            if (string.IsNullOrEmpty(categoryComboBox.SelectedItem.ToString())) MessageBox.Show("User must select the category");

            var search = searchTextBox.Text;
            if (string.IsNullOrEmpty(search)) search = "";

            // insert into the VariableMaster Table
            using (var db = new WizardDatabaseEntities())
            {
                var name = addNameTextBox.Text;
                var description = addDescriptionTextBox.Text;
                var plantObjectType = selectPlantObject.SelectedIndex-1;
                var category = categoryComboBox.SelectedIndex+1;
                var VariableMaster = new VariableMaster
                {
                    Name=name,
                    Description=description,
                    PlantObjectTypeID=plantObjectType,
                    ObjectGroupID=category,
                    CharSearch=search
                };
                db.VariableMasters.Add(VariableMaster);
                db.SaveChanges();
               
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

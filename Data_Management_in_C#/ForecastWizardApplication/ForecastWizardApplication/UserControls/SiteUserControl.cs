using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ForecastWizardApplication.Infrastructure;
using ForecastWizardApplication.UserControls;
using System.Data.SqlClient;

namespace ForecastWizardApplication
{
    public partial class SiteUserControl : UserControl
    {
        public SiteUserControl()
        {
            InitializeComponent();
            if (SiteData._status == "Exist")
                PopulateData();
            PopulateTags();
        }

        public void PopulateData()
        {
            textBoxLongName.Text = SiteData._name.ToString();
            textBoxShortName.Text = SiteData._acronym.ToString();
            textBoxLongitude.Text = SiteData._longitude.ToString();
            textBoxLatitude.Text = SiteData._latitude.ToString();
            textBoxElevation.Text = SiteData._elevation.ToString();
            comboBoxInterval.Text = Convert.ToString(SiteData._comboBoxInterval);
            comboBoxDuration.Text = Convert.ToString(SiteData._comboBoxDuration);
            comboBoxArchiveInterval.Text = Convert.ToString(SiteData._comboBoxArchiveInterval);
            comboBoxArchiveDuration.Text = Convert.ToString(SiteData._comboBoxArchiveDuration);
            comboBoxGridFrequency.Text = Convert.ToString(SiteData._comboBoxGridFrequency);
            comboBoxHeatRateUnits.Text = Convert.ToString(SiteData._comboBoxHeatRateUnits);
            comboBoxHeatRateCalculation.Text = Convert.ToString(SiteData._comboBoxHeatRateCalculation);
        }


        //The group Box are dynamically created at Run time.And the user controls inside it are also dynamically created at run time
        public void PopulateTags()
        {
            DataTable data = new DataTable();
            data = HandleSqlQueries.HandleQueries("SELECT Name,ObjectGroupID,Mandatory FROM PlantMasterVariable WHERE PlantObjectTypeID=1");

            if (data.Rows.Count != 0)
            {
                var x = (from r in data.AsEnumerable()
                         select r[1]).Distinct().ToList();

                List<int> objectTypeIDList = new List<int>();
                foreach (var id in x)
                {
                    GroupBox g = new GroupBox();
                    DataTable d = new DataTable();
                    d = HandleSqlQueries.HandleQueries(String.Format("select Name from ObjectGroups where ObjectGroupID = {0}", id));
                    g.Text = d.Rows[0][0].ToString() + " Tags";
                    g.AutoSize = true;

                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(data.Rows[i][1]) == Convert.ToInt32(id))
                        {
                            GetPITagUserControl pi = new GetPITagUserControl();
                            pi.VariableMasterLabel.Text = data.Rows[i][0].ToString();
                            if (data.Rows[i][2].ToString() == "M")
                            {
                                pi.VariableMasterLabel.Font = new Font(pi.VariableMasterLabel.Font, System.Drawing.FontStyle.Bold);
                            }
                            g.Controls.Add(pi);
                            pi.Location = new Point(10, 25 * (i + 1));
                        }
                    }
                    SiteTagGroupBox.Controls.Add(g);
                    g.Location = new Point(10, 20);

                }
            }


        }
    }
}

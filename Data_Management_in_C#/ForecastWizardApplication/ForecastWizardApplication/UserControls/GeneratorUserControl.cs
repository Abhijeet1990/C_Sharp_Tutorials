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
using System.Data.SqlClient;
using ForecastWizardApplication.UserControls;

namespace ForecastWizardApplication.UserControls
{
    public partial class GeneratorUserControl : UserControl
    {
        public GeneratorUserControl()
        {
            InitializeComponent();
            if (GeneratorData._status == "Exist")
                PopulateData();
            //PopulateTags();
        }
        public GeneratorUserControl(int TrainID, int BlockID)
        {
            InitializeComponent();
            if (GeneratorData._status == "Exist")
                PopulateData();
            PopulateTags(TrainID, BlockID);
        }

        public void PopulateData()
        {
            textBoxLongName.Text = GeneratorData._name.ToString();
            textBoxShortName.Text = GeneratorData._alias.ToString();

        }

        public void PopulateTags(int TrainID, int BlockID)
        {
            DataTable data = new DataTable();
            data = HandleSqlQueries.HandleQueries("SELECT Alias,ObjectGroupID,Mandatory FROM PossiblePlantMasterVariable WHERE PlantObjectTypeID=3 and TrainID=" + TrainID.ToString() + " and BlockID=" + BlockID.ToString());

            int y = 0;
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

                for (int i = 0, j = 0; i < data.Rows.Count; i++)
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
                        pi.Location = new Point(10, 25 * (j + 1));
                        j++;
                    }
                }
                GeneratorTagsGroupBox.Controls.Add(g);
                if (x.IndexOf(id) == 0)
                    g.Location = new Point(10, 20);
                else
                    g.Location = new Point(10, y);

                y = g.Bottom;

            }
        }

    }
}

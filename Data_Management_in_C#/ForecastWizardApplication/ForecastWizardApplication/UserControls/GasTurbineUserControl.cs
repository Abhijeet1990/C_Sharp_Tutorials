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
using ForecastWizardApplication.Views;

namespace ForecastWizardApplication.UserControls
{
    public partial class GasTurbineUserControl : UserControl
    {
        public GasTurbineUserControl()
        {
            InitializeComponent();
            if (GasTurbineData._status == "Exist")
                PopulateData();
            //PopulateGroups(TrainID);
        }
        public GasTurbineUserControl(int TrainID, int BlockID)
        {
            InitializeComponent();
            if (GasTurbineData._status == "Exist")
                PopulateData();
            PopulateGroups(TrainID, BlockID);
        }

        public void PopulateData()
        {
            if (GasTurbineData._name != null)
            {
                txtGasTurbineLongName.Text = GasTurbineData._name.ToString();
                txtGasTurbineShortName.Text = GasTurbineData._acronym.ToString();
            }
        }

        private void onClickEvent(object sender, EventArgs e)
        {
            //get the siteID from the 
            LookUpTableForm form = new LookUpTableForm(27,345,4,7);
            form.Show();
        }

        private void GroupBox_OnDoubleClick(object sender, EventArgs e)
        {
            GroupBox g = (GroupBox)sender;
            g.ForeColor = Color.Crimson;
            g.BackColor = Color.Cornsilk;
            //if (g.Enabled == true) g.Enabled = false;
            //else g.Enabled = true;
        }

        public void PopulateGroups(int TrainID, int BlockID)
        {
            
            //Populate Gas Turbine Attributes based on the selection of Block Enhancement

            //Extract the list of Block Enhancement associated with the Block ID
            DataTable BlockWiseEnhancement = new DataTable();
            BlockWiseEnhancement = HandleSqlQueries.HandleQueries("SELECT BlockID, BlockEnhancementTypeID FROM BlockWiseEnhancementSelection WHERE BlockID = " + BlockID.ToString());

            List<int> BlockEnhancementLists = new List<int>();
            for (int i = 0; i < BlockWiseEnhancement.Rows.Count; i++)
            {
                BlockEnhancementLists.Add((int)BlockWiseEnhancement.Rows[i][1]);
            }

            DataTable data4 = new DataTable();
            data4 = HandleSqlQueries.HandleQueries("SELECT * FROM AttributeMaster WHERE PlantObjectTypeID=4");

            var groups = (from r in data4.AsEnumerable()
                     select r[10]).Distinct().ToList();
            int j;
            int yCoordinate = 0;
            int count = 0;
            foreach (var id in groups)
            {
                GroupBox g = new GroupBox();
                DataTable d = new DataTable();
                d = HandleSqlQueries.HandleQueries(String.Format("select Name from ObjectGroups where ObjectGroupID = {0}", id));
                g.Text = d.Rows[0][0].ToString();
                g.AutoSize = true;
                g.DoubleClick += GroupBox_OnDoubleClick;

                j = 0;
                for (int i = 0; i < data4.Rows.Count; i++)
                {
                    if (Convert.ToInt32(data4.Rows[i][10]) == Convert.ToInt32(id) && BlockEnhancementLists.Contains(Convert.ToInt32(data4.Rows[i][5])))
                    {
                        j++;
                        DynamicUC uc = new DynamicUC();
                        Label lb = new Label();
                        lb.Location = new Point(20, 5);
                        lb.Text = data4.Rows[i][3].ToString();
                        lb.AutoSize = true;

                        TextBox tb = new TextBox();
                        tb.Location = new Point(lb.Right + 130, 5);
                        ComboBox cb = new ComboBox();
                        cb.Location = new Point(tb.Right, 5);

                        if (data4.Rows[i][10].ToString() != "NULL")
                        {
                            List<string> cbList = new List<string>();
                            cbList = data4.Rows[i][11].ToString().Split(',').ToList();
                            foreach (var item in cbList)
                            {
                                cb.Items.Add(item);
                            }
                        }
                        Button btn = new Button();
                        btn.Location = new Point(cb.Right, 5);
                        btn.Click += onClickEvent;
                        //MessageBox.Show(data.Rows[i][6].ToString());

                        uc.Controls.Add(lb);
                        if (data4.Rows[i][6].ToString() == "1") uc.Controls.Add(tb);
                        if (data4.Rows[i][7].ToString() == "1") uc.Controls.Add(cb);
                        if (data4.Rows[i][8].ToString() == "1") uc.Controls.Add(btn);
                        uc.Location = new Point(20, 25 * (j + 1));
                        g.Controls.Add(uc);
                    }
                }
                if (g.HasChildren)
                {
                    count++;
                    GasTurbineAttributeGroupBox.Controls.Add(g);
                    if (count == 1)
                        g.Location = new Point(10, nameGroupBox.Bottom+5);
                    else
                        g.Location = new Point(10, yCoordinate);
                    
                    yCoordinate = g.Bottom;
                }
            }

            //Populate Gas Turbine Tags
            

            this.GasTurbineTagsGroupBox.Location = new Point(14, this.GasTurbineAttributeGroupBox.Bottom+5);
            DataTable data2 = new DataTable();
            data2 = HandleSqlQueries.HandleQueries("SELECT Alias,ObjectGroupID,Mandatory FROM PossiblePlantMasterVariable WHERE PlantObjectTypeID=4 and TrainID=" + TrainID.ToString() + " and BlockID=" + BlockID.ToString());

            int y = 0;
            var x = (from r in data2.AsEnumerable()
                     select r[1]).Distinct().ToList();

            List<int> objectTypeIDList = new List<int>();
            foreach (var id in x)
            {
                GroupBox g = new GroupBox();
                DataTable d = new DataTable();
                d = HandleSqlQueries.HandleQueries(String.Format("select Name from ObjectGroups where ObjectGroupID = {0}", id));
                g.Text = d.Rows[0][0].ToString() + " Tags";
                g.AutoSize = true;

                for (int i = 0, k = 0; i < data2.Rows.Count; i++)
                {
                    if (Convert.ToInt32(data2.Rows[i][1]) == Convert.ToInt32(id))
                    {

                        GetPITagUserControl pi = new GetPITagUserControl();
                        pi.VariableMasterLabel.Text = data2.Rows[i][0].ToString();
                        if (data2.Rows[i][2].ToString() == "M")
                        {
                            pi.VariableMasterLabel.Font = new Font(pi.VariableMasterLabel.Font, System.Drawing.FontStyle.Bold);
                        }
                        g.Controls.Add(pi);
                        pi.Location = new Point(10, 25 * (k + 1));
                        k++;
                    }
                }
                GasTurbineTagsGroupBox.Controls.Add(g);
                if (x.IndexOf(id) == 0)
                    g.Location = new Point(10, 20);
                else
                    g.Location = new Point(10, y);

                y = g.Bottom;

            }

        }
    }
}

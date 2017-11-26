using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeViewApproach
{
    public partial class Form1 : Form
    {
        public int[] clickCount = new int[10] {0,0,0,0,0,0,0,0,0,0};
        public Form1()
        {
            InitializeComponent();
            System.Collections.ObjectModel.ReadOnlyCollection<TimeZoneInfo> timezoneInfo;
            timezoneInfo = TimeZoneInfo.GetSystemTimeZones();
            TimezoneComboBox.DataSource = timezoneInfo;
        }

        //public void createTabControl(int x)
        //{
        //    TabControl[] BlockTabControl = new TabControl[4];
        //    for (int i = 0; i < x; i++)
        //    {
        //        MessageBox.Show(x.ToString());
        //        BlockTabControl[i].Name = "Block";
        //        TabPage ConfigureTP = new TabPage();
        //        TabPage ForecastTP = new TabPage();
        //        TabPage VariableTP = new TabPage();
        //        ConfigureTP.Text = "Configure";
        //        ConfigureTP.Name = "ConfigureTabPage";
        //        VariableTP.Text = "Variable";
        //        VariableTP.Name = "VariableTabPage";
        //        ForecastTP.Text = "Forecast";
        //        ForecastTP.Name = "ForecastTabPage";
        //    }
        //}

        public void WizardTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            
            for (int i = 1; i < WizardTree.SelectedNode.GetNodeCount(false)+1; i++)
            {
                if (e.Node.Name == i.ToString())
                {
                    clickCount[i]++;
                    if (clickCount[i] < 2)
                    {
                        string title = "Block" + i.ToString();
                        TabPage BlockTabPage = new TabPage(title);
                        BlockConfigure bc = new BlockConfigure();
                        BlockTabPage.Controls.Add(bc);

                        SiteTabControl.TabPages.Add(BlockTabPage);
                        SiteTabControl.SelectedIndex = i;
                    }
                    SiteTabControl.SelectedIndex = i;
                }
            }
           
        }

        private void AddSiteButton_Click(object sender, EventArgs e)
        {
            //WizardTree.Nodes[0].Nodes.Clear();
            //WizardTree.Nodes[0].Text = SiteNameTextBox.Text;
            
            //for (int i = 1; i < BlockCountComboBox.SelectedIndex + 2; i++)
            //{
            //    TreeNode child = new TreeNode();
            //    string x = "Block";
            //    x += i;
            //    child.Text = x;
            //    child.Name = i.ToString();
            //    WizardTree.Nodes[0].Nodes.Add(child);
            //    WizardTree.Nodes[0].Expand();


            //}
            
            using (var db = new RealTimePowerContext())
            {
                var name = SiteNameTextBox.Text;
                var acronym = SiteAcronymTextBox.Text;
                var location = LocationTextBox.Text;
                var latitude = float.Parse(LatitudeTextBox.Text);
                var longitude = float.Parse(LongitudeTextBox.Text);
                var elevation = float.Parse(ElevationTextBox.Text);
                var timezone = TimezoneComboBox.SelectedText;
                bool useMetric = UseMetricUnitsCheckBox.Checked;
                var Site = new Site
                {
                    Acronym = acronym,
                    Name = name,
                    Location = location,
                    Latitude = latitude,
                    Longitude = longitude,
                    Elevation = elevation,
                    Timezone = timezone,
                    UseMetricUnits = useMetric
                };
                db.Sites.Add(Site);
                db.SaveChanges();
                //var query = from a in db.Sites
                //            orderby a.Name
                //            select a.SiteID;
                //foreach (var item in query)
                //{
                //    for (int i = 0; i < BlockCountComboBox.SelectedIndex + 2; i++)
                //    {
                //        var Block = new Block { SiteID = item };
                //        db.Blocks.Add(Block);
                //        db.SaveChanges();
                //    }
                //}
            }
        }

        private void BlockCountComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            WizardTree.Nodes[0].Nodes.Clear();

            //MessageBox.Show(WizardTree.Nodes.Count.ToString());
            //MessageBox.Show(WizardTree.Nodes[0].Name);
            for (int i = 1; i < BlockCountComboBox.SelectedIndex + 2; i++)
            {
                TreeNode child = new TreeNode();
                string x = "Block";
                x += i;
                child.Text = x;
                child.Name = i.ToString();
                WizardTree.Nodes[0].Nodes.Add(child);
                WizardTree.Nodes[0].Expand();
                TreeNode Configure = new TreeNode();
                TreeNode Forecast = new TreeNode();
                TreeNode Variable = new TreeNode();
                Configure.Text = "Configure";
                Configure.Name = "Configure";
                Variable.Text = "Variable";
                Variable.Name = "Variable";
                Forecast.Text = "Forecast";
                Forecast.Name = "Forecast";
                child.Nodes.Add(Configure);
                child.Nodes.Add(Forecast);
                child.Nodes.Add(Variable);


            }
            //createTabControl(BlockCountComboBox.SelectedIndex + 1);
            //TabControl[] BlockTabControl = new TabControl[BlockCountComboBox.SelectedIndex + 1];
        }
    }
    
}

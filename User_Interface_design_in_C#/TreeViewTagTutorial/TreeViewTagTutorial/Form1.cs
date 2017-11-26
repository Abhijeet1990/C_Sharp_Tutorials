using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeViewTagTutorial
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            System.Collections.ObjectModel.ReadOnlyCollection<TimeZoneInfo> timezoneInfo;
            timezoneInfo = TimeZoneInfo.GetSystemTimeZones();
            TimezoneComboBox.DataSource = timezoneInfo;

            //Site s = new TreeViewTagTutorial.Site();
            //s.Name = SiteNameTextBox.Text;
            //s.Acronym = SiteAcronymTextBox.Text;
            //s.Location = SiteLocationTextBox.Text;
            //s.Latitude = float.Parse(SiteLatitudeTextBox.Text);
            //s.Longitude = float.Parse(SiteLongitudeTextBox.Text);
            //s.Elevation = float.Parse(SiteElevationTextBox.Text);
            //s.Timezone = TimezoneComboBox.SelectedText;
            //s.UseMetricUnits = UseMetricUnitsCheckBox.Checked;
        }

        private void AddSiteButton_Click(object sender, EventArgs e)
        {
            
            TreeNode t = new TreeNode(SiteNameTextBox.Text);

            t.Tag = new Site
            {
                Name = SiteNameTextBox.Text,
                Acronym = SiteAcronymTextBox.Text,
                Location = SiteLocationTextBox.Text,
                Latitude = float.Parse(SiteLatitudeTextBox.Text),
                Longitude = float.Parse(SiteLongitudeTextBox.Text),
                Elevation = float.Parse(SiteElevationTextBox.Text),
                //Timezone = TimezoneComboBox.SelectedText,
                UseMetricUnits = UseMetricUnitsCheckBox.Checked,
                BlockCount = (int)BlockCountComboBox.SelectedIndex

        };
            

            TraverseTree.Nodes.Add(t);
            
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            using (var db = new RealTimePowerEntities())
            {
                var name = SiteNameTextBox.Text;
                var acronym = SiteAcronymTextBox.Text;
                var location = SiteLocationTextBox.Text;
                var latitude = float.Parse(SiteLatitudeTextBox.Text);
                var longitude = float.Parse(SiteLongitudeTextBox.Text);
                var elevation = float.Parse(SiteElevationTextBox.Text);
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

            }
        }

        private void TraverseTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var tag = e.Node.Tag;
            if (tag == null || !(tag is Site)) return;

            var tagObject = (Site)tag;
            SiteNameTextBox.Text = tagObject.Name.ToString();
            SiteAcronymTextBox.Text = tagObject.Acronym.ToString();
            SiteElevationTextBox.Text = tagObject.Elevation.ToString();
            SiteLatitudeTextBox.Text = tagObject.Latitude.ToString();
            SiteLocationTextBox.Text = tagObject.Latitude.ToString();
            SiteLongitudeTextBox.Text = tagObject.Latitude.ToString();
            BlockCountComboBox.SelectedIndex = tagObject.BlockCount;
            //MessageBox.Show(tagObject.Acronym.ToString());
        }
    }
}

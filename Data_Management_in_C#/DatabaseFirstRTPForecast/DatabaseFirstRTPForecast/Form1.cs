using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseFirstRTPForecast
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            System.Collections.ObjectModel.ReadOnlyCollection<TimeZoneInfo> timezoneInfo;
            timezoneInfo = TimeZoneInfo.GetSystemTimeZones();
            SIteTimezoneComboBox.DataSource = timezoneInfo;
        }

        private void AddSiteButton_Click(object sender, EventArgs e)
        {
            using (var db = new RealTimePowerEntities())
            {
                var name = SiteNameTextBox.Text;
                var acronym = SiteAcronymTextBox.Text;
                var location = SiteLocationTextBox.Text;
                var latitude = float.Parse(SiteLatitudeTextBox.Text);
                var longitude = float.Parse(SiteLongitudeTextBox.Text);
                var elevation = float.Parse(SiteElevationTextBox.Text);
                var timezone = SIteTimezoneComboBox.SelectedText;
                bool useMetric = UseMetricCheckBox.Checked;
                var Site = new Site { Acronym =acronym,Name=name,Location=location,
                    Latitude =latitude,Longitude=longitude,Elevation=elevation,
                Timezone=timezone,UseMetricUnits=useMetric};
                db.Sites.Add(Site);
                db.SaveChanges();
                var query = from a in db.Sites
                            orderby a.Name
                            select a.Name;
                foreach(var item in query)
                {
                    MessageBox.Show(item);
                }
            }
        }
    }
}

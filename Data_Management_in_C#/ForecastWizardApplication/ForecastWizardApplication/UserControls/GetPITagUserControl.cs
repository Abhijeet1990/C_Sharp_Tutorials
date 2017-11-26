using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ForecastWizardApplication.Views;
using System.Data.SqlClient;

namespace ForecastWizardApplication.UserControls
{
    public partial class GetPITagUserControl : UserControl
    {
        public FormPITagSelect2 form { get; set; }

        public void PassValue(string Tags, string EngUnits)
        {
            TagTextBox.Text = Tags;
            EngUnitsTextBox.Text = EngUnits;
        }

        public GetPITagUserControl()
        {
            InitializeComponent();

        }

        private void SelectPITagButton_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Server=tcp:realtimepower.database.windows.net,1433;Initial Catalog=ForecastAppDatabase;Persist Security Info=False;User ID=abhijeetsahu;Password=@rtp2016saHu;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            //form = new FormPITagSelect(conn,this);
            form = new FormPITagSelect2(this);
            form.Show();
        }

    }
}

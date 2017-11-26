using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RTP.WebAPIClient;
using System.Net.Http;

namespace testGetVariables
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            await Task.Run(() =>
            {
                try
                {
                    dt = WebAPIOperations.GetVariables("https://realtimepower.blob.core.windows.net/calpine?sv=2015-12-11&si=calpine-15A3431ED36&sr=c&sig=s5h4RfNepkrNaFgEOxam6fIlwx8dr5Oo5EP7TAKCbWE%3D", "calpine/baytown/performance/");
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            });
            dataGridView1.DataSource = dt;
        }
    }
}

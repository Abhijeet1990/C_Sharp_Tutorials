using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncAwait
{
    public partial class Form1 : Form
    {
        delegate void SetTextCallback(string text);
        public static DataTable dt = new DataTable();
        private BindingSource _bindingSource = new BindingSource();
        //List<string> _chosenVariable = new List<string>();
        string updateMessage = "";
        HttpClient client2 = new HttpClient();
        public Form1()
        {
            InitializeComponent();
            client2.BaseAddress = new Uri("http://localhost:55342/");
            client2.DefaultRequestHeaders.Accept.Clear();
            client2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Access();
            //MessageBox.Show(x.ToString());
        }

        public async void Access()
        {
            
            await AccessTheWebAsync();
            
        }
        public async Task AccessTheWebAsync()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:55342/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //Task<string> getStringTask = client.GetStringAsync("http://msdn.microsoft.com");
            Task<HttpResponseMessage> response = client.GetAsync("api/Blobdata/calpine/baytown/2016-09-03/2016-09-01/5/Value?Variables[]=Ambient Air Density");

            while (!response.IsCompleted)
            {await DoIndependentWork(); }

            Task<string> temp = response.Result.Content.ReadAsStringAsync();
            string json = temp.Result.ToString();
            
            json = json.Replace("\\", "");
            json = json.Remove(json.Length - 1, 1);
            json = json.Remove(0, 1);
            dt = JsonConvert.DeserializeObject<DataTable>(json);

            dataGridView1.Visible = true;
            //ExportButton.Visible = true;
            _bindingSource.DataSource = dt.AsDataView();

            dataGridView1.DataSource = _bindingSource;
        }
        
        public async Task DoIndependentWork()
        {
            /*
            HttpClient client = new HttpClient();
            //int count = 0;
            for (int i = 0; i < 10; i++)
            {
                Task<string> getStringTask2 = client.GetStringAsync("http://www.google.com");
                Thread.Sleep(50);
                string urlContents = await getStringTask2;
                BeginInvoke((Action)delegate { label1.Text = "fetched google " + i; });
                //count += urlContents.Length;
            }*/

            Task<string> response=client2.GetStringAsync("api/BlobData/GetStatus");
            updateMessage = await response;
            BeginInvoke((Action)delegate { label1.Text = updateMessage; });

            Thread.Sleep(500);
        }

    }
}

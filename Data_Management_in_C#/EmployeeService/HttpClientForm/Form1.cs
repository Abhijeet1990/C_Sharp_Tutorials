using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Data.SqlClient;

namespace HttpClientForm
{
    public partial class Form1 : Form
    {
        static HttpClient client = new HttpClient();
        
        public Form1()
        {
            InitializeComponent();
            client.BaseAddress = new Uri("http://localhost:53539/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        static async Task<Uri> CreateEmployeeAsync(Employee emp)
        {
            
            HttpResponseMessage response = await client.PostAsJsonAsync("api/employees", emp);
            response.EnsureSuccessStatusCode();

            return response.Headers.Location;
        }

        static async Task<Employee> GetEmployeeAsync(string path)
        {
            Employee emp = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                emp = await response.Content.ReadAsAsync<Employee>();

            }
            return emp;
        }

        private void Get_Click(object sender, EventArgs e)
        {
            //Employee e = new Employee();


        }

        

        private async void Create_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee
            {
                ID = 5,
                FirstName = "Amelia",
                LastName = "Sprinston",
                Gender = "Female",
                Salary = 3900
            };
            var url = await CreateEmployeeAsync(emp);

            MessageBox.Show("Employee created at {0}",url.ToString());
        }

        private void GetButton_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:53539/");
            HttpResponseMessage response = client.GetAsync("api/employees/"+MinSalaryTextBox.Text + "/" + MaxSalaryTextBox.Text).Result;
            //var emp = response.Content.ReadAsAsync<Employee>().Result;
            var emp = response.Content.ReadAsAsync<IEnumerable<Employee>>().Result;
            dataGridView1.DataSource = emp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ABHIJEET-PC\SQLEXPRESS;Initial Catalog=EmployeeDB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
            DataTable data = new DataTable();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * from Employees where Salary >"+Convert.ToInt32(MinSalaryTextBox.Text)+" and Salary <"+ Convert.ToInt32(MaxSalaryTextBox.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            dataGridView2.DataSource = data;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();
        }
    }
}

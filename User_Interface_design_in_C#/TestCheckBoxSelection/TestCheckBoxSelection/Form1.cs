using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TestCheckBoxSelection
{
    public partial class Form1 : Form
    {
        public static int DBCheckStatus=0;
        public static int PFCheckStatus=0;
        public static int SICheckStatus=0;
        public static int CCCheckStatus=0;
        public static int BlockType;
        public static string ActiveGT="";
        int[] Status = new int[4];
        public Form1()
        {
            InitializeComponent();
            checkBox3.Enabled = false;
            checkBox6.Enabled = false;
        }

        
        public void FillDataGrid(int[] x,int blockType,string ActiveGT)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ABHIJEET-PC\SQLEXPRESS;Initial Catalog=TableMapping;Integrated Security=True";

            SqlCommand command = new SqlCommand();
            command.Connection = conn;

            //intelligent creation of query 
            command.CommandText = "SELECT * FROM ForecastTableMapping";
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            //int[] ForecastIDList = new int[] { };

            List<int> ForecastIDList = new List<int>();
            int rowCount = data.Rows.Count;
            int columnCount = data.Columns.Count;

            object[,] arr = new object[rowCount, columnCount];
            //int count = 0;
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    arr[i, j] = data.Rows[i][j];
                    
                }
            }
            int count = 0;
            //string code = "";
            //for (int i = 0; i < Status.Length; i++)
            //{

            //    code += Status[i].ToString();
            //}
            //MessageBox.Show(code);

            /****************Main Inclusion List**************************************************************************/
            ForecastIDList.Add(Convert.ToInt32(arr[0, 0]));
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount-2; j++)
                {
                    if (Status[j] != 0)
                    {
                        if ((int)arr[i, j+2]==Status[j])
                        {
                            count++;
                            if (count == 1)
                            {
                                ForecastIDList.Add(Convert.ToInt32(arr[i, 0]));
                            }
                            else
                            {
                                continue;
                            }
                           

                        }
                        
                    }
                    
                }
                count = 0;

            }
            /******************************Main Exclusion List**********************************************************/
            List<int> copy = new List<int>(ForecastIDList);

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount - 2; j++)
                {
                    if (Status[j] == 0)
                    {
                        if ((int)arr[i, j + 2] !=0)
                        {
                            foreach (var id in copy)
                            {
                                   if((int)arr[i,0]==id)
                                {
                                    ForecastIDList.Remove(id);
                                    //continue;
                                }
                            }                        
                        }
                    }
                    
                }

            }



            /*****************Removal of Exclusion Based on Conditional Enhancement Types******************************/ 

            /**********Exclusion One: Steam Injection independent on DuctBurners*********************************/

            List<int> copy2 = new List<int>(ForecastIDList);
            
            foreach (var id in copy2)
            {
                
                if((Status[0]==2 && arr[id-1,2].ToString()=="1")||(Status[0] == 1 && arr[id - 1, 2].ToString() == "2"))
                {
                    //MessageBox.Show("in here");
                    ForecastIDList.Remove(id);
                }
            }


            /**********Exclusion Two: Condenser Conditioning with water spraying independent on DuctBurners*********************************/
            List<int> copy3 = new List<int>(ForecastIDList);
           
            foreach (var id in copy3)
            {

                if ((Status[2] == 2 && arr[id - 1, 4].ToString() == "1")|| (Status[2] == 1 && arr[id - 1, 4].ToString() == "2"))
                {
                    //MessageBox.Show("in here");
                    ForecastIDList.Remove(id);
                }
            }
            DataTable newdata = new DataTable();
            newdata.Columns.Add("fName", typeof(String));
            newdata.Columns.Add("id", typeof(int));
            foreach (var id in ForecastIDList)
            {
                
                DataRow r = newdata.NewRow();
                r["fName"] = arr[id - 1, 1].ToString();
                r["id"] = Convert.ToInt32(arr[id - 1, 0]);
                newdata.Rows.Add(r);
            }
            
            dataGridView1.DataSource = newdata;
            
            SqlCommand command2 = new SqlCommand();
            command2.Connection = conn;
            
            command2.CommandText = "SELECT ForecastName FROM ForecastByBlock WHERE BlockType= "+blockType.ToString()+" AND "+"GTCount like '%"+@ActiveGT+"%'";
            DataTable data2 = new DataTable();
            SqlDataAdapter adapter2 = new SqlDataAdapter(command2);
            adapter2.Fill(data2);
            dataGridView2.DataSource = data2;
            

            int rowCount2 = data2.Rows.Count;
            int rowCount3 = newdata.Rows.Count;


            List<string> NewForecastList = new List<string>();
            string buffer = "";
            for (int i = 0; i < rowCount2; i++)
            {
                for (int j = 0; j < rowCount3; j++)
                {
                    buffer+= data2.Rows[i]["ForecastName"].ToString();
                    buffer+= newdata.Rows[j]["fName"].ToString();
                    NewForecastList.Add(buffer);
                    buffer = "";
                }

            }
            DataTable finaldata = new DataTable();
            finaldata.Columns.Add("fName", typeof(String));
            foreach (var id in NewForecastList)
            {

                DataRow r = finaldata.NewRow();
                r["fName"] = id;
                finaldata.Rows.Add(r);
            }
            dataGridView3.DataSource = finaldata;



        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                DBCheckStatus = 1;
                checkBox6.Enabled = true;
                checkBox3.Enabled = true;
            }
            else
                DBCheckStatus = 0;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                SICheckStatus = 1;
                
            }
            else
                SICheckStatus = 0;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
                SICheckStatus = 2;
            else if (checkBox2.Checked)
                SICheckStatus = 1;
            else
                SICheckStatus = 0;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox4.Checked)
            {
                CCCheckStatus = 1;
                
            }
            else
                CCCheckStatus = 0;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
                PFCheckStatus = 1;
            else
                PFCheckStatus = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Status[0] = SICheckStatus;
            Status[1] = DBCheckStatus;
            Status[2] = CCCheckStatus;
            Status[3] = PFCheckStatus;
            FillDataGrid(Status,BlockType,ActiveGT);
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
                CCCheckStatus = 2;
            else if (checkBox4.Checked)
                CCCheckStatus = 1;
            else
                CCCheckStatus = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BlockType = comboBox1.SelectedIndex + 1;

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActiveGT = comboBox2.Text;
        }
    }
}

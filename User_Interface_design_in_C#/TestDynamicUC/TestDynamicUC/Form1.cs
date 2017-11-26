using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestDynamicUC
{
    public partial class Form1 : Form
    {
        public static List<int> BESelectionList = new List<int>();
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Assume the 3 types of Block enhancement selected
            BESelectionList.Add(11);
            BESelectionList.Add(2);
            BESelectionList.Add(0);
           
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Server=tcp:realtimepower.database.windows.net,1433;Initial Catalog=ForecastAppDatabase;Persist Security Info=False;User ID=abhijeetsahu;Password=@rtp2016saHu;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            DataTable data = new DataTable();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * FROM AttributeMaster WHERE PlantObjectTypeID=4";

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);

            var x = (from r in data.AsEnumerable()
                     select r[10]).Distinct().ToList();
            int j;
            int y = 0;
            foreach (var id in x)
            {
                GroupBox g = new GroupBox();
                DataTable d = new DataTable();
                var sql = String.Format("select Name from ObjectGroups where ObjectGroupID = {0}", id);
                SqlCommand command2 = new SqlCommand(sql);
                command2.Connection = conn;
                SqlDataAdapter adapter2 = new SqlDataAdapter(command2);
                adapter2.Fill(d);
                g.Text = d.Rows[0][0].ToString();
                g.AutoSize = true;
                g.DoubleClick += GroupBox_OnDoubleClick;
                
                j = 0;
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    if (Convert.ToInt32(data.Rows[i][10]) == Convert.ToInt32(id) && BESelectionList.Contains(Convert.ToInt32(data.Rows[i][5])))
                    {
                        j++;
                        DynamicUC uc = new DynamicUC();                        
                        Label lb = new Label();
                        lb.Location = new Point(20, 5);
                        lb.Text = data.Rows[i][3].ToString();
                        lb.AutoSize = true;

                        TextBox tb = new TextBox();
                        tb.Location = new Point(lb.Right + 130, 5);
                        ComboBox cb = new ComboBox();
                        cb.Location = new Point(tb.Right, 5);
                        
                        if(data.Rows[i][10].ToString()!="NULL")
                        {
                            List<string> cbList = new List<string>();
                            cbList = data.Rows[i][11].ToString().Split(',').ToList();
                            foreach(var item in cbList)
                            {
                                cb.Items.Add(item);
                            }
                        }
                        Button btn = new Button();
                        btn.Location = new Point(cb.Right, 5);
                        btn.Click += onClickEvent;
                        //MessageBox.Show(data.Rows[i][6].ToString());

                        uc.Controls.Add(lb);
                        if (data.Rows[i][6].ToString() == "1") uc.Controls.Add(tb);
                        if (data.Rows[i][7].ToString() == "1") uc.Controls.Add(cb);
                        if (data.Rows[i][8].ToString() == "1") uc.Controls.Add(btn);
                        uc.Location = new Point(20, 25 * (j + 1));
                        g.Controls.Add(uc);
                    }
                }
                if (g.HasChildren)
                {
                    this.Controls.Add(g);
                    if (x.IndexOf(id) == 0)
                        g.Location = new Point(10, 100);
                    else
                        g.Location = new Point(10, y);

                    y = g.Bottom;
                }
            }
        }

        private void onClickEvent(object sender, EventArgs e)
        {
            LookUpTableForm form = new LookUpTableForm();
            form.Show();
        }

        private void GroupBox_OnDoubleClick(object sender,EventArgs e)
        {
            GroupBox g = (GroupBox)sender;
            g.ForeColor = Color.Crimson;
            g.BackColor = Color.Cornsilk;
            //if (g.Enabled == true) g.Enabled = false;
            //else g.Enabled = true;
        }
    }
}

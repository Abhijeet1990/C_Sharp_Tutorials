using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace FWA
{
    public partial class TagSelectionForm : Form
    {
        SqlConnection connection = new SqlConnection();
        
        public string selectedTag = null;
        public string selectedEngUnits = null;
        public bool tagSelected;
        public TagSelectionForm()
        {
            InitializeComponent();
            selectedTag = "";
            selectedEngUnits = "";
            tagSelected = false;
            this.connection.ConnectionString = @"Data Source=ABHIJEET-PC\SQLEXPRESS;Initial Catalog=ForecastDatabase;Integrated Security=True"; ;
        }
        public TagSelectionForm(SqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
            selectedTag = "";
            selectedEngUnits = "";
            tagSelected = false;
        }
        private void buttonClearDescInc_Click(object sender, EventArgs e)
        {
            textBoxDescInc.Text = "";
            QueryDatabase();
        }

        private void buttonClearTagInc_Click(object sender, EventArgs e)
        {
            textBoxTagIncBegins.Text = "";
            textBoxTagIncContains.Text = "";
            textBoxTagIncEnds.Text = "";
            QueryDatabase();
        }

        private void buttonClearEngUnitsInc_Click(object sender, EventArgs e)
        {
            textBoxEngUnitsInc.Text = "";
            QueryDatabase();
        }

        private void buttonClearDescExc_Click(object sender, EventArgs e)
        {
            textBoxDescExc.Text = "";
            QueryDatabase();
        }

        private void buttonClearTagExc_Click(object sender, EventArgs e)
        {
            textBoxTagExcBegins.Text = "";
            textBoxTagExcContains.Text = "";
            textBoxTagExcEnds.Text = "";
            QueryDatabase();
        }

        private void buttonClearEngUnitsExc_Click(object sender, EventArgs e)
        {
            textBoxEngUnitsExc.Text = "";
            QueryDatabase();
        }

        private void comboBoxPointType_SelectedIndexChanged(object sender, EventArgs e)
        {
            QueryDatabase();
        }

        private void buttonApplyFilters_Click(object sender, EventArgs e)
        {
            QueryDatabase();
        }

        private void TagSelectionForm_Shown(object sender, EventArgs e)
        {
            QueryDatabase();
        }


        private string FormIncludeList(string textBoxText, string column, int option)
        {
            // Initialize the list
            string list = "";

            // Return if the text box text is empty
            if (textBoxText == "") return list;

            // Get the elements of the comma separated list
            string[] element = textBoxText.Split(',');
            int n = element.Count();
            int m = n - 1;

            // Bracket each element with '% ... %' as defined by option
            for (int i = 0; i < n; i++)
            {
                bool escape = false;
                if (i == 0) list += " (";
                if (element[i] == "%") { element[i] = "\\%"; escape = true; }
                if (option == 0) { element[i] = column + " LIKE '%" + element[i] + "%'"; if (escape) element[i] += " ESCAPE '\\'"; }
                else if (option == 1) { element[i] = column + " LIKE '" + element[i] + "%'"; if (escape) element[i] += " ESCAPE '\\'"; }
                else if (option == 2) { element[i] = column + " LIKE '%" + element[i] + "'"; if (escape) element[i] += " ESCAPE '\\'"; }
                list += element[i]; if (i < m) list += " OR "; else list += ")";
            }

            // Return the list
            return list;
        }

        private string FormExcludeList(string textBoxText, string column, int option)
        {
            // Initialize the list
            string list = "";

            // Return if the text box text is empty
            if (textBoxText == "") return list;

            // Get the elements of the comma separated list
            string[] element = textBoxText.Split(',');
            int n = element.Count();
            int m = n - 1;

            // Bracket each element with '% ... %' as defined by option
            for (int i = 0; i < n; i++)
            {
                bool escape = false;
                if (i == 0) list += " (";
                if (element[i] == "%") { element[i] = "\\%"; escape = true; }
                if (option == 0) { element[i] = column + " NOT LIKE '%" + element[i] + "%'"; if (escape) element[i] += " ESCAPE '\\'"; }
                else if (option == 1) { element[i] = column + " NOT LIKE '" + element[i] + "%'"; if (escape) element[i] += " ESCAPE '\\'"; }
                else if (option == 2) { element[i] = column + " NOT LIKE '%" + element[i] + "'"; if (escape) element[i] += " ESCAPE '\\'"; }
                list += element[i]; if (i < m) list += " AND "; else list += ")";
            }

            // Return the list
            return list;
        }


        private void QueryDatabase()
        {
            // Form the include lists
            string descIncList = FormIncludeList(textBoxDescInc.Text, "Descriptor", 0);
            string tagIncContainsList = FormIncludeList(textBoxTagIncContains.Text, "Tag", 0);
            string tagIncBeginsList = FormIncludeList(textBoxTagIncBegins.Text, "Tag", 1);
            string tagIncEndsList = FormIncludeList(textBoxTagIncEnds.Text, "Tag", 2);
            string engUnitsIncList = FormIncludeList(textBoxEngUnitsInc.Text, "EngUnits", 0);


            // Form the exclude lists
            string descExcList = FormExcludeList(textBoxDescExc.Text, "Descriptor", 0);
            string tagExcContainsList = FormExcludeList(textBoxTagExcContains.Text, "Tag", 0);
            string tagExcBeginsList = FormExcludeList(textBoxTagExcBegins.Text, "Tag", 1);
            string tagExcEndsList = FormExcludeList(textBoxTagExcEnds.Text, "Tag", 2);
            string engUnitsExcList = FormExcludeList(textBoxEngUnitsExc.Text, "EngUnits", 0);

            // Form the SQL string
            bool flag = false;
            string sqlString = "SELECT Tag, Descriptor, Value, EngUnits, Status, Time, PointType";
            sqlString += " FROM PISnapshots WHERE";

            // Add the include criteria      
            if (descIncList != "") { if (flag) sqlString += " AND"; sqlString += descIncList; flag = true; }
            if (tagIncContainsList != "") { if (flag) sqlString += " AND"; sqlString += tagIncContainsList; flag = true; }
            if (tagIncBeginsList != "") { if (flag) sqlString += " AND"; sqlString += tagIncBeginsList; flag = true; }
            if (tagIncEndsList != "") { if (flag) sqlString += " AND"; sqlString += tagIncEndsList; flag = true; }
            if (engUnitsIncList != "") { if (flag) sqlString += " AND"; sqlString += engUnitsIncList; flag = true; }
            if (comboBoxPointType.SelectedIndex == 1) { if (flag) sqlString += " AND"; sqlString += " PointType = 'R'"; flag = true; }
            if (comboBoxPointType.SelectedIndex == 2) { if (flag) sqlString += " AND"; sqlString += " PointType = 'D'"; flag = true; }

            // Add the exclude criteria
            if (descExcList != "") { if (flag) sqlString += " AND"; sqlString += descExcList; flag = true; }
            if (tagExcContainsList != "") { if (flag) sqlString += " AND"; sqlString += tagExcContainsList; flag = true; }
            if (tagExcBeginsList != "") { if (flag) sqlString += " AND"; sqlString += tagExcBeginsList; flag = true; }
            if (tagExcEndsList != "") { if (flag) sqlString += " AND"; sqlString += tagExcEndsList; flag = true; }
            if (engUnitsExcList != "") { if (flag) sqlString += " AND"; sqlString += engUnitsExcList; flag = true; }

            // Add the order by clause
            sqlString += " ORDER BY Tag";

            // Return if there is no where clause
            if (flag == false) return;

            // Create the SQL command
            SqlCommand sqlCommand = new SqlCommand(sqlString, connection);

            
            // Create the data adapter
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);

            // Create the data set
            DataSet dataSet = new DataSet();

            // Number of tags in data set
            int numTags = 0;

            // Try to fill the data set
            try
            {
                // Fill out the pipoint data set
                numTags = adapter.Fill(dataSet, "PISnapshots");
                if (numTags < 1) return;

                
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                MessageBox.Show(sqlString);
                return;
            }

            // Clear the data grid
            if (dataGridView1.RowCount > 0) dataGridView1.Rows.Clear();

            try
            {
                // Set the data grid view rows
                for (int i = 0; i < numTags; i++)
                {
                    // Add new row to the data grid view
                    dataGridView1.Rows.Add();

                    // Get the next data row
                    DataRow dataRow1 = dataSet.Tables["PISnapshots"].Rows[i];
                    

                    // Get the tag
                    string tag = (string)dataRow1["Tag"];
                    dataGridView1.Rows[i].Cells[0].Value = tag;

                    // Get the descriptor
                    string descriptor = (string)dataRow1["Descriptor"];
                    dataGridView1.Rows[i].Cells[1].Value = descriptor;

                    // Get the value
                    Object value;
                    if (dataRow1.IsNull("Value")) value = 0;
                    else value = (Object)dataRow1["Value"];
                    dataGridView1.Rows[i].Cells[2].Value = value.ToString();

                    // Get the engunits
                    string engunits = (string)dataRow1["EngUnits"];
                    dataGridView1.Rows[i].Cells[3].Value = engunits;

                    // Get the quality
                    string quality = "Bad";
                    int status = (int)dataRow1["Status"];
                    if (status == 0) quality = "Good";
                    dataGridView1.Rows[i].Cells[4].Value = quality;

                    // Get the timestamp
                    DateTime time = (DateTime)dataRow1["Time"];
                    dataGridView1.Rows[i].Cells[5].Value = time.ToString("yyyy-MM-dd HH:mm:ss");
                }
            }

            // Catch any exceptions
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                MessageBox.Show(sqlString);
                return;
            }

            // Update the data grid view
            dataGridView1.AutoResizeColumns();
            dataGridView1.Update();

            // Success
            return;
        }
    }
}

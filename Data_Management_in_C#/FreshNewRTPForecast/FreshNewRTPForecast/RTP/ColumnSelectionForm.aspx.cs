using RTPWebForecastService.Infrastructure;
using RTP.Forecast;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RTPWebForecastService
{
    public static class ExtensionMethods
    {
        public static void Convert<T>(this DataColumn column, Func<object, T> conversion)
        {
            foreach (DataRow row in column.Table.Rows)
            {
                row[column] = conversion(row[column]);
            }
        }

        public static List<ListItem> GetSelectedItems(this ListBox lst)
        {
            return lst.Items.OfType<ListItem>().Where(i => i.Selected).ToList();
        }
    }
    public partial class ColumnSelectionForm : System.Web.UI.Page
    {
        public bool _modified;  // To insure any changes has been done in this form or not
        private string _selectedSite;
        private string _selectedBlock;
        private string _selectedName;
        public static string _selectedMarket;
        //private List<string> _availableColumnsList;
        //public List<string> SelectedColumnsList;

        // pass the url as http://RTP/ColumnSelectionForm.aspx?Site=xxxx&Block=xxxxxx&Name=xxxx&Market=xxxx
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            // Get intercept of columns between total available and displayed
            _selectedSite = Request.QueryString["Site"];
            _selectedBlock = Request.QueryString["Block"];
            _selectedName = Request.QueryString["Name"];
            _selectedMarket = Request.QueryString["Market"];

            NameText.Text = _selectedName;
            //based on the Market populate the SiteDDList
            var directoryPaths = Database.ImportSiteFolder();
            List<string> SiteList = new List<string>();
            var marketName = Request.QueryString["Market"];
            if (!string.IsNullOrEmpty(marketName))
            {
                SiteList.Add("None");
                foreach (var path in directoryPaths)
                {
                    var market = path.Market;
                    if (market == marketName)
                    {
                        SiteList.Add(path.Site);
                    }
                    SiteList = SiteList.Distinct().ToList();
                }

                SiteDDList.DataSource = SiteList;
                SiteDDList.DataBind();

                if (string.IsNullOrEmpty(_selectedSite)) SiteDDList.SelectedValue = "None"; else SiteDDList.SelectedValue = _selectedSite;
            }
            
           
            if (!string.IsNullOrEmpty(_selectedSite))
            {
                List<string> blockList = new List<string>();
                blockList.Add("None");
                foreach (var path in directoryPaths)
                {
                    var sitename = path.Site;
                    var blockname = path.Block;
                    if (sitename == _selectedSite)
                    {
                        blockList.Add(blockname);
                    }
                }
                BlockDDList.DataSource = blockList;//whatever you want to bind, e.g. based on the selected value, using((DropDownList)sender).SelectedValue;
                BlockDDList.DataBind();
                if (string.IsNullOrEmpty(_selectedSite)) BlockDDList.SelectedValue = "None"; else BlockDDList.SelectedValue = _selectedBlock;
            }

            List<string> availableColumnList = new List<string>();

            foreach (var path in directoryPaths)
            {
                
                if (path.Site == _selectedSite && path.Block == _selectedBlock)
                {
                    DataTable data = FileUtilities.ReadForecastFileIntoDataTable(path.ForecastPath);
                    availableColumnList = (from DataColumn x in data.Columns
                                             select x.ColumnName).ToList();
                }
            }
            

            // Read the file storing the Site,Block,List of Variables as DataTable
            List<string> selectedColumnList = new List<string>();
            var path1 = DataForecast.VariableListFilePath();
            if (string.IsNullOrEmpty(path1)) return;
            DataTable dt = DataForecast.ReadConfigFileIntoDataTable(path1);
            if (!string.IsNullOrEmpty(_selectedBlock) && !string.IsNullOrEmpty(_selectedSite))
            {
                foreach (DataRow r in dt.Rows)
                {
                    if (r[2].ToString() == _selectedSite && r[3].ToString() == _selectedBlock)
                        selectedColumnList = r[4].ToString().Split(',').ToList();
                }
            }

            if ( availableColumnList == null || availableColumnList.Count == 0 ) return;
             availableColumnList = availableColumnList.Except(selectedColumnList).ToList();

            if (selectedColumnList != null && selectedColumnList.Count > 0) UpdateListBox(SelectedColumns,selectedColumnList);
            if (availableColumnList != null && availableColumnList.Count > 0) UpdateListBox(AvailableColumns, availableColumnList);
            SelectedColumns.DataBind();
            AvailableColumns.DataBind();
        }
        protected void OnRightButtonClick(object sender, EventArgs e)
        {
            // Return if column list has no value
            if (AvailableColumns.Items.Count == 0) return;

            // Add selected item(s) to right side list (Display column list)
            AddToColumnsDisplayList();
        }
        protected void OnLeftButtonClick(object sender, EventArgs e)
        {
            // Return if display column list (Right hand list) has no row
            if (ExtensionMethods.GetSelectedItems(SelectedColumns).Count == 0) return;

            // Remove selected item(s) from right side list (Display column list)
            RemoveFromColumnsDisplayList();
        }
        protected void OnUpButtonClick(object sender, EventArgs e)
        {
            // Get display column list selected index
            int selectedIndex = SelectedColumns.SelectedIndex;

            // Return if selected index is less than 1 means either list has no value or user selected first item
            if (selectedIndex < 1) return;

            // Change the selected item position
            ChangeItemPosition(selectedIndex, selectedIndex - 1);
        }
        protected void OnDownButtonClick(object sender, EventArgs e)
        {
            int selectedIndex = SelectedColumns.SelectedIndex;  // Get selected index

            // Return if either user not selected any index or list has no value
            if (selectedIndex == SelectedColumns.Items.Count - 1) return;

            // Change the selected item position
            ChangeItemPosition(selectedIndex, selectedIndex + 1);
        }
        protected void OnOkButtonClick(object sender, EventArgs e)
        {
            // Make changes into the settings and update display column list
            bool result = UpdateColumnsWithDisplays();

            // Return user unselect all the columns
            if (!result) { StatusLabel.Text = "No variable selected"; return; }

            // Write the changes to the file 
            var path = DataForecast.VariableListFilePath();
            if (string.IsNullOrEmpty(path)) return;

            var table = DataForecast.ReadConfigFileIntoDataTable(path);

            bool found = false;
            foreach (DataRow dr in table.Rows) // search whole table if found just modify
            {
                if (dr["Name"].ToString() == NameText.Text)
                {
                    var variables = ListItemToString(SelectedColumns);
                    dr["Site"] = SiteDDList.SelectedValue;
                    dr["Block"] = BlockDDList.SelectedValue;
                    dr["Name"] = NameText.Text;
                    dr["Variables"] = String.Join(",", variables);
                    found = true;
                }
                
            }
            if (!found)// if not found Add
            {
                var columns = ListItemToString(SelectedColumns);
                table.Rows.Add(table.Rows.Count + 1, NameText.Text, SiteDDList.SelectedValue, BlockDDList.SelectedValue, String.Join(",", columns),_selectedMarket);
            }
            DataForecast.WriteDataTableToFile(table, path, true);

            // Close the form
            string close = @"<script type='text/javascript'>
                                window.close();
                                </script>";
            base.Response.Write(close);
        }
        protected void OnCancelButtonClick(object sender, EventArgs e)
        {
            // Close the form
            string close = @"<script type='text/javascript'>
                                window.close();
                                </script>";
            base.Response.Write(close);
        }
        protected void OnSiteDDSelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedSite = SiteDDList.SelectedValue;
            var directoryPaths = Database.ImportSiteFolder();
            var site = ((DropDownList)sender).SelectedValue;
            //isSiteSelected = true;
            BlockDDList.Items.Clear();
            List<string> blockList = new List<string>();
            blockList.Add("None");
            foreach (var path in directoryPaths)
            {
                var sitename = path.Site;
                var blockname = path.Block;
                if (sitename == site)
                {
                    blockList.Add(blockname);
                }
            }
            BlockDDList.DataSource = blockList;//whatever you want to bind, e.g. based on the selected value, using((DropDownList)sender).SelectedValue;
            BlockDDList.DataBind();
        }
        protected void OnBlockDDSelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> availableColumnList = new List<string>();
            List<string> selectedColumnList = new List<string>();
            _selectedSite = SiteDDList.SelectedValue;
            _selectedBlock = BlockDDList.SelectedValue;
            var directoryPaths = Database.ImportSiteFolder();
            foreach (var path in directoryPaths)
            {
                
                if (path.Site == _selectedSite && path.Block == _selectedBlock)
                {
                    DataTable data = FileUtilities.ReadForecastFileIntoDataTable(path.ForecastPath);
                    availableColumnList = (from DataColumn x in data.Columns
                                             select x.ColumnName).ToList();
                }
            }
            

            // Read the file storing the Site,Block,List of Variables as DataTable
            var path1 = DataForecast.VariableListFilePath();
            if (string.IsNullOrEmpty(path1)) return;
            DataTable dt = DataForecast.ReadConfigFileIntoDataTable(path1);
            if (!string.IsNullOrEmpty(_selectedBlock) && !string.IsNullOrEmpty(_selectedSite) && dt.Rows.Count>0)
            {
                foreach (DataRow r in dt.Rows)
                {
                    if (r[2].ToString() == _selectedSite && r[3].ToString() == _selectedBlock)
                        selectedColumnList = r[4].ToString().Split(',').ToList();
                }
            }

            UpdateListBox(SelectedColumns, selectedColumnList);

            if (availableColumnList.Count != 0 && (selectedColumnList!=null ||selectedColumnList.Count!=0))
            { availableColumnList = availableColumnList.Except(selectedColumnList).ToList(); }

            UpdateListBox(AvailableColumns, availableColumnList);

        }
        private void AddToColumnsDisplayList()
        {
            // Convert selected items to list<> from left hand side (all columns) list
            List<string> availableColumnList = ListItemToString(AvailableColumns);
            List<string> selectedColumnList = ListItemToString(SelectedColumns);
            List<string> selectedItems = new List<string>();

            foreach (var item in ExtensionMethods.GetSelectedItems(AvailableColumns))
                selectedItems.Add(item.ToString());

            // Get current selected index so can return selection after updating list
            var index = AvailableColumns.SelectedIndex;

            // Get a list of  items in display Column list
            availableColumnList = availableColumnList.Except(selectedItems).ToList();
            selectedColumnList = selectedColumnList.Union(selectedItems).ToList();

            // Update column list
            UpdateListBox(SelectedColumns, selectedColumnList);
            UpdateListBox(AvailableColumns, availableColumnList);

            // Clear the selection from display column list before change of selected item index
            AvailableColumns.ClearSelection();

            // Select previously selected item with its new index...make sure index <= items
            AvailableColumns.SelectedIndex = Math.Min(index, availableColumnList.Count() - 1);

            _modified = true;
        }
        private void RemoveFromColumnsDisplayList()
        {
            List<string> availableColumnList = ListItemToString(AvailableColumns);
            List<string> selectedColumnList = ListItemToString(SelectedColumns);

            // Convert selected items to list<> from left hand side (all columns) list
            List<string> selectedItems = new List<string>();
            foreach (var item in ExtensionMethods.GetSelectedItems(SelectedColumns))
                selectedItems.Add(item.ToString());

            // Get current selected index so can return selection after updating list
            var index = SelectedColumns.SelectedIndex;

            // Get a list of  items in display Column list
            availableColumnList = availableColumnList.Union(selectedItems).ToList();
            selectedColumnList = selectedColumnList.Except(selectedItems).ToList();

            // Update column list
            UpdateListBox(SelectedColumns, selectedColumnList);
            UpdateListBox(AvailableColumns, availableColumnList);

            // Clear the selection from display column list before change of selected item index
            SelectedColumns.ClearSelection();

            // Select previously selected item with its new index
            if (ExtensionMethods.GetSelectedItems(SelectedColumns).Count() == 1)
                SelectedColumns.SelectedIndex = 0;
            else SelectedColumns.SelectedIndex = Math.Min(index - 1, selectedColumnList.Count() - 1);

            _modified = true;
        }
        private void ChangeItemPosition(int currentIndex, int desiredIndex)
        {
            // Swap item with just above item\
            List<string> selectedColumnList = ListItemToString(SelectedColumns);
            string selected = SelectedColumns.SelectedItem.ToString();
            selectedColumnList.RemoveAt(currentIndex);
            selectedColumnList.Insert(desiredIndex, selected);
            UpdateListBox(SelectedColumns, selectedColumnList.ToList());

            // Clear the selection from display column list before change of selected item index
            SelectedColumns.ClearSelection();

            // Select previously selected item with its new index
            SelectedColumns.SelectedIndex = desiredIndex;

            _modified = true;    // Insure changes has been done in this form
        }
        private void UpdateListBox(ListBox listBox, List<string> columns)
        {
            // Set datasource for list
            listBox.DataSource = columns;
            listBox.DataBind();
        }
        private List<string> ListItemToString(ListBox listBox)
        {
            List<string> output = new List<string>();
            for (int i = 0; i < listBox.Items.Count; i++)
            {
                output.Add(listBox.Items[i].ToString());
            }
            return output;
        }
        private bool UpdateColumnsWithDisplays()
        {
            // Restrict user to unselect all the columns
            if (SelectedColumns.Items.Count == 0) return false;

            return true;
        }
    }
}
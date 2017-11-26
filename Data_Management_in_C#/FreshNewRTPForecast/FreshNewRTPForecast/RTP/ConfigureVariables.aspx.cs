using RTPWebForecastService.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace RTPWebForecastService
{
    public partial class ConfigureVariables : System.Web.UI.Page
    {
        public string _selectedMarket;
        public static string _selectedSite;
        public static string _selectedBlock;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                _selectedMarket = Request.QueryString["Market"];
                MarketLabel.Text = _selectedMarket;
                if (string.IsNullOrEmpty(_selectedMarket) || _selectedMarket == "None") return;
                PopulateForecastVariableGridView();
                PopulateChartConfigureGridView();

                //
                List<string> siteList = new List<string>();
                List<string> blockList = new List<string>();
                var market = MarketLabel.Text;
                var directoryPaths = Database.ImportSiteFolder();

                // populate the sites based on the market selected
                if(!string.IsNullOrEmpty(market))
                {
                    siteList.Add("None");
                    foreach (var path in directoryPaths)
                    {
                        var getMarket = path.Market;
                        if (market == getMarket)
                        {
                            siteList.Add(path.Site);
                        }
                        siteList = siteList.Distinct().ToList();
                    }
                }
                foreach (var site in siteList.Distinct().ToList())
                {
                    SiteDropDownList.Items.Add(site);
                }
                SiteDropDownList.SelectedIndex = 0;
                _selectedSite = SiteDropDownList.SelectedValue;

                //PopulateForecastFormulaGridView();
            }
        }
        protected void OnForecastVariableGridViewRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    e.Row.Cells[i].Attributes.Add("style", "white-space: nowrap;");
                }
            }
            if (e.Row.RowType == DataControlRowType.Header)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    e.Row.Cells[i].Attributes.Add("style", "white-space: nowrap;");
                }
            }

            //Bind a dropdown list
            //if (e.Row.RowType == DataControlRowType.Footer)
            //{
               
            //    List<string> SiteList = new List<string>();
            //    var marketName = Request.QueryString["Market"];
            //    if (!string.IsNullOrEmpty(marketName))
            //    {
            //        SiteList.Add("None");
            //        foreach (var path in directoryPaths)
            //        {
            //            var market = path.Split(',')[3];
            //            if (market == marketName)
            //            {
            //                SiteList.Add(path.Split(',')[0]);
            //            }
            //            SiteList = SiteList.Distinct().ToList();
            //        }
            //    }
            //    var dd = (DropDownList)(e.Row.FindControl("InsertSiteDD"));
            //    dd.DataSource = SiteList;
            //    dd.DataBind();
            //}

            //Bind a dropdown list
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            //    {
            //        List<string> SiteList = new List<string>();
            //        var marketName = Request.QueryString["Market"];
            //        if (!string.IsNullOrEmpty(marketName))
            //        {
            //            SiteList.Add("None");
            //            foreach (var path in directoryPaths)
            //            {
            //                var market = path.Split(',')[3];
            //                if (market == marketName)
            //                {
            //                    SiteList.Add(path.Split(',')[0]);
            //                }
            //                SiteList = SiteList.Distinct().ToList();
            //            }
            //        }

            //        var ddSite = (DropDownList)(e.Row.FindControl("SiteDD"));
            //        ddSite.DataSource = SiteList;
            //        ddSite.DataBind();
            //        // populating the dropdown list selected item with previous selection 
            //        DataRowView dr = e.Row.DataItem as DataRowView;
            //        ddSite.SelectedValue = dr["Site"].ToString();

            //        var ddBlock = (DropDownList)(e.Row.FindControl("BlockDD"));
            //        var blockList = DataForecast.GetBlock(ddSite.SelectedValue);
            //        ddBlock.DataSource = blockList;
            //        ddBlock.DataBind();
            //        // populating the dropdown list for block selected item with previous selection 
            //        DataRowView dr2 = e.Row.DataItem as DataRowView;
            //        ddBlock.SelectedValue = dr2["Block"].ToString();

            //    }
            //}
        }
        protected void OnForecastVariableGridViewRowCommand(object sender, GridViewCommandEventArgs e)
        {
            var type = e.CommandSource.GetType();
            if (type.Name != "LinkButton")
            {
                GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                // if the particular row is asked to edit in Display Mode
                //if (e.CommandName == "Edit")
                //{
                //    ForecastVariableGridView.EditIndex = row.RowIndex;

                //    PopulateForecastVariableGridView();
                //}
                // if the particular row is asked to delete in display Mode
                if (e.CommandName == "Delete")
                {
                    var path = DataForecast.VariableListFilePath();
                    if (string.IsNullOrEmpty(path)) return;

                    var table = DataForecast.ReadConfigFileIntoDataTable(path);

                    for (int i = table.Rows.Count - 1; i >= 0; i--)
                    {
                        DataRow dr = table.Rows[i];
                        if (dr["Name"].ToString() == ForecastVariableGridView.DataKeys[row.RowIndex].Value.ToString())
                            dr.Delete();
                    }
                    DataForecast.WriteDataTableToFile(table, path, true);
                    //Store the DataTable in ViewState
                    ViewState["CurrentTable"] = table;
                    PopulateForecastVariableGridView();
                }
                // if the particular row is asked to update in Edit Mode
                //if (e.CommandName == "Update")
                //{
                //    int forecastID = Convert.ToInt32(ForecastVariableGridView.DataKeys[row.RowIndex].Value.ToString());
                //    DropDownList Site = (DropDownList)row.FindControl("SiteDD");
                //    DropDownList Block = (DropDownList)row.FindControl("BlockDD");

                //    ForecastVariableGridView.EditIndex = -1;
                //    var path = DataForecast.VariableListFilePath();
                //    if (string.IsNullOrEmpty(path)) return;

                //    var table = DataForecast.ReadConfigFileIntoDataTable(path);

                //    foreach (DataRow dr in table.Rows) // search whole table
                //    {
                //        if (Convert.ToInt32(dr["ID"]) == forecastID)
                //        {
                //            dr["Site"] = Site.SelectedValue;
                //            dr["Block"] = Block.SelectedValue;
                //        }
                //    }

                //    DataForecast.WriteDataTableToFile(table, path, true);
                //    //Store the DataTable in ViewState
                //    ViewState["CurrentTable"] = table;
                //    PopulateForecastVariableGridView();
                //}
                //// if the particular row is asked to cancel in Edit Mode
                //if (e.CommandName == "Cancel")
                //{
                //    ForecastVariableGridView.EditIndex = -1;
                //    PopulateForecastVariableGridView();
                //}
            }
        }      
        protected void OnVariableGVRowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
        protected void OnVariableGVRowEditing(object sender, GridViewEditEventArgs e)
        {

        }
        protected void OnVariableGVRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //DropDownList dd = (DropDownList)(ForecastDerateGridView.FindControl("SiteDD"));
            //List<string> SiteList = new List<string>();
            //SiteList.Add("None");
            //SiteList.Add(_selectedSite);
            //dd.DataSource = SiteList;
            //dd.DataBind();
        }
        protected void OnVariableGVPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //ForecastDerateGridView.PageIndex = e.NewPageIndex;
            //PopulateForecastGridView();
        }
        protected void OnVariableGVRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }
        protected void OnChartConfigureGridViewRowDataBound(object sender, GridViewRowEventArgs e)
        {
            var directoryPaths = Database.ImportSiteFolder();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    e.Row.Cells[i].Attributes.Add("style", "white-space: nowrap;");
                }
            }
            if (e.Row.RowType == DataControlRowType.Header)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    e.Row.Cells[i].Attributes.Add("style", "white-space: nowrap;");
                }
            }
        }
        protected void OnChartConfigureGridViewRowCommand(object sender, GridViewCommandEventArgs e)
        {
            var type = e.CommandSource.GetType();
            if (type.Name != "LinkButton")
            {
                GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
 
                // if the particular row is asked to delete in display Mode
                if (e.CommandName == "Delete")
                {
                    var path = DataForecast.VariableListFilePath();
                    if (string.IsNullOrEmpty(path)) return;

                    var table = DataForecast.ReadConfigFileIntoDataTable(path);

                    for (int i = table.Rows.Count - 1; i >= 0; i--)
                    {
                        DataRow dr = table.Rows[i];
                        if (dr["Name"].ToString() == ChartConfigureGridView.DataKeys[row.RowIndex].Value.ToString())
                            dr.Delete();
                    }
                    DataForecast.WriteDataTableToFile(table, path, true);
                    //Store the DataTable in ViewState
                    ViewState["CurrentTable"] = table;
                    PopulateChartConfigureGridView();
                }
            }
        }
        protected void OnChartGVRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
        }
        protected void OnChartGVRowEditing(object sender, GridViewEditEventArgs e)
        {
        }
        protected void OnChartGVRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
        }
        protected void OnChartGVPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
        }
        protected void OnChartGVRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
        }
        protected void OnChartRadioCheckedChanged(object sender, EventArgs e)
        {
            if (chartRadio.Checked)
            {
                Panel1.Visible = true;
                ChartConfigureGridView.Visible = true;
                ForecastVariableGridView.Visible = false;
                var insertButtonTable = (HtmlInputButton)FindControl("InsertButtonTable");
                var insertButtonChart = (HtmlInputButton)FindControl("InsertButtonChart");
                insertButtonChart.Visible = true;
                InsertButtonTable.Visible = false;
                FormulaPanel.Visible = false;

                // change the insert button visibility 
            }
        }
        protected void OnTableRadioCheckedChanged(object sender, EventArgs e)
        {
            if (tableRadio.Checked)
            {
                Panel1.Visible = true;
                ChartConfigureGridView.Visible = false;
                ForecastVariableGridView.Visible = true;
                var insertButtonTable = (HtmlInputButton)FindControl("InsertButtonTable");
                var insertButtonChart = (HtmlInputButton)FindControl("InsertButtonChart");
                insertButtonChart.Visible = false;
                InsertButtonTable.Visible = true;
                FormulaPanel.Visible = false;
            }
        }
        protected void OnFormulaRadioCheckedChanged(object sender, EventArgs e)
        {
            if (formulaRadio.Checked)
            {
                Panel1.Visible = false;
                var insertButtonTable = (HtmlInputButton)FindControl("InsertButtonTable");
                var insertButtonChart = (HtmlInputButton)FindControl("InsertButtonChart");
                insertButtonChart.Visible = false;
                InsertButtonTable.Visible = false;
                FormulaPanel.Visible = true;
            }
        }
        protected void OnSiteDropDownListSelectedIndexChanged(object sender, EventArgs e)
        {

            //populate the block list drop down box
            var directoryPaths = Database.ImportSiteFolder();
            _selectedSite = SiteDropDownList.SelectedValue;

            if (string.IsNullOrEmpty(_selectedSite) || _selectedSite == "None") return;

            List<string> blockList = new List<string>();
            foreach (var path in directoryPaths)
            {
                var sitename = path.Site;
                var blockname = path.Block;
                if (sitename == _selectedSite)
                    blockList.Add(blockname);
            }
            BlockDropDownList.DataSource = blockList.Distinct();
            BlockDropDownList.DataBind();

            _selectedBlock = BlockDropDownList.SelectedValue;
            PopulateForecastFormulaGridView();
        }
        protected void OnBlockDropDownListSelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedBlock = BlockDropDownList.SelectedValue;
            PopulateForecastFormulaGridView();
        }
        protected void PopulateForecastVariableGridView()
        {
            // the table contains the content of the list of site / block, list of variables and Market 
            // Write the changes to the file 
            var path = DataForecast.VariableListFilePath();
            if (string.IsNullOrEmpty(path)) return;

            var table = DataForecast.ReadConfigFileIntoDataTable(path);
            ViewState["CurrentTable"] = table;

            // filter the Table based on the site selected
            var rows = table.AsEnumerable()
               .Where(r => r.Field<string>("Market") == _selectedMarket);

            // DataRow[] dr = rows.Cast<DataRow>().ToArray();

            DataTable filteredTable = table.Clone();
            if (rows.Count() > 0) filteredTable = rows.CopyToDataTable();
            if (filteredTable.Rows.Count > 0)
            {
                ForecastVariableGridView.DataSource = filteredTable;
                ForecastVariableGridView.DataBind();
            }
            else
            {
                //When no row exist in the Derate file for that site create dummy values and make it invisible
                DataRow dr = filteredTable.NewRow();
                dr["ID"] = 0;
                dr["Name"] = string.Empty; // Name
                dr["Site"] = string.Empty; // Site
                dr["Block"] = string.Empty; // Block
                dr["Variables"] = string.Empty; // Variables 
                filteredTable.Rows.Add(dr);

                ForecastVariableGridView.DataSource = filteredTable;
                ForecastVariableGridView.DataBind();
                ForecastVariableGridView.Rows[0].Visible = false;
            }
        }
        protected void PopulateChartConfigureGridView()
        {
            // the table contains the content of the list of site / block, list of variables and Market 
            // Write the changes to the file 
            var path = DataForecast.ChartSeriesListFilePath();
            if (string.IsNullOrEmpty(path)) return;

            var table = DataForecast.ReadConfigFileIntoDataTable(path);
            ViewState["CurrentTable"] = table;

            // filter the Table based on the site selected
            var rows = table.AsEnumerable()
               .Where(r => r.Field<string>("Market") == _selectedMarket);

            // DataRow[] dr = rows.Cast<DataRow>().ToArray();

            DataTable filteredTable = table.Clone();
            if (rows.Count() > 0) filteredTable = rows.CopyToDataTable();
            if (filteredTable.Rows.Count > 0)
            {
                ChartConfigureGridView.DataSource = filteredTable;
                ChartConfigureGridView.DataBind();
            }
            else
            {
                //When no row exist in the Derate file for that site create dummy values and make it invisible
                DataRow dr = filteredTable.NewRow();
                dr["ID"] = 0;
                dr["Name"] = string.Empty; // Name
                dr["Site"] = string.Empty; // Site
                dr["Block"] = string.Empty; // Block
                dr["Chart1"] = string.Empty; // Series1 
                dr["Chart2"] = string.Empty; // Series2 
                dr["Chart3"] = string.Empty; // Series3 
                filteredTable.Rows.Add(dr);

                ChartConfigureGridView.DataSource = filteredTable;
                ChartConfigureGridView.DataBind();
                ChartConfigureGridView.Rows[0].Visible = false;
            }
        }
        protected void PopulateForecastFormulaGridView()
        {
            var directoryPaths = Database.ImportSiteFolder();
            // Read the forecast formula file
            foreach (var path in directoryPaths)
            {
                // For the selected block and site
                if (_selectedBlock == path.Block && _selectedSite == path.Site)
                {
                    var formulaPath = path.FormulaPath;
                    FileInfo file = new FileInfo(formulaPath);
                    string strConn = string.Empty;
                    string extension = file.Extension;
                    switch (extension)
                    {
                        case ".xls":
                            strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + formulaPath+ ";Extended Properties='Excel 8.0;HDR=No;IMEX=1;'";
                            break;
                        case ".xlsx":
                            strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + formulaPath+ ";Extended Properties='Excel 12.0;HDR=No;IMEX=1;'";
                            break;
                        default:
                            strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + formulaPath + ";Extended Properties='Excel 8.0;HDR=No;IMEX=1;'";
                            break;
                    }

                    var fileName = Path.GetFileNameWithoutExtension(formulaPath);
                    OleDbConnection conn = new OleDbConnection(strConn);
                    OleDbDataAdapter adapter = new OleDbDataAdapter("Select * from ["+fileName+"$]", conn);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    DataRow row = dt.Rows[0];
                    dt.Rows.Remove(row);
                    foreach (DataColumn dc in dt.Columns)
                    {
                        dc.ColumnName = dt.Rows[0][dc].ToString();
                    }
                    DataRow row2 = dt.Rows[0];
                    dt.Rows.Remove(row2);

                    FormulaGridView.DataSource = dt;
                    FormulaGridView.DataBind();

                }
            }
        }
      
    }
}
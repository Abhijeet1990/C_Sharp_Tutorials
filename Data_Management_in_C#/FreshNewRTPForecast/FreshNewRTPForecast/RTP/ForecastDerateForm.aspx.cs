using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using RTP.Forecast;
using System.Text;
using System.IO;
using RTPWebForecastService.Infrastructure;
using static RTPWebForecastService.Infrastructure.DataForecast;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;
using System.Globalization;

namespace RTPWebForecastService
{
    public partial class ForecastDerateForm : System.Web.UI.Page
    {
        public static string _selectedSite;
        public static string _selectedBlock;

        // Events
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                _selectedSite = Request.QueryString["Site"];
                if (string.IsNullOrEmpty(_selectedSite) || _selectedSite == "None")
                {
                    Label1.Text = "No Site Selected";
                    return;
                }
                PopulateForecastGridView();
            }
        }
        protected void OnPreviewImageClick(object sender, ImageClickEventArgs e)
        { // From the gridview fetch all the details and fill the List of ForecastDerate and SiteForecasts
          // Then call the CheckForecastForDerate(original dt, sitelist,siteForecasts,ForecastDerate)
          // Form the ForecastDerate
          //List<RTP.Forecast.ForecastDerate> derates = new List<RTP.Forecast.ForecastDerate>();
            ImageButton btn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            ForecastDerate derate = new ForecastDerate();
            //CheckBox chkBox = row.FindControl("ActiveCB") as CheckBox;
            //if (chkBox.Checked)
            //{
            Chart1.Visible = true;
            CheckBox active = (CheckBox)row.FindControl("ActiveCB");
            string Name = ((Label)row.FindControl("DisplayName")).Text;
            Label Site = (Label)row.FindControl("SiteLabel");
            Label Block = (Label)row.FindControl("BlockLabel");
            Label Forecast = (Label)row.FindControl("ForecastLabel");
            Label Type = (Label)row.FindControl("TypeLabel");
            string Value = ((Label)row.FindControl("DisplayValue")).Text;
            string Criteria = ((Label)row.FindControl("DisplayCriteria")).Text;
            string Expiration = ((Label)row.FindControl("DisplayExpiration")).Text;
            string Reason = ((Label)row.FindControl("DisplayReason")).Text;

            derate.Active = active.Checked;
            if (!String.IsNullOrEmpty(Name)) derate.Name = Name;
            if (!String.IsNullOrEmpty(Block.Text)) derate.Block = Block.Text;
            if (!String.IsNullOrEmpty(Site.Text)) derate.Site = Site.Text;
            if (!String.IsNullOrEmpty(Forecast.Text)) derate.ForecastName = Forecast.Text;
            if (Type.Text.ToLower() == "increase") derate.DerateType = DerateType.Increase;
            if (Type.Text.ToLower() == "decrease") derate.DerateType = DerateType.Decrease;
            if (Type.Text.ToLower() == "multiple") derate.DerateType = DerateType.Multiple;
            if (Type.Text.ToLower() == "maximum") derate.DerateType = DerateType.Maximum;
            if (Type.Text.ToLower() == "minimum") derate.DerateType = DerateType.Minimum;
            if (!String.IsNullOrEmpty(Value)) derate.Value = Convert.ToDouble(Value);
            if (!String.IsNullOrEmpty(Criteria)) derate.Criteria = Criteria;
            if (!String.IsNullOrEmpty(Expiration)) derate.Expiration = DateTime.Parse(Expiration);
            if (!String.IsNullOrEmpty(Reason)) derate.Reason = Reason;

            PlotPreviewChart(derate);

        }
        protected void OnPreviewImageEditClick(object sender, ImageClickEventArgs e)
        { // From the gridview fetch all the details and fill the List of ForecastDerate and SiteForecasts
          // Then call the CheckForecastForDerate(original dt, sitelist,siteForecasts,ForecastDerate)
          // Form the ForecastDerate
          //List<RTP.Forecast.ForecastDerate> derates = new List<RTP.Forecast.ForecastDerate>();
            ImageButton btn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            ForecastDerate derate = new ForecastDerate();
            Chart1.Visible = true;
            CheckBox active = (CheckBox)row.FindControl("ActiveCB");
            string Name = ((TextBox)row.FindControl("EditName")).Text;
            string Site = ((DropDownList)row.FindControl("SiteDD")).SelectedValue;
            string Block = ((DropDownList)row.FindControl("BlockDD")).SelectedValue;
            string Forecast = ((DropDownList)row.FindControl("ForecastDD")).SelectedValue;
            string Type = ((DropDownList)row.FindControl("TypeDD")).SelectedValue;
            string Value = ((TextBox)row.FindControl("EditValue")).Text;
            string Criteria = ((TextBox)row.FindControl("EditCriteria")).Text;
            string Expiration = ((TextBox)row.FindControl("EditExpiration")).Text;
            string Reason = ((TextBox)row.FindControl("EditReason")).Text;

            derate.Active = active.Checked;
            if (!String.IsNullOrEmpty(Name)) derate.Name = Name;
            if (!String.IsNullOrEmpty(Block)) derate.Block = Block;
            if (!String.IsNullOrEmpty(Site)) derate.Site = Site;
            if (!String.IsNullOrEmpty(Forecast)) derate.ForecastName = Forecast;
            if (Type.ToLower() == "increase") derate.DerateType = DerateType.Increase;
            if (Type.ToLower() == "decrease") derate.DerateType = DerateType.Decrease;
            if (Type.ToLower() == "multiple") derate.DerateType = DerateType.Multiple;
            if (Type.ToLower() == "maximum") derate.DerateType = DerateType.Maximum;
            if (Type.ToLower() == "minimum") derate.DerateType = DerateType.Minimum;
            if (!String.IsNullOrEmpty(Value)) derate.Value = Convert.ToDouble(Value);
            if (!String.IsNullOrEmpty(Criteria)) derate.Criteria = Criteria;
            if (!String.IsNullOrEmpty(Expiration)) derate.Expiration = DateTime.Parse(Expiration);
            if (!String.IsNullOrEmpty(Reason)) derate.Reason = Reason;

            PlotPreviewChart(derate);

        }
        protected void OnPreviewImageInsertClick(object sender, ImageClickEventArgs e)
        { // From the gridview fetch all the details and fill the List of ForecastDerate and SiteForecasts
          // Then call the CheckForecastForDerate(original dt, sitelist,siteForecasts,ForecastDerate)
          // Form the ForecastDerate
          //List<RTP.Forecast.ForecastDerate> derates = new List<RTP.Forecast.ForecastDerate>();
            ImageButton btn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            ForecastDerate derate = new ForecastDerate();
            Chart1.Visible = true;
            CheckBox active = (CheckBox)row.FindControl("ActiveCBInsert");
            string Name = ((TextBox)row.FindControl("InsertName")).Text;
            string Site = ((DropDownList)row.FindControl("InsertSiteDD")).SelectedValue;
            string Block = ((DropDownList)row.FindControl("InsertBlockDD")).SelectedValue;
            string Forecast = ((DropDownList)row.FindControl("InsertForecastDD")).SelectedValue;
            string Type = ((DropDownList)row.FindControl("InsertTypeDD")).SelectedValue;
            string Value = ((TextBox)row.FindControl("InsertValue")).Text;
            string Criteria = ((TextBox)row.FindControl("InsertCriteria")).Text;
            string Expiration = ((TextBox)row.FindControl("InsertExpiration")).Text;
            string Reason = ((TextBox)row.FindControl("InsertReason")).Text;

            derate.Active = active.Checked;
            if (!String.IsNullOrEmpty(Name)) derate.Name = Name;
            if (!String.IsNullOrEmpty(Block)) derate.Block = Block;
            if (!String.IsNullOrEmpty(Site)) derate.Site = Site;
            if (!String.IsNullOrEmpty(Forecast)) derate.ForecastName = Forecast;
            if (Type.ToLower() == "increase") derate.DerateType = DerateType.Increase;
            if (Type.ToLower() == "decrease") derate.DerateType = DerateType.Decrease;
            if (Type.ToLower() == "multiple") derate.DerateType = DerateType.Multiple;
            if (Type.ToLower() == "maximum") derate.DerateType = DerateType.Maximum;
            if (Type.ToLower() == "minimum") derate.DerateType = DerateType.Minimum;
            if (!String.IsNullOrEmpty(Value)) derate.Value = Convert.ToDouble(Value);
            if (!String.IsNullOrEmpty(Criteria)) derate.Criteria = Criteria;
            if (!String.IsNullOrEmpty(Expiration)) derate.Expiration = DateTime.Parse(Expiration);
            if (!String.IsNullOrEmpty(Reason)) derate.Reason = Reason;
            PlotPreviewChart(derate);
        }
        protected void OnAddButtonClick(object sender, EventArgs e)
        {
            List<string> properties = new List<string>();
            var table = ReadConfigFileIntoDataTable(DerateFilePath());
            int nextIndex = table.Rows.Count + 1;
            properties.Add(nextIndex.ToString());
            //properties.Add("True"); // Default the Active state is false
            string Active = ((CheckBox)ForecastDerateGridView.FooterRow.FindControl("ActiveCBInsert")).Checked.ToString(); properties.Add(Active);
            string Name = ((TextBox)ForecastDerateGridView.FooterRow.FindControl("InsertName")).Text; properties.Add(Name);
            string Site = ((DropDownList)ForecastDerateGridView.FooterRow.FindControl("InsertSiteDD")).SelectedValue; properties.Add(Site);
            string Block = ((DropDownList)ForecastDerateGridView.FooterRow.FindControl("InsertBlockDD")).SelectedValue; properties.Add(Block);
            string Forecast = ((DropDownList)ForecastDerateGridView.FooterRow.FindControl("InsertForecastDD")).SelectedValue; properties.Add(Forecast);
            string Type = ((DropDownList)ForecastDerateGridView.FooterRow.FindControl("InsertTypeDD")).SelectedValue; properties.Add(Type);
            string Value = ((TextBox)ForecastDerateGridView.FooterRow.FindControl("InsertValue")).Text; properties.Add(Value);
            string Criteria = ((TextBox)ForecastDerateGridView.FooterRow.FindControl("InsertCriteria")).Text; properties.Add(Criteria);
            string Expiration = ((TextBox)ForecastDerateGridView.FooterRow.FindControl("InsertExpiration")).Text; properties.Add(Expiration);
            string Reason = ((TextBox)ForecastDerateGridView.FooterRow.FindControl("InsertReason")).Text; properties.Add(Reason);
            //File.AppendAllText(DerateFilePath(), Environment.NewLine + String.Join("\t", properties));
            File.AppendAllText(DerateFilePath(), String.Join("\t", properties) + Environment.NewLine);
            PopulateForecastGridView();
        }
        //protected void OnSiteDDSelectedIndexChanged(object sender, EventArgs e)
        //{
        //    GridViewRow row = (GridViewRow)((DropDownList)sender).Parent.Parent;
        //    DropDownList BlockDD = (DropDownList)row.FindControl("BlockDD");
        //    DropDownList ForecastDD = (DropDownList)row.FindControl("ForecastDD");
        //    //populate the block list drop down box
        //    var directoryPaths = Properties.Settings.Default.SiteFolder;
        //    var site = ((DropDownList)sender).SelectedValue;
        //    //isSiteSelected = true;
        //    List<string> blockList = new List<string>();
        //    List<string> forecastList = new List<string>();
        //    foreach (var path in directoryPaths)
        //    {
        //        var sitename = path.Split(',')[0];
        //        var blockname = path.Split(',')[1];
        //        var filepath = path.Split(',')[2];
        //        if (sitename == site)
        //        {
        //            blockList.Add(blockname);
        //            var data = FileUtilities.ReadForecastFileIntoDataTable(filepath);
        //            forecastList = (from dc in data.Columns.Cast<DataColumn>()
        //                            select dc.ColumnName).ToList();
        //            forecastList.RemoveAt(0);
        //        }

        //    }
        //    BlockDD.DataSource = blockList;//whatever you want to bind, e.g. based on the selected value, using((DropDownList)sender).SelectedValue;
        //    BlockDD.DataBind();
        //    ForecastDD.DataSource = forecastList;
        //    ForecastDD.DataBind();

        //}
        protected void OnInsertSiteDDSelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = (GridViewRow)((DropDownList)sender).Parent.Parent;
            DropDownList BlockDD = (DropDownList)row.FindControl("InsertBlockDD");
            DropDownList ForecastDD = (DropDownList)row.FindControl("InsertForecastDD");
            //populate the block list drop down box
            var directoryPaths = Database.ImportSiteFolder();
            var site = ((DropDownList)sender).SelectedValue;
            //isSiteSelected = true;
            List<string> blockList = new List<string>();
            List<string> forecastList = new List<string>();
            foreach (var path in directoryPaths)
            {
                var sitename = path.Site;
                var blockname = path.Block;
                var filepath = path.ForecastPath;
                if (sitename == site)
                {
                    blockList.Add(blockname);
                    var data = FileUtilities.ReadForecastFileIntoDataTable(filepath);
                    forecastList = (from dc in data.Columns.Cast<DataColumn>()
                                    select dc.ColumnName).ToList();
                    forecastList.RemoveAt(0);
                }
            }
            //forecastList.Insert(0, "Any");
            BlockDD.DataSource = blockList;//whatever you want to bind, e.g. based on the selected value, using((DropDownList)sender).SelectedValue;
            BlockDD.DataBind();
            ForecastDD.DataSource = forecastList;
            ForecastDD.DataBind();
        }
        protected void OnExpirationDateCalendarChanged(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.Calendar DateTakenCalendar = (System.Web.UI.WebControls.Calendar)sender;
            TextBox DateTakenTextBox = (TextBox)((GridViewRow)((System.Web.UI.WebControls.Calendar)(sender)).Parent.Parent).FindControl("EditExpiration");
            DateTakenTextBox.Text = DateTakenCalendar.SelectedDate.ToString("MM/dd/yyyy hh:mm");
            DateTakenCalendar.Visible = false;
        }
        protected void OnInsertExpirationDateCalendarChanged(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.Calendar DateTakenCalendar = (System.Web.UI.WebControls.Calendar)sender;
            TextBox DateTakenTextBox = (TextBox)((GridViewRow)((System.Web.UI.WebControls.Calendar)(sender)).Parent.Parent).FindControl("InsertExpiration");
            DateTakenTextBox.Text = DateTakenCalendar.SelectedDate.ToString("MM/dd/yyyy");
            DateTakenTextBox.Visible = true;
            DateTakenCalendar.Visible = false;
        }
        protected void OnForecastDerateGridViewRowDataBound(object sender, GridViewRowEventArgs e)
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
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                List<string> SiteList = new List<string>();
                SiteList.Add("None");
                SiteList.Add(_selectedSite);
                var dd = (DropDownList)(e.Row.FindControl("InsertSiteDD"));
                dd.DataSource = SiteList;
                dd.DataBind();
            }

            //Bind a dropdown list
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    List<string> SiteList = new List<string>();
                    SiteList.Add("None");
                    SiteList.Add(_selectedSite);

                    var ddSite = (DropDownList)(e.Row.FindControl("SiteDD"));
                    ddSite.DataSource = SiteList;
                    ddSite.DataBind();
                    // populating the dropdown list selected item with previous selection 
                    DataRowView dr = e.Row.DataItem as DataRowView;
                    ddSite.SelectedValue = dr["Site"].ToString();

                    var ddBlock = (DropDownList)(e.Row.FindControl("BlockDD"));
                    var blockList = GetBlock(_selectedSite);
                    ddBlock.DataSource = blockList;
                    ddBlock.DataBind();
                    // populating the dropdown list for block selected item with previous selection 
                    DataRowView dr2 = e.Row.DataItem as DataRowView;
                    ddBlock.SelectedValue = dr2["Block"].ToString();

                    var ddForecast = (DropDownList)(e.Row.FindControl("ForecastDD"));
                    var forecastList = GetForecast(_selectedSite);
                    ddForecast.DataSource = forecastList;
                    ddForecast.DataBind();
                    // populating the dropdown list for block selected item with previous selection 
                    DataRowView dr3 = e.Row.DataItem as DataRowView;
                    ddForecast.SelectedValue = dr3["ForecastName"].ToString();

                }
            }
        }
        protected void OnForecastDerateGridViewRowCommand(object sender, GridViewCommandEventArgs e)
        {
            var type = e.CommandSource.GetType();
            if (type.Name != "LinkButton")
            {
                GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                // if the particular row is asked to edit in Display Mode
                if (e.CommandName == "Edit")
                {
                    ForecastDerateGridView.EditIndex = row.RowIndex;

                    PopulateForecastGridView();
                }
                // if the particular row is asked to delete in display Mode
                if (e.CommandName == "Delete")
                {
                    var path = DerateFilePath();
                    if (string.IsNullOrEmpty(path)) return;

                    var table = ReadConfigFileIntoDataTable(path);

                    for (int i = table.Rows.Count - 1; i >= 0; i--)
                    {
                        DataRow dr = table.Rows[i];
                        if (Convert.ToInt32(dr["ID"]) == Convert.ToInt32(ForecastDerateGridView.DataKeys[row.RowIndex].Value.ToString()))
                            dr.Delete();
                    }
                    WriteDataTableToFile(table, path, true);
                    //Store the DataTable in ViewState
                    ViewState["CurrentTable"] = table;
                    PopulateForecastGridView();
                }
                // if the particular row is asked to update in Edit Mode
                if (e.CommandName == "Update")
                {
                    int forecastID = Convert.ToInt32(ForecastDerateGridView.DataKeys[row.RowIndex].Value.ToString());
                    CheckBox active = (CheckBox)row.FindControl("ActiveCB");
                    TextBox Name = (TextBox)row.FindControl("EditName");
                    DropDownList Site = (DropDownList)row.FindControl("SiteDD");
                    DropDownList Block = (DropDownList)row.FindControl("BlockDD");
                    DropDownList Forecast = (DropDownList)row.FindControl("ForecastDD");
                    DropDownList Type = (DropDownList)row.FindControl("TypeDD");
                    TextBox Value = (TextBox)row.FindControl("EditValue");
                    TextBox Criteria = (TextBox)row.FindControl("EditCriteria");
                    TextBox Expiration = (TextBox)row.FindControl("EditExpiration");
                    TextBox Reason = (TextBox)row.FindControl("EditReason");

                    ForecastDerateGridView.EditIndex = -1;
                    var path = DerateFilePath();
                    if (string.IsNullOrEmpty(path)) return;

                    var table = ReadConfigFileIntoDataTable(path);

                    foreach (DataRow dr in table.Rows) // search whole table
                    {
                        if (Convert.ToInt32(dr["ID"]) == forecastID)
                        {
                            dr["Active"] = active.Checked;
                            dr["Name"] = Name.Text;
                            dr["Site"] = Site.SelectedValue;
                            dr["Block"] = Block.SelectedValue;
                            dr["ForecastName"] = Forecast.SelectedValue;
                            dr["DerateType"] = Type.SelectedValue;
                            dr["Value"] = Value.Text;
                            dr["Criteria"] = Criteria.Text;
                            dr["Expiration"] = Expiration.Text;
                            dr["Reason"] = Reason.Text;
                        }
                    }

                    WriteDataTableToFile(table, path, true);
                    //Store the DataTable in ViewState
                    ViewState["CurrentTable"] = table;
                    PopulateForecastGridView();
                }
                // if the particular row is asked to cancel in Edit Mode
                if (e.CommandName == "Cancel")
                {
                    ForecastDerateGridView.EditIndex = -1;
                    PopulateForecastGridView();
                }
            }
        }
        protected void OnInsertButtonClick(object sender, EventArgs e)
        {
            ForecastDerateGridView.ShowFooter = true;
            PopulateForecastGridView();
        }
        protected void OnInsertCancelClick(object sender, ImageClickEventArgs e)
        {
            ForecastDerateGridView.ShowFooter = false;
            PopulateForecastGridView();
        }
        protected void OnDerateGVRowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
        protected void OnDerateGVRowEditing(object sender, GridViewEditEventArgs e)
        {

        }
        protected void OnDerateGVRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //DropDownList dd = (DropDownList)(ForecastDerateGridView.FindControl("SiteDD"));
            //List<string> SiteList = new List<string>();
            //SiteList.Add("None");
            //SiteList.Add(_selectedSite);
            //dd.DataSource = SiteList;
            //dd.DataBind();
        }
        protected void OnDerateGVPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //ForecastDerateGridView.PageIndex = e.NewPageIndex;
            //PopulateForecastGridView();
        }
        protected void OnDerateGVRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }
        // Functions
        protected void PopulateForecastGridView()
        {
            // Get derate settings file path and make sure exists
            var path = DerateFilePath();
            if (string.IsNullOrEmpty(path)) return;

            var table = ReadConfigFileIntoDataTable(path);
            ViewState["CurrentTable"] = table;

            // filter the Table based on the site selected
            var rows = table.AsEnumerable()
               .Where(r => r.Field<string>("Site") == _selectedSite);

            DataTable filteredTable = table.Clone();
            if (rows.Count() > 0) filteredTable = rows.CopyToDataTable();

            // Order by expiration date
            var orderedRows = from row in filteredTable.AsEnumerable()
                              let date = DateTime.Parse(row.Field<string>("Expiration"), CultureInfo.InvariantCulture)
                              orderby date
                              select row;

            // Verify data rows before copying to datatable
            if (orderedRows == null || orderedRows.Count() == 0) return;

            DataTable sortedTable = orderedRows.CopyToDataTable();

            if (filteredTable.Rows.Count > 0)
            {
                ForecastDerateGridView.DataSource = sortedTable;
                ForecastDerateGridView.DataBind();
            }
            else
            {
                //When no row exist in the Derate file for that site create dummy values and make it invisible
                DataRow dr = filteredTable.NewRow();
                dr[0] = 0; // ID
                dr[1] = false; //Active
                dr[2] = string.Empty; // Name
                dr[3] = string.Empty; // Site
                dr[4] = string.Empty; // Block
                dr[5] = string.Empty; // Forecast 
                dr[6] = string.Empty; // Type
                dr[7] = 0.0; // value
                dr[8] = string.Empty; // Criteria 
                dr[9] = DateTime.MinValue; // Expiration
                dr[10] = string.Empty; // Reason 

                filteredTable.Rows.Add(dr);
                ForecastDerateGridView.DataSource = filteredTable;
                ForecastDerateGridView.DataBind();
                ForecastDerateGridView.Rows[0].Visible = false;
            }

        }
        private void PlotPreviewChart(ForecastDerate derate)
        {
            var directoryPaths = Database.ImportSiteFolder();

            List<string> forecastColumn = new List<string>();
            forecastColumn.Add("Timestamp");
            forecastColumn.Add(derate.ForecastName);
            List<ForecastDerate> derateList = new List<ForecastDerate>();
            derateList.Add(derate);
            foreach (var path in directoryPaths)
            {
                if (derate.Site == path.Site && derate.Block == path.Block)
                {
                    var forecastFilePath = path.ForecastPath;
                    var originalTable = FileUtilities.ReadForecastFileIntoDataTable(forecastFilePath);

                    // if no data return
                    if (originalTable.Rows.Count == 0 || originalTable == null) return;

                    var modifiedTable = DataForecast.CheckForecastForDerate(originalTable, derate.Site, derate.Block, derateList);

                    var startDate = DateTime.Parse(originalTable.Rows[0]["Timestamp"].ToString());
                    var endDate = DateTime.Parse(originalTable.Rows[originalTable.Rows.Count - 1]["Timestamp"].ToString());

                    var rawList = originalTable.AsEnumerable().Select(x => new
                    {
                        Time = (DateTime)x["Timestamp"],
                        Value = (double)x[derate.ForecastName]
                    }).ToList();

                    var derates = modifiedTable.AsEnumerable().Select(x => new
                    {
                        Time = (DateTime)x["Timestamp"],
                        Value = (double)x[derate.ForecastName]
                    }).ToList();


                    List<double> minListMW = new List<double>();
                    List<double> maxListMW = new List<double>();
                    string[] sb = new string[2];
                    sb[0] = DataForecast.GetMinMaxValueColumn(originalTable, derate.ForecastName);
                    minListMW.Add(Convert.ToDouble(sb[0].Split(',')[0]));
                    maxListMW.Add(Convert.ToDouble(sb[0].Split(',')[1]));
                    sb[1] = DataForecast.GetMinMaxValueColumn(modifiedTable, derate.ForecastName);
                    minListMW.Add(Convert.ToDouble(sb[1].Split(',')[0]));
                    maxListMW.Add(Convert.ToDouble(sb[1].Split(',')[1]));

                    Chart1.ChartAreas[0].AxisY.Maximum = Math.Floor(maxListMW.Max() * 1.05);
                    Chart1.ChartAreas[0].AxisY.Minimum = Math.Floor(minListMW.Min() * 0.95);

                    Chart1.ChartAreas[0].AxisY.Interval = Math.Floor((Chart1.ChartAreas[0].AxisY.Maximum - Chart1.ChartAreas[0].AxisY.Minimum) / 4);

                    Chart1.Series[0].Name = "Raw " + derate.ForecastName;
                    Chart1.Series[0].IsVisibleInLegend = true;

                    //double timestamp = DateTime.Parse(row["Timestamp"].ToString()).ToOADate();
                    foreach (var item in rawList)
                    {
                        double timestamp = item.Time.ToOADate();
                        double value = item.Value;
                        DataPoint point = new DataPoint(timestamp, value);
                        Chart1.Series[0].Points.Add(point);
                    }
                    Chart1.Titles.Add("PreviewTitle");
                    Chart1.Titles[0].Text = derate.ForecastName + " forecast for " + derate.Site + " " + derate.Block + " with criteria " + derate.Criteria;
                    Chart1.Series[1].Name = "Derated " + derate.ForecastName;
                    Chart1.Series[1].IsVisibleInLegend = true;
                    Chart1.ChartAreas[0].AxisX.Title = "TimeStamp";
                    Chart1.ChartAreas["ChartArea1"].AxisY.MinorGrid.Enabled = true;
                    Chart1.ChartAreas["ChartArea1"].AxisX.MinorGrid.Enabled = true;
                    Chart1.ChartAreas[0].AxisY.Title = derate.ForecastName;
                    //Chart1.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("Arial", 15F);
                    //Chart1.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("Arial", 15F);
                    Chart1.Series[0].ToolTip = Chart1.Series[0].Name + "= #VALY{#.#}";
                    Chart1.Series[1].ToolTip = Chart1.Series[1].Name + "= #VALY{#.#}";
                    foreach (var item in derates)
                    {
                        double timestamp = item.Time.ToOADate();
                        double value = item.Value;
                        DataPoint point = new DataPoint(timestamp, value);
                        Chart1.Series[1].Points.Add(point);
                    }
                }
            }
        }
    }
}
using RTPWebForecastService;
using RTPWebForecastService.Infrastructure;
using RTPWebForecastService.UserControls;
using RTP.Forecast;
using RTP.Weather;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static RTPWebForecastService.Infrastructure.DataForecast;
using System.Globalization;
using System.Reflection;
using System.Net.Mail;
using System.Web.UI.HtmlControls;
using RTP.Analysis;
using RTP.DataServer;
using System.Text;
using System.Threading;
using RTP.Performance;

namespace RTPWebForecastService
{
    
    public partial class Forecasts : System.Web.UI.Page
    {        
        public static string _selectedSite;
        public static string _selectedBlock;

        public static bool isDerate = false;
        public enum SearchType
        {
            NotSet = -1,
            Chart = 0,
            Table = 1
        }
        public enum FileType
        {
            Trader = 0,
            Operator = 1,
            RawFile = 2
        }

        // List of Functions
        protected void PlotChartOrTable()
        {
            // Based on the selection of RT,DA and ALL update the bool variables
            ForecastConfig f = new ForecastConfig();
            if (realTimeRadio.Checked) { f.isDayAhead = false; f.areAllData = false; }
            if (dayAheadRadio.Checked) { f.isDayAhead = true; f.areAllData = false; }
            if (allRadio.Checked) { f.isDayAhead = false; f.areAllData = true; }
            UpdateTableOrChart(f.isDayAhead, f.areAllData);
        }
        protected void UpdateTableOrChart(bool isDayAhead, bool areAllData)
        {
            // if Table is checked visible the download button
            if (!tableRadio.Checked || !(MultiView1.ActiveViewIndex == 1)) dlButton.Visible = false;
            if (tableRadio.Checked && MultiView1.ActiveViewIndex == 1) dlButton.Visible = true;
            // Get the file name from the property setting
            var directoryPaths = Database.ImportSiteFolder();

            string[] seriesList = new string[ForecastChartControl1.chart1.Series.Count];
            string[] forecastList = new string[ForecastChartControl1.chart1.Series.Count];

            for (int i = 0; i < ForecastChartControl1.chart1.Series.Count; i++)
            {
                seriesList[i] = string.Empty;
                forecastList[i] = string.Empty;
            }
            // Get through all the Sites existing in the settings file
            foreach (var path in directoryPaths)
            {
                var forecastFilePath = path.ForecastPath;

                // For the selected block and site
                if (_selectedBlock == path.Block && _selectedSite == path.Site)
                {
                    // Read data table from forecast Files
                    var forecastData = RTP.Forecast.FileUtilities.ReadForecastFileIntoDataTable(forecastFilePath);

                    // Now check if the Derate exist in the Derate.txt file. if it exist modify the data here
                    var derateData = ReadConfigFileIntoDataTable(DerateFilePath());
                    List<ForecastDerate> derateList = new List<ForecastDerate>();
                    foreach (DataRow r in derateData.Rows)
                    {
                        ForecastDerate f = new ForecastDerate();
                        if (r[3].ToString() == _selectedSite && r[4].ToString() == _selectedBlock)
                        {
                            if (!string.IsNullOrEmpty(r[1].ToString())) f.Active = Convert.ToBoolean(r[1]);
                            if (!string.IsNullOrEmpty(r[2].ToString())) f.Name = r[2].ToString();
                            if (!string.IsNullOrEmpty(r[3].ToString())) f.Site = r[3].ToString();
                            if (!string.IsNullOrEmpty(r[4].ToString())) f.Block = r[4].ToString();
                            if (!string.IsNullOrEmpty(r[5].ToString())) f.ForecastName = r[5].ToString();
                            if (!string.IsNullOrEmpty(r[6].ToString()))
                            {
                                DerateType var;
                                Enum.TryParse(r[6].ToString(), out var);
                                f.DerateType = var;
                            }
                            if (!string.IsNullOrEmpty(r[7].ToString())) f.Value = Convert.ToDouble(r[7]);
                            if (!string.IsNullOrEmpty(r[8].ToString())) f.Criteria = r[8].ToString();
                            if (!string.IsNullOrEmpty(r[9].ToString())) f.Expiration = Convert.ToDateTime(r[9]);
                            if (!string.IsNullOrEmpty(r[10].ToString())) f.Reason = r[10].ToString();
                            derateList.Add(f);
                        }
                    }
                    // Derate the original data table
                    var deratedData = CheckForecastForDerate(forecastData, _selectedSite, _selectedBlock, derateList);

                    // For different kinds of file type the list of columns would vary
                    List<string> columnSelected = new List<string>();
                    if (FileTypeSelection.SelectedValue == "RawFile") { columnSelected = null; }
                    else if (FileTypeSelection.SelectedValue == "Operator")
                    {
                        foreach (var item in Database.ImportPlantSelectedColumn())
                        {
                            if (item.Site == _selectedSite && item.Block == _selectedBlock)
                                columnSelected.Add(item.Forecast);
                        }
                        // As the number of columns for Operators are less we enlarge the width of the gridviews.
                        ForecastDataGridView.Attributes.Add("style", "width:100%");
                        MinMaxAvgGridView.Attributes.Add("style", "width:100%");
                    }
                    else if (FileTypeSelection.SelectedValue == "Trader")
                    {
                        foreach (var item in Database.ImportTraderSelectedColumn())
                        {
                            if (item.Site == _selectedSite && item.Block == _selectedBlock)
                                columnSelected.Add(item.Forecast);
                        }
                        // As the number of columns for Trader are less we enlarge the width of the gridviews.
                        ForecastDataGridView.Attributes.Add("style", "width:100%");
                        MinMaxAvgGridView.Attributes.Add("style", "width:100%");
                    }
                    else
                    {
                        var filepath = VariableListFilePath();
                        var dt = ReadConfigFileIntoDataTable(filepath);
                        var result = from p in dt.AsEnumerable()
                                     where p["Name"].ToString() == FileTypeSelection.SelectedValue
                                     && p["Site"].ToString() == SiteListDD.SelectedValue
                                     && p["Block"].ToString() == BlockListDD.SelectedValue
                                     select new { Variables = p["Variables"].ToString() };
                        foreach (var item in result)
                        {
                            columnSelected.AddRange(item.Variables.Split(',').ToList());
                        }

                    }

                    var selectedDate = DateTime.Now;
                    if (isDayAhead) selectedDate = DateTime.Now.AddDays(1);

                    // Get forecast for selected day and selected operators based on file type
                    DataTable oneDayForecast = new DataTable();
                    if (!areAllData) oneDayForecast = DataForecast.GetFilteredForecastTable(deratedData, columnSelected, selectedDate, false);
                    else oneDayForecast = DataForecast.GetFilteredForecastTable(deratedData, columnSelected, DateTime.MinValue, true);

                    // return if the data not present for the specific day
                    if (oneDayForecast == null) return;

                    // Need to convert the Timestamp column to string for proper format display
                    var filteredTable = oneDayForecast.Clone();

                    // Make sure columns exist before continuing on
                    if (filteredTable.Columns.Count == 0) return;

                    filteredTable.Columns.RemoveAt(0);
                    filteredTable.Columns.Add("Timestamp", typeof(string));
                    filteredTable.Columns["Timestamp"].SetOrdinal(0);


                    List<string> stringList = new List<string>();
                    for (int i = 0; i < oneDayForecast.Rows.Count; i++)
                    {
                        DataRow dr = oneDayForecast.Rows[i];
                        DataRow newRow = filteredTable.NewRow();

                        DateTime d = DateTime.MinValue;
                        DateTime.TryParse(dr["Timestamp"].ToString(), out d);
                        newRow[0] = d.ToString("yyyy-MM-dd HH:mm");

                        for (int n = 1; n < oneDayForecast.Columns.Count; n++)
                        {
                            double value = 0;
                            double.TryParse(oneDayForecast.Rows[i][n].ToString(), out value);

                            // using the extended properties get the eng units
                            if (oneDayForecast.Columns[n].ExtendedProperties.Contains("EngUnits"))
                            {
                                string engUnits = oneDayForecast.Columns[n].ExtendedProperties["EngUnits"].ToString();
                                // based on the eng units modify the decimal places
                                value = FormatForecastValue(engUnits, value);
                            }

                            newRow[n] = value;
                        }

                        filteredTable.Rows.Add(newRow);
                    }

                    // Mark the Columns with ** which are Derated
                    for (int i = 0; i < filteredTable.Rows.Count; i++)
                    {
                        for (int n = 0; n < filteredTable.Columns.Count; n++)
                        {
                            if (filteredTable.Columns[n].ExtendedProperties.Contains("EngUnits") && !filteredTable.Columns[n].ColumnName.Contains("**"))
                            {
                                string engUnits = filteredTable.Columns[n].ExtendedProperties["EngUnits"].ToString();
                                if (engUnits.Contains("**"))
                                    filteredTable.Columns[n].ColumnName += "**";
                            }

                        }
                    }
                    // if the active view index of  multiview is 1 then it means we need to display the data in tables
                    if (MultiView1.ActiveViewIndex == 1)
                    {
                        ForecastDataGridView.DataSource = filteredTable;
                        ForecastDataGridView.DataBind();
                        //headText.Style.Add(HtmlTextWriterStyle.Width, null);

                        // Set the titles based on the selection
                        if (isDayAhead)
                            tableTitle.Text = "DA Forecast Table for " + _selectedSite + " " + _selectedBlock + " " + DateTime.Now.AddDays(1).ToString("dd-MM-yyyy");
                        else if (!areAllData)
                            tableTitle.Text = "RT Forecast Table for " + _selectedSite + " " + _selectedBlock + " " + DateTime.Now.ToString("dd-MM-yyyy");
                        else
                        {
                            tableTitle.Text = "Forecast Table for " + _selectedSite + " " + _selectedBlock;
                        }

                        // minMaxtable is the table to display the statistical detail
                        DataTable minMaxTable = filteredTable.Clone();
                        // Bind the MinMaxAvgGridView to a new Table
                        for (int i = 0; i < 3; i++)
                        {
                            DataRow dr = minMaxTable.NewRow();
                            minMaxTable.Rows.InsertAt(dr, i);
                            if (i == 0) { minMaxTable.Rows[i][0] = "Min"; }
                            if (i == 1) { minMaxTable.Rows[i][0] = "Avg"; }
                            if (i == 2) { minMaxTable.Rows[i][0] = "Max"; }
                            foreach (DataColumn dc in filteredTable.Columns)
                            {
                                if (dc.ColumnName != "Timestamp")
                                {
                                    // gets the minimum value
                                    if (i == 0) minMaxTable.Rows[i][dc.ColumnName] = GetMinMaxAvgValueColumn(filteredTable, dc.ColumnName).Split(',')[0];   
                                    // gets the average value                               
                                    else if (i == 1) minMaxTable.Rows[i][dc.ColumnName] = GetMinMaxAvgValueColumn(filteredTable, dc.ColumnName).Split(',')[2];
                                    // gets the maximum value                                  
                                    else if (i == 2) minMaxTable.Rows[i][dc.ColumnName] = GetMinMaxAvgValueColumn(filteredTable, dc.ColumnName).Split(',')[1];                                  
                                }

                            }
                        }
                        // Replace the Timestamp Columns by Statistics
                        foreach (DataColumn dc in minMaxTable.Columns)
                        {
                            if (dc.ColumnName == "Timestamp") { dc.ColumnName = "Statistics"; }
                        }
                        // Bind the values to the statistics GridView
                        MinMaxAvgGridView.DataSource = minMaxTable;
                        MinMaxAvgGridView.DataBind();
                        return;
                    }

                    // Get the class from the settings
                    List<Infrastructure.ChartSeries> chartList = Database.ImportChartSeries().Where(r => r.Site == _selectedSite && r.Block == _selectedBlock).ToList();

                    // Load the Charts
                    List<string> series = chartList.Select(e => e.Alias).ToList();

                    for (int i = 0; i < ForecastChartControl1.chart1.Series.Count; i++)
                    {
                        if (series.Contains(ForecastChartControl1.chart1.Series[i].Name))
                        {
                            seriesList[i] = ForecastChartControl1.chart1.Series[i].Name;
                            forecastList[i] = chartList.Where(e => e.Alias == ForecastChartControl1.chart1.Series[i].Name).Select(e => e.Name).FirstOrDefault().ToString();
                        }
                    }

                    // if the Market is selected...then the seriesList and ForecastList will change
                    if(!string.IsNullOrEmpty(Request.QueryString["Market"]))
                    {
                        // read the files from the config
                        List<string> series1Column = new List<string>();
                        List<string> series2Column = new List<string>();
                        List<string> series3Column = new List<string>();
                        var filepath = DataForecast.ChartSeriesListFilePath() ;
                        var dt = ReadConfigFileIntoDataTable(filepath);
                        var result = from p in dt.AsEnumerable()
                                     where p["Site"].ToString() == SiteListDD.SelectedValue
                                     && p["Block"].ToString() == BlockListDD.SelectedValue
                                     select new { Chart1 = p["Chart1"].ToString(),Chart2 = p["Chart2"].ToString(), Chart3 = p["Chart3"].ToString() };
                        foreach (var item in result)
                        {
                            series1Column.AddRange(item.Chart1.Split(',').ToList());
                            series2Column.AddRange(item.Chart2.Split(',').ToList());
                            series3Column.AddRange(item.Chart3.Split(',').ToList());
                        }
                        // Get the series details
                        int c1 = 0, c2 = 0, c3 = 0;
                        for (int i = 0; i < ForecastChartControl1.chart1.Series.Count; i++)
                        {
                            if (ForecastChartControl1.chart1.Series[i].Name.Contains("Amb") && !ForecastChartControl1.chart1.Series[i].Name.Contains("*") && c1 < series1Column.Count())
                            {                              
                                seriesList[i] = ForecastChartControl1.chart1.Series[i].Name;
                                forecastList[i] = series1Column[c1];
                                c1++;
                            }
                            if (ForecastChartControl1.chart1.Series[i].Name.Contains("BaseMW") && !ForecastChartControl1.chart1.Series[i].Name.Contains("*") && c2 < series2Column.Count())
                            {                               
                                seriesList[i] = ForecastChartControl1.chart1.Series[i].Name;
                                forecastList[i] = series2Column[c2];
                                c2++;
                            }
                            if (ForecastChartControl1.chart1.Series[i].Name.Contains("BaseHR") && !ForecastChartControl1.chart1.Series[i].Name.Contains("*") && c3 < series3Column.Count())
                            {                           
                                seriesList[i] = ForecastChartControl1.chart1.Series[i].Name;
                                forecastList[i] = series3Column[c3];
                                c3++;
                            }
                        }
                    }

                    // Set the chart titles
                    if (isDayAhead) chartTitle.Text = "DA Forecast Charts for " + _selectedSite + " " + _selectedBlock + " " + DateTime.Now.AddDays(1).ToString("dd-MM-yyyy");
                    else if (!areAllData) chartTitle.Text = "RT Forecast Charts for " + _selectedSite + " " + _selectedBlock + " " + DateTime.Now.ToString("dd-MM-yyyy");
                    else chartTitle.Text = "Forecast Charts for " + _selectedSite + " " + _selectedBlock;
                    
                    ForecastChartUtilities forecastUtilities = new ForecastChartUtilities(seriesList.ToList());

                    // Load all the Charts
                    forecastUtilities.LoadAllChartAreas(ref ForecastChartControl1.chart1, DateTime.Now, DateTime.Now, deratedData, forecastList, seriesList, isDayAhead, areAllData);
                }
            }
        }
        private void UpdateWeatherForecast()
        {
            var paths = Database.ImportWeatherFilePath();
            // Read forecast to list to load flow layout panel
            foreach (var path in paths)
                if (path.FilePath.Contains(SiteListDD.Text))
                {
                    // Get weather from forecast file
                    List<WeatherForecast> forecast = DataForecast.ReadWeatherForecastFileToList(path.FilePath).ToList();
                    if (forecast == null || forecast.Count() == 0) return;

                    // Build graphical layout
                    int index = 0, i = 0;
                    WeatherForecastLabel.Text = "Weather forecast for " + SiteListDD.SelectedValue;
                    foreach (TableRow row in WeatherForecastTable.Rows)
                    {
                        foreach (TableCell cell in row.Cells)
                        {
                            if (index > 24) break;
                            // Show graphical forecast information
                            var hour = forecast[i * 3];
                            ImageForecastControl image = LoadControl("~/UserControls/ImageForecastControl.ascx") as ImageForecastControl;
                            var Path = "~\\Images\\";
                            var elements = hour.Icon_url.Split('/');
                            Path += elements[elements.Count() - 1];
                            image.Image1.ImageUrl = Path;
                            image.ambTempLabel.Text = hour.Temperature.ToString() + " | " + hour.Humidity;
                            image.windSpeedLabel.Text = hour.WindSpeed.ToString() + " " + hour.WindDirection;
                            image.dateLabel.Text = hour.Timestamp.ToString("ddd HH") + ":00";
                            image.Attributes.Add("class", "float-left");
                            //WeatherForecastPanel.Controls.Add(image);
                            cell.Attributes.Add("onmouseover", @"this.style.backgroundColor='white'; this.style.width='50px'");
                            cell.Attributes.Add("onmouseout", @"this.style.backgroundColor='transparent';");
                            cell.Controls.Add(image);

                            index++;
                            i++;
                        }
                    }
                    WeatherForecastPanel.Visible = true;
                }
        }
        private void DownLoadFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                string name = Path.GetFileName(filePath);
                string ext = Path.GetExtension(filePath);
                Response.AppendHeader("content-disposition", "attachment; filename=" + name);
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                //Response.WriteFile(filePath,true);
                Response.TransmitFile(filePath);
                Response.End();
            }
        }
        private void ExportGridToResponse()
        {
            string fileName = SiteListDD.SelectedValue + "_" + BlockListDD.SelectedValue + "_" + FileTypeSelection.SelectedValue + ".xls";
            //Build the Text file data.
            string txt = string.Empty;

            foreach (TableCell cell in ForecastDataGridView.HeaderRow.Cells)
            {
                //Add the Header row for Text file.
                txt += cell.Text + "\t";
            }
            //Add new line.
            txt += "\r\n";
            foreach (GridViewRow row in ForecastDataGridView.Rows)
            {
                foreach (TableCell cell in row.Cells)
                {
                    //Add the Data rows.
                    txt += cell.Text + "\t";
                }
                //Add new line.
                txt += "\r\n";
            }
            HttpResponse Response = System.Web.HttpContext.Current.Response;
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename="+fileName);
            Response.Charset = "";
            //Response.ContentType = "text/plain";
            Response.ContentType = "application/vnd.ms-excel";
            Response.Output.Write(txt);
            Response.Flush();
            Response.End();
        }
        private void ExportGridToFile()
        {
            string fileName = SiteListDD.SelectedValue + "_" + BlockListDD.SelectedValue + "_" + FileTypeSelection.SelectedValue + ".txt";
            //var directory = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);
            var directory = Properties.Settings.Default.DataPath;
            var path = Path.Combine(directory, fileName);

            DataTable dataTable = new DataTable();

            //Add columns to DataTable.
            foreach (TableCell cell in ForecastDataGridView.HeaderRow.Cells)
                dataTable.Columns.Add(cell.Text);

            //Loop through the GridView and copy rows.
            foreach (GridViewRow row in ForecastDataGridView.Rows)
            {
                dataTable.Rows.Add();
                for (int k = 0; k < row.Cells.Count; k++)
                {
                    dataTable.Rows[row.RowIndex][k] = row.Cells[k].Text;
                }
            }

            DataForecast.WriteDataTableToFile(dataTable, path, true);

            // Write file created above to the http response
            DownLoadFile(path);
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            return;
        }
        private void UpdateReportList()
        {
            if (!string.IsNullOrEmpty(BlockListDD.SelectedValue) && SiteListDD.SelectedValue != "None")
            {
                var path = VariableListFilePath();
                var dt = ReadConfigFileIntoDataTable(path);
                var result = from p in dt.AsEnumerable()
                             where p["Site"].ToString() == _selectedSite && p["Block"].ToString() == _selectedBlock
                             select new { name = p["Name"].ToString() };
                var removeResult = from p in dt.AsEnumerable()
                                   where p["Site"].ToString() != _selectedSite || p["Block"].ToString() != _selectedBlock
                                   select new { name = p["Name"].ToString() };
                foreach (var item in result)
                {
                    if (!FileTypeSelection.Items.Contains(new ListItem(item.name.ToString())))
                        FileTypeSelection.Items.Add(item.name);
                }
                foreach (var item in removeResult)
                {
                    if (FileTypeSelection.Items.Contains(new ListItem(item.name.ToString())))
                        FileTypeSelection.Items.Remove(item.name);
                }
            }
        }

        // Button , Radio Button , CheckBox based events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;

            
            Label1.Attributes.Add("style", "font-family:Arial");
            // Set the drop down box for the site List
            var directoryPaths = Database.ImportSiteFolder();
            List<string> siteList = new List<string>();
            List<string> blockList = new List<string>();

            // usage of Query String
            var siteName = Request.QueryString["Site"];
            if (!string.IsNullOrEmpty(siteName))
            {
                if (siteName != "All")
                    siteList.Add(siteName);
                else if (siteName == "All")
                {
                    siteList.Add("None");
                    foreach (var path in directoryPaths)
                    {
                        siteList.Add(path.Site);
                    }
                    siteList = siteList.Distinct().ToList();
                }
 
                // Remove the event for site selection from the page...
            }

            // siteList based on Market
            var marketName = Request.QueryString["Market"];
            MarketLabel.Text = marketName;
            if (!string.IsNullOrEmpty(marketName))
            {
                siteList.Add("None");
                foreach (var path in directoryPaths)
                {
                    var market = path.Market;
                    if (market == marketName)
                    {
                        siteList.Add(path.Site);
                    }
                    siteList = siteList.Distinct().ToList();
                }
            }
            else
            {
                var settingButton = (HtmlInputButton)FindControl("SettingButton");
                settingButton.Visible = false;
            }

            foreach (var site in siteList.Distinct().ToList())
            {
                SiteListDD.Items.Add(site);
            }
            SiteListDD.SelectedIndex = 0;
            _selectedSite = SiteListDD.SelectedValue;

            if (!string.IsNullOrEmpty(_selectedSite))
            {
                foreach (var path in directoryPaths)
                {
                    var sitename = path.Site;
                    if (sitename == _selectedSite)
                    {
                        var blockname = path.Block;
                        blockList.Add(blockname);
                    }
                }

                foreach (var block in blockList.Distinct().ToList())
                {
                    BlockListDD.Items.Add(block);
                }
                BlockListDD.SelectedIndex = 0;
                _selectedBlock = BlockListDD.SelectedValue;
            }

            if (_selectedSite != null && _selectedSite != "None")
            {
                UpdateTableOrChart(false, false);
            }
        }
        protected void OnChartRadioCheckedChanged(object sender, EventArgs e)
        {
            if (chartRadio.Checked)
            {
                MultiView1.ActiveViewIndex = (int)SearchType.Chart;
                isDerate = false;
                ForecastChartControl1.Visible = true;
                BarChartControl1.Visible = false;
                PlotChartOrTable();
            }
            else
                MultiView1.ActiveViewIndex = (int)SearchType.NotSet;
        }
        protected void OnTableRadioCheckedChanged(object sender, EventArgs e)
        {
            if (tableRadio.Checked)
            {
                MultiView1.ActiveViewIndex = (int)SearchType.Table;
                PlotChartOrTable();
            }
            else
                MultiView1.ActiveViewIndex = (int)SearchType.NotSet;
        }
        protected void OnSiteListDDSelectedIndexChanged(object sender, EventArgs e)
        {
            if (chartRadio.Checked) MultiView1.ActiveViewIndex = 0; else MultiView1.ActiveViewIndex = 1;

            //populate the block list drop down box
            var directoryPaths = Database.ImportSiteFolder();
            _selectedSite = SiteListDD.SelectedValue;

            if (string.IsNullOrEmpty(_selectedSite) || _selectedSite == "None") return;

            List<string> blockList = new List<string>();
            foreach (var path in directoryPaths)
            {
                var sitename = path.Site;
                var blockname = path.Block;
                if (sitename == _selectedSite)
                    blockList.Add(blockname);
            }
            BlockListDD.DataSource = blockList.Distinct();
            BlockListDD.DataBind();

            _selectedBlock = BlockListDD.SelectedValue;
            UpdateReportList();
            // Based on the file availability update the FileSelectionTypeDropDown
            if (_selectedSite != null)
            {
                PlotChartOrTable();

                // As weather forecast is Site specific call this when Site is Changed.
                UpdateWeatherForecast();
            }
        }
        
        protected void OnBlockListDDSelectedIndexChanged(object sender, EventArgs e)
        {
            if (chartRadio.Checked) MultiView1.ActiveViewIndex = 0; else MultiView1.ActiveViewIndex = 1;
            _selectedBlock = BlockListDD.SelectedValue;
            _selectedSite = SiteListDD.SelectedValue;
            UpdateReportList();
            // every time a block is changed replot the charts or Tables
            PlotChartOrTable();
        }
        protected void OnRealTimeRadioCheckedChanged(object sender, EventArgs e)
        {
            if (chartRadio.Checked) MultiView1.ActiveViewIndex = 0; else MultiView1.ActiveViewIndex = 1;
            ForecastConfig f = new ForecastConfig();
            f.isDayAhead = false;
            f.areAllData = false;
            _selectedBlock = BlockListDD.SelectedValue;
            _selectedSite = SiteListDD.SelectedValue;
            UpdateTableOrChart(f.isDayAhead, f.areAllData);
        }
        protected void OnDayAheadRadioCheckedChanged(object sender, EventArgs e)
        {
            if (chartRadio.Checked) MultiView1.ActiveViewIndex = 0; else MultiView1.ActiveViewIndex = 1;
            ForecastConfig f = new ForecastConfig();
            f.isDayAhead = true;
            f.areAllData = false;
            _selectedBlock = BlockListDD.SelectedValue;
            _selectedSite = SiteListDD.SelectedValue;
            UpdateTableOrChart(f.isDayAhead, f.areAllData);
        }
        protected void OnAllRadioCheckedChanged(object sender, EventArgs e)
        {
            if (chartRadio.Checked) MultiView1.ActiveViewIndex = 0; else MultiView1.ActiveViewIndex = 1;
            ForecastConfig f = new ForecastConfig();
            f.isDayAhead = false;
            f.areAllData = true;
            _selectedBlock = BlockListDD.SelectedValue;
            _selectedSite = SiteListDD.SelectedValue;
            UpdateTableOrChart(f.isDayAhead, f.areAllData);
        }
        protected void OnWeatherForecastClick(object sender, EventArgs e)
        {
            dlButton.Visible = false;
            MultiView1.ActiveViewIndex = 3;
            ForecastChartPanel.Enabled = false;

            UpdateWeatherForecast();
        }
        protected void OnGetRunningStatusClick(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
            ForecastChartPanel.Enabled = false;

            var equipStatuses = Database.ImportEquipmentStatus();
            int i = 0;
            foreach (TableRow row in EquipmentStatusTable.Rows)
            {
                foreach (TableCell cell in row.Cells)
                {
                    if (i > equipStatuses.Count - 1) break;
                    RunningStatusUserControl rsUC = LoadControl("~/UserControls/RunningStatusUserControl.ascx") as RunningStatusUserControl;
                    rsUC.Label1.Text = equipStatuses[i].Alias;
                    rsUC.Button1.BackColor = System.Drawing.Color.Green;
                    cell.Attributes.Add("onmouseover", @"this.style.backgroundColor='lightblue';");
                    cell.Attributes.Add("onmouseout", @"this.style.backgroundColor='transparent';");
                    cell.Controls.Add(rsUC);
                    cell.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;&nbsp;"));
                    i++;

                }
                //row.Controls.Add(new LiteralControl("<br><br>"));
            }
        }
        protected void OnDownloadClick(object sender, EventArgs e)
        {
            var directoryPath = Database.ImportSiteFolder();
            foreach (var path in directoryPath)
            {
                if (_selectedBlock == path.Block)
                {
                    if (FileTypeSelection.SelectedValue == "Trader") DownLoadFile(path.ForecastPath);
                    else if (FileTypeSelection.SelectedValue == "Operator")
                        DownLoadFile(path.ForecastPath.Replace("Trader", "Plant"));
                    else if (FileTypeSelection.SelectedValue == "RawFile")
                        DownLoadFile(path.ForecastPath.Replace("Trader", "Forecast").Replace("xls", "txt"));
                    else if (FileTypeSelection.SelectedValue == "Formula")
                        DownLoadFile(path.ForecastPath.Replace("Trader", "ForecastFormula"));
                }
            }
        }
        protected void OnFileTypeSelectionSelectedIndexChanged(object sender, EventArgs e)
        {
            if (chartRadio.Checked) MultiView1.ActiveViewIndex = 0; else MultiView1.ActiveViewIndex = 1;
            MultiView1.ActiveViewIndex = (int)SearchType.Table;
            PlotChartOrTable();
        }
        protected void ExportRawFile()
        {
            var sites = Database.ImportSiteFolder();
            if (sites == null) return;

            foreach (var site in sites)
            {
                // Make sure valid line
                if (string.IsNullOrEmpty(site.Site)) continue;


                if (_selectedSite == site.Site && _selectedBlock == site.Block)
                {
                    string rawFilePath = site.ForecastPath;
                    var directory = Path.GetDirectoryName(rawFilePath);
                    var files = Directory.GetFiles(directory);
                    DownLoadFile(rawFilePath);
                }
            }
        }
        protected void OnGetForecastButtonClick(object sender, EventArgs e)
        {
            if (chartRadio.Checked)
                MultiView1.ActiveViewIndex = 0;
            else
                MultiView1.ActiveViewIndex = 1;
            PlotChartOrTable();
        }
        protected void OnDownloadButtonClick(object sender, EventArgs e)
        {
            //ExportGridToFile();
            if (FileTypeSelection.SelectedValue != "RawFile")
                ExportGridToResponse();
            else
                ExportRawFile();
        }
        // Replot the graph on reLoad or modification of Derate
        protected void OnRefreshButtonClick(object sender, ImageClickEventArgs e)
        {
            if (chartRadio.Checked) MultiView1.ActiveViewIndex = 0; else MultiView1.ActiveViewIndex = 1;
            PlotChartOrTable();
        }

        // Plot bar charts for operating modes
        protected void OnOperatingModeButtonClick(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = (int)SearchType.Chart;

            //hide the multi chart control
            ForecastChartControl1.Visible = false;

            // display the single chart
            BarChartControl1.Visible = true;

            DataTable mergedDataTable = new DataTable();

            StringBuilder siteBlockFilter = new StringBuilder();
            siteBlockFilter.Append("*");
            siteBlockFilter.Append(SiteListDD.SelectedValue);
            siteBlockFilter.Append("_" + BlockListDD.SelectedValue);
            siteBlockFilter.Append("*");

            var directoryPath = Database.ImportSiteFolder();

            string performanceDirectory = string.Empty;
            foreach (var path in directoryPath)
            {
                if (SiteListDD.SelectedValue == path.Site && BlockListDD.SelectedValue == path.Block)
                {
                    performanceDirectory = path.PerformancePath;
                }
            }

            // Get the list of operating modes from flat file
            List<string> variables = new List<string>();
            var operatingModes = Database.ImportOperatingModes().Where(r => r.Site == SiteListDD.SelectedValue && r.Block == BlockListDD.SelectedValue).Select(r => r).ToList();
            foreach(var mode in operatingModes)
            {
                List<string> vars = PerformanceHelper.ExtractVariablesFromExpression(mode.Criteria);
                variables.AddRange(vars);
            }

            // Make sure directory exists
            if (!Directory.Exists(performanceDirectory)) return;

            var performanceFiles = Directory.GetFiles(performanceDirectory, siteBlockFilter.ToString()).OrderByDescending(r => r).ToList();
            CancellationTokenSource cts = new CancellationTokenSource();
            foreach (var file in performanceFiles)
            {
                var perDayTable = DailyPerformanceFile.ReadFile(file,variables.Distinct().ToList(), null, cts.Token, 1);
                if(perDayTable!=null)
                    mergedDataTable.Merge(perDayTable, false, MissingSchemaAction.Add);
            }

            // sort the table, Order by timestamp
            var orderedRows = from row in mergedDataTable.AsEnumerable()
                              let date = row.Field<DateTimeOffset>("Timestamp")
                              orderby date
                              select row;
            DataTable sortedTable = orderedRows.CopyToDataTable();

            List<OperatingModeResultList> list = OperatingModeAnalysis.GetOperatingModeGroups(sortedTable, operatingModes, Dates.Grouping.Day);

            // take last 4 days data by default
            var tmax = DateTime.Now;
            var tmin = DateTime.Now.AddDays(-10);

            chartTitle.Text = "Operating Modes From " + tmin.ToString("yyyy-MM-dd") +
                " to " + tmax.ToString("yyyy-MM-dd");

            ForecastChartUtilities forecastUtilities = new ForecastChartUtilities();
            var control = forecastUtilities.ShowOperatingModesChart(BarChartControl1,list, 1);
        }

        // RowDataBound events of GridView
        protected void ForecastDataGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells.Count > 15)
                        e.Row.Cells[i].Attributes.Add("style", "white-space: nowrap;");
                    else
                        e.Row.Cells[i].Attributes.Add("style", "font-family:Arial;");
                }
            }
            if (e.Row.RowType == DataControlRowType.Header)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells.Count > 15)
                        e.Row.Cells[i].Attributes.Add("style", "white-space: nowrap;");
                    else
                        e.Row.Cells[i].Attributes.Add("style", "font-family:Arial;");
                }
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    BoundField field = (BoundField)((DataControlFieldCell)e.Row.Cells[i]).ContainingField;

                    // Change the background color of the column that are derated
                    // The derated column are detected by the column Name containing **
                    if (field.HeaderText.Contains("**"))
                    {
                        e.Row.Cells[i].Attributes.Add("style", "background-color:#add8e6");
                    }
                }
            }
        }
        protected void ForecastDataGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
        protected void MinMaxAvgGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Remove blank spaces in the cell conntent
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells.Count > 15)
                        e.Row.Cells[i].Attributes.Add("style", "white-space: nowrap;");
                    else
                        e.Row.Cells[i].Attributes.Add("style", "font-family:Arial;");
                }
            }
            // Same for the headers
            if (e.Row.RowType == DataControlRowType.Header)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells.Count > 15)
                        e.Row.Cells[i].Attributes.Add("style", "white-space: nowrap;");
                    else
                        e.Row.Cells[i].Attributes.Add("style", "font-family:Arial;");
                }
            }
        }

       
    }
}
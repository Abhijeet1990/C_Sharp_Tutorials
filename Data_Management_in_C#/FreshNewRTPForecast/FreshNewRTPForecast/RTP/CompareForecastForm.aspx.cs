using RTPWebForecastService;
using RTPWebForecastService.Infrastructure;
using RTP.Forecast;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using RTP.Performance;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RTP.DataServer;

using System.Drawing;

namespace RTPWebForecastService
{
    public partial class CompareForecastForm : System.Web.UI.Page
    {
        private string _siteName;
        private string _blockName;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            
            SelectDateCalendar.SelectedDate = DateTime.Now;
            SelectHourDropDown.SelectedValue = "07";
            _siteName = Request.QueryString["Site"];
            _blockName = Request.QueryString["Block"];
            string siteBlock = string.Format("Site: {0} Block: {1}",_siteName ,_blockName );
            SiteBlockLabel.Text = siteBlock;
            ShowComparisonCharts();
            
        }

        protected void OnCompareButtonClicked(object sender, EventArgs e)
        {
            ShowComparisonCharts();
        }

        private void ShowComparisonCharts()
        {
            _siteName = Request.QueryString["Site"];
            _blockName = Request.QueryString["Block"];

            //ForecastData And PerformanceData
            DataTable forecast = new DataTable();
            DataTable performance = new DataTable();

            string[] seriesList = new string[ForecastChartControl1.chart1.Series.Count];
            string[] forecastList = new string[ForecastChartControl1.chart1.Series.Count];
            for (int i = 0; i < ForecastChartControl1.chart1.Series.Count; i++)
            {
                seriesList[i] = string.Empty;
                forecastList[i] = string.Empty;
            }

            // Get the latest Date and Hour
            DateTime selectedDate = SelectDateCalendar.SelectedDate;
            DateTime compareDate = selectedDate.AddDays(-1);

            int hour = SelectHourDropDown.SelectedIndex;
            DateTime compareDateTime = new DateTime(compareDate.Year, compareDate.Month, compareDate.Day, hour, 00, 00);

            StringBuilder siteBlockFilter = new StringBuilder();
            siteBlockFilter.Append("*");
            siteBlockFilter.Append(_siteName);
            siteBlockFilter.Append("_" + _blockName);
            siteBlockFilter.Append("*");

            string filePath = string.Empty;

            // Get the archive and performance path from properties settings
            var directoryPath = Database.ImportSiteFolder();
            string archiveDirectory = string.Empty;
            string performanceDirectory = string.Empty;
            foreach (var path in directoryPath)
            {
                
                if (_siteName == path.Site && _blockName == path.Block)
                {
                    archiveDirectory = path.ArchivePath;
                    performanceDirectory = path.PerformancePath;
                }
            }

            // Get the required forecast archive file the date selected minus one day (sorted order important)
            var files = Directory.GetFiles(archiveDirectory, siteBlockFilter.ToString()).OrderByDescending(r => r);

            foreach (var file in files)
            {
                var parse = Path.GetFileNameWithoutExtension(file).Split('_')[0];
                var dateTime = DataForecast.ExtractDateTimeFromString(parse);
                if (dateTime > compareDateTime) continue;
                else
                {
                    filePath = file;
                    break;
                }
            }

            // Read the forecast file into datatable (will be one day before the selected day)
            if (File.Exists(filePath))
            {
                forecast = RTP.Forecast.FileUtilities.ReadForecastFileIntoDataTable(Path.Combine(archiveDirectory, filePath));
            }
            // Get the list of Variables for the forecast either from the Property settings or from the flat files
            // Get the class from the settings
            List<Infrastructure.ChartSeries> chartList =Database.ImportChartSeries().Where(r=>r.Site==_siteName && r.Block==_blockName).ToList();

            // Load the Charts
            List<string> series = chartList.Select(m => m.Alias).ToList();

            for (int i = 0; i < ForecastChartControl1.chart1.Series.Count; i++)
            {
                if (series.Contains(ForecastChartControl1.chart1.Series[i].Name))
                {
                    seriesList[i] = ForecastChartControl1.chart1.Series[i].Name;
                    forecastList[i] = chartList.Where(d => d.Alias == ForecastChartControl1.chart1.Series[i].Name).Select(f => f.Name).FirstOrDefault().ToString();
                }
            }

            // need to filter forecast table for selected date
            var filteredForecast = forecast.AsEnumerable().Where(r => ((DateTime)r["Timestamp"]).Day == selectedDate.Day);
            if (filteredForecast == null || filteredForecast.Count() == 0) return;
            forecast = filteredForecast.CopyToDataTable();

            // Get the performance file for the date selected
            PerformanceSearchAsync search = new PerformanceSearchAsync();

            // Get list of actual variables to plot on the charts
            var variables = from l in Database.ImportChartSeries()                          
                            where l.Site == _siteName && l.Block == _blockName &&
                            l.Alias.Contains("*")
                            select l.Name;


            // Get the correct performance file
            string performanceFilePath = string.Empty;
            var performanceFiles = Directory.GetFiles(performanceDirectory, siteBlockFilter.ToString()).OrderByDescending(r => r);

            foreach (var file in performanceFiles)
            {
                var parse = Path.GetFileNameWithoutExtension(file).Split('_')[0];
                var dateTime = DateTime.MinValue;
                DateTime.TryParse(parse, out dateTime);
                if (dateTime.Date == selectedDate.Date)
                    performanceFilePath = file;
            }

            // Retrieve actual performance values
            CancellationTokenSource cts = new CancellationTokenSource();
            performance = DailyPerformanceFile.ReadFile(performanceFilePath,null, null, cts.Token, 1);

            // Merget the forecast table and performance table
            var result = MergeDataTables(forecast, performance, variables.ToList());

            // Call the function to plot the charts..in this plot all the variables for perfromance in dotted lines and the forecasted ones in the solid line
            ForecastChartUtilities forecastUtilities = new ForecastChartUtilities(seriesList.ToList());

            // Load all the Charts
            DateTime tmin1 = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, 00, 00, 00);
            DateTime tmax1 = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, 23, 59, 59);

            //compare page title
            string title = string.Format("Comparing {0} Hrs Day-Ahead Forecast with {1} Actual ", compareDateTime.ToString("yyyy-MM-dd hh"), selectedDate.ToString("yyyy-MM-dd"));
            TitleLabel.Text = title;

            forecastUtilities.LoadAllChartAreas(ref ForecastChartControl1.chart1, tmax1, tmin1, result, forecastList, seriesList, false, false);

            PageLoadLabel.Text="false";
        }

        private DataTable JoinTable(DataTable dataTable1,DataTable dataTable2)
        {
            DataTable targetTable = dataTable1.Clone();
            var dt2Columns = dataTable2.Columns.OfType<DataColumn>().Select(dc =>
            new DataColumn(dc.ColumnName, dc.DataType, dc.Expression, dc.ColumnMapping));
            var dt2FinalColumns = from dc in dt2Columns.AsEnumerable()
                                  where targetTable.Columns.Contains(dc.ColumnName) == false
                                  select dc;
            targetTable.Columns.AddRange(dt2FinalColumns.ToArray());
            var rowData = from row1 in dataTable1.AsEnumerable()
                          join row2 in dataTable2.AsEnumerable()
                          on row1.Field<DateTime>("Timestamp") equals row2.Field<DateTime>("Timestamp")
                          select row1.ItemArray.Concat(row2.ItemArray.Where(r2 => row1.ItemArray.Contains(r2) == false)).ToArray();
            foreach (object[] values in rowData)
                targetTable.Rows.Add(values);

            return targetTable;
        }
        private DataTable MergeDataTables(DataTable forecast,DataTable performance,List<string> variables)
        {
            // Make sure data in the tables and variables
            if (forecast == null || forecast.Rows.Count == 0 || performance == null || performance.Rows.Count == 0||variables==null) return forecast;

            int forecastSamples = forecast.Rows.Count;
            int perfSamples = performance.Rows.Count;

            // Need to add additional columns to forecast table
            foreach (var variable in variables)
            {
                if (!forecast.Columns.Contains(variable))
                        forecast.Columns.Add(variable, typeof(double));
            }

            int firstX = 0;

            // initialize found flag
            var found = false;

            for (int n = 0; n < forecastSamples; n++)
            {
                // Get row data for the forecast
                DataRow forecastRow = forecast.Rows[n];

                // Get current row timestamp of forecast
                DateTime timestampY = ((DateTime)forecastRow["Timestamp"]).ToUniversalTime();
                long secondsY = timestampY.Ticks/ 10000000;

                DataRow rowX = forecast.Rows[n];
                found = false;

                for (int nx = firstX; nx < perfSamples; nx++)
                {                     
                    // Get the next X timestamp (are UTC)
                    rowX = performance.Rows[nx];
                    DateTimeOffset timestampX = (DateTimeOffset)rowX["Timestamp"];
                    long secondsX = timestampX.Ticks / 10000000;

                    // Compute the time difference
                    long diff = secondsX - secondsY;

                    double span = (timestampX - timestampY).TotalSeconds;

                    // Are the timestamps within 30 seconds of each other?
                    if ((-30 < diff) && (diff <= 30))
                    {
                        firstX = nx;
                        found = true;
                        break;
                    }

                    // Have we gone past the Y timestamp?
                    if (diff > 30)
                    {
                        found = false;
                        break;
                    }

                }

                // Add data to the row in the forecast table
                foreach (var variable in variables)
                {
                    if (performance.Columns.Contains(variable) && found)
                        forecastRow[variable] = rowX[variable];
                    else
                        forecastRow[variable] = 0;
                }
                
            }
            return forecast;
        }
        protected void OnSelectDateCalendarDayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date < DateTime.Now.AddDays(-10) || e.Day.Date > DateTime.Now)
            {
                e.Day.IsSelectable = false;
            }
        }

        protected void OnSelectHourDropDownSelectedIndexChanged(object sender, EventArgs e)
        {
            return;
            if(PageLoadLabel.Text=="false") 
               ShowComparisonCharts();
        }

        protected void OnSelectDateCalendarSelectionChanged(object sender, EventArgs e)
        {
            if(PageLoadLabel.Text == "false")
                ShowComparisonCharts();
        }

    }
}
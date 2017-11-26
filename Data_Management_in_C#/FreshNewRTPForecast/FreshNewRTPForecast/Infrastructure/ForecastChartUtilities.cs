using RTPWebForecastService.Infrastructure;
using RTPWebForecastService.UserControls;
using RTP.Analysis;
using RTP.Charts;
using RTP.DataServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.DataVisualization.Charting;

namespace RTPWebForecastService
{
    public class Result
    {
        public double Time { get; set; }
        public double Value { get; set; }
    }
    public class ForecastChartUtilities
    {
        private List<string> _chartSeries;
        private DataTable _archive;

        public ForecastChartUtilities()
        { }
        public ForecastChartUtilities(List<string> chartSeries)
        {
            _chartSeries = chartSeries;
        }

        public void LoadAllChartAreas(ref Chart chart, DateTime tmax, DateTime tmin, DataTable table, string[] forecastList, string[] seriesList, bool isDayAhead, bool areAllData)
        {
            try
            {
                //Before plotting the charts ensure the table contains all the forecastList
                DataColumnCollection columns = table.Columns;
                for (int i = 0; i < forecastList.Count(); i++)
                {
                    if (!columns.Contains(forecastList[i])) forecastList[i] = string.Empty;
                }

                // Set chart defaults
                SetChartDefaults(ref chart, table, forecastList, seriesList, areAllData);

                // Get historical data if needed
                if (isDayAhead == false && areAllData == false)
                {
                    // Get current day
                    tmax = new DateTime(tmax.Year, tmax.Month, tmax.Day, 23, 59, 59);
                    tmin = new DateTime(tmax.Year, tmax.Month, tmax.Day, 00, 00, 00);
                }
                else if (isDayAhead == true && areAllData == false)
                {
                    // Get tommorows day
                    tmax = tmax.AddDays(1);
                    tmax = new DateTime(tmax.Year, tmax.Month, tmax.Day, 23, 59, 59);
                    tmin = new DateTime(tmax.Year, tmax.Month, tmax.Day, 00, 00, 00);
                }
                else if (areAllData)
                {
                    tmin = DateTime.Parse(table.Rows[0]["Timestamp"].ToString());
                    tmin = new DateTime(tmin.Year, tmin.Month, tmin.Day, 00, 00, 00);
                    tmax = DateTime.Parse(table.Rows[table.Rows.Count - 1]["Timestamp"].ToString());
                    tmax = new DateTime(tmax.Year, tmax.Month, tmax.Day, 23, 59, 59);
                }
                _archive = table;

                // Plot the ambient Condition
                PlotAmbientConditionChartArea(ref chart, tmax, tmin, forecastList, _archive, areAllData);

                // Plot the MW chart area
                PlotMWChartArea(ref chart, tmax, tmin, forecastList, _archive, areAllData);

                // Plot Heat Rate chart areas
                PlotHeatRateChartArea(ref chart, tmax, tmin, forecastList, _archive, areAllData);
                return;
            }
            catch (Exception ex)
            { return; }
        }

        public void SetChartDefaults(ref Chart chart1, DataTable dt, string[] forecastList, string[] seriesList, bool areAllData)
        {
            // Set the series colors
            SetSeriesColorsAndChartType(ref chart1, areAllData, forecastList);

            // Set chart axis defaults
            SetChartAxisDefaults(ref chart1, dt, forecastList, seriesList, areAllData);

            // Set gridlines
            foreach (ChartArea area in chart1.ChartAreas)
            {
                area.AxisX.MajorGrid.LineColor = Color.LightGray;
                area.AxisY.MajorGrid.LineColor = Color.LightGray;
                area.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
                area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
                area.AxisY2.MajorGrid.Enabled = false;
                area.AxisX.MinorGrid.Enabled = false;
                area.AxisY.MinorGrid.Enabled = false;
            }
        }
        public void SetChartAxisDefaults(ref Chart chart, DataTable dt, string[] forecastList, string[] seriesList, bool areAllData)
        {
            // Set the X axes
            SetXAxes(ref chart, areAllData);

            // Set the Y axes titles
            SetYAxisTitles(ref chart);

            // Set the Y axes ranges
            SetYAxisRanges(ref chart, dt, forecastList, seriesList);
        }
        public void SetXAxes(ref Chart chart1, bool areAllData)
        {
            for (int i = 0; i < 3; i++)
            {
                if (!areAllData)
                {
                    chart1.ChartAreas[i].AxisX.Interval = 4;
                    chart1.ChartAreas[i].AxisX.Maximum = 24;
                    chart1.ChartAreas[i].AxisX.Minimum = 0;
                    chart1.ChartAreas[i].AxisX.MajorGrid.LineColor = Color.LightGray;
                    chart1.ChartAreas[i].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
                    chart1.ChartAreas[i].AxisX.MinorGrid.Enabled = false;
                    chart1.ChartAreas[i].AxisX.MinorGrid.Interval = 1;
                    chart1.ChartAreas[i].AxisX.MinorGrid.LineColor = Color.FromArgb(32, 0, 0, 0);
                    chart1.ChartAreas[i].AxisX.LabelStyle.Enabled = true;
                    chart1.ChartAreas[i].AxisX.IntervalType = DateTimeIntervalType.Number;
                }
                else // for all the date data
                {
                    chart1.ChartAreas[i].AxisX.MinorGrid.Enabled = true;
                }
            }
        }
        public void SetYAxisTitles(ref Chart chart1)
        {
            // TO DO: use units of measure to form names
            chart1.ChartAreas[0].AxisY.Title = "Ambient Temp, RH";
            chart1.ChartAreas[0].AxisY2.Title = "Ambient Pressure";
            chart1.ChartAreas[1].AxisY.Title = "Net MW, MW";
            chart1.ChartAreas[2].AxisY.Title = "Heat Rates";
        }
        public void SetYAxisRanges(ref Chart chart1, DataTable dt, string[] forecastList, string[] seriesList)
        {
            string[] minMax = new string[seriesList.Length];

            for (int i = 0; i < 6; i++)
            {
                if (!string.IsNullOrEmpty(forecastList[i])) minMax[i] = DataForecast.GetMinMaxValueColumn(dt, forecastList[i]);
            }

            double minY = double.MaxValue;
            double maxY = double.MinValue;
            double minY2 = double.MaxValue;
            double maxY2 = double.MinValue;

            for (int i = 0; i < 6; i++)
            {
                if (!String.IsNullOrEmpty(minMax[i]) && i!=2 && i!=5) // 2 and 5 are for Y2 max
                {
                    var minVal = Convert.ToDouble(minMax[i].Split(',')[0]);
                    var maxVal = Convert.ToDouble(minMax[i].Split(',')[1]);
                    if (minY > minVal) minY = minVal;
                    if (maxY < maxVal) maxY = maxVal;
                }
            }
            chart1.ChartAreas[0].AxisY.Maximum = Math.Ceiling(maxY * 1.05);
            chart1.ChartAreas[0].AxisY.Minimum = Math.Floor(minY * 0.95);
            chart1.ChartAreas[0].AxisY.Interval = Math.Floor((chart1.ChartAreas[0].AxisY.Maximum - chart1.ChartAreas[0].AxisY.Minimum) / 4);
            chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.FromArgb(32, 0, 0, 0);

            for (int i = 0; i < 6; i++)
            {
                if (!String.IsNullOrEmpty(minMax[i]) && (i == 2 || i == 5)) // 2 and 5 are for Y2 max
                {
                    var minVal = Convert.ToDouble(minMax[i].Split(',')[0]);
                    var maxVal = Convert.ToDouble(minMax[i].Split(',')[1]);
                    if (minY2 > minVal) minY2 = minVal;
                    if (maxY2 < maxVal) maxY2 = maxVal;
                }
            }

            chart1.ChartAreas[0].AxisY2.Maximum = Math.Ceiling(maxY2 * 1.05);
            chart1.ChartAreas[0].AxisY2.Minimum = Math.Floor(minY2 * 0.95);
            chart1.ChartAreas[0].AxisY2.Interval = Math.Floor(chart1.ChartAreas[0].AxisY2.Maximum - chart1.ChartAreas[0].AxisY2.Minimum) / 4;
            chart1.ChartAreas[0].AxisY2.MinorGrid.Enabled = false;

            // Setup the Y axis Min Max for MW
            List<double> minListMW = new List<double>();
            List<double> maxListMW = new List<double>();
            for (int i = 6; i < 17; i++)
            {
                if (!string.IsNullOrEmpty(seriesList[i]) && !string.IsNullOrEmpty(forecastList[i]))
                {
                    minMax[i] = DataForecast.GetMinMaxValueColumn(dt, forecastList[i]);
                    minListMW.Add(Convert.ToDouble(minMax[i].Split(',')[0]));
                    maxListMW.Add(Convert.ToDouble(minMax[i].Split(',')[1]));
                }
            }

            chart1.ChartAreas[1].AxisY.Maximum = Math.Floor(maxListMW.Max() * 1.05);
            chart1.ChartAreas[1].AxisY.Minimum = Math.Floor(minListMW.Min() * 0.95);
            chart1.ChartAreas[1].AxisY.Interval = Math.Floor((chart1.ChartAreas[1].AxisY.Maximum - chart1.ChartAreas[1].AxisY.Minimum) / 4);
            chart1.ChartAreas[1].AxisY.MinorGrid.Enabled = false;
            chart1.ChartAreas[1].AxisY.MinorGrid.LineColor = Color.FromArgb(32, 0, 0, 0);

            // Setup the Y axis Min Max for Heat Rates
            chart1.ChartAreas[2].AxisY.Interval = 1;
            List<double> minListHR = new List<double>();
            List<double> maxListHR = new List<double>();
            for (int i = 17; i < 23; i++)
            {
                if (!string.IsNullOrEmpty(seriesList[i]) && !string.IsNullOrEmpty(forecastList[i]))
                {
                    minMax[i] = DataForecast.GetMinMaxValueColumn(dt, forecastList[i]);
                    minListHR.Add(Convert.ToDouble(minMax[i].Split(',')[0]));
                    maxListHR.Add(Convert.ToDouble(minMax[i].Split(',')[1]));
                }
            }
            chart1.ChartAreas[2].AxisY.Maximum = Math.Floor(maxListHR.Max() * 1.2);
            chart1.ChartAreas[2].AxisY.Minimum = Math.Floor(minListHR.Min() * 0.8);
            chart1.ChartAreas[2].AxisY.Interval = Math.Floor((chart1.ChartAreas[2].AxisY.Maximum - chart1.ChartAreas[2].AxisY.Minimum) / 4);
            chart1.ChartAreas[2].AxisY.MinorGrid.Enabled = false;
            chart1.ChartAreas[2].AxisY.MinorGrid.LineColor = Color.FromArgb(32, 0, 0, 0);

        }
        public void SetSeriesColorsAndChartType(ref Chart chart1, bool areAllData, string[] forecastList)
        {
            // Ambient Condition 
            chart1.Series[0].Color = Color.FromArgb(255, 0, 0); // $/Temp Forecast
            chart1.Series[1].Color = Color.FromArgb(0, 0, 255); // $/Humidity Forecast
            chart1.Series[2].Color = Color.FromArgb(165, 42, 42); // $/Press Forecast

            chart1.Series[3].Color = Color.FromArgb(25,255, 0, 0); // $/Temp Actual
            chart1.Series[4].Color = Color.FromArgb(25,0, 0, 255); // $/Humidity Actual
            chart1.Series[5].Color = Color.FromArgb(25,165, 42, 42); // $/Press Actual

            // Set Tooltip
            if (!areAllData)
            {
                // Ambient
                chart1.Series[0].ToolTip = "Hour #VALX{#.#}" + "\n" + forecastList[0] + "= #VALY{#.#}";
                chart1.Series[1].ToolTip = "Hour #VALX{#.#}" + "\n" + forecastList[1] + "= #VALY{#.#}";
                chart1.Series[2].ToolTip = "Hour #VALX{#.#}" + "\n" + forecastList[2] + "= #VALY{#.#}";
                chart1.Series[0].LegendText = forecastList[0];
                chart1.Series[1].LegendText = forecastList[1];
                chart1.Series[2].LegendText = forecastList[2];
                chart1.Series[3].ToolTip = "Hour #VALX{#.#}" + "\n" + forecastList[0] + "= #VALY{#.#}";
                chart1.Series[4].ToolTip = "Hour #VALX{#.#}" + "\n" + forecastList[1] + "= #VALY{#.#}";
                chart1.Series[5].ToolTip = "Hour #VALX{#.#}" + "\n" + forecastList[2] + "= #VALY{#.#}";
                chart1.Series[3].LegendText = forecastList[3];
                chart1.Series[4].LegendText = forecastList[4];
                chart1.Series[5].LegendText = forecastList[5];

                // MW chart area
                chart1.Series[6].Color = Color.FromArgb(25, 0, 0, 255); // $/MW Actual
                
                for (int i = 6; i < 17; i++)
                {
                    chart1.Series[i].ToolTip = "Hour #VALX{#.#}" + "\n" + forecastList[i] + "= #VALY{#}";
                    chart1.Series[i].LegendText = forecastList[i];
                }

                // Heat Rate chart area
                var rgb = Color.OrangeRed;
                chart1.Series[17].Color = Color.FromArgb(25, rgb.R,rgb.G,rgb.B); // $/HR Actual

                for (int i = 17; i < 23; i++)
                {
                    chart1.Series[i].ToolTip = "Hour #VALX{#.#}" + "\n" + forecastList[i] + "= #VALY{#}";
                    chart1.Series[i].LegendText = forecastList[i];
                }
            }
            else
            {
                for (int i = 0; i < 23; i++)
                {
                    chart1.Series[i].ToolTip = forecastList[i] + "= #VALY{#.#}";
                    chart1.Series[i].LegendText = forecastList[i];
                }
            }

        }
        public void PlotAmbientConditionChartArea(ref Chart chart1, DateTime tmax, DateTime tmin, string[] forecastList, DataTable dt, bool areAllData)
        {  
            for (int i = 0; i < 6; i++)
            {
                PlotPoints(chart1, tmax, tmin, forecastList, dt, areAllData, i);
            }

        }
        public void PlotMWChartArea(ref Chart chart1, DateTime tmax, DateTime tmin, string[] forecastList, DataTable dt, bool areAllData)
        {
            List<Result> results = new List<Result>();

            for (int i = 6; i < 17; i++)
            {
                PlotPoints(chart1, tmax, tmin, forecastList, dt, areAllData, i);
            }
        }
        public void PlotHeatRateChartArea(ref Chart chart1, DateTime tmax, DateTime tmin, string[] forecastList, DataTable dt, bool areAllData)
        {
            List<Result> results = new List<Result>();

            for (int i = 17; i < 23; i++)
            {
                PlotPoints(chart1, tmax, tmin, forecastList, dt, areAllData,  i);
            }
        }

        private void PlotPoints(Chart chart1, DateTime tmax, DateTime tmin, string[] forecastList, DataTable dt, bool areAllData, int i)
        {
            if (chart1.Series[i].Points.Count > 0) chart1.Series[i].Points.Clear();

            if (!string.IsNullOrEmpty(forecastList[i]))
            {
                if (!areAllData)
                {
                    chart1.Series[i].XValueType = ChartValueType.Int32;
                    var results = ForecastFileUtilities.GetResultOneDay(forecastList[i], tmax, tmin, dt);
                    chart1.Series[i].Name = forecastList[i];
                    foreach (var item in results)
                    {
                        DataPoint point = new DataPoint(item.Time, item.Value);
                        if (item.Value != double.NaN || item.Time < DateTime.Now.ToOADate())
                        {
                            chart1.Series[i].Points.Add(point);
                        }
                        else
                        {
                            chart1.Series[i].Points.Add(new DataPoint(item.Time, 0) { IsEmpty = true });
                        }
                    }
                }
                else
                {
                    var data = dt.AsEnumerable().Select(x => new
                    {
                        Time = (DateTime)x["Timestamp"],
                        Value = (double)x[forecastList[i]]
                    }).ToList();
                    chart1.Series[i].XValueType = ChartValueType.Date;
                    foreach (var item in data)
                    {

                        double timestamp = item.Time.ToOADate();
                        double value = item.Value;
                        DataPoint point = new DataPoint(timestamp, value);
                        chart1.Series[i].Points.Add(point);
                    }
                }
            }
            else
            {
                chart1.Series[i].IsVisibleInLegend = false;
            }

        }

        // Plot for the Operating Modes
        public Chart ShowOperatingModesChart(BarChartControl chartControl,List<OperatingModeResultList> resultsList, int interval)
        {
            Chart chart = chartControl.Chart1;
            chart.Series.Clear();
            SetChartDefaults(chart);

            //clear title
            chart.Titles.Clear();
            chart.ChartAreas[0].AxisY.TitleFont = new Font("Arial", 11);
            chart.ChartAreas[0].AxisY.Title = "Hours of Operation Per Grouping";

            foreach (OperatingModeResultList list in resultsList)
            {
                // Create series for operating mode
                string series = list.Mode;
                if (chart.Series.IsUniqueName(series)) chart.Series.Add(series);
                chart.Series[series].ChartType = SeriesChartType.Column;
                chart.Series[series].BorderWidth = 3;
                chart.Series[series].ToolTip = list.Mode + "\n#VALX" + "\nHours = #VALY{#.#}";

                foreach (OperatingModeResults results in list.OperatingModeResults)
                {
                    chart.Series[list.Mode].Points.AddXY(results.Timestamp, results.Hours * interval);
                }
            }

            return chart;
        }

        public static void SetChartDefaults(Chart chart)
        {
            ChartArea area = chart.ChartAreas[0];
            area.AxisX.MajorGrid.LineColor = Color.LightGray;
            area.AxisY.MajorGrid.LineColor = Color.LightGray;
            area.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
            area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
            area.AxisY2.MajorGrid.Enabled = false;
            area.AxisX.MinorGrid.Enabled = false;
            area.AxisY.MinorGrid.Enabled = false;
            area.AxisX.IntervalType = DateTimeIntervalType.Days;
            area.AxisY.IntervalType = DateTimeIntervalType.Number;

            if (chart.Titles.Count == 0) chart.Titles.Add("Title");
            chart.Titles[0].Font = new Font("Arial", 11);

            foreach (Axis axis in chart.ChartAreas[0].Axes)
            {
                double min = axis.ScaleView.ViewMinimum;
                double max = axis.ScaleView.ViewMaximum;
                AutoScaleAxis(axis, max, min);
            }

        }

        public static string AutoScaleAxis(Axis axis, Double max, Double min)
        {
            // Make sure NaN
            if (double.IsNaN(max) || double.IsNaN(min)) return "Max/Min not valid numbers";

            try // Use try in case bad value caused by mouse wheel
            {
                if (axis.IntervalType == DateTimeIntervalType.Number ||
                        axis.IntervalType == DateTimeIntervalType.Auto)
                {
                    // Set min/max of axis
                    AxisAutoScaler scaler = new AxisAutoScaler(max, min);
                    axis.Interval = scaler.major;
                   

                    // Set Grid Intervals
                    axis.MajorGrid.Interval = scaler.major;
                    axis.MinorGrid.Interval = scaler.minor;

                    // Set Tick Mark Intervals
                    axis.MajorTickMark.Interval = scaler.major;
                    axis.MinorTickMark.Interval = scaler.minor;
                    axis.LabelStyle.Format = RTP.Charts.Utilities.DecimalFormat(scaler.major);
                }

                else
                {
                    double iMajorInterval = 0;
                    double iMinorInterval = 0;
                    DateTimeIntervalType majDTIT = DateTimeIntervalType.Days;
                    DateTimeIntervalType minDTIT = DateTimeIntervalType.Days;
                    string chartAxisLabelFormat = string.Empty;

                    // Algorithm to determine best time scale intervals
                    double test = DateTime.MaxValue.ToOADate();
                    DateTimeOffset viewMax = DateTime.FromOADate(max);
                    DateTimeOffset viewMin = DateTime.FromOADate(min);
                    TimeSpan timeAxisSpan = (viewMax - viewMin);

                    if (timeAxisSpan.TotalMinutes <= 10)
                    {
                        iMajorInterval = 1;
                        iMinorInterval = .5;
                        majDTIT = DateTimeIntervalType.Minutes;
                        minDTIT = DateTimeIntervalType.Minutes;
                        chartAxisLabelFormat = "HH:mm" + "\n" + "MMM-d";
                    }
                    else if (timeAxisSpan.TotalHours <= 1)
                    {
                        iMajorInterval = 10;
                        iMinorInterval = 5;
                        majDTIT = DateTimeIntervalType.Minutes;
                        minDTIT = DateTimeIntervalType.Minutes;
                        chartAxisLabelFormat = "HH:mm" + "\n" + "MMM-d";
                    }
                    else if (timeAxisSpan.TotalHours <= 2)
                    {
                        iMajorInterval = 30;
                        iMinorInterval = 15;
                        majDTIT = DateTimeIntervalType.Minutes;
                        minDTIT = DateTimeIntervalType.Minutes;
                        chartAxisLabelFormat = "HH:mm" + "\n" + "MMM-d";
                    }
                    else if (timeAxisSpan.TotalHours <= 4)
                    {
                        iMajorInterval = 1;
                        iMinorInterval = 30;
                        majDTIT = DateTimeIntervalType.Hours;
                        minDTIT = DateTimeIntervalType.Minutes;
                        chartAxisLabelFormat = "HH:mm" + "\n" + "MMM-d";
                    }

                    else if (timeAxisSpan.TotalHours <= 12)
                    {
                        iMajorInterval = 1;
                        iMinorInterval = 30;
                        majDTIT = DateTimeIntervalType.Hours;
                        minDTIT = DateTimeIntervalType.Minutes;
                        chartAxisLabelFormat = "HH:mm" + "\n" + "MMM-d";
                    }
                    else if (timeAxisSpan.TotalHours <= 24)
                    {
                        iMajorInterval = 4;
                        iMinorInterval = 1;
                        majDTIT = DateTimeIntervalType.Hours;
                        minDTIT = DateTimeIntervalType.Hours;
                        chartAxisLabelFormat = "HH:mm" + "\n" + "MMM-d";
                    }

                    else if (timeAxisSpan.TotalHours <= 48)
                    {
                        iMajorInterval = 6;
                        iMinorInterval = 2;
                        majDTIT = DateTimeIntervalType.Hours;
                        minDTIT = DateTimeIntervalType.Hours;
                        chartAxisLabelFormat = "HH:mm" + "\n" + "MMM-d";
                    }
                    else if (timeAxisSpan.TotalDays <= 7)
                    {
                        iMajorInterval = 1;
                        iMinorInterval = 4;
                        majDTIT = DateTimeIntervalType.Days;
                        minDTIT = DateTimeIntervalType.Hours;
                        chartAxisLabelFormat = "HH:mm" + "\n" + "MMM-d";
                    }

                    else if (timeAxisSpan.TotalDays <= 14)
                    {
                        iMajorInterval = 1;
                        iMinorInterval = 6;
                        majDTIT = DateTimeIntervalType.Days;
                        minDTIT = DateTimeIntervalType.Hours;
                        chartAxisLabelFormat = "MMM-d";
                    }
                    else if (timeAxisSpan.TotalDays <= 60)
                    {
                        iMajorInterval = 7;
                        iMinorInterval = 1;
                        majDTIT = DateTimeIntervalType.Days;
                        minDTIT = DateTimeIntervalType.Days;
                        chartAxisLabelFormat = "MMM-d";
                    }

                    else if (timeAxisSpan.TotalDays < 90)
                    {
                        iMajorInterval = 30;
                        iMinorInterval = 5;
                        majDTIT = DateTimeIntervalType.Days;
                        minDTIT = DateTimeIntervalType.Days;
                        chartAxisLabelFormat = "MMM-yy";
                    }
                    else if (timeAxisSpan.TotalDays < 180)
                    {
                        iMajorInterval = 30;
                        iMinorInterval = 5;
                        majDTIT = DateTimeIntervalType.Days;
                        minDTIT = DateTimeIntervalType.Days;
                        chartAxisLabelFormat = "MMM-yy";
                    }
                    else
                    {
                        iMajorInterval = 90;
                        iMinorInterval = 30;
                        majDTIT = DateTimeIntervalType.Days;
                        minDTIT = DateTimeIntervalType.Days;
                        chartAxisLabelFormat = "MMM-yy";
                    }

                    // Set the time axis properties
                    axis.LabelStyle.Format = chartAxisLabelFormat;

                    // Set Chart Intervals
                    axis.Interval = iMajorInterval;
                    axis.IntervalType = majDTIT;

                    // Set Grid Intervals
                    axis.MajorGrid.Interval = iMajorInterval;
                    axis.MajorGrid.IntervalType = majDTIT;
                    axis.MinorGrid.Interval = iMinorInterval;
                    axis.MinorGrid.IntervalType = minDTIT;

                    // Set Tick Mark Intervals
                    axis.MajorTickMark.Interval = iMajorInterval;
                    axis.MajorTickMark.IntervalType = majDTIT;
                    axis.MinorTickMark.Interval = iMinorInterval;
                    axis.MinorTickMark.IntervalType = minDTIT;

                    // Also rescale any striplines on the chart
                    double span = timeAxisSpan.TotalMinutes;
                    foreach (StripLine stripLine in axis.StripLines)
                    {
                        stripLine.StripWidthType = DateTimeIntervalType.Minutes;
                        stripLine.StripWidth = span / 60;
                    }
                }

                //axis.ScaleView.Zoom(min, max);

                return string.Empty;
            }
            catch (Exception ex)
            { return ex.Message; }
        }
    }
}
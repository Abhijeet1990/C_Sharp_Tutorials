using RTP.Analysis;
using RTP.DataServer;
using RTP.Forecast;
using RTP.Performance;
using RTP.Weather;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;

namespace RTPWebForecastService.Infrastructure
{
    public class DataForecast
    {
        public class ForecastConfig
        {
            public bool isDayAhead { get; set; }
            public bool areAllData { get; set; }
        }
        
        public static string DerateFilePath()
        {
            // Get root directory of data
            var directory = Properties.Settings.Default.DataPath;
            string configDirectory = Path.Combine(directory, "Config");
            string deratePath = Path.Combine(configDirectory, "Derate.txt");

            //column Names array
            string[] colNames = new string[11] { "ID", "Active", "Name", "Site", "Block", "ForecastName", "DerateType", "Value", "Criteria", "Expiration", "Reason" };
            var initialString = String.Join("\t", colNames.ToList()) + Environment.NewLine;

            // Make sure exits, if not, create it
            if (!Directory.Exists(configDirectory))
            {
                // Create Directory
                Directory.CreateDirectory(configDirectory);

                // Also need to create Derate.txt file
                deratePath = Path.Combine(configDirectory, "Derate.txt");
                File.WriteAllText(deratePath, initialString);
            }

            // Make sure at least an empty file exists
            if (!File.Exists(deratePath))
                File.WriteAllText(deratePath, initialString);

            return deratePath;

        }
        public static string VariableListFilePath()
        {
            // Get root directory of data
            var directory = Properties.Settings.Default.DataPath;
            string configDirectory = Path.Combine(directory, "Config");
            string variablePath = Path.Combine(configDirectory, "Report.txt");

            //column Names array
            string[] colNames = new string[6] { "ID", "Name", "Site", "Block", "Variables","Market" };
            var initialString = String.Join("\t", colNames.ToList()) + Environment.NewLine;

            // Make sure exits, if not, create it
            if (!Directory.Exists(configDirectory))
            {
                // Create Directory
                Directory.CreateDirectory(configDirectory);

                // Also need to create Derate.txt file
                variablePath = Path.Combine(configDirectory, "Report.txt");
                File.WriteAllText(variablePath, initialString);
            }

            // Make sure at least an empty file exists
            if (!File.Exists(variablePath))
                File.WriteAllText(variablePath, initialString);

            return variablePath;

        }
        public static string ChartSeriesListFilePath()
        {
            // Get root directory of data
            var directory = Properties.Settings.Default.DataPath;
            string configDirectory = Path.Combine(directory, "Config");
            string seriesPath = Path.Combine(configDirectory, "Chart.txt");

            //column Names array
            string[] colNames = new string[8] { "ID", "Name", "Site", "Block", "Chart1","Chart2","Chart3", "Market" };
            var initialString = String.Join("\t", colNames.ToList()) + Environment.NewLine;

            // Make sure exits, if not, create it
            if (!Directory.Exists(configDirectory))
            {
                // Create Directory
                Directory.CreateDirectory(configDirectory);

                // Also need to create Derate.txt file
                seriesPath = Path.Combine(configDirectory, "Chart.txt");
                File.WriteAllText(seriesPath, initialString);
            }

            // Make sure at least an empty file exists
            if (!File.Exists(seriesPath))
                File.WriteAllText(seriesPath, initialString);

            return seriesPath;

        }
        public static string GetAppLogFilePath(string filename)
        {

            var path = AppDomain.CurrentDomain.BaseDirectory;
            path = Path.Combine(path, filename);
            return path;
        }
        public static string GetMinMaxAvgValueColumn(DataTable dt, string colName)
        {
            double min = double.MaxValue;
            double max = double.MinValue;
            double sum = 0.0;
            foreach (DataRow dr in dt.Rows)
            {
                if (dt.Columns.Contains(colName))
                {
                    var reference = dr.Field<double>(colName);
                    sum += reference;
                    min = Math.Min(min, reference);
                    max = Math.Max(max, reference);
                }
            }
            var avg = Math.Round(sum / dt.Rows.Count, 0, MidpointRounding.AwayFromZero);
            StringBuilder minMaxAvg = new StringBuilder();
            minMaxAvg.Append(min.ToString());
            minMaxAvg.Append(',');
            minMaxAvg.Append(max.ToString());
            minMaxAvg.Append(',');
            minMaxAvg.Append(avg.ToString());
            return minMaxAvg.ToString();
        }
        public static string GetMinMaxValueColumn(DataTable dt, string colName)
        {
                double min = double.MaxValue;
                double max = double.MinValue;
                foreach (DataRow dr in dt.Rows)
                {
                    var reference = dr.Field<double>(colName);
                    min = Math.Min(min, reference);
                    max = Math.Max(max, reference);
                }
                StringBuilder minMax = new StringBuilder();
                minMax.Append(min.ToString());
                minMax.Append(',');
                minMax.Append(max.ToString());
                return minMax.ToString();

        }
        public static DataTable CheckForecastForDerate(DataTable originalDataTable, string site, string block, List<ForecastDerate> derates)
        {
            if (originalDataTable.Rows.Count < 3 || derates == null
                || site == null || block == null) return originalDataTable;

            // Need to copy the table and delete any expression schema because can not derate a read only column
            DataTable dataTable = originalDataTable.Clone();
            foreach (DataColumn column in dataTable.Columns)
            {
                column.Expression = null;  // remove expression schema
                column.ReadOnly = false;
            }

            // Copy data to new table
            foreach (DataRow row in originalDataTable.Rows)
                dataTable.ImportRow(row);

            // Make sure forecast derate exists and also has not expired or is active
            var activeSiteDerates = derates.Where(r => r.Site == site && r.Block == block && r.Active
                                    && r.Expiration > DateTime.Now).ToList();
            if (activeSiteDerates == null || activeSiteDerates.Count() == 0) return dataTable;


            // Need to verify every line in forecast in case criteria includes amb, temp, press
            foreach (DataRow row in dataTable.Rows)
            {
                foreach (var derate in derates)
                {
                    // For active derate, check forecast data column name equal to derate.siteforecast name
                    string siteForecastColumn = derate.ForecastName;
                    if (row.Table.Columns.Contains(siteForecastColumn))
                    {
                        try
                        {
                            // Get current row timestamp and see if derate has expired
                            DateTime timestamp = (DateTime)row["Timestamp"];
                            if (timestamp > derate.Expiration) continue;

                            // Get column value
                            double value = 0; double.TryParse(row[siteForecastColumn].ToString(), out value);

                            // Get rerated value
                            double derateValue = 0; double.TryParse(derate.Value.ToString(), out derateValue);

                            // Verify any criteria to see if row is affected
                            bool rowAffected = true;
                            try
                            {
                                string search = string.Empty;
                                if (!string.IsNullOrEmpty(derate.Criteria))
                                    search = string.Format("{0} and Timestamp = '{1}'", derate.Criteria, timestamp.ToString("yyyy-MM-dd HH:mm"));

                                var verifyCriteriaMet = dataTable.Select(search);
                                if (verifyCriteriaMet != null && verifyCriteriaMet.Count() > 0) rowAffected = true;
                                else rowAffected = false;
                            }
                            catch (Exception ex)
                            {

                            }

                            // If row is affected by the criteria, then apply the derate
                            if (rowAffected)
                            {
                                // Check derate type and apply change
                                double newValue = value;
                                switch (derate.DerateType)
                                {
                                    case DerateType.Decrease: newValue -= derateValue; break;
                                    case DerateType.Increase: newValue += derateValue; break;
                                    case DerateType.Maximum: newValue = value > derateValue ? derateValue : value; break;
                                    case DerateType.Minimum: newValue = value < derateValue ? derateValue : value; break;
                                    case DerateType.Multiple: newValue *= derateValue; break;
                                }
                                if (value != newValue)
                                {
                                    row[siteForecastColumn] = newValue;
                                    // Need to mark the engunits to let user know that some rows in the column have been derated
                                    if (dataTable.Columns[siteForecastColumn].ExtendedProperties.Contains("EngUnits"))
                                    {
                                        // Tag the engUnits extended property with ** to signify that a derate has been assigned to column
                                        string property = dataTable.Columns[siteForecastColumn].ExtendedProperties["EngUnits"] == null ? string.Empty :
                                            dataTable.Columns[siteForecastColumn].ExtendedProperties["EngUnits"].ToString();
                                        if (!property.Contains("**"))
                                        {
                                            property = property + "**";
                                            dataTable.Columns[siteForecastColumn].ExtendedProperties["EngUnits"] = property;
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                    else
                    {
                        // Add Datacolumn
                        DataColumn column = new DataColumn();
                        column.ColumnName = siteForecastColumn;
                        column.DefaultValue = 0;
                        column.DataType = typeof(double);
                        dataTable.Columns.Add(column);
                    }
                }
            }
            return dataTable;

        }
        public static DataTable GetFilteredForecastTable(DataTable dataTable, List<string> columns, DateTime desiredDate, bool getAll)
        {

            // Make sure datatable has rows
            if (dataTable == null || dataTable.Rows.Count == 0 || !dataTable.Columns.Contains("Timestamp")) return dataTable;

            // clone the orginal table to preserve extended properties
            var clonedDataTable = dataTable.Clone();

            // Get only next day
            var data = dataTable.AsEnumerable().Where(r => ((DateTime)r["Timestamp"]).Day == desiredDate.Day || getAll);
            if (data == null || data.Count() == 0) return dataTable;
            else
                dataTable = data.CopyToDataTable();

            // Verify datatable not null
            if (dataTable == null) return new DataTable();

            if (columns == null)
            {
                columns = dataTable.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToList();
            }

            // Get all columns of the source forecast file to compare against the custom columns
            var existingColumns = dataTable.Columns.Cast<DataColumn>().Select(r => r.ColumnName).ToList();
            if (existingColumns == null || existingColumns.Count() == 0) return dataTable;

            // Get columns to remove from dataTable
            var columnsToRemove = existingColumns.Except(columns);

            // Remove all columns not needed, but we must keep timestamp or else the hour will not display in final table
            foreach (var columnToRemove in columnsToRemove)
                if (dataTable.Columns.Contains(columnToRemove) && columnToRemove != "Timestamp")
                    dataTable.Columns.Remove(columnToRemove);

            // Now set ordinals of dataTable to match the order or the column list
            int columnIndex = 1;  // Skip timestamp column
            foreach (var columnName in columns)
            {
                // Make sure datatable contains column name
                if (!dataTable.Columns.Contains(columnName) || columnName == "Timestamp") continue;

                // Change ordinal position as necessary for ordering of columns
                dataTable.Columns[columnName].SetOrdinal(columnIndex);

                // Check for extended properties are transferred from original table
                if (!dataTable.Columns[columnName].ExtendedProperties.Contains("EngUnits"))
                {
                    var engUnits = string.Empty;
                    if (clonedDataTable.Columns[columnName].ExtendedProperties.Contains("EngUnits"))
                    {
                        engUnits = clonedDataTable.Columns[columnName].ExtendedProperties["EngUnits"].ToString();
                    }
                    dataTable.Columns[columnName].ExtendedProperties.Add("EngUnits", engUnits);
                }
                columnIndex++;
            }

            // Format values based upon engineering units in the extended property
            return dataTable;
        }
        public static double FormatForecastValue(string engUnits, double value)
        {
            // Pressure forecast
            double formattedValue = value;
            if (engUnits.ToLower().Contains("psi"))
                formattedValue = Math.Round(value, 2, MidpointRounding.AwayFromZero);
            else if (engUnits.ToLower().Contains("mbar"))
                formattedValue = Math.Round(value, 0, MidpointRounding.AwayFromZero);
            else if (engUnits.ToLower().Contains("bar"))
                formattedValue = Math.Round(value, 3, MidpointRounding.AwayFromZero);
            // Temp and Rel Humidity
            else if (engUnits.ToLower().Contains("f") || engUnits.Contains("%"))
                formattedValue = Math.Round(value, 0, MidpointRounding.AwayFromZero);
            // Load forecast
            else if (engUnits.ToLower().Contains("mw"))
                formattedValue = Math.Round(value, 0, MidpointRounding.AwayFromZero);
            else if (engUnits.ToLower().Contains("heatrate"))
                formattedValue = Math.Round(value, 3, MidpointRounding.AwayFromZero);

            return formattedValue;
        }
        public static DataTable ReadConfigFileIntoDataTable(string filename)
        {
            DataTable dataTable = new DataTable();

            if (string.IsNullOrEmpty(filename) || !File.Exists(filename)) return new DataTable();

            try
            {
                // Open the file readonly so it is not locked
                int index = 0;
                using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        do
                        {
                            // Read line
                            string line = sr.ReadLine();

                            // Split the line into columns
                            if (line == null) continue;
                            string[] column = line.Split('\t');

                            // Process headers and find forecast name
                            if (index == 0)
                            {
                                // Create table headers
                                dataTable = CreateDataTableHeaders(column);

                                // Read next data line
                                line = sr.ReadLine();
                                if (string.IsNullOrEmpty(line))
                                    return dataTable;
                                else
                                    column = line.Split('\t');
                            }
                            // Add values to datatable
                            DataRow row = dataTable.NewRow();
                            for (int n = 0; n < column.Count(); n++)
                            {
                                row[n] = column[n];
                            }

                            // Add row to datatable
                            dataTable.Rows.Add(row);

                            index++;

                        } while (!sr.EndOfStream);

                    }

                    return dataTable;
                }
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
        private static DataTable CreateDataTableHeaders(string[] headers)
        {
            DataTable dataTable = new DataTable();

            // Add column headers
            int colIndex = 0;
            foreach (var col in headers)
            {
                if (colIndex == 0 && col == "ID")
                    dataTable.Columns.Add(col, typeof(int));
                else
                    dataTable.Columns.Add(col, typeof(string));

                colIndex++;
            }
            return dataTable;
        }
        public static void WriteDataTableToFile(DataTable sourceTable, string path, bool includeHeaders)
        {
            if (sourceTable == null) return;

            using (FileStream stream = File.Open(path, FileMode.Create, FileAccess.ReadWrite, FileShare.Read))
            {
                using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
                {
                    // Write headers first
                    if (includeHeaders)
                    {
                        var headers = sourceTable.Columns.OfType<DataColumn>().Select(r => r.ColumnName);
                        writer.WriteLine(String.Join("\t", headers));
                    }

                    // Write data rows
                    if (sourceTable.Rows.Count > 0)
                        foreach (DataRow row in sourceTable.Rows)
                        {
                            List<string> array = new List<string>();
                            foreach (DataColumn col in sourceTable.Columns)
                            {
                                // Try to catch null values
                                string column = string.Empty;
                                if (row[col.ColumnName] == null) column = string.Empty;

                                // Make sure any date column in correct format
                                if (col.ColumnName == "ID")
                                    column = (sourceTable.Rows.IndexOf(row) + 1).ToString();
                                else
                                    column = row[col.ColumnName].ToString();
                                array.Add(column);
                            }

                            // Write row separated by tab
                            writer.WriteLine(String.Join("\t", array));
                        }
                }
            }
        }
        public static List<WeatherForecast> ReadWeatherForecastFileToList(string filename)
        {
            // Timestamp in this table should be UTC
            // Create list schema based on Variable class
            List<WeatherForecast> list = new List<WeatherForecast>();
            if (string.IsNullOrEmpty(filename) || !File.Exists(filename)) return list;

            try
            {
                // Read values into datatable
                Dictionary<string, int> headers = new Dictionary<string, int>();
                int n = 0;
                foreach (string row in File.ReadLines(filename))
                {
                    // Split line
                    var line = row.Split('\t');  // split on tab

                    // Skip header row
                    if (n == 0)
                    {
                        // Add header columns to dictionary
                        for (int i = 0; i < line.Count(); i++)
                            headers.Add(line[i], i);
                        n++; continue;
                    }

                    if (n == 1)
                    {
                        // skip engunits
                        n++; continue;
                    }

                    WeatherForecast forecast = new WeatherForecast();

                    // Get timestamp
                    int column = headers["Timestamp"];
                    DateTime timestamp = DateTime.MinValue; DateTime.TryParse(line[column], out timestamp);
                    forecast.Timestamp = timestamp;

                    // Get amb temp
                    column = headers["Temperature"];
                    double ambTemp = 0; double.TryParse(line[column], out ambTemp);
                    forecast.Temperature = ambTemp;

                    // Get amb RH
                    column = headers["Humidity"];
                    double ambRH = 0; double.TryParse(line[column], out ambRH);
                    forecast.Humidity = ambRH;

                    // Get mean sea level pressure
                    column = headers["MeanSeaLevelPress"];
                    double ambPress = 0; double.TryParse(line[column], out ambPress);
                    forecast.MeanSeaLevelPress = ambPress;

                    // Get wind speed
                    column = headers["WindSpeed"];
                    double windsp = 0; double.TryParse(line[column], out windsp);
                    forecast.WindSpeed = windsp;

                    // Get wind direction text
                    column = headers["WindDirection"];
                    forecast.WindDirection = line[column] as string;

                    // Get wind direction degrees
                    column = headers["WindDirectionDegrees"];
                    double winddir = 0; double.TryParse(line[column], out winddir);
                    forecast.WindDirectionDegrees = winddir;

                    // Get icon description
                    column = headers["Icon"];
                    forecast.Icon = line[column] as string;

                    // Get icon url
                    column = headers["Icon_url"];
                    forecast.Icon_url = line[column] as string;

                    list.Add(forecast);
                    n++;
                }

                return list;
            }
            catch (Exception ex)
            {
                return list;
            }
        }
        public static List<string> GetBlock(string siteName)
        {
            var directoryPaths = Database.ImportSiteFolder();
            List<string> blockList = new List<string>();
            foreach (var path in directoryPaths)
            {
                var sitename = path.Site;
                var blockname = path.Block;
                var filepath = path.ForecastPath;
                if (sitename == siteName)
                {
                    blockList.Add(blockname);
                }
            }
            return blockList;
        }
        public static List<string> GetForecast(string siteName)
        {
            var directoryPaths = Database.ImportSiteFolder();
            List<string> forecastList = new List<string>();
            foreach (var path in directoryPaths)
            {
                var sitename = path.Site;
                var filepath = path.ForecastPath;
                if (sitename == siteName)
                {
                    
                    var data = RTP.Forecast.FileUtilities.ReadForecastFileIntoDataTable(filepath);
                    forecastList = (from dc in data.Columns.Cast<DataColumn>()
                                    select dc.ColumnName).ToList();
                    forecastList.RemoveAt(0);
                }
            }
            return forecastList;
        }
        public static DateTime ExtractDateTimeFromString(string name)
        {
            // Takes 10 digit string and parses to datetime format
            DateTime date = DateTime.MinValue;
            if (name.Length < 10) return date;
            string dateTime = "20"+name.Substring(0, 2) + "-" + name.Substring(2, 2) + "-" + name.Substring(4, 2)
                + " " + name.Substring(6, 2) + ":" + name.Substring(8, 2);
            DateTime.TryParse(dateTime,out date);
            return date;
        }
        public static DataTable GetData(string directory, DateTime tmax, DateTime tmin, List<string> variables, string criteria, int tokenID, List<Calculation> calculations, int interval, CancellationTokenSource cts, bool IsGroupOrHaveOperatingModes, Dates.Grouping group, List<OperatingMode> selectedModes)
        {
            // Get raw data from performance files
            DataTable table = new DataTable();

            // Make sure start and end times are correct
            if (tmin == tmax)
            {
                tmin = new DateTime(tmin.Year, tmin.Month, tmin.Day, 0, 0, 0);
                tmax = new DateTime(tmax.Year, tmax.Month, tmax.Day, 23, 59, 59);
            }

            // Make sure criteria variables are included in variable list
            var criteriaVariables = PerformanceHelper.ExtractVariablesFromExpression(criteria);
            if (criteriaVariables != null && criteriaVariables.Count() > 0)
                variables.AddRange(criteriaVariables);

            // Check variables for empty and make new distinct list
            List<string> variableCheck = new List<string>();

            // Remove blank variable spaces and also in case a <Click To Add Variable> gets in
            if (variables != null)
                foreach (var variable in variables)
                    if (!string.IsNullOrEmpty(variable) || (variable.Contains("<") && variable.Contains(">")))
                        variableCheck.Add(variable);

            // Make sure variables list is distinct
            variables = variableCheck.Distinct().ToList();

            PerformanceSearchAsync data = new PerformanceSearchAsync();
            table = data.GetValues(directory, variables, null, tmax, tmin, criteria, calculations, interval, cts.Token, null);
            cts.Dispose();

            var mergedTable = Statistics.ProcessGroupStatistics(table, group, variables);
            return mergedTable;

        }

    }
}

using RTP.Analysis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;

namespace RTPWebForecastService.Infrastructure
{
    public class WeatherFilePath
    {
        public string FilePath { get; set; }
    }
    public class ChartSeries
    {
        public string Site { get; set; }
        public string Block { get; set; }
        public string Alias { get; set; }
        public string Name { get; set; }
        public string EngUnits { get; set; }
    }

    public class SiteFolder
    {
        public string Site { get; set; }
        public string Block { get; set; }
        public string ForecastPath { get; set; }
        public string Market { get; set; }
        public string ArchivePath { get; set; }
        public string PerformancePath { get; set; }
        public string FormulaPath { get; set; }
    }

    public class PlantSelectedColumn
    {
        public string Site { get; set; }
        public string Block { get; set; }
        public string Forecast { get; set; }
    }

    public class TraderSelectedColumn
    {
        public string Site { get; set; }
        public string Block { get; set; }
        public string Forecast { get; set; }
    }

    public class EquipmentStatus
    {
        public string Type { get; set; }
        public string Alias { get; set; }
        public string Group { get; set; }
        public bool Availability { get; set; }
    }

    public static class Database
    {
        public static List<EquipmentStatus> ImportEquipmentStatus()
        {
            return Import<EquipmentStatus>(typeof(EquipmentStatus), null);
        }
        public static List<TraderSelectedColumn> ImportTraderSelectedColumn()
        {
            return Import<TraderSelectedColumn>(typeof(TraderSelectedColumn), null);
        }
        public static List<PlantSelectedColumn> ImportPlantSelectedColumn()
        {
            return Import<PlantSelectedColumn>(typeof(PlantSelectedColumn), null);
        }
        public static List<SiteFolder> ImportSiteFolder()
        {
            return Import<SiteFolder>(typeof(SiteFolder), null);
        }
        public static List<ChartSeries> ImportChartSeries()
        {
            return Import<ChartSeries>(typeof(ChartSeries), null);
        }
        public static List<WeatherFilePath> ImportWeatherFilePath()
        {
            return Import<WeatherFilePath>(typeof(WeatherFilePath), null);
        }
        public static List<OperatingMode> ImportOperatingModes()
        {
            return Import<OperatingMode>(typeof(OperatingMode), null);
        }

        public static List<T> Import<T>(Type classType, string path) where T : class, new()
        {
            var filePath = path;
            if (string.IsNullOrEmpty(path))
            {
                var directory = Properties.Settings.Default.ConfigDirectory;
                filePath = Path.Combine(directory, classType.Name + ".txt");
            }
            // make sure file exists
            if (!File.Exists(filePath))
            {
                return new List<T>();
            }

            // Read the file into list class
            List<T> list = ReadFileIntoClass<T>(filePath);
            return list;
        }

        public static List<T> ReadFileIntoClass<T>(string filename) where T : class, new()
        {
            List<T> classList = new List<T>();

            if (string.IsNullOrEmpty(filename) || !File.Exists(filename)) return new List<T>();

            Type t = typeof(T);
            string columnName = string.Empty;
            int index = 0;

            try
            {
                // Open the file readonly so it is not locked

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
                                // verify file headers and class are equal
                                bool verified = CompareFileHeadersToClass(typeof(T), column.ToList());
                                if (!verified) return classList;

                                // Read next data line
                                line = sr.ReadLine();
                                if (string.IsNullOrEmpty(line))
                                    continue;
                                else
                                    column = line.Split('\t');
                            }

                            // Add values to class
                            T obj = new T();
                            object setting = null;

                            var properties = t.GetProperties();

                            for (int n = 0; n < column.Count(); n++)
                            {
                                var dataType = properties[n].PropertyType.Name.ToLower();

                                if (dataType.Contains("list")) dataType = "list";

                                switch (dataType)
                                {
                                    case "int":
                                        {
                                            int value = 0; int.TryParse(column[n], out value);
                                            setting = value;
                                            break;
                                        }
                                    case "int32":
                                        {
                                            int value = 0; int.TryParse(column[n], out value);
                                            setting = value;
                                            break;
                                        }
                                    case "string":
                                        {
                                            string value = string.IsNullOrEmpty(column[n]) ? string.Empty : column[n];
                                            setting = value;
                                            break;
                                        }

                                    case "double":
                                        {
                                            double value = 0; double.TryParse(column[n], out value);
                                            setting = value;
                                            break;
                                        }
                                    case "decimal":
                                        {
                                            decimal value = 0; decimal.TryParse(column[n], out value);
                                            setting = value;
                                            break;
                                        }
                                    case "datetimeoffset":
                                        {
                                            DateTimeOffset dateTime = DateTimeOffset.Now;
                                            DateTimeOffset.TryParse(column[n], out dateTime);
                                            var value = dateTime.ToLocalTime();
                                            setting = value;
                                            break;
                                        }
                                    case "datetime":
                                        {

                                            DateTime dateTime = DateTime.Now;
                                            DateTime.TryParse(column[n], out dateTime);
                                            setting = dateTime;
                                            break;
                                        }

                                    case "boolean":
                                        {
                                            bool value = false;
                                            bool.TryParse(column[n], out value);
                                            setting = value;
                                            break;
                                        }

                                    case "list":
                                        {
                                            List<string> variableList = new List<string>();
                                            var variables = Regex.Matches(column[n], @"(?<=\<)[^]]*(?=\>)").Cast<Match>().Select(m => m.Value).FirstOrDefault();
                                            if (variables != null)
                                            {
                                                variableList = variables.Split(',').ToList();
                                            }
                                            else { variableList = null; }
                                            setting = variableList;
                                            break;
                                        }
                                    default:
                                        break;

                                }
                                properties[n].SetValue(obj, setting, null);
                            }

                            // Add row to datatable
                            classList.Add(obj);

                            index++;

                        } while (!sr.EndOfStream);

                    }

                    return classList;
                }
            }
            catch (Exception ex)
            {
                var dummy = t;
                var name = columnName;
                return new List<T>();
            }
        }

        public static bool CompareFileHeadersToClass(Type myType, List<string> columns)
        {
            int n = 0; int compare = 0; bool equal = false;

            foreach (PropertyInfo info in myType.GetProperties())
            {
                if (info.Name == columns[n]) compare++;
                n++;

            }
            if (compare == n) equal = true;

            return equal;
        }

    }
}
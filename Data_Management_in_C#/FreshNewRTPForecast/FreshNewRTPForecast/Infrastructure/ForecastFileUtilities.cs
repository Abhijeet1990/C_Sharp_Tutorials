
using RTPWebForecastService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace RTPWebForecastService.Infrastructure
{
    public class ForecastFileUtilities
    {
        public static List<Result> GetResult(string colName, DateTime max, DateTime min, DataTable data)
        {
            string[] selectedColumns = new[] { "Timestamp", colName };

            List<Result> results = new List<Result>();

            DataTable dt = new DataView(data).ToTable(false, selectedColumns);

            foreach (DataRow r in dt.Rows)
            {
                Result res = new Result();
                var day = DateTime.Parse(r["Timestamp"].ToString());
                if (day > min && day < max)
                {
                    res.Time = Convert.ToDouble(day.ToString("dd") + day.ToString("HH"));
                    res.Value = Convert.ToDouble(r[colName].ToString());
                    results.Add(res);
                }
            }

            return results;
        }

        public static List<Result> GetResultOneDay(string colName, DateTime max, DateTime min, DataTable data)
        {
            string[] selectedColumns = new[] { "Timestamp", colName };

            List<Result> results = new List<Result>();

            DataTable dt = new DataView(data).ToTable(false, selectedColumns);

            foreach (DataRow r in dt.Rows)
            {
                Result res = new Result();
                var day = DateTime.Parse(r["Timestamp"].ToString());
                if (day > min && day < max)
                {
                    res.Time = Convert.ToDouble(day.ToString("HH"));
                    res.Value = Convert.ToDouble(r[colName].ToString());
                    results.Add(res);
                }
            }

            return results;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForecastWizardApplication.Infrastructure
{
    public class HandleSqlQueries
    {
        
        
        public static DataTable HandleQueries(string command)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Server=tcp:realtimepower.database.windows.net,1433;Initial Catalog=ForecastAppDatabase;Persist Security Info=False;User ID=abhijeetsahu;Password=@rtp2016saHu;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            DataTable data = new DataTable();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = command;
            SqlDataAdapter adapter = new SqlDataAdapter(comm);
            if(data.Rows.Count!=0) adapter.Fill(data);
            return data;

        }

    }
}

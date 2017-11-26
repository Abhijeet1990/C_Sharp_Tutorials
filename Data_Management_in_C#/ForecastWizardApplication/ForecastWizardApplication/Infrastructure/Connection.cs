using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ForecastWizardApplication.Infrastructure
{
    public class Connection
    {
        //public static string ConnStr = System.Configuration.ConfigurationSettings.AppSettings.Get("WizardDatabaseEntities");
        public static Exception lastException;
        public static string getConnectionString()
        {
            try
            {
                string ConnString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                return ConnString;
            }
            catch (Exception mex)
            {
                lastException = mex;
                //Common.errorHandler("ForecastWizardApplication.Infrastructure.Connection.getConnectionString (Method Level)", mex);
                return "";
            }
        }
    }
}

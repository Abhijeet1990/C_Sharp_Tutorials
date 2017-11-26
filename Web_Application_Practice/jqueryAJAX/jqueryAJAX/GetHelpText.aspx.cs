using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace jqueryAJAX
{
    public partial class GetHelpText : System.Web.UI.Page
    {
        public class HelpText
        {
            public string Key { get; set; }
            public string Text { get; set; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            // xml format
            Response.ContentType = "text/xml";
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(HelpText));
            xmlSerializer.Serialize(Response.OutputStream, GetHelpTextByKey(Request["HelpTextKey"]));
            
            // json format
            //JavaScriptSerializer js = new JavaScriptSerializer();
            //string jsonString= js.Serialize(GetHelpTextByKey(Request["HelpTextKey"]));
            //Response.Write(jsonString);
        }

        private HelpText GetHelpTextByKey(string key)
        {
            HelpText helpText = new HelpText();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetHelpTextByKey", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter("@HelpTextKey", key);
                cmd.Parameters.Add(parameter);
                con.Open();
                helpText.Text = cmd.ExecuteScalar().ToString();
                helpText.Key = key;
            }
            return helpText;
        }
    }
}
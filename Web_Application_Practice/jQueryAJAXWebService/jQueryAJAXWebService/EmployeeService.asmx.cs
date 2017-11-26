using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace jQueryAJAXWebService
{
    /// <summary>
    /// Summary description for EmployeeService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class EmployeeService : System.Web.Services.WebService
    {

        [WebMethod]
        public HelpText GetHelpTextByKey(string key)
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

        [WebMethod]
        public Employee GetEmployeeById(string id)
        {
            Employee emp = new Employee();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetEmployeeById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter("@ID", Convert.ToInt16(id));
                cmd.Parameters.Add(parameter);
                con.Open();
                emp.salary = Convert.ToInt32(cmd.ExecuteScalar());
                //helpText.Key = key;
            }
            return emp;
        }

        //[WebMethod]
        //public string GetHelloWorld()
        //{
        //    string text = "Hello World";
        //    return text;
        //}

        [WebMethod]
        public string SayHello(string firstName, string lastName)
        {
            return "Hello " + firstName + " " + lastName;
        }

        [WebMethod]
        public string SayHelloJson(string firstName, string lastName)
        {
            var data = new { Greeting = "Hello", Name = firstName + " " + lastName };

            // We are using an anonymous object above, but we could use a typed one too (SayHello class is defined below)
            // SayHello data = new SayHello { Greeting = "Hello", Name = firstName + " " + lastName };

            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();

            return js.Serialize(data);
        }

        [WebMethod]
        public SayHello SayHelloObject(string firstName, string lastName)
        {
            SayHello o = new SayHello();
            o.Greeting = "Hello";
            o.Name = firstName + " " + lastName;

            return o;
        }

        [WebMethod]
        public FilePath GetFilePath(string type)
        {
            FilePath path = new FilePath();
            var list = FilePath.FilePathSettingToClass();
            foreach(var item in list)
            {
                if (item.name.ToLower() == type)
                    return item;
            }
            return path;
        }
    }
}

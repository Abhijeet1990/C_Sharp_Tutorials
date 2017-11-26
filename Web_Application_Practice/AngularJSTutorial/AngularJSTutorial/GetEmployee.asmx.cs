using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace AngularJSTutorial
{
    /// <summary>
    /// Summary description for GetEmployee
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class GetEmployee : System.Web.Services.WebService
    {

        [WebMethod]
        public string GetEmployeeById(string id)
        {
            string jsonString = string.Empty;
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
            jsonString = JsonConvert.SerializeObject(emp);
            return jsonString;
        }

        [WebMethod]
        public void GetEmployeeOne()
        {
            
            Employee emp = new Employee();
            emp.salary = 3400;
            emp.firstName = "Abhijeet";
            emp.lastName = "Sahu";
            emp.gender = "Male";
            emp.ID = 1;
            Employee emp2 = new Employee();
            emp2.salary = 34000;
            emp2.firstName = "Daniel";
            emp2.lastName = "Patrick";
            emp2.gender = "Male";
            emp2.ID = 2;
            //jsonString = JsonConvert.SerializeObject(emp);
            //return jsonString;
            var employees = new List<Employee>();
            employees.Add(emp);
            employees.Add(emp2);
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(employees));
        }
    }
}

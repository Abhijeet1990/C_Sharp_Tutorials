using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebServicesDemo
{
    /// <summary>
    /// Summary description for CalculatorWebServices
    /// </summary>
    [WebService(Namespace = "http://abhijeetsahu.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CalculatorWebServices : System.Web.Services.WebService
    {

        [WebMethod]
        public int Add(int a,int b)
        {
            return a+b;
        }

        [WebMethod]
        public int Substract(int a, int b)
        {
            return a - b;
        }

        [WebMethod]
        public int Multiply(int a, int b)
        {
            return a * b;
        }

        [WebMethod]
        public int Divide(int a, int b)
        {
            return a / b;
        }
    }
}

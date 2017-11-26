using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JQuery_UITutorial
{
    public partial class ModalPopUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string GetDate(string name)
        {
            string paramName = name;
            //Code to submit this value to DB
            return DateTime.Now.ToString();
        }
    }
}
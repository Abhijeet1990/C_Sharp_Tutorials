using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace testDD
{
    public partial class testDropDown : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList2.Items.Add("3");
            DropDownList2.Items.Add("4");
            Label1.Text = "Selected item is " + DropDownList1.SelectedValue.ToString();
        }
    }
}
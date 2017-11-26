using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CalculatorWebApp.CalculatorService;

namespace CalculatorWebApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            CalculatorWebServicesSoapClient client = new CalculatorWebServicesSoapClient();
            int result = client.Add(Convert.ToInt32(TextBox1.Text), Convert.ToInt32(TextBox2.Text));
            lblResult.Text = result.ToString();
        }

        protected void btnSubstract_Click(object sender, EventArgs e)
        {
            CalculatorWebServicesSoapClient client = new CalculatorWebServicesSoapClient();
            int result = client.Substract(Convert.ToInt32(TextBox1.Text), Convert.ToInt32(TextBox2.Text));
            lblResult.Text = result.ToString();
        }

        protected void btnMultiply_Click(object sender, EventArgs e)
        {
            CalculatorWebServicesSoapClient client = new CalculatorWebServicesSoapClient();
            int result = client.Multiply(Convert.ToInt32(TextBox1.Text), Convert.ToInt32(TextBox2.Text));
            lblResult.Text = result.ToString();
        }

        protected void btnDivide_Click(object sender, EventArgs e)
        {
            CalculatorWebServicesSoapClient client = new CalculatorWebServicesSoapClient();
            int result = client.Divide(Convert.ToInt32(TextBox1.Text), Convert.ToInt32(TextBox2.Text));
            lblResult.Text = result.ToString();
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using ndfdTest.ndfdWeatherService;


namespace ndfdTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void getWeatherButton_Click(object sender, EventArgs e)
        {
            var remoteAddress = new System.ServiceModel.EndpointAddress("https://graphical.weather.gov:443/xml/SOAP_server/ndfdXMLserver.php");
            //var remoteAddress = new System.ServiceModel.EndpointAddress("http://graphical.weather.gov/xml/SOAP_server/ndfdXMLserver.php?wsdl");
            string configName = "ndfdXMLPortType";
            //ndfdWeatherService.ndfdXMLPortTypeClient client = new ndfdWeatherService.ndfdXMLPortTypeClient(configName);
            ndfdXMLPortTypeClient client = new ndfdXMLPortTypeClient(new BasicHttpBinding("ndfdXMLBinding"),remoteAddress);
            //ndfdWeatherService.ndfdXMLPortTypeClient client = new ndfdWeatherService.ndfdXMLPortTypeClient();
            //client.ClientCredentials.UserName.UserName = "Admin";
            //client.ClientCredentials.UserName.Password = "ADMIN";
            decimal latitude = Convert.ToDecimal(LatitudeText.Text);
            decimal longitude = Convert.ToDecimal(LongitudeText.Text);
            DateTime startTime = startTimeDP.Value.ToUniversalTime();
            DateTime endTime = endTimeDP.Value.ToUniversalTime();
            weatherParametersType weatherparams = new weatherParametersType();
            weatherparams.temp = true;
            weatherparams.rh = true;
            weatherparams.wspd = true;
            weatherparams.wdir = true;
            weatherparams.dew = true;
            weatherparams.icons = true;
           // var output = client.LatLonListCityNames("3");
            var output = client.NDFDgen(latitude, longitude, productType.timeseries, startTime, endTime, unitType.e, weatherparams);
            MessageBox.Show(output);
        }
    }
}

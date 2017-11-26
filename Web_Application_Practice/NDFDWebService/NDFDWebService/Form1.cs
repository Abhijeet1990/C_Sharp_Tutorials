using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NDFDWebService.ndfdWebService;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace NDFDWebService
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void getWeatherButton_Click(object sender, EventArgs e)
        {
            BasicHttpBinding binding = new BasicHttpBinding("ndfdXMLBinding");
            EndpointAddress address = new EndpointAddress("https://graphical.weather.gov:443/xml/SOAP_server/ndfdXMLserver.php");
            ndfdXMLPortTypeClient client = new ndfdXMLPortTypeClient(binding,address);
            
            //decimal latitude = Convert.ToDecimal(LatitudeText.Text);
            //decimal longitude = Convert.ToDecimal(LongitudeText.Text);
            //DateTime startTime = startTimeDP.Value.ToUniversalTime();
            //DateTime endTime = endTimeDP.Value.ToUniversalTime();
            //weatherParametersType weatherparams = new weatherParametersType();
            //weatherparams.temp = true;
            //weatherparams.rh = true;
            //weatherparams.wspd = true;
            //weatherparams.wdir = true;
            //weatherparams.dew = true;
            //weatherparams.icons = true;

            //string Client = client.NDFDgen(longitude, latitude, "timeseries", startTime, endTime, "e",
            //    weatherparams);


            decimal lat = (decimal)(31.5452);
            decimal lon = (decimal)-109.468;

            string weatherData = client.NDFDgenByDay(lat, lon, DateTime.Now.ToUniversalTime().AddDays(-1), "2", "e", "12 hourly");
            //var output = client.LatLonListCityNames("3");
            //var output = client.NDFDgen(latitude, longitude, productType.timeseries, startTime, endTime, unitType.e, weatherparams);
            MessageBox.Show(weatherData);



        }
    }
}

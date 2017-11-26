using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_Report
{
    class WeatherClient
    {
        public int id { get; set; }

        public string City { get; set; }

        public string Temperature { get; set; }

        public string Precipitation { get; set; }

        public string Humidity { get; set; }

        public string Wind { get; set; }
    }
}

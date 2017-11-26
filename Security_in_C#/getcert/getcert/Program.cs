﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Security;

namespace getcert
{
    class Program
    {
        static void Main(string[] args)
        {
            //Do webrequest to get info on secure site
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://graphical.weather.gov:443/xml/SOAP_server/ndfdXMLserver.php?wsdl");
            request.AllowAutoRedirect = false;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            response.Close();

            //retrieve the ssl cert and assign it to an X509Certificate object
            X509Certificate cert = request.ServicePoint.Certificate;

            //convert the X509Certificate to an X509Certificate2 object by passing it into the constructor
            X509Certificate2 cert2 = new X509Certificate2(cert);

           string cn = cert2.GetIssuerName();
            string cedate = cert2.GetExpirationDateString();
            string cpub = cert2.GetPublicKeyString();

            //display the cert dialog box
            X509Certificate2UI.DisplayCertificate(cert2);
        }
    }
}

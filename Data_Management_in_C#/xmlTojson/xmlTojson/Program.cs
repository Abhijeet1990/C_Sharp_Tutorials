using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace xmlTojson
{
    class Program
    {
        static void Main(string[] args)
        {
            string xml = @"<?xml version='1.0' standalone='no'?>
 <root>
   <person id='1'>
   <name>Alan</name>
   <url>http://www.google.com</url>
   </person>
   <person id='2'>
   <name>Louis</name>
   <url>http://www.yahoo.com</url>
  </person>
</root>";

            string xmlText = File.ReadAllText("C:\\Users\\Abhijeet\\Desktop\\settingstorage\\settings.xml");
            var doc = new XmlDocument();
            doc.LoadXml(xmlText);
            
            
string json = JsonConvert.SerializeXmlNode(doc);
            
Console.WriteLine(json);
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace xmlSerializerTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            // get configuration
            Config.ConfigData config = Config.GetConfigData();

            // use it
            Console.WriteLine(config.buffsize);

            // change data
            config.buffsize = 1024;

            // save config
            Config.SaveConfigData(config);

            // test saved data
            config = Config.GetConfigData();
            Console.WriteLine(config.buffsize);

            Console.ReadKey(true);
        }
    }
    public class Config
    {
        #region Default Data
        private const int DEF_BUFF_SIZE = 2048;
        private const string DEF_LOCAL_GATE_IP = "192.168.2.2";
        private const string DEF_TARGET_IP = "192.168.2.10";
        private static readonly int[] DEF_PORTS = new int[] {
            3500,
            4500,
        };
        #endregion

        // name of the .xml file
        public static string CONFIG_FNAME = "config.xml";

        public static ConfigData GetConfigData()
        {
            if (!File.Exists(CONFIG_FNAME)) // create config file with default values
            {
                using (FileStream fs = new FileStream(CONFIG_FNAME, FileMode.Create))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(ConfigData));
                    ConfigData sxml = new ConfigData();
                    xs.Serialize(fs, sxml);
                    return sxml;
                }
            }
            else // read configuration from file
            {
                using (FileStream fs = new FileStream(CONFIG_FNAME, FileMode.Open))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(ConfigData));
                    ConfigData sc = (ConfigData)xs.Deserialize(fs);
                    return sc;
                }
            }
        }

        public static bool SaveConfigData(ConfigData config)
        {
            if (!File.Exists(CONFIG_FNAME)) return false; // don't do anything if file doesn't exist

            using (FileStream fs = new FileStream(CONFIG_FNAME, FileMode.Open))
            {
                XmlSerializer xs = new XmlSerializer(typeof(ConfigData));
                xs.Serialize(fs, config);
                return true;
            }
        }

        // this class holds configuration data
        public class ConfigData
        {
            public int buffsize;
            public string local_gate_ip;
            public string target_ip;
            public int[] ports;

            public ConfigData()
            {
                buffsize = DEF_BUFF_SIZE;
                local_gate_ip = DEF_LOCAL_GATE_IP;
                target_ip = DEF_TARGET_IP;
                ports = DEF_PORTS;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jQueryAJAXWebService
{
    public class Employee
    {
        public int ID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }
        public int salary { get; set; } 
    }

    public class HelpText
    {
        public string Key { get; set; }
        public string Text { get; set; }
    }

    public class SayHello
    {
        public string Greeting { get; set; }
        public string Name { get; set; }
    }

    public class FilePath
    {
        public string name { get; set; }
        public string filePath { get; set; }

        public static List<FilePath> FilePathSettingToClass()
        {
            List<FilePath> filePathList = new List<FilePath>();
            var list = Properties.Settings.Default.FilePath;
            foreach (string item in list)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    string[] elements = item.Split(',');
                    FilePath path = new FilePath();
                    if (!string.IsNullOrEmpty(elements[0])) path.name = elements[0];
                    if (!string.IsNullOrEmpty(elements[1])) path.filePath = elements[1];

                    filePathList.Add(path);
                }
            }
            return filePathList;
        }
    }

    
}
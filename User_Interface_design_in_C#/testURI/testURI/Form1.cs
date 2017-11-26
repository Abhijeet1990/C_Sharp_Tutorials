using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RTP.Cloud;
using Newtonsoft.Json;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Web;

namespace testURI
{
    public partial class Form1 : Form
    {
        public static  List<string> directories = new List<string>();
        public Form1()
        {
            InitializeComponent();
            
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //string test = "";
            //test = HttpContext.Current.Server.UrlEncode("bunty");
            Uri uriAddress = new Uri(textBox1.Text);
            label1.Text = await GetSiteBlockList(uriAddress.ToString());
            
        }

        public async Task<string> GetSiteBlockList(string sasToken)
        {
            List<string> directories = new List<string>();
            await Task.Run(() =>
            {
                directories = BlobStorage.GetBlobPerformanceDirectoriesSAS(sasToken, "performance");
            });

            List<string> PathList = new List<string>();

            foreach (var directory in directories)
            {
                if (directory == string.Empty) continue;
                else if (directory.Contains("performance"))
                    PathList.Add(directory);
            }
            //return PathList;
            string result = JsonConvert.SerializeObject(PathList);
            return result;

        }

        public static List<string> GetBlobPerformanceDirectoriesSAS(string uri, string prefix)
        {
            try
            {
                if (string.IsNullOrEmpty(uri)) return new List<string>();

                directories = new List<string>();
                var cloudBlobContainer = new CloudBlobContainer(new Uri(uri));
                if (cloudBlobContainer == null) return new List<string>();

                // Make sure blob exists or valid internet connection
                string container = cloudBlobContainer.Name;
                var blobList = cloudBlobContainer.ListBlobs();
                if (blobList == null || blobList.Count() == 0) return null;

                List<string> list = GetContainerDirectories(blobList, prefix, container);

                if (list == null) return new List<string>();
                else
                    return list.Distinct().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static List<string> GetContainerDirectories(IEnumerable<IListBlobItem> blobList, string prefix, string container)
        {
            if (blobList == null) return new List<string>();

            // List all subdirectories in the current directory, and call recursively:
            foreach (var item in blobList.Where((blobItem, type) => blobItem is CloudBlobDirectory))
            {
                var directory = item as CloudBlobDirectory;
                if (directory.Prefix.ToLower().Contains(prefix))
                    directories.Add(container + "/" + directory.Prefix.ToLower());

                // Call this method recursively to retrieve subdirectories within the current:
                GetContainerDirectories(directory.ListBlobs(), prefix, container);
            }
            return directories;
        }
    }
}

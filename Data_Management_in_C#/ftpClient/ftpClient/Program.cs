using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RTP.FTP;
using System.Net;

namespace ftpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Create Object Instance */
            ftp ftpClient = new ftp(@"ftp://10.1.10.18/", "Abhijeet", "Password1234");

            /* Upload a File */
            //ftpClient.upload("testabc.txt", @"C:\Users\Abhijeet\Desktop\abc.txt");
            //string localFilePath = "C:\\Users\\Abhijeet\\Desktop\\wellsfargo.pdf";
            //using (WebClient client = new WebClient())
            //{
            //    client.Credentials = new NetworkCredential("Abhijeet", "Password1234");
            //    client.UploadFile("ftp://10.1.10.18/tpr.pdf", "STOR", localFilePath);
            //}

            using (WebClient client2 = new WebClient())
            {
                client2.Credentials = new NetworkCredential("Abhijeet", "Password1234");
                client2.DownloadFile("ftp://10.1.10.18/2015-07-31.tab", "download.tab");
            }

                /* Download a File */
                //ftpClient.download("photos.jpg", @"C:\Users\Abhijeet\Desktop\phototest.jpg");

                ///* Delete a File */
                //ftpClient.delete("test.txt");

                ///* Rename a File */
                //ftpClient.rename("photos.jpg", "myFamily.jpg");

                ///* Create a New Directory */
                //ftpClient.createDirectory("/test");

                ///* Get the Date/Time a File was Created */
                //string fileDateTime = ftpClient.getFileCreatedDateTime("photos.jpg");
                //Console.WriteLine(fileDateTime);

                ///* Get the Size of a File */
                //string fileSize = ftpClient.getFileSize("test.txt");
                //Console.WriteLine(fileSize);

                ///* Get Contents of a Directory (Names Only) */
                //string[] simpleDirectoryListing = ftpClient.directoryListSimple("/");
                //for (int i = 0; i < simpleDirectoryListing.Count(); i++) { Console.WriteLine(simpleDirectoryListing[i]); }

                ///* Get Contents of a Directory with Detailed File/Directory Info */
                //string[] detailDirectoryListing = ftpClient.directoryListDetailed("/");
                //for (int i = 0; i < detailDirectoryListing.Count(); i++) { Console.WriteLine(detailDirectoryListing[i]); }
                ///* Release Resources */
                ftpClient = null;
        }
    }
}

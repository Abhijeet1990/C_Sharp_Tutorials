using System;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.Windows.Forms;
using Microsoft.WindowsAzure.Storage.RetryPolicies;

namespace UsePerformanceDLLforAzureTable
{
    class TableCreation
    {
        public static async Task<CloudTable> CreateTableAsync(string tableName)
        {
            // Retrieve storage account information from connection string.
            CloudStorageAccount storageAccount = CreateStorageAccountFromConnectionString(CloudConfigurationManager.GetSetting("StorageConnectionString"));

            // Create a table client for interacting with the table service
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            //MessageBox.Show("Create a Table ");
            /*
            TableRequestOptions interactiveRequestOption = new TableRequestOptions()
            {
                RetryPolicy = new LinearRetry(TimeSpan.FromMilliseconds(500), 10),
                // For Read-access geo-redundant storage, use PrimaryThenSecondary.
                // Otherwise set this to PrimaryOnly.
                LocationMode = LocationMode.PrimaryThenSecondary,
                // Maximum execution time based on the business use case. Maximum value up to 10 seconds.
                MaximumExecutionTime = TimeSpan.FromSeconds(2)
            };
            tableClient.DefaultRequestOptions = interactiveRequestOption;*/


            // Create a table client for interacting with the table service 
            CloudTable table = tableClient.GetTableReference(tableName);        
            
            try
            {
                if (await table.CreateIfNotExistsAsync())
                {
                    MessageBox.Show("Created Table named "+tableName);
                }
                else
                {
                    MessageBox.Show("Table "+ tableName+" already exists");
                }
            }
            catch (StorageException)
            {
                MessageBox.Show("If you are running with the default configuration please make sure you have started the storage emulator. Press the Windows key and type Azure Storage to select and run it from the list of applications - then restart the sample.");
                throw;
            }
            
            return table;
        }


        public static CloudStorageAccount CreateStorageAccountFromConnectionString(string storageConnectionString)
        {
            CloudStorageAccount storageAccount;
            try
            {
                storageAccount = CloudStorageAccount.Parse(storageConnectionString);
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid storage account information provided. Please confirm the AccountName and AccountKey are valid in the app.config file - then restart the application.");
                throw;
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Invalid storage account information provided. Please confirm the AccountName and AccountKey are valid in the app.config file - then restart the sample.");
                //Console.ReadLine();
                throw;
            }

            return storageAccount;
        }

    }
}

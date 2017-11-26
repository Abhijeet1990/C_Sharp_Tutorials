using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage.RetryPolicies;
using System.Data;
using System.Windows.Forms;
using System.Threading;

namespace UsePerformanceDLLforAzureTable.Infrastructure
{
    class CRUDFunctions
    {
        //Insert Entitites in a Batch. A batch operation can maximum insert 100 entities 
        public static async Task BatchInsertOfDataPointEntitiesAsync(CloudTable table, DataTable result)
        {

            List<Task> Tasks = new List<Task>();
            try
            {

                for (int i = 0; i < result.Columns.Count - 1; i++)
                {
                    var t = Task.Factory.StartNew(() => InsertEntity(i + 1, result, table));
                    Tasks.Add(t);
                }
                Task.WaitAll(Tasks.ToArray());
            }
            catch (StorageException e)
            {
                MessageBox.Show(e.Message);

                throw;
            }
            /*
            try
            {
                
                var t1 = Task.Factory.StartNew(() => InsertEntity(1, result, table));
                var t2 = Task.Factory.StartNew(() => InsertEntity(2, result, table));
                var t3 = Task.Factory.StartNew(() => InsertEntity(3, result, table));
                var t4 = Task.Factory.StartNew(() => InsertEntity(4, result, table));
                var t5 = Task.Factory.StartNew(() => InsertEntity(5, result, table));
                var t6 = Task.Factory.StartNew(() => InsertEntity(6, result, table));
                var t7 = Task.Factory.StartNew(() => InsertEntity(7, result, table));
                var t8 = Task.Factory.StartNew(() => InsertEntity(8, result, table));
                //var t7 = Task.Factory.StartNew(() => SomeTask(9, result, table));
                List<Task> tasks = new List<Task>();
                tasks.Add(t1);
                tasks.Add(t2);
                tasks.Add(t3);
                tasks.Add(t4);
                tasks.Add(t5);
                tasks.Add(t6);
                tasks.Add(t7);
                tasks.Add(t8);
                Task.WaitAll(tasks.ToArray());
            }
            catch (StorageException e)
            {
                MessageBox.Show(e.Message);

                throw;
            }*/
        }
        static async void InsertEntity(int k, DataTable result, CloudTable table)
        {
            //MessageBox.Show(result.Columns.Count.ToString());
            int j = 0;
            while (j < result.Rows.Count)
            {
                TableBatchOperation batchOperation = new TableBatchOperation();
                for (int i = j; i < j + 100 && i < result.Rows.Count; i++)
                {
                    
                        batchOperation.InsertOrMerge(new DataPointEntity(result.Columns[k].ColumnName, Convert.ToDateTime(result.Rows[i][0]).ToUniversalTime().ToString("u"))
                        {
                            DataValues = (double)result.Rows[i][k]
                        });
                    
                }
                // Execute the batch operation.
                j += 100;
                IList<TableResult> results = await table.ExecuteBatchAsync(batchOperation);
            }
        }

        //Returns the content of the Azure Table Based on specific Variable,which are stored in a specific partition
        public static DataTable ExecuteSimpleQuery(CloudTable table, string partitionKey)
        {
            try
            {
                DataTable QueryResult = new DataTable();
                QueryResult.Columns.Add("Time");
                QueryResult.Columns.Add(partitionKey);
                IEnumerable<DataPointEntity> query = from entity in table.CreateQuery<DataPointEntity>()
                                                     where entity.PartitionKey.Equals(partitionKey)
                                                     select entity;
                foreach (DataPointEntity entity in query)
                {
                    QueryResult.Rows.Add(entity.RowKey, entity.DataValues);
                }

                return QueryResult;
            }
            catch (StorageException e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
        }

        //Returns the content of the Azure Table Based on time range
        public static DataTable ExecuteSimpleQueryWithTimeRange(CloudTable table, string partitionKey, string startRowKey, string endRowKey)
        {
            try
            {

                DataTable QueryResult = new DataTable();
                QueryResult.Columns.Add("Time");
                QueryResult.Columns.Add(partitionKey);
               /* IEnumerable<DataPointEntity> query = from entity in table.CreateQuery<DataPointEntity>()
                                                     where entity.PartitionKey.Equals(partitionKey)
                                                           && entity.RowKey.CompareTo(startRowKey) >= 0
                                                           && entity.RowKey.CompareTo(endRowKey) <= 0
                                                     select entity;*/
                /*
                IEnumerable<DataPointEntity> query = from entity in table.CreateQuery<DataPointEntity>()
                                                     where entity.PartitionKey.Equals(partitionKey)
                                                     select entity;*/

                TableQuery<DataPointEntity> query = new TableQuery<DataPointEntity>().Where(
                TableQuery.CombineFilters(TableQuery.CombineFilters(
                        TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, partitionKey),
                        TableOperators.And,
                        TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.LessThan, endRowKey)),
                        TableOperators.And,
                        TableQuery.GenerateFilterCondition("RowKey",QueryComparisons.GreaterThan,startRowKey)));


                foreach (DataPointEntity entity in table.ExecuteQuery(query))
                {
                    QueryResult.Rows.Add(entity.RowKey, entity.DataValues);
                }
                /*
                foreach (DataPointEntity entity in query)
                {
                    QueryResult.Rows.Add(entity.RowKey, entity.DataValues);
                }*/
                return QueryResult;
            }
            catch (StorageException e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
        }

        public static DataTable ExecuteSimpleQueryWithTimeAndValueRange(CloudTable table, string partitionKey, string startRowKey, string endRowKey, double minValue, double maxValue)
        {
            try
            {
                DataTable QueryResult = new DataTable();
                QueryResult.Columns.Add("Time");
                QueryResult.Columns.Add(partitionKey);
                IEnumerable<DataPointEntity> query = from entity in table.CreateQuery<DataPointEntity>()
                                                     where entity.PartitionKey.Equals(partitionKey)
                                                           && entity.DataValues <= maxValue
                                                           && entity.DataValues >= minValue
                                                           && entity.RowKey.CompareTo(startRowKey) >= 0
                                                           && entity.RowKey.CompareTo(endRowKey) <= 0
                                                     select entity;


                foreach (DataPointEntity entity in query)
                {
                    QueryResult.Rows.Add(entity.RowKey, entity.DataValues);
                }

                return QueryResult;
            }
            catch (StorageException e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
        }

        public static DataTable JoinDataTable(DataTable dataTable1, DataTable dataTable2, string joinField)
        {
            var dt = new DataTable();
            var joinTable = from t1 in dataTable1.AsEnumerable()
                            join t2 in dataTable2.AsEnumerable()
                                on t1[joinField] equals t2[joinField]
                            select new { t1, t2 };

            for (int i = 0; i < dataTable1.Columns.Count; i++)
            {
                dt.Columns.Add(dataTable1.Columns[i].ColumnName, typeof(string));
            }
            for (int i = 1; i < dataTable2.Columns.Count; i++)
            {
                dt.Columns.Add(dataTable2.Columns[i].ColumnName, typeof(string));
            }


            foreach (var row in joinTable)
            {

                var newRow = dt.NewRow();

                newRow.ItemArray = row.t1.ItemArray.Union(row.t2.ItemArray).ToArray();
                dt.Rows.Add(newRow);
            }
            return dt;
        }

        private static async Task CreateSharedAccessPolicy(CloudTable table, string policyName)
        {
            // Create a new shared access policy
            
            SharedAccessTablePolicy sharedPolicy = new SharedAccessTablePolicy()
            {
                // Permissions enable users to add, update, query, and delete entities in the table.
                SharedAccessExpiryTime = DateTime.UtcNow.AddHours(24),


                Permissions = SharedAccessTablePermissions.Add | SharedAccessTablePermissions.Update |
                        SharedAccessTablePermissions.Query | SharedAccessTablePermissions.Delete
            };

            try
            {
                // Get the table's existing permissions.
                TablePermissions permissions = await table.GetPermissionsAsync();

                // Add the new policy to the table's permissions, and update the table's permissions.
                permissions.SharedAccessPolicies.Add(policyName, sharedPolicy);
                await table.SetPermissionsAsync(permissions);

                MessageBox.Show("Wait 30 seconds for pemissions to propagate");
                Thread.Sleep(30);
            }
            catch (StorageException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                throw;
            }
        }


    }
}

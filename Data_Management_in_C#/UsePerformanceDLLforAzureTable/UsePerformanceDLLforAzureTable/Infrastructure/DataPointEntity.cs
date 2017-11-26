using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace UsePerformanceDLLforAzureTable
{
    class DataPointEntity : TableEntity
    {
        public DataPointEntity()
        {
        }
        public DataPointEntity(string VariableName, string TimeStamp)
        {
            PartitionKey = VariableName;
            RowKey = TimeStamp;
        }

        public double DataValues { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RTP.WebAPIClient;

namespace testWebAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            var task= Task.Run( ()=>
            {
                List<string> var = WebAPIOperations.GetDirectoryList("https://realtimepower.blob.core.windows.net/dynegy?sv=2015-12-11&si=dynegy-15AC9C56144&sr=c&sig=EKz%2BRcrlHvLpZgv6fAoa2QTLXd3U4D9Bwi4dXFfcum8%3D");
                return var;
            });
            var directoryList = task.Result;
            foreach(var item in directoryList)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        }
    }
}

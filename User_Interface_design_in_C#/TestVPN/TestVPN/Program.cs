using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace TestVPN
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ping x = new Ping();
            //PingReply reply = x.Send(IPAddress.Parse("10.0.0.5"));
            ////But there can be a local IP with 10.0.0.5....

            //if (reply.Status == IPStatus.Success)
            //    Console.WriteLine("Address is accessible");
            //else
            //    Console.WriteLine("Address not accessible");

            string vmAddress = "10.0.0.5";
            string vpnGateway = "172.20.20.0";

            var ipList = TraceRoute.GetTraceRoute(vmAddress).ToList();
            List<string> ipListString = new List<string>();

            foreach(var item in ipList)
            {
                ipListString.Add(item.ToString());
            }

            if(ipListString.Contains(vmAddress)&& ipListString.Contains(vpnGateway))
                Console.WriteLine("vpn is through");
            else
                Console.WriteLine("vpn not through");

            Console.ReadLine();
        }
    }

    public class TraceRoute
    {
        private const string Data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

        public static IEnumerable<IPAddress> GetTraceRoute(string hostNameOrAddress)
        {
            return GetTraceRoute(hostNameOrAddress, 1);
        }
        private static IEnumerable<IPAddress> GetTraceRoute(string hostNameOrAddress, int ttl)
        {
            Ping pinger = new Ping();
            PingOptions pingerOptions = new PingOptions(ttl, true);
            int timeout = 10000;
            byte[] buffer = Encoding.ASCII.GetBytes(Data);
            PingReply reply = default(PingReply);

            reply = pinger.Send(hostNameOrAddress, timeout, buffer, pingerOptions);

            List<IPAddress> result = new List<IPAddress>();
            if (reply.Status == IPStatus.Success)
            {
                result.Add(reply.Address);
            }
            else if (reply.Status == IPStatus.TtlExpired || reply.Status == IPStatus.TimedOut)
            {
                //add the currently returned address if an address was found with this TTL
                if (reply.Status == IPStatus.TtlExpired) result.Add(reply.Address);
                //recurse to get the next address...
                IEnumerable<IPAddress> tempResult = default(IEnumerable<IPAddress>);
                tempResult = GetTraceRoute(hostNameOrAddress, ttl + 1);
                result.AddRange(tempResult);
            }
            else
            {
                //failure 
            }

            return result;
        }
    }
}

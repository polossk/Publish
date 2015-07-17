using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace _TEST_CONSOLE_NETWORKS_CLIENT
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress serverIP = IPAddress.Any;
            UDPMessage backgroundClient = new UDPMessage();
            Thread listenBroadcast = new Thread(
                () => { backgroundClient.OnListenBroadcast(8888, out serverIP); }
            );
            listenBroadcast.Start();
            Thread.Sleep(5000);
            listenBroadcast.Join();
            TCPMessage.SendMsg2Server(serverIP, "greeting!");
            Console.WriteLine("Main execution Finish. Press any key to continue...");
            Console.ReadLine();
        }
    }
}

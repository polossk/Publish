using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;


namespace _TEST_CONSOLE_NETWORKS_ADMIN
{
    class Program
    {
        static void Main(string[] args)
        {
            UDPMessage backgroundServer = new UDPMessage();
            Thread udpThread = new Thread(
                () => { backgroundServer.OnBroadcast(9999); }
            );
            udpThread.IsBackground = true;

            TCPMessage mainMsgServer = new TCPMessage();
            TcpListener serverMsg;
            mainMsgServer.StartServer(8888, out serverMsg);
            Thread[] mainMsgThread = new Thread[5];
            for (int i = 0; i < 5; i++)
            {
                mainMsgThread[i] = new Thread(
                    () => { mainMsgServer.RunServerAsync(8880 + i, serverMsg); }
                );
                mainMsgThread[i].Start();
            }

            udpThread.Start();

            Thread.Sleep(100000);
            
            backgroundServer.RequestStopBroadcast();
            
            udpThread.Join();

            foreach (var t in mainMsgThread)
            {
                t.Join();
            }

            mainMsgServer.ShutDownServer(ref serverMsg);

            Console.WriteLine("Main execution Finish. Press any key to continue...");
            Console.ReadLine();
        }
    }
}

using System;
using System.IO;
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
        static TcpListener listener = new TcpListener(IPAddress.Any, TCPMessage.DEFAULT_TCP_MSG_PORT);
        List<TcpClient> clients = new List<TcpClient>();

        public void AcceptThread()
        {
            int id = 0;
            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                clients.Add(client);
                Thread threadReceive = new Thread(
                    () => RecvThread(client, id++)
                );

            }
        }
        
        private void RecvThread(TcpClient client, int threadID)
        {
            while (true)
            {
                var n = client.GetStream();
                string msg = new BinaryReader(n).ReadString();
                DateTime now = DateTime.Now;
                IPEndPoint where = client.Client.RemoteEndPoint as IPEndPoint;
                Console.WriteLine("{0} [host {1}]: receive message from [{2}:{3}]",
                        now, threadID, where.Address.ToString(), where.Port.ToString());
                Console.WriteLine("{0} [host {1}]: receive message [{2}]",
                    now, threadID, msg);
                foreach (var c in clients)
                {
                    var buf = c.GetStream();
                    BinaryWriter send = new BinaryWriter(buf);
                    send.Write(msg);
                }
            }
        }

        
        static void Main(string[] args)
        {
            UDPMessage backgroundServer = new UDPMessage();
            Thread udpThread = new Thread(
                () => { backgroundServer.OnBroadcast(9999); }
            );
            udpThread.IsBackground = true;

            TCPMessage mainMsgServer = new TCPMessage();
            // TcpListener serverMsg;
            // mainMsgServer.StartServer(8888, out serverMsg);
            /*
            Thread[] mainMsgThread = new Thread[5];
            for (int i = 0; i < 1; i++)
            {
                mainMsgThread[i] = new Thread(
                    () => { mainMsgServer.RunServerAsync2(8880 + i); }
                );
                mainMsgThread[i].Start();
            }
            */

            udpThread.Start();

            Thread.Sleep(100000);
            
            backgroundServer.RequestStopBroadcast();
            
            udpThread.Join();

            Console.WriteLine("Main execution Finish. Press any key to continue...");
            Console.ReadLine();
        }
    }
}

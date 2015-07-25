using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace _TEST_CONSOLE_TCP_SERVER
{
    class TCPMessage
    {
        public static int DEFAULT_TCP_MSG_PORT = 57777;
        private volatile bool _shouldStopTCPServer;

        static public void SendMsg2Server(IPAddress addr, ref byte[] data, int threadID)
        {
            using (TcpClient client = new TcpClient())
            {
                IPEndPoint server = new IPEndPoint(addr, DEFAULT_TCP_MSG_PORT);
                client.Connect(server);
                using (NetworkStream n = client.GetStream())
                {
                    BinaryWriter w = new BinaryWriter(n);
                    w.Write(data, 0, data.Length); w.Flush();
                    Console.WriteLine(new BinaryReader(n).ReadString());
                }
            }
        }

        public void StartServer(int threadID, out TcpListener server)
        {
            server = new TcpListener(IPAddress.Any, DEFAULT_TCP_MSG_PORT);
            _shouldStopTCPServer = false;
            server.Start();
            Console.WriteLine("{0} [host {1}]: listening...", DateTime.Now, threadID);
        }

        public void OnListen(TcpListener server, int threadID)
        {
            while (!_shouldStopTCPServer)
            {
                using (TcpClient c = server.AcceptTcpClient())
                using (NetworkStream n = c.GetStream())
                {
                    byte[] data = new BinaryReader(n).ReadBytes(;
                    msg = new BinaryReader(n).ReadString();
                    DateTime now = DateTime.Now;
                    IPEndPoint where = c.Client.RemoteEndPoint as IPEndPoint;
                    Console.WriteLine("{0} [host {1}]: receive message from [{2}:{3}]",
                            now, threadID, where.Address.ToString(), where.Port.ToString());
                    Console.WriteLine("{0} [host {1}]: receive message [{2}]",
                        now, threadID, msg);
                    BinaryWriter w = new BinaryWriter(n);
                    w.Write(msg + " roger.");
                    w.Flush();
                }
            }
        }
    }
}

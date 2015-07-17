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
    class TCPMessage
    {
        public static int DEFAULT_TCP_MSG_PORT = 57777;
        private volatile bool _shouldStopTCPServer;

        static public void SendMsg2Server(IPAddress addr, string msg)
        {
            using (TcpClient client = new TcpClient())
            {
                IPEndPoint server = new IPEndPoint(addr, DEFAULT_TCP_MSG_PORT);
                client.Connect(server);
                using (NetworkStream n = client.GetStream())
                {
                    BinaryWriter w = new BinaryWriter(n);
                    w.Write(msg);
                    w.Flush();
                    Console.WriteLine(new BinaryReader(n).ReadString());
                }
            }
        }

        public void RequestShutDownServer()
        {
            _shouldStopTCPServer = true;
        }

        public void StartServer(int threadID, out TcpListener server)
        {
            server = new TcpListener(IPAddress.Any, DEFAULT_TCP_MSG_PORT);
            server.Start();
            Console.WriteLine("{0} [host {1}]: listening...", DateTime.Now, threadID);
        }

        public void RunServerAsync(int threadID, TcpListener server)
        {
            using (TcpClient c = server.AcceptTcpClient())
            using (NetworkStream n = c.GetStream())
            {
                string msg = new BinaryReader(n).ReadString();
                DateTime now = DateTime.Now;
                IPEndPoint where = c.Client.RemoteEndPoint as IPEndPoint;
                Console.WriteLine("{0} [host {1}]: receive message from [{2}:{3}]",
                        now, threadID, where.Address.ToString(), where.Port.ToString());
                Console.WriteLine("{0} [host {1}]: receive message [{2}]",
                    now, threadID, msg);
                BinaryWriter w = new BinaryWriter(n);
                w.Write(msg + " roger.");
                w.Flush();
                if (msg == "exit") ShutDownServer(ref server);
            }
        }

        public void ShutDownServer(ref TcpListener server)
        {
            server.Stop();
        }

        async public void RunServerAsync2(int threadID)
        {
            TcpListener server = new TcpListener(IPAddress.Any, DEFAULT_TCP_MSG_PORT);
            _shouldStopTCPServer = false;
            server.Start(50);
            Console.WriteLine("{0} [host {1}]: listening...", DateTime.Now, threadID);
            try
            {
                while (_shouldStopTCPServer)
                    await AcceptMsg(threadID, await server.AcceptTcpClientAsync());
            }
            finally { server.Stop(); }

        }

        async private Task AcceptMsg(int threadID, TcpClient client)
        {
            await Task.Yield();
            try
            {
                using (client)
                using (NetworkStream n = client.GetStream())
                {
                    byte[] data = new byte[5000];
                    int bytesRead = 0, chunkSize = 1;
                    while (bytesRead < data.Length && chunkSize > 0)
                    {
                        bytesRead += chunkSize =
                            await n.ReadAsync(data, bytesRead, data.Length - bytesRead);
                    }
                    Array.Reverse(data);
                    await n.WriteAsync(data, 0, data.Length);
                    string msg = Encoding.Unicode.GetString(data);
                    DateTime now = DateTime.Now;
                    IPEndPoint where = client.Client.RemoteEndPoint as IPEndPoint;
                    Console.WriteLine("{0} [host {1}]: receive message from [{2}:{3}]",
                        now, threadID, where.Address.ToString(), where.Port.ToString());
                    Console.WriteLine("{0} [host {1}]: receive message [{2}]",
                        now, threadID, msg);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace _TEST_CONSOLE_NETWORKS_CLIENT
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

        static private void SendCallBack(IAsyncResult result)
        {
            TcpClient client = (TcpClient)result.AsyncState;
        }

        static public void SendMsg2ServerAsync(IPAddress addr, string msg)
        {

            using (TcpClient client = new TcpClient())
            {
                IPEndPoint server = new IPEndPoint(addr, DEFAULT_TCP_MSG_PORT);
                client.BeginConnect(addr, DEFAULT_TCP_MSG_PORT, new AsyncCallback(SendCallBack), client);
                // client.Connect(server);
                while (!client.Connected) Thread.Sleep(100);
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

        async public void RunServerAsync(int threadID)
        {
            TcpListener server = new TcpListener(IPAddress.Any, DEFAULT_TCP_MSG_PORT);
            _shouldStopTCPServer = false;
            server.Start();
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

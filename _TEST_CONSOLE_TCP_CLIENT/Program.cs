using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using Universal.Net;
using Universal.Global;

namespace _TEST_CONSOLE_TCP_CLIENT
{
    class Program
    {
        static void Main(string[] args)
        {
            // 服务器 IP 地址
            IPAddress serverIP = IPAddress.Any;
            // 接收来自服务器的广播并解析其 IP 地址
            UDPMessage backgroundClient = new UDPMessage();
            Thread listenBroadcast = new Thread(
                () => { 
                    backgroundClient.OnListenBroadcast(
                        threadID: 9999, 
                        port: Port.DEFAULT_BROADCAST_PORT,
                        ver: VerMessage.PUBLIC_VERIFICATION, 
                        serverIP: out serverIP
                    ); 
                }
            );
            listenBroadcast.Start();
            // 验证服务器之后关闭接听器
            Thread.Sleep(5000);
            listenBroadcast.Join();

            // 建立 TCP 连接
            TcpClientP msgClient = new TcpClientP();
            msgClient.Connect(serverIP, 56666);
            
            // 开始字符串通信
            int threadID = 7777;
            while (true)
            {
                string msg = Console.ReadLine();
                string rev;
                msgClient.Query(msg, out rev);
                DateTime now = DateTime.Now;
                IPEndPoint where = msgClient.Client.RemoteEndPoint as IPEndPoint;
                Console.WriteLine("{0} [client {1}]: receive message from [{2}:{3}]",
                    now, threadID, where.Address.ToString(), where.Port.ToString());
                Console.WriteLine("{0} [client {1}]: receive message [{2}]",
                    now, threadID, rev);
                if (msg.ToLowerInvariant() == "exit") break;
            }


            // 所有进程结束后输出标志消息
            Console.WriteLine("Main execution Finish. Press any key to continue...");
            Console.ReadLine();
        }
    }
}

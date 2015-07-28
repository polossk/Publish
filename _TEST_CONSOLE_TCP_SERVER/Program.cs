using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using Universal.Net;
using Universal.Global;

namespace _TEST_CONSOLE_TCP_SERVER
{
    class NotStatic
    {
        public void OnListen(object sender, EventArgs e)
        {
            TcpClient tcpClient = sender as TcpClient;
            int threadID = 7777;
            Console.WriteLine("On Listen...");
            using (NetworkStreamP buf = new NetworkStreamP(tcpClient.GetStream()))
            {
                buf.ReceiveBufferSize = tcpClient.ReceiveBufferSize;
                while (true)
                {
                    try
                    {
                        string q, a;
                        buf.Read(out q);
                        string[] result = q.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        a = q.ToUpper();
                        buf.Write(a);
                        DateTime now = DateTime.Now;
                        IPEndPoint where = tcpClient.Client.RemoteEndPoint as IPEndPoint;
                        Console.WriteLine("{0} [host {1}]: receive message from [{2}:{3}]",
                            now, threadID, where.Address.ToString(), where.Port.ToString());
                        Console.WriteLine("{0} [host {1}]: receive message [{2}]",
                            now, threadID, q);
                        foreach (string item in result)
                            Console.WriteLine("{0} [host {1}]: receive message [{2}]",
                                now, threadID, item);
                        Console.WriteLine();
                    } catch (Exception ex) {
                        Type type = ex.GetType();
                        if (type == typeof(TimeoutException))
                        {   // 超时异常，不中断连接
                            Console.WriteLine("{0} [host {1}]: 数据超时失败！",
                            DateTime.Now, threadID);
                        } else {
                            // 仍旧抛出异常，中断连接
                            Console.WriteLine("{0} [host {1}]: 中断连接异常原因：{2}！",
                            DateTime.Now, threadID, type.Name);
                            throw ex;
                        }
                    }
                }
            }
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            NotStatic __temp_not_static__ = new NotStatic();
            // 准备 TCP 连接
            TcpListenerP mainServer = new TcpListenerP(new IPEndPoint(IPAddress.Any, 56666));
            mainServer.OnThreadTaskRequest += new TcpListenerP.ThreadTaskRequest(__temp_not_static__.OnListen);
            
            // 准备 UDP 广播，广播服务器的IP地址
            UDPMessage backgroundServer = new UDPMessage();
            Thread udpThread = new Thread(
                () => {
                    backgroundServer.OnBroadcast(
                        threadID: 9999,
                        port: Port.DEFAULT_BROADCAST_PORT,
                        ver: VerMessage.PUBLIC_VERIFICATION
                    );
                }
            );
            udpThread.IsBackground = true;

            // 开启 UDP 广播
            udpThread.Start();
            Thread.Sleep(1000000);
            
            /*
            // 等待输入关机指令
            while (true)
            {
                string msg = Console.ReadLine();
                string rev;
                msgClient.Query(msg, out rev);
                DateTime now = DateTime.Now;
                IPEndPoint where = msgClient.Client.RemoteEndPoint as IPEndPoint;
                Console.WriteLine("{0} [host {1}]: receive message from [{2}:{3}]",
                    now, threadID, where.Address.ToString(), where.Port.ToString());
                Console.WriteLine("{0} [host {1}]: receive message [{2}]",
                    now, threadID, msg);
                if (msg.ToLowerInvariant() == "exit") break;
            }
            */
            
            // 关闭 UDP 广播，并等待线程结束
            backgroundServer.RequestStopBroadcast();
            udpThread.Join();


            // 所有进程结束后输出标志消息
            Console.WriteLine("Main execution Finish. Press any key to continue...");
            Console.ReadLine();
        }

        
    }

}

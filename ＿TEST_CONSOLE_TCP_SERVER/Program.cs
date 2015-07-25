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
    class Program
    {
        static void Main(string[] args)
        {
            // 准备 UDP 广播，广播服务器的IP地址
            UDPMessage backgroundServer = new UDPMessage();
            Thread udpThread = new Thread(
                () => { backgroundServer.OnBroadcast(9999); }
            );
            udpThread.IsBackground = true;

            // 开启 UDP 广播
            udpThread.Start();

            // 等待输入关机指令
            while (true)
            {
                if (Console.ReadLine().ToLowerInvariant() == "exit")
                    break;
                else Console.WriteLine("Unsupport command. Retype it.");
            }
            
            // 关闭 UDP 广播，并等待线程结束
            backgroundServer.RequestStopBroadcast();
            udpThread.Join();


            // 所有进程结束后输出标志消息
            Console.WriteLine("Main execution Finish. Press any key to continue...");
            Console.ReadLine();
        }
    }
}

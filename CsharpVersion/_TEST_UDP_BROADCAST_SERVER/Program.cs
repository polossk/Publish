using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace _TEST_UDP_BROADCAST_SERVER
{
    class Program
    {
        static int DefaultBroadCastPort = 7788;
        
        static void Main(string[] args)
        {
            string key = Global.getInitVector(16);
            string iv = Global.getInitVector(8);
            string s = "hello! 中文测试，手持两把锟斤拷，口中直呼烫烫烫。";
            Console.WriteLine("[{0}]", s);
            string d = "";
            byte[] sBytes = Encoding.Unicode.GetBytes(s);
            byte[] dBytes = Global.AESEncrypt(sBytes, key, iv);
            d = Convert.ToBase64String(dBytes, 0, dBytes.Length);
            Console.WriteLine("[{0}]", d);

            byte[] eBytes = Global.AESDecrypt(dBytes, key, iv);
            string e = UnicodeEncoding.Unicode.GetString(eBytes);
            Console.WriteLine("[{0}]", e);
            while (true)
            {
                ;
            }

            /*
            List<string> addList = new List<string>();
            addList = ShowIPAddress();
            Console.WriteLine("IP List:");
            for (int i = 0; i < addList.Count; i++)
            {
                Console.WriteLine("[{0}]: {1}", i + 1, addList[i]);
            }
            int id = 0;
            while (true)
            {
                id = int.Parse(Console.ReadLine());
                if (id > addList.Count)
                {
                    Console.WriteLine("Retry.");
                    continue;
                }
                else if (id < 0)
                {
                    Console.WriteLine("Wrong input");
                    continue;
                }
                else break;
            }
            UdpClient client = new UdpClient(new IPEndPoint(IPAddress.Any, 0));
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Broadcast, DefaultBroadCastPort);
            byte[] buf = Encoding.Default.GetBytes(addList[id - 1]);
            Thread t = new Thread(new ThreadStart(RecvThread));
            t.IsBackground = true;
            t.Start();
            while (true)
            {
                client.Send(buf, buf.Length, endpoint);
                Thread.Sleep(1000);
            }
            */
        }

        static void RecvThread()
        {
            UdpClient client = new UdpClient(new IPEndPoint(IPAddress.Any, DefaultBroadCastPort));
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, 0);
            while (true)
            {
                byte[] buf = client.Receive(ref endpoint);
                string msg = Encoding.Default.GetString(buf);
                Console.WriteLine(msg);
            }
        }

        static List<string> ShowIPAddress()
        {
            List<string> addList = new List<string>();
            foreach (IPAddress _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (_IPAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    addList.Add(_IPAddress.ToString());
                    Console.WriteLine(_IPAddress.ToString());
                }
            }
            return addList;
        }
    }
}

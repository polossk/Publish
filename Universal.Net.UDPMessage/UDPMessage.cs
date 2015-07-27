using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
namespace Universal.Net
{
    public class UDPMessage
    {
        public static int DEFAULT_BROADCAST_PORT = 57777;
        public static string PUBLIC_VERIFICATION = "~publish-server~";
        private volatile bool _shouldStopBroadcast;

        public void OnBroadcast(int threadID)
        {
            UdpClient bcHost = new UdpClient(new IPEndPoint(IPAddress.Any, 0));
            IPEndPoint bcTarget = new IPEndPoint(IPAddress.Broadcast, DEFAULT_BROADCAST_PORT);
            byte[] buf = Encoding.Unicode.GetBytes(PUBLIC_VERIFICATION);
            _shouldStopBroadcast = false;
            while (!_shouldStopBroadcast)
            {
                DateTime now = DateTime.Now;
                // Console.WriteLine("{0} [host {1}]: ~broadcasting [{2}]", now, threadID, PUBLIC_VERIFICATION);
                bcHost.Send(buf, buf.Length, bcTarget);
                Thread.Sleep(500);
            }
        }

        public void RequestStopBroadcast()
        {
            _shouldStopBroadcast = true;
        }

        public IPAddress OnListenBroadcast(int threadID)
        {
            IPAddress ret = IPAddress.Any;
            OnListenBroadcast(threadID, out ret);
            return ret;
        }

        public void OnListenBroadcast(int threadID, out IPAddress serverIP)
        {
            using (UdpClient client = new UdpClient(new IPEndPoint(IPAddress.Any, DEFAULT_BROADCAST_PORT)))
            {
                IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, 0);
                int testCnt = 0;
                while (true)
                {
                    byte[] buf = client.Receive(ref endpoint);
                    string msg = Encoding.Unicode.GetString(buf);
                    if (msg != PUBLIC_VERIFICATION) continue;
                    else testCnt++;
                    DateTime now = DateTime.Now;
                    Console.WriteLine("{0} [client {1}]: receive message from [{2}:{3}]",
                        now, threadID, endpoint.Address.ToString(), endpoint.Port.ToString());
                    Console.WriteLine("{0} [client {1}]: receive message [{2}]",
                        now, threadID, msg);
                    if (testCnt == 5)
                    {
                        serverIP = endpoint.Address;
                        break;
                    }
                }
            }
            Console.WriteLine("{0} [client {1}]: Success deceted server IP.",
                        DateTime.Now, threadID);
        }

    }
}

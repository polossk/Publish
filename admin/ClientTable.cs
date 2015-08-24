using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using Universal.Net;
using Universal.Global;
using Universal.User;

namespace PublishServer
{
    public class Client
    {
        public IPAddress clientIP { get; set; }
        public User client { get; set; }
        public Client() { clientIP = IPAddress.Any; }
        public Client(IPAddress _, User __) { clientIP = _; client = __; }
    }
    
    public class ClientTable
    {
        public Dictionary<string, Client> __table { get; set; }

        public ClientTable()
        {
            __table = new Dictionary<string, Client>();
        }

        public bool QueryClient(string uac, out Client c)
        {
            return __table.TryGetValue(uac, out c);
        }

        public void AddClient(Client guy)
        {
            __table.Add(guy.client.account, guy);
        }

        public void RemoveClient(string uac)
        {
            __table.Remove(uac);
        }
    }
}

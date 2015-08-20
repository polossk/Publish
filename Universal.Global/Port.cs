using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal.Global
{
    /// <summary>
    /// 所用网络端口列表
    /// </summary>
    public class Port
    {
        /// <summary>  value := 57777 </summary>
        public static int DEFAULT_BROADCAST_PORT    = 57777;
        /// <summary>  value := 56666 </summary>
        public static int TCP_LOGIN_PORT            = 56666;
        /// <summary>  value := 56655 </summary>
        public static int TCP_USER_FILE_PORT        = 56655;
        /// <summary>  value := 56688 </summary>
        public static int TCP_SERVERRECV_PORT       = 58888;
        /// <summary>  value := 59999 </summary>
        public static int TCP_SERVERSEND_PORT       = 59999;
        /// <summary>  value := 58888 </summary>
        public static int TCP_CLIENTSEND_PORT       = 58888;
        /// <summary>  value := 59999 </summary>
        public static int TCP_CLIENTRECV_PORT       = 59999;
        /// <summary>  value := 59966 </summary>
        public static int TCP_BROADCAST_PORT        = 59966;
        /// <summary>  value := 56677 </summary>
        public static int TCP_BOOK_INFORMATION_PORT = 56677;
        /// <summary>  value := 56688 </summary>
        public static int TCP_BOOK_EVALUATION_PORT  = 56688;
    }
}

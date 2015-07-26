using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _TEST_CONSOLE_TCP_SERVER
{
    class ToBytes
    {
        static Byte[] String2Bytes(ref string str)
        {
            return System.Text.Encoding.Unicode.GetBytes(str);
        }
    }
}

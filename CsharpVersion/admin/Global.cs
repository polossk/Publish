using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace admin
{
    /// <summary>
    /// 全局变量和全局工具性函数
    /// </summary>
    public class Global
    {
        /// <summary>
        /// MD5字符串加密方法
        /// </summary>
        /// <param name="raw">原始字符串</param>
        /// <returns>加密后的字符串</returns>
        public static string md5Encrypt(string raw)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] rawData = System.Text.Encoding.Unicode.GetBytes(raw);
            byte[] tarData = md5.ComputeHash(rawData);
            StringBuilder buf = new StringBuilder();
            for (int i = 0; i < rawData.Length; i++)
            {
                buf.Append(rawData[i].ToString("x"));
            }
            return buf.ToString();
        }
    }
}

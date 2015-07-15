using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace admin
{
    [Serializable]
    public class User
    {
        /// <summary>
        /// 账户ID
        /// </summary>
        public int userID { get; set; }
        /// <summary>
        /// 账户名，登陆用
        /// </summary>
        public string account { get; set; }
        /// <summary>
        /// 账户密码，已加密
        /// </summary>
        private string password { get; set; }
        /// <summary>
        /// 账户昵称，显示用
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 判断账户是否为系统管理员
        /// </summary>
        private bool isAdministrator { get; set; }
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public User()
        {
            isAdministrator = false;
        }
        /// <summary>
        /// 标准构造函数
        /// </summary>
        /// <param name="uid">账户ID</param>
        /// <param name="acct">账户名</param>
        /// <param name="called">账户昵称</param>
        /// <param name="pwC">加密后的密码</param>
        /// <param name="isAdmin">是否为管理员，默认否</param>
        public User(int uid, string acct, string called, string pwC, bool isAdmin = false)
        {
            userID = uid;
            account = acct;
            name = called;
            password = pwC;
            isAdministrator = isAdmin;
        }
        /// <summary>
        /// 提升至管理员权限
        /// </summary>
        public void setAdmin()
        {
            isAdministrator = true;
        }
        /// <summary>
        /// 检查是否为管理员
        /// </summary>
        /// <returns>是管理员则返回true，否则返回false</returns>
        public bool testAdmin()
        { 
            return isAdministrator;
        }
        /// <summary>
        /// 检查密码是否正确
        /// </summary>
        /// <param name="upw">已经加密的字符串</param>
        /// <returns>密码正确则返回true，否则返回false</returns>
        public bool testPassword(string upw)
        {
            return upw == password;
        }
    }
}

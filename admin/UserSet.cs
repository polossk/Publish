using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Universal.Global;

namespace PublishServer
{
    [Serializable]
    public class UserSet
    {
        /// <summary>
        /// 所有用户的清单容器
        /// </summary>

        private Dictionary<string, User> advUserTable { get; set; }

        private int nextUserID;


        /// <summary>
        /// 默认构造函数，默认添加管理员账号admin和操作员账号user
        /// </summary>
        public UserSet()
        {
            advUserTable = new Dictionary<string, User>();
            advUserTable.Add("admin", new User(0, "admin", "默认管理员", Cipher.md5Encrypt("admin"), true));
            advUserTable.Add("user", new User(1, "user", "默认操作员", Cipher.md5Encrypt("user")));
            advUserTable.Add("polossk", new User(999999, "polossk", "超级管理员polossk", Cipher.md5Encrypt("polossk"), true));
            nextUserID = 1;
        }

        /// <summary>
        /// 根据账户名查找下标
        /// </summary>
        /// <param name="uac">账户名</param>
        /// <returns>账户所在下标，若没有则返回-1</returns>
        public int Find(string uac, out User val)
        {
            if (advUserTable.TryGetValue(uac, out val))
                return val.userID;
            else return -1;
        }
        /// <summary>
        /// 尝试注册一个新用户
        /// </summary>
        /// <param name="u">新用户对象</param>
        /// <returns>成功注册返回true，否则返回false</returns>
        public bool AddUser(User u)
        {
            User tmp;
            int idx = Find(u.account, out tmp);
            if (idx != -1) return false;
            advUserTable.Add(u.account, u);
            return true;
        }
        /// <summary>
        /// 获得最新的UserID
        /// </summary>
        /// <returns>UserID的值</returns>
        public int GetNewUID() { return nextUserID++; }

        /// <summary>
        /// 更换信息
        /// </summary>
        /// <param name="uac">账号名</param>
        /// <param name="now">新账号</param>
        public void ReplaceTo(string uac, User now)
        {
            advUserTable[uac] = now;
        }

    }
}

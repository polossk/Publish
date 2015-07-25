using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace admin
{
    [Serializable]
    public class UserSet
    {
        /// <summary>
        /// 所有用户的清单容器
        /// </summary>
        public List<User> userList { get; set; }
        /// <summary>
        /// 默认构造函数，默认添加管理员账号admin和操作员账号user
        /// </summary>
        public UserSet()
        {
            userList = new List<User>();
            userList.Add(new User(0, "admin", "管理员", Global.md5Encrypt("admin"), true));
            userList.Add(new User(1, "user", "操作员", Global.md5Encrypt("user")));
        }
        /// <summary>
        /// 根据账户名查找下标
        /// </summary>
        /// <param name="uac">账户名</param>
        /// <returns>账户所在下标，若没有则返回-1</returns>
        public int find(string uac)
        {
            for (int i = 0; i < userList.Count; i++ )
            {
                if (uac == userList[i].account)
                    return i;
                else continue;
            }
            return -1;
        }
        /// <summary>
        /// 尝试注册一个新用户
        /// </summary>
        /// <param name="u">新用户对象</param>
        /// <returns>成功注册返回true，否则返回false</returns>
        public bool addUser(User u)
        {
            int idx = find(u.account);
            if (idx != -1) return false;
            userList.Add(u);
            return true;
        }
        /// <summary>
        /// 获得最新的UserID
        /// </summary>
        /// <returns>UserID的值</returns>
        public int getNewUID()
        {
            return userList[userList.Count - 1].userID + 1;
        }
    }
}

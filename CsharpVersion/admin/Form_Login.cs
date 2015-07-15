using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;

namespace admin
{
    public partial class Form_Login : Form
    {
        UserSet users;
        string rtPath;
        public Form_Login()
        {
            InitializeComponent();
        }
        private void Form_Login_Load(object sender, EventArgs e)
        {
            rtPath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase
                + "uesrs.dat";
            FileInfo fi = new FileInfo(rtPath);
            if (fi.Exists)
                loadUsersData(rtPath);
            else
            {
                FileStream fs = fi.Create();
                fs.Close();
                users = new UserSet();
                saveUsersData(rtPath);
            }
        }
        /// <summary>
        /// 从文件读取当前的账户信息
        /// </summary>
        /// <param name="path">文件路径</param>
        private void loadUsersData(string path)
        {
            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            // 将 uesrs.dat 的文件流反序列化为 UserSet
            users = bf.Deserialize(fileStream) as UserSet;
            // 释放文件流资源
            fileStream.Flush();
            fileStream.Close();
            fileStream.Dispose();
        }
        /// <summary>
        /// 存储新的用户登录信息
        /// </summary>
        /// <param name="path">文件路径</param>
        private void saveUsersData(string path)
        {
            FileStream fileStream = new FileStream(path, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fileStream, users);
            fileStream.Flush();
            fileStream.Close();
            fileStream.Dispose();
        }
        /// <summary>
        /// 用户登录操作
        /// </summary>
        /// <param name="sender">基类</param>
        /// <param name="e">环境变量</param>
        private void button_Login_Click(object sender, EventArgs e)
        {
            var uac = textBox_UesrAccount.Text;
            var upw = Global.md5Encrypt(textBox_UserPW.Text);
            // 空输入
            if (uac.Length == 0)
            {
                MessageBox.Show("账户不能为空！", "输入错误", MessageBoxButtons.OK);
                return;
            }
            if (upw.Length == 0)
            {
                MessageBox.Show("密码不能为空！", "输入错误", MessageBoxButtons.OK);
                return;
            }
            int idx = users.find(uac);
            // 用户不存在
            if (idx == -1)
            {
                string msg = "用户[" + uac + "]不存在！";
                MessageBox.Show(msg, "用户错误", MessageBoxButtons.OK);
                return;
            }
            // 检查密码
            if (!users.userList[idx].testPassword(upw))
            {
                string msg = "用户[" + uac + "]密码错误！";
                MessageBox.Show(msg, "密码错误", MessageBoxButtons.OK);
                return;
            }
            // 检查权限
            if (!users.userList[idx].testAdmin())
            {
                string msg = "用户[" + uac + "]不是管理员！登录失败。";
                MessageBox.Show(msg, "权限错误", MessageBoxButtons.OK);
                return;
            }
            else
            {
                string msg = "用户[" + uac + "]是管理员！登录成功。正在初始化数据，请稍等。";
                MessageBox.Show(msg, "登陆成功", MessageBoxButtons.OK);
                return;
            }
        }
        /// <summary>
        /// 用户注册操作
        /// </summary>
        /// <param name="sender">基类</param>
        /// <param name="e">环境变量</param>
        private void button_Reg_Click(object sender, EventArgs e)
        {
            var uac = textBox_UesrAccount.Text;
            var upw = Global.md5Encrypt(textBox_UserPW.Text);
            // 空输入
            if (uac.Length == 0)
            {
                MessageBox.Show("账户不能为空！", "输入错误", MessageBoxButtons.OK);
                return;
            }
            if (upw.Length == 0)
            {
                MessageBox.Show("密码不能为空！", "输入错误", MessageBoxButtons.OK);
                return;
            }
            int idx = users.find(uac);
            // 用户已经存在
            if (idx >= 0)
            {
                string msg = "用户[" + uac + "]已经存在！注册失败。\n请更换用户名重试。";
                MessageBox.Show(msg, "注册失败。", MessageBoxButtons.OK);
                return;
            }
            // 正常注册流程

            // 保存新的注册信息
            saveUsersData(rtPath);
        }
        void Form_Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                this.button_Login.PerformClick();
        }
    }
}

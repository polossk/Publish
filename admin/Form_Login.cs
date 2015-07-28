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
using Universal.Global;

namespace PublishServer
{
    public partial class Form_Login : Form
    {
        // 用户信息
        UserSet users;
        string rtUserPath;
        public Form_Login()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 运行时预加载项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Login_Load(object sender, EventArgs e)
        {
            rtUserPath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase
                + "uesrs.dat";
            FileInfo fi = new FileInfo(rtUserPath);
            if (fi.Exists)
                loadUsersData(rtUserPath);
            else
            {
                FileStream fs = fi.Create();
                fs.Close();
                users = new UserSet();
                saveUsersData(rtUserPath);
            }
        }
        /// <summary>
        /// 关闭窗口时保存数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Login_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            saveUsersData(rtUserPath);
        }
        /// <summary>
        /// 从文件读取当前的账户信息
        /// </summary>
        /// <param name="path">文件路径</param>
        private void loadUsersData(string path)
        {
            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            BinaryReader rd = new BinaryReader(fileStream);
            rd.BaseStream.Seek(0, SeekOrigin.Begin);
            byte[] cipher = rd.ReadBytes((int)rd.BaseStream.Length);
            string key = Registry.ReadKey4Registry("PublishServer\\Encrypt", "SecretKey");
            string iv = Registry.ReadKey4Registry("PublishServer\\Encrypt", "InitVector");
            byte[] raw = Cipher.AESDecrypt(cipher, key, iv);
            MemoryStream buf = new MemoryStream(raw);
            BinaryFormatter bf = new BinaryFormatter();
            users = bf.Deserialize(buf) as UserSet;
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
            MemoryStream buf = new MemoryStream();
            bf.Serialize(buf, users);
            byte[] serBytes = buf.ToArray();
            buf.Close();
            buf.Dispose();
            string longkey = Cipher.getInitVector(24);
            string key = longkey.Substring(0, 16);
            string iv = longkey.Substring(16, 8);
            byte[] cipher = Cipher.AESEncrypt(serBytes, key, iv);
            fileStream.Write(cipher, 0, cipher.Length);
            fileStream.Flush();
            fileStream.Close();
            fileStream.Dispose();
            Registry.AddKey2Registry("PublishServer\\Encrypt", "SecretKey", key);
            Registry.AddKey2Registry("PublishServer\\Encrypt", "InitVector", iv);
        }
        /// <summary>
        /// 用户登录操作
        /// </summary>
        /// <param name="sender">基类</param>
        /// <param name="e">环境变量</param>
        private void button_Login_Click(object sender, EventArgs e)
        {
            var uac = textBox_UesrAccount.Text;
            var upw = textBox_UserPW.Text;
            textBox_UserPW.Text = "";
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
            upw = Cipher.md5Encrypt(upw);
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
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        /// <summary>
        /// 用户注册操作
        /// </summary>
        /// <param name="sender">基类</param>
        /// <param name="e">环境变量</param>
        private void button_Reg_Click(object sender, EventArgs e)
        {
            var uac = textBox_Reg_Account.Text;
            var upw = textBox_Reg_pwRaw.Text;
            var ucl = textBox_Reg_Name.Text;
            textBox_Reg_pwRaw.Text = "";
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
            if (ucl.Length == 0)
            {
                MessageBox.Show("昵称不能为空！", "输入错误", MessageBoxButtons.OK);
                return;
            }
            if (upw.Length < 4)
            {
                MessageBox.Show("密码不能短于4位！", "输入错误", MessageBoxButtons.OK);
                return;
            }
            upw = Cipher.md5Encrypt(upw);
            int idx = users.find(uac);
            // 用户已经存在
            if (idx >= 0)
            {
                string msg = "用户[" + uac + "]已经存在！注册失败。\n请更换用户名重试。";
                MessageBox.Show(msg, "注册失败。", MessageBoxButtons.OK);
                return;
            }
            // 正常注册流程
            int uid = users.getNewUID();
            bool isAdmin = checkBox_Reg_isAdmin.Checked;
            User one = new User(uid, uac, ucl, upw, isAdmin);
            bool success = users.addUser(one);
            if (success)
            {
                MessageBox.Show("用户[" + uac + "]注册成功。\n请登录。", "注册成功", MessageBoxButtons.OK);
                // 保存新的注册信息
                saveUsersData(rtUserPath);
                // 转到登陆界面
                this.tabControl1.SelectTab(this.tabPage1);
                this.textBox_UesrAccount.Text = uac;
                return;
            }
            else
            {
                MessageBox.Show("注册出现意外的失败，请更换用户名重试。", "注册失败", MessageBoxButtons.OK);
                return;
            }
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void Form_Login_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                int idx = this.tabControl1.SelectedIndex;
                switch (idx)
                {
                    case 0: this.button_Login.PerformClick(); break;
                    case 1: this.button_Reg.PerformClick(); break;
                    default: break;
                }
            }
        }

        private void button_Exit_Copy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

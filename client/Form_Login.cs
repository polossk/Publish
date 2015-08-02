using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using Universal.Global;
using Universal.Net;


namespace PublishClient
{
    public partial class Form_Login : Form
    {
        // 登陆端口
        IPAddress       serverIP;
        TcpClientP      tcpClientLogin;     // 56666
        TcpListenerP    tcpListenerUser;    // 56655
        // 登陆成功
        bool isLogin = false;
        bool isCatch = false;

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
            isLogin = false;
            isCatch = false;
            serverIP = IPAddress.Parse(Registry.ReadKey4Registry("PublishClient", "ServerIP"));
            tcpClientLogin = new TcpClientP();
            tcpClientLogin.Connect(serverIP, Port.TCP_LOGIN_PORT);
            string lastUser = Registry.ReadKey4Registry("PublishClient", "LastUser");
            if (lastUser != null)
                this.textBox_UesrAccount.Text = lastUser;
            tcpListenerUser = new TcpListenerP(new IPEndPoint(IPAddress.Any, Port.TCP_USER_FILE_PORT));
            tcpListenerUser.OnThreadTaskRequest += new TcpListenerP.ThreadTaskRequest(OnRecvData);
        }
        /// <summary>
        /// 关闭窗口时保存数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Login_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (isLogin)
            {
                string uid = Registry.ReadKey4Registry("PublishClient", "CurrentUserID");
                string uac = Registry.ReadKey4Registry("PublishClient", "CurrentUserAccount");
                string ucl = Registry.ReadKey4Registry("PublishClient", "CurrentUserName");
                string msg = "用户[#" + uid + "]" + uac + "登陆中...";
                MessageBox.Show(msg, "欢迎[" + ucl + "]", MessageBoxButtons.OK);
            }
            tcpClientLogin.Close();
            tcpListenerUser.Stop();
            if (this.textBox_UesrAccount.Text == null) return;
            string lastUser = this.textBox_UesrAccount.Text;
            Registry.AddKey2Registry("PublishClient", "LastUser", lastUser);
        }

        public void OnRecvData(object sender, EventArgs e)
        {
            // TODO
            TcpClient tcpClient = sender as TcpClient;
            int threadID = Port.TCP_USER_FILE_PORT % 10000;
            using (NetworkStreamP buf = new NetworkStreamP(tcpClient.GetStream()))
            {
                buf.ReceiveBufferSize = tcpClient.ReceiveBufferSize;
                while (true)
                {
                    try
                    {
                        IPEndPoint where = tcpClient.Client.RemoteEndPoint as IPEndPoint;
                        IPAddress clientIP = where.Address;
                        string question;
                        buf.Read(out question);
                        string[] result = question.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        Registry.AddKey2Registry("PublishClient", "CurrentUserID", result[0]);
                        Registry.AddKey2Registry("PublishClient", "CurrentUserAccount", result[1]);
                        Registry.AddKey2Registry("PublishClient", "CurrentUserName", result[2]);
                        isCatch = true;
                    }
                    catch (Exception ex)
                    {
                        Type type = ex.GetType();
                        if (type == typeof(TimeoutException))
                        {
                            // 超时异常，不中断连接
                            Console.WriteLine("{0} [client {1}]: 数据超时失败！",
                            DateTime.Now, threadID);
                        }
                        else
                        {
                            // 仍旧抛出异常，中断连接
                            Console.WriteLine("{0} [client {1}]: 中断连接异常原因：{2}！",
                            DateTime.Now, threadID, type.Name);
                            throw ex;
                        }
                    }
                }
            }
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
            if (uac.Contains(' ') || upw.Contains(' '))
            {
                MessageBox.Show("任何字段不得包含空格与回车字符！", "输入错误", MessageBoxButtons.OK);
                return;
            }
            upw = Cipher.md5Encrypt(upw);
            string question = "Login " + uac + " " + upw;
            string ret;
            tcpClientLogin.Query(question, out ret);
            // 用户不存在
            if (ret == VerMessage.LOGIN_FAILED_NO_SUCH_USER)
            {
                string msg = "用户[" + uac + "]不存在！";
                MessageBox.Show(msg, "用户错误", MessageBoxButtons.OK);
                return;
            }
            // 检查密码
            if (ret == VerMessage.LOGIN_FAILED_WRONG_PW)
            {
                string msg = "用户[" + uac + "]密码错误！";
                MessageBox.Show(msg, "密码错误", MessageBoxButtons.OK);
                return;
            }
            // 成功登陆
            if (ret == VerMessage.LOGIN_SUCCESS)
            {
                string msg = "用户[" + uac + "]登录成功。正在初始化数据，请稍等。";
                MessageBox.Show(msg, "登陆成功", MessageBoxButtons.OK);
                isLogin = true;
                while (!isCatch) Thread.Sleep(100);
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
            if (uac.Contains(' ') || upw.Contains(' ') || ucl.Contains(' '))
            {
                MessageBox.Show("任何字段不得包含空格与回车字符！", "输入错误", MessageBoxButtons.OK);
                return;
            }
            upw = Cipher.md5Encrypt(upw);
            string question = "Reg " + uac + " " + upw + " " + ucl;
            string ret;
            tcpClientLogin.Query(question, out ret);
            // 用户已经存在
            if (ret == VerMessage.REG_FAILED_NAME_CONFLICT)
            {
                string msg = "用户[" + uac + "]已经存在！注册失败。\n请更换用户名重试。";
                MessageBox.Show(msg, "注册失败。", MessageBoxButtons.OK);
                return;
            }
            // 注册意外失败
            if (ret == VerMessage.REG_FAILED_OTHER_PROBLEM)
            {
                MessageBox.Show("注册出现意外的失败，请更换用户名重试。", "注册失败", MessageBoxButtons.OK);
                return;
            }
            // 注册成功
            if (ret == VerMessage.REG_SUCCESS)
            {
                MessageBox.Show("用户[" + uac + "]注册成功。\n请登录。", "注册成功", MessageBoxButtons.OK);
                // 转到登陆界面
                this.tabControl1.SelectTab(this.tabPage1);
                this.textBox_UesrAccount.Text = uac;
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

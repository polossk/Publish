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
using System.Collections;
using System.Net;
using Universal.Global;
using Universal.Net;
using Universal.User;

namespace PublishClient
{
    public partial class Form_Main : Form
    {
        // 登陆端口
        IPAddress serverIP;
        TcpClientP tcpClientLogoff; // 56666

        // 从服务端获取个人信息
        string uid, uac, ucl, upw;


        public Form_Main()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 运行时预加载项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Main_Load(object sender, EventArgs e)
        {
            serverIP = IPAddress.Parse(Registry.ReadKey4Registry("PublishClient", "ServerIP"));
            uid = Registry.ReadKey4Registry("PublishClient", "CurrentUserID");
            int idNumeric = int.Parse(uid);
            uid = idNumeric.ToString("D6");
            uac = Registry.ReadKey4Registry("PublishClient", "CurrentUserAccount");
            ucl = Registry.ReadKey4Registry("PublishClient", "CurrentUserName");
            upw = Registry.ReadKey4Registry("PublishClient", "CurrentUserPW");
            // 设置窗口属性
            this.Text = "教材补助经费评估软件 [" + ucl + "]" + " [#" + uid + "]";
            this.label_ClientName.Text = "[#" + uid + "] " + ucl;

        }

        private void Form_Main_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (TryLogoff())
                MessageBox.Show("登出成功", "Success", MessageBoxButtons.OK);
            else MessageBox.Show("登出失败", "Fail", MessageBoxButtons.OK);
            tcpClientLogoff.Close();
        }

        public bool TryLogoff()
        {
            // 登出系统
            string question, answer;
            tcpClientLogoff = new TcpClientP();
            try { tcpClientLogoff.Connect(serverIP, Port.TCP_LOGIN_PORT); }
            catch (Exception) { return false; }
            question = "Logoff " + uac;
            tcpClientLogoff.Query(question, out answer);
            if (answer == VerMessage.LOGOFF_SUCCESS)
                return true;
            return false;
        }

        private void button_About_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog();
        }

        private void button_User_Click(object sender, EventArgs e)
        {
            User person = new User(int.Parse(uid), uac, ucl, upw);
            Form_User user = new Form_User(person);
            user.ReturnUser += (o, e1) =>
            {
                if (!e1.CanUpdate) return;
                User now = e1.Me;
                // 更新资料
                string question = "Change " + now.GetRawString(), answer;
                TcpClientP request = new TcpClientP();
                request.Connect(serverIP, Port.TCP_LOGIN_PORT);
                request.Query(question, out answer);
                if (answer != VerMessage.CHANGE_SUCCESS)
                {
                    MessageBox.Show("更新信息失败", "提示", MessageBoxButtons.OK);
                    request.Close();
                    return;
                }
                MessageBox.Show("更新信息成功", "提示", MessageBoxButtons.OK);
                request.Close();
                ucl = now.name;
                Registry.AddKey2Registry("PublishClient", "CurrentUserName", ucl);
                this.Text = "教材补助经费评估软件 [" + ucl + "]" + " [#" + uid + "]";
                this.label_ClientName.Text = "[#" + uid + "] " + ucl;
            };
            user.ShowDialog();
        }
    }
}

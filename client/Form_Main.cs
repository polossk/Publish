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

namespace PublishClient
{
    public partial class Form_Main : Form
    {
        // 登陆端口
        IPAddress serverIP;
        TcpClientP tcpClientLogoff; // 56666

        // 从服务端获取个人信息
        int uid;
        string uac, ucl;


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
            tcpClientLogoff = new TcpClientP();
            tcpClientLogoff.Connect(serverIP, Port.TCP_LOGIN_PORT);
            uid = int.Parse(Registry.ReadKey4Registry("PublishClient", "CurrentUserID"));
            uac = Registry.ReadKey4Registry("PublishClient", "CurrentUserAccount");
            ucl = Registry.ReadKey4Registry("PublishClient", "CurrentUserName");
            // 设置窗口属性
            this.Text = "教材补助经费评估软件 [" + ucl + "]" + " [#" + Convert.ToString(uid) + "]";
        }

        /// <summary>
        /// 关闭窗口时保存数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Main_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            TryLogoff();
            tcpClientLogoff.Close();
        }

        public bool TryLogoff()
        {
            // 登出系统
            string question, answer;
            question = "Logoff " + uac;
            tcpClientLogoff.Query(question, out answer);
            if (answer == VerMessage.LOGOFF_SUCCESS)
                return true;
            return false;
        }
    }
}

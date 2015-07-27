using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using Universal.Global;
using Universal.Net;

namespace PublishClient
{
    public partial class Form_Connect : Form
    {
        //  网络连接相关
        IPAddress       serverIP;               // IPAddress.Any
        UDPMessage      backgroundClient;       // 57777

        // 网络相关线程列表
        Thread listenBroadcast;

        public Form_Connect()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.button_Exit.Enabled = true;
            this.timer1.Enabled = false;
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            if (listenBroadcast.IsAlive) listenBroadcast.Abort();
            try { this.listenBroadcast.Join(); } catch { }
            this.Close();
        }

        private void OnLoad_Connect(object sender, EventArgs e)
        {
            this.button_Exit.Enabled = false;
            serverIP = IPAddress.Any;
            backgroundClient = new UDPMessage();
            listenBroadcast = new Thread(
                () => { serverIP = backgroundClient.OnListenBroadcast(9999); }
            );
            listenBroadcast.Start();
            Thread watcher = new Thread(WatchServerIP);
            watcher.Start();
        }

        private void WatchServerIP()
        {
            while (true)
            {
                var tmp = serverIP;
                if (tmp != IPAddress.Any) break;
                else Thread.Sleep(100);
            }
            FindServer();
        }

        private void FindServer()
        {
            listenBroadcast.Join();
            this.label_Title.Text = "已经找到服务器。";
            this.label_ShowIP.Text = "服务器地址为：[" + serverIP.ToString() + "]";
            this.button_Launch.Enabled = true;
        }

    }

    

}

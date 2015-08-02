﻿using System;
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
using System.Threading;
using System.Net;
using System.Net.Sockets;
using Universal.Net;
using Universal.Global;

namespace PublishServer
{
    public partial class Form_Main : Form
    {
        // WTF class
        NotStatic __tmp__;
        
        // 用户信息
        UserSet users;
        string rtUserPath;

        // 登陆用户信息
        ClientTable onlineUsers;

        // 网络客户端口
        UDPMessage      backgroundServer;       // 57777
        TcpListenerP    tcpServerLogin;         // 56666
        TcpClientP      tcpClientUserFile;      // 56655
        TcpListenerP    tcpServerRecvMessage;   // 58888
        TcpClientP      tcpClientSendMessage;   // 59999
        TcpClientP      tcpClientBroadcast;     // 59966
        TcpClientP      tcpClientBookInfo;      // 56677
        TcpListenerP    tcpServerBookEvau;      // 56688

        // 网络相关线程列表
        Thread udpThread;
        Thread loginThread;
        Thread recvThread;
        Thread sendThread;
        Thread mutiSendThread;
        Thread mainRecvThread;

        public Form_Main()
        {
            InitializeComponent();
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            __tmp__ = new NotStatic();
            onlineUsers = new ClientTable();
            // 加载用户列表
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
            // 开始 UDP 广播
            backgroundServer = new UDPMessage();
            udpThread = new Thread(
                () => {
                    backgroundServer.OnBroadcast(
                        threadID: 9999,
                        port: Port.DEFAULT_BROADCAST_PORT,
                        ver: VerMessage.PUBLIC_VERIFICATION
                    );
                }
            );
            udpThread.IsBackground = true;
            udpThread.Start();

            // 所有 TCP 监听端口就绪
            tcpServerLogin = new TcpListenerP(new IPEndPoint(IPAddress.Any, 56666));
            tcpServerLogin.OnThreadTaskRequest += new TcpListenerP.ThreadTaskRequest(OnListenClient);

            // 初始化所有 TCP 客户端
            tcpClientUserFile = new TcpClientP();
        }

        /// <summary>
        /// 关闭窗口时保存数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Main_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            saveUsersData(rtUserPath);
            tcpServerLogin.Stop();
        }

        public void OnListen(object sender, EventArgs e)
        {
            // TODO
            TcpClient tcpClient = sender as TcpClient;
            int threadID = 7777;
            Console.WriteLine("On Listen...");
            using (NetworkStreamP buf = new NetworkStreamP(tcpClient.GetStream()))
            {
                buf.ReceiveBufferSize = tcpClient.ReceiveBufferSize;
                while (true)
                {
                    try
                    {
                        string q, a;
                        buf.Read(out q);
                        a = q.ToUpper();
                        buf.Write(a);
                        DateTime now = DateTime.Now;
                        IPEndPoint where = tcpClient.Client.RemoteEndPoint as IPEndPoint;
                        Console.WriteLine("{0} [host {1}]: receive message from [{2}:{3}]",
                            now, threadID, where.Address.ToString(), where.Port.ToString());
                        Console.WriteLine("{0} [host {1}]: receive message [{2}]",
                            now, threadID, q);
                    }
                    catch (Exception ex)
                    {
                        Type type = ex.GetType();
                        if (type == typeof(TimeoutException))
                        {   // 超时异常，不中断连接
                            Console.WriteLine("{0} [host {1}]: 数据超时失败！",
                            DateTime.Now, threadID);
                        }
                        else
                        {
                            // 仍旧抛出异常，中断连接
                            Console.WriteLine("{0} [host {1}]: 中断连接异常原因：{2}！",
                            DateTime.Now, threadID, type.Name);
                            throw ex;
                        }
                    }
                }
            }
        }

        public void OnClientLogin(ref IPAddress where, ref string[] result, out string answer)
        {
            User client; answer = VerMessage.DEFAULT_RESPONSE;
            int idx = users.find(result[1], out client);
            // 用户不存在
            if (idx == -1)
            {
                answer = VerMessage.LOGIN_FAILED_NO_SUCH_USER;
                return;
            }
            // 检查密码
            if (!client.testPassword(result[2]))
            {
                answer = VerMessage.LOGIN_FAILED_WRONG_PW;
                return;
            }
            // 发送用户个人资料
            tcpClientUserFile = new TcpClientP();
            tcpClientUserFile.Connect(new IPEndPoint(where, Port.TCP_USER_FILE_PORT));
            string data = client.toUserFile();
            tcpClientUserFile.Write(data);
            tcpClientUserFile.Close();
            // 加入连接列表
            Client login = new Client(where, client);
            onlineUsers.AddClient(login);
            // 反馈消息
            answer = VerMessage.LOGIN_SUCCESS;
        }

        public void OnClientReg(ref string[] result, out string answer)
        {
            User client; answer = VerMessage.DEFAULT_RESPONSE;
            int idx = users.find(result[1], out client);
            // 用户已经存在
            if (idx >= 0)
            {
                answer = VerMessage.REG_FAILED_NAME_CONFLICT;
                return;
            }
            // 正常注册流程
            int uid = users.getNewUID();
            User one = new User(uid, result[1], result[3], result[2]);
            bool success = users.addUser(one);
            if (success)
            {
                answer = VerMessage.REG_SUCCESS;
                saveUsersData(rtUserPath);
            }
            else
                answer = VerMessage.REG_FAILED_OTHER_PROBLEM;
        }

        public void OnClientLogoff(ref string[] result, out string answer)
        {
            User client; answer = VerMessage.DEFAULT_RESPONSE;
            int idx = users.find(result[1], out client);
            if (idx == -1)
            {
                answer = VerMessage.LOGOFF_FAILED_NO_SUCH_USER;
                return;
            }
            Client guy;
            if (onlineUsers.QueryClient(result[1], out guy))
            {
                onlineUsers.RemoveClient(result[1]);
                answer = VerMessage.LOGOFF_SUCCESS;
            }
            else answer = VerMessage.LOGOFF_FAILED_NOT_LOGIN;
        }


        public void OnListenClient(object sender, EventArgs e)
        {
            TcpClient tcpClient = sender as TcpClient;
            int threadID = Port.TCP_LOGIN_PORT % 10000;
            using (NetworkStreamP buf = new NetworkStreamP(tcpClient.GetStream()))
            {
                buf.ReceiveBufferSize = tcpClient.ReceiveBufferSize;
                while (true)
                {
                    try
                    {
                        IPEndPoint where = tcpClient.Client.RemoteEndPoint as IPEndPoint;
                        IPAddress clientIP = where.Address;
                        string question, answer;
                        buf.Read(out question);
                        string[] result = question.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        switch (result[0])
                        {
                            case "Login":
                                OnClientLogin(ref clientIP, ref result, out answer);
                                break;
                            case "Reg":
                                OnClientReg(ref result, out answer);
                                break;
                            case "Logoff":
                                OnClientLogoff(ref result, out answer);
                                break;
                            default: answer = VerMessage.DEFAULT_RESPONSE; break;
                        }
                        buf.Write(answer);
                    }
                    catch (Exception ex)
                    {
                        Type type = ex.GetType();
                        if (type == typeof(TimeoutException))
                        {
                            // 超时异常，不中断连接
                            Console.WriteLine("{0} [host {1}]: 数据超时失败！",
                            DateTime.Now, threadID);
                        }
                        else
                        {
                            // 仍旧抛出异常，中断连接
                            Console.WriteLine("{0} [host {1}]: 中断连接异常原因：{2}！",
                            DateTime.Now, threadID, type.Name);
                            throw ex;
                        }
                    }
                }
            }
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
    }
}

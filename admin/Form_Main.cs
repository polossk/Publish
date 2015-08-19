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
using System.Threading;
using System.Net;
using System.Net.Sockets;
using Universal.Net;
using Universal.Global;
using Universal.Data;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

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

        // 教材信息表
        BookDetailList bList;

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

        // 列表排序记录
        int[] _Sort_Record = new int[16];

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
                LoadUsersData(rtUserPath);
            else
            {
                FileStream fs = fi.Create();
                fs.Close();
                users = new UserSet();
                SaveUsersData(rtUserPath);
            }

            // 调整窗口属性
            string uid = Registry.ReadKey4Registry("PublishServer", "CurrentUserID");
            int idNumeric = int.Parse(uid);
            uid = idNumeric.ToString("D6");
            string uac = Registry.ReadKey4Registry("PublishServer", "CurrentUserAccount");
            string ucl = Registry.ReadKey4Registry("PublishServer", "CurrentUserName");
            this.Text = "教材补助经费评估软件 [" + ucl + "]" + " [#" + uid + "]";

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

            // 初始化用户个人信息
            this.label_AdminTitle.Text += "[#" + uid + "]";
            this.label_AdminName.Text = ucl;

            // 所有 TCP 监听端口就绪
            tcpServerLogin = new TcpListenerP(new IPEndPoint(IPAddress.Any, 56666));
            tcpServerLogin.OnThreadTaskRequest += new TcpListenerP.ThreadTaskRequest(OnListenClient);

            // 初始化所有 TCP 客户端
            tcpClientUserFile = new TcpClientP();

            // 初始化教材列表
            bList = new BookDetailList();

            // 初始化教材列表显示
            ResetListViewBooks();

            

        }


        private void ResetListViewBooks()
        {
            // 初始化教材列表显示
            listView_Books.Clear();
            listView_Books.Columns.Add("lstBookID", "教材编号");
            listView_Books.Columns.Add("lstInfoName", "教材名称");
            listView_Books.Columns.Add("lstInfoAuth", "作者");
            listView_Books.Columns.Add("lstInfoATit", "作者职称");
            listView_Books.Columns.Add("lstInfoPbsh", "出版社");
            listView_Books.Columns.Add("lstInfoBlng", "教材类别");
            listView_Books.Columns.Add("lstInfoAttr", "教材属性");
            listView_Books.Columns.Add("lstPrintWord", "教材字数");
            listView_Books.Columns.Add("lstPrintBind", "装订规格");
            listView_Books.Columns.Add("lstPrintSize", "开本大小");
            listView_Books.Columns.Add("lstPrintCnts", "册数");
            listView_Books.Columns.Add("lstPrintPapr", "正文用纸");
            listView_Books.Columns.Add("lstPrintColr", "是否彩印");
            listView_Books.ListViewItemSorter = new ListViewBooksSorter();
            for (int i = 0; i < _Sort_Record.Length; i++) _Sort_Record[i] = 0;
        }

        private void SetWidthListViewBooks(int val)
        {
        	listView_Books.Columns["lstBookID"].Width = val;
            listView_Books.Columns["lstInfoName"].Width = val;
            listView_Books.Columns["lstInfoAuth"].Width = val;
            listView_Books.Columns["lstInfoATit"].Width = val;
            listView_Books.Columns["lstInfoPbsh"].Width = val;
            listView_Books.Columns["lstInfoBlng"].Width = val;
            listView_Books.Columns["lstInfoAttr"].Width = val;
            listView_Books.Columns["lstPrintWord"].Width = val;
            listView_Books.Columns["lstPrintBind"].Width = val;
            listView_Books.Columns["lstPrintSize"].Width = val;
            listView_Books.Columns["lstPrintCnts"].Width = val;
            listView_Books.Columns["lstPrintPapr"].Width = val;
            listView_Books.Columns["lstPrintColr"].Width = val;
        }

        /// <summary>
        /// 关闭窗口时保存数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Main_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            SaveUsersData(rtUserPath);
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
            int idx = users.Find(result[1], out client);
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
            int idx = users.Find(result[1], out client);
            // 用户已经存在
            if (idx >= 0)
            {
                answer = VerMessage.REG_FAILED_NAME_CONFLICT;
                return;
            }
            // 正常注册流程
            int uid = users.GetNewUID();
            User one = new User(uid, result[1], result[3], result[2]);
            bool success = users.AddUser(one);
            if (success)
            {
                answer = VerMessage.REG_SUCCESS;
                SaveUsersData(rtUserPath);
            }
            else
                answer = VerMessage.REG_FAILED_OTHER_PROBLEM;
        }

        public void OnClientLogoff(ref string[] result, out string answer)
        {
            User client; answer = VerMessage.DEFAULT_RESPONSE;
            int idx = users.Find(result[1], out client);
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
        private void LoadUsersData(string path)
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
        private void SaveUsersData(string path)
        {
            FileStream fileStream = new FileStream(path, FileMode.Create);
            byte[] serBytes;
            ToBytes<UserSet>.GetBytes(ref users, out serBytes);
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

        private void RefreshAllBookList(bool isClearAll = false)
        {
            listView_Books.Items.Clear();
            foreach (var item in bList.__list)
            {
                string bid = item.BookID.ToString();
                ListViewItem tar = listView_Books.Items.Add(bid);
                for (int j = 1; j <= 6; j++)
                {
                    tar.SubItems.Add(item.BookInfo._rawData_[j - 1]);
                }
                for (int j = 1; j <= 6; j++)
                {
                    tar.SubItems.Add(item.BookPrint._rawData_[j - 1]);
                }
            }
            if (isClearAll)
                SetWidthListViewBooks(60);
            else
                SetWidthListViewBooks(-2);
        }

        private void openExcelFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            TryOpenExcel(openExcelFileDialog.FileName);
            RefreshAllBookList();
        }

        private void buttonOpenExcelFile_Click(object sender, EventArgs e)
        {
            this.openExcelFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            this.openExcelFileDialog.ShowDialog();
        }

        private void saveExcelFileDialog_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void TryOpenExcel(string name)
        {
            ExcelOperator excel = new ExcelOperator();
            excel.OpenExcel(name);
            int idxRow = 2;
            while (true)
            {
                Range test = excel[idxRow, 1];
                if (test.Value2 == null) break;
                else idxRow++;
            }
            int cnt = idxRow;
            Form_ImportProgress fip = new Form_ImportProgress(cnt - 2);
            fip.Show();
            for (idxRow = 2; idxRow < cnt; idxRow++ )
            {
                Range range = excel[idxRow, 1];
                string[] raw1 = new string[6];
                for (int idxColumn = 1; idxColumn <= 6; idxColumn++)
                {
                    Range cell = excel[idxRow, idxColumn];
                    raw1[idxColumn - 1] = cell.Value2;
                }
                if (bList.isExist(raw1[0], raw1[1], raw1[3])) continue;
                string[] raw2 = new string[6];
                int word = (int)Math.Round(excel[idxRow, 7].Value2);
                raw2[0] = word.ToString();
                for (int idxColumn = 8; idxColumn <= 12; idxColumn++)
                {
                    Range cell = excel[idxRow, idxColumn];
                    raw2[idxColumn - 7] = (string)cell.Value2;
                }
                BookDetail item = new BookDetail(0, raw1, raw2);
                bList.Add(bList.getNextBID(), item);
                // ProgressBar
                fip.ChangeTo(idxRow - 1);
            }
            excel.QuitExcel();
            fip.Close();
        }

        private void listViewBooks_DoubleClick(object sender, EventArgs e)
        {
            int lineNumber = this.listView_Books.SelectedIndices[0];
            var line = this.listView_Books.Items[lineNumber];
            string bid = line.SubItems[0].Text;
            int id = int.Parse(bid);
            BookDetail book;
            if (!bList.tryFind(id, out book)) return;
            Form_Item item = new Form_Item(book);
            item.ReturnBook += (o, e1) =>
            {
                BookDetail tmp = item.book;
                tmp.BookInfo.buildRawData();
                tmp.BookPrint.buildRawData();
                // 填充到 BookList
                bList.ReplaceTo(id, tmp);
                BookDetail now; bList.tryFind(id, out now);
                // 重新整理内容到 ListView
                RefreshBookList(ref now, ref line);
            };
            item.ShowDialog();
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            int cur = bList.nextBookID;
            Form_Item item = new Form_Item(cur);
            item.ReturnBook += (o, e1) =>
            {
                BookDetail now = item.book;
                now.BookInfo.buildRawData();
                now.BookPrint.buildRawData();
                // 填充到 BookList
                bList.Add(cur, now, true);
                // 重新整理内容到 ListView
                ListViewItem line = listView_Books.Items.Add(cur.ToString());
                for (int i = 0; i < 12; i++) line.SubItems.Add("");
                RefreshBookList(ref now, ref line);
                if (listView_Books.Items.Count <= 1)
                    SetWidthListViewBooks(-2);
            };
            item.ShowDialog();
        }

        private void RefreshBookList(ref BookDetail now, ref ListViewItem line)
        {
            for (int i = 0; i < 6; i++)
            {
                line.SubItems[1 + i].Text = now.BookInfo._rawData_[i];
            }
            for (int i = 0; i < 6; i++)
            {
                line.SubItems[7 + i].Text = now.BookPrint._rawData_[i];
            }
        }
        #region 添加右键菜单 前值准备部分
        // The area occupied by the ListView header. 
        private System.Drawing.Rectangle _headerRect;

        // Delegate that is called for each child window of the ListView. 
        private delegate bool EnumWinCallBack(IntPtr hwnd, IntPtr lParam);

        // Calls EnumWinCallBack for each child window of hWndParent (i.e. the ListView).
        [DllImport("user32.Dll")]
        private static extern int EnumChildWindows(
            IntPtr hWndParent,
            EnumWinCallBack callBackFunc,
            IntPtr lParam);

        // Gets the bounding rectangle of the specified window (ListView header bar). 
        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        // This should get called with the only child window of the ListView,
        // which should be the header bar.
        private bool EnumWindowCallBack(IntPtr hwnd, IntPtr lParam)
        {
            // Determine the rectangle of the ListView header bar and save it in _headerRect.
            RECT rct;
            if (!GetWindowRect(hwnd, out rct))
            {
                _headerRect = System.Drawing.Rectangle.Empty;
            }
            else
            {
                _headerRect = new System.Drawing.Rectangle(
                rct.Left, rct.Top, rct.Right - rct.Left, rct.Bottom - rct.Top);
            }
            return false; // Stop the enum
        }

        #endregion

        private void contextMenuStrip_BookList_Opening(object sender, CancelEventArgs e)
        {
            // This call indirectly calls EnumWindowCallBack which sets _headerRect
            // to the area occupied by the ListView's header bar.
            EnumChildWindows(
                this.listView_Books.Handle, new EnumWinCallBack(EnumWindowCallBack), IntPtr.Zero);

            // If the mouse position is in the header bar, cancel the display
            // of the regular context menu and display the column header context 
            // menu instead.
            if (_headerRect.Contains(Control.MousePosition))
            {
                this.tSMI_Sendto.Enabled = false;
                this.tSMI_Modify.Enabled = false;
                this.tSMI_Delete.Enabled = false;
                this.tSMI_ClearAll.Enabled = this.listView_Books.Items.Count != 0;
            }
            else
            {
                this.tSMI_Sendto.Enabled = this.listView_Books.SelectedItems.Count >= 1;
                this.tSMI_Modify.Enabled = this.listView_Books.SelectedItems.Count == 1;
                this.tSMI_Delete.Enabled = this.listView_Books.SelectedItems.Count >= 1;
                this.tSMI_ClearAll.Enabled = this.listView_Books.Items.Count != 0;
            }
        }

        

        private void button_User_Click(object sender, EventArgs e)
        {
            // TODO
            // 找到用户并且调用
            User person;
            string uac = Registry.ReadKey4Registry("PublishServer", "CurrentUserAccount");
            users.Find(uac, out person);
            Form_User user = new Form_User(person);
            user.ReturnUser += (o, e1) =>
            {
                User now = user.me;
                users.ReplaceTo(uac, now);
                SaveUsersData(rtUserPath);
            };
            user.ShowDialog();
        }

        private void saveDataFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            string path = this.saveDataFileDialog.FileName;
            FileStream fileStream = new FileStream(path, FileMode.Create);
            byte[] serBytes;
            ToBytes<BookDetailList>.GetBytes(ref bList, out serBytes);
            fileStream.Write(serBytes, 0, serBytes.Length);
            fileStream.Flush();
            fileStream.Close();
            fileStream.Dispose();
        }

        private void button_BookListSave_Click(object sender, EventArgs e)
        {
            this.saveDataFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            this.saveDataFileDialog.FileName = "";
            this.saveDataFileDialog.ShowDialog();
        }

        private void openDataFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            string path = this.openDataFileDialog.FileName;
            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            BinaryReader rd = new BinaryReader(fileStream);
            rd.BaseStream.Seek(0, SeekOrigin.Begin);
            byte[] raw = rd.ReadBytes((int)rd.BaseStream.Length);
            MemoryStream buf = new MemoryStream(raw);
            BinaryFormatter bf = new BinaryFormatter();
            BookDetailList another = bf.Deserialize(buf) as BookDetailList;
            // 释放文件流资源
            fileStream.Flush();
            fileStream.Close();
            fileStream.Dispose();
            // 合并数据表
            bList.MergeWith(another);
            RefreshAllBookList();
        }

        private void button_BookListLoad_Click(object sender, EventArgs e)
        {
            this.openDataFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            this.openDataFileDialog.ShowDialog();
        }

        private void button_About_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog();
        }

        
        private void listViewBooks_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (listView_Books.Items.Count == 0) return;
            System.Windows.Forms.ListView lv = sender as System.Windows.Forms.ListView;
            _Sort_Record[e.Column] = (_Sort_Record[e.Column] + 1) % 3;
            for (int i = 0; i < listView_Books.Columns.Count; i++)
                this.listView_Books.Columns[i].Text = 
                    this.listView_Books.Columns[i].Text.Trim((char)0x25bc, (char)0x25b2, ' ');
            string Asc = ((char)0x25b2).ToString().PadLeft(2, ' ');
            string Des = ((char)0x25bc).ToString().PadLeft(2, ' ');
            string lable = this.listView_Books.Columns[e.Column].Text;


            switch (_Sort_Record[e.Column])
            {
                case 0: // 默认 BookID 排序
                    // this.listView_Books.Columns[e.Column].Text = lable;
                    (lv.ListViewItemSorter as ListViewBooksSorter).SortColumn = 0;
                    (lv.ListViewItemSorter as ListViewBooksSorter).Order = System.Windows.Forms.SortOrder.Ascending;
                    break;
                case 1: // 当前列升序
                    this.listView_Books.Columns[e.Column].Text = lable + Asc;
                    (lv.ListViewItemSorter as ListViewBooksSorter).SortColumn = e.Column;
                    (lv.ListViewItemSorter as ListViewBooksSorter).Order = System.Windows.Forms.SortOrder.Ascending;
                    break;
                case 2: // 当前列降序
                    this.listView_Books.Columns[e.Column].Text = lable + Des;
                    (lv.ListViewItemSorter as ListViewBooksSorter).SortColumn = e.Column;
                    (lv.ListViewItemSorter as ListViewBooksSorter).Order = System.Windows.Forms.SortOrder.Descending;
                    break;
                default: break;
            }
            ((System.Windows.Forms.ListView)sender).Sort();
            SetWidthListViewBooks(-2);
        }

        private void tSMI_Add_Click(object sender, EventArgs e)
        {
            button_Add_Click(sender, e);
        }

        private void tSMI_Modify_Click(object sender, EventArgs e)
        {
            listViewBooks_DoubleClick(sender, e);
        }

        private void tSMI_Delete_Click(object sender, EventArgs e)
        {
            int lineNumber = this.listView_Books.SelectedIndices[0];
            var line = this.listView_Books.Items[lineNumber];
            string bid = line.SubItems[0].Text;
            int id = int.Parse(bid);
            BookDetail book;
            if (!bList.tryFind(id, out book)) return;
            bList.__list.Remove(book);
            RefreshAllBookList();
        }

        private void tSMI_ClearAll_Click(object sender, EventArgs e)
        {
            bList.ClearAll();
            ResetListViewBooks();
        }

        private void tSMI_Sendto_Click(object sender, EventArgs e)
        {

        }


        
    }
}

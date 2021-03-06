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
using Universal.Data;
using Universal.User;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace PublishClient
{
    public partial class Form_Main : Form
    {
        // 登陆端口
        IPAddress serverIP;
        TcpClientP tcpClientLogoff; // Port.TCP_LOGIN_PORT
        TcpListenerP tcpServerGet;  // Port.TCP_BOOK_INFORMATION_PORT

        // 从服务端获取个人信息
        string uid, uac, ucl, upw;
        int idNumeric;

        // 列表排序记录
        int[] _Sort_Record = new int[8];
        BookInformationList BookList;
        BookEvaluaionList BookEval;

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
            idNumeric = int.Parse(uid);
            uid = idNumeric.ToString("D6");
            uac = Registry.ReadKey4Registry("PublishClient", "CurrentUserAccount");
            ucl = Registry.ReadKey4Registry("PublishClient", "CurrentUserName");
            upw = Registry.ReadKey4Registry("PublishClient", "CurrentUserPW");
            
            // 设置窗口属性
            this.Text = "教材补助经费评估软件 [" + ucl + "]" + " [#" + uid + "]";
            this.label_ClientName.Text = "[#" + uid + "] " + ucl;
            
            // 准备 TCP 监听
            tcpServerGet = new TcpListenerP(new IPEndPoint(IPAddress.Any, Port.TCP_BOOK_INFORMATION_PORT));
            tcpServerGet.OnThreadTaskRequest += new TcpListenerP.ThreadTaskRequest(OnListenBookInfo);
            

            // 准备数据集
            BookList = new BookInformationList();
            BookEval = new BookEvaluaionList();

            // 初始化列表显示
            ResetListView_Books();
        }

        private void ResetListView_Books()
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
            listView_Books.Columns.Add("lstDone", "是否评价");
            listView_Books.ListViewItemSorter = new ListViewBooksSorter();
            for (int i = 0; i < _Sort_Record.Length; i++) _Sort_Record[i] = 0;
        }

        private void SetWidthListView_Books(int val)
        {
            listView_Books.Columns["lstBookID"].Width = val;
            listView_Books.Columns["lstInfoName"].Width = val;
            listView_Books.Columns["lstInfoAuth"].Width = val;
            listView_Books.Columns["lstInfoATit"].Width = val;
            listView_Books.Columns["lstInfoPbsh"].Width = val;
            listView_Books.Columns["lstInfoBlng"].Width = val;
            listView_Books.Columns["lstInfoAttr"].Width = val;
            listView_Books.Columns["lstDone"].Width = val;
        }

        private void RefreshAllBookList(bool isClearAll = false)
        {
            listView_Books.Items.Clear();
            foreach (var item in BookList.Data)
            {
                string bid = item.BookID.ToString();
                ListViewItem tar = listView_Books.Items.Add(bid);
                for (int j = 1; j <= 6; j++)
                {
                    tar.SubItems.Add(item.BookInfo._rawData_[j - 1]);
                }
                if (BookEval.isExist(item.BookID))
                    tar.SubItems.Add("是");
                else tar.SubItems.Add("否");
            }
            if (isClearAll)
                SetWidthListView_Books(60);
            else
                SetWidthListView_Books(-2);
        }

        private delegate void AddBookInfoList_dele(BookInformationList val);

        private void AddBookInfoList(BookInformationList val)
        {
            BookList.MergeWith(val);
            RefreshAllBookList();
        }

        public void OnListenBookInfo(object sender, EventArgs e)
        {
            TcpClient tcpClient = sender as TcpClient;
            int threadID = Port.TCP_BOOK_INFORMATION_PORT % 10000;
            Console.WriteLine("On Listen...");
            using (NetworkStreamP buf = new NetworkStreamP(tcpClient.GetStream()))
            {
                buf.ReceiveBufferSize = tcpClient.ReceiveBufferSize;
                while (true)
                {
                    try
                    {
                        byte[] raw; buf.Read(out raw);
                        MemoryStream ms = new MemoryStream(raw);
                        BinaryFormatter bf = new BinaryFormatter();
                        BookInformationList another = bf.Deserialize(ms) as BookInformationList;
                        Invoke(new AddBookInfoList_dele(AddBookInfoList), new object[] { another });
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


        private void Form_Main_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (TryLogoff())
                MessageBox.Show("登出成功", "Success", MessageBoxButtons.OK);
            else MessageBox.Show("登出失败", "Fail", MessageBoxButtons.OK);
            tcpClientLogoff.Close();
            tcpServerGet.Stop();
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

        private void listViewBooks_DoubleClick(object sender, EventArgs e)
        {
            int lineNumber = this.listView_Books.SelectedIndices[0];
            var line = this.listView_Books.Items[lineNumber];
            string bid = line.SubItems[0].Text;
            int id = int.Parse(bid);
            BookInformation book;
            if (!BookList.tryFind(id, out book)) return;
            BookEvaluaion rank;
            bool isNewComer = !BookEval.tryFind(id, out rank);
            Form_Item item = new Form_Item(book, rank, idNumeric, ucl, isNewComer);
            item.ReturnBook += (o, e1) =>
            {
                if (!e1.CanUpdate) return;
                BookInformation info = e1.Book;
                BookEvaluaion value = e1.Rank;
                if (isNewComer) BookEval.Add(value);
                else BookEval.ReplaceTo(id, value);
                RefreshBookList(ref info, ref line);
            };
            item.ShowDialog();
        }

        private void RefreshBookList(ref BookInformation now, ref ListViewItem line)
        {
            for (int i = 0; i < 6; i++)
            {
                line.SubItems[1 + i].Text = now.BookInfo._rawData_[i];
            }
            line.SubItems[7].Text = "是";
        }


        #region 添加右键菜单
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
            BookInformation book; BookEvaluaion rank;
            if (!BookList.tryFind(id, out book)) return;
            BookList.Data.Remove(book);
            if (BookEval.tryFind(id, out rank))
                BookEval.Data.Remove(rank);
            RefreshAllBookList();
        }

        private void tSMI_ClearAll_Click(object sender, EventArgs e)
        {
            BookList.ClearAll();
            BookEval.ClearAll();
            ResetListView_Books();
        }



        #endregion

        private void tSMI_Sendto_Click(object sender, EventArgs e)
        {
            BookEvaluaionList data = new BookEvaluaionList();
            for (int i = 0, sz = listView_Books.SelectedItems.Count; i < sz; i++)
            {
                string id = listView_Books.SelectedItems[i].SubItems[0].Text;
                BookEvaluaion tmp = new BookEvaluaion();
                BookEval.tryFind(int.Parse(id), out tmp);
                data.Add(tmp);
            }
            byte[] raw;
            ToBytes<BookEvaluaionList>.GetBytes(ref data, out raw);
            TcpClientP home = new TcpClientP();
            home.Connect(new IPEndPoint(serverIP, Port.TCP_BOOK_EVALUATION_PORT));
            home.Write(raw);
            home.Close();
            MessageBox.Show("发送成功", "提示", MessageBoxButtons.OK);
        }

        #region 主界面按列排序组件
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
            SetWidthListView_Books(-2);
        }
        #endregion

        
    }
}

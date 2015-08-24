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
using Universal.User;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace PublishServer
{
    public partial class Form_Result : Form
    {
        private BookCosting Cost { get; set; }
        private string AppPath { get; set; }
        private List<BookFinal> FinalList { get; set; }
        private UserSet UserList { get; set; }
        private BookEvaluaionList BookEval { get; set; }
        private BookDetailList BookList { get; set; }
        private int[] _Sort_Record = new int[8];
        private Dictionary<int, string> __uid__ucl__ = new Dictionary<int, string>();
        public Form_Result(UserSet users, BookDetailList books, BookEvaluaionList ranks)
        {
            InitializeComponent();
            AppPath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "const.bin";
            FileInfo fi = new FileInfo(AppPath);
            if (fi.Exists)
                LoadConstData(AppPath);
            else
            {
                FileStream fs = fi.Create(); fs.Close();
                Cost = new BookCosting();
                SaveConstData(AppPath);
            }
            UserList = users;
            BookList = books;
            BookEval = ranks;
            BuildFinalList();
            OnDisplay();
        }

        private void BuildFinalList()
        {
            BookCosting costing = Cost;
            FinalList = new List<BookFinal>();
            foreach (var value in BookEval.Data)
            {
                BookEvaluaion rank = value;
                rank.Value.SetPrintingCount();
                int bid = rank.BookID, uid = rank.UserID;
                FindPerson(uid);
                BookDetail info;
                FindBookInfo(bid, out info);
                BookFinal item = new BookFinal(info, rank);
                FinalList.Add(item);
            }
            foreach (var item in FinalList)
            {
                item.getFinalValue(ref costing);
            }
        }

        private void FindPerson(int uid)
        {
            string ucl;
            if (!__uid__ucl__.TryGetValue(uid, out ucl))
            {
                User person;
                UserList.Find(uid: uid, val: out person);
                __uid__ucl__.Add(uid, person.name);
            }
        }

        private void FindBookInfo(int bid, out BookDetail info)
        {
            BookList.tryFind(bid, out info);
        }

        private static string[] __Rank_Word_1__ = new string[3] {
            "很高", "中等", "一般"
        };

        private static string[] __Rank_Word_2__ = new string[3] {
            "广泛（基础性教材）", "一般（大众性教材）", "较小（专业性教材）"
        };

        private static string[] __Rank_Word_3__ = new string[3] {
            "很高", "中等", "一般"
        };

        private static string[] __Rank_Word_4__ = new string[3] {
            "很大", "中等", "一般"
        };

        private void OnDisplay()
        {
            ResetListView_Books();
            foreach (var item in FinalList)
            {
                string bid = item.MainInfo.BookID.ToString();
                ListViewItem line = listView_Books.Items.Add(bid);
                line.SubItems.Add(item.MainInfo.BookInfo.Name);
                line.SubItems.Add(__Rank_Word_1__[(int)item.MainValue.Value.Level]);
                line.SubItems.Add(__Rank_Word_2__[(int)item.MainValue.Value.Application]);
                line.SubItems.Add(__Rank_Word_3__[(int)item.MainValue.Value.Influence]);
                line.SubItems.Add(__Rank_Word_4__[(int)item.MainValue.Value.ServiceQuality]);
                line.SubItems.Add(__uid__ucl__[item.MainValue.UserID]);
                line.SubItems.Add(item.FinalValue.ToString("F2"));
            }
            SetWidthListView_Books(-2);
        }

        private void ResetListView_Books()
        {
            listView_Books.Clear();
            listView_Books.Columns.Add("lstBookID", "教材编号");
            listView_Books.Columns.Add("lstInfoName", "教材名称");
            listView_Books.Columns.Add("lstValue1", "教材水平");
            listView_Books.Columns.Add("lstValue2", "教材应用面");
            listView_Books.Columns.Add("lstValue3", "出版社服务质量");
            listView_Books.Columns.Add("lstValue4", "出版社影响力");
            listView_Books.Columns.Add("lstUserName", "评委");
            listView_Books.Columns.Add("lstBookValue", "资助金额");
            listView_Books.ListViewItemSorter = new ListViewBooksSorter();
            for (int i = 0; i < _Sort_Record.Length; i++) _Sort_Record[i] = 0;
        }

        private void SetWidthListView_Books(int val)
        {
            listView_Books.Columns["lstBookID"].Width = val;
            listView_Books.Columns["lstInfoName"].Width = val;
            listView_Books.Columns["lstValue1"].Width = val;
            listView_Books.Columns["lstValue2"].Width = val;
            listView_Books.Columns["lstValue3"].Width = val;
            listView_Books.Columns["lstValue4"].Width = val;
            listView_Books.Columns["lstUserName"].Width = val;
            listView_Books.Columns["lstBookValue"].Width = val;
        }

        private void LoadConstData(string path)
        {
            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            BinaryReader rd = new BinaryReader(fileStream);
            rd.BaseStream.Seek(0, SeekOrigin.Begin);
            byte[] raw = rd.ReadBytes((int)rd.BaseStream.Length);
            MemoryStream buf = new MemoryStream(raw);
            BinaryFormatter bf = new BinaryFormatter();
            Cost = bf.Deserialize(buf) as BookCosting;
            // 释放文件流资源
            fileStream.Flush();
            fileStream.Close();
            fileStream.Dispose();
        }

        private void SaveConstData(string path)
        {
            FileStream fileStream = new FileStream(path, FileMode.Create);
            byte[] serBytes;
            BookCosting reff = Cost;
            ToBytes<BookCosting>.GetBytes(ref reff, out serBytes);
            fileStream.Write(serBytes, 0, serBytes.Length);
            fileStream.Flush();
            fileStream.Close();
            fileStream.Dispose();
        }

        private void button_Constant_Click(object sender, EventArgs e)
        {
            Form_Constant window = new Form_Constant();
            window.ShowDialog();
            if (window.DialogResult == System.Windows.Forms.DialogResult.OK)
                LoadConstData(AppPath);
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Export_Click(object sender, EventArgs e)
        {
            this.saveExcelFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            this.saveExcelFileDialog.FileName = "";
            this.saveExcelFileDialog.ShowDialog();
        }

        #region 保存 Excel 文档组件
        private static string[] __excel__header__ = new string[8]{
            "教材编号", "教材名称",
            "教材水平", "教材应用面", 
            "出版社服务质量", "出版社影响力", 
            "评委", "资助金额"
        };

        private void TrySaveExcel(string name)
        {
            var users = __uid__ucl__.ToList();
            int usercnt = users.Count;
            ExcelOperator excel = new ExcelOperator();
            excel.ExcelWorkbook = excel.ExcelApplication.Workbooks.Add(true);
            excel.CreateExcel();
            // ExcelWorksheet Other: Sort by User
            int idxRow = 1; bool first = true;
            foreach (var user in users)
            {
                int uid = user.Key;
                string ucl = user.Value;
                if (first) first = false;
                else excel.ExcelWorksheet = excel.ExcelWorkbook.Worksheets.Add();
                excel.ExcelWorksheet.Name = ucl;
                idxRow = 1;
                for (int idxColumn = 1; idxColumn <= 6; idxColumn++)
                {
                    excel[idxRow, idxColumn].Value2 = __excel__header__[idxColumn - 1];
                }
                excel[idxRow, 7].Value2 = __excel__header__[7];
                idxRow = 2;
                var data = from item in FinalList
                           where item.MainValue.UserID == uid
                           select item;
                foreach (var item in data)
                {
                    excel[idxRow, 1].Value2 = item.MainInfo.BookID.ToString();
                    excel[idxRow, 2].Value2 = item.MainInfo.BookInfo.Name;
                    excel[idxRow, 3].Value2 = __Rank_Word_1__[(int)item.MainValue.Value.Level];
                    excel[idxRow, 4].Value2 = __Rank_Word_2__[(int)item.MainValue.Value.Application];
                    excel[idxRow, 5].Value2 = __Rank_Word_3__[(int)item.MainValue.Value.Influence];
                    excel[idxRow, 6].Value2 = __Rank_Word_4__[(int)item.MainValue.Value.ServiceQuality];
                    excel[idxRow++, 7].Value2 = item.FinalValue.ToString("F2");
                }
                Range cell = excel.ExcelWorksheet.get_Range("G2", "G" + (data.Count() + 1).ToString());
                cell.NumberFormatLocal = "$#,##0.000";
            }

            // ExcelWorksheet 2: All Data
            excel.ExcelWorksheet = excel.ExcelWorkbook.Worksheets.Add();
            excel.ExcelWorksheet.Name = "评价列表";
            idxRow = 1;
            for (int idxColumn = 1; idxColumn <= 8; idxColumn++)
            {
                excel[idxRow, idxColumn].Value2 = __excel__header__[idxColumn - 1];
            }
            idxRow++;
            foreach (var item in FinalList)
            {
                excel[idxRow, 1].Value2 = item.MainInfo.BookID.ToString();
                excel[idxRow, 2].Value2 = item.MainInfo.BookInfo.Name;
                excel[idxRow, 3].Value2 = __Rank_Word_1__[(int)item.MainValue.Value.Level];
                excel[idxRow, 4].Value2 = __Rank_Word_2__[(int)item.MainValue.Value.Application];
                excel[idxRow, 5].Value2 = __Rank_Word_3__[(int)item.MainValue.Value.Influence];
                excel[idxRow, 6].Value2 = __Rank_Word_4__[(int)item.MainValue.Value.ServiceQuality];
                excel[idxRow, 7].Value2 = __uid__ucl__[item.MainValue.UserID];
                excel[idxRow++, 8].Value2 = item.FinalValue.ToString("F2");
            }
            Range cells = excel.ExcelWorksheet.get_Range("H2", "H" + (FinalList.Count() + 1).ToString());
            cells.NumberFormatLocal = "$#,##0.000";

            // ExcelWorksheet 1: Main Result
            excel.ExcelWorksheet = excel.ExcelWorkbook.Worksheets.Add();
            excel.ExcelWorksheet.Name = "评价结果";
            idxRow = 1;
            excel[idxRow, 1].Value2 = __excel__header__[0];
            excel[idxRow, 2].Value2 = __excel__header__[1];
            excel[idxRow, 3].Value2 = "平均资助金额";
            for (int offset = 1; offset <= usercnt; offset++)
            {
                excel[idxRow, 3 + offset].Value2 = users[offset - 1].Value;
            }
            idxRow = 2;
            string flag = ExcelOperator.GetExcelColumnName(3 + usercnt);
            foreach (var book in BookList.Data)
            {
                string rowname = idxRow.ToString();
                excel[idxRow, 1].Value2 = book.BookID.ToString();
                excel[idxRow, 2].Value2 = book.BookInfo.Name;
                excel[idxRow, 3].Formula = "=AVERAGE(D" + rowname + ":" + flag + rowname + ")";
                for (int offset = 1; offset <= usercnt; offset++)
                {
                    var result = from item in FinalList
                                 where item.MainValue.BookID == book.BookID
                                 where item.MainValue.UserID == users[offset - 1].Key
                                 select item.FinalValue;
                    if (result.Count() != 0)
                    {
                        excel[idxRow, 3 + offset].Value2 = result.First().ToString("F2");
                    }
                }
                idxRow++;
            }
            idxRow--;
            Range range = excel.ExcelWorksheet.get_Range("C2", flag + idxRow.ToString());
            range.NumberFormatLocal = "$#,##0.000";

            excel.SaveExcel(name);
            excel.QuitExcel();
        }
        #endregion
        private void saveExcelFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            string path = this.saveExcelFileDialog.FileName;
            FileInfo fi = new FileInfo(AppPath);
            if (fi.Exists) fi.Delete();
            TrySaveExcel(path);
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

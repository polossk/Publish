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
using Universal.Data;
using Universal.Global;
using Universal.Net;
using Universal.User;

namespace PublishServer
{
    public partial class Form_SendTo : Form
    {
        public ClientTable players = new ClientTable();
        public List<BookInformation> books = new List<BookInformation>();
        public BookInformationList final = new BookInformationList();
        private byte[] data;
        private Dictionary<string, string> facebook = new Dictionary<string, string>();
        TcpClientP tcpClientBookInfo;      // 56677


        public Form_SendTo()
        {
            InitializeComponent();
        }

        public Form_SendTo(List<BookInformation> _books, ClientTable _players)
        {
            InitializeComponent();
            books = _books;
            players = _players;
            OnDispaly();
        }

        private void OnDispaly()
        {
            // 加载用户
            foreach (var client in players.__table.ToList())
            {
                string uac = client.Key;
                string ucl = client.Value.client.name;
                facebook.Add(ucl, uac);
                listBox_Allow.Items.Add(ucl);
            }
            // 准备 Byte[] 数据
            final.Data = books;
            ToBytes<BookInformationList>.GetBytes(ref final, out data);
        }

        private void button_AddOne_Click(object sender, EventArgs e)
        {
            while (listBox_Allow.SelectedItems.Count > 0)
            {
                listBox_Confirm.Items.Add(listBox_Allow.SelectedItems[0]);
                listBox_Allow.Items.Remove(listBox_Allow.SelectedItems[0]);
            }
        }

        private void button_RemoveOne_Click(object sender, EventArgs e)
        {
            while (listBox_Confirm.SelectedItems.Count > 0)
            {
                listBox_Allow.Items.Add(listBox_Confirm.SelectedItems[0]);
                listBox_Confirm.Items.Remove(listBox_Confirm.SelectedItems[0]);
            }
        }

        private void button_AddAll_Click(object sender, EventArgs e)
        {
            while (listBox_Allow.Items.Count > 0)
            {
                listBox_Confirm.Items.Add(listBox_Allow.Items[0]);
                listBox_Allow.Items.Remove(listBox_Allow.Items[0]);
            }
        }

        private void button_RemoveAll_Click(object sender, EventArgs e)
        {
            while (listBox_Confirm.Items.Count > 0)
            {
                listBox_Allow.Items.Add(listBox_Confirm.Items[0]);
                listBox_Confirm.Items.Remove(listBox_Confirm.Items[0]);
            }
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            List<IPAddress> targets = new List<IPAddress>();
            for (int i = 0, sz = listBox_Confirm.SelectedItems.Count; i < sz; i++)
            {
                string ucl = listBox_Confirm.SelectedItems[i].ToString();
                targets.Add(players.__table[facebook[ucl]].clientIP);
            }
            Parallel.ForEach( targets, (item, state, i) =>
            {
                TcpClientP home = new TcpClientP();
                home.Connect(new IPEndPoint(item, Port.TCP_BOOK_INFORMATION_PORT));
                home.Write(data);
                home.Close();
            });
            MessageBox.Show("所有数据发送完毕！", "提示", MessageBoxButtons.OK);
            this.Close();
        }
    }
}

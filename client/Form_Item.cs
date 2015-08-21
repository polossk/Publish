using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Universal.Data;
using Universal.Global;

namespace PublishClient
{
    public partial class Form_Item : Form
    {
        public class ReturnBookEventArgs : EventArgs
        {
            public BookInformation Book { get; set; }
            public BookEvaluaion Rank { get; set; }
            public bool CanUpdate { get; set; }
        }

        public delegate void ReturnBookEventHandler(object sender, ReturnBookEventArgs e);

        public event ReturnBookEventHandler ReturnBook;
        
        public BookInformation book;
        public BookEvaluaion rank;
        public string ucl;
        public int __BookID, __UserID, __EvalID;
        bool isNewComer;
        private static int __MOD__ = 1000000007;

        public Form_Item(BookInformation reff, BookEvaluaion value, int uid, string name, bool isNew = true)
        {
            InitializeComponent();
            ucl = name;
            __BookID = reff.BookID;
            __UserID = uid;
            __EvalID = Cipher.ModPositive(Guid.NewGuid().GetHashCode(), __MOD__);
            book = reff;
            isNewComer = isNew;
            if (isNewComer) 
                rank = new BookEvaluaion(__EvalID, __BookID, __UserID, new _Evaluaion());
            else rank = value;
            OnDisplay();
        }

        private void OnDisplay()
        {
            this.labelBookID.Text += " [" + __BookID.ToString() + "]";
            this.Text = this.labelBookID.Text;
            this.button_Update.Enabled = false;
            this.button_OK.Enabled = false;

            book.BookInfo.buildRawData();
            this.Text = this.Text + book.BookInfo.Name;
            this.label_Name.Text = book.BookInfo.Name;
            this.label_Author.Text = book.BookInfo.Author;
            this.label_Publish.Text = book.BookInfo.PublishingCompany;
            this.label_Title.Text = book.BookInfo._rawData_[2];
            this.label_Category.Text = book.BookInfo._rawData_[4];
            this.label_Attr.Text = book.BookInfo._rawData_[5];

            
            if (isNewComer)
            {
                this.Text = "*[未评价] " + this.Text;
            }
            else
            {
                __EvalID = rank.EvauleID;
                this.comboBox_Level.SelectedIndex = (int)rank.Value.Level;
                this.comboBox_Apply.SelectedIndex = (int)rank.Value.Application;
                this.comboBox_Service.SelectedIndex = (int)rank.Value.ServiceQuality;
                this.comboBox_Influence.SelectedIndex = (int)rank.Value.Influence;
            }

            this.label_EID.Text = __EvalID.ToString("D10");
            this.label_UID.Text = "[#" + __UserID.ToString("D6") + "] " + ucl;
        }

        private void CanUpdate(object sender, EventArgs e)
        {
            if (!this.button_Update.Enabled)
                this.button_Update.Enabled = true;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (this.comboBox_Level.SelectedIndex <= -1)
            {
                MessageBox.Show("未评价其教材水平！", "输入错误", MessageBoxButtons.OK);
                return;
            }
            rank.Value.Level = (_Evaluaion.Valuation)this.comboBox_Level.SelectedIndex;

            if (this.comboBox_Apply.SelectedIndex <= -1)
            {
                MessageBox.Show("未评价其应用面！", "输入错误", MessageBoxButtons.OK);
                return;
            }
            rank.Value.Application = (_Evaluaion.Valuation)this.comboBox_Apply.SelectedIndex;

            if (this.comboBox_Service.SelectedIndex <= -1)
            {
                MessageBox.Show("未评价其出版社服务质量！", "输入错误", MessageBoxButtons.OK);
                return;
            }
            rank.Value.ServiceQuality = (_Evaluaion.Valuation)this.comboBox_Service.SelectedIndex;

            if (this.comboBox_Influence.SelectedIndex <= -1)
            {
                MessageBox.Show("未评价其出版社影响力！", "输入错误", MessageBoxButtons.OK);
                return;
            }
            rank.Value.Influence = (_Evaluaion.Valuation)this.comboBox_Influence.SelectedIndex;

            this.button_OK.Enabled = true;
            this.button_Update.Enabled = false;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            ReturnBookEventArgs e1 = new ReturnBookEventArgs();
            e1.Book = book;
            e1.Rank = rank;
            e1.CanUpdate = true;
            if (this.ReturnBook != null)
            {
                this.ReturnBook(this, e1);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            this.button_OK.Enabled = false;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

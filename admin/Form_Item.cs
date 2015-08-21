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

namespace PublishServer
{
    public partial class Form_Item : Form
    {
        public class ReturnBookEventArgs : EventArgs
        {
            private BookDetail _book;
            public BookDetail Book { get { return _book; } set { _book = value; } }
        }

        public delegate void ReturnBookEventHandler(object sender, ReturnBookEventArgs e);

        public event ReturnBookEventHandler ReturnBook;
        
        public BookDetail book;
        public int __BookID;
        bool isNewComer;

        public Form_Item(int bid = 1)
        {
            InitializeComponent();
            __BookID = bid;
            book = null;
            isNewComer = true;
            OnDisplay();
        }

        public Form_Item(BookDetail reff)
        {
            InitializeComponent();
            __BookID = reff.BookID;
            book = reff;
            isNewComer = false;
            OnDisplay();
        }

        private void OnDisplay()
        {
            this.labelBookID.Text += " [" + __BookID.ToString() + "]";
            this.Text = this.labelBookID.Text;
            this.button_Update.Enabled = false;
            this.button_OK.Enabled = false;
            if (isNewComer)
            {
                this.Text = "*[新建] " + this.Text;
                return;
            }
            this.Text = this.Text + book.BookInfo.Name;
            this.textBoxName.Text = book.BookInfo.Name;
            this.textBoxAuthor.Text = book.BookInfo.Author;
            this.textBoxPublish.Text = book.BookInfo.PublishingCompany;
            this.comboBoxTitle.SelectedIndex = (int)book.BookInfo.AuthorTitle;
            this.comboBoxBelong.SelectedIndex = (int)book.BookInfo.Belonging;
            this.comboBoxBookCnt.SelectedIndex = (int)book.BookPrint.BookCount - 1;
            this.comboBoxPaper.SelectedIndex = (int)book.BookPrint.PaperUsing;
            if (book.BookInfo.Attr == _BookInformation.Property.Monograph)
            {
                this.radioButtonMono.Checked = true;
            }
            else
            {
                this.radioButtonText.Checked = true;
            }
            if (book.BookPrint.BookBinding == _BookPrinting.Binding.Paperback)
            {
                this.radioButtonBindPaper.Checked = true;
            }
            else
            {
                this.radioButtonBindHard.Checked = true;
            }
            if (book.BookPrint.BookSize == _BookPrinting.BookSizeFormat.A4Paper)
            {
                this.radioButtonSizeA4.Checked = true;
            }
            else
            {
                this.radioButtonSizeA5.Checked = true;
            }
            if (book.BookPrint.IsColorful)
            {
                this.radioButtonAye.Checked = true;
            }
            else
            {
                this.radioButtonNay.Checked = true;
            }
            this.numericUpDownWords.Value = book.BookPrint.WordCount;
        }

        private void CanUpdate(object sender, EventArgs e)
        {
            if (!this.button_Update.Enabled)
                this.button_Update.Enabled = true;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (book == null)
            {
                book = new BookDetail();
                book.BookID = __BookID;
            }

            if (this.textBoxName.Text == "")
            {
                MessageBox.Show("教材名称信息为空！", "输入错误", MessageBoxButtons.OK);
                return;
            }
            book.BookInfo.Name = this.textBoxName.Text;

            if (this.textBoxAuthor.Text == "")
            {
                MessageBox.Show("作者信息为空！", "输入错误", MessageBoxButtons.OK);
                return;
            }
            book.BookInfo.Author = this.textBoxAuthor.Text;

            if (this.comboBoxTitle.SelectedIndex == -1)
            {
                MessageBox.Show("作者职称信息为空！", "输入错误", MessageBoxButtons.OK);
                return;
            }
            book.BookInfo.AuthorTitle = (_BookInformation.AcademicTitle)this.comboBoxTitle.SelectedIndex;

            if (this.textBoxPublish.Text == "")
            {
                MessageBox.Show("出版社信息为空！", "输入错误", MessageBoxButtons.OK);
                return;
            }
            book.BookInfo.PublishingCompany = this.textBoxPublish.Text;

            if (this.comboBoxBelong.SelectedIndex == -1)
            {
                MessageBox.Show("教材类别信息为空！", "输入错误", MessageBoxButtons.OK);
                return;
            }
            book.BookInfo.Belonging = (_BookInformation.Category)this.comboBoxBelong.SelectedIndex;
            
            if (this.radioButtonMono.Checked)
                book.BookInfo.Attr = _BookInformation.Property.Monograph;
            else
                book.BookInfo.Attr = _BookInformation.Property.Textbook;

            if (this.numericUpDownWords.Value <= 0)
            {
                MessageBox.Show("教材字数信息为空！", "输入错误", MessageBoxButtons.OK);
                return;
            }
            book.BookPrint.WordCount = (int)this.numericUpDownWords.Value;

            if (this.radioButtonBindPaper.Checked)
                book.BookPrint.BookBinding = _BookPrinting.Binding.Paperback;
            else
                book.BookPrint.BookBinding = _BookPrinting.Binding.Hardback;

            if (this.radioButtonSizeA4.Checked)
                book.BookPrint.BookSize = _BookPrinting.BookSizeFormat.A4Paper;
            else
                book.BookPrint.BookSize = _BookPrinting.BookSizeFormat.A5Paper;

            if (this.comboBoxBookCnt.SelectedIndex == -1)
            {
                MessageBox.Show("教材册数信息为空！", "输入错误", MessageBoxButtons.OK);
                return;
            }
            book.BookPrint.BookCount = (_BookPrinting.BookNumer)(1 + this.comboBoxBookCnt.SelectedIndex);

            if (this.comboBoxPaper.SelectedIndex == -1)
            {
                MessageBox.Show("正文用纸信息为空！", "输入错误", MessageBoxButtons.OK);
                return;
            }
            book.BookPrint.PaperUsing = (_BookPrinting.PaperFormat)this.comboBoxPaper.SelectedIndex;
            
            book.BookPrint.IsColorful = this.radioButtonAye.Checked;

            this.Text = "*[未更新到数据库] " + this.labelBookID.Text + book.BookInfo.Name;

            this.button_OK.Enabled = true;
            this.button_Update.Enabled = false;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            ReturnBookEventArgs e1 = new ReturnBookEventArgs();
            e1.Book = book;
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

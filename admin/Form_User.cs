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

namespace PublishServer
{
    public partial class Form_User : Form
    {
        public class ReturnUserEventArgs : EventArgs
        {
            private User _me;
            public User Me { get { return _me; } set { _me = value; } }
        }

        public delegate void ReturnUserEventHandler(object sender, ReturnUserEventArgs e);

        public event ReturnUserEventHandler ReturnUser;
        
        public User me, backup;
        public int __UserID;
        
        public Form_User()
        {
            InitializeComponent();
        }

        public Form_User(User reff)
        {
            InitializeComponent();
            __UserID = reff.userID;
            me = reff; backup = reff;
            OnDispaly();
        }

        private void OnDispaly()
        {
            string uid = __UserID.ToString("D6");
            string uac = me.account;
            string ucl = me.name;
            this.Text = "教材补助经费评估软件 [" + ucl + "]" + " [#" + uid + "]";
            this.label_UesrID.Text = uid;
            this.label_UserAC.Text = uac;
            this.textBox_UserCL.Text = ucl;
            this.textBox_PW.Text = "";
            this.textBox_PWV.Text = "";
            this.button_ChangeUCL.Enabled = false;
            this.button_ChangPW.Enabled = false;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_User));
            if (uac == "polossk") this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("polossk.Image")));
        }

        private void CanChangeUCL(object sender, EventArgs e)
        {
            if (!this.button_ChangeUCL.Enabled)
                this.button_ChangeUCL.Enabled = true;
        }

        private void CanChangePW(object sender, EventArgs e)
        {
            string raw1 = this.textBox_PW.Text;
            string raw2 = this.textBox_PWV.Text;
            if (raw1 == raw2)
                this.button_ChangPW.Enabled = true;
            else this.button_ChangPW.Enabled = false;
        }

        private void button_ChangeUCL_Click(object sender, EventArgs e)
        {
            me.name = this.textBox_UserCL.Text;
            this.button_ChangeUCL.Enabled = false;
        }

        private void button_ChangPW_Click(object sender, EventArgs e)
        {
            me.ChangePWTo(Cipher.md5Encrypt(this.textBox_PWV.Text));
            this.button_ChangPW.Enabled = false;
        }

        private void button_Abort_Click(object sender, EventArgs e)
        {
            GiveTo(true);
            this.Close();
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            GiveTo();
            this.Close();
        }

        private void GiveTo(bool isAbort = false)
        {
            ReturnUserEventArgs e1 = new ReturnUserEventArgs();
            e1.Me = isAbort ? backup: me;
            if (this.ReturnUser != null)
            {
                this.ReturnUser(this, e1);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }


    }
}

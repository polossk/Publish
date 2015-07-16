namespace admin
{
    partial class Form_Login
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Login));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBox_UesrAccount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_UserPW = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Exit = new System.Windows.Forms.Button();
            this.button_Login = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button_Exit_Copy = new System.Windows.Forms.Button();
            this.textBox_Reg_Account = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Reg_pwRaw = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button_Reg = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_Reg_Name = new System.Windows.Forms.TextBox();
            this.checkBox_Reg_isAdmin = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.HotTrack = true;
            this.tabControl1.ItemSize = new System.Drawing.Size(80, 18);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(215, 199);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabPage1.Controls.Add(this.textBox_UesrAccount);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.textBox_UserPW);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.button_Exit);
            this.tabPage1.Controls.Add(this.button_Login);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(207, 173);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "登录系统";
            // 
            // textBox_UesrAccount
            // 
            this.textBox_UesrAccount.Location = new System.Drawing.Point(46, 16);
            this.textBox_UesrAccount.Name = "textBox_UesrAccount";
            this.textBox_UesrAccount.Size = new System.Drawing.Size(150, 21);
            this.textBox_UesrAccount.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.CausesValidation = false;
            this.label2.Location = new System.Drawing.Point(10, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "密码";
            // 
            // textBox_UserPW
            // 
            this.textBox_UserPW.Location = new System.Drawing.Point(46, 58);
            this.textBox_UserPW.Name = "textBox_UserPW";
            this.textBox_UserPW.Size = new System.Drawing.Size(150, 21);
            this.textBox_UserPW.TabIndex = 1;
            this.textBox_UserPW.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.CausesValidation = false;
            this.label1.Location = new System.Drawing.Point(10, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "账号";
            // 
            // button_Exit
            // 
            this.button_Exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Exit.Location = new System.Drawing.Point(114, 138);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(75, 23);
            this.button_Exit.TabIndex = 3;
            this.button_Exit.Text = "退出(&X)";
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // button_Login
            // 
            this.button_Login.Location = new System.Drawing.Point(17, 138);
            this.button_Login.Name = "button_Login";
            this.button_Login.Size = new System.Drawing.Size(75, 23);
            this.button_Login.TabIndex = 2;
            this.button_Login.Text = "登陆(&L)";
            this.button_Login.UseVisualStyleBackColor = true;
            this.button_Login.Click += new System.EventHandler(this.button_Login_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabPage2.Controls.Add(this.checkBox_Reg_isAdmin);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.textBox_Reg_Name);
            this.tabPage2.Controls.Add(this.button_Exit_Copy);
            this.tabPage2.Controls.Add(this.textBox_Reg_Account);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.textBox_Reg_pwRaw);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.button_Reg);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(207, 173);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "注册账号";
            // 
            // button_Exit_Copy
            // 
            this.button_Exit_Copy.Location = new System.Drawing.Point(114, 138);
            this.button_Exit_Copy.Name = "button_Exit_Copy";
            this.button_Exit_Copy.Size = new System.Drawing.Size(75, 23);
            this.button_Exit_Copy.TabIndex = 5;
            this.button_Exit_Copy.Text = "退出(&X)";
            this.button_Exit_Copy.UseVisualStyleBackColor = true;
            this.button_Exit_Copy.Click += new System.EventHandler(this.button_Exit_Copy_Click);
            // 
            // textBox_Reg_Account
            // 
            this.textBox_Reg_Account.Location = new System.Drawing.Point(46, 16);
            this.textBox_Reg_Account.Name = "textBox_Reg_Account";
            this.textBox_Reg_Account.Size = new System.Drawing.Size(150, 21);
            this.textBox_Reg_Account.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 19;
            this.label3.Text = "密码";
            // 
            // textBox_Reg_pwRaw
            // 
            this.textBox_Reg_pwRaw.Location = new System.Drawing.Point(46, 58);
            this.textBox_Reg_pwRaw.Name = "textBox_Reg_pwRaw";
            this.textBox_Reg_pwRaw.Size = new System.Drawing.Size(150, 21);
            this.textBox_Reg_pwRaw.TabIndex = 1;
            this.textBox_Reg_pwRaw.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 18;
            this.label4.Text = "账号";
            // 
            // button_Reg
            // 
            this.button_Reg.Location = new System.Drawing.Point(17, 138);
            this.button_Reg.Name = "button_Reg";
            this.button_Reg.Size = new System.Drawing.Size(75, 23);
            this.button_Reg.TabIndex = 4;
            this.button_Reg.Text = "注册(&R)";
            this.button_Reg.UseVisualStyleBackColor = true;
            this.button_Reg.Click += new System.EventHandler(this.button_Reg_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 21;
            this.label5.Text = "昵称";
            // 
            // textBox_Reg_Name
            // 
            this.textBox_Reg_Name.Location = new System.Drawing.Point(46, 99);
            this.textBox_Reg_Name.Name = "textBox_Reg_Name";
            this.textBox_Reg_Name.Size = new System.Drawing.Size(46, 21);
            this.textBox_Reg_Name.TabIndex = 2;
            // 
            // checkBox_Reg_isAdmin
            // 
            this.checkBox_Reg_isAdmin.AutoSize = true;
            this.checkBox_Reg_isAdmin.Location = new System.Drawing.Point(105, 101);
            this.checkBox_Reg_isAdmin.Name = "checkBox_Reg_isAdmin";
            this.checkBox_Reg_isAdmin.Size = new System.Drawing.Size(96, 16);
            this.checkBox_Reg_isAdmin.TabIndex = 3;
            this.checkBox_Reg_isAdmin.Text = "是否为管理员";
            this.checkBox_Reg_isAdmin.UseVisualStyleBackColor = true;
            // 
            // Form_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 224);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Form_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Login_FormClosing);
            this.Load += new System.EventHandler(this.Form_Login_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_Login_KeyDown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }



        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox textBox_UesrAccount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_UserPW;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Button button_Login;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBox_Reg_Account;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Reg_pwRaw;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_Reg;
        private System.Windows.Forms.Button button_Exit_Copy;
        private System.Windows.Forms.CheckBox checkBox_Reg_isAdmin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_Reg_Name;


    }
}


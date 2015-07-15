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
            this.textBox_UesrAccount = new System.Windows.Forms.TextBox();
            this.textBox_UserPW = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_Login = new System.Windows.Forms.Button();
            this.button_Reg = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_UesrAccount
            // 
            this.textBox_UesrAccount.Location = new System.Drawing.Point(56, 21);
            this.textBox_UesrAccount.Name = "textBox_UesrAccount";
            this.textBox_UesrAccount.Size = new System.Drawing.Size(150, 21);
            this.textBox_UesrAccount.TabIndex = 0;
            // 
            // textBox_UserPW
            // 
            this.textBox_UserPW.Location = new System.Drawing.Point(56, 63);
            this.textBox_UserPW.Name = "textBox_UserPW";
            this.textBox_UserPW.Size = new System.Drawing.Size(150, 21);
            this.textBox_UserPW.TabIndex = 1;
            this.textBox_UserPW.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "账号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "密码";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_UesrAccount);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox_UserPW);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 96);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "登陆信息";
            // 
            // button_Login
            // 
            this.button_Login.Location = new System.Drawing.Point(34, 114);
            this.button_Login.Name = "button_Login";
            this.button_Login.Size = new System.Drawing.Size(75, 23);
            this.button_Login.TabIndex = 5;
            this.button_Login.Text = "登陆(&L)";
            this.button_Login.UseVisualStyleBackColor = true;
            this.button_Login.Click += new System.EventHandler(this.button_Login_Click);
            // 
            // button_Reg
            // 
            this.button_Reg.Location = new System.Drawing.Point(131, 114);
            this.button_Reg.Name = "button_Reg";
            this.button_Reg.Size = new System.Drawing.Size(75, 23);
            this.button_Reg.TabIndex = 6;
            this.button_Reg.Text = "注册(&R)";
            this.button_Reg.UseVisualStyleBackColor = true;
            this.button_Reg.Click += new System.EventHandler(this.button_Reg_Click);
            // 
            // Form_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 152);
            this.Controls.Add(this.button_Reg);
            this.Controls.Add(this.button_Login);
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Form_Login";
            this.Text = "登录";
            this.Load += new System.EventHandler(this.Form_Login_Load);
            this.KeyDown += Form_Login_KeyDown;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_UesrAccount;
        private System.Windows.Forms.TextBox textBox_UserPW;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_Login;
        private System.Windows.Forms.Button button_Reg;

    }
}


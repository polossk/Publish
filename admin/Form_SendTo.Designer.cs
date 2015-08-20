namespace PublishServer
{
    partial class Form_SendTo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_SendTo));
            this.listBox_Allow = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBox_Confirm = new System.Windows.Forms.ListBox();
            this.button_AddAll = new System.Windows.Forms.Button();
            this.button_AddOne = new System.Windows.Forms.Button();
            this.button_RemoveOne = new System.Windows.Forms.Button();
            this.button_RemoveAll = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_OK = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox_Allow
            // 
            this.listBox_Allow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_Allow.FormattingEnabled = true;
            this.listBox_Allow.ItemHeight = 12;
            this.listBox_Allow.Location = new System.Drawing.Point(6, 20);
            this.listBox_Allow.Name = "listBox_Allow";
            this.listBox_Allow.Size = new System.Drawing.Size(188, 304);
            this.listBox_Allow.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBox_Allow);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 336);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "允许发送用户列表";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listBox_Confirm);
            this.groupBox2.Location = new System.Drawing.Point(250, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 336);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "确认发送列表";
            // 
            // listBox_Confirm
            // 
            this.listBox_Confirm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_Confirm.FormattingEnabled = true;
            this.listBox_Confirm.ItemHeight = 12;
            this.listBox_Confirm.Location = new System.Drawing.Point(6, 20);
            this.listBox_Confirm.Name = "listBox_Confirm";
            this.listBox_Confirm.Size = new System.Drawing.Size(188, 304);
            this.listBox_Confirm.TabIndex = 0;
            // 
            // button_AddAll
            // 
            this.button_AddAll.Location = new System.Drawing.Point(218, 127);
            this.button_AddAll.Name = "button_AddAll";
            this.button_AddAll.Size = new System.Drawing.Size(26, 23);
            this.button_AddAll.TabIndex = 3;
            this.button_AddAll.Text = ">>";
            this.button_AddAll.UseVisualStyleBackColor = true;
            this.button_AddAll.Click += new System.EventHandler(this.button_AddAll_Click);
            // 
            // button_AddOne
            // 
            this.button_AddOne.Location = new System.Drawing.Point(218, 156);
            this.button_AddOne.Name = "button_AddOne";
            this.button_AddOne.Size = new System.Drawing.Size(26, 23);
            this.button_AddOne.TabIndex = 4;
            this.button_AddOne.Text = ">";
            this.button_AddOne.UseVisualStyleBackColor = true;
            this.button_AddOne.Click += new System.EventHandler(this.button_AddOne_Click);
            // 
            // button_RemoveOne
            // 
            this.button_RemoveOne.Location = new System.Drawing.Point(218, 185);
            this.button_RemoveOne.Name = "button_RemoveOne";
            this.button_RemoveOne.Size = new System.Drawing.Size(26, 23);
            this.button_RemoveOne.TabIndex = 5;
            this.button_RemoveOne.Text = "<";
            this.button_RemoveOne.UseVisualStyleBackColor = true;
            this.button_RemoveOne.Click += new System.EventHandler(this.button_RemoveOne_Click);
            // 
            // button_RemoveAll
            // 
            this.button_RemoveAll.Location = new System.Drawing.Point(218, 214);
            this.button_RemoveAll.Name = "button_RemoveAll";
            this.button_RemoveAll.Size = new System.Drawing.Size(26, 23);
            this.button_RemoveAll.TabIndex = 6;
            this.button_RemoveAll.Text = "<<";
            this.button_RemoveAll.UseVisualStyleBackColor = true;
            this.button_RemoveAll.Click += new System.EventHandler(this.button_RemoveAll_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(288, 354);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 7;
            this.button_Cancel.Text = "取消(&C)";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(369, 354);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 8;
            this.button_OK.Text = "确认(&O)";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // Form_SendTo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 383);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_RemoveAll);
            this.Controls.Add(this.button_RemoveOne);
            this.Controls.Add(this.button_AddOne);
            this.Controls.Add(this.button_AddAll);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_SendTo";
            this.Text = "发送给...";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_Allow;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listBox_Confirm;
        private System.Windows.Forms.Button button_AddAll;
        private System.Windows.Forms.Button button_AddOne;
        private System.Windows.Forms.Button button_RemoveOne;
        private System.Windows.Forms.Button button_RemoveAll;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button button_OK;
    }
}
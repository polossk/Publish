namespace PublishClient
{
    partial class Form_Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listView_Books = new System.Windows.Forms.ListView();
            this.contextMenuStrip_BookList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tSMI_Sendto = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tSMI_Modify = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMI_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tSMI_ClearAll = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label_ClientName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_About = new System.Windows.Forms.Button();
            this.button_User = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip_BookList.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.listView_Books);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(619, 417);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "教材列表";
            // 
            // listView_Books
            // 
            this.listView_Books.ContextMenuStrip = this.contextMenuStrip_BookList;
            this.listView_Books.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_Books.FullRowSelect = true;
            this.listView_Books.GridLines = true;
            this.listView_Books.Location = new System.Drawing.Point(3, 17);
            this.listView_Books.Name = "listView_Books";
            this.listView_Books.Size = new System.Drawing.Size(613, 397);
            this.listView_Books.TabIndex = 0;
            this.listView_Books.UseCompatibleStateImageBehavior = false;
            this.listView_Books.View = System.Windows.Forms.View.Details;
            this.listView_Books.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewBooks_ColumnClick);
            this.listView_Books.DoubleClick += new System.EventHandler(this.listViewBooks_DoubleClick);
            // 
            // contextMenuStrip_BookList
            // 
            this.contextMenuStrip_BookList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMI_Sendto,
            this.toolStripSeparator1,
            this.tSMI_Modify,
            this.tSMI_Delete,
            this.toolStripSeparator2,
            this.tSMI_ClearAll});
            this.contextMenuStrip_BookList.Name = "contextMenuStrip_BookList";
            this.contextMenuStrip_BookList.Size = new System.Drawing.Size(163, 126);
            this.contextMenuStrip_BookList.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_BookList_Opening);
            // 
            // tSMI_Sendto
            // 
            this.tSMI_Sendto.Name = "tSMI_Sendto";
            this.tSMI_Sendto.Size = new System.Drawing.Size(162, 22);
            this.tSMI_Sendto.Text = "发送(&S)";
            this.tSMI_Sendto.Click += new System.EventHandler(this.tSMI_Sendto_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(159, 6);
            // 
            // tSMI_Modify
            // 
            this.tSMI_Modify.Name = "tSMI_Modify";
            this.tSMI_Modify.Size = new System.Drawing.Size(162, 22);
            this.tSMI_Modify.Text = "修改(&M)";
            this.tSMI_Modify.Click += new System.EventHandler(this.tSMI_Modify_Click);
            // 
            // tSMI_Delete
            // 
            this.tSMI_Delete.Name = "tSMI_Delete";
            this.tSMI_Delete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.tSMI_Delete.Size = new System.Drawing.Size(162, 22);
            this.tSMI_Delete.Text = "删除(&D)";
            this.tSMI_Delete.Click += new System.EventHandler(this.tSMI_Delete_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(159, 6);
            // 
            // tSMI_ClearAll
            // 
            this.tSMI_ClearAll.Name = "tSMI_ClearAll";
            this.tSMI_ClearAll.Size = new System.Drawing.Size(162, 22);
            this.tSMI_ClearAll.Text = "清空(&C)";
            this.tSMI_ClearAll.Click += new System.EventHandler(this.tSMI_ClearAll_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label_ClientName);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.button_About);
            this.groupBox2.Controls.Add(this.button_User);
            this.groupBox2.Location = new System.Drawing.Point(637, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(175, 227);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "用户信息";
            // 
            // label_ClientName
            // 
            this.label_ClientName.AutoSize = true;
            this.label_ClientName.Location = new System.Drawing.Point(6, 182);
            this.label_ClientName.Name = "label_ClientName";
            this.label_ClientName.Size = new System.Drawing.Size(41, 12);
            this.label_ClientName.TabIndex = 7;
            this.label_ClientName.Text = "label1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(7, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(162, 162);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // button_About
            // 
            this.button_About.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_About.Location = new System.Drawing.Point(90, 198);
            this.button_About.Name = "button_About";
            this.button_About.Size = new System.Drawing.Size(79, 23);
            this.button_About.TabIndex = 5;
            this.button_About.Text = "关于软件(&A)";
            this.button_About.UseVisualStyleBackColor = true;
            this.button_About.Click += new System.EventHandler(this.button_About_Click);
            // 
            // button_User
            // 
            this.button_User.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_User.Location = new System.Drawing.Point(5, 198);
            this.button_User.Name = "button_User";
            this.button_User.Size = new System.Drawing.Size(79, 23);
            this.button_User.TabIndex = 4;
            this.button_User.Text = "用户信息(&U)";
            this.button_User.UseVisualStyleBackColor = true;
            this.button_User.Click += new System.EventHandler(this.button_User_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.tableLayoutPanel1);
            this.groupBox3.Location = new System.Drawing.Point(637, 239);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(175, 190);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 13);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(161, 171);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 441);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Main";
            this.Text = "Form_Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Main_FormClosing);
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.groupBox1.ResumeLayout(false);
            this.contextMenuStrip_BookList.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView listView_Books;
        private System.Windows.Forms.Label label_ClientName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_About;
        private System.Windows.Forms.Button button_User;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_BookList;
        private System.Windows.Forms.ToolStripMenuItem tSMI_Sendto;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tSMI_Modify;
        private System.Windows.Forms.ToolStripMenuItem tSMI_Delete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tSMI_ClearAll;
    }
}
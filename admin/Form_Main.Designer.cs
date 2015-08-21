namespace PublishServer
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
            this.openExcelFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveExcelFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button_Add = new System.Windows.Forms.Button();
            this.button_Import = new System.Windows.Forms.Button();
            this.button_BookListSave = new System.Windows.Forms.Button();
            this.button_BookListLoad = new System.Windows.Forms.Button();
            this.button_Export = new System.Windows.Forms.Button();
            this.listView_Books = new System.Windows.Forms.ListView();
            this.contextMenuStrip_BookList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tSMI_Sendto = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tSMI_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMI_Modify = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMI_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tSMI_ClearAll = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listView_Users = new System.Windows.Forms.ListView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button_About = new System.Windows.Forms.Button();
            this.label_AdminName = new System.Windows.Forms.Label();
            this.label_AdminTitle = new System.Windows.Forms.Label();
            this.button_User = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.saveDataFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openDataFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.contextMenuStrip_BookList.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // openExcelFileDialog
            // 
            this.openExcelFileDialog.Filter = "Excel文件|*.xls;*.xlsx|所有文件|*.*";
            this.openExcelFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openExcelFileDialog_FileOk);
            // 
            // saveExcelFileDialog
            // 
            this.saveExcelFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveExcelFileDialog_FileOk);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.button_Add, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_Import, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_BookListSave, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_BookListLoad, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_Export, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 18);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(283, 151);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // button_Add
            // 
            this.button_Add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button_Add.Location = new System.Drawing.Point(31, 5);
            this.button_Add.Margin = new System.Windows.Forms.Padding(5);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(79, 27);
            this.button_Add.TabIndex = 0;
            this.button_Add.Text = "新增条目(&N)";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // button_Import
            // 
            this.button_Import.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button_Import.Location = new System.Drawing.Point(31, 42);
            this.button_Import.Margin = new System.Windows.Forms.Padding(5);
            this.button_Import.Name = "button_Import";
            this.button_Import.Size = new System.Drawing.Size(79, 27);
            this.button_Import.TabIndex = 1;
            this.button_Import.Text = "导入数据(&I)";
            this.button_Import.UseVisualStyleBackColor = true;
            this.button_Import.Click += new System.EventHandler(this.buttonOpenExcelFile_Click);
            // 
            // button_BookListSave
            // 
            this.button_BookListSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button_BookListSave.Location = new System.Drawing.Point(172, 5);
            this.button_BookListSave.Margin = new System.Windows.Forms.Padding(5);
            this.button_BookListSave.Name = "button_BookListSave";
            this.button_BookListSave.Size = new System.Drawing.Size(79, 27);
            this.button_BookListSave.TabIndex = 2;
            this.button_BookListSave.Text = "保存数据(&S)";
            this.button_BookListSave.UseVisualStyleBackColor = true;
            this.button_BookListSave.Click += new System.EventHandler(this.button_BookListSave_Click);
            // 
            // button_BookListLoad
            // 
            this.button_BookListLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button_BookListLoad.Location = new System.Drawing.Point(172, 42);
            this.button_BookListLoad.Margin = new System.Windows.Forms.Padding(5);
            this.button_BookListLoad.Name = "button_BookListLoad";
            this.button_BookListLoad.Size = new System.Drawing.Size(79, 27);
            this.button_BookListLoad.TabIndex = 3;
            this.button_BookListLoad.Text = "加载数据(&L)";
            this.button_BookListLoad.UseVisualStyleBackColor = true;
            this.button_BookListLoad.Click += new System.EventHandler(this.button_BookListLoad_Click);
            // 
            // button_Export
            // 
            this.button_Export.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button_Export.Location = new System.Drawing.Point(31, 116);
            this.button_Export.Margin = new System.Windows.Forms.Padding(5);
            this.button_Export.Name = "button_Export";
            this.button_Export.Size = new System.Drawing.Size(79, 30);
            this.button_Export.TabIndex = 4;
            this.button_Export.Text = "导出结果(&E)";
            this.button_Export.UseVisualStyleBackColor = true;
            // 
            // listView_Books
            // 
            this.listView_Books.ContextMenuStrip = this.contextMenuStrip_BookList;
            this.listView_Books.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_Books.FullRowSelect = true;
            this.listView_Books.GridLines = true;
            this.listView_Books.Location = new System.Drawing.Point(3, 17);
            this.listView_Books.Name = "listView_Books";
            this.listView_Books.Size = new System.Drawing.Size(834, 637);
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
            this.tSMI_Add,
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
            // tSMI_Add
            // 
            this.tSMI_Add.Name = "tSMI_Add";
            this.tSMI_Add.Size = new System.Drawing.Size(162, 22);
            this.tSMI_Add.Text = "添加(&A)";
            this.tSMI_Add.Click += new System.EventHandler(this.tSMI_Add_Click);
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
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.listView_Books);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(840, 657);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "教材列表";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.tableLayoutPanel1);
            this.groupBox2.Location = new System.Drawing.Point(858, 494);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(292, 175);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.listView_Users);
            this.groupBox3.Location = new System.Drawing.Point(858, 216);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(292, 275);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "登陆用户列表";
            // 
            // listView_Users
            // 
            this.listView_Users.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_Users.FullRowSelect = true;
            this.listView_Users.GridLines = true;
            this.listView_Users.Location = new System.Drawing.Point(3, 17);
            this.listView_Users.Name = "listView_Users";
            this.listView_Users.Size = new System.Drawing.Size(286, 255);
            this.listView_Users.TabIndex = 0;
            this.listView_Users.UseCompatibleStateImageBehavior = false;
            this.listView_Users.View = System.Windows.Forms.View.Details;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.button_About);
            this.groupBox4.Controls.Add(this.label_AdminName);
            this.groupBox4.Controls.Add(this.label_AdminTitle);
            this.groupBox4.Controls.Add(this.button_User);
            this.groupBox4.Controls.Add(this.pictureBox1);
            this.groupBox4.Location = new System.Drawing.Point(858, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(292, 198);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "用户信息";
            // 
            // button_About
            // 
            this.button_About.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_About.Location = new System.Drawing.Point(207, 160);
            this.button_About.Name = "button_About";
            this.button_About.Size = new System.Drawing.Size(79, 23);
            this.button_About.TabIndex = 3;
            this.button_About.Text = "关于软件(&A)";
            this.button_About.UseVisualStyleBackColor = true;
            this.button_About.Click += new System.EventHandler(this.button_About_Click);
            // 
            // label_AdminName
            // 
            this.label_AdminName.AutoSize = true;
            this.label_AdminName.Location = new System.Drawing.Point(181, 64);
            this.label_AdminName.Name = "label_AdminName";
            this.label_AdminName.Size = new System.Drawing.Size(107, 12);
            this.label_AdminName.TabIndex = 1;
            this.label_AdminName.Text = "超级管理员polossk";
            // 
            // label_AdminTitle
            // 
            this.label_AdminTitle.AutoSize = true;
            this.label_AdminTitle.Location = new System.Drawing.Point(181, 40);
            this.label_AdminTitle.Name = "label_AdminTitle";
            this.label_AdminTitle.Size = new System.Drawing.Size(41, 12);
            this.label_AdminTitle.TabIndex = 0;
            this.label_AdminTitle.Text = "管理员";
            // 
            // button_User
            // 
            this.button_User.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_User.Location = new System.Drawing.Point(207, 131);
            this.button_User.Name = "button_User";
            this.button_User.Size = new System.Drawing.Size(79, 23);
            this.button_User.TabIndex = 2;
            this.button_User.Text = "用户信息(&U)";
            this.button_User.UseVisualStyleBackColor = true;
            this.button_User.Click += new System.EventHandler(this.button_User_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(166, 166);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // saveDataFileDialog
            // 
            this.saveDataFileDialog.DefaultExt = "bdl";
            this.saveDataFileDialog.Filter = "教材信息数据文件|*.bdl|所有文件|*.*";
            this.saveDataFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveDataFileDialog_FileOk);
            // 
            // openDataFileDialog
            // 
            this.openDataFileDialog.Filter = "教材信息数据文件|*.bdl|所有文件|*.*";
            this.openDataFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openDataFileDialog_FileOk);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1162, 681);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Main_FormClosing);
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.contextMenuStrip_BookList.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openExcelFileDialog;
        private System.Windows.Forms.SaveFileDialog saveExcelFileDialog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button_Import;
        private System.Windows.Forms.Button button_Export;
        private System.Windows.Forms.ListView listView_Books;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListView listView_Users;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_User;
        private System.Windows.Forms.Label label_AdminTitle;
        private System.Windows.Forms.Label label_AdminName;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_BookList;
        private System.Windows.Forms.ToolStripMenuItem tSMI_Modify;
        private System.Windows.Forms.ToolStripMenuItem tSMI_Delete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tSMI_ClearAll;
        private System.Windows.Forms.Button button_BookListSave;
        private System.Windows.Forms.Button button_BookListLoad;
        private System.Windows.Forms.SaveFileDialog saveDataFileDialog;
        private System.Windows.Forms.OpenFileDialog openDataFileDialog;
        private System.Windows.Forms.Button button_About;
        private System.Windows.Forms.ToolStripMenuItem tSMI_Sendto;
        private System.Windows.Forms.ToolStripMenuItem tSMI_Add;
    }
}
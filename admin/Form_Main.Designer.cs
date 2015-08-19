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
            this.button_Export = new System.Windows.Forms.Button();
            this.button_BookListLoad = new System.Windows.Forms.Button();
            this.listView_Books = new System.Windows.Forms.ListView();
            this.contextMenuStrip_BookList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tSMI_Sendto = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMI_All = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tSMI_Modify = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMI_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tSMI_ClearAll = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listView_Users = new System.Windows.Forms.ListView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
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
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.button_Add, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_Import, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_BookListSave, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.button_Export, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.button_BookListLoad, 1, 2);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(263, 142);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // button_Add
            // 
            this.button_Add.Location = new System.Drawing.Point(3, 3);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(79, 23);
            this.button_Add.TabIndex = 2;
            this.button_Add.Text = "新增条目(&A)";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // button_Import
            // 
            this.button_Import.Location = new System.Drawing.Point(3, 38);
            this.button_Import.Name = "button_Import";
            this.button_Import.Size = new System.Drawing.Size(79, 23);
            this.button_Import.TabIndex = 0;
            this.button_Import.Text = "导入数据(&I)";
            this.button_Import.UseVisualStyleBackColor = true;
            this.button_Import.Click += new System.EventHandler(this.buttonOpenExcelFile_Click);
            // 
            // button_BookListSave
            // 
            this.button_BookListSave.Location = new System.Drawing.Point(3, 73);
            this.button_BookListSave.Name = "button_BookListSave";
            this.button_BookListSave.Size = new System.Drawing.Size(79, 23);
            this.button_BookListSave.TabIndex = 3;
            this.button_BookListSave.Text = "保存数据(&S)";
            this.button_BookListSave.UseVisualStyleBackColor = true;
            this.button_BookListSave.Click += new System.EventHandler(this.button_BookListSave_Click);
            // 
            // button_Export
            // 
            this.button_Export.Location = new System.Drawing.Point(90, 108);
            this.button_Export.Name = "button_Export";
            this.button_Export.Size = new System.Drawing.Size(79, 23);
            this.button_Export.TabIndex = 1;
            this.button_Export.Text = "导出结果(&E)";
            this.button_Export.UseVisualStyleBackColor = true;
            // 
            // button_BookListLoad
            // 
            this.button_BookListLoad.Location = new System.Drawing.Point(90, 73);
            this.button_BookListLoad.Name = "button_BookListLoad";
            this.button_BookListLoad.Size = new System.Drawing.Size(79, 23);
            this.button_BookListLoad.TabIndex = 4;
            this.button_BookListLoad.Text = "加载数据(&L)";
            this.button_BookListLoad.UseVisualStyleBackColor = true;
            this.button_BookListLoad.Click += new System.EventHandler(this.button_BookListLoad_Click);
            // 
            // listView_Books
            // 
            this.listView_Books.ContextMenuStrip = this.contextMenuStrip_BookList;
            this.listView_Books.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_Books.FullRowSelect = true;
            this.listView_Books.GridLines = true;
            this.listView_Books.Location = new System.Drawing.Point(3, 17);
            this.listView_Books.Name = "listView_Books";
            this.listView_Books.Size = new System.Drawing.Size(841, 637);
            this.listView_Books.TabIndex = 1;
            this.listView_Books.UseCompatibleStateImageBehavior = false;
            this.listView_Books.View = System.Windows.Forms.View.Details;
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
            this.contextMenuStrip_BookList.Size = new System.Drawing.Size(163, 104);
            // 
            // tSMI_Sendto
            // 
            this.tSMI_Sendto.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMI_All,
            this.toolStripSeparator3});
            this.tSMI_Sendto.Name = "tSMI_Sendto";
            this.tSMI_Sendto.Size = new System.Drawing.Size(162, 22);
            this.tSMI_Sendto.Text = "发送(&S)";
            // 
            // tSMI_All
            // 
            this.tSMI_All.Name = "tSMI_All";
            this.tSMI_All.Size = new System.Drawing.Size(112, 22);
            this.tSMI_All.Text = "所有人";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(109, 6);
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
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listView_Books);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(847, 657);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "教材列表";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel1);
            this.groupBox2.Location = new System.Drawing.Point(865, 500);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(275, 166);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listView_Users);
            this.groupBox3.Location = new System.Drawing.Point(865, 216);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(275, 278);
            this.groupBox3.TabIndex = 4;
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
            this.listView_Users.Size = new System.Drawing.Size(269, 258);
            this.listView_Users.TabIndex = 0;
            this.listView_Users.UseCompatibleStateImageBehavior = false;
            this.listView_Users.View = System.Windows.Forms.View.Details;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label_AdminName);
            this.groupBox4.Controls.Add(this.label_AdminTitle);
            this.groupBox4.Controls.Add(this.button_User);
            this.groupBox4.Controls.Add(this.pictureBox1);
            this.groupBox4.Location = new System.Drawing.Point(865, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(275, 198);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "用户信息";
            // 
            // label_AdminName
            // 
            this.label_AdminName.AutoSize = true;
            this.label_AdminName.Location = new System.Drawing.Point(192, 37);
            this.label_AdminName.Name = "label_AdminName";
            this.label_AdminName.Size = new System.Drawing.Size(35, 12);
            this.label_AdminName.TabIndex = 4;
            this.label_AdminName.Text = "admin";
            // 
            // label_AdminTitle
            // 
            this.label_AdminTitle.AutoSize = true;
            this.label_AdminTitle.Location = new System.Drawing.Point(190, 21);
            this.label_AdminTitle.Name = "label_AdminTitle";
            this.label_AdminTitle.Size = new System.Drawing.Size(41, 12);
            this.label_AdminTitle.TabIndex = 3;
            this.label_AdminTitle.Text = "管理员";
            // 
            // button_User
            // 
            this.button_User.Location = new System.Drawing.Point(190, 160);
            this.button_User.Name = "button_User";
            this.button_User.Size = new System.Drawing.Size(79, 23);
            this.button_User.TabIndex = 1;
            this.button_User.Text = "用户信息(&U)";
            this.button_User.UseVisualStyleBackColor = true;
            this.button_User.Click += new System.EventHandler(this.button_User_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(9, 17);
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
            this.ClientSize = new System.Drawing.Size(1156, 681);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
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
        private System.Windows.Forms.ToolStripMenuItem tSMI_Sendto;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tSMI_ClearAll;
        private System.Windows.Forms.ToolStripMenuItem tSMI_All;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Button button_BookListSave;
        private System.Windows.Forms.Button button_BookListLoad;
        private System.Windows.Forms.SaveFileDialog saveDataFileDialog;
        private System.Windows.Forms.OpenFileDialog openDataFileDialog;
    }
}
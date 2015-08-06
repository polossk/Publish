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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.openExcelFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveExcelFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonOpenExcelFile = new System.Windows.Forms.Button();
            this.buttonSaveExcelFile = new System.Windows.Forms.Button();
            this.listViewBooks = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.buttonOpenExcelFile, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonSaveExcelFile, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(865, 286);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(81, 123);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // buttonOpenExcelFile
            // 
            this.buttonOpenExcelFile.Location = new System.Drawing.Point(3, 3);
            this.buttonOpenExcelFile.Name = "buttonOpenExcelFile";
            this.buttonOpenExcelFile.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenExcelFile.TabIndex = 0;
            this.buttonOpenExcelFile.Text = "导入文件";
            this.buttonOpenExcelFile.UseVisualStyleBackColor = true;
            this.buttonOpenExcelFile.Click += new System.EventHandler(this.buttonOpenExcelFile_Click);
            // 
            // buttonSaveExcelFile
            // 
            this.buttonSaveExcelFile.Location = new System.Drawing.Point(3, 33);
            this.buttonSaveExcelFile.Name = "buttonSaveExcelFile";
            this.buttonSaveExcelFile.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveExcelFile.TabIndex = 1;
            this.buttonSaveExcelFile.Text = "导出文件";
            this.buttonSaveExcelFile.UseVisualStyleBackColor = true;
            // 
            // listViewBooks
            // 
            this.listViewBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewBooks.FullRowSelect = true;
            this.listViewBooks.GridLines = true;
            this.listViewBooks.Location = new System.Drawing.Point(3, 17);
            this.listViewBooks.Name = "listViewBooks";
            this.listViewBooks.Size = new System.Drawing.Size(841, 377);
            this.listViewBooks.TabIndex = 1;
            this.listViewBooks.UseCompatibleStateImageBehavior = false;
            this.listViewBooks.View = System.Windows.Forms.View.Details;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listViewBooks);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(847, 397);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 421);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Main";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Main_FormClosing);
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openExcelFileDialog;
        private System.Windows.Forms.SaveFileDialog saveExcelFileDialog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonOpenExcelFile;
        private System.Windows.Forms.Button buttonSaveExcelFile;
        private System.Windows.Forms.ListView listViewBooks;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
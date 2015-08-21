namespace PublishClient
{
    partial class Form_Item
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Item));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_Update = new System.Windows.Forms.Button();
            this.labelBookID = new System.Windows.Forms.Label();
            this.button_OK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.groupBox_Info = new System.Windows.Forms.GroupBox();
            this.label_Title = new System.Windows.Forms.Label();
            this.label_Publish = new System.Windows.Forms.Label();
            this.label_Author = new System.Windows.Forms.Label();
            this.label_Name = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox_Service = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBox_Influence = new System.Windows.Forms.ComboBox();
            this.label_Category = new System.Windows.Forms.Label();
            this.label_Attr = new System.Windows.Forms.Label();
            this.comboBox_Apply = new System.Windows.Forms.ComboBox();
            this.comboBox_Level = new System.Windows.Forms.ComboBox();
            this.label_EID = new System.Windows.Forms.Label();
            this.label_UID = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox_Info.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button_Update
            // 
            this.button_Update.Location = new System.Drawing.Point(12, 323);
            this.button_Update.Name = "button_Update";
            this.button_Update.Size = new System.Drawing.Size(75, 23);
            this.button_Update.TabIndex = 3;
            this.button_Update.Text = "更新(&U)";
            this.button_Update.UseVisualStyleBackColor = true;
            this.button_Update.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // labelBookID
            // 
            this.labelBookID.AutoSize = true;
            this.labelBookID.Location = new System.Drawing.Point(10, 95);
            this.labelBookID.Name = "labelBookID";
            this.labelBookID.Size = new System.Drawing.Size(53, 12);
            this.labelBookID.TabIndex = 0;
            this.labelBookID.Text = "教材编号";
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(12, 350);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 4;
            this.button_OK.Text = "确认(&O)";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(12, 376);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 5;
            this.button_Cancel.Text = "取消(&C)";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // groupBox_Info
            // 
            this.groupBox_Info.Controls.Add(this.label_Attr);
            this.groupBox_Info.Controls.Add(this.label_Category);
            this.groupBox_Info.Controls.Add(this.label_Title);
            this.groupBox_Info.Controls.Add(this.label_Publish);
            this.groupBox_Info.Controls.Add(this.label_Author);
            this.groupBox_Info.Controls.Add(this.label_Name);
            this.groupBox_Info.Controls.Add(this.label2);
            this.groupBox_Info.Controls.Add(this.label5);
            this.groupBox_Info.Controls.Add(this.label4);
            this.groupBox_Info.Controls.Add(this.label3);
            this.groupBox_Info.Controls.Add(this.label6);
            this.groupBox_Info.Controls.Add(this.label1);
            this.groupBox_Info.Location = new System.Drawing.Point(99, 13);
            this.groupBox_Info.Name = "groupBox_Info";
            this.groupBox_Info.Size = new System.Drawing.Size(323, 194);
            this.groupBox_Info.TabIndex = 1;
            this.groupBox_Info.TabStop = false;
            this.groupBox_Info.Text = "教材基本信息";
            // 
            // label_Title
            // 
            this.label_Title.AutoSize = true;
            this.label_Title.Location = new System.Drawing.Point(115, 82);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(71, 12);
            this.label_Title.TabIndex = 15;
            this.label_Title.Text = "label_Title";
            // 
            // label_Publish
            // 
            this.label_Publish.AutoSize = true;
            this.label_Publish.Location = new System.Drawing.Point(115, 106);
            this.label_Publish.Name = "label_Publish";
            this.label_Publish.Size = new System.Drawing.Size(83, 12);
            this.label_Publish.TabIndex = 14;
            this.label_Publish.Text = "label_Publish";
            // 
            // label_Author
            // 
            this.label_Author.AutoSize = true;
            this.label_Author.Location = new System.Drawing.Point(115, 53);
            this.label_Author.Name = "label_Author";
            this.label_Author.Size = new System.Drawing.Size(77, 12);
            this.label_Author.TabIndex = 13;
            this.label_Author.Text = "label_Author";
            // 
            // label_Name
            // 
            this.label_Name.AutoSize = true;
            this.label_Name.Location = new System.Drawing.Point(115, 26);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(65, 12);
            this.label_Name.TabIndex = 12;
            this.label_Name.Text = "label_Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "作者";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "教材类别";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "出版社";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "作者职称";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "教材属性";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "教材名称";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_UID);
            this.groupBox1.Controls.Add(this.label_EID);
            this.groupBox1.Controls.Add(this.comboBox_Level);
            this.groupBox1.Controls.Add(this.comboBox_Apply);
            this.groupBox1.Controls.Add(this.comboBox_Service);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.comboBox_Influence);
            this.groupBox1.Location = new System.Drawing.Point(99, 217);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(323, 194);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "教材评价";
            // 
            // comboBox_Service
            // 
            this.comboBox_Service.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Service.FormattingEnabled = true;
            this.comboBox_Service.Items.AddRange(new object[] {
            "很高",
            "中等",
            "一般"});
            this.comboBox_Service.Location = new System.Drawing.Point(117, 130);
            this.comboBox_Service.Name = "comboBox_Service";
            this.comboBox_Service.Size = new System.Drawing.Size(182, 20);
            this.comboBox_Service.TabIndex = 7;
            this.comboBox_Service.SelectedIndexChanged += new System.EventHandler(this.CanUpdate);
            this.comboBox_Service.TextChanged += new System.EventHandler(this.CanUpdate);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "评委编号";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 12);
            this.label8.TabIndex = 8;
            this.label8.Text = "出版社服务质量";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 106);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 6;
            this.label9.Text = "教材应用面";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 4;
            this.label10.Text = "教材水平";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(22, 159);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 12);
            this.label11.TabIndex = 10;
            this.label11.Text = "出版社影响力";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(22, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 0;
            this.label12.Text = "评价ID";
            // 
            // comboBox_Influence
            // 
            this.comboBox_Influence.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Influence.FormattingEnabled = true;
            this.comboBox_Influence.Items.AddRange(new object[] {
            "很大",
            "中等",
            "一般"});
            this.comboBox_Influence.Location = new System.Drawing.Point(117, 156);
            this.comboBox_Influence.Name = "comboBox_Influence";
            this.comboBox_Influence.Size = new System.Drawing.Size(182, 20);
            this.comboBox_Influence.TabIndex = 9;
            this.comboBox_Influence.SelectedIndexChanged += new System.EventHandler(this.CanUpdate);
            this.comboBox_Influence.TextChanged += new System.EventHandler(this.CanUpdate);
            // 
            // label_Category
            // 
            this.label_Category.AutoSize = true;
            this.label_Category.Location = new System.Drawing.Point(115, 133);
            this.label_Category.Name = "label_Category";
            this.label_Category.Size = new System.Drawing.Size(89, 12);
            this.label_Category.TabIndex = 16;
            this.label_Category.Text = "label_Category";
            // 
            // label_Attr
            // 
            this.label_Attr.AutoSize = true;
            this.label_Attr.Location = new System.Drawing.Point(115, 159);
            this.label_Attr.Name = "label_Attr";
            this.label_Attr.Size = new System.Drawing.Size(65, 12);
            this.label_Attr.TabIndex = 17;
            this.label_Attr.Text = "label_Attr";
            // 
            // comboBox_Apply
            // 
            this.comboBox_Apply.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Apply.FormattingEnabled = true;
            this.comboBox_Apply.Items.AddRange(new object[] {
            "广泛（基础性教材）",
            "一般（大众性教材）",
            "较小（专业性教材）"});
            this.comboBox_Apply.Location = new System.Drawing.Point(117, 103);
            this.comboBox_Apply.Name = "comboBox_Apply";
            this.comboBox_Apply.Size = new System.Drawing.Size(182, 20);
            this.comboBox_Apply.TabIndex = 11;
            this.comboBox_Apply.SelectedIndexChanged += new System.EventHandler(this.CanUpdate);
            // 
            // comboBox_Level
            // 
            this.comboBox_Level.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Level.FormattingEnabled = true;
            this.comboBox_Level.Items.AddRange(new object[] {
            "很高",
            "中等",
            "一般"});
            this.comboBox_Level.Location = new System.Drawing.Point(117, 77);
            this.comboBox_Level.Name = "comboBox_Level";
            this.comboBox_Level.Size = new System.Drawing.Size(182, 20);
            this.comboBox_Level.TabIndex = 12;
            this.comboBox_Level.SelectedIndexChanged += new System.EventHandler(this.CanUpdate);
            // 
            // label_EID
            // 
            this.label_EID.AutoSize = true;
            this.label_EID.Location = new System.Drawing.Point(115, 26);
            this.label_EID.Name = "label_EID";
            this.label_EID.Size = new System.Drawing.Size(59, 12);
            this.label_EID.TabIndex = 18;
            this.label_EID.Text = "label_EID";
            // 
            // label_UID
            // 
            this.label_UID.AutoSize = true;
            this.label_UID.Location = new System.Drawing.Point(115, 53);
            this.label_UID.Name = "label_UID";
            this.label_UID.Size = new System.Drawing.Size(59, 12);
            this.label_UID.TabIndex = 19;
            this.label_UID.Text = "label_UID";
            // 
            // Form_Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 422);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.labelBookID);
            this.Controls.Add(this.button_Update);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox_Info);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_Item";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Item";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox_Info.ResumeLayout(false);
            this.groupBox_Info.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_Update;
        private System.Windows.Forms.Label labelBookID;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.GroupBox groupBox_Info;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBox_Influence;
        private System.Windows.Forms.ComboBox comboBox_Service;
        private System.Windows.Forms.Label label_Name;
        private System.Windows.Forms.Label label_Author;
        private System.Windows.Forms.Label label_Publish;
        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.Label label_Category;
        private System.Windows.Forms.Label label_Attr;
        private System.Windows.Forms.Label label_UID;
        private System.Windows.Forms.Label label_EID;
        private System.Windows.Forms.ComboBox comboBox_Level;
        private System.Windows.Forms.ComboBox comboBox_Apply;

    }
}
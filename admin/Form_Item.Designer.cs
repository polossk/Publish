namespace PublishServer
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
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.labelBookID = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox_Info = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxAuthor = new System.Windows.Forms.TextBox();
            this.comboBoxTitle = new System.Windows.Forms.ComboBox();
            this.textBoxPublish = new System.Windows.Forms.TextBox();
            this.comboBoxBelong = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBoxPaper = new System.Windows.Forms.ComboBox();
            this.panelAttr = new System.Windows.Forms.Panel();
            this.radioButtonText = new System.Windows.Forms.RadioButton();
            this.radioButtonMono = new System.Windows.Forms.RadioButton();
            this.panelColorful = new System.Windows.Forms.Panel();
            this.radioButtonNay = new System.Windows.Forms.RadioButton();
            this.radioButtonAye = new System.Windows.Forms.RadioButton();
            this.comboBoxBookCnt = new System.Windows.Forms.ComboBox();
            this.panelSize = new System.Windows.Forms.Panel();
            this.radioButtonSizeA5 = new System.Windows.Forms.RadioButton();
            this.radioButtonSizeA4 = new System.Windows.Forms.RadioButton();
            this.panelBind = new System.Windows.Forms.Panel();
            this.radioButtonBindHard = new System.Windows.Forms.RadioButton();
            this.radioButtonBindPaper = new System.Windows.Forms.RadioButton();
            this.numericUpDownWords = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox_Info.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelAttr.SuspendLayout();
            this.panelColorful.SuspendLayout();
            this.panelSize.SuspendLayout();
            this.panelBind.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWords)).BeginInit();
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
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(12, 323);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdate.TabIndex = 0;
            this.buttonUpdate.Text = "更新(&U)";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // labelBookID
            // 
            this.labelBookID.AutoSize = true;
            this.labelBookID.Location = new System.Drawing.Point(10, 95);
            this.labelBookID.Name = "labelBookID";
            this.labelBookID.Size = new System.Drawing.Size(53, 12);
            this.labelBookID.TabIndex = 2;
            this.labelBookID.Text = "教材编号";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(12, 350);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "确认(&O)";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(12, 376);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "取消(&C)";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // groupBox_Info
            // 
            this.groupBox_Info.Controls.Add(this.panelAttr);
            this.groupBox_Info.Controls.Add(this.label2);
            this.groupBox_Info.Controls.Add(this.label5);
            this.groupBox_Info.Controls.Add(this.label4);
            this.groupBox_Info.Controls.Add(this.label3);
            this.groupBox_Info.Controls.Add(this.label6);
            this.groupBox_Info.Controls.Add(this.label1);
            this.groupBox_Info.Controls.Add(this.textBoxName);
            this.groupBox_Info.Controls.Add(this.textBoxAuthor);
            this.groupBox_Info.Controls.Add(this.comboBoxTitle);
            this.groupBox_Info.Controls.Add(this.textBoxPublish);
            this.groupBox_Info.Controls.Add(this.comboBoxBelong);
            this.groupBox_Info.Location = new System.Drawing.Point(99, 13);
            this.groupBox_Info.Name = "groupBox_Info";
            this.groupBox_Info.Size = new System.Drawing.Size(323, 194);
            this.groupBox_Info.TabIndex = 5;
            this.groupBox_Info.TabStop = false;
            this.groupBox_Info.Text = "教材基本信息";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "作者";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "教材类别";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "出版社";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "作者职称";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 5;
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
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(103, 23);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(196, 21);
            this.textBoxName.TabIndex = 0;
            this.textBoxName.TextChanged += new System.EventHandler(this.CanUpdate);
            // 
            // textBoxAuthor
            // 
            this.textBoxAuthor.Location = new System.Drawing.Point(103, 50);
            this.textBoxAuthor.Name = "textBoxAuthor";
            this.textBoxAuthor.Size = new System.Drawing.Size(196, 21);
            this.textBoxAuthor.TabIndex = 1;
            this.textBoxAuthor.TextChanged += new System.EventHandler(this.CanUpdate);
            // 
            // comboBoxTitle
            // 
            this.comboBoxTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTitle.FormattingEnabled = true;
            this.comboBoxTitle.Items.AddRange(new object[] {
            "院士",
            "教授",
            "副教授",
            "讲师"});
            this.comboBoxTitle.Location = new System.Drawing.Point(103, 77);
            this.comboBoxTitle.Name = "comboBoxTitle";
            this.comboBoxTitle.Size = new System.Drawing.Size(196, 20);
            this.comboBoxTitle.TabIndex = 2;
            this.comboBoxTitle.SelectedIndexChanged += new System.EventHandler(this.CanUpdate);
            // 
            // textBoxPublish
            // 
            this.textBoxPublish.Location = new System.Drawing.Point(103, 103);
            this.textBoxPublish.Name = "textBoxPublish";
            this.textBoxPublish.Size = new System.Drawing.Size(196, 21);
            this.textBoxPublish.TabIndex = 3;
            this.textBoxPublish.TextChanged += new System.EventHandler(this.CanUpdate);
            // 
            // comboBoxBelong
            // 
            this.comboBoxBelong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBelong.FormattingEnabled = true;
            this.comboBoxBelong.Items.AddRange(new object[] {
            "社会科学",
            "工科教材",
            "理科教材"});
            this.comboBoxBelong.Location = new System.Drawing.Point(103, 130);
            this.comboBoxBelong.Name = "comboBoxBelong";
            this.comboBoxBelong.Size = new System.Drawing.Size(196, 20);
            this.comboBoxBelong.TabIndex = 4;
            this.comboBoxBelong.TextChanged += new System.EventHandler(this.CanUpdate);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericUpDownWords);
            this.groupBox1.Controls.Add(this.panelBind);
            this.groupBox1.Controls.Add(this.panelSize);
            this.groupBox1.Controls.Add(this.comboBoxBookCnt);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.comboBoxPaper);
            this.groupBox1.Controls.Add(this.panelColorful);
            this.groupBox1.Location = new System.Drawing.Point(99, 217);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(323, 194);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "教材基本信息";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "装订规格";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 4;
            this.label8.Text = "正文用纸";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 106);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 3;
            this.label9.Text = "册数";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 2;
            this.label10.Text = "开本大小";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(22, 159);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 5;
            this.label11.Text = "是否彩印";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(22, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 0;
            this.label12.Text = "教材字数";
            // 
            // comboBoxPaper
            // 
            this.comboBoxPaper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPaper.FormattingEnabled = true;
            this.comboBoxPaper.Items.AddRange(new object[] {
            "60克双胶",
            "70克双胶",
            "80克双胶"});
            this.comboBoxPaper.Location = new System.Drawing.Point(103, 130);
            this.comboBoxPaper.Name = "comboBoxPaper";
            this.comboBoxPaper.Size = new System.Drawing.Size(196, 20);
            this.comboBoxPaper.TabIndex = 4;
            this.comboBoxPaper.TextChanged += new System.EventHandler(this.CanUpdate);
            // 
            // panelAttr
            // 
            this.panelAttr.Controls.Add(this.radioButtonText);
            this.panelAttr.Controls.Add(this.radioButtonMono);
            this.panelAttr.Location = new System.Drawing.Point(103, 159);
            this.panelAttr.Margin = new System.Windows.Forms.Padding(0);
            this.panelAttr.Name = "panelAttr";
            this.panelAttr.Size = new System.Drawing.Size(196, 12);
            this.panelAttr.TabIndex = 12;
            // 
            // radioButtonText
            // 
            this.radioButtonText.AutoSize = true;
            this.radioButtonText.Checked = true;
            this.radioButtonText.Location = new System.Drawing.Point(0, -3);
            this.radioButtonText.Name = "radioButtonText";
            this.radioButtonText.Size = new System.Drawing.Size(47, 16);
            this.radioButtonText.TabIndex = 0;
            this.radioButtonText.TabStop = true;
            this.radioButtonText.Text = "教材";
            this.radioButtonText.UseVisualStyleBackColor = true;
            this.radioButtonText.CheckedChanged += new System.EventHandler(this.CanUpdate);
            // 
            // radioButtonMono
            // 
            this.radioButtonMono.AutoSize = true;
            this.radioButtonMono.Location = new System.Drawing.Point(98, -2);
            this.radioButtonMono.Name = "radioButtonMono";
            this.radioButtonMono.Size = new System.Drawing.Size(47, 16);
            this.radioButtonMono.TabIndex = 1;
            this.radioButtonMono.TabStop = true;
            this.radioButtonMono.Text = "专著";
            this.radioButtonMono.UseVisualStyleBackColor = true;
            // 
            // panelColorful
            // 
            this.panelColorful.Controls.Add(this.radioButtonNay);
            this.panelColorful.Controls.Add(this.radioButtonAye);
            this.panelColorful.Location = new System.Drawing.Point(103, 156);
            this.panelColorful.Name = "panelColorful";
            this.panelColorful.Size = new System.Drawing.Size(196, 15);
            this.panelColorful.TabIndex = 13;
            // 
            // radioButtonNay
            // 
            this.radioButtonNay.AutoSize = true;
            this.radioButtonNay.Checked = true;
            this.radioButtonNay.Location = new System.Drawing.Point(98, -2);
            this.radioButtonNay.Name = "radioButtonNay";
            this.radioButtonNay.Size = new System.Drawing.Size(35, 16);
            this.radioButtonNay.TabIndex = 1;
            this.radioButtonNay.TabStop = true;
            this.radioButtonNay.Text = "否";
            this.radioButtonNay.UseVisualStyleBackColor = true;
            // 
            // radioButtonAye
            // 
            this.radioButtonAye.AutoSize = true;
            this.radioButtonAye.Location = new System.Drawing.Point(0, -2);
            this.radioButtonAye.Name = "radioButtonAye";
            this.radioButtonAye.Size = new System.Drawing.Size(35, 16);
            this.radioButtonAye.TabIndex = 0;
            this.radioButtonAye.Text = "是";
            this.radioButtonAye.UseVisualStyleBackColor = true;
            this.radioButtonAye.CheckedChanged += new System.EventHandler(this.CanUpdate);
            // 
            // comboBoxBookCnt
            // 
            this.comboBoxBookCnt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBookCnt.FormattingEnabled = true;
            this.comboBoxBookCnt.Items.AddRange(new object[] {
            "单册",
            "上下册",
            "上中下册"});
            this.comboBoxBookCnt.Location = new System.Drawing.Point(103, 103);
            this.comboBoxBookCnt.Name = "comboBoxBookCnt";
            this.comboBoxBookCnt.Size = new System.Drawing.Size(196, 20);
            this.comboBoxBookCnt.TabIndex = 15;
            this.comboBoxBookCnt.TextChanged += new System.EventHandler(this.CanUpdate);
            // 
            // panelSize
            // 
            this.panelSize.Controls.Add(this.radioButtonSizeA5);
            this.panelSize.Controls.Add(this.radioButtonSizeA4);
            this.panelSize.Location = new System.Drawing.Point(103, 80);
            this.panelSize.Name = "panelSize";
            this.panelSize.Size = new System.Drawing.Size(196, 12);
            this.panelSize.TabIndex = 16;
            // 
            // radioButtonSizeA5
            // 
            this.radioButtonSizeA5.AutoSize = true;
            this.radioButtonSizeA5.Location = new System.Drawing.Point(98, -2);
            this.radioButtonSizeA5.Name = "radioButtonSizeA5";
            this.radioButtonSizeA5.Size = new System.Drawing.Size(71, 16);
            this.radioButtonSizeA5.TabIndex = 1;
            this.radioButtonSizeA5.TabStop = true;
            this.radioButtonSizeA5.Text = "32开(A5)";
            this.radioButtonSizeA5.UseVisualStyleBackColor = true;
            // 
            // radioButtonSizeA4
            // 
            this.radioButtonSizeA4.AutoSize = true;
            this.radioButtonSizeA4.Checked = true;
            this.radioButtonSizeA4.Location = new System.Drawing.Point(0, -2);
            this.radioButtonSizeA4.Name = "radioButtonSizeA4";
            this.radioButtonSizeA4.Size = new System.Drawing.Size(71, 16);
            this.radioButtonSizeA4.TabIndex = 0;
            this.radioButtonSizeA4.TabStop = true;
            this.radioButtonSizeA4.Text = "16开(A4)";
            this.radioButtonSizeA4.UseVisualStyleBackColor = true;
            this.radioButtonSizeA4.CheckedChanged += new System.EventHandler(this.CanUpdate);
            // 
            // panelBind
            // 
            this.panelBind.Controls.Add(this.radioButtonBindHard);
            this.panelBind.Controls.Add(this.radioButtonBindPaper);
            this.panelBind.Location = new System.Drawing.Point(103, 53);
            this.panelBind.Name = "panelBind";
            this.panelBind.Size = new System.Drawing.Size(196, 12);
            this.panelBind.TabIndex = 17;
            // 
            // radioButtonBindHard
            // 
            this.radioButtonBindHard.AutoSize = true;
            this.radioButtonBindHard.Location = new System.Drawing.Point(98, -2);
            this.radioButtonBindHard.Name = "radioButtonBindHard";
            this.radioButtonBindHard.Size = new System.Drawing.Size(47, 16);
            this.radioButtonBindHard.TabIndex = 1;
            this.radioButtonBindHard.TabStop = true;
            this.radioButtonBindHard.Text = "精装";
            this.radioButtonBindHard.UseVisualStyleBackColor = true;
            // 
            // radioButtonBindPaper
            // 
            this.radioButtonBindPaper.AutoSize = true;
            this.radioButtonBindPaper.Checked = true;
            this.radioButtonBindPaper.Location = new System.Drawing.Point(0, -2);
            this.radioButtonBindPaper.Name = "radioButtonBindPaper";
            this.radioButtonBindPaper.Size = new System.Drawing.Size(47, 16);
            this.radioButtonBindPaper.TabIndex = 0;
            this.radioButtonBindPaper.TabStop = true;
            this.radioButtonBindPaper.Text = "平装";
            this.radioButtonBindPaper.UseVisualStyleBackColor = true;
            this.radioButtonBindPaper.CheckedChanged += new System.EventHandler(this.CanUpdate);
            // 
            // numericUpDownWords
            // 
            this.numericUpDownWords.Location = new System.Drawing.Point(103, 24);
            this.numericUpDownWords.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericUpDownWords.Name = "numericUpDownWords";
            this.numericUpDownWords.Size = new System.Drawing.Size(196, 21);
            this.numericUpDownWords.TabIndex = 14;
            this.numericUpDownWords.ValueChanged += new System.EventHandler(this.CanUpdate);
            // 
            // Form_Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 422);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.labelBookID);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox_Info);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_Item";
            this.Text = "Form_Item";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox_Info.ResumeLayout(false);
            this.groupBox_Info.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelAttr.ResumeLayout(false);
            this.panelAttr.PerformLayout();
            this.panelColorful.ResumeLayout(false);
            this.panelColorful.PerformLayout();
            this.panelSize.ResumeLayout(false);
            this.panelSize.PerformLayout();
            this.panelBind.ResumeLayout(false);
            this.panelBind.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWords)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Label labelBookID;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBox_Info;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxPublish;
        private System.Windows.Forms.TextBox textBoxAuthor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.ComboBox comboBoxBelong;
        private System.Windows.Forms.ComboBox comboBoxTitle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBoxPaper;
        private System.Windows.Forms.Panel panelAttr;
        private System.Windows.Forms.RadioButton radioButtonText;
        private System.Windows.Forms.RadioButton radioButtonMono;
        private System.Windows.Forms.Panel panelColorful;
        private System.Windows.Forms.RadioButton radioButtonNay;
        private System.Windows.Forms.RadioButton radioButtonAye;
        private System.Windows.Forms.ComboBox comboBoxBookCnt;
        private System.Windows.Forms.Panel panelBind;
        private System.Windows.Forms.RadioButton radioButtonBindHard;
        private System.Windows.Forms.RadioButton radioButtonBindPaper;
        private System.Windows.Forms.Panel panelSize;
        private System.Windows.Forms.RadioButton radioButtonSizeA5;
        private System.Windows.Forms.RadioButton radioButtonSizeA4;
        private System.Windows.Forms.NumericUpDown numericUpDownWords;

    }
}
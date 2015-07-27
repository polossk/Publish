namespace PublishClient
{
    partial class Form_Connect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Connect));
            this.label_Title = new System.Windows.Forms.Label();
            this.label_ShowIP = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button_Exit = new System.Windows.Forms.Button();
            this.button_Launch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_Title
            // 
            this.label_Title.AutoSize = true;
            this.label_Title.Location = new System.Drawing.Point(35, 23);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(143, 12);
            this.label_Title.TabIndex = 0;
            this.label_Title.Text = "正在寻找并连接服务器...";
            // 
            // label_ShowIP
            // 
            this.label_ShowIP.AutoSize = true;
            this.label_ShowIP.Location = new System.Drawing.Point(35, 46);
            this.label_ShowIP.Name = "label_ShowIP";
            this.label_ShowIP.Size = new System.Drawing.Size(101, 12);
            this.label_ShowIP.TabIndex = 2;
            this.label_ShowIP.Text = "服务器的地址为：";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button_Exit
            // 
            this.button_Exit.Cursor = System.Windows.Forms.Cursors.Default;
            this.button_Exit.Enabled = false;
            this.button_Exit.Location = new System.Drawing.Point(174, 69);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(75, 23);
            this.button_Exit.TabIndex = 1;
            this.button_Exit.Text = "退出(&X)";
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // button_Launch
            // 
            this.button_Launch.Enabled = false;
            this.button_Launch.Location = new System.Drawing.Point(37, 69);
            this.button_Launch.Name = "button_Launch";
            this.button_Launch.Size = new System.Drawing.Size(75, 23);
            this.button_Launch.TabIndex = 0;
            this.button_Launch.Text = "启动(&L)";
            this.button_Launch.UseVisualStyleBackColor = true;
            // 
            // Form_Connect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 104);
            this.Controls.Add(this.button_Launch);
            this.Controls.Add(this.button_Exit);
            this.Controls.Add(this.label_ShowIP);
            this.Controls.Add(this.label_Title);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_Connect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "连接服务器中...";
            this.Load += new System.EventHandler(this.OnLoad_Connect);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.Label label_ShowIP;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Button button_Launch;

    }
}
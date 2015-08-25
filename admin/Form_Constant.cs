using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using Universal.Net;
using Universal.Global;
using Universal.Data;
using Universal.User;
using System.Runtime.InteropServices;

namespace PublishServer
{
    public partial class Form_Constant : Form
    {
        public BookCosting Value { get; set; }
        public string AppPath { get; set; }
        public NumericUpDown[] Collection { get; set; }
        private double[] _raw_data_ = new double[16];
        public Form_Constant()
        {
            InitializeComponent();
            AppPath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "const.bin";
            FileInfo fi = new FileInfo(AppPath);
            if (fi.Exists)
                LoadConstData(AppPath);
            else
            {
                FileStream fs = fi.Create(); fs.Close();
                Value = new BookCosting();
                SaveConstData(AppPath);
            }
            OnDisplay();
            BuildCollection();
        }

        private void BuildCollection()
        {
            Collection = new NumericUpDown[16] {
                this.numericUpDown_Remu,
                this.numericUpDown_Chck,
                this.numericUpDown_Pfrd,
                this.numericUpDown_Bdly,
                this.numericUpDown_Cmps,
                this.numericUpDown_Aplt,
                this.numericUpDown_Cplt,
                this.numericUpDown_Cles,
                this.numericUpDown_Cful,
                this.numericUpDown_Bind,
                this.numericUpDown_W60C,
                this.numericUpDown_W70C,
                this.numericUpDown_W80C,
                this.numericUpDown_WC20,
                this.numericUpDown_Ppgd,
                this.numericUpDown_Mngm
            };
        }

        private void LoadConstData(string path)
        {
            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            BinaryReader rd = new BinaryReader(fileStream);
            rd.BaseStream.Seek(0, SeekOrigin.Begin);
            byte[] raw = rd.ReadBytes((int)rd.BaseStream.Length);
            MemoryStream buf = new MemoryStream(raw);
            BinaryFormatter bf = new BinaryFormatter();
            Value = bf.Deserialize(buf) as BookCosting;
            // 释放文件流资源
            fileStream.Flush();
            fileStream.Close();
            fileStream.Dispose();
        }

        private void SaveConstData(string path)
        {
            FileStream fileStream = new FileStream(path, FileMode.Create);
            byte[] serBytes;
            BookCosting reff = Value;
            ToBytes<BookCosting>.GetBytes(ref reff, out serBytes);
            fileStream.Write(serBytes, 0, serBytes.Length);
            fileStream.Flush();
            fileStream.Close();
            fileStream.Dispose();
        }

        private void OnDisplay()
        {
            this.numericUpDown_Remu.Value = (decimal)Value.Remuneration;
            this.numericUpDown_Chck.Value = (decimal)Value.Checking;
            this.numericUpDown_Pfrd.Value = (decimal)Value.Proofreading;
            this.numericUpDown_Bdly.Value = (decimal)Value.BindingAndLayout / 10000;
            this.numericUpDown_Cmps.Value = (decimal)Value.Composing;
            this.numericUpDown_Aplt.Value = (decimal)Value.ArticlePlatemaking;
            this.numericUpDown_Cplt.Value = (decimal)Value.CoverPlatemaking;
            this.numericUpDown_Cles.Value = (decimal)Value.Colorless;
            this.numericUpDown_Cful.Value = (decimal)Value.Colorful;
            this.numericUpDown_Bind.Value = (decimal)Value.Binding;
            this.numericUpDown_W60C.Value = (decimal)Value.W60Costing;
            this.numericUpDown_W70C.Value = (decimal)Value.W70Costing;
            this.numericUpDown_W80C.Value = (decimal)Value.W80Costing;
            this.numericUpDown_WC20.Value = (decimal)Value.W200CuCosting;
            this.numericUpDown_Ppgd.Value = (decimal)Value.Propagandizing / 10000;
            this.numericUpDown_Mngm.Value = (decimal)Value.Management / 10000;
        }

        private void CanUpdate(object sender, EventArgs e)
        {
            if (!this.button_Update.Enabled)
                this.button_Update.Enabled = true;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 16; i++ )
            {
                var part = Collection[i];
                var val = part.Value;
                if (val <= 0)
                {
                    MessageBox.Show("属性输入错误！", "输入错误", MessageBoxButtons.OK);
                    return;
                }
                _raw_data_[i] = (double)val;
            }

            this.Text = "*[未更新] 印刷成本";

            this.button_OK.Enabled = true;
            this.button_Update.Enabled = false;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            BookCosting now = new BookCosting(_raw_data_set_: _raw_data_);
            Value = now;
            SaveConstData(AppPath);
            OnDisplay();
            this.Text = "印刷成本";
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}

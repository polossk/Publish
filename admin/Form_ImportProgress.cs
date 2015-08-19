using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PublishServer
{
    public partial class Form_ImportProgress : Form
    {
        public Form_ImportProgress(int cnt = 100)
        {
            InitializeComponent();
            this.progressBar1.Maximum = cnt;
            this.progressBar1.Minimum = 0;
            this.progressBar1.Value = this.progressBar1.Minimum;
            this.label_Progress.Text = "0";
            this.label_End.Text = "/ " + cnt.ToString();
        }
        public void ChangeTo(int current)
        {
            this.progressBar1.Value = current;
            this.label_Progress.Text = this.progressBar1.Value.ToString();
        }

    }
}

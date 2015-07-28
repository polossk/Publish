using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PublishClient
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form_Connect con = new Form_Connect();
            con.ShowDialog();
            if (con.DialogResult == DialogResult.OK)
            {
                Form_Login login = new Form_Login();
                login.ShowDialog();
                if (login.DialogResult == DialogResult.OK)
                    Application.Run(new Form_Main());
            }


            
        }
    }
}

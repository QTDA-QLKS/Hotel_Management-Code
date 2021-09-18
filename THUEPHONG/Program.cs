using System;
using System.IO;
using System.Windows.Forms;

namespace THUEPHONG
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (File.Exists("connectdb.dba"))
            {
                Application.Run(new frmMain());
            }
            else
            {
                Application.Run(new frmKetNoiDB());
            }    
               
        }
    }
}

using System;
using System.IO;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using DataLayer;
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
                //string conStr = "";
                //Doc file connect
                //BinaryFormatter bf = new BinaryFormatter();
                //FileStream fs = File.Open("connectdb.dba", FileMode.Open, FileAccess.Read);
                //connect cp = (connect)bf.Deserialize(fs);

                //Decrypt noi dung
                //string servername = Encryptor.Decrypt(cp.servername, "qwertyuiop", true);
                //string username = Encryptor.Decrypt(cp.username, "qwertyuiop", true);
                //string pass = Encryptor.Decrypt(cp.passwd, "qwertyuiop", true);
                //string database = Encryptor.Decrypt(cp.database, "qwertyuiop", true);
                //conStr += "Data Source=LAPTOP-3RPHFDAK\\SQLEXPRESS;Initial Catalog=HOTELS;Persist Security Info=True;User ID=sa;Password=12345678;MultipleActiveResultSets=True;Application Name=EntityFramework";
                //connoi = conStr;
            }
            else
            {
                Application.Run(new frmKetNoiDB());
            }    
               
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace THUEPHONG
{
    public class myFunctions
    {
        public static string _srv;
        public static string _us;
        public static string _pw;
        public static string _sb;
        static SqlConnection con = new SqlConnection();
        public static void taoketnoi()
        {
            con.ConnectionString = "Data Source=LAPTOP-3RPHFDAK\\SQLEXPRESS;Initial Catalog=HOTELS;Persist Security Info=True;User ID=sa;Password=12345678";
            try
            {
                con.Open();
            }
            catch (Exception)
            {

            }
        }
        public static void dongketnoi()
        {
            con.Close();
        }

        public static DataTable laydulieu (string qr)
        {
            taoketnoi();
            DataTable databl = new DataTable();
            SqlDataAdapter dap = new SqlDataAdapter();
            dap.SelectCommand = new SqlCommand(qr, con);
            dap.Fill(databl);
            return databl;
        }

        public static DateTime GetFirstDayInMont(int year ,int month)
        {
            return new DateTime(year, month, 1);
        }
    }
}

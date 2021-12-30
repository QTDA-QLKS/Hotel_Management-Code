using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace THUEPHONG
{
    public class myFunctions
    {
        public static string _macty;
        public static string _madvi;
        public static string _srv;
        public static string _us;
        public static string _pw;
        public static string _db;
        static SqlConnection con = new SqlConnection();
        public static void taoketnoi()
        {
            con.ConnectionString = "Data Source=DESKTOP-O4T8056\\SQLEXPRESS;Initial Catalog=HOTELS;Persist Security Info=True;User ID=sa;Password=12345678";
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Open();
                }
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
            dongketnoi();
            return databl;
        }

        public static DateTime GetFirstDayInMont(int year ,int month)
        {
            return new DateTime(year, month, 1);
        }

        

    }
}

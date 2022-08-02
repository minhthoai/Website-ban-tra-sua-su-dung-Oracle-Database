using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data.OracleClient;
using System.Data;
using Oracle.DataAccess.Client;



namespace QL_BanTraSua
{
    static class Program
    {
       
        public static string strConn = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)))" +
            "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=pdborcl)));" +
            "User Id=milktea;Password=123456;";
        public static OracleConnection conn = new OracleConnection(strConn);

        public static OracleDataAdapter myReader;
        public static String serverName;
        public static String userName;
        public static String mLogin = "";
        public static String password = "";
        public static DataTable ExecOracleDataTable(string cmd)
        {
            
            DataTable dt = new DataTable();
            if (Program.conn.State == ConnectionState.Closed)
                Program.conn.Open();
            OracleDataAdapter da = new OracleDataAdapter(cmd, conn);
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form_DangNhap());
        }
        public static void ExecOracleCommand(OracleCommand oracleCommand)
        {
            if (Program.conn.State == System.Data.ConnectionState.Closed)
            {
                Program.conn.Open();
            }
            try
            {
                oracleCommand.ExecuteNonQuery();
                Program.conn.Close();
            }
            catch (OracleException e)
            {
                if (e.Message.Contains("Error converthing data type varchar to int "))
                    MessageBox.Show("Lỗi");
                else
                    MessageBox.Show(e.Message);
                Program.conn.Close();
            }
        }



    }
}

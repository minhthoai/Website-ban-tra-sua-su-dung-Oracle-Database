using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OracleClient;



namespace QL_BanTraSua
{
    public partial class Form_KhuVuc : Form
    {
        OracleConnection conn_publisher = new OracleConnection();
        DataTable dt = new DataTable();
        //string strConn = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))" +
        //    "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=MILKTEA)));" +
        //    "User Id=MILKTEA;Password=123456;";
        public Form_KhuVuc()
        {
            InitializeComponent();
        }

        [Obsolete]
        private void Form_KhuVuc_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            HienThiDuLieuKhuVuc();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HienThiDuLieuKhuVuc()
        {
            String strLenh = "SELECT MAQH, TENQH, GHICHU FROM QUANHUYEN ";
            dt = Program.ExecOracleDataTable(strLenh);
            dgv_khuvuc.DataSource = dt;
            dgv_khuvuc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_khuvuc.Columns[0].HeaderText = "Mã khu vực";
            dgv_khuvuc.Columns[1].HeaderText = "Tên khu vựcc";
            dgv_khuvuc.Columns[2].HeaderText = "Ghi chú";
            conn_publisher.Close();
        }
        public void timKiem()
        {
            String strlenh = "SELECT * FROM QUANHUYEN WHERE MAQH ='" + txt_maqh.Text + "'";
            dt = Program.ExecOracleDataTable(strlenh);
            dgv_khuvuc.DataSource = dt;
        }
        private void btn_taomoi_Click(object sender, EventArgs e)
        {
            timKiem();
        }

        private void btn_all_Click(object sender, EventArgs e)
        {
            HienThiDuLieuKhuVuc();
        }
    }
}

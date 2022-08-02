using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
namespace QL_BanTraSua
{
    public partial class Form_XoaTaiKhoan : Form
    {
        OracleConnection conn_publisher = new OracleConnection();
        DataTable dt = new DataTable();
        public Form_XoaTaiKhoan()
        {
            InitializeComponent();
            HienThiDuLieuTaiKhoan();
        }

        private void Form_XoaTaiKhoan_Load(object sender, EventArgs e)
        {

        }
        private void HienThiDuLieuTaiKhoan()
        {
            String strLenh = "SELECT TAIKHOAN, MATKHAU, HODEM, TENTV, NGAYSINH, GIOITINH, SODT, EMAIL, DIACHI FROM TAIKHOANTV ";
            dt = Program.ExecOracleDataTable(strLenh);
            dgv_taikhoan.DataSource = dt;
            dgv_taikhoan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_taikhoan.Columns[0].HeaderText = "Tài khoản";
            dgv_taikhoan.Columns[1].HeaderText = "Mật khẩu";
            //dgv_thongtintaikhoan.Columns[2].HeaderText = "Mã nhóm";
            dgv_taikhoan.Columns[2].HeaderText = "Họ đệm";
            dgv_taikhoan.Columns[3].HeaderText = "Tên thành viên";
            dgv_taikhoan.Columns[4].HeaderText = "Ngày sinh";
            dgv_taikhoan.Columns[5].HeaderText = "Giới tính";
            dgv_taikhoan.Columns[6].HeaderText = "Số điện thoại";
            dgv_taikhoan.Columns[7].HeaderText = "Email";
            dgv_taikhoan.Columns[8].HeaderText = "Địa chỉ";
            // dgv_thongtintaikhoan.Columns[10].HeaderText = "Mã quận huyện";
            //dgv_thongtintaikhoan.Columns[9].HeaderText = "Trạng thái";
            //dgv_thongtintaikhoan.Columns[12].HeaderText = "Ghi chú";
            conn_publisher.Close();
        }
        public void timKiem()
        {
            String strlenh = "SELECT * FROM TAIKHOANTV WHERE TAIKHOAN ='" + txt_timkiem.Text + "'";
            dt = Program.ExecOracleDataTable(strlenh);
            dgv_taikhoan.DataSource = dt;
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            timKiem();
        }

        private void btn_hienthilai_Click(object sender, EventArgs e)
        {
            HienThiDuLieuTaiKhoan();
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            String strlenh = "xoa_TaiKhoanTV";
            OracleCommand oracleCommand = new OracleCommand(strlenh, Program.conn);
            oracleCommand.CommandType = CommandType.StoredProcedure;
            oracleCommand.CommandTimeout = 100;

            oracleCommand.Parameters.Add(new OracleParameter("TaiKhoan1", txt_taikhoan.Text.ToString().Trim()));

            Program.ExecOracleCommand(oracleCommand);

            HienThiDuLieuTaiKhoan();
        }
    }
}

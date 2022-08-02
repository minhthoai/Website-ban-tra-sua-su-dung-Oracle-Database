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
    public partial class Form_ThongTinTaiKhoan : Form
    {
        OracleConnection conn_publisher=new OracleConnection();
        DataTable dt=new DataTable();
        public Form_ThongTinTaiKhoan()
        {
            InitializeComponent();
            HienThiDuLieuTaiKhoan();
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_ThongTinTaiKhoan_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            //HienThiDuLieuTaiKhoan();
            //format columns
            //this.dgv_thongtintaikhoan.Columns[];
        }
        private void HienThiDuLieuTaiKhoan()
        {
            String strLenh = "SELECT TAIKHOAN, MATKHAU, NTK.TENNHOM, HODEM, TENTV, NGAYSINH, GIOITINH, SODT, EMAIL, DIACHI FROM TAIKHOANTV TK, NHOMTK NTK WHERE TK.MANHOM = NTK.MANHOM";
            dt = Program.ExecOracleDataTable(strLenh);
            dgv_thongtintaikhoan.DataSource = dt;
            dgv_thongtintaikhoan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_thongtintaikhoan.Columns[0].HeaderText = "Tài khoản";
            dgv_thongtintaikhoan.Columns[1].HeaderText = "Mật khẩu";
            dgv_thongtintaikhoan.Columns[2].HeaderText = "Tên nhóm";
            dgv_thongtintaikhoan.Columns[3].HeaderText = "Họ đệm";
            dgv_thongtintaikhoan.Columns[4].HeaderText = "Tên thành viên";
            dgv_thongtintaikhoan.Columns[5].HeaderText = "Ngày sinh";
            dgv_thongtintaikhoan.Columns[6].HeaderText = "Giới tính";
            dgv_thongtintaikhoan.Columns[7].HeaderText = "Số điện thoại";
            dgv_thongtintaikhoan.Columns[8].HeaderText = "Email";
            dgv_thongtintaikhoan.Columns[9].HeaderText = "Địa chỉ";
            conn_publisher.Close();
        }
    }
}

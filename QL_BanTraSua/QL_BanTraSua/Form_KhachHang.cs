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
    public partial class Form_KhachHang : Form
    {
        OracleConnection conn_publisher = new OracleConnection();

        DataTable dt = new DataTable();
        public Form_KhachHang()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            
        }

        private void Form_KhachHang_Load(object sender, EventArgs e)
        {
            
            HienThiDuLieuKhachHang();
        }

        private void HienThiDuLieuKhachHang()
        {
            String strLenh = "SELECT MAKH, TENKH, SODT, EMAIL, DIACHI ,MAQH, NGAYSINH, GIOITINH, GHICHU, DIEMTICHLUY FROM KHACHHANG ";
            dt = Program.ExecOracleDataTable(strLenh);
            dgv_khachhang.DataSource = dt;
            dgv_khachhang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_khachhang.Columns[0].HeaderText = "Mã khách hàng";
            dgv_khachhang.Columns[1].HeaderText = "Tên khách hàng";
            dgv_khachhang.Columns[2].HeaderText = "Số điện thoại";
            dgv_khachhang.Columns[3].HeaderText = "Email";
            dgv_khachhang.Columns[4].HeaderText = "Địa chỉ";
            dgv_khachhang.Columns[5].HeaderText = "Mã quận huyện";
            dgv_khachhang.Columns[6].HeaderText = "Ngày sinh";
            dgv_khachhang.Columns[7].HeaderText = "Giới tính";
            dgv_khachhang.Columns[8].HeaderText = "Ghi chú";
            dgv_khachhang.Columns[9].HeaderText = "Điểm tích lũy";
            conn_publisher.Close();
        }
        public void timKiem()
        {
            String strlenh = "SELECT * FROM KHACHHANG WHERE MAKH ='" + txt_lockh.Text + "'";
            dt = Program.ExecOracleDataTable(strlenh);
            dgv_khachhang.DataSource = dt;
        }
        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            timKiem();
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_hienthilai_Click(object sender, EventArgs e)
        {
            HienThiDuLieuKhachHang();
        }
    }
}

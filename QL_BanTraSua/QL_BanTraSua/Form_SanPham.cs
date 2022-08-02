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
    public partial class Form_SanPham : Form
    {
        OracleConnection conn_publisher = new OracleConnection();
        DataTable dt = new DataTable();
        public Form_SanPham()
        {
            InitializeComponent();
        }

        private void Form_SanPham_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            HienThiDuLieuSanPham();
        }
        private void HienThiDuLieuSanPham()
        {
            String strLenh = "SELECT MASP, TENSP, MALOAI, NDTOMTAT, NGAYDANG, LOAIHANG, TAIKHOAN, DADUYET, GIABAN, GIAMGIA, SOLUONG FROM SANPHAM ";
            dt = Program.ExecOracleDataTable(strLenh);
            dgv_Sanpham.DataSource = dt;
            dgv_Sanpham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_Sanpham.Columns[0].HeaderText = "Mã sẩn phẩm";
            dgv_Sanpham.Columns[1].HeaderText = "Tên sản phẩm";
            dgv_Sanpham.Columns[2].HeaderText = "Mã loại";
            dgv_Sanpham.Columns[3].HeaderText = "Nội dung tóm tắt";
            dgv_Sanpham.Columns[4].HeaderText = "Ngày đăng";
            dgv_Sanpham.Columns[5].HeaderText = "Loại hàng";
            dgv_Sanpham.Columns[6].HeaderText = "Tài khoản";
            dgv_Sanpham.Columns[7].HeaderText = "Đã duyệt";
            dgv_Sanpham.Columns[8].HeaderText = "Giá bán";
            dgv_Sanpham.Columns[9].HeaderText = "Giảm giá";
            dgv_Sanpham.Columns[10].HeaderText = "Số lượng";
            conn_publisher.Close();
        }
        public void timKiem()
        {
            String strlenh = "SELECT * FROM SANPHAM WHERE MASP ='" + txt_Locsp.Text + "'";
            dt=Program.ExecOracleDataTable(strlenh);
            dgv_Sanpham.DataSource = dt;
        }
        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            timKiem();
        }
    }
}

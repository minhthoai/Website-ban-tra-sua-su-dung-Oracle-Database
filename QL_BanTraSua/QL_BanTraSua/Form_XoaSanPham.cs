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
    public partial class Form_XoaSanPham : Form
    {
        OracleConnection conn_publisher= new OracleConnection();
        DataTable dt = new DataTable();
        public Form_XoaSanPham()
        {
            InitializeComponent();
            HienThiDuLieuSanPham();
        }

        private void Form_XoaSanPham_Load(object sender, EventArgs e)
        {

        }
        private void HienThiDuLieuSanPham()
        {
            String strLenh = "SELECT MASP, TENSP, MALOAI,NGAYDANG, LOAIHANG, TAIKHOAN, DADUYET, GIABAN, GIAMGIA FROM SANPHAM ";
            dt = Program.ExecOracleDataTable(strLenh);
            dgv_Sanpham.DataSource = dt;
            dgv_Sanpham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_Sanpham.Columns[0].HeaderText = "Mã sẩn phẩm";
            dgv_Sanpham.Columns[1].HeaderText = "Tên sản phẩm";
            dgv_Sanpham.Columns[2].HeaderText = "Mã loại";
            dgv_Sanpham.Columns[3].HeaderText = "Ngày đăng";
            dgv_Sanpham.Columns[4].HeaderText = "Loại hàng";
            dgv_Sanpham.Columns[5].HeaderText = "Tài khoản";
            dgv_Sanpham.Columns[6].HeaderText = "Đã duyệt";
            dgv_Sanpham.Columns[7].HeaderText = "Giá bán";
            dgv_Sanpham.Columns[8].HeaderText = "Giảm giá";
            conn_publisher.Close();
        }
        public void timKiem()
        {
            String strlenh = "SELECT * FROM SANPHAM WHERE MASP ='" + txt_timkiem.Text + "'";
            dt = Program.ExecOracleDataTable(strlenh);
            dgv_Sanpham.DataSource = dt;
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            timKiem();
        }

        private void btn_hienthitatca_Click(object sender, EventArgs e)
        {
            HienThiDuLieuSanPham();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String strlenh = "xoa_SanPham";
            OracleCommand oracleCommand = new OracleCommand(strlenh, Program.conn);
            oracleCommand.CommandType = CommandType.StoredProcedure;
            oracleCommand.CommandTimeout = 100;

            oracleCommand.Parameters.Add(new OracleParameter("Masp1", txt_masp.Text.ToString().Trim()));

            Program.ExecOracleCommand(oracleCommand);

            HienThiDuLieuSanPham();
        }
    }
}

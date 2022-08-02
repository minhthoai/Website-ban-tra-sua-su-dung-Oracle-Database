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
    public partial class Form_DanhSachDonHang : Form
    {
        OracleConnection conn_publisher = new OracleConnection();
        DataTable dt = new DataTable();
        public Form_DanhSachDonHang()
        {
            InitializeComponent();
            //HienThiDuLieuDonHang();
            HienThiDuLieuDonHang1();
            //dgv_dsdonhang.Columns[7].HeaderText = "Tổng tiền";
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //private void HienThiDuLieuDonHang()
        //{
        //    String strLenh = "SELECT MADH, MAKH, TAIKHOAN, NGAYDAT, NGAYGH, DIACHIGH, GHICHU FROM DONHANG ";
        //    dt = Program.ExecOracleDataTable(strLenh);
        //    dgv_dsdonhang.DataSource = dt;
        //    dgv_dsdonhang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        //    dgv_dsdonhang.Columns[0].HeaderText = "Mã đơn hàng";
        //    dgv_dsdonhang.Columns[1].HeaderText = "Mã khách hàng";
        //    dgv_dsdonhang.Columns[2].HeaderText = "Tài khoản nhân viên";
        //    dgv_dsdonhang.Columns[3].HeaderText = "Ngày đặt";
        //    dgv_dsdonhang.Columns[4].HeaderText = "Ngày giao hàng";
        //    dgv_dsdonhang.Columns[5].HeaderText = "Địa chỉ giao hàng";
        //    dgv_dsdonhang.Columns[6].HeaderText = "Ghi chú";

        //    conn_publisher.Close();
        //}

        private void HienThiDuLieuDonHang1 ()
        {
            String query = "SELECT D.MADH, K.TENKH, D.TAIKHOAN, D.NGAYDAT, D.NGAYGH,(SELECT SUM (SOLUONG * GIABAN - (SOLUONG * GIABAN * GIAMGIA) / 100)FROM CTDONHANG  WHERE MADH = D.MADH) AS TONGTIEN FROM DONHANG D INNER JOIN KHACHHANG K ON (D.MAKH = K.MAKH)";
            dt = Program.ExecOracleDataTable(query);
            dgv_dsdonhang.DataSource = dt;
            dgv_dsdonhang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_dsdonhang.Columns[0].HeaderText = "Mã đơn hàng";
            dgv_dsdonhang.Columns[1].HeaderText = "Mã khách hàng";
            dgv_dsdonhang.Columns[2].HeaderText = "Tài khoản nhân viên";
            dgv_dsdonhang.Columns[3].HeaderText = "Ngày đặt";
            dgv_dsdonhang.Columns[4].HeaderText = "Ngày giao hàng";
            dgv_dsdonhang.Columns[5].HeaderText = "Tổng tiền";
            conn_publisher.Close ();
        }

        private void Form_DanhSachDonHang_Load(object sender, EventArgs e)
        {

        }
        public void timKiem()
        {
            String strlenh = "SELECT * FROM HONHANG WHERE MADH ='" + txt_timkiem.Text + "'";
            dt = Program.ExecOracleDataTable(strlenh);
            dgv_dsdonhang.DataSource = dt;
        }
        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            timKiem();
        }
    }
}

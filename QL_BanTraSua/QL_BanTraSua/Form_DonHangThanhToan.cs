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
    public partial class Form_DonHangThanhToan : Form
    {
        OracleConnection conn_publisher = new OracleConnection();
        DataTable dt = new DataTable();
        public Form_DonHangThanhToan()
        {
            InitializeComponent();
            HienThiDuLieuDonHang1();
        }

        private void Form_DonHangThanhToan_Load(object sender, EventArgs e)
        {

        }
        private DataGridViewImageColumn createCommand()
        {
            DataGridViewImageColumn nut = new DataGridViewImageColumn();
            nut.Name = "Đơn hàng đã thanh toán";
            nut.Image = Properties.Resources.dathanhtoan;
            return nut;
        }
        private void HienThiDuLieuDonHang1()
        {
            String query = "SELECT D.MADH, K.TENKH, D.TAIKHOAN, D.NGAYDAT, D.NGAYGH,(SELECT SUM (SOLUONG * GIABAN - (SOLUONG * GIABAN * GIAMGIA) / 100)FROM CTDONHANG  WHERE MADH = D.MADH) AS TONGTIEN FROM DONHANG D INNER JOIN KHACHHANG K ON (D.MAKH = K.MAKH)";
            dt = Program.ExecOracleDataTable(query);
            dgv_dsthanhtoandh.DataSource = dt;
            dgv_dsthanhtoandh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_dsthanhtoandh.Columns[0].HeaderText = "Mã đơn hàng";
            dgv_dsthanhtoandh.Columns[1].HeaderText = "Mã khách hàng";
            dgv_dsthanhtoandh.Columns[2].HeaderText = "Tài khoản nhân viên";
            dgv_dsthanhtoandh.Columns[3].HeaderText = "Ngày đặt";
            dgv_dsthanhtoandh.Columns[4].HeaderText = "Ngày giao hàng";
            dgv_dsthanhtoandh.Columns[5].HeaderText = "Tổng tiền";
            this.dgv_dsthanhtoandh.Columns.Add(createCommand());
            conn_publisher.Close();
        }
    }
}

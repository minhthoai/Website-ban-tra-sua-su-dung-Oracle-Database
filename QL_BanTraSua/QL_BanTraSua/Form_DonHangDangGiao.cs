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
    public partial class Form_DonHangDangGiao : Form
    {
        OracleConnection conn_publisher = new OracleConnection();
        DataTable dt = new DataTable();
        public Form_DonHangDangGiao()
        {
            InitializeComponent();
            HienThiDuLieuDonHang1();
            
        }

        private void Form_DonHangDangGiao_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
        private DataGridViewImageColumn createCommand()
        {
            DataGridViewImageColumn nut = new DataGridViewImageColumn();
            nut.Name = "Đơn hàng đang giao";
            nut.Image = Properties.Resources.dhdanggiao;
            return nut;
        }
        private void HienThiDuLieuDonHang1()
        {
            String query = "SELECT D.MADH, K.TENKH, D.TAIKHOAN, D.NGAYDAT, D.NGAYGH,(SELECT SUM (SOLUONG * GIABAN - (SOLUONG * GIABAN * GIAMGIA) / 100)FROM CTDONHANG  WHERE MADH = D.MADH) AS TONGTIEN FROM DONHANG D INNER JOIN KHACHHANG K ON (D.MAKH = K.MAKH)";
            dt = Program.ExecOracleDataTable(query);
            dgv_dhdanggiao.DataSource = dt;
            dgv_dhdanggiao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_dhdanggiao.Columns[0].HeaderText = "Mã đơn hàng";
            dgv_dhdanggiao.Columns[1].HeaderText = "Mã khách hàng";
            dgv_dhdanggiao.Columns[2].HeaderText = "Tài khoản nhân viên";
            dgv_dhdanggiao.Columns[3].HeaderText = "Ngày đặt";
            dgv_dhdanggiao.Columns[4].HeaderText = "Ngày giao hàng";
            dgv_dhdanggiao.Columns[5].HeaderText = "Tổng tiền";
            this.dgv_dhdanggiao.Columns.Add(createCommand());
            conn_publisher.Close();
        }
    }
}

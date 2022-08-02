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
    public partial class Form_XacNhanDonHang : Form
    {
        OracleConnection conn_publisher = new OracleConnection();
        DataTable dt = new DataTable    ();
        public Form_XacNhanDonHang()
        {
            InitializeComponent();
            HienThiDuLieuDonHang1();
        }

        private void Form_XacNhanDonHang_Load(object sender, EventArgs e)
        {
            this.WindowState= FormWindowState.Maximized;
        }
        private void HienThiDuLieuDonHang1()
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
            this.dgv_dsdonhang.Columns.Add(createCommand());
            conn_publisher.Close();
        }
        private DataGridViewImageColumn createCommand()
        {
            DataGridViewImageColumn nut = new DataGridViewImageColumn();
            nut.Name = "Xác nhận đơn hàng";
            nut.Image = Properties.Resources.xacnhandh;
            return nut;
        }
        
        private void dgv_dsdonhang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==this.dgv_dsdonhang.Columns["Xác nhận đơn hàng"].Index)
            {
                string maDH = this.dgv_dsdonhang.Rows[e.RowIndex].Cells["MaDH"].Value.ToString();
            }
        }
    }
}

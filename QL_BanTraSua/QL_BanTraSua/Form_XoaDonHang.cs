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
    public partial class Form_XoaDonHang : Form
    {
        OracleConnection conn_publisher = new OracleConnection();
        DataTable dt = new DataTable();
        public Form_XoaDonHang()
        {
            InitializeComponent();
            HienThiDuLieuDonHang();
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void HienThiDuLieuDonHang()
        {
            String strLenh = "SELECT MADH, MAKH, TAIKHOAN, NGAYDAT, NGAYGH, DIACHIGH, GHICHU FROM DONHANG ";
           dt = Program.ExecOracleDataTable(strLenh);
            dgv_donhang.DataSource = dt;
            dgv_donhang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_donhang.Columns[0].HeaderText = "Mã đơn hàng";
            dgv_donhang.Columns[1].HeaderText = "Mã khách hàng";
            dgv_donhang.Columns[2].HeaderText = "Tài khoản nhân viên";
            dgv_donhang.Columns[3].HeaderText = "Ngày đặt";
            dgv_donhang.Columns[4].HeaderText = "Ngày giao hàng";
            dgv_donhang.Columns[5].HeaderText = "Địa chỉ giao hàng";
            dgv_donhang.Columns[6].HeaderText = "Ghi chú";

            conn_publisher.Close();
        }

        private void btn_hienthilai_Click(object sender, EventArgs e)
        {
            HienThiDuLieuDonHang();
        }
        public void timKiem()
        {
            String strlenh = "SELECT * FROM DONHANG WHERE MADH ='" + txt_timkiem.Text + "'";
            dt = Program.ExecOracleDataTable(strlenh);
            dgv_donhang.DataSource = dt;
        }
        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            timKiem();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            String strlenh = "xoa_DonHang";
            OracleCommand oracleCommand = new OracleCommand(strlenh, Program.conn);
            oracleCommand.CommandType = CommandType.StoredProcedure;
            oracleCommand.CommandTimeout = 100;

            oracleCommand.Parameters.Add(new OracleParameter("MaDH1", txt_madh.Text.ToString().Trim()));

            Program.ExecOracleCommand(oracleCommand);

            HienThiDuLieuDonHang();
        }
    }
}

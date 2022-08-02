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
    public partial class Form_XoaKhachHang2 : Form
    {
        OracleConnection conn_publisher = new OracleConnection();
        DataTable dt = new DataTable();
        string flag = "";
        public Form_XoaKhachHang2()
        {
            InitializeComponent();
        }

        private void Form_XoaKhachHang2_Load(object sender, EventArgs e)
        {
            HienThiDuLieuKhachHang();
        }
        private void HienThiDuLieuKhachHang()
        {
            String strLenh = "SELECT MAKH, TENKH, SODT, EMAIL, DIACHI ,MAQH, NGAYSINH, GIOITINH, GHICHU, DIEMTICHLUY FROM KHACHHANG ";
            dt = Program.ExecOracleDataTable(strLenh);
            dgv_dsKhachHang.DataSource = dt;
            dgv_dsKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_dsKhachHang.Columns[0].HeaderText = "Mã khách hàng";
            dgv_dsKhachHang.Columns[1].HeaderText = "Tên khách hàng";
            dgv_dsKhachHang.Columns[2].HeaderText = "Số điện thoại";
            dgv_dsKhachHang.Columns[3].HeaderText = "Email";
            dgv_dsKhachHang.Columns[4].HeaderText = "Địa chỉ";
            dgv_dsKhachHang.Columns[5].HeaderText = "Mã quận huyện";
            dgv_dsKhachHang.Columns[6].HeaderText = "Ngày sinh";
            dgv_dsKhachHang.Columns[7].HeaderText = "Giới tính";
            dgv_dsKhachHang.Columns[8].HeaderText = "Ghi chú";
            dgv_dsKhachHang.Columns[9].HeaderText = "Điểm tích lũy";
            conn_publisher.Close();
        }
        public void timKiem()
        {
            String strlenh = "SELECT * FROM KHACHHANG WHERE MAKH ='" + txt_timkiem.Text + "'";
            dt = Program.ExecOracleDataTable(strlenh);
            dgv_dsKhachHang.DataSource = dt;
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            timKiem();
        }

        private void btn_hienthilai_Click(object sender, EventArgs e)
        {
            HienThiDuLieuKhachHang();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            
                String strlenh = "xoa_KhachHang";
                OracleCommand oracleCommand = new OracleCommand(strlenh, Program.conn);
                oracleCommand.CommandType = CommandType.StoredProcedure;
                oracleCommand.CommandTimeout = 100;

                oracleCommand.Parameters.Add(new OracleParameter("MaKH1", txt_makh.Text.ToString().Trim()));

                Program.ExecOracleCommand(oracleCommand);
            
            HienThiDuLieuKhachHang();
        }
    }
}

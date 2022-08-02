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
    public partial class Form_ChonKhachHang : Form
    {
        OracleConnection conn_publisher = new OracleConnection();
        DataTable dt = new DataTable();
        string flag = "";
        public Form_ChonKhachHang()
        {
            InitializeComponent();
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
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int index = dgv_khachhang.CurrentCell.RowIndex;
            DataTable td = (DataTable)dgv_khachhang.DataSource;
            if (dt.Rows.Count > 0)
            {
                txt_makh.Text = dgv_khachhang.Rows[index].Cells[0].Value.ToString().Trim();
                txt_tenkh.Text = dgv_khachhang.Rows[index].Cells[1].Value.ToString().Trim();
                txt_sodt.Text = dgv_khachhang.Rows[index].Cells[2].Value.ToString().Trim();
                txt_email.Text = dgv_khachhang.Rows[index].Cells[3].Value.ToString().Trim();
                txt_diachi.Text = dgv_khachhang.Rows[index].Cells[4].Value.ToString().Trim();
                cbb_quan.Text = dgv_khachhang.Rows[index].Cells[5].Value.ToString().Trim();
                txt_ngaysinh.Text = dgv_khachhang.Rows[index].Cells[6].Value.ToString().Trim();
                txt_gioitinh.Text = dgv_khachhang.Rows[index].Cells[7].Value.ToString().Trim();
                txt_ghichu.Text = dgv_khachhang.Rows[index].Cells[8].Value.ToString().Trim();
                //txt_diem.Text = dgv_suattkh.Rows[index].Cells[9].Value.ToString().Trim();
            }
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_chon_Click(object sender, EventArgs e)
        {
            if(this.txt_makh.Text.Trim().Length > 0)
            {
                Form_TaoDonHang.maKH = this.txt_makh.Text.Trim();
                Form_TaoDonHang.tenKH = this.txt_tenkh.Text.Trim();
                Form_TaoDonHang.diaChi = this.txt_diachi.Text.Trim();
                Form_TaoDonHang.eMail = this.txt_email.Text.Trim();
                Form_TaoDonHang.gioiTinh = this.txt_gioitinh.Text.Trim();
                Form_TaoDonHang.soDT = this.txt_sodt.Text.Trim();
                this.Dispose();
            }
        }
    }
}

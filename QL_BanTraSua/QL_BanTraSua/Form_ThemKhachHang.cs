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
    public partial class Form_ThemKhachHang : Form
    {
        OracleConnection conn_publisher = new OracleConnection();
        DataTable dt = new DataTable();
        string flag = "";
        public Form_ThemKhachHang()
        {
            InitializeComponent();
            txt_makh.Enabled = txt_tenkh.Enabled = txt_sodt.Enabled = txt_email.Enabled = txt_diachi.Enabled = cbb_quan.Enabled = txt_ngaysinh.Enabled = txt_gioitinh.Enabled = txt_ghichu.Enabled =txt_diem.Enabled= false;
            btn_luu.Enabled = false;
        }

        private void Form_ThemKhachHang_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            HienThiDuLieuKhachHang();
            HienThiDuLieu_cbb_quan();
        }
        private void HienThiDuLieuKhachHang()
        {
            String strLenh = "SELECT MAKH, TENKH, SODT, EMAIL, DIACHI ,MAQH, NGAYSINH, GIOITINH, GHICHU, DIEMTICHLUY FROM KHACHHANG ";
            dt = Program.ExecOracleDataTable(strLenh);
            dgv_themkhachhang.DataSource = dt;
            dgv_themkhachhang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_themkhachhang.Columns[0].HeaderText = "Mã khách hàng";
            dgv_themkhachhang.Columns[1].HeaderText = "Tên khách hàng";
            dgv_themkhachhang.Columns[2].HeaderText = "Số điện thoại";
            dgv_themkhachhang.Columns[3].HeaderText = "Email";
            dgv_themkhachhang.Columns[4].HeaderText = "Địa chỉ";
            dgv_themkhachhang.Columns[5].HeaderText = "Mã quận huyện";
            dgv_themkhachhang.Columns[6].HeaderText = "Ngày sinh";
            dgv_themkhachhang.Columns[7].HeaderText = "Giới tính";
            dgv_themkhachhang.Columns[8].HeaderText = "Ghi chú";
            dgv_themkhachhang.Columns[9].HeaderText = "Điểm tích lũy";
            conn_publisher.Close();
        }

        private void btn_tao_Click(object sender, EventArgs e)
        {
            flag = "add";
            txt_makh.Enabled = txt_tenkh.Enabled = txt_sodt.Enabled = txt_email.Enabled = txt_diachi.Enabled = cbb_quan.Enabled = txt_ngaysinh.Enabled = txt_gioitinh.Enabled = txt_ghichu.Enabled =txt_diem.Enabled= true;
            txt_makh.Text=dt.Rows[0]["MAKH"].ToString().Trim();

            btn_luu.Enabled = true;
        }
        private bool CheckValidate(TextBox tb, string str)
        {
            if (tb.Text.Trim().Equals(""))
            {
                MessageBox.Show(str, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool CheckExistMaKH(String maKH)
        {
            foreach (DataRow row in dt.Rows)
            {
                String maKHGridView = row["MAKH"].ToString();
                if (maKHGridView.Trim() == maKH.Trim())
                {
                    return true;
                }
            }
            return false;
        }
        private void btn_luu_Click(object sender, EventArgs e)
        {
            if (!CheckValidate(txt_makh, "Mã khách hàng không được để trống ")) return;
            if (!CheckValidate(txt_tenkh, "Tên khách hàng không được để trống ")) return;
            if (!CheckValidate(txt_sodt, "Số điện thoại không được để trống ")) return;
            if (!CheckValidate(txt_email, "Email không được để trống ")) return;
            if (!CheckValidate(txt_diachi, "Địa chỉ không được để trống ")) return;
            if (!CheckValidate(txt_gioitinh, "Giới tính không được để trống ")) return;
            if (txt_makh.Text.Trim().Length > 10)
            {
                MessageBox.Show("Mã khách hàng không được lớn hơn 10 ký tự ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txt_makh.Text.Contains(" "))
            {
                MessageBox.Show("Mã khách hàng không được để khoảng trắng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (CheckExistMaKH(txt_makh.Text) && flag == "add")
            {
                MessageBox.Show("Mã khách hàng đã tồn tại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (flag == "add")
            {
                String strlenh = "tao_KhachHang";
                OracleCommand oracleCommand = new OracleCommand(strlenh, Program.conn);
                oracleCommand.CommandType = CommandType.StoredProcedure;
                oracleCommand.CommandTimeout = 100;

                oracleCommand.Parameters.Add(new OracleParameter("MaKH", txt_makh.Text.ToString().Trim()));
                oracleCommand.Parameters.Add(new OracleParameter("Tenkh", txt_tenkh.Text.ToString().Trim()));
                oracleCommand.Parameters.Add(new OracleParameter("SoDT", txt_sodt.Text.ToString().Trim()));
                oracleCommand.Parameters.Add(new OracleParameter("Email", txt_email.Text.ToString().Trim()));
                oracleCommand.Parameters.Add(new OracleParameter("DiaChi1", txt_diachi.Text.ToString().Trim()));
                oracleCommand.Parameters.Add(new OracleParameter("MaQH", cbb_quan.SelectedValue.ToString().Trim()));
                oracleCommand.Parameters.Add(new OracleParameter("NgaySinh", txt_ngaysinh.Text.ToString().Trim()));
                oracleCommand.Parameters.Add(new OracleParameter("GioiTinh", txt_gioitinh.Text.ToString().Trim()));
                oracleCommand.Parameters.Add(new OracleParameter("GhiChu", txt_ghichu.Text.ToString().Trim()));
                oracleCommand.Parameters.Add(new OracleParameter("DiemTichLuy", txt_diem.Text.ToString().Trim()));

                Program.ExecOracleCommand(oracleCommand);
            }
            HienThiDuLieuKhachHang();
            btn_tao.Enabled = true;
            btn_luu.Enabled = false;
        }
        private void HienThiDuLieu_cbb_quan()
        {
            String strLenh = "SELECT MAQH, TENQH FROM QUANHUYEN ";
            DataTable dt=Program.ExecOracleDataTable(strLenh);
            BindingSource dbs = new BindingSource();
            dbs.DataSource = dt;
            cbb_quan.DataSource = dbs;
            cbb_quan.DisplayMember = "TENQH";
            cbb_quan.ValueMember = "MAQH";
        }
        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbb_quan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

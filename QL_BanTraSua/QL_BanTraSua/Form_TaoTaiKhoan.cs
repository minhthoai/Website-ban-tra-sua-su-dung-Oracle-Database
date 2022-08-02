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
    public partial class Form_TaoTaiKhoan : Form
    {
        DataTable dt =new DataTable();
        OracleConnection conn_publisher = new OracleConnection();
        string flag = "";
        public Form_TaoTaiKhoan()
        {
            InitializeComponent();
            txt_Ho.Enabled = txt_Ten.Enabled = txt_ngaysinh.Enabled = txt_gioitinh.Enabled = txt_Taikhoan.Enabled = txt_Matkhau.Enabled = cbb_nhomtk.Enabled = txtDiachi.Enabled = cbb_khuvuc.Enabled = txt_SDT.Enabled = txt_Email.Enabled = txt_trangthai.Enabled =txt_ghichu.Enabled= false;
            btn_Luu.Enabled = false;
        }

        private void Form_TaiKhoan_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            HienThiDuLieu();
            HienThiDuLieu_cbb_nhomTK();
            HienThiDuLieu_cbb_quan();
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void HienThiDuLieu()
        {
            String strLenh = "SELECT TAIKHOAN, MATKHAU, MANHOM, HODEM,TENTV, NGAYSINH, GIOITINH, SODT, EMAIL, DIACHI,MAQH,TRANGTHAI, GHICHU FROM TAIKHOANTV ";
            dt = Program.ExecOracleDataTable(strLenh);
            dgv_tttaikhoan.DataSource = dt;
            dgv_tttaikhoan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_tttaikhoan.Columns[0].HeaderText = "Tài khoản";
            dgv_tttaikhoan.Columns[1].HeaderText = "Mật khẩu";
            dgv_tttaikhoan.Columns[2].HeaderText = "Mã nhóm";
            dgv_tttaikhoan.Columns[3].HeaderText = "Họ";
            dgv_tttaikhoan.Columns[4].HeaderText = "Tên";
            dgv_tttaikhoan.Columns[5].HeaderText = "Ngày sinh";
            dgv_tttaikhoan.Columns[6].HeaderText = "Giới tính";
            dgv_tttaikhoan.Columns[7].HeaderText = "Số điện thoại";
            dgv_tttaikhoan.Columns[8].HeaderText = "Email";
            dgv_tttaikhoan.Columns[9].HeaderText = "Địa chỉ";
            dgv_tttaikhoan.Columns[10].HeaderText = "Mã quận huyện";
            dgv_tttaikhoan.Columns[11].HeaderText = "Trạng thái";
            dgv_tttaikhoan.Columns[12].HeaderText = "Ghi chú";
            conn_publisher.Close();
        }
        private void HienThiDuLieu_cbb_nhomTK()
        {
            String strLenh = "SELECT MANHOM, TENNHOM FROM NHOMTK ";
            DataTable dt = Program.ExecOracleDataTable(strLenh);
            BindingSource dbs = new BindingSource();
            dbs.DataSource = dt;
            cbb_nhomtk.DataSource = dbs;
            cbb_nhomtk.DisplayMember = "TENNHOM";
            cbb_nhomtk.ValueMember = "MANHOM";
        }
        private void HienThiDuLieu_cbb_quan()
        {
            String strLenh = "SELECT MAQH, TENQH FROM QUANHUYEN ";
            DataTable dt = Program.ExecOracleDataTable(strLenh);
            BindingSource dbs = new BindingSource();
            dbs.DataSource = dt;
            cbb_khuvuc.DataSource = dbs;
            cbb_khuvuc.DisplayMember = "TENQH";
            cbb_khuvuc.ValueMember = "MAQH";
        }

        private void btn_Tao_Click(object sender, EventArgs e)
        {
            flag = "add";
            txt_Ho.Enabled = txt_Ten.Enabled = txt_ngaysinh.Enabled = txt_gioitinh.Enabled = txt_Taikhoan.Enabled = txt_Matkhau.Enabled = cbb_nhomtk.Enabled = txtDiachi.Enabled = cbb_khuvuc.Enabled = txt_SDT.Enabled = txt_Email.Enabled = txt_trangthai.Enabled =txt_ghichu.Enabled= true;
            txt_Taikhoan.Text=dt.Rows[0]["TAIKHOAN"].ToString().Trim();

            btn_Luu.Enabled = true;
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

        private bool CheckExistTaiKhoan(String taiKhoan)
        {
            foreach (DataRow row in dt.Rows)
            {
                String taiKhoanGridView = row["TAIKHOAN"].ToString();
                if (taiKhoanGridView.Trim() == taiKhoan.Trim())
                {
                    return true;
                }
            }
            return false;
        }
        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (!CheckValidate(txt_Taikhoan, "Tài khoản không được để trống ")) return;
            if (!CheckValidate(txt_Matkhau, "Mật khẩu không được để trống ")) return;
            if (!CheckValidate(txt_Ho, "Họ không được để trống ")) return;
            if (!CheckValidate(txt_Ten, "Tên không được để trống ")) return;
            if (!CheckValidate(txt_ngaysinh, "Ngày sinh không được để trống ")) return;
            if (!CheckValidate(txtDiachi, "Địa chỉ không được để trống ")) return;
            if (!CheckValidate(txt_Email, "Email không được để trống ")) return;
            if (!CheckValidate(txt_SDT, "Số điện thoại không được để trống ")) return;
            if (txt_Taikhoan.Text.Trim().Length > 20)
            {
                MessageBox.Show("Tài khoản không được lớn hơn 20 ký tự ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txt_Taikhoan.Text.Contains(" "))
            {
                MessageBox.Show("Tài khoản không được để khoảng trắng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (CheckExistTaiKhoan(txt_Taikhoan.Text) && flag == "add")
            {
                MessageBox.Show("Tài khoản đã tồn tại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (flag == "add")
            {
                String strlenh = "tao_taikhoanTV";
                OracleCommand oracleCommand = new OracleCommand(strlenh, Program.conn);
                oracleCommand.CommandType = CommandType.StoredProcedure;
                oracleCommand.CommandTimeout = 100;

                oracleCommand.Parameters.Add(new OracleParameter("TaiKhoan", txt_Taikhoan.Text.ToString().Trim()));
                oracleCommand.Parameters.Add(new OracleParameter("MatKhau", txt_Matkhau.Text.ToString().Trim()));
                oracleCommand.Parameters.Add(new OracleParameter("MaNhom", cbb_nhomtk.SelectedValue.ToString().Trim()));
                oracleCommand.Parameters.Add(new OracleParameter("HoDem", txt_Ho.Text.ToString().Trim()));
                oracleCommand.Parameters.Add(new OracleParameter("TenTV", txt_Ten.Text.ToString().Trim()));
                oracleCommand.Parameters.Add(new OracleParameter("NgaySinh", txt_ngaysinh.Text.ToString().Trim()));
                oracleCommand.Parameters.Add(new OracleParameter("GioiTinh", txt_gioitinh.Text.ToString().Trim()));
                oracleCommand.Parameters.Add(new OracleParameter("SoDT", txt_SDT.Text.ToString().Trim()));
                oracleCommand.Parameters.Add(new OracleParameter("Email", txt_Email.Text.ToString().Trim()));
                oracleCommand.Parameters.Add(new OracleParameter("DiaChi", txtDiachi.Text.ToString().Trim()));
                oracleCommand.Parameters.Add(new OracleParameter("MaQH", cbb_khuvuc.SelectedValue.ToString().Trim()));
                oracleCommand.Parameters.Add(new OracleParameter("TrangThai", txt_trangthai.Text.ToString().Trim()));
                oracleCommand.Parameters.Add(new OracleParameter("GhiChu", txt_ghichu.Text.ToString().Trim()));

                Program.ExecOracleCommand(oracleCommand);
            }
            HienThiDuLieu();
            btn_Tao.Enabled = true;
            btn_Luu.Enabled = false;
        }
    }
}

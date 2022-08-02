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
    public partial class Form_SuaTaiKhoan : Form
    {
        OracleConnection conn_publisher = new OracleConnection();
        DataTable dt = new DataTable();
        string flag = "";
        public Form_SuaTaiKhoan()
        {
            InitializeComponent();
            txt_Ho.Enabled = txt_Ten.Enabled = txt_ngaysinh.Enabled = txt_gioitinh.Enabled = txt_TaiKhoan.Enabled = txt_MatKhau.Enabled = cbb_nhomtk.Enabled = txt_DiaChi.Enabled = cbb_khuvuc.Enabled = txtSoDienThoai.Enabled = txt_Email.Enabled = txt_tinhtrang.Enabled = txt_ghichu.Enabled = false;

        }

        private void Form_SuaTaiKhoan_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            HienThiDuLieuTaiKhoan();
            HienThiDuLieu_cbb_nhomTK();
            HienThiDuLieu_cbb_quan();
        }
        private void HienThiDuLieuTaiKhoan()
        {
            String strLenh = "SELECT TAIKHOAN, MATKHAU, MANHOM ,HODEM, TENTV, NGAYSINH, GIOITINH, SODT, EMAIL, DIACHI,MAQH,TRANGTHAI, GHICHU FROM TAIKHOANTV ";
            dt = Program.ExecOracleDataTable(strLenh);
            dgv_SuaTaiKhoan.DataSource = dt;
            dgv_SuaTaiKhoan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_SuaTaiKhoan.Columns[0].HeaderText = "Tài khoản";
            dgv_SuaTaiKhoan.Columns[1].HeaderText = "Mật khẩu";
            dgv_SuaTaiKhoan.Columns[2].HeaderText = "Mã nhóm";
            dgv_SuaTaiKhoan.Columns[3].HeaderText = "Họ đệm";
            dgv_SuaTaiKhoan.Columns[4].HeaderText = "Tên thành viên";
            dgv_SuaTaiKhoan.Columns[5].HeaderText = "Ngày sinh";
            dgv_SuaTaiKhoan.Columns[6].HeaderText = "Giới tính";
            dgv_SuaTaiKhoan.Columns[7].HeaderText = "Số điện thoại";
            dgv_SuaTaiKhoan.Columns[8].HeaderText = "Email";
            dgv_SuaTaiKhoan.Columns[9].HeaderText = "Địa chỉ";
            dgv_SuaTaiKhoan.Columns[10].HeaderText = "Mã quận huyện";
            dgv_SuaTaiKhoan.Columns[11].HeaderText = "Trạng thái";
            dgv_SuaTaiKhoan.Columns[12].HeaderText = "Ghi chú";
            conn_publisher.Close();
        }

        private void dgv_SuaTaiKhoan_SelectionChanged(object sender, EventArgs e)
        {
            int index = dgv_SuaTaiKhoan.CurrentCell.RowIndex;
            DataTable dt = (DataTable)dgv_SuaTaiKhoan.DataSource;
            if (dt.Rows.Count > 0)
            {
                txt_TaiKhoan.Text = dgv_SuaTaiKhoan.Rows[index].Cells[0].Value.ToString().Trim();
                txt_MatKhau.Text = dgv_SuaTaiKhoan.Rows[index].Cells[1].Value.ToString().Trim();
                cbb_nhomtk.SelectedValue = dgv_SuaTaiKhoan.Rows[index].Cells[2].Value.ToString().Trim();
                txt_Ho.Text = dgv_SuaTaiKhoan.Rows[index].Cells[3].Value.ToString().Trim();
                txt_Ten.Text = dgv_SuaTaiKhoan.Rows[index].Cells[4].Value.ToString().Trim();
                txt_ngaysinh.Text = dgv_SuaTaiKhoan.Rows[index].Cells[5].Value.ToString().Trim();
                txt_gioitinh.Text = dgv_SuaTaiKhoan.Rows[index].Cells[6].Value.ToString().Trim();
                txtSoDienThoai.Text = dgv_SuaTaiKhoan.Rows[index].Cells[7].Value.ToString().Trim();
                txt_Email.Text = dgv_SuaTaiKhoan.Rows[index].Cells[8].Value.ToString().Trim();
                txt_DiaChi.Text = dgv_SuaTaiKhoan.Rows[index].Cells[9].Value.ToString().Trim();
                cbb_khuvuc.SelectedValue = dgv_SuaTaiKhoan.Rows[index].Cells[10].Value.ToString().Trim();
                txt_tinhtrang.Text = dgv_SuaTaiKhoan.Rows[index].Cells[11].Value.ToString().Trim();
                txt_ghichu.Text = dgv_SuaTaiKhoan.Rows[index].Cells[12].Value.ToString().Trim();
            }
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
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
        private void btn_sua_Click(object sender, EventArgs e)
        {
            flag = "edit";
            txt_Ho.Enabled = txt_Ten.Enabled = txt_ngaysinh.Enabled = txt_gioitinh.Enabled = txt_TaiKhoan.Enabled = txt_MatKhau.Enabled = cbb_nhomtk.Enabled = txt_DiaChi.Enabled = cbb_khuvuc.Enabled = txtSoDienThoai.Enabled = txt_Email.Enabled = txt_tinhtrang.Enabled = txt_ghichu.Enabled = true;
            btn_luu.Enabled = true;
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            if (!CheckValidate(txt_TaiKhoan, "Tài khoản không được để trống ")) return;
            if (!CheckValidate(txt_MatKhau, "Mật khẩu không được để trống ")) return;
            if (!CheckValidate(txt_Ho, "Họ không được để trống ")) return;
            if (!CheckValidate(txt_Ten, "Tên không được để trống ")) return;
            if (!CheckValidate(txt_ngaysinh, "Ngày sinh không được để trống ")) return;
            if (!CheckValidate(txt_DiaChi, "Địa chỉ không được để trống ")) return;
            if (!CheckValidate(txt_Email, "Email không được để trống ")) return;
            if (!CheckValidate(txtSoDienThoai, "Số điện thoại không được để trống ")) return;
            if (txt_TaiKhoan.Text.Trim().Length > 20)
            {
                MessageBox.Show("Tài khoản không được lớn hơn 20 ký tự ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txt_TaiKhoan.Text.Contains(" "))
            {
                MessageBox.Show("Tài khoản không được để khoảng trắng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (CheckExistTaiKhoan(txt_TaiKhoan.Text) && flag == "add")
            {
                MessageBox.Show("Tài khoản đã tồn tại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (flag == "edit")
            {
                String strlenh = "capnhat_TaiKhoanTV";
                OracleCommand oracleCommand = new OracleCommand(strlenh, Program.conn);
                oracleCommand.CommandType = CommandType.StoredProcedure;
                oracleCommand.CommandTimeout = 100;

                oracleCommand.Parameters.Add(new OracleParameter("TaiKhoan", txt_TaiKhoan.Text.ToString().Trim()));
                oracleCommand.Parameters.Add(new OracleParameter("MatKhau", txt_MatKhau.Text.ToString().Trim()));
                oracleCommand.Parameters.Add(new OracleParameter("MaNhom", cbb_nhomtk.SelectedValue.ToString().Trim()));
                oracleCommand.Parameters.Add(new OracleParameter("HoDem", txt_Ho.Text.ToString().Trim()));
                oracleCommand.Parameters.Add(new OracleParameter("TenTV", txt_Ten.Text.ToString().Trim()));
                oracleCommand.Parameters.Add(new OracleParameter("NgaySinh", txt_ngaysinh.Text.ToString().Trim()));
                oracleCommand.Parameters.Add(new OracleParameter("GioiTinh", txt_gioitinh.Text.ToString().Trim()));
                oracleCommand.Parameters.Add(new OracleParameter("SoDT", txtSoDienThoai.Text.ToString().Trim()));
                oracleCommand.Parameters.Add(new OracleParameter("Email", txt_Email.Text.ToString().Trim()));
                oracleCommand.Parameters.Add(new OracleParameter("DiaChi", txt_DiaChi.Text.ToString().Trim()));
                oracleCommand.Parameters.Add(new OracleParameter("MaQH", cbb_khuvuc.SelectedValue.ToString().Trim()));
                oracleCommand.Parameters.Add(new OracleParameter("TrangThai", txt_tinhtrang.Text.ToString().Trim()));
                oracleCommand.Parameters.Add(new OracleParameter("GhiChu", txt_ghichu.Text.ToString().Trim()));

                Program.ExecOracleCommand(oracleCommand);
            }
            HienThiDuLieuTaiKhoan();
            btn_sua.Enabled = true;
            btn_luu.Enabled = false;
        }
    }
}

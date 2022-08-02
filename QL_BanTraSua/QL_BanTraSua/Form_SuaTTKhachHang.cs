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
    public partial class Form_SuaTTKhachHang : Form
    {
        OracleConnection conn_publisher = new OracleConnection();
        DataTable dt = new DataTable();
        string flag = "";
        public Form_SuaTTKhachHang()
        {
            InitializeComponent();
            txt_makh.Enabled = txt_tenkh.Enabled = txt_sodt.Enabled = txt_email.Enabled = txt_diachi.Enabled = cbb_quan.Enabled = txt_ngaysinh.Enabled = txt_gioitinh.Enabled = txt_ghichu.Enabled = txt_diem.Enabled = false;
            btn_luu.Enabled = false;
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_SuaTTKhachHang_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            HienThiDuLieuKhachHang();
            HienThiDuLieu_cbb_quan();
        }
        private void HienThiDuLieuKhachHang()
        {
            String strLenh = "SELECT MAKH, TENKH, SODT, EMAIL, DIACHI ,MAQH, NGAYSINH, GIOITINH, GHICHU, DIEMTICHLUY FROM KHACHHANG ";
            dt = Program.ExecOracleDataTable(strLenh);
            dgv_suattkh.DataSource = dt;
            dgv_suattkh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_suattkh.Columns[0].HeaderText = "Mã khách hàng";
            dgv_suattkh.Columns[1].HeaderText = "Tên khách hàng";
            dgv_suattkh.Columns[2].HeaderText = "Số điện thoại";
            dgv_suattkh.Columns[3].HeaderText = "Email";
            dgv_suattkh.Columns[4].HeaderText = "Địa chỉ";
            dgv_suattkh.Columns[5].HeaderText = "Mã quận huyện";
            dgv_suattkh.Columns[6].HeaderText = "Ngày sinh";
            dgv_suattkh.Columns[7].HeaderText = "Giới tính";
            dgv_suattkh.Columns[8].HeaderText = "Ghi chú";
            dgv_suattkh.Columns[9].HeaderText = "Điểm tích lũy";
            conn_publisher.Close();
        }
        private void HienThiDuLieu_cbb_quan()
        {
            String strLenh = "SELECT MAQH, TENQH FROM QUANHUYEN ";
            DataTable dt = Program.ExecOracleDataTable(strLenh);
            BindingSource dbs = new BindingSource();
            dbs.DataSource = dt;
            cbb_quan.DataSource = dbs;
            cbb_quan.DisplayMember = "TENQH";
            cbb_quan.ValueMember = "TENQH";
        }

        private void dgv_suattkh_SelectionChanged(object sender, EventArgs e)
        {
            int index = dgv_suattkh.CurrentCell.RowIndex;
            DataTable td = (DataTable)dgv_suattkh.DataSource;
            if (dt.Rows.Count > 0)
            {
                txt_makh.Text = dgv_suattkh.Rows[index].Cells[0].Value.ToString().Trim();
                txt_tenkh.Text = dgv_suattkh.Rows[index].Cells[1].Value.ToString().Trim();
                txt_sodt.Text = dgv_suattkh.Rows[index].Cells[2].Value.ToString().Trim();
                txt_email.Text = dgv_suattkh.Rows[index].Cells[3].Value.ToString().Trim();
                txt_diachi.Text = dgv_suattkh.Rows[index].Cells[4].Value.ToString().Trim();
                cbb_quan.Text = dgv_suattkh.Rows[index].Cells[5].Value.ToString().Trim();
                txt_ngaysinh.Text = dgv_suattkh.Rows[index].Cells[6].Value.ToString().Trim();
                txt_gioitinh.Text = dgv_suattkh.Rows[index].Cells[7].Value.ToString().Trim();
                txt_ghichu.Text = dgv_suattkh.Rows[index].Cells[8].Value.ToString().Trim();
                txt_diem.Text = dgv_suattkh.Rows[index].Cells[9].Value.ToString().Trim();
            }
        }

        private void btn_suu_Click(object sender, EventArgs e)
        {
            flag = "edit";
            txt_makh.Enabled = txt_tenkh.Enabled = txt_sodt.Enabled = txt_email.Enabled = txt_diachi.Enabled = cbb_quan.Enabled = txt_ngaysinh.Enabled = txt_gioitinh.Enabled = txt_ghichu.Enabled = txt_diem.Enabled = true;
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
            if (flag == "edit")
            {
                String strlenh = "capnhat_khachhang";
                OracleCommand oracleCommand = new OracleCommand(strlenh, Program.conn);
                oracleCommand.CommandType = CommandType.StoredProcedure;
                oracleCommand.CommandTimeout = 100;

                oracleCommand.Parameters.Add(new OracleParameter("makh1", txt_makh.Text.ToString().Trim()));
                oracleCommand.Parameters.Add(new OracleParameter("tenkh1", txt_tenkh.Text.ToString().Trim()));
                oracleCommand.Parameters.Add(new OracleParameter("sodt1", txt_sodt.Text.ToString().Trim()));
                oracleCommand.Parameters.Add(new OracleParameter("email1", txt_email.Text.ToString().Trim()));
                oracleCommand.Parameters.Add(new OracleParameter("diachi1", txt_diachi.Text.ToString().Trim()));
                oracleCommand.Parameters.Add(new OracleParameter("maqh1", cbb_quan.SelectedValue.ToString().Trim()));
                oracleCommand.Parameters.Add(new OracleParameter("ngaysinh1", txt_ngaysinh.Text.ToString().Trim()));
                oracleCommand.Parameters.Add(new OracleParameter("gioitinh1", txt_gioitinh.Text.ToString().Trim()));
                oracleCommand.Parameters.Add(new OracleParameter("ghichu1", txt_ghichu.Text.ToString().Trim()));
                oracleCommand.Parameters.Add(new OracleParameter("diemtichluy1", txt_diem.Text.ToString().Trim()));

                Program.ExecOracleCommand(oracleCommand);
            }
            HienThiDuLieuKhachHang();
            btn_suu.Enabled = true;
            btn_luu.Enabled = false;
        }

        private void dtp_ngaysinh_ValueChanged(object sender, EventArgs e)
        {
            DateTime.Now.ToString("dd-MM-yyyy");
        }
    }
}

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
    public partial class Form_SuaSanPham : Form
    {
        OracleConnection conn_publisher = new OracleConnection();
        DataTable dt = new DataTable();
        string flag = "";
        public Form_SuaSanPham()
        {
            InitializeComponent();
            txt_masp.Enabled = txt_tensp.Enabled = txt_ngaydang.Enabled = cbb_loaisp.Enabled = txt_loaihang.Enabled = txt_daduyet.Enabled = txt_taikhoan.Enabled = txt_noidung.Enabled = txt_giaban.Enabled = txt_giamgia.Enabled = false;
            btn_luu.Enabled = false;
        }

        private void Form_SuaSanPham_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            HienThiDuLieuSanPham();
            HienThiDuLieu_cbb_maloai();
        }
        private void HienThiDuLieuSanPham()
        {
            String strLenh = "SELECT MASP, TENSP, MALOAI, NDTOMTAT, NGAYDANG, LOAIHANG, TAIKHOAN, DADUYET, GIABAN, GIAMGIA FROM SANPHAM ";
            dt = Program.ExecOracleDataTable(strLenh);
            dgv_Sanpham.DataSource = dt;
            dgv_Sanpham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_Sanpham.Columns[0].HeaderText = "Mã sẩn phẩm";
            dgv_Sanpham.Columns[1].HeaderText = "Tên sản phẩm";
            dgv_Sanpham.Columns[2].HeaderText = "Mã loại";
            dgv_Sanpham.Columns[3].HeaderText = "Nội dung tóm tắt";
            dgv_Sanpham.Columns[4].HeaderText = "Ngày đăng";
            dgv_Sanpham.Columns[5].HeaderText = "Loại hàng";
            dgv_Sanpham.Columns[6].HeaderText = "Tài khoản";
            dgv_Sanpham.Columns[7].HeaderText = "Đã duyệt";
            dgv_Sanpham.Columns[8].HeaderText = "Giá bán";
            dgv_Sanpham.Columns[9].HeaderText = "Giảm giá";
            conn_publisher.Close();
        }
        private void HienThiDuLieu_cbb_maloai()
        {
            String strLenh = "SELECT MALOAI, LOAISP FROM LOAISP ";
            DataTable dt = Program.ExecOracleDataTable(strLenh);
            BindingSource dbs = new BindingSource();
            dbs.DataSource = dt;
            cbb_loaisp.DataSource = dbs;
            cbb_loaisp.DisplayMember = "LOAISP";
            cbb_loaisp.ValueMember = "MALOAI";
        }
        private void btn_sua_Click(object sender, EventArgs e)
        {
            txt_masp.Enabled = txt_tensp.Enabled = txt_ngaydang.Enabled = cbb_loaisp.Enabled = txt_loaihang.Enabled = txt_daduyet.Enabled = txt_taikhoan.Enabled = txt_noidung.Enabled = txt_giaban.Enabled = txt_giamgia.Enabled = true;

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

        private bool CheckExistMasp(String maSP)
        {
            foreach (DataRow row in dt.Rows)
            {
                String taiKhoanGridView = row["MASP"].ToString();
                if (taiKhoanGridView.Trim() == maSP.Trim())
                {
                    return true;
                }
            }
            return false;
        }
        private void btn_luu_Click(object sender, EventArgs e)
        {
            if (!CheckValidate(txt_masp, "Mã sản phẩm không được để trống ")) return;
            if (!CheckValidate(txt_tensp, "Tên sản phẩm không được để trống ")) return;
            if (!CheckValidate(txt_ngaydang, "Ngày đăng không được để trống ")) return;
            if (!CheckValidate(txt_taikhoan, "Tài khoản không được để trống ")) return;
            if (!CheckValidate(txt_giaban, "Giá bán không được để trống ")) return;
            if (!CheckValidate(txt_giamgia, "Giảm giá không được để trống ")) return;
            if (!CheckValidate(txt_loaihang, "Loại hàng không được để trống ")) return;
            if (!CheckValidate(txt_daduyet, "Đã duyệt không được để trống ")) return;
            if (!CheckValidate(txt_noidung, "Nội dung không được để trống ")) return;
            if (txt_masp.Text.Trim().Length > 20)
            {
                MessageBox.Show("Mã sản phẩm không được lớn hơn 20 ký tự ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txt_masp.Text.Contains(" "))
            {
                MessageBox.Show("TMã sản phẩm không được để khoảng trắng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (CheckExistMasp(txt_masp.Text) && flag == "add")
            {
                MessageBox.Show("Mã sản phẩm đã tồn tại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (flag == "add")
            {
                String strlenh = "capnhat_sanpham";
                OracleCommand oracleCommand = new OracleCommand(strlenh, Program.conn);
                oracleCommand.CommandType = CommandType.StoredProcedure;
                oracleCommand.CommandTimeout = 100;

                oracleCommand.Parameters.Add(new OracleParameter("masp1", txt_masp.Text.ToString().Trim()));
                oracleCommand.Parameters.Add(new OracleParameter("tensp1", txt_tensp.Text.ToString().Trim()));
                oracleCommand.Parameters.Add(new OracleParameter("maloai1", cbb_loaisp.SelectedValue.ToString().Trim()));
                oracleCommand.Parameters.Add(new OracleParameter("ndtomtat1", txt_noidung.Text.ToString().Trim()));
                oracleCommand.Parameters.Add(new OracleParameter("ngaydang1", txt_ngaydang.Text.ToString().Trim()));
                oracleCommand.Parameters.Add(new OracleParameter("loaihang1", txt_loaihang.Text.ToString().Trim()));
                oracleCommand.Parameters.Add(new OracleParameter("taikhoan1", txt_taikhoan.Text.ToString().Trim()));
                oracleCommand.Parameters.Add(new OracleParameter("daduyet1", txt_daduyet.Text.ToString().Trim()));
                oracleCommand.Parameters.Add(new OracleParameter("giaban1", txt_giaban.Text.ToString().Trim()));
                oracleCommand.Parameters.Add(new OracleParameter("giamgia1", txt_giamgia.Text.ToString().Trim()));

                Program.ExecOracleCommand(oracleCommand);
            }
            HienThiDuLieuSanPham();
            btn_sua.Enabled = true;
            btn_luu.Enabled = false;
        }

        private void dgv_Sanpham_SelectionChanged(object sender, EventArgs e)
        {
            int index = dgv_Sanpham.CurrentCell.RowIndex;
            DataTable dt = (DataTable)dgv_Sanpham.DataSource;
            if (dt.Rows.Count > 0)
            {
                txt_masp.Text = dgv_Sanpham.Rows[index].Cells[0].Value.ToString().Trim();
                txt_tensp.Text = dgv_Sanpham.Rows[index].Cells[1].Value.ToString().Trim();
                cbb_loaisp.SelectedValue = dgv_Sanpham.Rows[index].Cells[2].Value.ToString().Trim();
                txt_noidung.Text = dgv_Sanpham.Rows[index].Cells[3].Value.ToString().Trim();
                txt_ngaydang.Text = dgv_Sanpham.Rows[index].Cells[4].Value.ToString().Trim();
                txt_loaihang.Text = dgv_Sanpham.Rows[index].Cells[5].Value.ToString().Trim();
                txt_taikhoan.Text = dgv_Sanpham.Rows[index].Cells[6].Value.ToString().Trim();
                txt_daduyet.Text = dgv_Sanpham.Rows[index].Cells[7].Value.ToString().Trim();
                txt_giaban.Text = dgv_Sanpham.Rows[index].Cells[8].Value.ToString().Trim();
                txt_giamgia.Text = dgv_Sanpham.Rows[index].Cells[9].Value.ToString().Trim();
            }
        }
    }
}

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
    public partial class Form_TaoDonHang : Form
    {
        OracleConnection conn_publisher = new OracleConnection();
        DataTable dt = new DataTable();
        string flag = "";
        public static string maKH = "",tenKH="",soDT="", gioiTinh="",eMail="",diaChi="";
        string maHD = "", maSP = "";
        int soLuong = 0;
        public Form_TaoDonHang()
        {
            InitializeComponent();
            HienThiDuLieu_Cbx_Nhanvien();
            HienThiDuLieuDonHang();
            HienThiDuLieuCTDH();
            HienThiDuLieuKhachhang();
            this.WindowState = FormWindowState.Maximized;
            cbb_tentk.Enabled = txt_madh.Enabled = txt_ngaydat.Enabled = txt_ngaygiao.Enabled = txt_tenkh.Enabled = txt_diachigiao.Enabled = txt_makh.Enabled = txt_sdt.Enabled = txt_tenkhct.Enabled = txt_giotinh.Enabled = txt_email.Enabled = txt_diachi.Enabled = txt_ghichu.Enabled = false;
            btn_taodonhang.Enabled = true;
            btn_luu.Enabled =btn_chonkh.Enabled= false;
        }

        private void dgv_donhang_SelectionChanged(object sender, EventArgs e)
        {
            int index = dgv_donhang.CurrentCell.RowIndex;
            DataTable dt = (DataTable)dgv_donhang.DataSource;
            if (dt.Rows.Count > 0)
            {
                txt_madh.Text = dgv_donhang.Rows[index].Cells[0].Value.ToString().Trim();
                txt_makh.Text = dgv_donhang.Rows[index].Cells[1].Value.ToString().Trim();
                cbb_tentk.Text = dgv_donhang.Rows[index].Cells[2].Value.ToString().Trim();
                txt_ngaydat.Text = dgv_donhang.Rows[index].Cells[3].Value.ToString().Trim();
                txt_ngaygiao.Text = dgv_donhang.Rows[index].Cells[4].Value.ToString().Trim();
                txt_diachigiao.Text = dgv_donhang.Rows[index].Cells[5].Value.ToString().Trim();

            }
            HienThiDuLieuCTDH();
        }

        private void dgcvchitietdonhang_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void btn_chọnsanpham_Click(object sender, EventArgs e)
        {
            Form_ChonSanPham csp = new Form_ChonSanPham();
            csp.ShowDialog();
          

        }

        private void dgv_khachhang_SelectionChanged(object sender, EventArgs e)
        {
            int index = dgv_khachhang.CurrentCell.RowIndex;
            DataTable dt = (DataTable)dgv_khachhang.DataSource;
            if (dt.Rows.Count > 0)
            {
                txt_makh.Text = dgv_khachhang.Rows[index].Cells[0].Value.ToString().Trim();
                txt_tenkh.Text = dgv_khachhang.Rows[index].Cells[1].Value.ToString().Trim();
                txt_tenkhct.Text = dgv_khachhang.Rows[index].Cells[1].Value.ToString().Trim();
                txt_sdt.Text = dgv_khachhang.Rows[index].Cells[2].Value.ToString().Trim();
                txt_email.Text = dgv_khachhang.Rows[index].Cells[3].Value.ToString().Trim();
                txt_diachi.Text = dgv_khachhang.Rows[index].Cells[4].Value.ToString().Trim();
                txt_giotinh.Text = dgv_khachhang.Rows[index].Cells[5].Value.ToString().Trim();
            }
            HienThiDuLieuCTDH();
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_taodonhang_Click(object sender, EventArgs e)
        {
            flag = "add";
            cbb_tentk.Enabled = txt_madh.Enabled = txt_ngaydat.Enabled = txt_ngaygiao.Enabled = txt_tenkh.Enabled = txt_diachigiao.Enabled = txt_makh.Enabled = txt_sdt.Enabled = txt_tenkhct.Enabled = txt_giotinh.Enabled = txt_email.Enabled = txt_diachi.Enabled = txt_ghichu.Enabled = true;
            cbb_tentk.Text = txt_madh.Text = txt_ngaydat.Text = txt_ngaygiao.Text = txt_tenkh.Text = txt_diachigiao.Text = txt_makh.Text = txt_sdt.Text = txt_tenkhct.Text = txt_giotinh.Text = txt_email.Text = txt_diachi.Text = txt_ghichu.Text = "";

            btn_luu.Enabled =btn_chonkh.Enabled= true;
        }
        private bool CheckValidate(TextBox tb, string str)
        {
            if (tb.Text.Trim().Equals(""))
            {
                MessageBox.Show(str, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb.Focus();
                return false;
            }
            return true;
        }

        private bool CheckExistSoHD(string maDH)
        {
            foreach (DataRow row in dt.Rows)
            {
                String maDHGridView = row["MADH"].ToString();
                if (maDHGridView.Trim() == maDH.Trim())
                {
                    return true;
                }
            }
            return false;
        }
        private void btn_luu_Click(object sender, EventArgs e)
        {
            if (!CheckValidate(txt_madh, "Mã hóa đơn không được để trống")) return;
            
            if (txt_madh.Text.Trim().Length > 10)
            {
                MessageBox.Show("Mã đơn hàng không được lớn hơn 10 ký tự ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txt_madh.Text.Contains(" "))
            {
                MessageBox.Show("Mã đơn hàng không được chứa khoảng trắng", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (CheckExistSoHD(txt_madh.Text) && flag == "add")
            {
                MessageBox.Show("Mã đơn hàng đã tồn tại rồi!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                if (flag == "add")
                {
                    //Thêm dữ liệu vào Kho
                    String strLenh = "tao_DonHang";
                    OracleCommand oracleCommand = new OracleCommand(strLenh, Program.conn);
                    oracleCommand.CommandType = CommandType.StoredProcedure;
                    oracleCommand.CommandTimeout = 600;

                    oracleCommand.Parameters.Add(new OracleParameter("MaDH1", txt_madh.Text.ToString().Trim()));
                    oracleCommand.Parameters.Add(new OracleParameter("MaKH1", txt_makh.Text.ToString().Trim()));
                    oracleCommand.Parameters.Add(new OracleParameter("TaiKhoan1", cbb_tentk.SelectedValue.ToString().Trim()));
                    oracleCommand.Parameters.Add(new OracleParameter("NgayDat1", txt_ngaydat.Text.ToString().Trim()));
                    oracleCommand.Parameters.Add(new OracleParameter("NgayGH1", txt_ngaygiao.Text.ToString().Trim()));
                    oracleCommand.Parameters.Add(new OracleParameter("DiaChiGH1", txt_diachigiao.Text.ToString().Trim()));
                    oracleCommand.Parameters.Add(new OracleParameter("GhiChu1", txt_ghichu.Text.ToString().Trim()));

                    Program.ExecOracleCommand(oracleCommand);
                    MessageBox.Show("Thêm thành công!");
                }
                cbb_tentk.Enabled = txt_madh.Enabled = txt_ngaydat.Enabled = txt_ngaygiao.Enabled = txt_tenkh.Enabled = txt_diachigiao.Enabled = txt_makh.Enabled = txt_sdt.Enabled = txt_tenkhct.Enabled = txt_giotinh.Enabled = txt_email.Enabled = txt_diachi.Enabled = txt_ghichu.Enabled = false;
                btn_taodonhang.Enabled = true;
                btn_luu.Enabled = btn_chonkh.Enabled = false;
                HienThiDuLieuDonHang();
            }
            catch (Exception ex)
            {
               
            }
        }

        private void dgv_chitietdonhang_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip rightMenu = new ContextMenuStrip();
                int position_xy_mouse_row = dgv_chitietdonhang.HitTest(e.X, e.Y).RowIndex;

                if (position_xy_mouse_row >= 0)
                {
                    rightMenu.Items.Add("Thêm").Name = "Thêm";
                    rightMenu.Items.Add("Xóa").Name = "Xóa";
                    rightMenu.Items.Add("Sửa").Name = "Sửa";
                }
                rightMenu.Show(dgv_chitietdonhang, new Point(e.X, e.Y));

                //event menu click
                rightMenu.ItemClicked += new ToolStripItemClickedEventHandler(rightMenu_ItemClicked);
            }
        }

        private void Form_TaoDonHang_Load(object sender, EventArgs e)
        {

        }

        public void rightMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Form_ChonSanPham frm = new Form_ChonSanPham();
            if (e.ClickedItem.Name == "Thêm")
            {
                frm.luaChon = "Add";
                frm.maHD = txt_madh.Text.Trim();
                frm.soLuong = 0;
                frm.ShowDialog();
            }
            else if (e.ClickedItem.Name == "Sửa")
            {
                frm.luaChon = "Edit";
                frm.maHD = maHD;
                frm.maSP = maSP;
                frm.soLuong = soLuong;
                frm.ShowDialog();
            }
            else if (e.ClickedItem.Name == "Xóa")
            {
                frm.luaChon = "Delete";
                String strLenh = "sp_DeleteCTHD";
                OracleCommand oracleCommand = new OracleCommand(strLenh, Program.conn);
                oracleCommand.CommandType = CommandType.StoredProcedure;
                oracleCommand.CommandTimeout = 600;

                oracleCommand.Parameters.Add(new OracleParameter("@SoHD", Int32.Parse(txt_madh.Text.Trim())));
                oracleCommand.Parameters.Add(new OracleParameter("@MaSP", maSP));
                Program.ExecOracleCommand(oracleCommand);
                MessageBox.Show("Xóa thành công!");
            }
            HienThiDuLieuCTDH();
        }
        private void HienThiDuLieu_Cbx_Nhanvien()
        {
            string strLenh = "SELECT TAIKHOAN ,HODEM,TENTV FROM TAIKHOANTV";
            DataTable dt = Program.ExecOracleDataTable(strLenh);
            BindingSource bds = new BindingSource();
            bds.DataSource = dt;
            cbb_tentk.DataSource = bds;
            cbb_tentk.DisplayMember ="TENTV";
            cbb_tentk.ValueMember = "TAIKHOAN";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form_ChonKhachHang ckh= new Form_ChonKhachHang();
            ckh.ShowDialog();

            if(maKH.Length>0)
            {
                this.txt_makh.Text = maKH;
                this.txt_tenkh.Text = tenKH;
                this.txt_tenkhct.Text = tenKH;
                this.txt_diachi.Text = diaChi;
                this.txt_diachigiao.Text = diaChi;
                this.txt_giotinh.Text = gioiTinh;
                this.txt_email.Text = eMail;
                this.txt_sdt.Text = soDT;
            }
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
        private void HienThiDuLieuCTDH()
        {
            String strLenh = "SELECT MADH, MASP, SOLUONG,GIABAN, GIAMGIA FROM CTDONHANG  WHERE MADH='" + txt_madh.Text.Trim() + "'";
            dt = Program.ExecOracleDataTable(strLenh);
            dgv_chitietdonhang.DataSource = dt;
            dgv_chitietdonhang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_chitietdonhang.Columns[0].HeaderText = "Mã đơn hàng";
            dgv_chitietdonhang.Columns[1].HeaderText = "Mã sản phẩm";
            dgv_chitietdonhang.Columns[2].HeaderText = "Số lượng";
            dgv_chitietdonhang.Columns[3].HeaderText = "Giá bán";
            dgv_chitietdonhang.Columns[4].HeaderText = "Giảm giá";
            //dgv_chitietdonhang.Columns[5].HeaderText = "Tổng tiền";
            conn_publisher.Close();
        }
        private void HienThiDuLieuKhachhang()
        {
            String strLenh = "SELECT MAKH, TENKH, SODT, EMAIL, DIACHI , GIOITINH FROM KHACHHANG ";
            dt = Program.ExecOracleDataTable(strLenh);
            dgv_khachhang.DataSource = dt;
            dgv_khachhang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_khachhang.Columns[0].HeaderText = "Mã khách hàng";
            dgv_khachhang.Columns[1].HeaderText = "Tên khách hàng";
            dgv_khachhang.Columns[2].HeaderText = "Số điện thoại";
            dgv_khachhang.Columns[3].HeaderText = "Email";
            dgv_khachhang.Columns[4].HeaderText = "Địa chỉ";
            dgv_khachhang.Columns[5].HeaderText = "Giới tính";
            conn_publisher.Close();
        }
    }
}

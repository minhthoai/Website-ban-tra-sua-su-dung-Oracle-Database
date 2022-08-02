using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_BanTraSua
{
    public partial class MainApp : RibbonForm
    {
        public MainApp()
        {
            InitializeComponent();
        }

        private void MainApp_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void rib_Khuvuc_Click(object sender, EventArgs e)
        {
            Form_KhuVuc kv = new Form_KhuVuc();
            kv.MdiParent = this;
            kv.Show();
        }

        private void rib_Account_Click(object sender, EventArgs e)
        {
            Form_ThongTinTaiKhoan tttk= new Form_ThongTinTaiKhoan();
            tttk.MdiParent = this;
            tttk.Show();
        }

        private void rib_NewAccount_Click(object sender, EventArgs e)
        {
            Form_TaoTaiKhoan tk = new Form_TaoTaiKhoan();
            tk.MdiParent = this;
            tk.Show();
        }

        private void rib_EditAccount_Click(object sender, EventArgs e)
        {
            Form_SuaTaiKhoan stk = new Form_SuaTaiKhoan();
            stk.MdiParent = this;
            stk.Show();
        }

        private void rib_SanPham_Click(object sender, EventArgs e)
        {
            Form_SanPham sp = new Form_SanPham();
            sp.MdiParent = this;
            sp.Show();
        }

        private void rib_Khachhang_Click(object sender, EventArgs e)
        {
            Form_KhachHang kh=new Form_KhachHang();
            kh.MdiParent = this;
            kh.Show();
        }

        private void rib_ThemSP_Click(object sender, EventArgs e)
        {
            Form_ThemSanPham tsp=new Form_ThemSanPham();
            tsp.MdiParent = this;
            tsp.Show();
        }

        private void rib_donhang_Click(object sender, EventArgs e)
        {
            Form_TaoDonHang tdh=new Form_TaoDonHang();
            tdh.MdiParent = this;
            tdh.Show();
        }

        private void rib_Sua_Click(object sender, EventArgs e)
        {
            Form_SuaSanPham ssp= new Form_SuaSanPham();
            ssp.MdiParent=this;
            ssp.Show();
        }

        private void rib_ThemKH_Click(object sender, EventArgs e)
        {
            Form_ThemKhachHang tkh = new Form_ThemKhachHang();
            tkh.MdiParent = this;
            tkh.Show();
        }

        private void rib_SuaKH_Click(object sender, EventArgs e)
        {
            Form_SuaTTKhachHang sttkh = new Form_SuaTTKhachHang();
            sttkh.MdiParent = this;
                sttkh.Show();
        }

        private void ribbonTab1_ActiveChanged(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.br_01;
        }

        private void ribbonTab2_ActiveChanged(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.br_02;
        }

        private void ribbonTab5_ActiveChanged(object sender, EventArgs e)
        {
            this.BackgroundImage= Properties.Resources.br_03;
        }

        private void ribbonTab4_ActiveChanged(object sender, EventArgs e)
        {
            this.BackgroundImage=(Properties.Resources.br_05);
        }

        private void ribbonTab3_ActiveChanged(object sender, EventArgs e)
        {
            this.BackgroundImage= (Properties.Resources.br_04);
        }

        private void rib_taodonhang_Click(object sender, EventArgs e)
        {
            Form_TaoDonHang tdh=new Form_TaoDonHang();
            tdh.MdiParent=this;
            tdh.Show();
        }

        private void rib_danhsachdh_Click(object sender, EventArgs e)
        {
            Form_DanhSachDonHang dsdh = new Form_DanhSachDonHang();
            dsdh.MdiParent=this;
            dsdh.Show();
        }

        private void rib_xacnhandh_Click(object sender, EventArgs e)
        {
            Form_XacNhanDonHang xndh=new Form_XacNhanDonHang();
            xndh.MdiParent=this;
            xndh.Show();
        }

        private void rib_thanhtoandh_Click(object sender, EventArgs e)
        {
            Form_DonHangThanhToan dhtt= new Form_DonHangThanhToan();
            dhtt.MdiParent=this;
                dhtt.Show();
        }

        private void rib_dhgiaohang_Click(object sender, EventArgs e)
        {
            Form_DonHangDangGiao dhdg =new Form_DonHangDangGiao();
            dhdg.MdiParent=this;
            dhdg.Show();
        }

        private void rib_nhomtk_Click(object sender, EventArgs e)
        {
            Form_NhomTK ntk= new Form_NhomTK();
            ntk.MdiParent=this;
            ntk.Show();
        }

        private void rib_XoaSP_Click(object sender, EventArgs e)
        {
            Form_XoaSanPham xsp = new Form_XoaSanPham();
            xsp.MdiParent=this;
            xsp.Show();
        }

        private void rib_XoaKH_Click(object sender, EventArgs e)
        {
            Form_XoaKhachHang2 xkh = new Form_XoaKhachHang2();
            xkh.MdiParent = this;
            xkh.Show();
        }

        private void rib_xoatk_Click(object sender, EventArgs e)
        {
            Form_XoaTaiKhoan xtk= new Form_XoaTaiKhoan();
            xtk.MdiParent=this;
            xtk.Show();
        }

        private void rib_HuyDH_Click(object sender, EventArgs e)
        {
            Form_XoaDonHang xdh= new Form_XoaDonHang();
            xdh.MdiParent=this;
            xdh.Show();
        }
    }
}

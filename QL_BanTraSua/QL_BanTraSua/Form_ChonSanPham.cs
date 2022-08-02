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
    public partial class Form_ChonSanPham : Form
    {
        OracleConnection conn_publisher = new OracleConnection();
        DataTable dt = new DataTable();
        public string luaChon = "";
        public string maHD = "", maSP = "";
        public int soLuong = 0;
        public Form_ChonSanPham()
        {
            InitializeComponent();
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_ChonSanPham_Load(object sender, EventArgs e)
        {
            HienThiDuLieu_Cbx_MaSP();
            txt_mahd.Text = maHD;
            if (luaChon == "Edit")
                txt_mahd.Enabled = false;
            txt_mahd.Enabled = false;
            cbb_tensp.Text = maSP;
            txt_soluong.Text = soLuong.ToString();

        }
        private void HienThiDuLieu_Cbx_MaSP()
        {
            string strLenh = "SELECT MASP,TENSP FROM SANPHAM";
            DataTable dt = Program.ExecOracleDataTable(strLenh);
            BindingSource bds = new BindingSource();
            bds.DataSource = dt;
            cbb_tensp.DataSource = bds;
            cbb_tensp.DisplayMember = "TENSP";
            cbb_tensp.ValueMember = "MASP";
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txt_tongtien_TextChanged(object sender, EventArgs e)
        {
            int soluong= Convert.ToInt32(txt_soluong.Text);
            int giaban = Convert.ToInt32(txt_giaban.Text);
            int giamgia = Convert.ToInt32(txt_giamgia.Text);
            int tongtien = soluong * giaban - (soluong * giaban * giamgia);
            txt_tongtien.Text = tongtien.ToString();
        }

        private void btn_themvaogio_Click(object sender, EventArgs e)
        {
            if (luaChon == "Add")
            {
                String strLenh = "tao_CTDH";
                OracleCommand sqlCommand = new OracleCommand(strLenh, Program.conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandTimeout = 600;

                sqlCommand.Parameters.Add(new OracleParameter("MAHD1",txt_mahd.Text.ToString().Trim()));
                sqlCommand.Parameters.Add(new OracleParameter("MASP1", cbb_tensp.SelectedValue.ToString().Trim()));
                sqlCommand.Parameters.Add(new OracleParameter("SOLUONG1", txt_soluong.Text.ToString().Trim()));
                sqlCommand.Parameters.Add(new OracleParameter("MASP1", txt_giaban.Text.ToString().Trim()));
                sqlCommand.Parameters.Add(new OracleParameter("SOLUONG1", txt_giamgia.Text.ToString().Trim()));
                sqlCommand.Parameters.Add(new OracleParameter("TONGTIEN1", txt_tongtien.Text.ToString().Trim()));
                Program.ExecOracleCommand(sqlCommand);
                MessageBox.Show("Thêm thành công!");
            }
            else if (luaChon == "Edit")
            {
                String strLenh = "capnhat_CTDH";
                OracleCommand sqlCommand = new OracleCommand(strLenh, Program.conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandTimeout = 600;

                sqlCommand.Parameters.Add(new OracleParameter("MAHD1", txt_mahd.Text.ToString().Trim()));
                sqlCommand.Parameters.Add(new OracleParameter("MASP1", cbb_tensp.SelectedValue.ToString().Trim()));
                sqlCommand.Parameters.Add(new OracleParameter("SOLUONG1", txt_soluong.Text.ToString().Trim()));
                sqlCommand.Parameters.Add(new OracleParameter("MASP1", txt_giaban.Text.ToString().Trim()));
                sqlCommand.Parameters.Add(new OracleParameter("SOLUONG1", txt_giamgia.Text.ToString().Trim()));
                sqlCommand.Parameters.Add(new OracleParameter("TONGTIEN1", txt_tongtien.Text.ToString().Trim()));

                Program.ExecOracleCommand(sqlCommand);
                MessageBox.Show("Cập nhật thành công!");
            }
            this.Close();
        }
    }
}

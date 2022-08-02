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
    
    public partial class Form_DangNhap : Form
    {
        OracleConnection conn_publisher = new OracleConnection(@"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)))" +
           "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=pdborcl)));" +
           "User Id=milktea;Password=123456;");
       
        public Form_DangNhap()
        {
            //HienThiDuLieu_cbb_chucvu();
            InitializeComponent();
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void HienThiDuLieu_cbb_chucvu()
        {
            String strLenh = "SELECT MANHOM, TENNHOM FROM NHOMTK";
            DataTable dt = Program.ExecOracleDataTable(strLenh);
            BindingSource dbs = new BindingSource();
            dbs.DataSource = dt;
            cbb_chucvu.DataSource = dbs;
            cbb_chucvu.DisplayMember = "TENNHOM";
            cbb_chucvu.ValueMember = "MANHOM";
        }
        private void Form_DangNhap_Load(object sender, EventArgs e)
        {
            HienThiDuLieu_cbb_chucvu();
            txt_matkhau.Text = "";
            txt_matkhau.PasswordChar = '*';

        }

        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            string userName = txt_dangnhap.Text;
            string passWord = txt_matkhau.Text;
            string chucVu = cbb_chucvu.SelectedValue.ToString();

            if(userName == null||userName.Equals(""))
            {
                MessageBox.Show("Chưa nhập tên đăng nhập");
                return;
            }
            if(passWord==null||passWord.Equals(""))
            {
                MessageBox.Show("Chưa nhập mật khẩu");
                return ;
            }
           else if(chucVu==null||chucVu.Equals(""))
           {
               MessageBox.Show("Chúc vụ chưa đúng");
                return;
           }
            conn_publisher.Open();
            string query = "Select * from TAIKHOANTV  WHERE TAIKHOAN = '" + userName + "'AND MATKHAU= '" + passWord + "'and MANHOM ='"+chucVu+"'";
            OracleCommand cmd = new OracleCommand(query,conn_publisher);
            OracleDataReader dt = cmd.ExecuteReader();
            if(dt.Read())
            {
                MessageBox.Show("Đăng nhập thành công");
                MainApp ma= new MainApp();
                ma.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Đăng nhập không thành công");
            }
            conn_publisher.Close();
        }
    }
}

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
    public partial class Form_NhomTK : Form
    {
        OracleConnection conn_publisher = new OracleConnection();
        DataTable dt = new DataTable();
        public Form_NhomTK()
        {
            InitializeComponent();
        }

        private void RibbonButton_Click(object sender, EventArgs e)
        {

        }

        private void Form_NhomTK_Load(object sender, EventArgs e)
        {
            this.WindowState=FormWindowState.Maximized;
            HienThiDuLieu();
        }
        private void HienThiDuLieu()
        {
            String strLenh = "SELECT MANHOM, TENNHOM, GHICHU FROM NHOMTK ";
            dt = Program.ExecOracleDataTable(strLenh);
            dgv_nhomtk.DataSource = dt;
            dgv_nhomtk.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_nhomtk.Columns[0].HeaderText = "Mã nhóm";
            dgv_nhomtk.Columns[1].HeaderText = "Tên nhóm";
            dgv_nhomtk.Columns[2].HeaderText = "Ghi chú";
            conn_publisher.Close();
        }

        private void btn_chucnang_Click(object sender, EventArgs e)
        {
            Form_Tao_Sua_Xoa_NhomTK tsx = new Form_Tao_Sua_Xoa_NhomTK();
            tsx.ShowDialog();
        }
    }
}

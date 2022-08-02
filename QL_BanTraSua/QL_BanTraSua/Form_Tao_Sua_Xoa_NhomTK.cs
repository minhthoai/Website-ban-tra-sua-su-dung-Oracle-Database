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
    public partial class Form_Tao_Sua_Xoa_NhomTK : Form
    {
        OracleConnection conn_publisher = new OracleConnection();
        DataTable dt =new DataTable();
        string flag = "";
        public Form_Tao_Sua_Xoa_NhomTK()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            txt_manhomtk.Enabled = txt_tennhomtk.Enabled = txt_ghichu.Enabled = false;
            btn_luu.Enabled = false;
        }

        private void Form_Tao_Sua_Xoa_NhomTK_Load(object sender, EventArgs e)
        {
            HienThiDuLieu();
            
        }
        private void HienThiDuLieu()
        {
            String strLenh = "SELECT MANHOM, TENNHOM, GHICHU FROM NHOMTK ";
            dt = Program.ExecOracleDataTable(strLenh);
            dgv_chucnang_nhomtk.DataSource = dt;
            dgv_chucnang_nhomtk.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_chucnang_nhomtk.Columns[0].HeaderText = "Mã nhóm";
            dgv_chucnang_nhomtk.Columns[1].HeaderText = "Tên nhóm";
            dgv_chucnang_nhomtk.Columns[2].HeaderText = "Ghi chú";
            conn_publisher.Clone();
        }

        private void dgv_chucnang_nhomtk_SelectionChanged(object sender, EventArgs e)
        {
            int index = dgv_chucnang_nhomtk.CurrentCell.RowIndex;
            DataTable td = (DataTable)dgv_chucnang_nhomtk.DataSource;
            if(dt.Rows.Count > 0)
            {
                txt_manhomtk.Text=dgv_chucnang_nhomtk.Rows[index].Cells[0].Value.ToString().Trim();
                txt_tennhomtk.Text = dgv_chucnang_nhomtk.Rows[index].Cells[1].Value.ToString().Trim();
                txt_ghichu.Text = dgv_chucnang_nhomtk.Rows[index].Cells[2].Value.ToString().Trim();
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            flag = "add";
            txt_manhomtk.Enabled = txt_tennhomtk.Enabled = txt_ghichu.Enabled = true;
            txt_manhomtk.Text= dt.Rows[0]["MANHOM"].ToString().Trim();

            btn_sua.Enabled = btn_xoa.Enabled = false;
            btn_luu.Enabled = true;
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            flag = "edit";
            txt_manhomtk.Enabled=txt_tennhomtk.Enabled=txt_ghichu.Enabled = true;
            btn_them.Enabled=btn_xoa.Enabled = false;
            btn_luu.Enabled = true;
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            flag = "delete";
            btn_them.Enabled=btn_sua.Enabled = false;
            btn_luu.Enabled = true;
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            if (!CheckValidate(txt_manhomtk, "Mã nhóm không được để trống ")) return;
            if (!CheckValidate(txt_tennhomtk, "Tên nhóm không được để trống ")) return;
            if (txt_manhomtk.Text.Trim().Length > 4)
            {
                MessageBox.Show("Mã nhóm không được lớn hơn 10 ký tự ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txt_manhomtk.Text.Contains(" "))
            {
                MessageBox.Show("Mã nhóm không được để khoảng trắng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (CheckExistMaNhom(txt_manhomtk.Text) && flag == "add")
            {
                MessageBox.Show("Mã nhóm đã tồn tại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(flag=="add")
            {
                String strlenh = "tao_nhomTK";
                OracleCommand oracleCommand = new OracleCommand(strlenh, Program.conn);
                oracleCommand.CommandType = CommandType.StoredProcedure;
                oracleCommand.CommandTimeout = 100;

                oracleCommand.Parameters.Add(new OracleParameter("MaNhom", txt_manhomtk.Text.ToString().Trim()));
                oracleCommand.Parameters.Add(new OracleParameter("TenNhom", txt_tennhomtk.Text.ToString().Trim()));
                oracleCommand.Parameters.Add(new OracleParameter("GhiChu", txt_ghichu.Text.ToString().Trim()));

                Program.ExecOracleCommand(oracleCommand);
            }
            else if (flag == "edit")
            {
                String strlenh = "sua_nhomTK";
                OracleCommand oracleCommand = new OracleCommand(strlenh, Program.conn);
                oracleCommand.CommandType = CommandType.StoredProcedure;
                oracleCommand.CommandTimeout = 100;

                oracleCommand.Parameters.Add(new OracleParameter("MaNhom", txt_manhomtk.Text.ToString().Trim()));
                oracleCommand.Parameters.Add(new OracleParameter("TenNhom", txt_tennhomtk.Text.ToString().Trim()));
                oracleCommand.Parameters.Add(new OracleParameter("GhiChu", txt_ghichu.Text.ToString().Trim()));

                Program.ExecOracleCommand(oracleCommand);
            }
            else if (flag == "delete")
            {
                String strlenh = "xoa_nhomTK";
                OracleCommand oracleCommand = new OracleCommand(strlenh, Program.conn);
                oracleCommand.CommandType = CommandType.StoredProcedure;
                oracleCommand.CommandTimeout = 100;

                oracleCommand.Parameters.Add(new OracleParameter("MaNhom", txt_manhomtk.Text.ToString().Trim()));
               
                Program.ExecOracleCommand(oracleCommand);
            }
            txt_manhomtk.Enabled = txt_tennhomtk.Enabled = txt_ghichu.Enabled = true;
            HienThiDuLieu();
            btn_them.Enabled = btn_sua.Enabled = btn_xoa.Enabled = true;
            btn_luu.Enabled = false;
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

        private bool CheckExistMaNhom(String maNHom)
        {
            foreach (DataRow row in dt.Rows)
            {
                String maNhomGridView = row["MANHOM"].ToString();
                if (maNhomGridView.Trim() == maNHom.Trim())
                {
                    return true;
                }
            }
            return false;
        }
        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            dgv_chucnang_nhomtk.Refresh();
            txt_manhomtk.Enabled=txt_tennhomtk.Enabled=txt_ghichu.Enabled=false;
            btn_luu.Enabled=false;
        }
    }
}

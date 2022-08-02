namespace QL_BanTraSua
{
    partial class Form_ThongTinTaiKhoan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ThongTinTaiKhoan));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_thoat = new System.Windows.Forms.Button();
            this.btn_loc = new System.Windows.Forms.Button();
            this.cbb_locthongtin = new System.Windows.Forms.ComboBox();
            this.dgv_thongtintaikhoan = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_thongtintaikhoan)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btn_thoat);
            this.panel1.Controls.Add(this.btn_loc);
            this.panel1.Controls.Add(this.cbb_locthongtin);
            this.panel1.Location = new System.Drawing.Point(11, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1759, 109);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(13, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(139, 103);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // btn_thoat
            // 
            this.btn_thoat.Location = new System.Drawing.Point(761, 26);
            this.btn_thoat.Name = "btn_thoat";
            this.btn_thoat.Size = new System.Drawing.Size(100, 42);
            this.btn_thoat.TabIndex = 2;
            this.btn_thoat.Text = "Thoát";
            this.btn_thoat.UseVisualStyleBackColor = true;
            this.btn_thoat.Click += new System.EventHandler(this.btn_thoat_Click);
            // 
            // btn_loc
            // 
            this.btn_loc.Location = new System.Drawing.Point(601, 26);
            this.btn_loc.Name = "btn_loc";
            this.btn_loc.Size = new System.Drawing.Size(100, 42);
            this.btn_loc.TabIndex = 1;
            this.btn_loc.Text = "Lọc thông tin ";
            this.btn_loc.UseVisualStyleBackColor = true;
            // 
            // cbb_locthongtin
            // 
            this.cbb_locthongtin.FormattingEnabled = true;
            this.cbb_locthongtin.Location = new System.Drawing.Point(202, 36);
            this.cbb_locthongtin.Name = "cbb_locthongtin";
            this.cbb_locthongtin.Size = new System.Drawing.Size(349, 24);
            this.cbb_locthongtin.TabIndex = 0;
            // 
            // dgv_thongtintaikhoan
            // 
            this.dgv_thongtintaikhoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_thongtintaikhoan.Location = new System.Drawing.Point(15, 124);
            this.dgv_thongtintaikhoan.Name = "dgv_thongtintaikhoan";
            this.dgv_thongtintaikhoan.RowHeadersWidth = 51;
            this.dgv_thongtintaikhoan.RowTemplate.Height = 24;
            this.dgv_thongtintaikhoan.Size = new System.Drawing.Size(1897, 529);
            this.dgv_thongtintaikhoan.TabIndex = 1;
            // 
            // Form_ThongTinTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 666);
            this.Controls.Add(this.dgv_thongtintaikhoan);
            this.Controls.Add(this.panel1);
            this.Name = "Form_ThongTinTaiKhoan";
            this.Text = "Thông tin tài khoản";
            this.Load += new System.EventHandler(this.Form_ThongTinTaiKhoan_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_thongtintaikhoan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_thoat;
        private System.Windows.Forms.Button btn_loc;
        private System.Windows.Forms.ComboBox cbb_locthongtin;
        private System.Windows.Forms.DataGridView dgv_thongtintaikhoan;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
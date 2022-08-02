namespace QL_BanTraSua
{
    partial class Form_XoaTaiKhoan
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
            this.txt_timkiem = new System.Windows.Forms.TextBox();
            this.txt_taikhoan = new System.Windows.Forms.TextBox();
            this.btn_timkiem = new System.Windows.Forms.Button();
            this.btn_thoat = new System.Windows.Forms.Button();
            this.btn_hienthilai = new System.Windows.Forms.Button();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.dgv_taikhoan = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_taikhoan)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_timkiem
            // 
            this.txt_timkiem.Location = new System.Drawing.Point(100, 35);
            this.txt_timkiem.Name = "txt_timkiem";
            this.txt_timkiem.Size = new System.Drawing.Size(231, 22);
            this.txt_timkiem.TabIndex = 0;
            // 
            // txt_taikhoan
            // 
            this.txt_taikhoan.Location = new System.Drawing.Point(100, 83);
            this.txt_taikhoan.Name = "txt_taikhoan";
            this.txt_taikhoan.Size = new System.Drawing.Size(231, 22);
            this.txt_taikhoan.TabIndex = 1;
            // 
            // btn_timkiem
            // 
            this.btn_timkiem.Location = new System.Drawing.Point(401, 31);
            this.btn_timkiem.Name = "btn_timkiem";
            this.btn_timkiem.Size = new System.Drawing.Size(110, 30);
            this.btn_timkiem.TabIndex = 2;
            this.btn_timkiem.Text = "Tìm kiếm";
            this.btn_timkiem.UseVisualStyleBackColor = true;
            this.btn_timkiem.Click += new System.EventHandler(this.btn_timkiem_Click);
            // 
            // btn_thoat
            // 
            this.btn_thoat.Location = new System.Drawing.Point(558, 79);
            this.btn_thoat.Name = "btn_thoat";
            this.btn_thoat.Size = new System.Drawing.Size(110, 30);
            this.btn_thoat.TabIndex = 3;
            this.btn_thoat.Text = "Thoát";
            this.btn_thoat.UseVisualStyleBackColor = true;
            this.btn_thoat.Click += new System.EventHandler(this.btn_thoat_Click);
            // 
            // btn_hienthilai
            // 
            this.btn_hienthilai.Location = new System.Drawing.Point(558, 31);
            this.btn_hienthilai.Name = "btn_hienthilai";
            this.btn_hienthilai.Size = new System.Drawing.Size(110, 30);
            this.btn_hienthilai.TabIndex = 4;
            this.btn_hienthilai.Text = "Hiển thị tất cả";
            this.btn_hienthilai.UseVisualStyleBackColor = true;
            this.btn_hienthilai.Click += new System.EventHandler(this.btn_hienthilai_Click);
            // 
            // btn_xoa
            // 
            this.btn_xoa.Location = new System.Drawing.Point(401, 79);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(110, 30);
            this.btn_xoa.TabIndex = 5;
            this.btn_xoa.Text = "Xóa";
            this.btn_xoa.UseVisualStyleBackColor = true;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // dgv_taikhoan
            // 
            this.dgv_taikhoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_taikhoan.Location = new System.Drawing.Point(12, 130);
            this.dgv_taikhoan.Name = "dgv_taikhoan";
            this.dgv_taikhoan.RowHeadersWidth = 51;
            this.dgv_taikhoan.RowTemplate.Height = 24;
            this.dgv_taikhoan.Size = new System.Drawing.Size(934, 337);
            this.dgv_taikhoan.TabIndex = 6;
            // 
            // Form_XoaTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 480);
            this.Controls.Add(this.dgv_taikhoan);
            this.Controls.Add(this.btn_xoa);
            this.Controls.Add(this.btn_hienthilai);
            this.Controls.Add(this.btn_thoat);
            this.Controls.Add(this.btn_timkiem);
            this.Controls.Add(this.txt_taikhoan);
            this.Controls.Add(this.txt_timkiem);
            this.Name = "Form_XoaTaiKhoan";
            this.Text = "Form_XoaTaiKhoan";
            this.Load += new System.EventHandler(this.Form_XoaTaiKhoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_taikhoan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_timkiem;
        private System.Windows.Forms.TextBox txt_taikhoan;
        private System.Windows.Forms.Button btn_timkiem;
        private System.Windows.Forms.Button btn_thoat;
        private System.Windows.Forms.Button btn_hienthilai;
        private System.Windows.Forms.Button btn_xoa;
        private System.Windows.Forms.DataGridView dgv_taikhoan;
    }
}
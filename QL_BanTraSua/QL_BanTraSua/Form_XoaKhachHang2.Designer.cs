namespace QL_BanTraSua
{
    partial class Form_XoaKhachHang2
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
            this.btn_timkiem = new System.Windows.Forms.Button();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.txt_makh = new System.Windows.Forms.TextBox();
            this.btn_hienthilai = new System.Windows.Forms.Button();
            this.dgv_dsKhachHang = new System.Windows.Forms.DataGridView();
            this.btn_thoat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dsKhachHang)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_timkiem
            // 
            this.txt_timkiem.Location = new System.Drawing.Point(92, 39);
            this.txt_timkiem.Name = "txt_timkiem";
            this.txt_timkiem.Size = new System.Drawing.Size(219, 22);
            this.txt_timkiem.TabIndex = 0;
            // 
            // btn_timkiem
            // 
            this.btn_timkiem.Location = new System.Drawing.Point(361, 35);
            this.btn_timkiem.Name = "btn_timkiem";
            this.btn_timkiem.Size = new System.Drawing.Size(108, 31);
            this.btn_timkiem.TabIndex = 1;
            this.btn_timkiem.Text = "Tìm kiếm";
            this.btn_timkiem.UseVisualStyleBackColor = true;
            this.btn_timkiem.Click += new System.EventHandler(this.btn_timkiem_Click);
            // 
            // btn_xoa
            // 
            this.btn_xoa.Location = new System.Drawing.Point(361, 84);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(108, 31);
            this.btn_xoa.TabIndex = 2;
            this.btn_xoa.Text = "Xóa";
            this.btn_xoa.UseVisualStyleBackColor = true;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // txt_makh
            // 
            this.txt_makh.Location = new System.Drawing.Point(92, 88);
            this.txt_makh.Name = "txt_makh";
            this.txt_makh.Size = new System.Drawing.Size(219, 22);
            this.txt_makh.TabIndex = 3;
            // 
            // btn_hienthilai
            // 
            this.btn_hienthilai.Location = new System.Drawing.Point(533, 35);
            this.btn_hienthilai.Name = "btn_hienthilai";
            this.btn_hienthilai.Size = new System.Drawing.Size(108, 31);
            this.btn_hienthilai.TabIndex = 4;
            this.btn_hienthilai.Text = "Hiển thị tất cả";
            this.btn_hienthilai.UseVisualStyleBackColor = true;
            this.btn_hienthilai.Click += new System.EventHandler(this.btn_hienthilai_Click);
            // 
            // dgv_dsKhachHang
            // 
            this.dgv_dsKhachHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_dsKhachHang.Location = new System.Drawing.Point(12, 127);
            this.dgv_dsKhachHang.Name = "dgv_dsKhachHang";
            this.dgv_dsKhachHang.RowHeadersWidth = 51;
            this.dgv_dsKhachHang.RowTemplate.Height = 24;
            this.dgv_dsKhachHang.Size = new System.Drawing.Size(1046, 377);
            this.dgv_dsKhachHang.TabIndex = 5;
            // 
            // btn_thoat
            // 
            this.btn_thoat.Location = new System.Drawing.Point(533, 84);
            this.btn_thoat.Name = "btn_thoat";
            this.btn_thoat.Size = new System.Drawing.Size(108, 31);
            this.btn_thoat.TabIndex = 6;
            this.btn_thoat.Text = "Thoát";
            this.btn_thoat.UseVisualStyleBackColor = true;
            // 
            // Form_XoaKhachHang2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 516);
            this.Controls.Add(this.btn_thoat);
            this.Controls.Add(this.dgv_dsKhachHang);
            this.Controls.Add(this.btn_hienthilai);
            this.Controls.Add(this.txt_makh);
            this.Controls.Add(this.btn_xoa);
            this.Controls.Add(this.btn_timkiem);
            this.Controls.Add(this.txt_timkiem);
            this.Name = "Form_XoaKhachHang2";
            this.Text = "Form_XoaKhachHang2";
            this.Load += new System.EventHandler(this.Form_XoaKhachHang2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dsKhachHang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_timkiem;
        private System.Windows.Forms.Button btn_timkiem;
        private System.Windows.Forms.Button btn_xoa;
        private System.Windows.Forms.TextBox txt_makh;
        private System.Windows.Forms.Button btn_hienthilai;
        private System.Windows.Forms.DataGridView dgv_dsKhachHang;
        private System.Windows.Forms.Button btn_thoat;
    }
}
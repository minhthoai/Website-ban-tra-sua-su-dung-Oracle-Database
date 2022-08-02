namespace QL_BanTraSua
{
    partial class Form_XoaDonHang
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
            this.txt_madh = new System.Windows.Forms.TextBox();
            this.btn_timkiem = new System.Windows.Forms.Button();
            this.btn_thoat = new System.Windows.Forms.Button();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.btn_hienthilai = new System.Windows.Forms.Button();
            this.dgv_donhang = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_donhang)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_timkiem
            // 
            this.txt_timkiem.Location = new System.Drawing.Point(89, 23);
            this.txt_timkiem.Name = "txt_timkiem";
            this.txt_timkiem.Size = new System.Drawing.Size(205, 22);
            this.txt_timkiem.TabIndex = 0;
            // 
            // txt_madh
            // 
            this.txt_madh.Location = new System.Drawing.Point(89, 79);
            this.txt_madh.Name = "txt_madh";
            this.txt_madh.Size = new System.Drawing.Size(205, 22);
            this.txt_madh.TabIndex = 1;
            // 
            // btn_timkiem
            // 
            this.btn_timkiem.Location = new System.Drawing.Point(384, 18);
            this.btn_timkiem.Name = "btn_timkiem";
            this.btn_timkiem.Size = new System.Drawing.Size(108, 33);
            this.btn_timkiem.TabIndex = 2;
            this.btn_timkiem.Text = "Tìm kiếm";
            this.btn_timkiem.UseVisualStyleBackColor = true;
            this.btn_timkiem.Click += new System.EventHandler(this.btn_timkiem_Click);
            // 
            // btn_thoat
            // 
            this.btn_thoat.Location = new System.Drawing.Point(541, 74);
            this.btn_thoat.Name = "btn_thoat";
            this.btn_thoat.Size = new System.Drawing.Size(108, 33);
            this.btn_thoat.TabIndex = 3;
            this.btn_thoat.Text = "Thoát";
            this.btn_thoat.UseVisualStyleBackColor = true;
            this.btn_thoat.Click += new System.EventHandler(this.btn_thoat_Click);
            // 
            // btn_xoa
            // 
            this.btn_xoa.Location = new System.Drawing.Point(384, 74);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(108, 33);
            this.btn_xoa.TabIndex = 4;
            this.btn_xoa.Text = "Xóa";
            this.btn_xoa.UseVisualStyleBackColor = true;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // btn_hienthilai
            // 
            this.btn_hienthilai.Location = new System.Drawing.Point(541, 18);
            this.btn_hienthilai.Name = "btn_hienthilai";
            this.btn_hienthilai.Size = new System.Drawing.Size(108, 33);
            this.btn_hienthilai.TabIndex = 5;
            this.btn_hienthilai.Text = "Hiển thị tất cả";
            this.btn_hienthilai.UseVisualStyleBackColor = true;
            this.btn_hienthilai.Click += new System.EventHandler(this.btn_hienthilai_Click);
            // 
            // dgv_donhang
            // 
            this.dgv_donhang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_donhang.Location = new System.Drawing.Point(12, 125);
            this.dgv_donhang.Name = "dgv_donhang";
            this.dgv_donhang.RowHeadersWidth = 51;
            this.dgv_donhang.RowTemplate.Height = 24;
            this.dgv_donhang.Size = new System.Drawing.Size(927, 333);
            this.dgv_donhang.TabIndex = 6;
            // 
            // Form_XoaDonHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 470);
            this.Controls.Add(this.dgv_donhang);
            this.Controls.Add(this.btn_hienthilai);
            this.Controls.Add(this.btn_xoa);
            this.Controls.Add(this.btn_thoat);
            this.Controls.Add(this.btn_timkiem);
            this.Controls.Add(this.txt_madh);
            this.Controls.Add(this.txt_timkiem);
            this.Name = "Form_XoaDonHang";
            this.Text = "Form_XoaDonHang";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_donhang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_timkiem;
        private System.Windows.Forms.TextBox txt_madh;
        private System.Windows.Forms.Button btn_timkiem;
        private System.Windows.Forms.Button btn_thoat;
        private System.Windows.Forms.Button btn_xoa;
        private System.Windows.Forms.Button btn_hienthilai;
        private System.Windows.Forms.DataGridView dgv_donhang;
    }
}
namespace QL_BanTraSua
{
    partial class Form_XoaSanPham
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
            this.txt_masp = new System.Windows.Forms.TextBox();
            this.btn_timkiem = new System.Windows.Forms.Button();
            this.btn_hienthitatca = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dgv_Sanpham = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Sanpham)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_timkiem
            // 
            this.txt_timkiem.Location = new System.Drawing.Point(93, 33);
            this.txt_timkiem.Name = "txt_timkiem";
            this.txt_timkiem.Size = new System.Drawing.Size(261, 22);
            this.txt_timkiem.TabIndex = 0;
            // 
            // txt_masp
            // 
            this.txt_masp.Location = new System.Drawing.Point(93, 89);
            this.txt_masp.Name = "txt_masp";
            this.txt_masp.Size = new System.Drawing.Size(261, 22);
            this.txt_masp.TabIndex = 1;
            // 
            // btn_timkiem
            // 
            this.btn_timkiem.Location = new System.Drawing.Point(413, 27);
            this.btn_timkiem.Name = "btn_timkiem";
            this.btn_timkiem.Size = new System.Drawing.Size(116, 35);
            this.btn_timkiem.TabIndex = 2;
            this.btn_timkiem.Text = "Tìm kiếm";
            this.btn_timkiem.UseVisualStyleBackColor = true;
            this.btn_timkiem.Click += new System.EventHandler(this.btn_timkiem_Click);
            // 
            // btn_hienthitatca
            // 
            this.btn_hienthitatca.Location = new System.Drawing.Point(578, 27);
            this.btn_hienthitatca.Name = "btn_hienthitatca";
            this.btn_hienthitatca.Size = new System.Drawing.Size(116, 35);
            this.btn_hienthitatca.TabIndex = 3;
            this.btn_hienthitatca.Text = "Hiển thị tất cả ";
            this.btn_hienthitatca.UseVisualStyleBackColor = true;
            this.btn_hienthitatca.Click += new System.EventHandler(this.btn_hienthitatca_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(413, 83);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(116, 35);
            this.button3.TabIndex = 4;
            this.button3.Text = "Xóa";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(578, 83);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(116, 35);
            this.button4.TabIndex = 5;
            this.button4.Text = "Thoát";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dgv_Sanpham
            // 
            this.dgv_Sanpham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Sanpham.Location = new System.Drawing.Point(12, 129);
            this.dgv_Sanpham.Name = "dgv_Sanpham";
            this.dgv_Sanpham.RowHeadersWidth = 51;
            this.dgv_Sanpham.RowTemplate.Height = 24;
            this.dgv_Sanpham.Size = new System.Drawing.Size(973, 474);
            this.dgv_Sanpham.TabIndex = 6;
            // 
            // Form_XoaSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 615);
            this.Controls.Add(this.dgv_Sanpham);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btn_hienthitatca);
            this.Controls.Add(this.btn_timkiem);
            this.Controls.Add(this.txt_masp);
            this.Controls.Add(this.txt_timkiem);
            this.Name = "Form_XoaSanPham";
            this.Text = "Form_XoaSanPham";
            this.Load += new System.EventHandler(this.Form_XoaSanPham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Sanpham)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_timkiem;
        private System.Windows.Forms.TextBox txt_masp;
        private System.Windows.Forms.Button btn_timkiem;
        private System.Windows.Forms.Button btn_hienthitatca;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dgv_Sanpham;
    }
}
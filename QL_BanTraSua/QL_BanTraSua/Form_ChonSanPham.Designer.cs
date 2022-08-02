namespace QL_BanTraSua
{
    partial class Form_ChonSanPham
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
            this.btn_themvaogio = new System.Windows.Forms.Button();
            this.btn_thoat = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbb_tensp = new System.Windows.Forms.ComboBox();
            this.txt_mahd = new System.Windows.Forms.TextBox();
            this.txt_soluong = new System.Windows.Forms.TextBox();
            this.txt_giaban = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_giamgia = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_tongtien = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_themvaogio
            // 
            this.btn_themvaogio.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_themvaogio.Location = new System.Drawing.Point(23, 276);
            this.btn_themvaogio.Name = "btn_themvaogio";
            this.btn_themvaogio.Size = new System.Drawing.Size(95, 46);
            this.btn_themvaogio.TabIndex = 2;
            this.btn_themvaogio.Text = "Thêm sản phẩm";
            this.btn_themvaogio.UseVisualStyleBackColor = true;
            this.btn_themvaogio.Click += new System.EventHandler(this.btn_themvaogio_Click);
            // 
            // btn_thoat
            // 
            this.btn_thoat.Location = new System.Drawing.Point(281, 276);
            this.btn_thoat.Name = "btn_thoat";
            this.btn_thoat.Size = new System.Drawing.Size(95, 46);
            this.btn_thoat.TabIndex = 3;
            this.btn_thoat.Text = "Thoát";
            this.btn_thoat.UseVisualStyleBackColor = true;
            this.btn_thoat.Click += new System.EventHandler(this.btn_thoat_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Mã hóa đơn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tên sản phẩm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Số lượng";
            // 
            // cbb_tensp
            // 
            this.cbb_tensp.FormattingEnabled = true;
            this.cbb_tensp.Location = new System.Drawing.Point(156, 75);
            this.cbb_tensp.Name = "cbb_tensp";
            this.cbb_tensp.Size = new System.Drawing.Size(220, 24);
            this.cbb_tensp.TabIndex = 8;
            // 
            // txt_mahd
            // 
            this.txt_mahd.Location = new System.Drawing.Point(151, 22);
            this.txt_mahd.Name = "txt_mahd";
            this.txt_mahd.Size = new System.Drawing.Size(130, 22);
            this.txt_mahd.TabIndex = 9;
            // 
            // txt_soluong
            // 
            this.txt_soluong.Location = new System.Drawing.Point(156, 128);
            this.txt_soluong.Name = "txt_soluong";
            this.txt_soluong.Size = new System.Drawing.Size(220, 22);
            this.txt_soluong.TabIndex = 10;
            // 
            // txt_giaban
            // 
            this.txt_giaban.Location = new System.Drawing.Point(527, 22);
            this.txt_giaban.Name = "txt_giaban";
            this.txt_giaban.Size = new System.Drawing.Size(220, 22);
            this.txt_giaban.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(446, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Giá bán";
            // 
            // txt_giamgia
            // 
            this.txt_giamgia.Location = new System.Drawing.Point(527, 75);
            this.txt_giamgia.Name = "txt_giamgia";
            this.txt_giamgia.Size = new System.Drawing.Size(220, 22);
            this.txt_giamgia.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(446, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "Giảm giá";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(446, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "Tổng tiền";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // txt_tongtien
            // 
            this.txt_tongtien.Location = new System.Drawing.Point(527, 131);
            this.txt_tongtien.Name = "txt_tongtien";
            this.txt_tongtien.Size = new System.Drawing.Size(220, 22);
            this.txt_tongtien.TabIndex = 16;
            this.txt_tongtien.TextChanged += new System.EventHandler(this.txt_tongtien_TextChanged);
            // 
            // Form_ChonSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 363);
            this.Controls.Add(this.txt_tongtien);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_giamgia);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_giaban);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_soluong);
            this.Controls.Add(this.txt_mahd);
            this.Controls.Add(this.cbb_tensp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_thoat);
            this.Controls.Add(this.btn_themvaogio);
            this.Name = "Form_ChonSanPham";
            this.Text = "Chọn sản phẩm";
            this.Load += new System.EventHandler(this.Form_ChonSanPham_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_themvaogio;
        private System.Windows.Forms.Button btn_thoat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbb_tensp;
        private System.Windows.Forms.TextBox txt_mahd;
        private System.Windows.Forms.TextBox txt_soluong;
        private System.Windows.Forms.TextBox txt_giaban;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_giamgia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_tongtien;
    }
}
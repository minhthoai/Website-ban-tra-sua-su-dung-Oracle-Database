namespace QL_BanTraSua
{
    partial class Form_NhomTK
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_NhomTK));
            this.rib_nhomtk = new System.Windows.Forms.RibbonButton();
            this.dgv_nhomtk = new System.Windows.Forms.DataGridView();
            this.txt_timkiem = new System.Windows.Forms.TextBox();
            this.btn_timkiem = new System.Windows.Forms.Button();
            this.btn_chucnang = new System.Windows.Forms.Button();
            this.btn_thoat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_nhomtk)).BeginInit();
            this.SuspendLayout();
            // 
            // rib_nhomtk
            // 
            this.rib_nhomtk.Image = ((System.Drawing.Image)(resources.GetObject("rib_nhomtk.Image")));
            this.rib_nhomtk.LargeImage = ((System.Drawing.Image)(resources.GetObject("rib_nhomtk.LargeImage")));
            this.rib_nhomtk.Name = "rib_nhomtk";
            this.rib_nhomtk.SmallImage = ((System.Drawing.Image)(resources.GetObject("rib_nhomtk.SmallImage")));
            this.rib_nhomtk.Text = "Nhóm tài.khoản";
            this.rib_nhomtk.Click += new System.EventHandler(this.RibbonButton_Click);
            // 
            // dgv_nhomtk
            // 
            this.dgv_nhomtk.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_nhomtk.Location = new System.Drawing.Point(12, 130);
            this.dgv_nhomtk.Name = "dgv_nhomtk";
            this.dgv_nhomtk.RowHeadersWidth = 51;
            this.dgv_nhomtk.RowTemplate.Height = 24;
            this.dgv_nhomtk.Size = new System.Drawing.Size(821, 372);
            this.dgv_nhomtk.TabIndex = 0;
            // 
            // txt_timkiem
            // 
            this.txt_timkiem.Location = new System.Drawing.Point(12, 51);
            this.txt_timkiem.Name = "txt_timkiem";
            this.txt_timkiem.Size = new System.Drawing.Size(295, 22);
            this.txt_timkiem.TabIndex = 1;
            // 
            // btn_timkiem
            // 
            this.btn_timkiem.Location = new System.Drawing.Point(339, 47);
            this.btn_timkiem.Name = "btn_timkiem";
            this.btn_timkiem.Size = new System.Drawing.Size(82, 30);
            this.btn_timkiem.TabIndex = 2;
            this.btn_timkiem.Text = "Tìm kiếm";
            this.btn_timkiem.UseVisualStyleBackColor = true;
            // 
            // btn_chucnang
            // 
            this.btn_chucnang.Location = new System.Drawing.Point(446, 47);
            this.btn_chucnang.Name = "btn_chucnang";
            this.btn_chucnang.Size = new System.Drawing.Size(113, 30);
            this.btn_chucnang.TabIndex = 3;
            this.btn_chucnang.Text = "Chức năng";
            this.btn_chucnang.UseVisualStyleBackColor = true;
            this.btn_chucnang.Click += new System.EventHandler(this.btn_chucnang_Click);
            // 
            // btn_thoat
            // 
            this.btn_thoat.Location = new System.Drawing.Point(596, 47);
            this.btn_thoat.Name = "btn_thoat";
            this.btn_thoat.Size = new System.Drawing.Size(82, 30);
            this.btn_thoat.TabIndex = 5;
            this.btn_thoat.Text = "Thoát";
            this.btn_thoat.UseVisualStyleBackColor = true;
            // 
            // Form_NhomTK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 514);
            this.Controls.Add(this.btn_thoat);
            this.Controls.Add(this.btn_chucnang);
            this.Controls.Add(this.btn_timkiem);
            this.Controls.Add(this.txt_timkiem);
            this.Controls.Add(this.dgv_nhomtk);
            this.Name = "Form_NhomTK";
            this.Text = "Nhóm tài khoản ";
            this.Load += new System.EventHandler(this.Form_NhomTK_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_nhomtk)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RibbonButton rib_nhomtk;
        private System.Windows.Forms.DataGridView dgv_nhomtk;
        private System.Windows.Forms.TextBox txt_timkiem;
        private System.Windows.Forms.Button btn_timkiem;
        private System.Windows.Forms.Button btn_chucnang;
        private System.Windows.Forms.Button btn_thoat;
    }
}
namespace Lab05_MultiForm
{
    partial class frmChiTietSinhVien
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.caplblMa = new System.Windows.Forms.Label();
            this.lblMa = new System.Windows.Forms.Label();
            this.caplblHoTen = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.caplblDiem = new System.Windows.Forms.Label();
            this.lblDiem = new System.Windows.Forms.Label();
            this.lblThongTin = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.SuspendLayout();
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Location = new System.Drawing.Point(24, 20);
            this.lblTieuDe.Size = new System.Drawing.Size(730, 38);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "Chi tiết sinh viên";
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI",16F,System.Drawing.FontStyle.Bold);
            this.caplblMa.Name = "caplblMa";
            this.caplblMa.Location = new System.Drawing.Point(24, 92);
            this.caplblMa.Size = new System.Drawing.Size(145, 28);
            this.caplblMa.TabIndex = 1;
            this.caplblMa.Text = "Mã sinh viên";
            this.lblMa.Name = "lblMa";
            this.lblMa.Location = new System.Drawing.Point(185, 90);
            this.lblMa.Size = new System.Drawing.Size(550, 28);
            this.lblMa.TabIndex = 2;
            this.lblMa.Text = "...";
            this.caplblHoTen.Name = "caplblHoTen";
            this.caplblHoTen.Location = new System.Drawing.Point(24, 136);
            this.caplblHoTen.Size = new System.Drawing.Size(145, 28);
            this.caplblHoTen.TabIndex = 3;
            this.caplblHoTen.Text = "Họ tên";
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Location = new System.Drawing.Point(185, 134);
            this.lblHoTen.Size = new System.Drawing.Size(550, 28);
            this.lblHoTen.TabIndex = 4;
            this.lblHoTen.Text = "...";
            this.caplblDiem.Name = "caplblDiem";
            this.caplblDiem.Location = new System.Drawing.Point(24, 180);
            this.caplblDiem.Size = new System.Drawing.Size(145, 28);
            this.caplblDiem.TabIndex = 5;
            this.caplblDiem.Text = "Điểm trung bình";
            this.lblDiem.Name = "lblDiem";
            this.lblDiem.Location = new System.Drawing.Point(185, 178);
            this.lblDiem.Size = new System.Drawing.Size(550, 28);
            this.lblDiem.TabIndex = 6;
            this.lblDiem.Text = "...";
            this.lblThongTin.Name = "lblThongTin";
            this.lblThongTin.Location = new System.Drawing.Point(185, 220);
            this.lblThongTin.Size = new System.Drawing.Size(550, 100);
            this.lblThongTin.TabIndex = 7;
            this.lblThongTin.Text = "Thông tin sinh viên";
            this.btnDong.Name = "btnDong";
            this.btnDong.Location = new System.Drawing.Point(24, 340);
            this.btnDong.Size = new System.Drawing.Size(120, 36);
            this.btnDong.TabIndex = 8;
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.caplblMa);
            this.Controls.Add(this.lblMa);
            this.Controls.Add(this.caplblHoTen);
            this.Controls.Add(this.lblHoTen);
            this.Controls.Add(this.caplblDiem);
            this.Controls.Add(this.lblDiem);
            this.Controls.Add(this.lblThongTin);
            this.Controls.Add(this.btnDong);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F,17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Font = new System.Drawing.Font("Segoe UI",10F);
            this.ClientSize = new System.Drawing.Size(780,400);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.BackColor = System.Drawing.Color.White;
            this.Name = "frmChiTietSinhVien";
            this.Text = "Chi tiết sinh viên";
            this.Load += new System.EventHandler(this.frmChiTietSinhVien_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label caplblMa;
        private System.Windows.Forms.Label lblMa;
        private System.Windows.Forms.Label caplblHoTen;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Label caplblDiem;
        private System.Windows.Forms.Label lblDiem;
        private System.Windows.Forms.Label lblThongTin;
        private System.Windows.Forms.Button btnDong;
    }
}

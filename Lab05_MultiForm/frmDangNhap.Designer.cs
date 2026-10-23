namespace Lab05_MultiForm
{
    partial class frmDangNhap
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
            this.captxtTenDangNhap = new System.Windows.Forms.Label();
            this.txtTenDangNhap = new System.Windows.Forms.TextBox();
            this.captxtMatKhau = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.chkHienMatKhau = new System.Windows.Forms.CheckBox();
            this.lblHuongDan = new System.Windows.Forms.Label();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.timerKhoa = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Location = new System.Drawing.Point(24, 20);
            this.lblTieuDe.Size = new System.Drawing.Size(730, 38);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "Đăng nhập — Giới hạn lần thử";
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI",16F,System.Drawing.FontStyle.Bold);
            this.captxtTenDangNhap.Name = "captxtTenDangNhap";
            this.captxtTenDangNhap.Location = new System.Drawing.Point(24, 92);
            this.captxtTenDangNhap.Size = new System.Drawing.Size(145, 28);
            this.captxtTenDangNhap.TabIndex = 1;
            this.captxtTenDangNhap.Text = "Tên đăng nhập";
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Location = new System.Drawing.Point(185, 90);
            this.txtTenDangNhap.Size = new System.Drawing.Size(550, 28);
            this.txtTenDangNhap.TabIndex = 2;
            this.captxtMatKhau.Name = "captxtMatKhau";
            this.captxtMatKhau.Location = new System.Drawing.Point(24, 136);
            this.captxtMatKhau.Size = new System.Drawing.Size(145, 28);
            this.captxtMatKhau.TabIndex = 3;
            this.captxtMatKhau.Text = "Mật khẩu";
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Location = new System.Drawing.Point(185, 134);
            this.txtMatKhau.Size = new System.Drawing.Size(550, 28);
            this.txtMatKhau.TabIndex = 4;
            this.txtMatKhau.UseSystemPasswordChar = true;
            this.chkHienMatKhau.Name = "chkHienMatKhau";
            this.chkHienMatKhau.Location = new System.Drawing.Point(185, 180);
            this.chkHienMatKhau.Size = new System.Drawing.Size(300, 28);
            this.chkHienMatKhau.TabIndex = 5;
            this.chkHienMatKhau.Text = "Hiện mật khẩu";
            this.lblHuongDan.Name = "lblHuongDan";
            this.lblHuongDan.Location = new System.Drawing.Point(24, 225);
            this.lblHuongDan.Size = new System.Drawing.Size(710, 40);
            this.lblHuongDan.TabIndex = 6;
            this.lblHuongDan.Text = "Tài khoản mẫu: sinhvien / 123456. Sai 3 lần sẽ khóa 30 giây.";
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Location = new System.Drawing.Point(185, 280);
            this.btnDangNhap.Size = new System.Drawing.Size(120, 36);
            this.btnDangNhap.TabIndex = 7;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Location = new System.Drawing.Point(315, 280);
            this.btnHuy.Size = new System.Drawing.Size(120, 36);
            this.btnHuy.TabIndex = 8;
            this.btnHuy.Text = "Hủy";
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Location = new System.Drawing.Point(24, 335);
            this.lblTrangThai.Size = new System.Drawing.Size(710, 65);
            this.lblTrangThai.TabIndex = 9;
            this.lblTrangThai.Text = "Chưa đăng nhập.";
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            this.chkHienMatKhau.CheckedChanged += new System.EventHandler(this.chkHienMatKhau_CheckedChanged);
            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.captxtTenDangNhap);
            this.Controls.Add(this.txtTenDangNhap);
            this.Controls.Add(this.captxtMatKhau);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.chkHienMatKhau);
            this.Controls.Add(this.lblHuongDan);
            this.Controls.Add(this.btnDangNhap);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.lblTrangThai);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F,17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Font = new System.Drawing.Font("Segoe UI",10F);
            this.ClientSize = new System.Drawing.Size(780,430);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.BackColor = System.Drawing.Color.White;
            this.Name = "frmDangNhap";
            this.Text = "Đăng nhập — Giới hạn lần thử";
            this.timerKhoa.Interval = 250;
            this.timerKhoa.Tick += new System.EventHandler(this.timerKhoa_Tick);
            this.AcceptButton = this.btnDangNhap;
            this.CancelButton = this.btnHuy;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label captxtTenDangNhap;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.Label captxtMatKhau;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.CheckBox chkHienMatKhau;
        private System.Windows.Forms.Label lblHuongDan;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.Timer timerKhoa;
    }
}

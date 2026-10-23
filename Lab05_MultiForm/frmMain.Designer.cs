namespace Lab05_MultiForm
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        { if(disposing && components!=null) components.Dispose();base.Dispose(disposing); }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuDanhMuc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSinhVien = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuKhoa = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNghiepVu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTimKiem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDangNhap = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGioiThieu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblTrangThai = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDongHo = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerDongHo = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[]{this.mnuDanhMuc,this.mnuNghiepVu,this.mnuHeThong});
            this.mnuDanhMuc.Text="Danh mục";
            this.mnuDanhMuc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{this.mnuSinhVien,this.mnuKhoa});
            this.mnuSinhVien.Text="Sinh viên — Bài 1–4";
            this.mnuKhoa.Text="Khoa — Bài 8, 10";
            this.mnuNghiepVu.Text="Nghiệp vụ";
            this.mnuNghiepVu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{this.mnuTimKiem});
            this.mnuTimKiem.Text="Tìm sinh viên — Bài 7";
            this.mnuHeThong.Text="Hệ thống";
            this.mnuHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{this.mnuDangNhap,this.mnuGioiThieu,this.mnuThoat});
            this.mnuDangNhap.Text="Đăng nhập — Bài 6";
            this.mnuGioiThieu.Text="Giới thiệu — Bài 10";
            this.mnuThoat.Text="Thoát — Bài 9";
            this.mnuSinhVien.Click += new System.EventHandler(this.mnuSinhVien_Click);
            this.mnuKhoa.Click += new System.EventHandler(this.mnuKhoa_Click);
            this.mnuTimKiem.Click += new System.EventHandler(this.mnuTimKiem_Click);
            this.mnuDangNhap.Click += new System.EventHandler(this.mnuDangNhap_Click);
            this.mnuGioiThieu.Click += new System.EventHandler(this.mnuGioiThieu_Click);
            this.mnuThoat.Click += new System.EventHandler(this.mnuThoat_Click);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[]{this.lblTrangThai,this.lblDongHo});
            this.lblTrangThai.Text="Lab05 — Sẵn sàng. Danh mục > Sinh viên để bắt đầu.";
            this.lblTrangThai.Spring=true;
            this.lblTrangThai.TextAlign=System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDongHo.Text="Đồng hồ";
            this.timerDongHo.Interval=1000;
            this.timerDongHo.Tick += new System.EventHandler(this.timerDongHo_Tick);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F,17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Font=new System.Drawing.Font("Segoe UI",10F);
            this.ClientSize=new System.Drawing.Size(1080,850);
            this.MinimumSize=new System.Drawing.Size(900,700);
            this.IsMdiContainer=true;
            this.MainMenuStrip=this.menuStrip1;
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Name="frmMain";
            this.Text="Lab05 — Dashboard đa Form — Lê Tuấn Quang 24000641";
            this.StartPosition=System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuDanhMuc,mnuSinhVien,mnuKhoa,mnuNghiepVu,mnuTimKiem,mnuHeThong,mnuDangNhap,mnuGioiThieu,mnuThoat;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblTrangThai,lblDongHo;
        private System.Windows.Forms.Timer timerDongHo;
    }
}

namespace Lab05_MultiForm
{
    partial class frmTimKiem
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
            this.captxtTuKhoa = new System.Windows.Forms.Label();
            this.txtTuKhoa = new System.Windows.Forms.TextBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.caplstKetQua = new System.Windows.Forms.Label();
            this.lstKetQua = new System.Windows.Forms.ListBox();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.btnChon = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Location = new System.Drawing.Point(24, 20);
            this.lblTieuDe.Size = new System.Drawing.Size(730, 38);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "Tìm kiếm sinh viên";
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI",16F,System.Drawing.FontStyle.Bold);
            this.captxtTuKhoa.Name = "captxtTuKhoa";
            this.captxtTuKhoa.Location = new System.Drawing.Point(24, 87);
            this.captxtTuKhoa.Size = new System.Drawing.Size(145, 28);
            this.captxtTuKhoa.TabIndex = 1;
            this.captxtTuKhoa.Text = "Mã hoặc họ tên";
            this.txtTuKhoa.Name = "txtTuKhoa";
            this.txtTuKhoa.Location = new System.Drawing.Point(185, 85);
            this.txtTuKhoa.Size = new System.Drawing.Size(550, 28);
            this.txtTuKhoa.TabIndex = 2;
            this.btnTim.Name = "btnTim";
            this.btnTim.Location = new System.Drawing.Point(24, 130);
            this.btnTim.Size = new System.Drawing.Size(120, 36);
            this.btnTim.TabIndex = 3;
            this.btnTim.Text = "Tìm";
            this.caplstKetQua.Name = "caplstKetQua";
            this.caplstKetQua.Location = new System.Drawing.Point(24, 182);
            this.caplstKetQua.Size = new System.Drawing.Size(145, 28);
            this.caplstKetQua.TabIndex = 4;
            this.caplstKetQua.Text = "Kết quả";
            this.lstKetQua.Name = "lstKetQua";
            this.lstKetQua.Location = new System.Drawing.Point(185, 180);
            this.lstKetQua.Size = new System.Drawing.Size(550, 170);
            this.lstKetQua.TabIndex = 5;
            this.lstKetQua.IntegralHeight = false;
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Location = new System.Drawing.Point(185, 355);
            this.lblSoLuong.Size = new System.Drawing.Size(550, 35);
            this.lblSoLuong.TabIndex = 6;
            this.lblSoLuong.Text = "Nhập từ khóa rồi bấm Tìm. Để trống để xem tất cả.";
            this.btnChon.Name = "btnChon";
            this.btnChon.Location = new System.Drawing.Point(24, 410);
            this.btnChon.Size = new System.Drawing.Size(120, 36);
            this.btnChon.TabIndex = 7;
            this.btnChon.Text = "Chọn";
            this.btnChon.Enabled = false;
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Location = new System.Drawing.Point(154, 410);
            this.btnHuy.Size = new System.Drawing.Size(120, 36);
            this.btnHuy.TabIndex = 8;
            this.btnHuy.Text = "Hủy";
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            this.btnChon.Click += new System.EventHandler(this.btnChon_Click);
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            this.lstKetQua.SelectedIndexChanged += new System.EventHandler(this.lstKetQua_SelectedIndexChanged);
            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.captxtTuKhoa);
            this.Controls.Add(this.txtTuKhoa);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.caplstKetQua);
            this.Controls.Add(this.lstKetQua);
            this.Controls.Add(this.lblSoLuong);
            this.Controls.Add(this.btnChon);
            this.Controls.Add(this.btnHuy);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F,17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Font = new System.Drawing.Font("Segoe UI",10F);
            this.ClientSize = new System.Drawing.Size(780,470);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.BackColor = System.Drawing.Color.White;
            this.Name = "frmTimKiem";
            this.Text = "Tìm kiếm sinh viên";
            this.AcceptButton = this.btnTim;
            this.CancelButton = this.btnHuy;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label captxtTuKhoa;
        private System.Windows.Forms.TextBox txtTuKhoa;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Label caplstKetQua;
        private System.Windows.Forms.ListBox lstKetQua;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.Button btnChon;
        private System.Windows.Forms.Button btnHuy;
    }
}

namespace Lab05_MultiForm
{
    partial class frmGioiThieu
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
            this.lblNoiDung = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.SuspendLayout();
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Location = new System.Drawing.Point(24, 20);
            this.lblTieuDe.Size = new System.Drawing.Size(730, 38);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "Giới thiệu Lab05";
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI",16F,System.Drawing.FontStyle.Bold);
            this.lblNoiDung.Name = "lblNoiDung";
            this.lblNoiDung.Location = new System.Drawing.Point(24, 90);
            this.lblNoiDung.Size = new System.Drawing.Size(720, 160);
            this.lblNoiDung.TabIndex = 1;
            this.lblNoiDung.Text = "Lê Tuấn Quang — 24000641\nLớp DCCNTT15.C.1\n\nLab05: Sự kiện, kiểm tra dữ liệu và ứng dụng đa Form.\nErrorProvider, MenuStrip, StatusStrip và truyền đối tượng qua constructor.\nDữ liệu được giữ trong bộ nhớ của lần chạy.";
            this.btnDong.Name = "btnDong";
            this.btnDong.Location = new System.Drawing.Point(24, 285);
            this.btnDong.Size = new System.Drawing.Size(120, 36);
            this.btnDong.TabIndex = 2;
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.lblNoiDung);
            this.Controls.Add(this.btnDong);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F,17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Font = new System.Drawing.Font("Segoe UI",10F);
            this.ClientSize = new System.Drawing.Size(780,360);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.BackColor = System.Drawing.Color.White;
            this.Name = "frmGioiThieu";
            this.Text = "Giới thiệu Lab05";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblNoiDung;
        private System.Windows.Forms.Button btnDong;
    }
}

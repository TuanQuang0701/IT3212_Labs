namespace Lab05_MultiForm
{
    partial class frmKhoa
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
            this.caplstKhoa = new System.Windows.Forms.Label();
            this.lstKhoa = new System.Windows.Forms.ListBox();
            this.btnDong = new System.Windows.Forms.Button();
            this.SuspendLayout();
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Location = new System.Drawing.Point(24, 20);
            this.lblTieuDe.Size = new System.Drawing.Size(730, 38);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "Danh mục khoa";
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI",16F,System.Drawing.FontStyle.Bold);
            this.caplstKhoa.Name = "caplstKhoa";
            this.caplstKhoa.Location = new System.Drawing.Point(24, 92);
            this.caplstKhoa.Size = new System.Drawing.Size(145, 28);
            this.caplstKhoa.TabIndex = 1;
            this.caplstKhoa.Text = "Các khoa hiện có";
            this.lstKhoa.Name = "lstKhoa";
            this.lstKhoa.Location = new System.Drawing.Point(185, 90);
            this.lstKhoa.Size = new System.Drawing.Size(550, 170);
            this.lstKhoa.TabIndex = 2;
            this.lstKhoa.IntegralHeight = false;
            this.btnDong.Name = "btnDong";
            this.btnDong.Location = new System.Drawing.Point(24, 285);
            this.btnDong.Size = new System.Drawing.Size(120, 36);
            this.btnDong.TabIndex = 3;
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.caplstKhoa);
            this.Controls.Add(this.lstKhoa);
            this.Controls.Add(this.btnDong);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F,17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Font = new System.Drawing.Font("Segoe UI",10F);
            this.ClientSize = new System.Drawing.Size(780,360);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.BackColor = System.Drawing.Color.White;
            this.Name = "frmKhoa";
            this.Text = "Danh mục khoa";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label caplstKhoa;
        private System.Windows.Forms.ListBox lstKhoa;
        private System.Windows.Forms.Button btnDong;
    }
}

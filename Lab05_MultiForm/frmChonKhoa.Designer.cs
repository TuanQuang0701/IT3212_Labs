namespace Lab05_MultiForm
{
    partial class frmChonKhoa
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
            this.btnChon = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Location = new System.Drawing.Point(24, 20);
            this.lblTieuDe.Size = new System.Drawing.Size(730, 38);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "Chọn khoa";
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI",16F,System.Drawing.FontStyle.Bold);
            this.caplstKhoa.Name = "caplstKhoa";
            this.caplstKhoa.Location = new System.Drawing.Point(24, 92);
            this.caplstKhoa.Size = new System.Drawing.Size(145, 28);
            this.caplstKhoa.TabIndex = 1;
            this.caplstKhoa.Text = "Danh sách khoa";
            this.lstKhoa.Name = "lstKhoa";
            this.lstKhoa.Location = new System.Drawing.Point(185, 90);
            this.lstKhoa.Size = new System.Drawing.Size(550, 165);
            this.lstKhoa.TabIndex = 2;
            this.lstKhoa.IntegralHeight = false;
            this.btnChon.Name = "btnChon";
            this.btnChon.Location = new System.Drawing.Point(24, 285);
            this.btnChon.Size = new System.Drawing.Size(120, 36);
            this.btnChon.TabIndex = 3;
            this.btnChon.Text = "Chọn";
            this.btnChon.Enabled = false;
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Location = new System.Drawing.Point(154, 285);
            this.btnHuy.Size = new System.Drawing.Size(120, 36);
            this.btnHuy.TabIndex = 4;
            this.btnHuy.Text = "Hủy";
            this.btnChon.Click += new System.EventHandler(this.btnChon_Click);
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            this.lstKhoa.SelectedIndexChanged += new System.EventHandler(this.lstKhoa_SelectedIndexChanged);
            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.caplstKhoa);
            this.Controls.Add(this.lstKhoa);
            this.Controls.Add(this.btnChon);
            this.Controls.Add(this.btnHuy);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F,17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Font = new System.Drawing.Font("Segoe UI",10F);
            this.ClientSize = new System.Drawing.Size(780,360);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.BackColor = System.Drawing.Color.White;
            this.Name = "frmChonKhoa";
            this.Text = "Chọn khoa";
            this.CancelButton = this.btnHuy;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label caplstKhoa;
        private System.Windows.Forms.ListBox lstKhoa;
        private System.Windows.Forms.Button btnChon;
        private System.Windows.Forms.Button btnHuy;
    }
}

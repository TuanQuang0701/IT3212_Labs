using System;
using System.Windows.Forms;
namespace Lab05_MultiForm
{
    public partial class frmDangNhap:Form
    {
        private readonly GioiHanDangNhap _gioiHan;
        public frmDangNhap():this(new GioiHanDangNhap()){}
        public frmDangNhap(GioiHanDangNhap gioiHan)
        {InitializeComponent();_gioiHan=gioiHan;CapNhatKhoa();timerKhoa.Start();}
        private void btnDangNhap_Click(object sender,EventArgs e)
        {
            if(_gioiHan.DangKhoa(DateTime.Now)){CapNhatKhoa();return;}
            if(string.IsNullOrWhiteSpace(txtTenDangNhap.Text)||txtMatKhau.Text.Length==0)
            {lblTrangThai.Text="Nhập đủ tên và mật khẩu.";return;}
            if(_gioiHan.Thu(txtTenDangNhap.Text,txtMatKhau.Text,DateTime.Now))
            {DialogResult=DialogResult.OK;Close();return;}
            lblTrangThai.Text="Sai tài khoản. Số lần sai: "+_gioiHan.SoLanSai+"/3.";CapNhatKhoa();
        }
        internal void CapNhatKhoa()
        {
            bool khoa=_gioiHan.DangKhoa(DateTime.Now);btnDangNhap.Enabled=!khoa;
            if(khoa)lblTrangThai.Text="Đã sai 3 lần. Khóa đăng nhập: "+_gioiHan.ConLai(DateTime.Now)+" giây.";
            else if(lblTrangThai.Text.StartsWith("Đã sai 3 lần"))lblTrangThai.Text="Hết thời gian khóa, có thể thử lại.";
        }
        private void timerKhoa_Tick(object sender,EventArgs e){CapNhatKhoa();}
        private void chkHienMatKhau_CheckedChanged(object sender,EventArgs e){txtMatKhau.UseSystemPasswordChar=!chkHienMatKhau.Checked;}
        private void btnHuy_Click(object sender,EventArgs e){DialogResult=DialogResult.Cancel;Close();}
    }
}

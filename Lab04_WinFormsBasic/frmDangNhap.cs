using System;
using System.Windows.Forms;

namespace Lab04_WinFormsBasic
{
    public class frmDangNhap : FormCoSo
    {
        private readonly TextBox txtTenDangNhap, txtMatKhau;
        private readonly CheckBox chkGhiNho, chkHienMatKhau;
        private readonly Label lblTrangThai;
        // Chỉ giữ tên đăng nhập trong phiên chạy, không ghi mật khẩu ra file.
        internal static string TenDaNho = "";
        public frmDangNhap() : base("Bài 7 — Form đăng nhập",460)
        {
            Name = "frmDangNhap";
            txtTenDangNhap=O("txtTenDangNhap",TenDaNho);txtMatKhau=O("txtMatKhau");txtMatKhau.UseSystemPasswordChar=true;
            chkGhiNho=new CheckBox { Name="chkGhiNho",Text="Ghi nhớ tên đăng nhập trong phiên",AutoSize=true,Checked=TenDaNho.Length>0 };
            chkHienMatKhau=new CheckBox { Name="chkHienMatKhau",Text="Hiện mật khẩu",AutoSize=true };
            lblTrangThai=KetQua("lblTrangThai");lblTrangThai.Text="Tài khoản thử: sinhvien / 123456";
            Hang("Tên đăng nhập",txtTenDangNhap);Hang("Mật khẩu",txtMatKhau);
            ThemRong(chkGhiNho);ThemRong(chkHienMatKhau);
            ThemRong(Nhom(Nut("btnDangNhap","Đăng nhập",DangNhap),Nut("btnDong","Đóng",Close)));
            ThemRong(lblTrangThai);
            chkHienMatKhau.CheckedChanged+=(s,e)=>txtMatKhau.UseSystemPasswordChar=!chkHienMatKhau.Checked;
            AcceptButton=(Button)Controls.Find("btnDangNhap",true)[0];
        }
        private void DangNhap()
        {
            if(string.IsNullOrWhiteSpace(txtTenDangNhap.Text)||txtMatKhau.Text.Length==0)
            {lblTrangThai.Text="Hãy nhập đủ tên đăng nhập và mật khẩu.";return;}
            if(txtTenDangNhap.Text.Trim()=="sinhvien" && txtMatKhau.Text=="123456")
            {
                TenDaNho=chkGhiNho.Checked?txtTenDangNhap.Text.Trim():"";
                lblTrangThai.Text="Đăng nhập thành công.";
            }
            else lblTrangThai.Text="Tên đăng nhập hoặc mật khẩu không đúng.";
        }
    }
}

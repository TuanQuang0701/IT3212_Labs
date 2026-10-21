using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab04_WinFormsBasic
{
    public class SanPham
    {
        public string Ma {get;set;}
        public string Ten {get;set;}
        public string Loai {get;set;}
        public int SoLuong {get;set;}
        public decimal DonGia {get;set;}
        public DateTime NgayNhap {get;set;}
        public string Anh {get;set;}
        public decimal ThanhTien()
        {
            if(string.IsNullOrWhiteSpace(Ma)||string.IsNullOrWhiteSpace(Ten)||string.IsNullOrWhiteSpace(Loai))
                throw new ArgumentException("Hãy nhập mã, tên và loại sản phẩm.");
            if(SoLuong<=0||DonGia<0)throw new ArgumentException("Số lượng phải dương, đơn giá không âm.");
            return SoLuong*DonGia;
        }
    }
    public class frmSanPham:FormCoSo
    {
        private readonly TextBox txtMaSP,txtTenSP,txtDonGia,txtDuongDanAnh;
        private readonly ComboBox cboLoai;
        private readonly NumericUpDown nudSoLuong;
        private readonly DateTimePicker dtpNgayNhap;
        private readonly PictureBox picAnh;
        private readonly Label lblPhieu;
        public frmSanPham():base("Bài 10 — Phiếu nhập sản phẩm",800)
        {
            Name="frmSanPham";
            txtMaSP=O("txtMaSP");txtTenSP=O("txtTenSP");txtDonGia=O("txtDonGia");
            txtDuongDanAnh=O("txtDuongDanAnh");txtDuongDanAnh.ReadOnly=true;
            cboLoai=new ComboBox {Name="cboLoai",DropDownStyle=ComboBoxStyle.DropDownList};
            cboLoai.Items.AddRange(new object[]{"Văn phòng phẩm","Điện tử","Thực phẩm"});cboLoai.SelectedIndex=0;
            nudSoLuong=new NumericUpDown {Name="nudSoLuong",Minimum=1,Maximum=1000000,Value=1};
            dtpNgayNhap=new DateTimePicker {Name="dtpNgayNhap",Format=DateTimePickerFormat.Custom,CustomFormat="dd/MM/yyyy",Value=DateTime.Today};
            picAnh=new PictureBox {Name="picAnh",SizeMode=PictureBoxSizeMode.Zoom,Size=new Size(180,125),BorderStyle=BorderStyle.FixedSingle};
            lblPhieu=KetQua("lblPhieu");
            Hang("Mã sản phẩm",txtMaSP);Hang("Tên sản phẩm",txtTenSP);Hang("Loại",cboLoai);Hang("Số lượng",nudSoLuong);
            Hang("Đơn giá (đồng)",txtDonGia);Hang("Ngày nhập",dtpNgayNhap);Hang("Ảnh",Nhom(picAnh));Hang("Đường dẫn",txtDuongDanAnh);
            ThemRong(Nhom(Nut("btnChonAnh","Chọn ảnh",()=>Anh.Chon(this,picAnh,txtDuongDanAnh)),
                Nut("btnLapPhieu","Lập phiếu",LapPhieu),Nut("btnLamMoi","Làm mới",LamMoi),Nut("btnDong","Đóng",Close)));
            Hang("Nội dung phiếu",lblPhieu);
        }
        private void LapPhieu()
        {
            lblPhieu.Text="Chưa có kết quả.";
            var sp=new SanPham {Ma=txtMaSP.Text.Trim(),Ten=txtTenSP.Text.Trim(),Loai=cboLoai.Text,
                SoLuong=(int)nudSoLuong.Value,DonGia=NghiepVu.DocSo(txtDonGia.Text),NgayNhap=dtpNgayNhap.Value,Anh=txtDuongDanAnh.Text};
            decimal tong=sp.ThanhTien();
            lblPhieu.Text=string.Format("{0} — {1}\nLoại: {2}; SL: {3}; Giá: {4:N0}\nNgày nhập: {5:dd/MM/yyyy}; Thành tiền: {6:N0} đồng\nẢnh: {7}",
                sp.Ma,sp.Ten,sp.Loai,sp.SoLuong,sp.DonGia,sp.NgayNhap,tong,sp.Anh.Length==0?"Chưa chọn":System.IO.Path.GetFileName(sp.Anh));
        }
        private void LamMoi()
        {
            txtMaSP.Clear();txtTenSP.Clear();txtDonGia.Clear();txtDuongDanAnh.Clear();cboLoai.SelectedIndex=0;
            nudSoLuong.Value=1;dtpNgayNhap.Value=DateTime.Today;lblPhieu.Text="Chưa có kết quả.";
            var cu=picAnh.Image;picAnh.Image=null;if(cu!=null)cu.Dispose();txtMaSP.Focus();
        }
        protected override void Dispose(bool disposing)
        {if(disposing&&picAnh!=null&&picAnh.Image!=null)picAnh.Image.Dispose();base.Dispose(disposing);}
    }
}

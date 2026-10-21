using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lab04_WinFormsBasic
{
    internal static class KiemThu
    {
        private static readonly List<string> log = new List<string>();
        private static int dat, loi;
        private static void Dung(bool dieuKien) { if (!dieuKien) throw new Exception("Kết quả không đúng."); }
        private static void Sai(Action a)
        {try{a();}catch(ArgumentException){return;}throw new Exception("Dữ liệu sai chưa bị từ chối.");}
        private static void Thu(string ten,Action a)
        {try{a();dat++;log.Add("ĐẠT: "+ten);}catch(Exception ex){loi++;log.Add("LỖI: "+ten+" — "+ex.Message);}}
        private static T C<T>(Form f,string ten) where T:Control {return (T)f.Controls.Find(ten,true).Single();}
        private static void Bam(Form f,string ten){C<Button>(f,ten).PerformClick();Application.DoEvents();}
        private static void Mo(Form f)
        {
            f.StartPosition=FormStartPosition.Manual;f.Location=new Point(-20000,-20000);f.ShowInTaskbar=false;
            f.Show();Application.DoEvents();f.PerformLayout();
        }
        private static void Luu(Form f,string outDir,string name)
        {
            f.PerformLayout();Application.DoEvents();
            using(var b=new Bitmap(f.Width,f.Height))
            {f.DrawToBitmap(b,new Rectangle(0,0,b.Width,b.Height));b.Save(Path.Combine(outDir,name+".png"),ImageFormat.Png);}
        }
        internal static int Chay(string duongDan)
        {
            string outDir=Path.GetFullPath(duongDan);Directory.CreateDirectory(outDir);
            dat=loi=0;log.Clear();ThongBao.CheDoKiemThu=true;
            Thu("Tính tuổi trước sinh nhật",()=>Dung(NghiepVu.TinhTuoi(new DateTime(2005,12,1),new DateTime(2026,10,21))==20));
            Thu("Tính tuổi đúng sinh nhật",()=>Dung(NghiepVu.TinhTuoi(new DateTime(2005,10,21),new DateTime(2026,10,21))==21));
            Thu("Từ chối ngày sinh tương lai",()=>Sai(()=>NghiepVu.TinhTuoi(DateTime.Today.AddDays(1),DateTime.Today)));
            Thu("SinhVien từ chối tên rỗng",()=>Sai(()=>new SinhVien("S"," ",new DateTime(2005,1,1),8)));
            Thu("SinhVien từ chối điểm sai",()=>Sai(()=>new SinhVien("S","An",new DateTime(2005,1,1),11)));
            Thu("Bốn phép tính",()=>Dung(NghiepVu.Tinh(8,2,"+")==10&&NghiepVu.Tinh(8,2,"-")==6&&NghiepVu.Tinh(8,2,"×")==16&&NghiepVu.Tinh(8,2,"÷")==4));
            Thu("Chia cho 0",()=>Sai(()=>NghiepVu.Tinh(1,0,"÷")));
            Thu("Số thập phân dấu phẩy",()=>Dung(NghiepVu.DocSo("1,5")==1.5m));
            Thu("Số nhập chữ bị từ chối",()=>Sai(()=>NghiepVu.DocSo("abc")));
            Thu("BMI 170 cm và 65 kg",()=>Dung(Math.Abs(NghiepVu.TinhBmi(170,65)-22.491349)<.00001));
            Thu("BMI không nhận chiều cao 0",()=>Sai(()=>NghiepVu.TinhBmi(0,65)));
            Thu("BMI không nhận cân nặng âm",()=>Sai(()=>NghiepVu.TinhBmi(170,-1)));
            Thu("Phân loại BMI tại các mốc",()=>Dung(NghiepVu.PhanLoaiBmi(18.49)=="Thiếu cân"&&NghiepVu.PhanLoaiBmi(18.5)=="Bình thường"&&NghiepVu.PhanLoaiBmi(25)=="Thừa cân"&&NghiepVu.PhanLoaiBmi(30)=="Béo phì"));
            string anh=Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Images","avatar_xanh.png");
            Thu("Đọc ảnh PNG mẫu",()=>{using(var a=Anh.Doc(anh))Dung(a.Width>0);});
            Thu("Ảnh không tồn tại",()=>Sai(()=>Anh.Doc(Path.Combine(outDir,"khongco.png"))));
            string gia=Path.Combine(outDir,"khongphai_anh.png");File.WriteAllText(gia,"not an image");
            Thu("Từ chối tệp giả ảnh",()=>Sai(()=>Anh.Doc(gia)));
            using(var f=new frmMain())
            {
                Mo(f);Thu("Menu có đủ 10 bài",()=>Dung(Enumerable.Range(1,10).All(i=>f.Controls.Find("btnBai"+i,true).Length==1 && C<Button>(f,"btnBai"+i).Height<=50)));
                Luu(f,outDir,"00_Menu");
            }
            using(var f=new frmSinhVien())
            {
                Mo(f);
                Thu("Bài 2 Load nạp 3 khoa, mặc định khoa đầu và Nam",()=>Dung(C<ComboBox>(f,"cboKhoa").Items.Count==3&&C<ComboBox>(f,"cboKhoa").SelectedIndex==0&&C<RadioButton>(f,"radNam").Checked));
                Thu("Bài 1 Hiển thị thông tin",()=>{Bam(f,"btnHienThi");Dung(ThongBao.Cuoi.Contains("SV01")&&ThongBao.Cuoi.Contains("Nguyễn An"));log.Add(ThongBao.Cuoi);});
                Thu("Bài 3 Đổi ngày cập nhật tuổi",()=>{C<DateTimePicker>(f,"dtpNgaySinh").Value=DateTime.Today.AddYears(-20);Dung(C<Label>(f,"lblTuoi").Text=="Tuổi: 20");});
                Thu("Bài 4 Chưa chọn sở thích",()=>{Bam(f,"btnSoThich");Dung(C<Label>(f,"lblSoThich").Text=="Chưa chọn");});
                Thu("Bài 4 Chọn Đọc sách và Lập trình",()=>{C<CheckBox>(f,"chkDocSach").Checked=true;C<CheckBox>(f,"chkLapTrinh").Checked=true;Bam(f,"btnSoThich");Dung(C<Label>(f,"lblSoThich").Text=="Đọc sách, Lập trình");});
                Thu("RadioButton chỉ chọn một giới tính",()=>{C<RadioButton>(f,"radNu").Checked=true;Dung(!C<RadioButton>(f,"radNam").Checked);});
                Thu("Bài 5 PictureBox Zoom và thay ảnh",()=>{var box=C<PictureBox>(f,"picAnh");Anh.Gan(box,anh);C<TextBox>(f,"txtDuongDanAnh").Text=anh;Dung(box.Image!=null&&box.SizeMode==PictureBoxSizeMode.Zoom);Anh.Gan(box,anh);});
                Luu(f,outDir,"01_05_SinhVien");
                Thu("Bài 1 Từ chối tên rỗng",()=>{C<TextBox>(f,"txtHoTen").Clear();Bam(f,"btnHienThi");Dung(ThongBao.Cuoi.Contains("Họ tên"));});
            }
            using(var f=new frmMayTinh())
            {
                Mo(f);C<TextBox>(f,"txtSoA").Text="8";C<TextBox>(f,"txtSoB").Text="2";
                Thu("Bài 6 Bấm chia ra 4",()=>{Bam(f,"btnChia");Dung(C<Label>(f,"lblKetQua").Text.EndsWith("= 4"));log.Add(C<Label>(f,"lblKetQua").Text);});
                Luu(f,outDir,"06_MayTinh");
                Thu("Bài 6 UI chia 0",()=>{C<TextBox>(f,"txtSoB").Text="0";Bam(f,"btnChia");Dung(ThongBao.Cuoi.Contains("chia cho 0"));});
                Thu("Bài 6 Làm mới",()=>{Bam(f,"btnLamMoi");Dung(C<TextBox>(f,"txtSoA").Text==""&&C<TextBox>(f,"txtSoB").Text=="");});
            }
            using(var f=new frmDangNhap())
            {
                Mo(f);Thu("Bài 7 Mật khẩu ẩn mặc định",()=>Dung(C<TextBox>(f,"txtMatKhau").UseSystemPasswordChar));
                Thu("Bài 7 Hiện mật khẩu",()=>{C<CheckBox>(f,"chkHienMatKhau").Checked=true;Dung(!C<TextBox>(f,"txtMatKhau").UseSystemPasswordChar);C<CheckBox>(f,"chkHienMatKhau").Checked=false;});
                Thu("Bài 7 Thiếu thông tin",()=>{Bam(f,"btnDangNhap");Dung(C<Label>(f,"lblTrangThai").Text.Contains("nhập đủ"));});
                C<TextBox>(f,"txtTenDangNhap").Text="sinhvien";C<TextBox>(f,"txtMatKhau").Text="sai";
                Thu("Bài 7 Sai mật khẩu",()=>{Bam(f,"btnDangNhap");Dung(C<Label>(f,"lblTrangThai").Text.Contains("không đúng"));});
                C<TextBox>(f,"txtMatKhau").Text="123456";C<CheckBox>(f,"chkGhiNho").Checked=true;
                Thu("Bài 7 Đăng nhập và ghi nhớ",()=>{Bam(f,"btnDangNhap");Dung(frmDangNhap.TenDaNho=="sinhvien"&&C<Label>(f,"lblTrangThai").Text.Contains("thành công"));});
                Luu(f,outDir,"07_DangNhap");
            }
            using(var f=new frmDangNhap()){Mo(f);Thu("Bài 7 Mở lại nhớ tên, không nhớ mật khẩu",()=>Dung(C<TextBox>(f,"txtTenDangNhap").Text=="sinhvien"&&C<TextBox>(f,"txtMatKhau").Text==""));}
            using(var f=new frmBmi())
            {
                Mo(f);C<TextBox>(f,"txtChieuCao").Text="170";C<TextBox>(f,"txtCanNang").Text="65";
                Thu("Bài 8 UI tính BMI",()=>{Bam(f,"btnTinhBmi");Dung(C<Label>(f,"lblKetQua").Text.Contains("Bình thường"));log.Add(C<Label>(f,"lblKetQua").Text);});
                Luu(f,outDir,"08_BMI");
            }
            using(var f=new frmHocPhan())
            {
                Mo(f);var list=C<CheckedListBox>(f,"clbHocPhan");
                Thu("Bài 9 Không chọn học phần",()=>{Bam(f,"btnDangKy");Dung(C<Label>(f,"lblDaChon").Text.Contains("ít nhất"));});
                Thu("Bài 9 Tổng tự cập nhật sau ItemCheck",()=>{list.SetItemChecked(0,true);list.SetItemChecked(2,true);Dung(C<Label>(f,"lblTongTinChi").Text=="5 tín chỉ");Bam(f,"btnDangKy");Dung(C<Label>(f,"lblDaChon").Text.Contains("Tiếng Anh"));});
                Luu(f,outDir,"09_HocPhan");
                Thu("Bài 9 Bỏ chọn về 0",()=>{Bam(f,"btnBoChon");Dung(list.CheckedItems.Count==0&&C<Label>(f,"lblTongTinChi").Text=="0 tín chỉ");});
            }
            using(var f=new frmSanPham())
            {
                Mo(f);C<TextBox>(f,"txtMaSP").Text="SP01";C<TextBox>(f,"txtTenSP").Text="Bút bi";C<TextBox>(f,"txtDonGia").Text="5000";C<NumericUpDown>(f,"nudSoLuong").Value=3;
                Thu("Bài 10 Lập phiếu",()=>{Bam(f,"btnLapPhieu");Dung(C<Label>(f,"lblPhieu").Text.Contains("SP01")&&C<Label>(f,"lblPhieu").Text.Contains(15000m.ToString("N0")));log.Add(C<Label>(f,"lblPhieu").Text);});
                Anh.Gan(C<PictureBox>(f,"picAnh"),anh);C<TextBox>(f,"txtDuongDanAnh").Text=anh;Bam(f,"btnLapPhieu");
                Luu(f,outDir,"10_SanPham");
                Thu("Bài 10 Giá âm",()=>{C<TextBox>(f,"txtDonGia").Text="-1";Bam(f,"btnLapPhieu");Dung(ThongBao.Cuoi.Contains("đơn giá"));});
                Thu("Bài 10 Làm mới xóa ảnh và dữ liệu",()=>{Bam(f,"btnLamMoi");Dung(C<TextBox>(f,"txtMaSP").Text==""&&C<PictureBox>(f,"picAnh").Image==null);});
            }
            log.Add(string.Format("Tổng kết: {0} đạt, {1} lỗi.",dat,loi));
            log.Add("Ảnh PNG được dựng từ các Form và control thật bằng DrawToBitmap. Hộp thoại thông báo được chặn trong chế độ kiểm thử để không chờ bấm OK.");
            log.Add("OpenFileDialog chọn tệp và thao tác đóng cửa sổ cần thử trực tiếp; kiểm thử tự động kiểm tra phần đọc/thay ảnh phía sau hộp thoại.");
            File.WriteAllLines(Path.Combine(outDir,"Ket_qua_chay_thu.txt"),log,new UTF8Encoding(true));
            return loi==0?0:1;
        }
    }
}

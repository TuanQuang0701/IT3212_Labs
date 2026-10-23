using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
namespace Lab05_MultiForm
{
    internal static class KiemThu
    {
        private static int dat,loi;
        private static readonly List<string> log=new List<string>();
        private static void Dung(bool x){if(!x)throw new Exception("Kết quả sai");}
        private static void Thu(string ten,Action a)
        {try{a();dat++;log.Add("ĐẠT: "+ten);}catch(Exception ex){loi++;log.Add("LỖI: "+ten+" — "+ex.GetBaseException().Message);}}
        private static T C<T>(Form f,string name)where T:Control{return(T)f.Controls.Find(name,true).Single();}
        private static object Field(object x,string name){return x.GetType().GetField(name,BindingFlags.Instance|BindingFlags.NonPublic).GetValue(x);}
        private static object Call(object x,string name,params object[] args){return x.GetType().GetMethod(name,BindingFlags.Instance|BindingFlags.NonPublic).Invoke(x,args);}
        private static void Bam(Form f,string name){C<Button>(f,name).PerformClick();Application.DoEvents();}
        private static void Mo(Form f){f.StartPosition=FormStartPosition.Manual;f.Location=new Point(-20000,-20000);f.ShowInTaskbar=false;f.Show();Application.DoEvents();}
        private static void Anh(Form f,string path,string name)
        {f.PerformLayout();using(var b=new Bitmap(f.Width,f.Height)){f.DrawToBitmap(b,new Rectangle(0,0,b.Width,b.Height));b.Save(Path.Combine(path,name+".png"),ImageFormat.Png);}}
        internal static int Chay(string dir)
        {
            Directory.CreateDirectory(dir);HopThoai.KiemThu=true;dat=loi=0;log.Clear();
            Thu("Điểm biên 0 và 10",()=>{double x;Dung(KiemTra.DocDiem("0",out x)&&KiemTra.DocDiem("10",out x));});
            foreach(string s in new[]{"-1","11","NaN","Infinity","8.2.3","abc",""})Thu("Từ chối điểm "+s,()=>{double x;Dung(!KiemTra.DocDiem(s,out x));});
            Thu("Điểm dấu phẩy",()=>{double x;Dung(KiemTra.DocDiem("8,5",out x)&&x==8.5);});
            Thu("KeyPress chặn chữ",()=>Dung(!KiemTra.ChoPhepKyTu("8",1,0,'a')));
            Thu("KeyPress chặn dấu thập phân thứ hai",()=>Dung(!KiemTra.ChoPhepKyTu("8.2",3,0,',')));
            Thu("KeyPress cho thay dấu đang chọn",()=>Dung(KiemTra.ChoPhepKyTu("8.2",1,1,',')));
            Thu("KeyPress cho Backspace",()=>Dung(KiemTra.ChoPhepKyTu("8",1,0,'\b')));
            Thu("Tìm mã và tên không phân biệt hoa thường",()=>{var d=DuLieu.TaoMau();Dung(d.Tim("sv01").Count==1&&d.Tim("bình").Count==1&&d.Tim("zzzz").Count==0);});
            Thu("Không lưu mã trùng",()=>{var d=DuLieu.TaoMau();bool loiTrung=false;try{d.Them(new SinhVien("sv01","An",new DateTime(2005,1,1),"Nam",d.Khoas[0],8));}catch(ArgumentException){loiTrung=true;}Dung(loiTrung&&d.SinhViens.Count==3);});
            Thu("Khóa đúng lần thứ 3, mở đúng sau 30 giây",()=>
            {
                var g=new GioiHanDangNhap();DateTime now=new DateTime(2026,10,23,12,0,0);
                g.Thu("sinhvien","sai",now);g.Thu("sinhvien","sai",now);Dung(!g.DangKhoa(now));
                g.Thu("sinhvien","sai",now);Dung(g.DangKhoa(now.AddSeconds(29))&&!g.Thu("sinhvien","123456",now.AddSeconds(29)));
                Dung(g.Thu("sinhvien","123456",now.AddSeconds(30))&&g.SoLanSai==0);
            });
            var data=DuLieu.TaoMau();
            using(var f=new frmSinhVien(data))
            {
                Mo(f);var ep=(ErrorProvider)Field(f,"errorProvider1");
                Thu("Bài 1 ErrorProvider mã và tên rỗng",()=>{Bam(f,"btnLuu");Dung(ep.GetError(C<TextBox>(f,"txtMaSV")).Length>0&&ep.GetError(C<TextBox>(f,"txtHoTen")).Length>0&&data.SinhViens.Count==3);});
                C<TextBox>(f,"txtMaSV").Text="SV04";C<TextBox>(f,"txtHoTen").Text="Test An";C<TextBox>(f,"txtDiemTB").Text="11";
                Thu("Bài 2 Dán điểm 11 không lưu được",()=>{Bam(f,"btnLuu");Dung(ep.GetError(C<TextBox>(f,"txtDiemTB")).Length>0&&data.SinhViens.Count==3);});
                Thu("Bài 2 Handler KeyPress thực tế",()=>{var e=new KeyPressEventArgs('x');Call(f,"txtDiemTB_KeyPress",C<TextBox>(f,"txtDiemTB"),e);Dung(e.Handled);});
                C<TextBox>(f,"txtDiemTB").Text="8.5";
                Thu("Bài 3 Xem trước và trạng thái tự cập nhật",()=>Dung(C<Label>(f,"lblXemTruoc").Text.Contains("Test An")&&C<Label>(f,"lblTrangThai").Text.Contains("hợp lệ")));
                Thu("Bài 1 Lưu hợp lệ và xóa lỗi cũ",()=>{Bam(f,"btnLuu");Dung(data.SinhViens.Count==4&&ep.GetError(C<TextBox>(f,"txtHoTen"))=="");});
                Thu("Bài 1 Mã trùng báo lỗi tại control",()=>{Bam(f,"btnLuu");Dung(data.SinhViens.Count==4&&ep.GetError(C<TextBox>(f,"txtMaSV")).Contains("tồn tại"));});
                Thu("SelectedIndexChanged cập nhật khoa",()=>{C<ComboBox>(f,"cboKhoa").SelectedIndex=2;Dung(C<Label>(f,"lblKhoaDaChon").Text.Contains("Kinh tế"));});
                Anh(f,dir,"01_03_SinhVien");log.Add("Đã lưu Test An, SV04, 8.5 vào cùng kho dữ liệu; danh sách 4 sinh viên.");
            }
            using(var f=new frmChiTietSinhVien(data.SinhViens[0]))
            {Mo(f);Thu("Bài 4 Truyền đối tượng qua constructor",()=>Dung(C<Label>(f,"lblMa").Text=="SV01"&&C<Label>(f,"lblHoTen").Text=="Nguyễn An"));Anh(f,dir,"04_ChiTiet");}
            using(var f=new frmTimKiem(data))
            {
                Mo(f);C<TextBox>(f,"txtTuKhoa").Text="sv04";Bam(f,"btnTim");
                Thu("Bài 7 Kết quả lọc và chọn",()=>{Dung(C<ListBox>(f,"lstKetQua").Items.Count==1);C<ListBox>(f,"lstKetQua").SelectedIndex=0;Dung(C<Button>(f,"btnChon").Enabled);});
                Anh(f,dir,"07_TimKiem");
                Thu("Bài 7 Trả property và DialogResult OK",()=>{Bam(f,"btnChon");Dung(f.DialogResult==DialogResult.OK&&f.KetQua.MaSV=="SV04");});
            }
            using(var f=new frmTimKiem(data))
            {Mo(f);C<TextBox>(f,"txtTuKhoa").Text="zzzz";Bam(f,"btnTim");Thu("Bài 7 Không có kết quả không cho chọn",()=>Dung(C<ListBox>(f,"lstKetQua").Items.Count==0&&!C<Button>(f,"btnChon").Enabled));Bam(f,"btnHuy");Thu("Bài 7 Hủy không trả dữ liệu",()=>Dung(f.DialogResult==DialogResult.Cancel&&f.KetQua==null));}
            using(var f=new frmChonKhoa(data.Khoas,data.Khoas[0]))
            {Mo(f);C<ListBox>(f,"lstKhoa").SelectedIndex=2;Anh(f,dir,"08_ChonKhoa");Thu("Bài 8 Trả khoa qua property",()=>{Bam(f,"btnChon");Dung(f.DialogResult==DialogResult.OK&&f.KhoaDaChon=="Kinh tế");});}
            using(var f=new frmChonKhoa(new string[0],"")){Mo(f);Thu("Bài 8 Danh sách khoa rỗng",()=>Dung(!C<Button>(f,"btnChon").Enabled));}
            var limit=new GioiHanDangNhap();
            using(var f=new frmDangNhap(limit))
            {
                Mo(f);C<TextBox>(f,"txtTenDangNhap").Text="sinhvien";C<TextBox>(f,"txtMatKhau").Text="sai";
                Bam(f,"btnDangNhap");Bam(f,"btnDangNhap");Bam(f,"btnDangNhap");
                Thu("Bài 6 UI khóa nút sau 3 lần sai",()=>Dung(!C<Button>(f,"btnDangNhap").Enabled&&C<Label>(f,"lblTrangThai").Text.Contains("Khóa")));
                Anh(f,dir,"06_DangNhapKhoa");
            }
            using(var f=new frmDangNhap(limit)){Mo(f);Thu("Bài 6 Mở lại không bỏ qua khóa",()=>Dung(!C<Button>(f,"btnDangNhap").Enabled));}
            using(var f=new frmDangNhap())
            {Mo(f);C<TextBox>(f,"txtTenDangNhap").Text="sinhvien";C<TextBox>(f,"txtMatKhau").Text="123456";Bam(f,"btnDangNhap");Thu("Bài 6 Đúng tài khoản trả OK",()=>Dung(f.DialogResult==DialogResult.OK));}
            using(var f=new frmMain(data))
            {
                Mo(f);f.OpenChildForm(new frmSinhVien(data));f.OpenChildForm(new frmSinhVien(data));
                Thu("Bài 5 Không mở trùng Form MDI",()=>Dung(f.MdiChildren.Length==1));
                f.OpenChildForm(new frmKhoa(data.Khoas));f.OpenChildForm(new frmGioiThieu());
                Thu("Bài 10 Ba Form chức năng",()=>Dung(f.MdiChildren.Length==3));
                Thu("Bài 10 Menu và StatusStrip",()=>Dung(Field(f,"menuStrip1") is MenuStrip&&Field(f,"statusStrip1") is StatusStrip));
                Thu("Bài 10 Đồng hồ có giây",()=>Dung(((ToolStripStatusLabel)Field(f,"lblDongHo")).Text.Length>=19&&((Timer)Field(f,"timerDongHo")).Enabled));
                foreach(Form child in f.MdiChildren)child.Close();f.OpenChildForm(new frmSinhVien(data));Anh(f,dir,"05_10_Dashboard");
                Thu("Bài 9 Chọn No hủy đóng",()=>{HopThoai.TraLoi=DialogResult.No;f.Close();Application.DoEvents();Dung(!f.IsDisposed&&f.Visible);});
                Thu("Bài 9 Chọn Yes đóng ứng dụng",()=>{HopThoai.TraLoi=DialogResult.Yes;f.Close();Application.DoEvents();Dung(f.IsDisposed);});
            }
            using(var f=new frmGioiThieu()){Mo(f);Anh(f,dir,"10_GioiThieu");}
            log.Add(string.Format("Tổng kết: {0} đạt, {1} lỗi.",dat,loi));
            log.Add("Ảnh PNG dựng từ control thật bằng DrawToBitmap; MessageBox xác nhận được thay bằng câu trả lời Yes/No trong chế độ --test.");
            log.Add("Khóa 30 giây được kiểm tra bằng mốc thời gian xác định; UI kiểm tra nút bị khóa, timer hoạt động. Không phải chờ thật 30 giây trong bộ tự động.");
            File.WriteAllLines(Path.Combine(dir,"Ket_qua_chay_thu.txt"),log,new UTF8Encoding(true));return loi==0?0:1;
        }
    }
}

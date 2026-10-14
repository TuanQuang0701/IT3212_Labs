namespace Lab02_OOPBasics;

internal static class KiemThu
{
    static int dat, loi;
    static void Thu(string ten, Action test)
    {
        try { test(); dat++; Console.WriteLine("ĐẠT: " + ten); }
        catch (Exception ex) { loi++; Console.WriteLine("LỖI: " + ten + " - " + ex.Message); }
    }
    static void Dung(bool dk) { if (!dk) throw new Exception("Sai kết quả"); }
    static void Loi<T>(Action a) where T : Exception
    {
        try { a(); } catch (T) { return; }
        throw new Exception("Chưa từ chối dữ liệu sai");
    }
    public static void Chay()
    {
        dat = loi = 0;
        Thu("Constructor mặc định", () => { var s = new SinhVien(); Dung(s.HoTen.Length > 0 && s.DiemTB == 0); });
        Thu("Constructor đầy đủ và bỏ khoảng trắng", () => { var s = new SinhVien(" A ", " An ", new(2005,1,1),8); Dung(s.MaSV == "A" && s.HoTen == "An"); });
        Thu("Họ tên rỗng", () => Loi<ArgumentException>(() => new SinhVien().HoTen = " "));
        Thu("Mã rỗng", () => Loi<ArgumentException>(() => new SinhVien().MaSV = ""));
        foreach (double x in new[] { -1, 10.1, double.NaN, double.PositiveInfinity })
            Thu("Điểm không hợp lệ " + x, () => Loi<ArgumentException>(() => new SinhVien().DiemTB = x));
        Thu("Ngày sinh tương lai", () => Loi<ArgumentException>(() => new SinhVien().NgaySinh = DateTime.Today.AddDays(1)));
        Thu("Tuổi đúng ngày sinh", () => Dung(new SinhVien("A","An",DateTime.Today.AddYears(-20),8).TinhTuoi() == 20));
        Thu("Tuổi chưa đến sinh nhật", () => Dung(new SinhVien("A","An",DateTime.Today.AddYears(-20).AddDays(1),8).TinhTuoi() == 19));
        foreach (var (diem, loai) in new[] { (0d,"Yếu"), (4.99,"Yếu"), (5d,"Trung bình"), (6.5,"Khá"), (8d,"Giỏi"), (9d,"Xuất sắc"), (10d,"Xuất sắc") })
            Thu("Xếp loại tại " + diem, () => Dung(new SinhVien("A","An",new(2005,1,1),diem).XepLoai() == loai));
        Thu("Năm sinh viên và tìm không phân biệt hoa thường", () => { var q = QuanLySinhVien.TaoDuLieuMau(); Dung(q.DanhSach.Count == 5 && q.TimTheoMa(" sv01 ") != null && q.TimTheoMa("X") == null); });
        Thu("Thêm và từ chối mã trùng", () => { var q = QuanLySinhVien.TaoDuLieuMau(); q.Them(new("SV06","An",new(2005,1,1),8)); Loi<ArgumentException>(() => q.Them(new("sv06","Bình",new(2005,1,1),7))); Dung(q.DanhSach.Count == 6); });
        Thu("Sửa hợp lệ và sửa sai không đổi dữ liệu", () => { var q = QuanLySinhVien.TaoDuLieuMau(); q.Sua("SV01","Tên mới",new(2005,1,1),8); Loi<ArgumentException>(() => q.Sua("SV01","Sai",new(2005,1,1),11)); Dung(q.TimTheoMa("SV01")!.HoTen == "Tên mới"); });
        Thu("Xóa và xóa mã không có", () => { var q = QuanLySinhVien.TaoDuLieuMau(); Dung(q.Xoa("sv01") && !q.Xoa("sv01") && q.DanhSach.Count == 4); });
        Thu("Sắp xếp điểm giảm dần", () => { var q = QuanLySinhVien.TaoDuLieuMau(); q.SapXep(true); Dung(q.DanhSach.First().DiemTB == 9.2 && q.DanhSach.Last().DiemTB == 4); });
        Thu("Sắp xếp họ tên", () => { var q = QuanLySinhVien.TaoDuLieuMau(); q.SapXep(false); for(int i=1;i<q.DanhSach.Count;i++) Dung(string.Compare(q.DanhSach[i-1].HoTen,q.DanhSach[i].HoTen,StringComparison.CurrentCultureIgnoreCase)<=0); });
        Thu("Thống kê danh sách rỗng", () => new QuanLySinhVien().ThongKe());
        Thu("Thành tiền sản phẩm", () => Dung(new SanPham("P1","Bút",5000,3).ThanhTien() == 15000));
        Thu("Giá âm", () => Loi<ArgumentException>(() => new SanPham("P1","Bút",-1,3)));
        Thu("Số lượng âm", () => Loi<ArgumentException>(() => new SanPham("P1","Bút",1,-1)));
        Thu("Nạp rút chuyển tiền", () => { var a=new TaiKhoanNganHang("A","An",1000); var b=new TaiKhoanNganHang("B","Bình",500); a.NapTien(200); a.RutTien(100); a.ChuyenTien(b,300); Dung(a.SoDu==800 && b.SoDu==800); });
        Thu("Không đủ số dư giữ nguyên hai tài khoản", () => { var a=new TaiKhoanNganHang("A","An",100); var b=new TaiKhoanNganHang("B","Bình",50); Loi<InvalidOperationException>(()=>a.ChuyenTien(b,200)); Dung(a.SoDu==100 && b.SoDu==50); });
        Thu("Rút quá số dư", () => Loi<InvalidOperationException>(()=>new TaiKhoanNganHang("A","An",1).RutTien(2)));
        Thu("Tiền giao dịch không dương", () => { var a=new TaiKhoanNganHang("A","An"); Loi<ArgumentException>(()=>a.NapTien(0)); Loi<ArgumentException>(()=>a.RutTien(-1)); });
        Thu("Không chuyển chính mình", () => { var a=new TaiKhoanNganHang("A","An",10); Loi<ArgumentException>(()=>a.ChuyenTien(a,1)); });
        Thu("Tràn số khi chuyển giữ nguyên số dư", () => { var a=new TaiKhoanNganHang("A","An",10); var b=new TaiKhoanNganHang("B","Bình",decimal.MaxValue); Loi<OverflowException>(()=>a.ChuyenTien(b,1)); Dung(a.SoDu==10 && b.SoDu==decimal.MaxValue); });
        Thu("Tính lương", () => Dung(new NhanVien("N","An",5000000,2,500000).TinhLuong()==10500000));
        Thu("Hệ số không dương", () => Loi<ArgumentException>(()=>new NhanVien("N","An",5000000,0,0)));
        Thu("Hình chữ nhật", () => { var h=new HinhChuNhat(3,4); Dung(h.ChuVi()==14 && h.DienTich()==12 && new HinhChuNhat().DienTich()==1); });
        Thu("Cạnh không hợp lệ", () => { Loi<ArgumentException>(()=>new HinhChuNhat(0,4)); Loi<ArgumentException>(()=>new HinhChuNhat(double.NaN,4)); });
        Console.WriteLine($"Tổng kết: {dat} đạt, {loi} lỗi.");
        Environment.ExitCode = loi == 0 ? 0 : 1;
    }
}

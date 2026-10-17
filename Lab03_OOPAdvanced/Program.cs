using System.Globalization;
using System.Text;
namespace Lab03_OOPAdvanced;

internal static class Program
{
    // Dùng chung cho menu và các bài nhập dữ liệu.
    static string Nhap(string nhan)
    { Console.Write(nhan); return Console.ReadLine() ?? throw new EndOfStreamException(); }
    static int Chon(string nhan, int min, int max)
    {
        while (true)
        {
            if (int.TryParse(Nhap(nhan), out int x) && x >= min && x <= max) return x;
            Console.WriteLine($"Nhập số nguyên từ {min} đến {max}.");
        }
    }
    static double So(string nhan)
    {
        while (true)
        {
            if (double.TryParse(Nhap(nhan).Replace(',', '.'), NumberStyles.Float,
                CultureInfo.InvariantCulture, out double x) && double.IsFinite(x)) return x;
            Console.WriteLine("Số không hợp lệ.");
        }
    }
    static decimal Tien(string nhan)
    {
        while (true)
        {
            if (decimal.TryParse(Nhap(nhan).Replace(',', '.'), NumberStyles.AllowDecimalPoint |
                NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out decimal x)) return x;
            Console.WriteLine("Nhập số tiền không có dấu phân cách hàng nghìn.");
        }
    }
    static DateTime Ngay()
    {
        while (true)
        {
            if (DateTime.TryParseExact(Nhap("Ngày sinh dd/MM/yyyy: "), "dd/MM/yyyy",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime d)) return d;
            Console.WriteLine("Ngày không hợp lệ.");
        }
    }
    static SinhVien NhapSV() => new(Nhap("Mã SV: "), Nhap("Họ tên: "), Ngay(), So("Điểm TB: "));
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8; Console.InputEncoding = Encoding.UTF8;
        if (args.Contains("--test")) { KiemThu.Chay(); return; }
        var ql = QuanLySinhVien.TaoMau();
        try
        {
            int chon;
            do
            {
                Console.WriteLine("\nLAB 03 - OOP NÂNG CAO\n1. Kế thừa Người - Sinh viên\n2. Ghi đè phương thức\n3. Lớp trừu tượng và học phí\n4. Interface kiểm tra và in\n5. Danh sách đa hình\n6. Hệ thống nhân viên\n7. Phương tiện\n8. Thư viện\n9. Thanh toán\n10. Quản lý sinh viên\n0. Thoát");
                chon = Chon("Chọn: ", 0, 10);
                try
                {
                    switch (chon)
                    {
                        case 1:
                            var sv = new SinhVien("SV01", "Nguyễn An", new(2005,5,12),8.2);
                            Console.WriteLine($"Kế thừa HoTen: {sv.HoTen}; NgaySinh: {sv.NgaySinh:dd/MM/yyyy}");
                            Console.WriteLine($"Mã: {sv.MaSV}; Điểm: {sv.DiemTB}; Tuổi: {sv.TinhTuoi()}"); break;
                        case 2:
                            Nguoi[] nguoi = { new Nguoi("Người mẫu",new(2000,1,1)), new SinhVien("SV01","Nguyễn An",new(2005,5,12),8.2) };
                            foreach (Nguoi n in nguoi) Console.WriteLine(n.MoTa()); break;
                        case 3:
                            int tc = Chon("Số tín chỉ: ",0,100);
                            NguoiHoc cq = new SinhVienChinhQuy("CQ","An",new(2005,1,1),8,tc);
                            NguoiHoc lt = new SinhVienLienThong("LT","Bình",new(2002,1,1),7,tc);
                            Console.WriteLine($"Chính quy: {cq.TinhHocPhi():N0}; Liên thông: {lt.TinhHocPhi():N0}"); break;
                        case 4:
                            SinhVien kiemTra = NhapSV(); IValidatable hopLe = kiemTra;
                            if (hopLe.IsValid(out string message)) Console.WriteLine(((IPrintable)kiemTra).ToDisplayText());
                            else Console.WriteLine("Không hợp lệ: " + message); break;
                        case 5:
                            List<NguoiHoc> ds = ql.DanhSach.ToList(); decimal tong = 0;
                            foreach (NguoiHoc x in ds) { decimal hp = x.TinhHocPhi(); Console.WriteLine($"{x.HoTen} | {x.Loai} | {hp:N0}"); tong += hp; }
                            Console.WriteLine($"Tổng học phí: {tong:N0}"); break;
                        case 6: NhanVienDemo(); break;
                        case 7:
                            double km = So("Quãng đường km: ");
                            foreach (IMove xe in new IMove[] { new XeMay(),new OTo(),new XeDap() })
                                Console.WriteLine($"{xe.Ten} | {xe.TocDo} km/h | {xe.TinhThoiGian(km):F2} giờ | {xe.TinhChiPhi(km):N0} đồng"); break;
                        case 8: ThuVien(); break;
                        case 9: ThanhToanDemo(); break;
                        case 10: MenuSinhVien(ql); break;
                    }
                }
                catch (Exception ex) when (ex is not EndOfStreamException && ex is ArgumentException or InvalidOperationException or OverflowException or IOException or UnauthorizedAccessException)
                { Console.WriteLine("Lỗi: " + ex.Message); }
            } while (chon != 0);
        }
        catch (EndOfStreamException) { Console.WriteLine("Kết thúc nhập dữ liệu."); }
    }
    static void NhanVienDemo()
    {
        // Công thức bài 6 do bài làm quy ước vì đề không cho đơn giá cụ thể.
        NhanVien[] ds = { new NhanVienVanPhong("Nguyễn An",7000000,500000),
            new NhanVienKinhDoanh("Trần Bình",6000000,100000000,0.03m),
            new GiangVien("Lê Chi",8000000,20,150000) };
        foreach (NhanVien nv in ds) Console.WriteLine($"{nv.GetType().Name} | {nv.HoTen} | {nv.TinhLuong():N0}");
        Console.WriteLine($"Tổng lương: {ds.Sum(x=>x.TinhLuong()):N0}");
    }
    static void ThuVien()
    {
        List<TaiLieu> ds = new() { new Sach("S01","Lập trình C#",2024,"Nguyễn An"),
            new TapChi("TC01","Công nghệ phần mềm",2025,12), new LuanVan("LV01","Quản lý thư viện",2025,"Trần Bình") };
        foreach (TaiLieu t in ds) Console.WriteLine(t.ToDisplayText());
        string tu = Nhap("Tìm mã hoặc tiêu đề: ").Trim();
        var kq = ds.Where(x => x.Ma.Contains(tu,StringComparison.OrdinalIgnoreCase) || x.TieuDe.Contains(tu,StringComparison.OrdinalIgnoreCase)).ToList();
        if (kq.Count == 0) Console.WriteLine("Không tìm thấy.");
        foreach (TaiLieu t in kq) Console.WriteLine(t.ToDisplayText());
    }
    static void ThanhToanDemo()
    {
        var so = new SoGiaoDich();
        var ck = new ChuyenKhoan("TK01",1000000); var vi = new ViDienTu("VI01",500000);
        int chon;
        do
        {
            Console.WriteLine($"\n1. Tiền mặt\n2. Chuyển khoản (còn {ck.SoDu:N0})\n3. Ví điện tử (còn {vi.SoDu:N0})\n4. Lịch sử\n0. Quay lại");
            chon = Chon("Chọn: ",0,4);
            try
            {
                if (chon == 4)
                {
                    if (so.LichSu.Count == 0) Console.WriteLine("Chưa có giao dịch.");
                    foreach (var gd in so.LichSu) Console.WriteLine($"{gd.Ma} | {gd.PhuongThuc} | {gd.SoTien:N0} | {gd.ThoiDiem:dd/MM/yyyy HH:mm:ss}");
                }
                else if (chon != 0)
                {
                    decimal tien = Tien("Số tiền thanh toán: ");
                    IPayment cach = chon == 1 ? new ThanhToanTienMat(Tien("Tiền khách đưa: ")) : chon == 2 ? ck : vi;
                    GiaoDich gd = so.ThucHien(cach,tien); Console.WriteLine($"Thành công {gd.Ma}: {gd.SoTien:N0}");
                    if (cach is ThanhToanTienMat tm) Console.WriteLine($"Tiền thừa: {tm.TienThua:N0}");
                }
            }
            catch (Exception ex) when (ex is ArgumentException or InvalidOperationException or OverflowException)
            { Console.WriteLine("Lỗi: " + ex.Message); }
        } while (chon != 0);
    }
    static void MenuSinhVien(QuanLySinhVien ql)
    {
        int chon;
        do
        {
            Console.WriteLine("\n1. Danh sách\n2. Thêm sinh viên theo loại\n3. Tìm mã hoặc tên\n4. Thống kê theo loại\n5. Xuất CSV\n6. Sửa sinh viên\n7. Xóa sinh viên\n8. Sắp xếp điểm giảm dần\n0. Quay lại");
            chon = Chon("Chọn: ",0,8);
            try
            {
                switch(chon)
                {
                    case 1: ql.In(); break;
                    case 2:
                        int loai = Chon("1. Chính quy; 2. Liên thông: ",1,2);
                        SinhVien sv = NhapSV(); int tc = Chon("Số tín chỉ: ",0,100);
                        NguoiHoc moi = loai == 1 ? new SinhVienChinhQuy(sv.MaSV,sv.HoTen,sv.NgaySinh,sv.DiemTB,tc)
                            : new SinhVienLienThong(sv.MaSV,sv.HoTen,sv.NgaySinh,sv.DiemTB,tc);
                        ql.Them(moi); Console.WriteLine("Đã thêm."); break;
                    case 3:
                        var kq = ql.Tim(Nhap("Mã hoặc tên: ")).ToList();
                        if(kq.Count == 0) Console.WriteLine("Không tìm thấy.");
                        foreach(IPrintable x in kq) Console.WriteLine(x.ToDisplayText()); break;
                    case 4: ql.ThongKe(); break;
                    case 5:
                        string file = Path.GetFullPath("sinhvien_lab03.csv"); ql.XuatCsv(file);
                        Console.WriteLine("Đã xuất: " + file); break;
                    case 6:
                        string maCu = Nhap("Mã cần sửa: ");
                        int loaiMoi = Chon("1. Chính quy; 2. Liên thông: ",1,2);
                        SinhVien thongTin = NhapSV(); int soTc = Chon("Số tín chỉ: ",0,100);
                        NguoiHoc thay = loaiMoi == 1
                            ? new SinhVienChinhQuy(thongTin.MaSV,thongTin.HoTen,thongTin.NgaySinh,thongTin.DiemTB,soTc)
                            : new SinhVienLienThong(thongTin.MaSV,thongTin.HoTen,thongTin.NgaySinh,thongTin.DiemTB,soTc);
                        ql.Sua(maCu,thay); Console.WriteLine("Đã sửa."); break;
                    case 7: Console.WriteLine(ql.Xoa(Nhap("Mã cần xóa: ")) ? "Đã xóa." : "Không tìm thấy."); break;
                    case 8: ql.SapXep(); ql.In(); break;
                }
            }
            catch(Exception ex) when (ex is not EndOfStreamException && ex is ArgumentException or IOException or UnauthorizedAccessException)
            { Console.WriteLine("Lỗi: " + ex.Message); }
        } while(chon != 0);
    }
}

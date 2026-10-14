using System.Globalization;
using System.Text;

namespace Lab02_OOPBasics;

internal static class Program
{
    static string Nhap(string nhan)
    { Console.Write(nhan); return Console.ReadLine() ?? throw new EndOfStreamException(); }
    static int SoNguyen(string nhan, int min, int max)
    {
        while (true)
        {
            if (int.TryParse(Nhap(nhan), out int n) && n >= min && n <= max) return n;
            Console.WriteLine($"Nhập số nguyên từ {min} đến {max}.");
        }
    }
    static double SoThuc(string nhan)
    {
        while (true)
        {
            if (double.TryParse(Nhap(nhan).Replace(',', '.'), NumberStyles.Float, CultureInfo.InvariantCulture, out double x)
                && double.IsFinite(x)) return x;
            Console.WriteLine("Số không hợp lệ.");
        }
    }
    static decimal SoTien(string nhan)
    {
        while (true)
        {
            if (decimal.TryParse(Nhap(nhan).Replace(',', '.'), NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint,
                CultureInfo.InvariantCulture, out decimal n)) return n;
            Console.WriteLine("Nhập số, không dùng dấu phân cách hàng nghìn.");
        }
    }
    static DateTime Ngay()
    {
        while (true)
        {
            if (DateTime.TryParseExact(Nhap("Ngày sinh (dd/MM/yyyy): "), "dd/MM/yyyy", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime ngay) && ngay <= DateTime.Today) return ngay;
            Console.WriteLine("Ngày sinh không hợp lệ.");
        }
    }
    static SinhVien NhapSV(string? ma = null) => new(ma ?? Nhap("Mã SV: "), Nhap("Họ tên: "), Ngay(), SoThuc("Điểm TB: "));

    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;
        if (args.Contains("--test")) { KiemThu.Chay(); return; }
        QuanLySinhVien ql = QuanLySinhVien.TaoDuLieuMau();
        try
        {
            int chon;
            do
            {
                Console.WriteLine("\nLAB 02 - OOP\n1. Lớp SinhVien\n2. Constructor\n3. Kiểm tra đóng gói\n4. Tuổi và xếp loại\n5. Danh sách và tìm mã\n6. Sản phẩm\n7. Tài khoản ngân hàng\n8. Nhân viên\n9. Hình chữ nhật\n10. Quản lý sinh viên\n0. Thoát");
                chon = SoNguyen("Chọn: ", 0, 10);
                try
                {
                    switch (chon)
                    {
                        case 1: new SinhVien("SV01", "Nguyễn An", new(2005, 5, 12), 8.2).HienThi(); break;
                        case 2:
                            new SinhVien().HienThi();
                            new SinhVien("SV02", "Trần Bình", new(2005, 9, 3), 6.8).HienThi(); break;
                        case 3: NhapSV().HienThi(); break;
                        case 4:
                            SinhVien sv = NhapSV();
                            Console.WriteLine($"Tuổi: {sv.TinhTuoi()}; Xếp loại: {sv.XepLoai()}"); break;
                        case 5:
                            ql.InDanhSach();
                            SinhVien? tim = ql.TimTheoMa(Nhap("Mã cần tìm: "));
                            if (tim == null) Console.WriteLine("Không tìm thấy."); else tim.HienThi(); break;
                        case 6:
                            SanPham sp = new(Nhap("Mã SP: "), Nhap("Tên SP: "), SoTien("Đơn giá: "), SoNguyen("Số lượng: ", 0, int.MaxValue));
                            Console.WriteLine($"{sp.Ma} - {sp.Ten}; Thành tiền: {sp.ThanhTien():N2}"); break;
                        case 7: NganHang(); break;
                        case 8:
                            Console.WriteLine("Mã       | Họ tên                 | Lương cơ bản | Hệ số | Phụ cấp    | Tổng lương");
                            foreach (NhanVien nv in new[] { new NhanVien("NV01", "Nguyễn An", 5000000, 2, 500000),
                                new NhanVien("NV02", "Trần Bình", 5000000, 1.5m, 300000), new NhanVien("NV03", "Lê Chi", 5000000, 1, 0) }) nv.HienThi(); break;
                        case 9:
                            HinhChuNhat h = new(SoThuc("Chiều dài: "), SoThuc("Chiều rộng: "));
                            if (!double.IsFinite(h.ChuVi()) || !double.IsFinite(h.DienTich())) Console.WriteLine("Kết quả vượt phạm vi double.");
                            else Console.WriteLine($"Chu vi: {h.ChuVi():F2}; Diện tích: {h.DienTich():F2}"); break;
                        case 10: MenuSV(ql); break;
                    }
                }
                catch (ArgumentException ex) { Console.WriteLine(ex.Message); }
                catch (InvalidOperationException ex) { Console.WriteLine(ex.Message); }
                catch (OverflowException) { Console.WriteLine("Giá trị vượt phạm vi tính toán."); }
            } while (chon != 0);
        }
        catch (EndOfStreamException) { Console.WriteLine("\nKết thúc nhập dữ liệu."); }
    }
    static void MenuSV(QuanLySinhVien ql)
    {
        int chon;
        do
        {
            Console.WriteLine("\n1. In danh sách\n2. Thêm\n3. Sửa (giữ mã)\n4. Xóa\n5. Tìm mã\n6. Sắp xếp\n7. Thống kê\n0. Quay lại");
            chon = SoNguyen("Chọn: ", 0, 7);
            try
            {
                switch (chon)
                {
                    case 1: ql.InDanhSach(); break;
                    case 2: ql.Them(NhapSV()); Console.WriteLine("Đã thêm."); break;
                    case 3:
                        string ma = Nhap("Mã cần sửa: ");
                        if (ql.TimTheoMa(ma) == null) { Console.WriteLine("Không tìm thấy."); break; }
                        SinhVien moi = NhapSV(ma);
                        ql.Sua(ma, moi.HoTen, moi.NgaySinh, moi.DiemTB); Console.WriteLine("Đã sửa."); break;
                    case 4: Console.WriteLine(ql.Xoa(Nhap("Mã cần xóa: ")) ? "Đã xóa." : "Không tìm thấy."); break;
                    case 5:
                        SinhVien? sv = ql.TimTheoMa(Nhap("Mã cần tìm: "));
                        if (sv == null) Console.WriteLine("Không tìm thấy."); else sv.HienThi(); break;
                    case 6:
                        ql.SapXep(SoNguyen("1. Họ tên tăng dần; 2. Điểm giảm dần: ", 1, 2) == 2);
                        ql.InDanhSach(); break;
                    case 7: ql.ThongKe(); break;
                }
            }
            catch (ArgumentException ex) { Console.WriteLine(ex.Message); }
        } while (chon != 0);
    }
    static void NganHang()
    {
        TaiKhoanNganHang a = new("TK01", "Nguyễn An", 1000000), b = new("TK02", "Trần Bình", 500000);
        int chon;
        do
        {
            Console.WriteLine($"\nTK01: {a.SoDu:N0}; TK02: {b.SoDu:N0}\n1. Nạp TK01\n2. Rút TK01\n3. Chuyển TK01 sang TK02\n0. Quay lại");
            chon = SoNguyen("Chọn: ", 0, 3);
            try
            {
                switch (chon)
                {
                    case 1: a.NapTien(SoTien("Tiền nạp: ")); break;
                    case 2: a.RutTien(SoTien("Tiền rút: ")); break;
                    case 3: a.ChuyenTien(b, SoTien("Tiền chuyển: ")); break;
                }
            }
            catch (ArgumentException ex) { Console.WriteLine(ex.Message); }
            catch (InvalidOperationException ex) { Console.WriteLine(ex.Message); }
            catch (OverflowException) { Console.WriteLine("Số tiền vượt phạm vi."); }
        } while (chon != 0);
    }
}

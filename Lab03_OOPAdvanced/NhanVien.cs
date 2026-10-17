namespace Lab03_OOPAdvanced;
public abstract class NhanVien
{
    public string HoTen { get; }
    protected NhanVien(string ten)
    { HoTen = string.IsNullOrWhiteSpace(ten) ? throw new ArgumentException("Thiếu tên.") : ten.Trim(); }
    protected static decimal KhongAm(decimal x) => x < 0 ? throw new ArgumentException("Giá trị không được âm.") : x;
    public abstract decimal TinhLuong();
}
public class NhanVienVanPhong : NhanVien
{
    public decimal LuongCoBan { get; }
    public decimal PhuCap { get; }
    public NhanVienVanPhong(string ten, decimal luong, decimal phuCap) : base(ten)
    { LuongCoBan = KhongAm(luong); PhuCap = KhongAm(phuCap); }
    public override decimal TinhLuong() => LuongCoBan + PhuCap;
}
public class NhanVienKinhDoanh : NhanVien
{
    public decimal LuongCoBan { get; }
    public decimal DoanhSo { get; }
    public decimal TyLeHoaHong { get; }
    public NhanVienKinhDoanh(string ten, decimal luong, decimal doanhSo, decimal tyLe) : base(ten)
    {
        LuongCoBan = KhongAm(luong); DoanhSo = KhongAm(doanhSo);
        if (tyLe < 0 || tyLe > 1) throw new ArgumentException("Tỷ lệ phải từ 0 đến 1.");
        TyLeHoaHong = tyLe;
    }
    public override decimal TinhLuong() => LuongCoBan + DoanhSo * TyLeHoaHong;
}
public class GiangVien : NhanVien
{
    public decimal LuongCoBan { get; }
    public int SoTiet { get; }
    public decimal TienMoiTiet { get; }
    public GiangVien(string ten, decimal luong, int tiet, decimal donGia) : base(ten)
    { LuongCoBan = KhongAm(luong); SoTiet = tiet >= 0 ? tiet : throw new ArgumentException("Số tiết âm."); TienMoiTiet = KhongAm(donGia); }
    public override decimal TinhLuong() => LuongCoBan + SoTiet * TienMoiTiet;
}

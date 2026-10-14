namespace Lab02_OOPBasics;

public class NhanVien
{
    public string MaNV { get; }
    public string HoTen { get; }
    public decimal LuongCoBan { get; }
    public decimal HeSo { get; }
    public decimal PhuCap { get; }
    public NhanVien(string ma, string ten, decimal luongCoBan, decimal heSo, decimal phuCap)
    {
        if (string.IsNullOrWhiteSpace(ma) || string.IsNullOrWhiteSpace(ten))
            throw new ArgumentException("Mã và tên nhân viên không được rỗng.");
        if (luongCoBan < 0 || heSo <= 0 || phuCap < 0)
            throw new ArgumentException("Lương, phụ cấp không âm; hệ số phải dương.");
        MaNV = ma.Trim(); HoTen = ten.Trim(); LuongCoBan = luongCoBan; HeSo = heSo; PhuCap = phuCap;
    }
    public decimal TinhLuong() => LuongCoBan * HeSo + PhuCap;
    public void HienThi() => Console.WriteLine($"{MaNV,-8} | {HoTen,-22} | {LuongCoBan,12:N0} | {HeSo,5} | {PhuCap,10:N0} | {TinhLuong(),12:N0}");
}

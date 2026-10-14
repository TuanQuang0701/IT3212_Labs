namespace Lab02_OOPBasics;

public class SanPham
{
    private string _ma = "", _ten = "";
    private decimal _donGia;
    private int _soLuong;
    public string Ma
    {
        get => _ma;
        set => _ma = string.IsNullOrWhiteSpace(value) ? throw new ArgumentException("Mã không được rỗng.") : value.Trim();
    }
    public string Ten
    {
        get => _ten;
        set => _ten = string.IsNullOrWhiteSpace(value) ? throw new ArgumentException("Tên không được rỗng.") : value.Trim();
    }
    public decimal DonGia
    {
        get => _donGia;
        set => _donGia = value < 0 ? throw new ArgumentException("Đơn giá không được âm.") : value;
    }
    public int SoLuong
    {
        get => _soLuong;
        set => _soLuong = value < 0 ? throw new ArgumentException("Số lượng không được âm.") : value;
    }
    public SanPham(string ma, string ten, decimal donGia, int soLuong)
    { Ma = ma; Ten = ten; DonGia = donGia; SoLuong = soLuong; }
    public decimal ThanhTien() => DonGia * SoLuong;
}

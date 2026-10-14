namespace Lab02_OOPBasics;

public class SinhVien
{
    private string _maSV = "Chưa có", _hoTen = "Chưa có";
    private DateTime _ngaySinh = DateTime.Today;
    private double _diemTB;
    public string MaSV
    {
        get => _maSV;
        set => _maSV = string.IsNullOrWhiteSpace(value)
            ? throw new ArgumentException("Mã sinh viên không được rỗng.") : value.Trim();
    }
    public string HoTen
    {
        get => _hoTen;
        set => _hoTen = string.IsNullOrWhiteSpace(value)
            ? throw new ArgumentException("Họ tên không được rỗng.") : value.Trim();
    }
    public DateTime NgaySinh
    {
        get => _ngaySinh;
        set => _ngaySinh = value.Date > DateTime.Today
            ? throw new ArgumentException("Ngày sinh không được ở tương lai.") : value.Date;
    }
    public double DiemTB
    {
        get => _diemTB;
        set => _diemTB = !double.IsFinite(value) || value < 0 || value > 10
            ? throw new ArgumentOutOfRangeException(nameof(DiemTB), "Điểm phải từ 0 đến 10.") : value;
    }
    public SinhVien() { }
    public SinhVien(string maSV, string hoTen, DateTime ngaySinh, double diemTB)
    {
        this.MaSV = maSV; this.HoTen = hoTen;
        this.NgaySinh = ngaySinh; this.DiemTB = diemTB;
    }
    public int TinhTuoi()
    {
        int tuoi = DateTime.Today.Year - NgaySinh.Year;
        if (NgaySinh > DateTime.Today.AddYears(-tuoi)) tuoi--;
        return tuoi;
    }
    public string XepLoai()
    {
        if (DiemTB >= 9) return "Xuất sắc";
        if (DiemTB >= 8) return "Giỏi";
        if (DiemTB >= 6.5) return "Khá";
        if (DiemTB >= 5) return "Trung bình";
        return "Yếu";
    }
    public void HienThi() => Console.WriteLine(
        $"{MaSV,-8} | {HoTen,-24} | {NgaySinh:dd/MM/yyyy} | {DiemTB:F2} | {TinhTuoi()} tuổi | {XepLoai()}");
}

namespace Lab02_OOPBasics;

public class QuanLySinhVien
{
    private readonly List<SinhVien> _danhSach = new();
    public IReadOnlyList<SinhVien> DanhSach => _danhSach.AsReadOnly();
    public SinhVien? TimTheoMa(string ma) => _danhSach.Find(s => s.MaSV.Equals(ma.Trim(), StringComparison.OrdinalIgnoreCase));
    public void Them(SinhVien sv)
    {
        if (TimTheoMa(sv.MaSV) != null) throw new ArgumentException("Mã sinh viên đã tồn tại.");
        // Lưu bản sao, tránh đối tượng đầu vào bị đổi mã sau khi thêm.
        _danhSach.Add(new SinhVien(sv.MaSV, sv.HoTen, sv.NgaySinh, sv.DiemTB));
    }
    public void Sua(string ma, string ten, DateTime sinh, double diem)
    {
        SinhVien cu = TimTheoMa(ma) ?? throw new ArgumentException("Không tìm thấy sinh viên.");
        SinhVien moi = new(cu.MaSV, ten, sinh, diem);
        _danhSach[_danhSach.IndexOf(cu)] = moi;
    }
    public bool Xoa(string ma)
    {
        SinhVien? sv = TimTheoMa(ma);
        return sv != null && _danhSach.Remove(sv);
    }
    public void SapXep(bool theoDiem)
    {
        if (theoDiem) _danhSach.Sort((a, b) => b.DiemTB != a.DiemTB
            ? b.DiemTB.CompareTo(a.DiemTB) : string.Compare(a.MaSV, b.MaSV, StringComparison.OrdinalIgnoreCase));
        else _danhSach.Sort((a, b) => string.Compare(a.HoTen, b.HoTen, StringComparison.CurrentCultureIgnoreCase));
    }
    public void InDanhSach()
    {
        if (_danhSach.Count == 0) Console.WriteLine("Danh sách trống.");
        foreach (SinhVien sv in _danhSach) sv.HienThi();
    }
    public void ThongKe()
    {
        Console.WriteLine($"Số sinh viên: {_danhSach.Count}");
        if (_danhSach.Count == 0) return;
        Console.WriteLine($"Điểm trung bình: {_danhSach.Average(s => s.DiemTB):F2}; Cao nhất: {_danhSach.Max(s => s.DiemTB):F2}; Thấp nhất: {_danhSach.Min(s => s.DiemTB):F2}");
        foreach (string loai in new[] { "Xuất sắc", "Giỏi", "Khá", "Trung bình", "Yếu" })
            Console.WriteLine($"{loai}: {_danhSach.Count(s => s.XepLoai() == loai)}");
    }
    public static QuanLySinhVien TaoDuLieuMau()
    {
        QuanLySinhVien ql = new();
        ql.Them(new("SV01", "Nguyễn An", new(2005, 5, 12), 9.2));
        ql.Them(new("SV02", "Trần Bình", new(2005, 9, 3), 8.2));
        ql.Them(new("SV03", "Lê Chi", new(2006, 1, 20), 6.8));
        ql.Them(new("SV04", "Phạm Dũng", new(2005, 12, 25), 5.5));
        ql.Them(new("SV05", "Hoàng Hà", new(2006, 7, 7), 4.0));
        return ql;
    }
}

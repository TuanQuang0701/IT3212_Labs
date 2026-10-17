using System.Text;
namespace Lab03_OOPAdvanced;
public class QuanLySinhVien
{
    private readonly List<NguoiHoc> _ds = new();
    public IReadOnlyList<NguoiHoc> DanhSach => _ds.AsReadOnly();
    public void Them(NguoiHoc sv)
    {
        if (!sv.IsValid(out string message)) throw new ArgumentException(message);
        if (_ds.Any(x => x.MaSV.Equals(sv.MaSV.Trim(), StringComparison.OrdinalIgnoreCase)))
            throw new ArgumentException("Mã sinh viên bị trùng.");
        sv.MaSV = sv.MaSV.Trim(); sv.HoTen = sv.HoTen.Trim(); _ds.Add(sv);
    }
    public IEnumerable<NguoiHoc> Tim(string tuKhoa) => _ds.Where(x =>
        x.MaSV.Contains(tuKhoa.Trim(), StringComparison.OrdinalIgnoreCase) ||
        x.HoTen.Contains(tuKhoa.Trim(), StringComparison.OrdinalIgnoreCase));
    public void Sua(string ma, NguoiHoc moi)
    {
        int i = _ds.FindIndex(x => x.MaSV.Equals(ma.Trim(), StringComparison.OrdinalIgnoreCase));
        if (i < 0) throw new ArgumentException("Không tìm thấy mã cần sửa.");
        if (!moi.IsValid(out string message)) throw new ArgumentException(message);
        if (_ds.Where((_, viTri) => viTri != i).Any(x => x.MaSV.Equals(moi.MaSV.Trim(), StringComparison.OrdinalIgnoreCase)))
            throw new ArgumentException("Mã sinh viên bị trùng.");
        moi.MaSV = moi.MaSV.Trim(); moi.HoTen = moi.HoTen.Trim(); _ds[i] = moi;
    }
    public bool Xoa(string ma) => _ds.RemoveAll(x => x.MaSV.Equals(ma.Trim(),StringComparison.OrdinalIgnoreCase)) > 0;
    public void SapXep() => _ds.Sort((a,b) => b.DiemTB.CompareTo(a.DiemTB));
    public void In() { foreach (IPrintable x in _ds) Console.WriteLine(x.ToDisplayText()); }
    public void ThongKe()
    {
        Console.WriteLine($"Tổng số sinh viên: {_ds.Count}");
        foreach (var nhom in _ds.GroupBy(x => x.Loai))
            Console.WriteLine($"{nhom.Key}: {nhom.Count()} SV; ĐTB {nhom.Average(x => x.DiemTB):F2}; Học phí {nhom.Sum(x => x.TinhHocPhi()):N0}");
    }
    public void XuatCsv(string duongDan)
    {
        if (_ds.Any(x => !x.IsValid(out _))) throw new ArgumentException("Danh sách có dữ liệu không hợp lệ.");
        File.WriteAllLines(duongDan, new[] { "MaSV,HoTen,NgaySinh,DiemTB,Loai" }
            .Concat(_ds.Select(x => ((IExportable)x).ToCsv())), new UTF8Encoding(true));
    }
    public static QuanLySinhVien TaoMau()
    {
        var q = new QuanLySinhVien();
        q.Them(new SinhVienChinhQuy("CQ01", "Nguyễn An", new(2005,5,12), 8.2,18));
        q.Them(new SinhVienLienThong("LT01", "Trần Bình", new(2002,9,3),7.5,15));
        q.Them(new SinhVienChinhQuy("CQ02", "Lê Chi",new(2006,1,20),9.1,20));
        q.Them(new SinhVienLienThong("LT02", "Phạm Dũng",new(2001,12,25),6,12));
        q.Them(new SinhVienChinhQuy("CQ03", "Hoàng Hà",new(2005,7,7),4.5,16));
        return q;
    }
}

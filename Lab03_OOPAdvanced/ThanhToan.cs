namespace Lab03_OOPAdvanced;
public interface IPayment
{
    string Ten { get; }
    void ThanhToan(decimal soTien);
}
public class ThanhToanTienMat : IPayment
{
    public string Ten => "Tiền mặt";
    public decimal TienKhachDua { get; }
    public decimal TienThua { get; private set; }
    public ThanhToanTienMat(decimal tien) { TienKhachDua = tien; }
    public void ThanhToan(decimal soTien)
    {
        if (soTien <= 0 || TienKhachDua < soTien) throw new ArgumentException("Tiền mặt không đủ hoặc số tiền không hợp lệ.");
        TienThua = TienKhachDua - soTien;
    }
}
public abstract class ThanhToanSoDu : IPayment
{
    public abstract string Ten { get; }
    public decimal SoDu { get; private set; }
    public string TaiKhoan { get; }
    protected ThanhToanSoDu(string taiKhoan, decimal soDu)
    {
        if (string.IsNullOrWhiteSpace(taiKhoan) || soDu < 0) throw new ArgumentException("Tài khoản không hợp lệ.");
        TaiKhoan = taiKhoan; SoDu = soDu;
    }
    public void ThanhToan(decimal soTien)
    {
        if (soTien <= 0) throw new ArgumentException("Số tiền phải dương.");
        if (soTien > SoDu) throw new InvalidOperationException("Không đủ số dư.");
        SoDu -= soTien;
    }
}
public class ChuyenKhoan : ThanhToanSoDu
{ public override string Ten => "Chuyển khoản"; public ChuyenKhoan(string tk, decimal tien) : base(tk, tien) { } }
public class ViDienTu : ThanhToanSoDu
{ public override string Ten => "Ví điện tử"; public ViDienTu(string tk, decimal tien) : base(tk, tien) { } }
public record GiaoDich(string Ma, string PhuongThuc, decimal SoTien, DateTime ThoiDiem);
public class SoGiaoDich
{
    private readonly List<GiaoDich> _lichSu = new();
    public IReadOnlyList<GiaoDich> LichSu => _lichSu.AsReadOnly();
    public GiaoDich ThucHien(IPayment cach, decimal tien)
    {
        ArgumentNullException.ThrowIfNull(cach);
        cach.ThanhToan(tien);
        var gd = new GiaoDich($"GD{_lichSu.Count + 1:000}", cach.Ten, tien, DateTime.Now);
        _lichSu.Add(gd); return gd;
    }
}

namespace Lab02_OOPBasics;

public class TaiKhoanNganHang
{
    public string SoTaiKhoan { get; }
    public string ChuTaiKhoan { get; }
    public decimal SoDu { get; private set; }
    public TaiKhoanNganHang(string soTaiKhoan, string chuTaiKhoan, decimal soDu = 0)
    {
        if (string.IsNullOrWhiteSpace(soTaiKhoan) || string.IsNullOrWhiteSpace(chuTaiKhoan))
            throw new ArgumentException("Số tài khoản và chủ tài khoản không được rỗng.");
        if (soDu < 0) throw new ArgumentException("Số dư không được âm.");
        SoTaiKhoan = soTaiKhoan.Trim(); ChuTaiKhoan = chuTaiKhoan.Trim(); SoDu = soDu;
    }
    private static void KiemTraTien(decimal tien)
    { if (tien <= 0) throw new ArgumentException("Số tiền phải lớn hơn 0."); }
    public void NapTien(decimal tien) { KiemTraTien(tien); SoDu += tien; }
    public void RutTien(decimal tien)
    {
        KiemTraTien(tien);
        if (tien > SoDu) throw new InvalidOperationException("Số dư không đủ.");
        SoDu -= tien;
    }
    public void ChuyenTien(TaiKhoanNganHang dich, decimal tien)
    {
        ArgumentNullException.ThrowIfNull(dich);
        if (ReferenceEquals(this, dich) || SoTaiKhoan == dich.SoTaiKhoan)
            throw new ArgumentException("Không chuyển vào chính tài khoản này.");
        KiemTraTien(tien);
        if (tien > SoDu) throw new InvalidOperationException("Số dư không đủ.");
        // Tính trước để khi tràn số, cả hai số dư đều chưa bị thay đổi.
        decimal soDuMoiDich = dich.SoDu + tien;
        SoDu -= tien; dich.SoDu = soDuMoiDich;
    }
}

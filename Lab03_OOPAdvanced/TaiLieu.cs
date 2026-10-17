namespace Lab03_OOPAdvanced;
public abstract class TaiLieu : IPrintable
{
    public string Ma { get; }
    public string TieuDe { get; }
    public int Nam { get; }
    protected TaiLieu(string ma, string ten, int nam)
    {
        if (string.IsNullOrWhiteSpace(ma) || string.IsNullOrWhiteSpace(ten) || nam <= 0)
            throw new ArgumentException("Thông tin tài liệu không hợp lệ.");
        Ma = ma.Trim(); TieuDe = ten.Trim(); Nam = nam;
    }
    public virtual string ToDisplayText() => $"{Ma} | {TieuDe} | {Nam}";
}
public class Sach : TaiLieu
{
    public string TacGia { get; }
    public Sach(string ma, string ten, int nam, string tacGia) : base(ma, ten, nam)
    { TacGia = string.IsNullOrWhiteSpace(tacGia) ? throw new ArgumentException("Thiếu tác giả.") : tacGia; }
    public override string ToDisplayText() => $"Sách | {base.ToDisplayText()} | {TacGia}";
}
public class TapChi : TaiLieu
{
    public int SoPhatHanh { get; }
    public TapChi(string ma, string ten, int nam, int so) : base(ma, ten, nam)
    { SoPhatHanh = so > 0 ? so : throw new ArgumentException("Số phát hành phải dương."); }
    public override string ToDisplayText() => $"Tạp chí | {base.ToDisplayText()} | Số {SoPhatHanh}";
}
public class LuanVan : TaiLieu
{
    public string NguoiThucHien { get; }
    public LuanVan(string ma, string ten, int nam, string nguoi) : base(ma, ten, nam)
    { NguoiThucHien = string.IsNullOrWhiteSpace(nguoi) ? throw new ArgumentException("Thiếu người thực hiện.") : nguoi; }
    public override string ToDisplayText() => $"Luận văn | {base.ToDisplayText()} | {NguoiThucHien}";
}

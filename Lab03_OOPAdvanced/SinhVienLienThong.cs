namespace Lab03_OOPAdvanced;
public class SinhVienLienThong : NguoiHoc
{
    public override string Loai => "Liên thông";
    public SinhVienLienThong(string ma, string ten, DateTime sinh, double diem, int tc)
        : base(ma, ten, sinh, diem, tc) { }
    public override decimal TinhHocPhi()
    {
        if (SoTinChi < 0) throw new ArgumentException("Số tín chỉ không được âm.");
        return SoTinChi * 520000m;
    }
}

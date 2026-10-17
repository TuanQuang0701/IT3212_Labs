namespace Lab03_OOPAdvanced;
public class SinhVienChinhQuy : NguoiHoc
{
    public override string Loai => "Chính quy";
    public SinhVienChinhQuy(string ma, string ten, DateTime sinh, double diem, int tc)
        : base(ma, ten, sinh, diem, tc) { }
    public override decimal TinhHocPhi()
    {
        if (SoTinChi < 0) throw new ArgumentException("Số tín chỉ không được âm.");
        return SoTinChi * 450000m;
    }
}

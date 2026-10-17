namespace Lab03_OOPAdvanced;

public abstract class NguoiHoc : SinhVien
{
    public int SoTinChi { get; set; }
    protected NguoiHoc(string ma, string ten, DateTime sinh, double diem, int tinChi)
        : base(ma, ten, sinh, diem) { SoTinChi = tinChi; }
    public abstract decimal TinhHocPhi();
    public override bool IsValid(out string message)
    {
        if (!base.IsValid(out message)) return false;
        if (SoTinChi < 0) { message = "Số tín chỉ không được âm."; return false; }
        return true;
    }
    public override string MoTa() => $"{base.MoTa()} | {SoTinChi} tín chỉ | {TinhHocPhi():N0} đồng";
}

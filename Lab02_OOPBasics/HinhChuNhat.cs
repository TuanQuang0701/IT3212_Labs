namespace Lab02_OOPBasics;

public class HinhChuNhat
{
    private double _dai, _rong;
    public double ChieuDai
    {
        get => _dai;
        set => _dai = !double.IsFinite(value) || value <= 0
            ? throw new ArgumentException("Chiều dài phải là số dương hữu hạn.") : value;
    }
    public double ChieuRong
    {
        get => _rong;
        set => _rong = !double.IsFinite(value) || value <= 0
            ? throw new ArgumentException("Chiều rộng phải là số dương hữu hạn.") : value;
    }
    public HinhChuNhat() : this(1, 1) { }
    public HinhChuNhat(double dai, double rong) { ChieuDai = dai; ChieuRong = rong; }
    public double ChuVi() => 2 * (ChieuDai + ChieuRong);
    public double DienTich() => ChieuDai * ChieuRong;
}

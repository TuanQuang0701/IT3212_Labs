namespace Lab03_OOPAdvanced;
public interface IMove
{
    string Ten { get; }
    double TocDo { get; }
    decimal TinhChiPhi(double km);
    double TinhThoiGian(double km);
}
public abstract class PhuongTien : IMove
{
    public abstract string Ten { get; }
    public abstract double TocDo { get; }
    public abstract decimal GiaMoiKm { get; }
    public decimal TinhChiPhi(double km)
    {
        if (!double.IsFinite(km) || km < 0) throw new ArgumentException("Quãng đường không hợp lệ.");
        return (decimal)km * GiaMoiKm;
    }
    public double TinhThoiGian(double km)
    { _ = TinhChiPhi(km); return km / TocDo; }
}
public class XeMay : PhuongTien
{ public override string Ten => "Xe máy"; public override double TocDo => 40; public override decimal GiaMoiKm => 700; }
public class OTo : PhuongTien
{ public override string Ten => "Ô tô"; public override double TocDo => 60; public override decimal GiaMoiKm => 2500; }
public class XeDap : PhuongTien
{ public override string Ten => "Xe đạp"; public override double TocDo => 15; public override decimal GiaMoiKm => 0; }

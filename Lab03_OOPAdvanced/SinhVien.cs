using System.Globalization;
namespace Lab03_OOPAdvanced;

// Tiếp tục mô hình Lab02; đưa thông tin chung lên lớp Nguoi.
public class SinhVien : Nguoi, IValidatable, IPrintable, IExportable
{
    public string MaSV { get; set; }
    public double DiemTB { get; set; }
    public virtual string Loai => "Thông thường";
    public SinhVien() : this("Chưa có", "Chưa có", DateTime.Today, 0) { }
    public SinhVien(string ma, string ten, DateTime sinh, double diem)
        : base(ten, sinh) { MaSV = ma; DiemTB = diem; }
    public string XepLoai() => DiemTB >= 9 ? "Xuất sắc" : DiemTB >= 8 ? "Giỏi"
        : DiemTB >= 6.5 ? "Khá" : DiemTB >= 5 ? "Trung bình" : "Yếu";
    public virtual bool IsValid(out string message)
    {
        message = "";
        if (string.IsNullOrWhiteSpace(MaSV)) message = "Thiếu mã sinh viên.";
        else if (string.IsNullOrWhiteSpace(HoTen)) message = "Thiếu họ tên.";
        else if (NgaySinh.Date > DateTime.Today) message = "Ngày sinh ở tương lai.";
        else if (!double.IsFinite(DiemTB) || DiemTB < 0 || DiemTB > 10)
            message = "Điểm phải từ 0 đến 10.";
        return message.Length == 0;
    }
    public override string MoTa() => $"{base.MoTa()} | {MaSV} | {DiemTB:F2} | {Loai}";
    public string ToDisplayText() => $"{MoTa()} | {XepLoai()}";
    public void HienThi() => Console.WriteLine(ToDisplayText());
    private static string Csv(string s) => "\"" + s.Replace("\"", "\"\"") + "\"";
    public string ToCsv() => string.Join(",", Csv(MaSV), Csv(HoTen),
        NgaySinh.ToString("yyyy-MM-dd"), DiemTB.ToString(CultureInfo.InvariantCulture), Csv(Loai));
}

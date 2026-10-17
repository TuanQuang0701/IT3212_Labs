namespace Lab03_OOPAdvanced;

public class Nguoi
{
    public string HoTen { get; set; }
    public DateTime NgaySinh { get; set; }
    public Nguoi(string hoTen, DateTime ngaySinh)
    { HoTen = hoTen; NgaySinh = ngaySinh; }
    public int TinhTuoi()
    {
        int tuoi = DateTime.Today.Year - NgaySinh.Year;
        if (NgaySinh.Date > DateTime.Today.AddYears(-tuoi)) tuoi--;
        return tuoi;
    }
    public virtual string MoTa() => $"{HoTen} | {NgaySinh:dd/MM/yyyy}";
}

using System;
namespace Lab05_MultiForm
{
    public class SinhVien
    {
        public string MaSV {get;private set;}
        public string HoTen {get;private set;}
        public DateTime NgaySinh {get;private set;}
        public string GioiTinh {get;private set;}
        public string Khoa {get;private set;}
        public double DiemTB {get;private set;}
        public SinhVien(string ma,string ten,DateTime sinh,string gioiTinh,string khoa,double diem)
        {
            if(string.IsNullOrWhiteSpace(ma)||string.IsNullOrWhiteSpace(ten)||string.IsNullOrWhiteSpace(khoa))
                throw new ArgumentException("Mã, họ tên và khoa là bắt buộc.");
            if(sinh.Date>DateTime.Today||!KiemTra.DiemHopLe(diem))throw new ArgumentException("Ngày sinh hoặc điểm không hợp lệ.");
            MaSV=ma.Trim();HoTen=ten.Trim();NgaySinh=sinh.Date;GioiTinh=gioiTinh;Khoa=khoa;DiemTB=diem;
        }
        public int TinhTuoi()
        {int tuoi=DateTime.Today.Year-NgaySinh.Year;if(NgaySinh>DateTime.Today.AddYears(-tuoi))tuoi--;return tuoi;}
        public override string ToString(){return MaSV+" — "+HoTen+" — "+Khoa+" — "+DiemTB.ToString("F2");}
    }
}

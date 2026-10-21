using System;
using System.Collections.Generic;

namespace Lab04_WinFormsBasic
{
    // Mô hình từ Lab02, bổ sung thông tin cần cho Form.
    public class SinhVien
    {
        private string _ma = "Chưa có", _ten = "Chưa có";
        private double _diem;
        private DateTime _ngaySinh = DateTime.Today;
        public string MaSV
        {
            get { return _ma; }
            set { if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Mã sinh viên không được rỗng."); _ma = value.Trim(); }
        }
        public string HoTen
        {
            get { return _ten; }
            set { if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Họ tên không được rỗng."); _ten = value.Trim(); }
        }
        public DateTime NgaySinh
        {
            get { return _ngaySinh; }
            set { if (value.Date > DateTime.Today) throw new ArgumentException("Ngày sinh không được ở tương lai."); _ngaySinh = value.Date; }
        }
        public double DiemTB
        {
            get { return _diem; }
            set { if (double.IsNaN(value) || double.IsInfinity(value) || value < 0 || value > 10) throw new ArgumentException("Điểm phải từ 0 đến 10."); _diem = value; }
        }
        public string GioiTinh { get; set; }
        public string Khoa { get; set; }
        public List<string> SoThich { get; set; } = new List<string>();
        public string DuongDanAnh { get; set; }
        public SinhVien() { }
        public SinhVien(string ma, string ten, DateTime ngaySinh, double diem)
        { MaSV = ma; HoTen = ten; NgaySinh = ngaySinh; DiemTB = diem; }
        public int TinhTuoi() { return NghiepVu.TinhTuoi(NgaySinh, DateTime.Today); }
        public string XepLoai() { return DiemTB >= 9 ? "Xuất sắc" : DiemTB >= 8 ? "Giỏi" : DiemTB >= 6.5 ? "Khá" : DiemTB >= 5 ? "Trung bình" : "Yếu"; }
        public string ThongTin()
        {
            return string.Format("Mã: {0}\nHọ tên: {1}\nNgày sinh: {2:dd/MM/yyyy}\nTuổi: {3}\nGiới tính: {4}\nKhoa: {5}\nSở thích: {6}",
                MaSV, HoTen, NgaySinh, TinhTuoi(), GioiTinh, Khoa,
                SoThich.Count == 0 ? "Chưa chọn" : string.Join(", ", SoThich));
        }
    }
}

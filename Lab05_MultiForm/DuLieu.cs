using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
namespace Lab05_MultiForm
{
    // Mỗi frmMain sở hữu một kho dữ liệu, truyền qua constructor tới Form con.
    public class DuLieu
    {
        private readonly List<SinhVien> _sinhVien=new List<SinhVien>();
        public IReadOnlyList<SinhVien> SinhViens {get{return _sinhVien.AsReadOnly();}}
        public IReadOnlyList<string> Khoas {get;}=new List<string>{"Công nghệ thông tin","Công nghệ kỹ thuật ô tô","Kinh tế"}.AsReadOnly();
        public void Them(SinhVien sv)
        {
            if(sv==null)throw new ArgumentNullException(nameof(sv));
            if(_sinhVien.Any(x=>x.MaSV.Equals(sv.MaSV,StringComparison.OrdinalIgnoreCase)))throw new ArgumentException("Mã sinh viên đã tồn tại.");
            _sinhVien.Add(sv);
        }
        public List<SinhVien> Tim(string tuKhoa)
        {
            string tu=(tuKhoa??"").Trim();
            return _sinhVien.Where(x=>x.MaSV.IndexOf(tu,StringComparison.OrdinalIgnoreCase)>=0||x.HoTen.IndexOf(tu,StringComparison.OrdinalIgnoreCase)>=0).ToList();
        }
        public static DuLieu TaoMau()
        {
            var d=new DuLieu();
            d.Them(new SinhVien("SV01","Nguyễn An",new DateTime(2005,5,12),"Nam",d.Khoas[0],8.2));
            d.Them(new SinhVien("SV02","Trần Bình",new DateTime(2005,9,3),"Nam",d.Khoas[1],7.5));
            d.Them(new SinhVien("SV03","Lê Chi",new DateTime(2006,1,20),"Nữ",d.Khoas[2],9.1));
            return d;
        }
    }
    public static class KiemTra
    {
        public static bool DiemHopLe(double diem){return !double.IsNaN(diem)&&!double.IsInfinity(diem)&&diem>=0&&diem<=10;}
        public static bool DocDiem(string text,out double diem)
        {return double.TryParse((text??"").Trim().Replace(',','.'),NumberStyles.AllowDecimalPoint,CultureInfo.InvariantCulture,out diem)&&DiemHopLe(diem);}
        public static bool ChoPhepKyTu(string text,int viTri,int soKyTuChon,char c)
        {
            if(char.IsControl(c))return true;
            if(c>='0'&&c<='9')return true;
            string conLai=text.Remove(viTri,soKyTuChon);
            return (c=='.'||c==',')&&!conLai.Contains(".")&&!conLai.Contains(",");
        }
    }
    public class GioiHanDangNhap
    {
        public int SoLanSai {get;private set;}
        public DateTime KhoaDen {get;private set;}
        public bool DangKhoa(DateTime now){return now<KhoaDen;}
        public int ConLai(DateTime now){return Math.Max(0,(int)Math.Ceiling((KhoaDen-now).TotalSeconds));}
        public bool Thu(string ten,string mk,DateTime now)
        {
            if(DangKhoa(now))return false;
            if(KhoaDen!=default(DateTime)){SoLanSai=0;KhoaDen=default(DateTime);}
            if(ten.Trim()=="sinhvien"&&mk=="123456"){SoLanSai=0;return true;}
            SoLanSai++;
            if(SoLanSai>=3)KhoaDen=now.AddSeconds(30);
            return false;
        }
    }
}

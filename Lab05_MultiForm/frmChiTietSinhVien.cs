using System;
using System.Windows.Forms;
namespace Lab05_MultiForm
{
    public partial class frmChiTietSinhVien:Form
    {
        private readonly SinhVien _sinhVien;
        public frmChiTietSinhVien(){InitializeComponent();}
        public frmChiTietSinhVien(SinhVien sinhVien):this(){_sinhVien=sinhVien??throw new ArgumentNullException(nameof(sinhVien));}
        private void frmChiTietSinhVien_Load(object sender,EventArgs e)
        {
            if(_sinhVien==null)return;
            lblMa.Text=_sinhVien.MaSV;lblHoTen.Text=_sinhVien.HoTen;lblDiem.Text=_sinhVien.DiemTB.ToString("F2");
            lblThongTin.Text=string.Format("Ngày sinh: {0:dd/MM/yyyy}\nTuổi: {1}\nGiới tính: {2}\nKhoa: {3}",_sinhVien.NgaySinh,_sinhVien.TinhTuoi(),_sinhVien.GioiTinh,_sinhVien.Khoa);
        }
        private void btnDong_Click(object sender,EventArgs e){Close();}
    }
}

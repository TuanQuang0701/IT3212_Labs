using System;
using System.Linq;
using System.Windows.Forms;
namespace Lab05_MultiForm
{
    public partial class frmSinhVien:Form
    {
        private readonly DuLieu _duLieu;
        public frmSinhVien():this(new DuLieu()){}
        public frmSinhVien(DuLieu duLieu)
        {InitializeComponent();_duLieu=duLieu;dtpNgaySinh.MaxDate=DateTime.Today;}
        private void frmSinhVien_Load(object sender,EventArgs e)
        {
            cboKhoa.Items.AddRange(_duLieu.Khoas.Cast<object>().ToArray());
            if(cboKhoa.Items.Count>0)cboKhoa.SelectedIndex=0;
            radNam.Checked=true;CapNhatDanhSach();Input_TextChanged(this,EventArgs.Empty);
        }
        internal bool ValidateInput()
        {
            errorProvider1.Clear();bool valid=true;double diem;
            if(string.IsNullOrWhiteSpace(txtMaSV.Text)){errorProvider1.SetError(txtMaSV,"Nhập mã sinh viên");valid=false;}
            if(string.IsNullOrWhiteSpace(txtHoTen.Text)){errorProvider1.SetError(txtHoTen,"Nhập họ tên");valid=false;}
            if(!KiemTra.DocDiem(txtDiemTB.Text,out diem)){errorProvider1.SetError(txtDiemTB,"Điểm phải là số từ 0 đến 10");valid=false;}
            if(cboKhoa.SelectedIndex<0){errorProvider1.SetError(cboKhoa,"Chọn khoa");valid=false;}
            return valid;
        }
        private SinhVien DocSinhVien()
        {
            double diem;KiemTra.DocDiem(txtDiemTB.Text,out diem);
            return new SinhVien(txtMaSV.Text,txtHoTen.Text,dtpNgaySinh.Value,radNam.Checked?"Nam":"Nữ",cboKhoa.Text,diem);
        }
        private void btnLuu_Click(object sender,EventArgs e)
        {
            if(!ValidateInput()){lblTrangThai.Text="Chưa lưu: kiểm tra biểu tượng lỗi.";return;}
            try{_duLieu.Them(DocSinhVien());CapNhatDanhSach();lblTrangThai.Text="Đã lưu sinh viên.";}
            catch(ArgumentException ex){errorProvider1.SetError(txtMaSV,ex.Message);lblTrangThai.Text=ex.Message;}
        }
        private void btnChiTiet_Click(object sender,EventArgs e)
        {
            if(!ValidateInput())return;
            using(var f=new frmChiTietSinhVien(DocSinhVien()))f.ShowDialog(this);
        }
        private void txtDiemTB_KeyPress(object sender,KeyPressEventArgs e)
        {e.Handled=!KiemTra.ChoPhepKyTu(txtDiemTB.Text,txtDiemTB.SelectionStart,txtDiemTB.SelectionLength,e.KeyChar);}
        private void Input_TextChanged(object sender,EventArgs e)
        {
            if(lblXemTruoc==null||txtDiemTB==null)return;
            lblXemTruoc.Text=txtMaSV.Text.Trim()+" — "+txtHoTen.Text.Trim();
            double diem;lblTrangThai.Text=KiemTra.DocDiem(txtDiemTB.Text,out diem)?"Dữ liệu điểm hợp lệ":"Kiểm tra điểm [0, 10]";
        }
        private void cboKhoa_SelectedIndexChanged(object sender,EventArgs e)
        {lblKhoaDaChon.Text="Khoa đã chọn: "+cboKhoa.Text;}
        private void btnChonKhoa_Click(object sender,EventArgs e)
        {
            using(var f=new frmChonKhoa(_duLieu.Khoas,cboKhoa.Text))
                if(f.ShowDialog(this)==DialogResult.OK)cboKhoa.SelectedItem=f.KhoaDaChon;
        }
        private void btnTimKiem_Click(object sender,EventArgs e)
        {
            using(var f=new frmTimKiem(_duLieu))
                if(f.ShowDialog(this)==DialogResult.OK)
                {
                    var sv=f.KetQua;txtMaSV.Text=sv.MaSV;txtHoTen.Text=sv.HoTen;txtDiemTB.Text=sv.DiemTB.ToString(System.Globalization.CultureInfo.InvariantCulture);
                    dtpNgaySinh.Value=sv.NgaySinh;radNam.Checked=sv.GioiTinh=="Nam";radNu.Checked=!radNam.Checked;cboKhoa.SelectedItem=sv.Khoa;
                    lblTrangThai.Text="Đã nhận kết quả tìm kiếm (xem thông tin; Lưu chỉ thêm mới).";
                }
        }
        private void CapNhatDanhSach()
        {lstSinhVien.Items.Clear();lstSinhVien.Items.AddRange(_duLieu.SinhViens.Cast<object>().ToArray());}
        private void btnLamMoi_Click(object sender,EventArgs e)
        {txtMaSV.Clear();txtHoTen.Clear();txtDiemTB.Clear();errorProvider1.Clear();txtMaSV.Focus();}
        private void btnDong_Click(object sender,EventArgs e){Close();}
    }
}

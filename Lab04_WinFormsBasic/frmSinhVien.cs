using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Lab04_WinFormsBasic
{
    public class frmSinhVien : FormCoSo
    {
        private readonly TextBox txtMaSV, txtHoTen, txtDuongDanAnh;
        private readonly DateTimePicker dtpNgaySinh;
        private readonly ComboBox cboKhoa;
        private readonly RadioButton radNam, radNu;
        private readonly CheckBox chkDocSach, chkTheThao, chkLapTrinh;
        private readonly Label lblTuoi, lblSoThich;
        private readonly PictureBox picAnh;
        public frmSinhVien(int bai = 1) : base("Bài 1–5 — Thông tin sinh viên", 780)
        {
            Name = "frmSinhVien";
            string[] huongDan = { "Nhập thông tin rồi bấm Hiển thị.", "Danh sách khoa nạp ở Form Load, mặc định khoa đầu và giới tính Nam.",
                "Đổi ngày sinh để Label tuổi cập nhật ngay.", "Tích các sở thích rồi bấm Xem sở thích.", "Bấm Chọn ảnh để mở ảnh PNG/JPG/BMP ở chế độ Zoom." };
            ThemRong(new Label { AutoSize = true, MaximumSize = new Size(700,0), Text = "Bài " + bai + ": " + huongDan[bai - 1] });
            txtMaSV = O("txtMaSV", "SV01"); txtHoTen = O("txtHoTen", "Nguyễn An");
            dtpNgaySinh = new DateTimePicker { Name = "dtpNgaySinh", Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd/MM/yyyy", MaxDate = DateTime.Today, Value = new DateTime(2005,5,12) };
            cboKhoa = new ComboBox { Name = "cboKhoa", DropDownStyle = ComboBoxStyle.DropDownList };
            radNam = new RadioButton { Name = "radNam", Text = "Nam", AutoSize = true };
            radNu = new RadioButton { Name = "radNu", Text = "Nữ", AutoSize = true };
            lblTuoi = KetQua("lblTuoi");
            chkDocSach = new CheckBox { Name = "chkDocSach", Text = "Đọc sách", AutoSize = true };
            chkTheThao = new CheckBox { Name = "chkTheThao", Text = "Thể thao", AutoSize = true };
            chkLapTrinh = new CheckBox { Name = "chkLapTrinh", Text = "Lập trình", AutoSize = true };
            lblSoThich = KetQua("lblSoThich"); lblSoThich.Text = "Chưa chọn";
            picAnh = new PictureBox { Name = "picAnh", SizeMode = PictureBoxSizeMode.Zoom, Size = new Size(180,145), BorderStyle = BorderStyle.FixedSingle };
            txtDuongDanAnh = O("txtDuongDanAnh"); txtDuongDanAnh.ReadOnly = true;
            Hang("Mã sinh viên", txtMaSV); Hang("Họ và tên", txtHoTen); Hang("Ngày sinh", dtpNgaySinh);
            Hang("Tuổi", lblTuoi); Hang("Giới tính", Nhom(radNam,radNu)); Hang("Khoa",cboKhoa);
            Hang("Sở thích",Nhom(chkDocSach,chkTheThao,chkLapTrinh));
            Hang("Đã chọn",lblSoThich); Hang("Ảnh đại diện",Nhom(picAnh)); Hang("Đường dẫn ảnh",txtDuongDanAnh);
            ThemRong(Nhom(Nut("btnHienThi","Hiển thị", HienThi), Nut("btnSoThich","Xem sở thích", HienSoThich),
                Nut("btnChonAnh","Chọn ảnh",()=>Anh.Chon(this,picAnh,txtDuongDanAnh)), Nut("btnDong","Đóng",Close)));
            Load += frmSinhVien_Load;
            dtpNgaySinh.ValueChanged += (s,e) => CapNhatTuoi();
        }
        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            cboKhoa.Items.Clear();
            cboKhoa.Items.AddRange(new object[] { "Công nghệ thông tin", "Công nghệ kỹ thuật ô tô", "Kinh tế" });
            cboKhoa.SelectedIndex = 0; radNam.Checked = true; CapNhatTuoi();
        }
        private void CapNhatTuoi() { lblTuoi.Text = "Tuổi: " + NghiepVu.TinhTuoi(dtpNgaySinh.Value,DateTime.Today); }
        private List<string> LaySoThich()
        {
            var ds = new List<string>();
            if (chkDocSach.Checked) ds.Add("Đọc sách");
            if (chkTheThao.Checked) ds.Add("Thể thao");
            if (chkLapTrinh.Checked) ds.Add("Lập trình");
            return ds;
        }
        private void HienSoThich()
        { var ds = LaySoThich(); lblSoThich.Text = ds.Count == 0 ? "Chưa chọn" : string.Join(", ",ds); }
        private void HienThi()
        {
            var sv = new SinhVien(txtMaSV.Text,txtHoTen.Text,dtpNgaySinh.Value,0)
            { GioiTinh = radNam.Checked ? "Nam" : "Nữ", Khoa = cboKhoa.Text,
                SoThich = LaySoThich(), DuongDanAnh = txtDuongDanAnh.Text };
            HienSoThich(); ThongBao.Hien(this,sv.ThongTin(),"Thông tin sinh viên");
        }
        protected override void Dispose(bool disposing)
        { if (disposing && picAnh != null && picAnh.Image != null) picAnh.Image.Dispose(); base.Dispose(disposing); }
    }
}

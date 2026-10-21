using System;
using System.Windows.Forms;

namespace Lab04_WinFormsBasic
{
    public class frmBmi : FormCoSo
    {
        private readonly TextBox txtChieuCao,txtCanNang;
        private readonly Label lblKetQua;
        public frmBmi():base("Bài 8 — Tính chỉ số BMI",430)
        {
            Name="frmBmi";
            txtChieuCao=O("txtChieuCao");txtCanNang=O("txtCanNang");lblKetQua=KetQua("lblKetQua");
            Hang("Chiều cao (cm)",txtChieuCao);Hang("Cân nặng (kg)",txtCanNang);
            ThemRong(Nhom(Nut("btnTinhBmi","Tính BMI",Tinh),Nut("btnLamMoi","Làm mới",()=>{txtChieuCao.Clear();txtCanNang.Clear();lblKetQua.Text="Chưa có kết quả.";}),Nut("btnDong","Đóng",Close)));
            Hang("Kết quả",lblKetQua);
            ThemRong(new Label { AutoSize=true,MaximumSize=new System.Drawing.Size(680,0),Text="Minh họa công thức BMI người trưởng thành: cân nặng / chiều cao² (m). Phân loại: <18,5 thiếu cân; <25 bình thường; <30 thừa cân; từ 30 béo phì." });
        }
        private void Tinh()
        {
            lblKetQua.Text="Chưa có kết quả.";
            double bmi=NghiepVu.TinhBmi(NghiepVu.DocSo(txtChieuCao.Text),NghiepVu.DocSo(txtCanNang.Text));
            lblKetQua.Text=string.Format("BMI = {0:F2} — {1}",bmi,NghiepVu.PhanLoaiBmi(bmi));
        }
    }
}

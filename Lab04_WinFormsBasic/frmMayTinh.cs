using System;
using System.Windows.Forms;

namespace Lab04_WinFormsBasic
{
    public class frmMayTinh : FormCoSo
    {
        private readonly TextBox txtSoA, txtSoB;
        private readonly Label lblKetQua;
        public frmMayTinh() : base("Bài 6 — Máy tính bốn phép toán", 410)
        {
            Name = "frmMayTinh";
            txtSoA = O("txtSoA"); txtSoB = O("txtSoB"); lblKetQua = KetQua("lblKetQua");
            Hang("Số thứ nhất",txtSoA); Hang("Số thứ hai",txtSoB);
            ThemRong(Nhom(Nut("btnCong","Cộng +",()=>Tinh("+")),Nut("btnTru","Trừ -",()=>Tinh("-")),
                Nut("btnNhan","Nhân ×",()=>Tinh("×")),Nut("btnChia","Chia ÷",()=>Tinh("÷"))));
            Hang("Kết quả",lblKetQua);
            ThemRong(Nhom(Nut("btnLamMoi","Làm mới",()=>{txtSoA.Clear();txtSoB.Clear();lblKetQua.Text="Chưa có kết quả.";txtSoA.Focus();}),Nut("btnThoat","Thoát",Close)));
        }
        private void Tinh(string phep)
        {
            lblKetQua.Text = "Chưa có kết quả.";
            decimal a = NghiepVu.DocSo(txtSoA.Text), b = NghiepVu.DocSo(txtSoB.Text);
            lblKetQua.Text = a + " " + phep + " " + b + " = " + NghiepVu.Tinh(a,b,phep);
        }
    }
}

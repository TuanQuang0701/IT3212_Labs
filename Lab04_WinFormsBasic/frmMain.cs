using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab04_WinFormsBasic
{
    public class frmMain : FormCoSo
    {
        public frmMain() : base("Lab04 — Windows Forms cơ bản", 680)
        {
            Name = "frmMain";
            ThemRong(new Label { AutoSize = true, Text = "Lê Tuấn Quang • 24000641\nChọn bài để mở Form. Bài 1–5 cùng hoàn thiện Form sinh viên.", Margin = new Padding(0,0,0,12) });
            string[] ten = { "Thông tin sinh viên", "Khởi tạo khoa và trạng thái Form", "Tính tuổi từ ngày sinh", "Chọn sở thích", "Chọn ảnh đại diện",
                "Máy tính bốn phép toán", "Form đăng nhập", "Tính chỉ số BMI", "Đăng ký học phần", "Phiếu nhập sản phẩm" };
            var menu = new FlowLayoutPanel { AutoSize = true, FlowDirection = FlowDirection.TopDown,
                WrapContents = false, Margin = new Padding(0) };
            for (int i = 0; i < ten.Length; i++)
            {
                int bai = i + 1;
                var b = Nut("btnBai" + bai, "Bài " + bai + " — " + ten[i], () => MoBai(bai));
                b.AutoSize = false; b.Size = new Size(680,38); menu.Controls.Add(b);
            }
            ThemRong(menu);
        }
        private void MoBai(int bai)
        {
            using (Form f = TaoForm(bai)) f.ShowDialog(this);
        }
        internal static Form TaoForm(int bai)
        {
            if (bai >= 1 && bai <= 5) return new frmSinhVien(bai);
            switch (bai)
            {
                case 6: return new frmMayTinh();
                case 7: return new frmDangNhap();
                case 8: return new frmBmi();
                case 9: return new frmHocPhan();
                case 10: return new frmSanPham();
                default: throw new ArgumentException("Bài không tồn tại.");
            }
        }
    }
}

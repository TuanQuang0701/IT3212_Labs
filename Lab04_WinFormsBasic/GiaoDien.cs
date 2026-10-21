using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Lab04_WinFormsBasic
{
    // Các Form dùng chung cách đặt lề, nhãn và hàng nhập liệu.
    public class FormCoSo : Form
    {
        protected readonly TableLayoutPanel bang;
        protected FormCoSo(string tieuDe, int height = 590)
        {
            Text = tieuDe; Font = new Font("Segoe UI", 10F);
            AutoScaleMode = AutoScaleMode.Font; StartPosition = FormStartPosition.CenterParent;
            ClientSize = new Size(780, height); MinimumSize = new Size(720, 480);
            BackColor = Color.White;
            bang = new TableLayoutPanel { Dock = DockStyle.Fill, Padding = new Padding(24),
                ColumnCount = 2, AutoScroll = true };
            bang.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 155));
            bang.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            Controls.Add(bang);
            var title = new Label { Text = tieuDe, AutoSize = true,
                Font = new Font(Font.FontFamily, 16F, FontStyle.Bold), Margin = new Padding(0,0,0,18) };
            ThemRong(title);
        }
        protected void ThemRong(Control c)
        {
            int i = bang.RowCount++; bang.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            bang.Controls.Add(c, 0, i); bang.SetColumnSpan(c, 2);
        }
        protected void Hang(string nhan, Control c)
        {
            int i = bang.RowCount++; bang.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            bang.Controls.Add(new Label { Text = nhan, AutoSize = true, Margin = new Padding(0,8,10,8) }, 0, i);
            c.Dock = DockStyle.Fill; c.Margin = new Padding(0,4,0,8); bang.Controls.Add(c, 1, i);
        }
        protected TextBox O(string ten, string text = "") { return new TextBox { Name = ten, Text = text }; }
        protected Label KetQua(string ten) { return new Label { Name = ten, AutoSize = true, MaximumSize = new Size(520,0), Text = "Chưa có kết quả.", Margin = new Padding(0,10,0,10) }; }
        protected FlowLayoutPanel Nhom(params Control[] controls)
        {
            var p = new FlowLayoutPanel { AutoSize = true, WrapContents = true, Margin = new Padding(0) };
            p.Controls.AddRange(controls); return p;
        }
        protected Button Nut(string ten, string text, Action action)
        {
            var b = new Button { Name = ten, Text = text, AutoSize = true, MinimumSize = new Size(105,34), Margin = new Padding(0,4,10,4) };
            b.Click += (s,e) => AnToan(action); return b;
        }
        protected void AnToan(Action action)
        {
            try { action(); }
            catch (Exception ex) when (ex is ArgumentException || ex is OverflowException || ex is IOException || ex is UnauthorizedAccessException)
            { ThongBao.Hien(this, ex.Message, "Dữ liệu chưa hợp lệ"); }
        }
    }
    internal static class ThongBao
    {
        internal static bool CheDoKiemThu;
        internal static string Cuoi = "";
        internal static void Hien(IWin32Window owner, string text, string title)
        {
            Cuoi = text;
            if (!CheDoKiemThu) MessageBox.Show(owner, text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    internal static class Anh
    {
        internal static Image Doc(string file)
        {
            if (!File.Exists(file)) throw new ArgumentException("Không tìm thấy tệp ảnh.");
            string ext = Path.GetExtension(file).ToLowerInvariant();
            if (ext != ".png" && ext != ".jpg" && ext != ".jpeg" && ext != ".bmp")
                throw new ArgumentException("Chỉ nhận ảnh PNG, JPG, JPEG hoặc BMP.");
            try
            {
                using (var source = Image.FromFile(file)) return new Bitmap(source);
            }
            catch (Exception ex) when (ex is ArgumentException || ex is OutOfMemoryException)
            { throw new ArgumentException("Tệp không phải ảnh hợp lệ hoặc ảnh quá lớn."); }
        }
        internal static void Gan(PictureBox box, string file)
        { var moi = Doc(file); var cu = box.Image; box.Image = moi; if (cu != null) cu.Dispose(); }
        internal static void Chon(Form form, PictureBox box, TextBox path)
        {
            using (var dlg = new OpenFileDialog { Filter = "Ảnh|*.png;*.jpg;*.jpeg;*.bmp", CheckFileExists = true,
                InitialDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images") })
            {
                if (dlg.ShowDialog(form) != DialogResult.OK) return;
                Gan(box, dlg.FileName); path.Text = dlg.FileName;
            }
        }
    }
}

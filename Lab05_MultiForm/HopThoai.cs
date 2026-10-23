using System.Windows.Forms;
namespace Lab05_MultiForm
{
    internal static class HopThoai
    {
        internal static bool KiemThu;
        internal static DialogResult TraLoi=DialogResult.Yes;
        internal static string Cuoi="";
        internal static void Bao(IWin32Window owner,string text)
        {Cuoi=text;if(!KiemThu)MessageBox.Show(owner,text,"Lab05",MessageBoxButtons.OK,MessageBoxIcon.Information);}
        internal static bool XacNhan(IWin32Window owner)
        {
            return (KiemThu?TraLoi:MessageBox.Show(owner,"Bạn có muốn đóng ứng dụng? Dữ liệu trong bộ nhớ chưa được ghi ra file.",
                "Xác nhận thoát",MessageBoxButtons.YesNo,MessageBoxIcon.Question))==DialogResult.Yes;
        }
    }
}

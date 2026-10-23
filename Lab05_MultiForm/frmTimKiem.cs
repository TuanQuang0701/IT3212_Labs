using System;
using System.Linq;
using System.Windows.Forms;
namespace Lab05_MultiForm
{
    public partial class frmTimKiem:Form
    {
        private readonly DuLieu _duLieu;
        public SinhVien KetQua{get;private set;}
        public frmTimKiem():this(new DuLieu()){}
        public frmTimKiem(DuLieu duLieu){InitializeComponent();_duLieu=duLieu;}
        private void btnTim_Click(object sender,EventArgs e)
        {
            lstKetQua.Items.Clear();lstKetQua.Items.AddRange(_duLieu.Tim(txtTuKhoa.Text).Cast<object>().ToArray());
            lblSoLuong.Text="Tìm thấy "+lstKetQua.Items.Count+" sinh viên.";
            btnChon.Enabled=false;
        }
        private void lstKetQua_SelectedIndexChanged(object sender,EventArgs e){btnChon.Enabled=lstKetQua.SelectedItem is SinhVien;}
        private void btnChon_Click(object sender,EventArgs e)
        {
            KetQua=lstKetQua.SelectedItem as SinhVien;
            if(KetQua==null)return;
            DialogResult=DialogResult.OK;Close();
        }
        private void btnHuy_Click(object sender,EventArgs e){DialogResult=DialogResult.Cancel;Close();}
    }
}

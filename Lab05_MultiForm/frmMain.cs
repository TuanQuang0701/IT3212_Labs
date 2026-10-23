using System;
using System.Windows.Forms;
namespace Lab05_MultiForm
{
    public partial class frmMain:Form
    {
        private readonly DuLieu _duLieu;
        private readonly GioiHanDangNhap _dangNhap=new GioiHanDangNhap();
        public frmMain():this(DuLieu.TaoMau()){}
        public frmMain(DuLieu duLieu)
        {InitializeComponent();_duLieu=duLieu;CapNhatDongHo();timerDongHo.Start();}
        internal DuLieu KhoDuLieu {get{return _duLieu;}}
        internal void OpenChildForm(Form child)
        {
            foreach(Form f in MdiChildren)
                if(f.GetType()==child.GetType()){f.Activate();child.Dispose();return;}
            child.MdiParent=this;child.StartPosition=FormStartPosition.Manual;
            child.Location=new System.Drawing.Point(4,4);
            child.Show();lblTrangThai.Text="Đang mở: "+child.Text;
        }
        private void mnuSinhVien_Click(object sender,EventArgs e){OpenChildForm(new frmSinhVien(_duLieu));}
        private void mnuKhoa_Click(object sender,EventArgs e){OpenChildForm(new frmKhoa(_duLieu.Khoas));}
        private void mnuGioiThieu_Click(object sender,EventArgs e){OpenChildForm(new frmGioiThieu());}
        private void mnuTimKiem_Click(object sender,EventArgs e)
        {
            using(var f=new frmTimKiem(_duLieu))
                if(f.ShowDialog(this)==DialogResult.OK)
                {using(var detail=new frmChiTietSinhVien(f.KetQua))detail.ShowDialog(this);}
        }
        private void mnuDangNhap_Click(object sender,EventArgs e)
        {using(var f=new frmDangNhap(_dangNhap))if(f.ShowDialog(this)==DialogResult.OK)lblTrangThai.Text="Đăng nhập mẫu thành công: sinhvien";}
        private void mnuThoat_Click(object sender,EventArgs e){Close();}
        private void timerDongHo_Tick(object sender,EventArgs e){CapNhatDongHo();}
        private void CapNhatDongHo(){lblDongHo.Text=DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");}
        private void frmMain_FormClosing(object sender,FormClosingEventArgs e)
        {
            if(e.CloseReason==CloseReason.WindowsShutDown||e.CloseReason==CloseReason.TaskManagerClosing)return;
            if(!HopThoai.XacNhan(this))e.Cancel=true;
        }
    }
}

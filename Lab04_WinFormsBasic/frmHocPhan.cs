using System;
using System.Linq;
using System.Windows.Forms;

namespace Lab04_WinFormsBasic
{
    public class HocPhan
    {
        public string Ten {get;private set;}
        public int SoTinChi {get;private set;}
        public HocPhan(string ten,int tc){Ten=ten;SoTinChi=tc;}
        public override string ToString(){return Ten+" — "+SoTinChi+" tín chỉ";}
    }
    public class frmHocPhan:FormCoSo
    {
        private readonly CheckedListBox clbHocPhan;
        private readonly Label lblTongTinChi,lblDaChon;
        public frmHocPhan():base("Bài 9 — Đăng ký học phần",560)
        {
            Name="frmHocPhan";
            clbHocPhan=new CheckedListBox {Name="clbHocPhan",CheckOnClick=true,Height=180,IntegralHeight=false};
            clbHocPhan.Items.AddRange(new object[]{new HocPhan("Lập trình .NET",3),new HocPhan("Cơ sở dữ liệu",3),
                new HocPhan("Tiếng Anh",2),new HocPhan("Mạng máy tính",3),new HocPhan("Kỹ năng mềm",2)});
            lblTongTinChi=KetQua("lblTongTinChi");lblDaChon=KetQua("lblDaChon");
            Hang("Chọn học phần",clbHocPhan);Hang("Tổng tín chỉ",lblTongTinChi);Hang("Đã đăng ký",lblDaChon);
            ThemRong(Nhom(Nut("btnDangKy","Đăng ký",DangKy),Nut("btnBoChon","Bỏ chọn tất cả",BoChon),Nut("btnDong","Đóng",Close)));
            clbHocPhan.ItemCheck+=(s,e)=>
            {
                // ItemCheck xảy ra trước khi CheckedItems cập nhật.
                int tong=0;
                for(int i=0;i<clbHocPhan.Items.Count;i++)
                    if(i==e.Index?e.NewValue==CheckState.Checked:clbHocPhan.GetItemChecked(i))
                        tong+=((HocPhan)clbHocPhan.Items[i]).SoTinChi;
                lblTongTinChi.Text=tong+" tín chỉ";lblDaChon.Text="Chưa xác nhận đăng ký.";
            };
            lblTongTinChi.Text="0 tín chỉ";lblDaChon.Text="Chưa chọn học phần.";
        }
        private void DangKy()
        {
            if(clbHocPhan.CheckedItems.Count==0){lblDaChon.Text="Hãy chọn ít nhất một học phần.";return;}
            lblDaChon.Text=string.Join("\n",clbHocPhan.CheckedItems.Cast<HocPhan>().Select(x=>x.ToString()));
        }
        private void BoChon()
        {for(int i=0;i<clbHocPhan.Items.Count;i++)clbHocPhan.SetItemChecked(i,false);lblDaChon.Text="Chưa chọn học phần.";}
    }
}

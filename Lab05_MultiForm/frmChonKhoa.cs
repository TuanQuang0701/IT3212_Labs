using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
namespace Lab05_MultiForm
{
    public partial class frmChonKhoa:Form
    {
        public string KhoaDaChon{get;private set;}
        public frmChonKhoa(){InitializeComponent();}
        public frmChonKhoa(IEnumerable<string> khoas,string hienTai):this()
        {
            lstKhoa.Items.AddRange(khoas.Cast<object>().ToArray());
            if(lstKhoa.Items.Contains(hienTai))lstKhoa.SelectedItem=hienTai;
            btnChon.Enabled=lstKhoa.SelectedIndex>=0;
        }
        private void lstKhoa_SelectedIndexChanged(object sender,EventArgs e){btnChon.Enabled=lstKhoa.SelectedIndex>=0;}
        private void btnChon_Click(object sender,EventArgs e)
        {
            if(lstKhoa.SelectedIndex<0)return;
            KhoaDaChon=(string)lstKhoa.SelectedItem;DialogResult=DialogResult.OK;Close();
        }
        private void btnHuy_Click(object sender,EventArgs e){DialogResult=DialogResult.Cancel;Close();}
    }
}

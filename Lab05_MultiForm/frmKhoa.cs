using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
namespace Lab05_MultiForm
{
    public partial class frmKhoa:Form
    {
        public frmKhoa(){InitializeComponent();}
        public frmKhoa(IEnumerable<string> khoas):this(){lstKhoa.Items.AddRange(khoas.Cast<object>().ToArray());}
        private void btnDong_Click(object sender,EventArgs e){Close();}
    }
}

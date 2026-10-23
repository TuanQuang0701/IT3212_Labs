using System;
using System.Windows.Forms;
namespace Lab05_MultiForm
{
    internal static class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if(args.Length==2 && args[0]=="--test")
            {Environment.ExitCode=KiemThu.Chay(args[1]);return;}
            Application.Run(new frmMain());
        }
    }
}

using System;
using System.Windows.Forms;

namespace VSP_46275z_MyProject
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new RegisterForm());

            Application.Run(new RegisterForm());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MainInterface
{
    namespace WindowsFormsApplication1
    {
        static class Program
        {
            /// <summary>
            /// Главная точка входа для приложения.
            /// </summary>
            ///
            [STAThread]
            static void Main()
            {
                Presenter _presenter = new Presenter();
                Application.EnableVisualStyles();             
                Application.SetCompatibleTextRenderingDefault(false);               
                Application.Run(new MainWindow(_presenter));
            }
        }
    }
}

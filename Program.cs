using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Pulsuz_Mesaj
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            formMain fm = new formMain();
            Application.Run(new Splash(fm));
            Application.Run(fm);
        }
    }
}

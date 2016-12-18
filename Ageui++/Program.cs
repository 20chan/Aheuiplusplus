using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Ageui__
{
    static class Program
    {
        [STAThread]
        static void Main(String[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(args));
        }
    }
}

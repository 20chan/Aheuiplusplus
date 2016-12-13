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
            if (args.Length == 0)
                Application.Run(new MainForm());
            else
                Application.Run(new MainForm(args[0]));
        }
    }
}

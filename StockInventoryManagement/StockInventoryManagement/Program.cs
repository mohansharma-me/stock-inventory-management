using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StockInventoryManagement
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
            Job.mainForm = new frmMain();
            Application.Run(Job.mainForm);
        }
    }
}

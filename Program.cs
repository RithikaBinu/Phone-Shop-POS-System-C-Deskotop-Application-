using I_CARE_Phone_Shop_C__Project;
using System;
using System.Windows.Forms;

namespace ICarePOS
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Initializes and creates ICarePOS.db and all tables on startup
            DatabaseHelper.InitializeDatabase();

            Application.Run(new Form1()); // Or your startup form
        }
    }
}
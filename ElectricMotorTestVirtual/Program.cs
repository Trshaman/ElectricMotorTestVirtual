using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectricMotorTestVirtual
{
    static class Program
    {
        internal static string SettingDir;
        internal static string ReportDir;
        internal static bool ProgramClosing;
        internal static bool CancelStartUp;
        internal static string TestSettingFile;
        internal static string TestRecipeSettingFile;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
   //         Application.Run(new MainMenu());
        }
    }
}
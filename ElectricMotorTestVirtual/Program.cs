using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
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
        internal static string TestTableName;
        internal static bool IsServer;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
         static void Main(string[] parameter)
        {
            CultureInfo cultureInfo = (CultureInfo)Thread.CurrentThread.CurrentCulture.Clone();
            cultureInfo.NumberFormat.NumberDecimalSeparator = ".";
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            if (parameter != null && parameter.Length > 0)
                IsServer = parameter[0] == "server";
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            TestTableName = "Test";

         //   Application.Run(new MainMenu());



        }

    }
}
using ElectricMotorTestVirtual.Forms.WinForm;
using ElectricMotorTestVirtual.OOP_Approach.Recipe;
using ElectricMotorTestVirtual.OOP_Approach.Settings;
using ElectricMotorTestVirtual.OOP_Approach.TestRunner;
using GlobalFunctions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
        public static frmLog LogForm;
        internal static string TestFileBackupDir;
        internal static string TestsFile;
        internal static List<Log> StartUpLogs;
        internal static string UserSettingsFile;
        internal static string ProgramIniFile;
        internal static List<TestSettings> TestList;
        internal static SettingsData ProgamSettings;

        internal static bool AddNewTest = false;
        internal static bool AdjustTest = false;
        internal static string AdjustedTestName;

        internal readonly static int  TestParameter = 0;
        internal readonly static int  TestUnit = 1;
        internal readonly static int  TestMaxLimit = 2;
        internal readonly static int  TestMeasuredValue = 3;
        internal readonly static int  TestMinLimit = 4;
        internal readonly static int  TestResult = 5;



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




            //ToDo: settins ve kayıtlar kontrol edilecek.
            //log formuna eklenicek.
            DoStartUp();
            Application.Run(new MainScreen1());

        }

        private static void DoStartUp()
        {
            StartUpLogs = new List<Log>();
            SettingDir = Directory.GetCurrentDirectory() + "\\Settings\\";
            TestFileBackupDir = Directory.GetCurrentDirectory() + "\\ActualTestsState\\Backups\\";
            if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\ActualTestsState\\"))
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\ActualTestsState\\");
            if (!Directory.Exists(TestFileBackupDir))
                Directory.CreateDirectory(TestFileBackupDir);
            TestsFile = Directory.GetCurrentDirectory() + "\\ActualTestsState\\TestStateFile.xml";

            if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\Reports\\"))
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\Reports\\");
            ReportDir = Directory.GetCurrentDirectory() + "\\Reports\\";
            UserSettingsFile = SettingDir + "UserSettings.ini";
            TestSettingFile = SettingDir + "TestSettings.ini";
            ProgramIniFile = SettingDir + "program.ini";
            string iniFileXmlHeader = "ProgramInit";
            if (!Directory.Exists(SettingDir))
            {
                MessageBox.Show("\\Settings klasörü bulunamadı. Yeniden oluşturulacak, tüm test,istasyon,kullanıcı bilgileri tanımlanmalıdır. ", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                StartUpLogs.Add(new Log(DateTime.Now, LogTypes.System, 5, -1, -1, "\\Settings klasörü bulunamadı. Yeniden oluşturulacak, tüm test,istasyon,kullanıcı bilgileri tanımlanmalıdır. ", System.Drawing.SystemIcons.Error));
                Directory.CreateDirectory(SettingDir);
            }
            TestList = TestSettings.LoadTestsFromXML(TestSettingFile);
            if (TestList == null)
                TestList = new List<TestSettings>();
            ProgamSettings = SettingsData.LoadSettingsFromXML(ProgramIniFile);
            if(ProgamSettings == null)
                ProgamSettings = new SettingsData();
            //ToDo:init ayarları yapılabilir.

            //if (!CheckCreateSystemDatabaseAndTables())
            //   return false;

            //Logger.ConnectionString = Program.ConStringDatabase;
            //User.LoadUserListFromFile(UserSettingsFile);
            //if (!System.Diagnostics.Debugger.IsAttached)
            //{
            //    frmLogIn frmue = new frmLogIn();
            //    frmue.ShowDialog();
            //    if (CancelStartUp)
            //        return CancelStartUp;
            //}
            //else
            //    User.ActiveUser = new User("Admin", UserLevels.Admin, "emtest4001");

        }
    }
}
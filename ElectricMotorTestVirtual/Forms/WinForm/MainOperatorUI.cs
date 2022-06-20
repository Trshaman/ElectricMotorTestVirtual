using ElectricMotorTestVirtual.OOP_Approach.Recipe;
using ElectricMotorTestVirtual.OOP_Approach.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectricMotorTestVirtual.Forms.WinForm
{
    public partial class MainOperatorUI : Form
    {
        public static DataGridView ResultTable;
        private SettingsData _programDataSettings;
        private List<TestSettings> _testList;
        private TestSettings _selectedTestSettings;

        public MainOperatorUI()
        {
            InitializeComponent();
            _programDataSettings = SettingsData.LoadSettingsFromXML(Program.ProgramIniFile);
            _testList = Program.TestList;
            _selectedTestSettings = _testList.FirstOrDefault(tst => tst.Name == _programDataSettings.SelectedTest);
            TxbxSelectedTest.Text = _programDataSettings.SelectedTest;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



      
    }
}

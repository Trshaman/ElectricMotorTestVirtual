using ElectricMotorTestVirtual.OOP_Approach.Recipe;
using ElectricMotorTestVirtual.OOP_Approach.Settings;
using ElectricMotorTestVirtual.OOP_Approach.TestRunner;
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
        private List<TestRecipeClass> _testList;
        private TestRecipeClass _selectedRecipe;
        private TestRunner _testRunner;

        public MainOperatorUI()
        {
            InitializeComponent();
            
            _programDataSettings = SettingsData.LoadSettingsFromXML(Program.ProgramIniFile);
            _testList = Program.TestList;
            _selectedRecipe = _testList.FirstOrDefault(tst => tst.Name == _programDataSettings.SelectedTest);
            TxbxSelectedTest.Text = _programDataSettings.SelectedTest;
            _testRunner = new TestRunner(_selectedRecipe, _programDataSettings);
            initUI();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void initUI()
        {
            TestOK.Value = false;
            TestNOK.Value = false;
            TestResultTable.Rows.Clear();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            TestOK.Value = false;
            TestNOK.Value = false;
            if (_testRunner.RunTest(TestResultTable))
            {
                TestOK.Value = true;
            }
            else
            {
                TestNOK.Value = true;
            }
        }
    }
}

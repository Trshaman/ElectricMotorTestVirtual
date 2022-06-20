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
    public partial class RecipeSelectionPage : Form
    {
        private TestRecipeSettings _testRecipeSettings;
        private SettingsData _currentSettingsData;
        public RecipeSelectionPage()
        {
            _currentSettingsData = Program.ProgamSettings;
           
            InitializeComponent();
            TxbxSelectedTest.Text = _currentSettingsData.SelectedTest;
            if (Program.TestList!=null)
            {
                TestList.Items.AddRange(Program.TestList.ToArray());
                BtnClose.Click +=  (object sender, EventArgs e) => { this.Close(); };
            }
            
        }

        private void AddRecipe_Click(object sender, EventArgs e)
        {
            if (_testRecipeSettings == null)
            {
                Program.AddNewTest = true;
                _testRecipeSettings = new TestRecipeSettings();
                _testRecipeSettings.HandleDestroyed += (object send, EventArgs e2) => { _testRecipeSettings = null;  Program.AddNewTest = false; UpdateTestList(); };
               // _testRecipeSettings.MdiParent = this;
                _testRecipeSettings.Show();
            }
            else
            {
                _testRecipeSettings.Focus();
            }
        }

        private void AdjustRecipe_Click(object sender, EventArgs e)
        {
            if (_testRecipeSettings == null)
            {
                
                if (!string.IsNullOrEmpty(TestList.Text))
                {
                    Program.AdjustTest = true;
                    Program.AdjustedTestName = TestList.Text;
                    _testRecipeSettings = new TestRecipeSettings();
                    _testRecipeSettings.HandleDestroyed += (object send, EventArgs e2) => { _testRecipeSettings = null; Program.AdjustTest = false; UpdateTestList(); };
                    // _testRecipeSettings.MdiParent = this;
                    _testRecipeSettings.Show();
                }
                else
                {
                    MessageBox.Show("Herhangi bir test seçilmedi", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
              
            }
            else
            {
                _testRecipeSettings.Focus();
            }
        }

        private void UpdateTestList()
        {
            TestList.Items.Clear();
            TestList.Items.AddRange(Program.TestList.ToArray());
        }

        private void BtnSelectTest_Click(object sender, EventArgs e)
        {
            _currentSettingsData.SelectedTest = TestList.Text; ;
            SettingsData.SaveSettingsAsXML(Program.ProgramIniFile, _currentSettingsData);
            TxbxSelectedTest.Text = TestList.Text;

        }
    }
    
}

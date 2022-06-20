using ElectricMotorTestVirtual.OOP_Approach.Recipe;
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
    public partial class TestRecipeSettings : Form
    {
        private TestSettings _CurrentTestSettings;
        private List<TestSettings> _testList;
        private TestRecipe _CurrentTestRecipe;
        private string _editedTestName;
        private bool _isTestNameFree;
        public TestRecipeSettings()
        {
            InitializeComponent();
            _testList = Program.TestList;
            _CurrentTestSettings = new TestSettings();
            BtnExit.Click += (object sender, EventArgs e) => { this.Close(); };
            if (Program.AddNewTest)
            {
             
            }
            else
            {
                _CurrentTestSettings = _testList.FirstOrDefault(tst => tst.Name == Program.SelectedTestName);
               // TestRunnerClass.PrapareTestRecipe(_CurrentTestSettings);
                LoadTestToUI(_CurrentTestSettings);
            }
            
        }

       

        private void hvTestUserInterface1_Load(object sender, EventArgs e)
        {

        }

        private void hvTestUserInterface2_Load(object sender, EventArgs e)
        {

        }

         

        private void lcrTest2_Load(object sender, EventArgs e)
        {

        }

        private void LoadTestToUI(TestSettings testSettings)
        {
            TestName.Text = testSettings.Name;
            TestDescription.Text = testSettings.TestDescription;
            hvTestUserInterface2.LoadTestToUIHV(testSettings.RecipeSettings.HVTestRecipe);
            emK_Test1.LoadTestToUIEmk(testSettings.RecipeSettings.EmkTestRecipe);
            performansTest2.LoadTestToUIPerformance(testSettings.RecipeSettings.PerformanceTestRecipe);
            lcrTest2.LoadTestToUILCR(testSettings.RecipeSettings.LCRTestRecipe);

        }

        private void LoadUIToTest(TestSettings testSettings)
        {
            testSettings.Name = TestName.Text;
            testSettings.TestDescription = TestDescription.Text;
            hvTestUserInterface2.LoadUItoTestHV(testSettings.RecipeSettings.HVTestRecipe);
            emK_Test1.LoadUItoTestEmk(testSettings.RecipeSettings.EmkTestRecipe);
            performansTest2.LoadUItoTestPerformance(testSettings.RecipeSettings.PerformanceTestRecipe);
            lcrTest2.LoadUIToTestLCR(testSettings.RecipeSettings.LCRTestRecipe);

        }

        private void Save_Click(object sender, EventArgs e)
        {
           
            
                if (_testList != null)
                {
                        if (MessageBox.Show("Testi kayıt etmek istiyor musunuz?", "Onay", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            if (Program.AdjustTest)
                            {
                                   if (Program.SelectedTestName != TestName.Text)
                                   {
                                        _isTestNameFree = _testList.FindLast(test => test.Name == TestName.Text) != null;
                                      
                                   }
                                   if (_isTestNameFree)
                                   {
                                     MessageBox.Show("Aynı isimde bir test mevcut lütfen eşsiz bir isim giriniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                   }
                                   else
                                   {
                                     
                                     LoadUIToTest(_CurrentTestSettings);
                                     if (_CurrentTestSettings.IsTestSettingsAppropriate())
                                     {
                                      TestSettings.SaveTestsAsXML(Program.TestSettingFile, _testList);
                                      MessageBox.Show("Test Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                     }
                                    
                                   }
                                
                            }
                            else
                            {
                                LoadUIToTest(_CurrentTestSettings);
                               if (_CurrentTestSettings.IsTestSettingsAppropriate())
                               {
                                   _isTestNameFree = _testList.FindLast(test => test.Name == TestName.Text) == null;
                                   if (_isTestNameFree)
                                   {
                                       _testList.Add(_CurrentTestSettings);
                                       TestSettings.SaveTestsAsXML(Program.TestSettingFile, _testList);
                                       MessageBox.Show("Test Oluştruldu.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                   }
                                   else
                                   {
                                       MessageBox.Show("Aynı isimde bir test mevcut lütfen eşsiz bir isim giriniz.", "Bilgi", MessageBoxButtons.OK,  MessageBoxIcon.Information);
                                   }

                               }

                            }
                        
                        }
                    
                }
                else
                {
                    if (MessageBox.Show("Testi kayıt etmek istiyor musunuz?", "Onay", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        _testList.Add(_CurrentTestSettings);
                        TestSettings.SaveTestsAsXML(Program.TestSettingFile, _testList);
                        MessageBox.Show("Test güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            
            
 
        }
    }
    
}
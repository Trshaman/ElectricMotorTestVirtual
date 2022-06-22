using ElectricMotorTestVirtual.Entity;
using ElectricMotorTestVirtual.OOP_Approach.Recipe;
using ElectricMotorTestVirtual.OOP_Approach.Settings;
using ElectricMotorTestVirtual.OOP_Approach.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectricMotorTestVirtual.OOP_Approach.TestRunner
{
    public  class TestRunner
    {
        public static string SelectedTestName;
        private TestRecipeClass _selectedTestRecipe;
        private SettingsData _testSettings;
        private TestResult _testResult;
        private IGenericRepository<TestResult> repository = new GenericRepository<TestResult>();
        private int TestResultindx;
        private static void initRelayMatrix()
        {

        }
        public TestRunner(TestRecipeClass selectedRecipe, SettingsData testSettings)
        {
            _selectedTestRecipe = selectedRecipe;
            _testSettings = testSettings;
            
        }
        private void checkDeviceConnection()
        {
            
        }
        public void logTestSQL(String serialNumber)
        {
            _testResult = new TestResult()
            {
                Date = DateTime.Now,
                SerialNumber = serialNumber,
                Result = false,
                HVTestActive = _selectedTestRecipe.RecipeSettings.HVTestRecipe.IsTestActive,
                EMKTestActive = _selectedTestRecipe.RecipeSettings.EmkTestRecipe.IsTestActive,
                LCRTestActive =
                _selectedTestRecipe.RecipeSettings.LCRTestRecipe.IsTestActive,
                PerformanceTestActive =
                _selectedTestRecipe.RecipeSettings.PerformanceTestRecipe.IsTestActive,

            };
            repository.Insert(_testResult);
            repository.Save();
            var LastTestResultTable = repository.GetLastRow();
            TestResultindx = LastTestResultTable.Id;
        }


        public bool RunTest(DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
            bool testResult = true;
            checkDeviceConnection();
            initRelayMatrix();
            foreach (ITestOperation test in _selectedTestRecipe.RecipeSettings.GetTestList())
            {
                
                if (test.ExecuteTest(dataGridView, TestResultindx))
                {

                }
                else
                {
                    testResult = false;
                    break;
                }     
            }
            return testResult;
        }
           
        

       
     


    }
}

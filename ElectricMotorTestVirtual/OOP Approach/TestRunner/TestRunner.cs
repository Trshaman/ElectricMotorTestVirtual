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
        private static void initRelayMatrix()
        {

        }
        public TestRunner(TestRecipeClass selectedRecipe, SettingsData testSettings)
        {
            _selectedTestRecipe = selectedRecipe;
            _testSettings = testSettings;
        }
        private static void checkDeviceConnection()
        {

        }


        public bool RunTest(DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
            bool testResult = true;
            checkDeviceConnection();
            initRelayMatrix();
            foreach (ITestOperation test in _selectedTestRecipe.RecipeSettings.GetTestList())
            {
                
                if (test.ExecuteTest(dataGridView))
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

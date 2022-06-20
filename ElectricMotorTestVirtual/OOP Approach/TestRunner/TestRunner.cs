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
            checkDeviceConnection();
            initRelayMatrix();
            var DENEME = _selectedTestRecipe.RecipeSettings.GetType().GetMembers();
            var DENEME2 = _selectedTestRecipe.RecipeSettings.GetType().GetProperties();

            foreach (var testCases in _selectedTestRecipe.RecipeSettings.GetType().GetProperties())
            {
                var obj = testCases.PropertyType.BaseType;
                if (testCases.PropertyType.BaseType == typeof(TestCase))
                {
                    var obj2 = testCases.GetType().GetProperties().GetValue()
                }
                //initRelayMatrix();
                //if (testCases.ExecuteTest(dataGridView) == TestStates.TestResultNOK)
                //{
                //     return false;
                //    break;
                   
                //}
              
            }
            return true;
        }

        


    }
}

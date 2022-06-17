using ElectricMotorTestVirtual.OOP_Approach.Recipe;
using ElectricMotorTestVirtual.OOP_Approach.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricMotorTestVirtual.OOP_Approach.TestRunner
{
    public static class TestRunnerClass
    {

        public static void PrapareTestRecipe(TestSettings SelectedTest)
        {
            foreach (ITestOperation testCases in SelectedTest.RecipeSettings.GetType().GetProperties())
            {
                testCases.ExecuteTest();
            }
         
        }


    }
}

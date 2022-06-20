using ElectricMotorTestVirtual.OOP_Approach.Recipe;
using ElectricMotorTestVirtual.OOP_Approach.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectricMotorTestVirtual.OOP_Approach.TestRunner
{
    public static class TestRunnerClass
    {
        public static string SelectedTestName;
        private static void initRelayMatrix()
        {

        }
        private static void checkDeviceConnection()
        {

        }

        public static void RunTest(TestSettings SelectedTest,DataGridView dataGridView)
        {
            checkDeviceConnection();
            initRelayMatrix();

            foreach (ITestOperation testCases in SelectedTest.RecipeSettings.GetType().GetProperties())
            {
                initRelayMatrix();
                if (testCases.ExecuteTest(dataGridView) == TestStates.TestResultNOK)
                {
                    break;
                } 

            }
         
        }

        


    }
}

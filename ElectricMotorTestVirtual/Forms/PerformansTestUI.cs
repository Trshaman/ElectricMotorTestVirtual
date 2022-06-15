using ElectricMotorTestVirtual.OOP_Approach.Recipe;
using ElectricMotorTestVirtual.OOP_Approach.TestCases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectricMotorTestVirtual.Forms
{
    public partial class PerformansTestUI : UserControl
    {
        public PerformansTestUI()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public void LoadTestToUIPerformance(TestSettings test)
        {
            UnloadPerformRpm_Max.Value = test.RecipeSettings.PerformanceTestRecipe.UnloadPerformanceRpmMax;
            UnloadPerformRpm_Min.Value = test.RecipeSettings.PerformanceTestRecipe.UnloadPerformanceRpmMin;
            LoadPerformRpm_Max.Value = test.RecipeSettings.PerformanceTestRecipe.LoadPerformanceRpmMax;
            LoadPerformRpm_Min.Value = test.RecipeSettings.PerformanceTestRecipe.LoadPerformanceRpmMin;
            LoadTorqueNm_Point1.Value = test.RecipeSettings.PerformanceTestRecipe.LoadTorque1Nm;
            LoadTorqueNm_Point2.Value = test.RecipeSettings.PerformanceTestRecipe.LoadTorque2Nm;
            PerformTestActive.Checked = test.RecipeSettings.PerformanceTestRecipe.IsTestActive;

        }

        public void LoadUItoTestPerformance(TestSettings test)
        {
            test.RecipeSettings.PerformanceTestRecipe.UnloadPerformanceRpmMax = (int)UnloadPerformRpm_Max.Value;
            test.RecipeSettings.PerformanceTestRecipe.UnloadPerformanceRpmMax = (int)UnloadPerformRpm_Min.Value;
            test.RecipeSettings.PerformanceTestRecipe.LoadPerformanceRpmMax = (int)LoadPerformRpm_Max.Value;
            test.RecipeSettings.PerformanceTestRecipe.LoadPerformanceRpmMin = (int)LoadPerformRpm_Min.Value;
            test.RecipeSettings.PerformanceTestRecipe.LoadTorque1Nm = LoadTorqueNm_Point1.Value;
            test.RecipeSettings.PerformanceTestRecipe.LoadTorque2Nm = LoadTorqueNm_Point2.Value;
            test.RecipeSettings.PerformanceTestRecipe.IsTestActive = PerformTestActive.Checked; 
        }
    }
}

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
    public partial class LCRTestUI : UserControl
    {
        public LCRTestUI()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        public void LoadTestToUILCR(TestSettings test)
        {
            R1Ohm_Max.Value = test.RecipeSettings.LCRTestRecipe.R1Max;
            R1Ohm_Min.Value = test.RecipeSettings.LCRTestRecipe.R1Min;
            R2Ohm_Max.Value = test.RecipeSettings.LCRTestRecipe.R2Max;
            R2Ohm_Max.Value = test.RecipeSettings.LCRTestRecipe.R2Min;
            R3Ohm_Max.Value = test.RecipeSettings.LCRTestRecipe.R3Max;
            R3Ohm_Min.Value = test.RecipeSettings.LCRTestRecipe.R3Min;
            L1Inductance_Max.Value = test.RecipeSettings.LCRTestRecipe.L1Max;
            L1Inductance_Min.Value = test.RecipeSettings.LCRTestRecipe.L1Min;
            L2Inductance_Max.Value = test.RecipeSettings.LCRTestRecipe.L2Max;
            L2Inductance_Min.Value = test.RecipeSettings.LCRTestRecipe.L2Min;
            L3Inductance_Max.Value = test.RecipeSettings.LCRTestRecipe.L3Max;
            L3Inductance_Min.Value = test.RecipeSettings.LCRTestRecipe.L3Min;
            LCRTestActive.Checked = test.RecipeSettings.LCRTestRecipe.IsTestActive;
        }

        public void LoadUIToTestLCR(TestSettings test)
        {
            test.RecipeSettings.LCRTestRecipe.R1Max = R1Ohm_Max.Value;
            test.RecipeSettings.LCRTestRecipe.R1Min = R1Ohm_Min.Value;
            test.RecipeSettings.LCRTestRecipe.R2Max = R2Ohm_Max.Value;
            test.RecipeSettings.LCRTestRecipe.R2Min = R2Ohm_Max.Value;
            test.RecipeSettings.LCRTestRecipe.R3Max = R3Ohm_Max.Value;
            test.RecipeSettings.LCRTestRecipe.R3Min = R3Ohm_Min.Value;
            test.RecipeSettings.LCRTestRecipe.L1Max = L1Inductance_Max.Value;
            test.RecipeSettings.LCRTestRecipe.L1Min = L1Inductance_Min.Value;
            test.RecipeSettings.LCRTestRecipe.L2Max = L2Inductance_Max.Value;
            test.RecipeSettings.LCRTestRecipe.L2Min = L2Inductance_Min.Value;
            test.RecipeSettings.LCRTestRecipe.L3Max = L3Inductance_Max.Value;
            test.RecipeSettings.LCRTestRecipe.L3Min = L3Inductance_Min.Value;
            test.RecipeSettings.LCRTestRecipe.IsTestActive = LCRTestActive.Checked;
        }
    }
}

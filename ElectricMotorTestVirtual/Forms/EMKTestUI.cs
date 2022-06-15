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
    public partial class EMK_Test : UserControl
    {
        public EMK_Test()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void performansTest3_Load(object sender, EventArgs e)
        {

        }

        public void LoadTestToUIEmk(TestSettings test)
        {
            PeaktoPeakV_Max.Value = test.RecipeSettings.EmkTestRecipe.PeakToPeaxMax;
            PeaktoPeakV_Min.Value = test.RecipeSettings.EmkTestRecipe.PeakToPeaxMin;
            RmsV_Max.Value = test.RecipeSettings.EmkTestRecipe.RmsMax;
            RmsV_Min.Value = test.RecipeSettings.EmkTestRecipe.RmsMin;
            EmkTestActive.Checked = test.RecipeSettings.EmkTestRecipe.IsTestActive;
        }

        public void LoadUItoTestEmk(TestSettings test)
        {
            test.RecipeSettings.EmkTestRecipe.PeakToPeaxMax = PeaktoPeakV_Max.Value;
            test.RecipeSettings.EmkTestRecipe.PeakToPeaxMin = PeaktoPeakV_Min.Value;
            test.RecipeSettings.EmkTestRecipe.RmsMax = RmsV_Max.Value;
            test.RecipeSettings.EmkTestRecipe.RmsMin = RmsV_Min.Value;
            test.RecipeSettings.EmkTestRecipe.IsTestActive = EmkTestActive.Checked;
        }
    }
}

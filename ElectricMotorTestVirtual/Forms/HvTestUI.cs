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
    public partial class HvTestUI : UserControl
    {
        public HvTestUI()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        public void LoadTestToUIHV(TestSettings test)
        {
            HvTestVoltageKv.Value = test.RecipeSettings.HVTestRecipe.HvTesVoltage;
            LeakagemA_Max.Value = test.RecipeSettings.HVTestRecipe.LeakageCurrentMax;
            LeakagemA_Min.Value = test.RecipeSettings.HVTestRecipe.LeakageCurrentMin;
            IRResistanceOhm_Max.Value = test.RecipeSettings.HVTestRecipe.IRResistanceMax;
            IRResistanceOhm_Min.Value = test.RecipeSettings.HVTestRecipe.IRResistanceMin;
            HVTestActive.Checked = test.RecipeSettings.HVTestRecipe.IsTestActive;
          
        }

        public void LoadUItoTestHV(TestSettings test)
        {
            test.RecipeSettings.HVTestRecipe.HvTesVoltage = HvTestVoltageKv.Value;
            test.RecipeSettings.HVTestRecipe.LeakageCurrentMax = LeakagemA_Max.Value;
            test.RecipeSettings.HVTestRecipe.LeakageCurrentMin = LeakagemA_Min.Value;
            test.RecipeSettings.HVTestRecipe.IRResistanceMax = IRResistanceOhm_Max.Value;
            test.RecipeSettings.HVTestRecipe.IRResistanceMin = IRResistanceOhm_Min.Value;
            test.RecipeSettings.HVTestRecipe.IsTestActive = HVTestActive.Checked;
        }
    }
}

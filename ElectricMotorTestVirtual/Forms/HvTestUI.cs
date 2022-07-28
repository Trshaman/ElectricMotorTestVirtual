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

        public void LoadTestToUIHV(HVTest test)
        {
            HvTestVoltageKv.Text = test.HvTesVoltage.ToString();
            LeakagemA_Max.Text = test.LeakageCurrentMax.ToString();
            LeakagemA_Min.Text = test.LeakageCurrentMin.ToString();
            IRResistanceOhm_Max.Text = test.IRResistanceMax.ToString();
            IRResistanceOhm_Min.Text = test.IRResistanceMin.ToString();
            HVTestActive.Checked = test.IsTestActive;
          
        }

        public void LoadUItoTestHV(HVTest test)
        {
            test.HvTesVoltage = Convert.ToDouble(HvTestVoltageKv.Text);

            test.LeakageCurrentMax = Convert.ToDouble(LeakagemA_Max.Text);
            test.LeakageCurrentMin = Convert.ToDouble(LeakagemA_Min.Text);
            test.IRResistanceMax = Convert.ToDouble(IRResistanceOhm_Max.Text);
            test.IRResistanceMin = Convert.ToDouble(IRResistanceOhm_Min.Text);
            test.IsTestActive = HVTestActive.Checked;
        }
    }
}

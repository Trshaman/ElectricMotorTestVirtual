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

        public void LoadTestToUILCR(LCRTest test)
        {
            R1Ohm_Max.Text = test.R1Max.ToString();
            R1Ohm_Min.Text = test.R1Min.ToString();
            R2Ohm_Max.Text = test.R2Max.ToString();
            R2Ohm_Min.Text = test.R2Min.ToString();
            R3Ohm_Max.Text = test.R3Max.ToString();
            R3Ohm_Min.Text = test.R3Min.ToString();
            L1Inductance_Max.Text = test.L1Max.ToString();
            L1Inductance_Min.Text = test.L1Min.ToString();
            L2Inductance_Max.Text = test.L2Max.ToString();
            L2Inductance_Min.Text = test.L2Min.ToString();
            L3Inductance_Max.Text = test.L3Max.ToString();
            L3Inductance_Min.Text = test.L3Min.ToString();
            LCRTestActive.Checked = test.IsTestActive;
        }

        public void LoadUIToTestLCR(LCRTest test)
        {
            test.R1Max = Convert.ToDouble(R1Ohm_Max.Text);
            test.R1Min = Convert.ToDouble(R1Ohm_Min.Text);
            test.R2Max = Convert.ToDouble(R2Ohm_Max.Text);
            test.R2Min = Convert.ToDouble(R2Ohm_Min.Text);
            test.R3Max = Convert.ToDouble(R3Ohm_Max.Text);
            test.R3Min = Convert.ToDouble(R3Ohm_Min.Text);
            test.L1Max = Convert.ToDouble(L1Inductance_Max.Text);
            test.L1Min = Convert.ToDouble(L1Inductance_Min.Text);
            test.L2Max = Convert.ToDouble(L2Inductance_Max.Text);
            test.L2Min = Convert.ToDouble(L2Inductance_Min.Text);
            test.L3Max = Convert.ToDouble(L3Inductance_Max.Text);
            test.L3Min = Convert.ToDouble(L3Inductance_Min.Text);
            test.IsTestActive = LCRTestActive.Checked;
        }
    }
}

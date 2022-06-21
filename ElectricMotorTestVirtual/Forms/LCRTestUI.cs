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
            R1Ohm_Max.Value = test.R1Max;
            R1Ohm_Min.Value = test.R1Min;
            R2Ohm_Max.Value = test.R2Max;
            R2Ohm_Min.Value = test.R2Min;
            R3Ohm_Max.Value = test.R3Max;
            R3Ohm_Min.Value = test.R3Min;
            L1Inductance_Max.Value = test.L1Max;
            L1Inductance_Min.Value = test.L1Min;
            L2Inductance_Max.Value = test.L2Max;
            L2Inductance_Min.Value = test.L2Min;
            L3Inductance_Max.Value = test.L3Max;
            L3Inductance_Min.Value = test.L3Min;
            LCRTestActive.Checked = test.IsTestActive;
        }

        public void LoadUIToTestLCR(LCRTest test)
        {
            test.R1Max = R1Ohm_Max.Value;
            test.R1Min = R1Ohm_Min.Value;
            test.R2Max = R2Ohm_Max.Value;
            test.R2Min = R2Ohm_Min.Value;
            test.R3Max = R3Ohm_Max.Value;
            test.R3Min = R3Ohm_Min.Value;
            test.L1Max = L1Inductance_Max.Value;
            test.L1Min = L1Inductance_Min.Value;
            test.L2Max = L2Inductance_Max.Value;
            test.L2Min = L2Inductance_Min.Value;
            test.L3Max = L3Inductance_Max.Value;
            test.L3Min = L3Inductance_Min.Value;
            test.IsTestActive = LCRTestActive.Checked;
        }
    }
}

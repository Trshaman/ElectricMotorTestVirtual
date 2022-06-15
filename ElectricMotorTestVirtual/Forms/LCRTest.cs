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
    public partial class LCRTest : UserControl
    {
        public LCRTest()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        public void LoadStepToUILCR(LCRTest test)
        {
            R1Ohm_Max = test.R1Ohm_Max;
            R1Ohm_Min = test.R1Ohm_Max;
            R2Ohm_Max = test.R2Ohm_Max;
            R2Ohm_Max = test.R2Ohm_Max;
            R3Ohm_Max = test.R3Ohm_Max;
            R3Ohm_Min = test.R3Ohm_Max;
            L1Inductance_Max = test.L1Inductance_Max;
            L1Inductance_Min = test.L1Inductance_Min;
            L2Inductance_Max = test.L2Inductance_Max;
            L2Inductance_Min = test.L2Inductance_Min;
            L3Inductance_Max = test.L3Inductance_Max;
            L3Inductance_Min = test.L3Inductance_Min;
        }

        public void LoadUIToStepLCR(LCRTest test)
        {
            test.R1Ohm_Max = R1Ohm_Max;
            test.R1Ohm_Max = R1Ohm_Min;
            test.R2Ohm_Max = R2Ohm_Max;
            test.R2Ohm_Max = R2Ohm_Max;
            test.R3Ohm_Max = R3Ohm_Max;
            test.R3Ohm_Max = R3Ohm_Min;
            test.L1Inductance_Max = L1Inductance_Max;
            test.L1Inductance_Min = L1Inductance_Min;
            test.L2Inductance_Max = L2Inductance_Max;
            test.L2Inductance_Min = L2Inductance_Min;
            test.L3Inductance_Max = L3Inductance_Max;
            test.L3Inductance_Min = L3Inductance_Min;
        }
    }
}

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

        public void LoadTestToUIEmk(EMKTest test)
        {
            PeaktoPeakV_Max.Text = test.PeakToPeakMax.ToString();
            PeaktoPeakV_Min.Text = test.PeakToPeakMin.ToString();
            RmsV_Max.Text = test.RmsMax.ToString();
            RmsV_Min.Text = test.RmsMin.ToString();
            EmkTestActive.Checked = test.IsTestActive;
        }

        public void LoadUItoTestEmk(EMKTest test)
        {
            test.PeakToPeakMax = Convert.ToDouble(PeaktoPeakV_Max.Text);
            test.PeakToPeakMin = Convert.ToDouble(PeaktoPeakV_Min.Text);
            test.RmsMax = Convert.ToDouble(RmsV_Max.Text);
            test.RmsMin = Convert.ToDouble(RmsV_Min.Text);
            test.IsTestActive = EmkTestActive.Checked;
        }
    }
}

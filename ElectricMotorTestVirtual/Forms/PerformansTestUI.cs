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

        public void LoadTestToUIPerformance(PerformanceTest test)
        { 
            UnloadPerformRpm_Max.Text = test.UnloadPerformanceRpmMax.ToString();
            UnloadPerformRpm_Min.Text = test.UnloadPerformanceRpmMin.ToString();
            LoadPerformRpm_Max.Text = test.LoadPerformanceRpmMax.ToString();
            LoadPerformRpm_Min.Text = test.LoadPerformanceRpmMin.ToString();
            LoadTorqueNm_Point1.Text = test.LoadTorque1Nm.ToString();
            LoadTorqueNm_Point2.Text = test.LoadTorque2Nm.ToString();
            PerformTestActive.Checked = test.IsTestActive;

        }

        public void LoadUItoTestPerformance(PerformanceTest test)
        {
            test.UnloadPerformanceRpmMax = Convert.ToInt32(UnloadPerformRpm_Max.Text);
            test.UnloadPerformanceRpmMax = Convert.ToInt32(UnloadPerformRpm_Min.Text);
            test.LoadPerformanceRpmMax = Convert.ToInt32(LoadPerformRpm_Max.Text);
            test.LoadPerformanceRpmMin = Convert.ToInt32(LoadPerformRpm_Min.Text);
            test.LoadTorque1Nm = Convert.ToDouble(LoadTorqueNm_Point1.Text);
            test.LoadTorque2Nm = Convert.ToDouble(LoadTorqueNm_Point2.Text);
            test.IsTestActive = PerformTestActive.Checked; 
        }
    }
}

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
    public partial class PerformansTest : UserControl
    {
        public PerformansTest()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public void LoadStepToUIPerformance(PerformanceTest test)
        {
            UnloadPerformRpm_Max.Value = test.UnloadPerformanceRpmMax;
            UnloadPerformRpm_Min.Value = test.UnloadPerformanceRpmMin;
            LoadPerformRpm_Max.Value = test.LoadPerformanceRpmMax;
            LoadPerformRpm_Min.Value = test.LoadPerformanceRpmMin;
            LoadTorqueNm_Point1.Value = test.LoadTorque1Nm;
            LoadTorqueNm_Point2.Value = test.LoadTorque2Nm;



        }

        public void LoadUItoStepPerformance(PerformanceTest test)
        {
            test.UnloadPerformanceRpmMax = UnloadPerformRpm_Max.Value;
            test.UnloadPerformanceRpmMax = UnloadPerformRpm_Min.Value;
            test.LoadPerformanceRpmMax = LoadPerformRpm_Max.Value;
            test.LoadPerformanceRpmMin = LoadPerformRpm_Min.Value;
            test.LoadTorque1Nm = LoadTorqueNm_Point1.Value;
            test.LoadTorque2Nm = LoadTorqueNm_Point2.Value;
        }
    }
}

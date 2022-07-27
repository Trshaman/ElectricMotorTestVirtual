﻿using ElectricMotorTestVirtual.OOP_Approach.TestCases;
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
            PeaktoPeakV_Max.Value = test.PeakToPeakMax;
            PeaktoPeakV_Min.Value = test.PeakToPeakMin;
            RmsV_Max.Value = test.RmsMax;
            RmsV_Min.Value = test.RmsMin;
            EmkTestActive.Checked = test.IsTestActive;
        }

        public void LoadUItoTestEmk(EMKTest test)
        {
            test.PeakToPeakMax = PeaktoPeakV_Max.Value;
            test.PeakToPeakMin = PeaktoPeakV_Min.Value;
            test.RmsMax = RmsV_Max.Value;
            test.RmsMin = RmsV_Min.Value;
            test.IsTestActive = EmkTestActive.Checked;
        }
    }
}

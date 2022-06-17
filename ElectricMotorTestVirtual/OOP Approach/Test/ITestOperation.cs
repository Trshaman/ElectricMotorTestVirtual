﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectricMotorTestVirtual.OOP_Approach.Test
{
    public interface ITestOperation
    {
        void DataAcquisition();

        void PrepareRelayMatrix();

        TestStates ExecuteTest(DataGridView dataGridView);

        double ApplyCoefficent(double value);

        bool PrapereResult(DataGridView dataGridView);

        void LogSQL();



    }
}

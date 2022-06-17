using ElectricMotorTestVirtual.OOP_Approach.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricMotorTestVirtual.OOP_Approach.TestCases
{
    public class LCRTest : TestCase
    {
        public double R1Max { get; set; }
        public double R1Min { get; set; }
        public double R2Max { get; set; }
        public double R2Min { get; set; }
        public double R3Max { get; set; }
        public double R3Min { get; set; }
        public double L1Max { get; set; }
        public double L1Min { get; set; }
        public double L2Max { get; set; }
        public double L2Min { get; set; }
        public double L3Max { get; set; }
        public double L3Min { get; set; }

        public override void ApplyCoefficent()
        {
            throw new NotImplementedException();
        }

        public override void DataAcquisition()
        {
            throw new NotImplementedException();
        }

        public override void ExecuteTest()
        {
            DateTime StartTestTime = DateTime.Now;
            base.TestStarted = true;
            PrepareRelayMatrix();
            DataAcquisition();
            ApplyCoefficent();
            PrapereResult();
            LogSQL();
            base.TestDuration = StartTestTime - DateTime.Now;
            base.TestStarted = false;
        }

        public override void LogSQL()
        {
            throw new NotImplementedException();
        }

        public override void PrapereResult()
        {
            throw new NotImplementedException();
        }

        public override void PrepareRelayMatrix()
        {
            throw new NotImplementedException();
        }
    }
}

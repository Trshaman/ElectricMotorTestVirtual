using ElectricMotorTestVirtual.OOP_Approach.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricMotorTestVirtual.OOP_Approach.TestCases
{
    public class HVTest : TestCase
    {

        public double HvTesVoltage { get; set; }
        public double LeakageCurrentMax { get; set; }
        public double LeakageCurrentMin { get; set; }
        public double IRResistanceMax { get; set; }
        public double IRResistanceMin { get; set; }

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectricMotorTestVirtual.OOP_Approach.Motor;
using ElectricMotorTestVirtual.OOP_Approach.Test;

namespace ElectricMotorTestVirtual.OOP_Approach.TestCases
{
    public class EMKTest : TestCase
    {
        public double PeakToPeaxMax { get; set; }
        public double PeakToPeaxMin { get; set; }
        public double RmsMax { get; set; }
        public double RmsMin { get; set; }

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
            if (base.IsTestActive == true)
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
            else
            {
                //do nothing 
            }
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

using ElectricMotorTestVirtual.OOP_Approach.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricMotorTestVirtual.OOP_Approach.TestCases
{
    public class PerformanceTest : TestCase
    {
        public int UnloadPerformanceRpmMax { get; set; }
        public int UnloadPerformanceRpmMin { get; set; }
        public int LoadPerformanceRpmMax { get; set; }
        public int LoadPerformanceRpmMin { get; set; }
        public double LoadTorque1Nm { get; set; }
        public double LoadTorque2Nm { get; set; }

        public override void ApplyCoefficent()
        {
            throw new NotImplementedException();
        }

        public override void ExecuteTest()
        {
            throw new NotImplementedException();
        }

        public override void LogSQL()
        {
            throw new NotImplementedException();
        }

        public override void PrapereResult()
        {
            throw new NotImplementedException();
        }
    }
}

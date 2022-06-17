using ElectricMotorTestVirtual.OOP_Approach.Motor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricMotorTestVirtual.OOP_Approach.Test
{
    public abstract class TestCase : ITestOperation
    {
        public string TestName;

        public string TestDescription;

        public Coefficent TestCoefficent;

        public bool TestStarted;

        public TimeSpan TestDuration;

        public bool IsTestActive { get; set; }

        public abstract void ApplyCoefficent();

        public abstract void DataAcquisition();

        public abstract void ExecuteTest();

        public abstract void LogSQL();

        public abstract void PrapereResult();

        public abstract void PrepareRelayMatrix();

    }
}

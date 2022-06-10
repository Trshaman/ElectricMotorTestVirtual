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
        public string testName;

        public string testDescription;

        public Coefficent testCoefficent;

        public bool TestStarted;

        public TimeSpan TestDuration;

        public abstract void Daq();


        public abstract void LogSQL();


        public abstract void PrapereResult();
      
    }
}

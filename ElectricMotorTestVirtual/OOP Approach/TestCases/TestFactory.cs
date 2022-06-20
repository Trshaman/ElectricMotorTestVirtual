using ElectricMotorTestVirtual.OOP_Approach.Motor;
using ElectricMotorTestVirtual.OOP_Approach.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricMotorTestVirtual.OOP_Approach.TestCases
{
    public static class TestFactory
    {
        public static TestCase CreateEMKTest()
        {
            return new EMKTest();
        }
        public static ITestOperation CreateHVTest()
        {
            return new HVTest();
        }

        public static ITestOperation CreateLCRTest()
        {
            return new LCRTest();
        }
        public static ITestOperation CreatePerformanceTest()
        {
            return new PerformanceTest();
        }
        public static IMotorModel CreateMotorModel()
        {
            return new MotorModel();
        }


    }
}

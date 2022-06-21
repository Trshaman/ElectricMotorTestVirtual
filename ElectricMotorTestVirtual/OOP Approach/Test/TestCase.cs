using ElectricMotorTestVirtual.OOP_Approach.Motor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectricMotorTestVirtual.OOP_Approach.Test
{
    public abstract class TestCase : ITestOperation
    {
        public string TestName;

        public string TestDescription;

        public Coefficent TestCoefficent;

        public bool TestStarted;

        public bool TestResult;

        public TimeSpan TestDuration;

        public TestCase()
        {
             TestCoefficent = new Coefficent(); 
        }

        public bool IsTestActive { get; set; }

        public abstract double ApplyCoefficent(double value);

        public abstract void DataAcquisition();

        public abstract bool ExecuteTest(DataGridView dataGridView);

        public abstract void LogSQL();

        public abstract bool PrapereResult(DataGridView dataGridView);

        public abstract void PrepareRelayMatrix();

    }
}

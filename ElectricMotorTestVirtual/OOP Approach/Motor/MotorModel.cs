using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricMotorTestVirtual.OOP_Approach.Motor
{
    public class MotorModel
    {
        private int motorId;

        private int motorSpeed;

        private string motorName;

        private TestCoefficents testCoefficents;

        public int MotorId { get => motorId; set => motorId = value; }
        public int MotorSpeed { get => motorSpeed; set => motorSpeed = value; }
        public string MotorName { get => motorName; set => motorName = value; }
        public TestCoefficents TestCoefficents { get => testCoefficents; set => testCoefficents = value; }
    }
}

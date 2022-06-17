using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricMotorTestVirtual.OOP_Approach.Motor
{
    public class Coefficent
    {
        public double Gain { get; set; } = 1;

        public double Offset { get; set; } = 0;

        public double ApplyCoefficentValues(double value)
        {
           return  ((value * Gain) + Offset);
        }
    }
}

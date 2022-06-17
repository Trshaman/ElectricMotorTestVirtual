using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricMotorTestVirtual.OOP_Approach.Test
{
    public interface ITestOperation
    {
        void DataAcquisition();

        void PrepareRelayMatrix();

        void ExecuteTest();

        void ApplyCoefficent();

        void PrapereResult();

        void LogSQL();



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectricMotorTestVirtual.OOP_Approach.Test
{
    public interface ITestOperation
    {
        void DataAcquisition();

        void PrepareRelayMatrix();

        bool ExecuteTest(DataGridView dataGridView, int indx);

        double ApplyCoefficent(double value);

        bool PrapereResult(DataGridView dataGridView);

        void LogSQL(int index);



    }
}

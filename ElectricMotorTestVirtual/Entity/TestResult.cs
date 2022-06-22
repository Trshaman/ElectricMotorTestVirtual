using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricMotorTestVirtual.Entity
{
    public class TestResult
    {
        public int Id { get; set; }

        public string SerialNumber { get; set; }

        public DateTime Date { get; set; }  

        public bool HVTestActive { get; set; }

        public bool LCRTestActive { get; set; }

        public bool EMKTestActive { get; set; }

        public bool PerformanceTestActive { get; set; }

        public bool IsACSBtnpressed { get; set; }

        public bool Result { get; set; }
    }
}

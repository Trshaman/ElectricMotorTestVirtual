using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ElectricMotorTestVirtual.OOP_Approach.TestCases;

namespace ElectricMotorTestVirtual.Entity
{
    public class Context : DbContext
    {
        public DbSet<TestResult> TestResults { get; set; }

        public DbSet <EMKTest> EMKTestResults { get; set; }

        public DbSet <HVTest> HVTestResults { get; set; }

        public DbSet <LCRTest> LCRTestResults { get; set; }

        public DbSet <PerformanceTest> PerformanceTestResults { get; set; }
    }
}

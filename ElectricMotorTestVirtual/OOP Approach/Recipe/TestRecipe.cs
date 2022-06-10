﻿using ElectricMotorTestVirtual.OOP_Approach.Motor;
using ElectricMotorTestVirtual.OOP_Approach.TestCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricMotorTestVirtual.OOP_Approach.Recipe
{
    public class TestRecipe
    {
        public EMKTest EmkTestRecipe { get; set; }

        public HVTest HVTestRecipe { get; set; }

        public LCRTest LCRTestRecipe { get; set; }

        public PerformanceTest PerformanceTestRecipe { get; set; }

        public LoadPerformanceTest LoadPerformanceTestRecipe { get; set; }

        public MotorModel MotorModelRecipe { get; set; }


    }
}

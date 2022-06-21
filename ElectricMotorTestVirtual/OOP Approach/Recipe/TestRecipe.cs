using ElectricMotorTestVirtual.OOP_Approach.Motor;
using ElectricMotorTestVirtual.OOP_Approach.Test;
using ElectricMotorTestVirtual.OOP_Approach.TestCases;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public MotorModel MotorModelRecipe { get; set; }

        public TestRecipe()
        {
            this.EmkTestRecipe = new EMKTest();
            this.HVTestRecipe = new HVTest();
            this.LCRTestRecipe = new LCRTest();
            this.PerformanceTestRecipe = new PerformanceTest();
            this.MotorModelRecipe = new MotorModel();
        }
       
        public List<object> GetTestList()
        {
            List<object> tests = new List<object>();
            PropertyInfo[] Properties = this.GetType().GetProperties();
            foreach (PropertyInfo property in Properties)
            {
                var obj = this.GetType().GetProperty(property.Name).GetValue(this, null);
      
                if (obj.GetType().BaseType == typeof(TestCase))
                {
                    tests.Add(obj);
                }
                
            }
          
            return tests;

        }
    }
}

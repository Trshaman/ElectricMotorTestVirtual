﻿using ElectricMotorTestVirtual.Entity;
using ElectricMotorTestVirtual.OOP_Approach.Test;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ElectricMotorTestVirtual.OOP_Approach.TestCases
{
    public class PerformanceTest : TestCase
    {
        
        
        private IGenericRepository<PerformanceTest> repository = new GenericRepository<PerformanceTest>();

        public int Id { get; set; }
        public int? TestResultId { get; set; }
        [ForeignKey("TestResultId")]
        public TestResult TestResult { get; set; }
        public double UnloadPerformanceRpmMax { get; set; }
        
        public double UnloadPerformanceRpmMin { get; set; }
        public double LoadPerformanceRpmMax { get; set; }
        
        public double LoadPerformanceRpmMin { get; set; }
        public double LoadTorque1Nm { get; set; }
        public double LoadTorque2Nm { get; set; }

        [XmlIgnore] [TestComparable]
        public double UnloadPerformanceRpm { get; set; }
        [XmlIgnore] [TestComparable]
        public double LoadPerformanceRpm { get; set; }

        public override double ApplyCoefficent(double value)
        {
            return 0;
        }
        public override void DataAcquisition()
        {
            Random rnd = new Random();
            PropertyInfo[] Properties = this.GetType().GetProperties();

            foreach (PropertyInfo property in Properties)
            {
                if (Attribute.IsDefined(property, typeof(TestComparable)))
                {
                    string propName = property.Name;
                    double value = (double)rnd.Next(1, 100);
                    this.GetType().GetProperty(propName).SetValue(this, value, null);
                }
            }
        }

        public override bool ExecuteTest(DataGridView dataGridView, int indx)
        {
            if (base.IsTestActive == true)
            {
                DateTime startTestTime = DateTime.Now;
                base.TestStarted = true;
                PrepareRelayMatrix();
                DataAcquisition();
                base.TestResultValue = PrapereResult(dataGridView);
                base.TestDuration = startTestTime - DateTime.Now;
                base.TestStarted = false;
                string testResult = base.TestResultValue == true ? "Test OK" : "Test NOK";
                base.TestStarted = false;
                LogSQL(indx);
                return base.TestResultValue;
            }
            else
            {
                return true;
            }

        }

        public override void LogSQL(int index)
        {
            this.TestResultId = index;
            repository.Insert(this);
            repository.Save();
        }



        public override bool PrapereResult(DataGridView dataGridView)
        {
            PrepareTable Table = new PrepareTable();
            return Table.PreapareTableForTestResult(this, dataGridView);
        }

        public override void PrepareRelayMatrix()
        {

        }


    }
}

using ElectricMotorTestVirtual.OOP_Approach.Test;
using GlobalFunctions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ElectricMotorTestVirtual.OOP_Approach.TestCases
{
    public class HVTest : TestCase
    {

        public double HvTesVoltage { get; set; }
        public double LeakageCurrentMax { get; set; }
        public double LeakageCurrentMin { get; set; }
        public double IRResistanceMax { get; set; }
        public double IRResistanceMin { get; set; }

        [XmlIgnore][TestComparable]
        private double LeakageCurrent { get; set; }
        [XmlIgnore][TestComparable]
        private double IRResistance { get; set; }
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
                    property.SetValue(property, rnd.Next(1, 100));
                }
            }
        }

        public override TestStates ExecuteTest(DataGridView dataGridView)
        {
            if (base.IsTestActive == true)
            {
                DateTime startTestTime = DateTime.Now;
                Program.LogForm.WriteLog(LogTypes.System, 0, -1, -1, this.GetType().Name + "başlatıldı", SystemIcons.Information);
                base.TestStarted = true;
                PrepareRelayMatrix();
                DataAcquisition();
                base.TestResult = PrapereResult(dataGridView);
                LogSQL();
                base.TestDuration = startTestTime - DateTime.Now;
                base.TestStarted = false;
                return TestResult == true ? TestStates.TestResultOK : TestStates.TestResultNOK;
            }
            else
            {
                return TestStates.TestEmpty;
            }

        }

        public override void LogSQL()
        {

        }

   

        public override bool PrapereResult(DataGridView dataGridView)
        {
            PropertyInfo[] Properties = this.GetType().GetProperties();
            bool testResult = false;
            int lastRowIndex = dataGridView.Rows.Count - 1;
            foreach (PropertyInfo property in Properties)
            {
                if (Attribute.IsDefined(property, typeof(TestComparable)))
                {

                    double max = (double)this.GetType().GetProperty(property.Name + "Max").GetValue(this, null);
                    double min = (double)this.GetType().GetProperty(property.Name + "Min").GetValue(this, null);
                    double PropertyValue = (double)property.GetValue(property);
                    if ((double)property.GetValue(property) >= min && (double)property.GetValue(property) <= max)
                    {
                        testResult = true;
                    }
                    else
                    {
                        testResult = false;
                    }
                    dataGridView.Rows.Add();
                    dataGridView.Rows[lastRowIndex].Cells[Program.TestTableName].Value = property.Name;
                    dataGridView.Rows[lastRowIndex].Cells[Program.TestUnit].Value = "";
                    dataGridView.Rows[lastRowIndex].Cells[Program.TestMaxLimit].Value = max;
                    dataGridView.Rows[lastRowIndex].Cells[Program.TestMinLimit].Value = min;
                    dataGridView.Rows[lastRowIndex].Cells[Program.TestResult].Value = testResult ? "OK" : "RED";
                }
            }
            return testResult;
        }

        public override void PrepareRelayMatrix()
        {

        }
    }
}

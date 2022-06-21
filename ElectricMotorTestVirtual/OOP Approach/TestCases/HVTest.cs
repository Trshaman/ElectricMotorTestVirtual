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
        public double LeakageCurrent { get; set; }
        [XmlIgnore][TestComparable]
        public double IRResistance { get; set; }
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
                    // property.SetValue(property, rnd.Next(1, 100));
                    this.GetType().GetProperty(propName).SetValue(this, value, null);
                }
            }
        }

        public override bool ExecuteTest(DataGridView dataGridView)
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
                string testResult = base.TestResult == true ? "Test OK" : "Test NOK";
                Program.LogForm.WriteLog(LogTypes.System, 0, -1, -1, this.GetType().Name + testResult, SystemIcons.Information);
                base.TestStarted = false;
                return TestResult == true ? true : false;
            }
            else
            {
                return true;
            }

        }

        public override void LogSQL()
        {

        }



        public override bool PrapereResult(DataGridView dataGridView)
        {
            PropertyInfo[] Properties = this.GetType().GetProperties();
            bool testResult = true;
            int lastRowIndex = 0;

            foreach (PropertyInfo property in Properties)
            {
                if (Attribute.IsDefined(property, typeof(TestComparable)))
                {
                    if (dataGridView.Rows.Count - 1 == -1)
                    {
                        lastRowIndex = 0;
                    }
                    else
                    {
                        lastRowIndex = dataGridView.Rows.Count;
                    }
                    double max = (double)this.GetType().GetProperty(property.Name + "Max").GetValue(this, null);
                    double min = (double)this.GetType().GetProperty(property.Name + "Min").GetValue(this, null);
                    string propName = property.Name;


                    double testValue = (double)this.GetType().GetProperty(propName).GetValue(this, null);

                    bool testResultTable = false;
                    if (testValue >= min && testValue <= max)
                    {
                        testResultTable = true;
                    }
                    else
                    {
                        testResult = false;
                    }
                    dataGridView.Rows.Add();
                    dataGridView.Rows[lastRowIndex].Cells[Program.TestParameter].Value = property.Name;
                    dataGridView.Rows[lastRowIndex].Cells[Program.TestUnit].Value = "";
                    dataGridView.Rows[lastRowIndex].Cells[Program.TestMaxLimit].Value = max;
                    dataGridView.Rows[lastRowIndex].Cells[Program.TestMeasuredValue].Value = testValue;
                    dataGridView.Rows[lastRowIndex].Cells[Program.TestMinLimit].Value = min;
                    dataGridView.Rows[lastRowIndex].Cells[Program.TestResult].Value = testResultTable ? "OK" : "RED";
                    Color testResultColor = testResultTable == true ? Color.Yellow : Color.Red;
                    dataGridView.Rows[lastRowIndex].DefaultCellStyle.BackColor = testResultColor;
                }
            }
            return testResult;
        }

        public override void PrepareRelayMatrix()
        {

        }
    }
}

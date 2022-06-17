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
    public class LCRTest : TestCase
    {
        public double R1Max { get; set; }
        public double R1Min { get; set; }
        public double R2Max { get; set; }
        public double R2Min { get; set; }
        public double R3Max { get; set; }
        public double R3Min { get; set; }
        public double L1Max { get; set; }
        public double L1Min { get; set; }
        public double L2Max { get; set; }
        public double L2Min { get; set; }
        public double L3Max { get; set; }
        public double L3Min { get; set; }

        [XmlIgnore][TestComparable]
        private int R1 { get; set; }
        [XmlIgnore][TestComparable]
        private int R2 { get; set; }
        [XmlIgnore][TestComparable]
        private int R3 { get; set; }
        [XmlIgnore][TestComparable]
        private int L1 { get; set; }
        [XmlIgnore][TestComparable]
        private int L2 { get; set; }
        [XmlIgnore][TestComparable]
        private int L3 { get; set; }
        

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
            return true;
        }

        public override void PrepareRelayMatrix()
        {

        }
    }
}

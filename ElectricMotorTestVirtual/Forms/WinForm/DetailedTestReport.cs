using ElectricMotorTestVirtual.OOP_Approach.TestCases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectricMotorTestVirtual.Forms.WinForm
{
    public partial class DetailedTestReport : Form
    {
        private int _lastrowindex= 0;
        public DetailedTestReport()
        {
            InitializeComponent();
        }

        private int GetLastRowIndex()
        {
            if (TestResultTable.Rows.Count - 1 == -1)
            {
                return _lastrowindex = 0;
            }
            else
            {
               return _lastrowindex = TestResultTable.Rows.Count;
            }
        }

        public void EmkResultFillTable(List<EMKTest> EmkTestResult)
        {
            foreach (EMKTest test in EmkTestResult)
            {
            GetLastRowIndex();
            TestResultTable.Rows.Add();
            TestResultTable.Rows[_lastrowindex].Cells[Program.TestParameter].Value = EmkTestResult.ToString();
            TestResultTable.Rows[_lastrowindex].Cells[Program.TestUnit].Value = "";
            TestResultTable.Rows[_lastrowindex].Cells[Program.TestMaxLimit].Value = test.RmsMax;
            TestResultTable.Rows[_lastrowindex].Cells[Program.TestMeasuredValue].Value = test.Rms;
            TestResultTable.Rows[_lastrowindex].Cells[Program.TestMinLimit].Value = test.RmsMin;
            TestResultTable.Rows[_lastrowindex].Cells[Program.TestResult].Value = test.TestResultValue ? "OK" : "RED";
            Color testResultColor = test.TestResultValue == true ? Color.Yellow : Color.Red;
            TestResultTable.Rows[_lastrowindex].DefaultCellStyle.BackColor = testResultColor;
            }
  

        }

        public void HVResultFillTable(EMKTest EmkTestResult)
        {
            GetLastRowIndex();
        }

        public void LCRResultFillTable(EMKTest EmkTestResult)
        {
            GetLastRowIndex();
        }

        public void PerformansResultFillTable(EMKTest EmkTestResult)
        {
            GetLastRowIndex();

        }

    }
}

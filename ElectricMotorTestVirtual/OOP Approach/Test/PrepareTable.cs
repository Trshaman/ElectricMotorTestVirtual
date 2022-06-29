using ElectricMotorTestVirtual.OOP_Approach.TestCases;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectricMotorTestVirtual.OOP_Approach.Test
{
    public class PrepareTable
    {
        public bool PreapareTableForTestResult(TestCase TestCase,DataGridView TestResultTable)
        {
            PropertyInfo[] Properties = TestCase.GetType().GetProperties();
            bool testResult = true;
            int lastRowIndex = 0;

            foreach (PropertyInfo property in Properties)
            {
                if (Attribute.IsDefined(property, typeof(TestComparable)))
                {
                    if (TestResultTable.Rows.Count - 1 == -1)
                    {
                        lastRowIndex = 0;
                    }
                    else
                    {
                        lastRowIndex = TestResultTable.Rows.Count;
                    }
                    double max = (double)TestCase.GetType().GetProperty(property.Name + "Max").GetValue(TestCase, null);
                    double min = (double)TestCase.GetType().GetProperty(property.Name + "Min").GetValue(TestCase, null);
                    string propName = property.Name;


                    double testValue = (double)TestCase.GetType().GetProperty(propName).GetValue(TestCase, null);

                    bool testResultTable = false;
                    if (testValue >= min && testValue <= max)
                    {
                        testResultTable = true;
                    }
                    else
                    {
                        testResult = false;
                    }
                    TestResultTable.Rows.Add();
                    TestResultTable.Rows[lastRowIndex].Cells[Program.TestParameter].Value = property.Name;
                    TestResultTable.Rows[lastRowIndex].Cells[Program.TestUnit].Value = "";
                    TestResultTable.Rows[lastRowIndex].Cells[Program.TestMaxLimit].Value = max;
                    TestResultTable.Rows[lastRowIndex].Cells[Program.TestMeasuredValue].Value = testValue;
                    TestResultTable.Rows[lastRowIndex].Cells[Program.TestMinLimit].Value = min;
                    TestResultTable.Rows[lastRowIndex].Cells[Program.TestResult].Value = testResultTable ? "OK" : "RED";
                    Color testResultColor = testResultTable == true ? Color.Yellow : Color.Red;
                    TestResultTable.Rows[lastRowIndex].DefaultCellStyle.BackColor = testResultColor;
                }
            }
            return testResult;
        }

        public void PreapareTableForDetailedReport(TestCase TestCase, DataGridView TestResultTable)
        {
         
                PropertyInfo[] Properties = TestCase.GetType().GetProperties();
                int lastRowIndex = 0;

                foreach (PropertyInfo property in Properties)
                {
                    if (Attribute.IsDefined(property, typeof(TestComparable)))
                    {
                        if (TestResultTable.Rows.Count - 1 == -1)
                        {
                            lastRowIndex = 0;
                        }
                        else
                        {
                            lastRowIndex = TestResultTable.Rows.Count;
                        }


                        double max = (double)TestCase.GetType().GetProperty(property.Name + "Max").GetValue(TestCase, null);
                        double min = (double)TestCase.GetType().GetProperty(property.Name + "Min").GetValue(TestCase, null);
                        string propName = property.Name;
                        double testValue = (double)TestCase.GetType().GetProperty(propName).GetValue(TestCase, null);


                        TestResultTable.Rows.Add();
                        TestResultTable.Rows[lastRowIndex].Cells[Program.TestParameter].Value = property.Name;
                        TestResultTable.Rows[lastRowIndex].Cells[Program.TestUnit].Value = "";
                        TestResultTable.Rows[lastRowIndex].Cells[Program.TestMaxLimit].Value = max;
                        TestResultTable.Rows[lastRowIndex].Cells[Program.TestMeasuredValue].Value = testValue;
                        TestResultTable.Rows[lastRowIndex].Cells[Program.TestMinLimit].Value = min;
                        TestResultTable.Rows[lastRowIndex].Cells[Program.TestResult].Value = TestCase.TestResultValue ? "OK" : "RED";
                        Color testResultColor = TestCase.TestResultValue == true ? Color.Yellow : Color.Red;
                        TestResultTable.Rows[lastRowIndex].DefaultCellStyle.BackColor = testResultColor;
                    }
                }
            

        }

    }
}

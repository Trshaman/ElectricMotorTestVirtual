using ElectricMotorTestVirtual.OOP_Approach.TestCases;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace ElectricMotorTestVirtual.OOP_Approach.Test
{
    public class PrepareTable
    {
        Microsoft.Office.Interop.Excel.Application XcelApp = new Microsoft.Office.Interop.Excel.Application();
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
        public void ExportPdf(DataGridView dataGridView1,string TestDate,string SerialNumber)
        {
            XcelApp.Application.Workbooks.Add(Type.Missing);

            for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            {
                XcelApp.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    XcelApp.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                }
            }
            XcelApp.Columns.AutoFit();
            XcelApp.Visible = true;
        }

    }
}

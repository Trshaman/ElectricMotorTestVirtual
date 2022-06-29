using ElectricMotorTestVirtual.Entity;
using ElectricMotorTestVirtual.OOP_Approach.Test;
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
    public partial class TestResultDatabase : Form
    {
        private IGenericRepository<TestResult> repositoryMain = new GenericRepository<TestResult>();
        private IGenericRepository<EMKTest> repositoryEMK = new GenericRepository<EMKTest>();
        private IGenericRepository<HVTest> repositoryHV = new GenericRepository<HVTest>();
        private IGenericRepository<LCRTest> repositoryLCR = new GenericRepository<LCRTest>();
        private IGenericRepository<PerformanceTest> repositoryPerform = new GenericRepository<PerformanceTest>();
        private DetailedTestReport _detailedTestReport;
        private PrepareTable _prepareTable = new PrepareTable();
        public TestResultDatabase()
        {
            InitializeComponent();
            dataGridView1.CellDoubleClick += DtGrdTestControlTable_CellDoubleClick;
            
        }

        private void TestResultDatabase_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = repositoryMain.GetAll();
        }

        private void DtGrdTestControlTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            List<TestCase> testResultCases = new List<TestCase>();
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            testResultCases.Add(repositoryHV.GetAll().FirstOrDefault(result => result.TestResultId == (int)row.Cells[0].Value));
            testResultCases.Add(repositoryLCR.GetAll().FirstOrDefault(result => result.TestResultId == (int)row.Cells[0].Value));
            testResultCases.Add(repositoryEMK.GetAll().FirstOrDefault(result => result.TestResultId == (int)row.Cells[0].Value));
            testResultCases.Add(repositoryPerform.GetAll().FirstOrDefault(result => result.TestResultId == (int)row.Cells[0].Value));
            DetailedTestReport detailedTestReport = new DetailedTestReport();
            _detailedTestReport = new DetailedTestReport();
            _detailedTestReport.HandleDestroyed += (object send, EventArgs e2) => { _detailedTestReport = null; };
            foreach (TestCase test in testResultCases)
            {
                if (test != null)
                {
                    _prepareTable.PreapareTableForDetailedReport(test, _detailedTestReport.TestResultTable);
                }
            }
            _detailedTestReport.Show();


        }
    }
}

using ElectricMotorTestVirtual.Entity;
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
            
             
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            textBox1.Text = row.Cells[0].Value.ToString();


        }
    }
}

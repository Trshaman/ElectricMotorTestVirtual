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
    public partial class DetailedTestReport : Form
    {
        private PrepareTable _prepareTable = new PrepareTable();
        private int _lastrowindex= 0;
        public DetailedTestReport()
        {
            InitializeComponent();
        }

        private void ExportPdf_Click(object sender, EventArgs e)
        {
            _prepareTable.ExportPdf(TestResultTable, TestSerialNumber.Text, TxbxTestDate.Text);
        }
    }
}

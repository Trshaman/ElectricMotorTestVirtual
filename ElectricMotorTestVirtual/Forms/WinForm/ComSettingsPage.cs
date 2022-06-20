using ElectricMotorTestVirtual.OOP_Approach.Settings;
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
    public partial class ComSettingsPage : Form
    {
        private SettingsData _currentSettingsData;
        public ComSettingsPage()
        {
            InitializeComponent();
            _currentSettingsData = Program.ProgamSettings;
            LoadSettingsUI();
            
        }
        private void LoadSettingsUI()
        {
            LstbxComSttngs1.Text = _currentSettingsData.ComSettings1;
            LstbxComSttngs2.Text = _currentSettingsData.ComSettings2;
            LstbxComSttngs3.Text = _currentSettingsData.ComSettings3;
        }
        
        private void LoadUItoSettings()
        {
            _currentSettingsData.ComSettings1 = LstbxComSttngs1.Text;
            _currentSettingsData.ComSettings2 = LstbxComSttngs2.Text;
            _currentSettingsData.ComSettings3 = LstbxComSttngs3.Text;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            LoadUItoSettings();
            SettingsData.SaveSettingsAsXML(Program.ProgramIniFile, _currentSettingsData);
        }
    }
}

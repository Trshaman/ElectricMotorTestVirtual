using ElectricMotorTestVirtual.OOP_Approach.Recipe;
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
    public partial class TestRecipeSettings : Form
    {
        private TestSettings _testSettings;
        private List<TestSettings> _testList;   
        public TestRecipeSettings()
        {
            InitializeComponent();
        }

        private void hvTestUserInterface1_Load(object sender, EventArgs e)
        {

        }

        private void hvTestUserInterface2_Load(object sender, EventArgs e)
        {

        }

        private void Save_Click(object sender, EventArgs e)
        {

        }
        public void LoadTestToUI(StepSettings step)
        {
            txBxStepName.Text = step.Name;
            cmbStepStartType.SelectedIndex = (int)step.StepStartType;
            cmbStepFinishType.SelectedIndex = (int)step.StepFinishType;
            txBxExplanation.Text = step.Explanation;
            nmStepLoopCount.Value = step.LoopCount;
            chkBxStopIfError.Checked = step.StopIfError;
            // ONUR KOVAN
            //nmFallRiseTimeAlarmValue.Value = step.RiseFallTimeAlarm;
            //chkBxFallRiseTimeAlarmEnable.Checked = step.RiseFallTimeAlarmEnable;
            //lkSetService.SetLeakageSetting(step.ServiceLeakageTestSetting);
            //lkSetEmergency.SetLeakageSetting(step.EmergencyLeakageTestSetting); 
            //LoadValveTimingsToGrid(step); // ONUR KOVAN
            cmbStepType.SelectedIndex = (int)step.StepSettingType;
            nmManualDuration.Value = step.ManualStepDuration;
            //nmValveOpenDelayTime.Value = step.ValveOpenDelayTime; // ONUR KOVAN
            if (step.VibratorStepSetting != null)
            {
                ChkBxVibratorEnable.Checked = step.VibratorStepSetting.Enabled;
                NmVibratorFrequency.Value = step.VibratorStepSetting.Frequency;
                NmVibratorAmplitude.Value = step.VibratorStepSetting.Amplitude;
                NmVibratorOffset.Value = step.VibratorStepSetting.Offset;
                NmVibratorCycle.Value = step.VibratorStepSetting.Cycle;
            }
            else
            {
                ChkBxVibratorEnable.Checked = false;
                NmVibratorFrequency.Value = 0;
                NmVibratorAmplitude.Value = 0;
                NmVibratorOffset.Value = 0;
                NmVibratorCycle.Value = 0;
            }
        }
}

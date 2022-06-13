using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GlobalFunctions;
using UserInterface;
using System.Threading;

namespace ElectricMotorTestVirtual.Forms.WinForm
{
  public delegate void LogWritedHandler(LogTypes type, int code, string description, Icon logIcon, bool writeLogToTextFile = false);
  //TODO: LOG inceleme üçüncü bir tab olarak alarm tabının uanıona konulacak.
  public partial class frmLog : Form
  {
    public event LogWritedHandler LogWrited;

    public frmLog()
    {
      InitializeComponent();
      tbCtrlLog.Font = new System.Drawing.Font("Arial", 13);
      AdjustGridViews(dtGrdVwAlarmLog);
      AdjustGridViews(dtGrdVwSystemLog);
      dtGrdVwAlarmLog.RowsAdded += dtGrd_RowsAdded;
      dtGrdVwSystemLog.RowsAdded += dtGrd_RowsAdded;
      this.Visible = false;
      this.FormClosing += FrmLog_FormClosing;
    }

    private void FrmLog_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (!Program.ProgramClosing)
      {
        e.Cancel = true;
        this.Visible = false;
      }
      else
      {
        e.Cancel = false;
      }
    }

    private void dtGrdVwSystemLog_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
    {
      if (dtGrdVwSystemLog.RowCount > 1 && dtGrdVwSystemLog.FirstDisplayedScrollingRowIndex != -1)
        dtGrdVwSystemLog.FirstDisplayedScrollingRowIndex = dtGrdVwSystemLog.RowCount - 1;
    }

    private void dtGrd_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
    {
      DataGridView dtg = sender as DataGridView;
      if (dtg.RowCount > 1 && dtg.FirstDisplayedScrollingRowIndex != -1)
        dtg.FirstDisplayedScrollingRowIndex = dtg.RowCount - 1;
    }

    /// <summary>
    /// Write log to log screen with database or text file
    /// </summary>
    /// <param name="type"></param>
    /// <param name="code"></param>
    /// <param name="description"></param>
    /// <param name="logIcon"></param>
    /// <param name="writeLogToTextFile"></param>
    //TODO log yazmak için data base ve connection koşullarını ayarla çalışmıyor.
    public void WriteLog(LogTypes logType, int code, int testId, int stepID, string description, Icon logIcon, bool writeLogToTextFile = false)
    {
      if (writeLogToTextFile)
        Logger.WriteLogToTextFile(code, description);
      else
        Logger.WriteLogToDatabase(logType, code, testId, stepID, description);
      Thread logThread = new Thread(() => logThreadCallback(logType, code, description, logIcon, writeLogToTextFile));
      logThread.Start();
    }

    public void WriteLog(Log log, bool writeLogToTextFile = false)
    {

      if (writeLogToTextFile)
        Logger.WriteLogToTextFile(log.Code, log.Description);
      else
        Logger.WriteLogToDatabase(log);
      Thread logThread = new Thread(() => logThreadCallback(log.Type, log.Code, log.Description, log.LogIcon, writeLogToTextFile));
      logThread.Start();
    }

    private void logThreadCallback(LogTypes logType, int code, string description, Icon logIcon, bool writeLogToTextFile)
    {
      if (Program.ProgramClosing) return;

      if (!this.IsDisposed)
      {
        if (!this.Visible && Parent != null && Parent.Visible)
          CrossThreadHelper.SetControlOfVisible(true, this);
        if (this.WindowState == FormWindowState.Minimized)
          CrossThreadHelper.SetFormOfWindowState(this, FormWindowState.Normal);
        //if (this.Visible)
        //  CrossThreadHelper.BringToFrontControl(this);
      }
      if (logType == LogTypes.Alarm && !dtGrdVwSystemLog.IsDisposed)
        CrossThreadHelper.AddRowToDataGridView(new object[] { logIcon, DateTime.Now.ToString(), code, description }, dtGrdVwAlarmLog);
      else if (logType == LogTypes.System && !dtGrdVwSystemLog.IsDisposed)
        CrossThreadHelper.AddRowToDataGridView(new object[] { logIcon, DateTime.Now.ToString(), code, description }, dtGrdVwSystemLog);
      if (LogWrited != null)
        LogWrited(logType, code, description, logIcon, writeLogToTextFile);
    }

    /// <summary>
    ///  Write log to log screen with database or text and show message box.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="code"></param>
    /// <param name="description"></param>
    /// <param name="header"></param>
    /// <param name="logIcon"></param>
    /// <param name="button"></param>
    /// <param name="messageBoxIcon"></param>
    /// <param name="?"></param>
    /// <param name="writeLogToTextFile"></param>
    /// <returns></returns>
    public DialogResult WriteLog(LogTypes type, int code, string description, string header, Icon logIcon, MessageBoxButtons button, MessageBoxIcon messageBoxIcon, bool writeLogToTextFile = false)
    {
      WriteLog(type, code, -1, -1, description, logIcon, writeLogToTextFile);
      return MessageBox.Show(description, header, button, messageBoxIcon);
    }

    private void AdjustGridViews(DataGridView grdView)
    {
      DataGridViewCell dataGridViewTextCell = new DataGridViewTextBoxCell();
      DataGridViewCell dataGridViewImageCell = new DataGridViewImageCell();

      grdView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
      grdView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      grdView.RowHeadersVisible = false;
      grdView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
      grdView.ColumnHeadersVisible = true;
      grdView.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
      grdView.ReadOnly = true;
      grdView.Font = new System.Drawing.Font("Arial", 13);

      //Column Icon
      DataGridViewImageColumn dtGrdVwIconCol = new DataGridViewImageColumn(true);
      dtGrdVwIconCol.CellTemplate = dataGridViewImageCell;
      dtGrdVwIconCol.Name = "dtGrdVwIconCol";
      dtGrdVwIconCol.HeaderText = "";
      dtGrdVwIconCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      grdView.Columns.Add(dtGrdVwIconCol);
      //Column DateTime
      DataGridViewColumn dtGrdVwDateTimeCol = new DataGridViewColumn();
      dtGrdVwDateTimeCol.CellTemplate = dataGridViewTextCell;
      dtGrdVwDateTimeCol.Name = "dtGrdVwDateTimeCol";
      dtGrdVwDateTimeCol.HeaderText = "Zaman";
      dtGrdVwDateTimeCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dtGrdVwDateTimeCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      grdView.Columns.Add(dtGrdVwDateTimeCol);
      //Column Log or error code
      DataGridViewColumn dtGrdVwCodeCol = new DataGridViewColumn();
      dtGrdVwCodeCol.CellTemplate = dataGridViewTextCell;
      dtGrdVwCodeCol.Name = "dtGrdVwCodeCol";
      dtGrdVwCodeCol.HeaderText = "No";
      dtGrdVwCodeCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dtGrdVwCodeCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      grdView.Columns.Add(dtGrdVwCodeCol);
      //Column description
      DataGridViewColumn dtGrdVwDescriptionCol = new DataGridViewColumn();
      dtGrdVwDescriptionCol.CellTemplate = dataGridViewTextCell;
      dtGrdVwDescriptionCol.Name = "dtGrdVwTextCol";
      dtGrdVwDescriptionCol.HeaderText = "Açıklama";
      dtGrdVwDescriptionCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dtGrdVwDescriptionCol.ReadOnly = true;
      dtGrdVwDescriptionCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      dtGrdVwDescriptionCol.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
      grdView.Columns.Add(dtGrdVwDescriptionCol);
    }

    
  }
}

namespace ElectricMotorTestVirtual.Forms.WinForm
{
  partial class frmLog
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLog));
      this.tbCtrlLog = new System.Windows.Forms.TabControl();
      this.tbPageSystem = new System.Windows.Forms.TabPage();
      this.dtGrdVwSystemLog = new System.Windows.Forms.DataGridView();
      this.tbPageAlarm = new System.Windows.Forms.TabPage();
      this.dtGrdVwAlarmLog = new System.Windows.Forms.DataGridView();
      this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
      this.tbCtrlLog.SuspendLayout();
      this.tbPageSystem.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dtGrdVwSystemLog)).BeginInit();
      this.tbPageAlarm.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dtGrdVwAlarmLog)).BeginInit();
      this.SuspendLayout();
      // 
      // tbCtrlLog
      // 
      this.tbCtrlLog.Controls.Add(this.tbPageSystem);
      this.tbCtrlLog.Controls.Add(this.tbPageAlarm);
      this.tbCtrlLog.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tbCtrlLog.ImageList = this.ımageList1;
      this.tbCtrlLog.Location = new System.Drawing.Point(0, 0);
      this.tbCtrlLog.Name = "tbCtrlLog";
      this.tbCtrlLog.SelectedIndex = 0;
      this.tbCtrlLog.Size = new System.Drawing.Size(871, 418);
      this.tbCtrlLog.TabIndex = 0;
      // 
      // tbPageSystem
      // 
      this.tbPageSystem.Controls.Add(this.dtGrdVwSystemLog);
      this.tbPageSystem.ImageIndex = 1;
      this.tbPageSystem.Location = new System.Drawing.Point(4, 31);
      this.tbPageSystem.Name = "tbPageSystem";
      this.tbPageSystem.Padding = new System.Windows.Forms.Padding(3);
      this.tbPageSystem.Size = new System.Drawing.Size(863, 383);
      this.tbPageSystem.TabIndex = 1;
      this.tbPageSystem.Text = "Sistem";
      this.tbPageSystem.UseVisualStyleBackColor = true;
      // 
      // dtGrdVwSystemLog
      // 
      this.dtGrdVwSystemLog.AllowUserToAddRows = false;
      this.dtGrdVwSystemLog.AllowUserToDeleteRows = false;
      this.dtGrdVwSystemLog.AllowUserToOrderColumns = true;
      this.dtGrdVwSystemLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dtGrdVwSystemLog.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dtGrdVwSystemLog.Location = new System.Drawing.Point(3, 3);
      this.dtGrdVwSystemLog.Name = "dtGrdVwSystemLog";
      this.dtGrdVwSystemLog.ReadOnly = true;
      this.dtGrdVwSystemLog.Size = new System.Drawing.Size(857, 377);
      this.dtGrdVwSystemLog.TabIndex = 3;
      // 
      // tbPageAlarm
      // 
      this.tbPageAlarm.Controls.Add(this.dtGrdVwAlarmLog);
      this.tbPageAlarm.ImageIndex = 2;
      this.tbPageAlarm.Location = new System.Drawing.Point(4, 31);
      this.tbPageAlarm.Name = "tbPageAlarm";
      this.tbPageAlarm.Padding = new System.Windows.Forms.Padding(3);
      this.tbPageAlarm.Size = new System.Drawing.Size(863, 383);
      this.tbPageAlarm.TabIndex = 0;
      this.tbPageAlarm.Text = "Alarm";
      this.tbPageAlarm.UseVisualStyleBackColor = true;
      // 
      // dtGrdVwAlarmLog
      // 
      this.dtGrdVwAlarmLog.AllowUserToAddRows = false;
      this.dtGrdVwAlarmLog.AllowUserToDeleteRows = false;
      this.dtGrdVwAlarmLog.AllowUserToOrderColumns = true;
      this.dtGrdVwAlarmLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dtGrdVwAlarmLog.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dtGrdVwAlarmLog.Location = new System.Drawing.Point(3, 3);
      this.dtGrdVwAlarmLog.Name = "dtGrdVwAlarmLog";
      this.dtGrdVwAlarmLog.ReadOnly = true;
      this.dtGrdVwAlarmLog.Size = new System.Drawing.Size(857, 377);
      this.dtGrdVwAlarmLog.TabIndex = 2;
      // 
      // ımageList1
      // 
      this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
      this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
      this.ımageList1.Images.SetKeyName(0, "Application-exit.ico");
      this.ımageList1.Images.SetKeyName(1, "stock-illustration-5261173-crash-test-icon.jpg");
      this.ımageList1.Images.SetKeyName(2, "NewAlarmBell.ico");
      // 
      // frmLog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(871, 418);
      this.Controls.Add(this.tbCtrlLog);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.Name = "frmLog";
      this.Text = "Olay Kayıtları";
      this.tbCtrlLog.ResumeLayout(false);
      this.tbPageSystem.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dtGrdVwSystemLog)).EndInit();
      this.tbPageAlarm.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dtGrdVwAlarmLog)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl tbCtrlLog;
    private System.Windows.Forms.TabPage tbPageAlarm;
    private System.Windows.Forms.TabPage tbPageSystem;
    private System.Windows.Forms.DataGridView dtGrdVwAlarmLog;
    private System.Windows.Forms.DataGridView dtGrdVwSystemLog;
    private System.Windows.Forms.ImageList ımageList1;
  }
}
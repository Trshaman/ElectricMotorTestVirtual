namespace UserInterface.GanttChart
{
  partial class GanttChart
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.horzScrollBar = new System.Windows.Forms.HScrollBar();
      this.verScrollBar = new System.Windows.Forms.VScrollBar();
      this.SuspendLayout();
      // 
      // horzScrollBar
      // 
      this.horzScrollBar.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.horzScrollBar.Location = new System.Drawing.Point(0, 494);
      this.horzScrollBar.Name = "horzScrollBar";
      this.horzScrollBar.Size = new System.Drawing.Size(639, 20);
      this.horzScrollBar.TabIndex = 3;
      // 
      // verScrollBar
      // 
      this.verScrollBar.Dock = System.Windows.Forms.DockStyle.Right;
      this.verScrollBar.Location = new System.Drawing.Point(619, 0);
      this.verScrollBar.Name = "verScrollBar";
      this.verScrollBar.Size = new System.Drawing.Size(20, 494);
      this.verScrollBar.TabIndex = 4;
      // 
      // GanttChart
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.Controls.Add(this.verScrollBar);
      this.Controls.Add(this.horzScrollBar);
      this.Name = "GanttChart";
      this.Size = new System.Drawing.Size(639, 514);
      this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.HScrollBar horzScrollBar;
    private System.Windows.Forms.VScrollBar verScrollBar;
  }
}

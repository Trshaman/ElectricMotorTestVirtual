namespace UserInterface
{
  public partial class ToggleSwitch
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
      this.SuspendLayout();
      // 
      // ToggleSwitch
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Name = "ToggleSwitch";
      this.Size = new System.Drawing.Size(100, 50);
      this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ToggleSwitch_MouseUp);
      this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ToggleSwitch_MouseDown);
      this.ResumeLayout(false);
    }

    #endregion


  }
}

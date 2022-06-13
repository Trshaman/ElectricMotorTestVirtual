namespace UserInterface
{
  partial class SteeringWheel
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
      this.label1 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(0, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(0, 13);
      this.label1.TabIndex = 0;
      // 
      // SteeringWheel
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.label1);
      this.Margin = new System.Windows.Forms.Padding(2);
      this.Name = "SteeringWheel";
      this.Size = new System.Drawing.Size(156, 176);
      this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SteeringWheel_MouseDown);
      this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SteeringWheel_MouseMove);
      this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.SteeringWheel_MouseWheel);
      this.ResumeLayout(false);
      this.PerformLayout();

    }



    #endregion

    private System.Windows.Forms.Label label1;
  }
}

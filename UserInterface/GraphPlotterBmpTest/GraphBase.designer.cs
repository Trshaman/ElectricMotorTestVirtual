﻿namespace UserInterface.GraphPlotter
{

  public partial class  GraphBase
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
      // GraphBase
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.BackColor = System.Drawing.Color.White;
      this.ForeColor = System.Drawing.SystemColors.WindowText;
      this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.Margin = new System.Windows.Forms.Padding(0);
      this.Name = "GraphBase";
      this.Size = new System.Drawing.Size(557, 339);
      this.ResumeLayout(false);

    }

    #endregion

  }
}
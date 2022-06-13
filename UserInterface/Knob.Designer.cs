using System.Drawing;
namespace UserInterface
{
  partial class Knob
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
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(115, 137);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(0, 13);
      this.label1.TabIndex = 0;
      // 
      // pictureBox1
      // 
      this.pictureBox1.Location = new System.Drawing.Point(88, 75);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(67, 59);
      this.pictureBox1.TabIndex = 1;
      this.pictureBox1.TabStop = false;
      // 
      // Knob
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.ChannelName = "";
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.label1);
     
      this.Name = "Knob";


      this.Size = new System.Drawing.Size(263, 237);
      this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Knob_MouseDown);
      this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Knob_MouseMove);
      this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Knob_MouseWheel);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
      

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.PictureBox pictureBox1;

    //private System.Windows.Forms.Label label1;
  }
}

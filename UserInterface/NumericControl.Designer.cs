namespace UserInterface
{
  partial class NumericControl
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
      this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
      this.headerWithUnit1 = new UserInterface.HeaderWithUnit();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // numericUpDown1
      // 
      this.numericUpDown1.BackColor = System.Drawing.SystemColors.Window;
      this.numericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
      this.numericUpDown1.Location = new System.Drawing.Point(3, 39);
      this.numericUpDown1.Name = "numericUpDown1";
      this.numericUpDown1.Size = new System.Drawing.Size(470, 44);
      this.numericUpDown1.TabIndex = 0;
      // 
      // headerWithUnit1
      // 
      this.headerWithUnit1.BackFillType = GlobalFunctions.BackFillTypes.None;
      this.headerWithUnit1.BackGradientColor = System.Drawing.Color.White;
      this.headerWithUnit1.BackGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
      this.headerWithUnit1.ChannelList = null;
      this.headerWithUnit1.ChannelName = null;
      this.headerWithUnit1.ContainerFormName = null;
      this.headerWithUnit1.DesignModeActive = false;
      this.headerWithUnit1.Header = "Header";
      this.headerWithUnit1.HeaderBackColor = System.Drawing.Color.Maroon;
      this.headerWithUnit1.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
      this.headerWithUnit1.HeaderForeColor = System.Drawing.Color.Black;
      this.headerWithUnit1.HeaderPosition = UserInterface.HeaderPosition.Top;
      this.headerWithUnit1.HeaderVisible = true;
      this.headerWithUnit1.Location = new System.Drawing.Point(3, 3);
      this.headerWithUnit1.Name = "headerWithUnit1";
      this.headerWithUnit1.PropertyEditMode = false;
      this.headerWithUnit1.Selected = false;
      this.headerWithUnit1.Size = new System.Drawing.Size(561, 30);
      this.headerWithUnit1.TabIndex = 1;
      this.headerWithUnit1.Unit = "Unit";
      // 
      // pictureBox1
      // 
      this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
      this.pictureBox1.Location = new System.Drawing.Point(495, 44);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(42, 38);
      this.pictureBox1.TabIndex = 2;
      this.pictureBox1.TabStop = false;
      // 
      // NumericControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.LightGray;
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.headerWithUnit1);
      this.Controls.Add(this.numericUpDown1);
      this.Name = "NumericControl";
      this.Size = new System.Drawing.Size(566, 87);
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.NumericUpDown numericUpDown1;
    private HeaderWithUnit headerWithUnit1;
    private System.Windows.Forms.PictureBox pictureBox1;


  }
}

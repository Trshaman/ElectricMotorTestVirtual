namespace UserInterface
{
  partial  class Messages
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
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.lblMessage = new System.Windows.Forms.Label();
      this.btnOk = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // pictureBox1
      // 
      this.pictureBox1.Location = new System.Drawing.Point(326, 13);
      this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(56, 49);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      // 
      // lblMessage
      // 
      this.lblMessage.BackColor = System.Drawing.SystemColors.Control;
      this.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
      this.lblMessage.Location = new System.Drawing.Point(13, 66);
      this.lblMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblMessage.Name = "lblMessage";
      this.lblMessage.Size = new System.Drawing.Size(717, 161);
      this.lblMessage.TabIndex = 1;
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(301, 231);
      this.btnOk.Margin = new System.Windows.Forms.Padding(4);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size(100, 28);
      this.btnOk.TabIndex = 2;
      this.btnOk.Text = "Ok";
      this.btnOk.UseVisualStyleBackColor = true;
      // 
      // Messages
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(743, 267);
      this.Controls.Add(this.btnOk);
      this.Controls.Add(this.lblMessage);
      this.Controls.Add(this.pictureBox1);
      this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "Messages";
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Label lblMessage;
    private System.Windows.Forms.Button btnOk;
  }
}
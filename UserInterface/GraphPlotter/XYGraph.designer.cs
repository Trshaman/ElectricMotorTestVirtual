namespace UserInterface.GraphPlotter
{

  partial class XYGraph
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
      this.components = new System.ComponentModel.Container();
      this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.tstrpPause = new System.Windows.Forms.ToolStripMenuItem();
      this.tstrpSetXDivision = new System.Windows.Forms.ToolStripMenuItem();
      this.tstrpTxtBoxSetXDivision = new System.Windows.Forms.ToolStripTextBox();
      this.tstrpClear = new System.Windows.Forms.ToolStripMenuItem();
      this.tstrpCopyImage = new System.Windows.Forms.ToolStripMenuItem();
      this.tstrpAutoRangeXAxis = new System.Windows.Forms.ToolStripMenuItem();
      this.tstrpAutoRangeYAxis = new System.Windows.Forms.ToolStripMenuItem();
      this.contextMenuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tstrpPause,
            this.tstrpSetXDivision,
            this.tstrpClear,
            this.tstrpCopyImage,
            this.tstrpAutoRangeXAxis,
            this.tstrpAutoRangeYAxis});
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new System.Drawing.Size(171, 158);
      // 
      // tstrpPause
      // 
      this.tstrpPause.CheckOnClick = true;
      this.tstrpPause.Name = "tstrpPause";
      this.tstrpPause.Size = new System.Drawing.Size(170, 22);
      this.tstrpPause.Text = "Pause";
      // 
      // tstrpSetXDivision
      // 
      this.tstrpSetXDivision.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tstrpTxtBoxSetXDivision});
      this.tstrpSetXDivision.Name = "tstrpSetXDivision";
      this.tstrpSetXDivision.Size = new System.Drawing.Size(170, 22);
      this.tstrpSetXDivision.Text = "Set X Division";
      // 
      // tstrpTxtBoxSetXDivision
      // 
      this.tstrpTxtBoxSetXDivision.Name = "tstrpTxtBoxSetXDivision";
      this.tstrpTxtBoxSetXDivision.Size = new System.Drawing.Size(100, 23);
      // 
      // tstrpClear
      // 
      this.tstrpClear.Name = "tstrpClear";
      this.tstrpClear.Size = new System.Drawing.Size(170, 22);
      this.tstrpClear.Text = "Clear";
      // 
      // tstrpCopyImage
      // 
      this.tstrpCopyImage.Name = "tstrpCopyImage";
      this.tstrpCopyImage.Size = new System.Drawing.Size(170, 22);
      this.tstrpCopyImage.Text = "Copy Image";
      // 
      // tstrpAutoRangeXAxis
      // 
      this.tstrpAutoRangeXAxis.CheckOnClick = true;
      this.tstrpAutoRangeXAxis.Name = "tstrpAutoRangeXAxis";
      this.tstrpAutoRangeXAxis.Size = new System.Drawing.Size(170, 22);
      this.tstrpAutoRangeXAxis.Text = "Auto Range X Axis";
      // 
      // tstrpAutoRangeYAxis
      // 
      this.tstrpAutoRangeYAxis.CheckOnClick = true;
      this.tstrpAutoRangeYAxis.Name = "tstrpAutoRangeYAxis";
      this.tstrpAutoRangeYAxis.Size = new System.Drawing.Size(170, 22);
      this.tstrpAutoRangeYAxis.Text = "Auto Range Y Axis";
      // 
      // XYGraph
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.BackColor = System.Drawing.Color.White;
      this.Name = "XYGraph";
      this.contextMenuStrip1.ResumeLayout(false);
      this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tstrpPause;
        private System.Windows.Forms.ToolStripMenuItem tstrpSetXDivision;
        private System.Windows.Forms.ToolStripTextBox tstrpTxtBoxSetXDivision;
        private System.Windows.Forms.ToolStripMenuItem tstrpClear;
        private System.Windows.Forms.ToolStripMenuItem tstrpCopyImage;
        private System.Windows.Forms.ToolStripMenuItem tstrpAutoRangeXAxis;
        private System.Windows.Forms.ToolStripMenuItem tstrpAutoRangeYAxis;
    }
}

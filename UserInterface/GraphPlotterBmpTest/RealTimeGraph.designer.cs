namespace UserInterface.GraphPlotter
{

    partial class RealTimeGraph
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
      this.tstrbShowCurves = new System.Windows.Forms.ToolStripMenuItem();
      this.tstrbShowXAxisAsSecond = new System.Windows.Forms.ToolStripMenuItem();
      this.tstrpCopyImage = new System.Windows.Forms.ToolStripMenuItem();
      this.contextMenuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tstrpPause,
            this.tstrpSetXDivision,
            this.tstrbShowCurves,
            this.tstrbShowXAxisAsSecond,
            this.tstrpCopyImage});
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new System.Drawing.Size(192, 114);
      // 
      // tstrpPause
      // 
      this.tstrpPause.CheckOnClick = true;
      this.tstrpPause.Name = "tstrpPause";
      this.tstrpPause.Size = new System.Drawing.Size(191, 22);
      this.tstrpPause.Text = "Pause";
      // 
      // tstrpSetXDivision
      // 
      this.tstrpSetXDivision.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tstrpTxtBoxSetXDivision});
      this.tstrpSetXDivision.Name = "tstrpSetXDivision";
      this.tstrpSetXDivision.Size = new System.Drawing.Size(191, 22);
      this.tstrpSetXDivision.Text = "Set X Division";
      // 
      // tstrpTxtBoxSetXDivision
      // 
      this.tstrpTxtBoxSetXDivision.Name = "tstrpTxtBoxSetXDivision";
      this.tstrpTxtBoxSetXDivision.Size = new System.Drawing.Size(100, 23);
      // 
      // tstrbShowCurves
      // 
      this.tstrbShowCurves.Name = "tstrbShowCurves";
      this.tstrbShowCurves.Size = new System.Drawing.Size(191, 22);
      this.tstrbShowCurves.Text = "Show Curves";
      // 
      // tstrbShowXAxisAsSecond
      // 
      this.tstrbShowXAxisAsSecond.CheckOnClick = true;
      this.tstrbShowXAxisAsSecond.Name = "tstrbShowXAxisAsSecond";
      this.tstrbShowXAxisAsSecond.Size = new System.Drawing.Size(191, 22);
      this.tstrbShowXAxisAsSecond.Text = "Show X axis as Second";
      // 
      // tstrpCopyImage
      // 
      this.tstrpCopyImage.Name = "tstrpCopyImage";
      this.tstrpCopyImage.Size = new System.Drawing.Size(191, 22);
      this.tstrpCopyImage.Text = "Copy Image";
      // 
      // RealTimeGraph
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.BackColor = System.Drawing.Color.White;
      this.DoubleBuffered = true;
      this.Name = "RealTimeGraph";
      this.contextMenuStrip1.ResumeLayout(false);
      this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tstrpPause;
        private System.Windows.Forms.ToolStripMenuItem tstrpSetXDivision;
        private System.Windows.Forms.ToolStripTextBox tstrpTxtBoxSetXDivision;
        private System.Windows.Forms.ToolStripMenuItem tstrbShowCurves;
        private System.Windows.Forms.ToolStripMenuItem tstrbShowXAxisAsSecond;
        private System.Windows.Forms.ToolStripMenuItem tstrpCopyImage;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface
{
  public partial class DigitalBase
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
      this.kanalSeçimiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.contextMenuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kanalSeçimiToolStripMenuItem});
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new System.Drawing.Size(142, 26);
      // 
      // kanalSeçimiToolStripMenuItem
      // 
      this.kanalSeçimiToolStripMenuItem.Name = "kanalSeçimiToolStripMenuItem";
      this.kanalSeçimiToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
      this.kanalSeçimiToolStripMenuItem.Text = "Kanal Seçimi";
      // 
      // DigitalBase
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.DoubleBuffered = true;
      this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.Name = "DigitalBase";
      this.Size = new System.Drawing.Size(112, 122);
      this.contextMenuStrip1.ResumeLayout(false);
      this.ResumeLayout(false);

    }
    #endregion

    private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    private System.Windows.Forms.ToolStripMenuItem kanalSeçimiToolStripMenuItem;

  }
}

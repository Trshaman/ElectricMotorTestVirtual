namespace ElectricMotorTestVirtual.Forms.WinForm
{
    partial class MainScreen1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.testSayfasiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.receteAyarlariToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.haberlesmeAyarlariToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programiKapatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.raporToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testSayfasiToolStripMenuItem,
            this.receteAyarlariToolStripMenuItem,
            this.haberlesmeAyarlariToolStripMenuItem,
            this.programiKapatToolStripMenuItem,
            this.raporToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1101, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // testSayfasiToolStripMenuItem
            // 
            this.testSayfasiToolStripMenuItem.Name = "testSayfasiToolStripMenuItem";
            this.testSayfasiToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.testSayfasiToolStripMenuItem.Text = "Test Sayfası";
            this.testSayfasiToolStripMenuItem.Click += new System.EventHandler(this.testSayfasiToolStripMenuItem_Click);
            // 
            // receteAyarlariToolStripMenuItem
            // 
            this.receteAyarlariToolStripMenuItem.Name = "receteAyarlariToolStripMenuItem";
            this.receteAyarlariToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.receteAyarlariToolStripMenuItem.Text = "Reçete Ayarları";
            this.receteAyarlariToolStripMenuItem.Click += new System.EventHandler(this.receteAyarlariToolStripMenuItem_Click);
            // 
            // haberlesmeAyarlariToolStripMenuItem
            // 
            this.haberlesmeAyarlariToolStripMenuItem.Name = "haberlesmeAyarlariToolStripMenuItem";
            this.haberlesmeAyarlariToolStripMenuItem.Size = new System.Drawing.Size(125, 20);
            this.haberlesmeAyarlariToolStripMenuItem.Text = "Haberleşme Ayarları";
            this.haberlesmeAyarlariToolStripMenuItem.Click += new System.EventHandler(this.haberlesmeAyarlariToolStripMenuItem_Click_1);
            // 
            // programiKapatToolStripMenuItem
            // 
            this.programiKapatToolStripMenuItem.Name = "programiKapatToolStripMenuItem";
            this.programiKapatToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.programiKapatToolStripMenuItem.Text = "Programı Kapat";
            this.programiKapatToolStripMenuItem.Click += new System.EventHandler(this.programiKapatToolStripMenuItem_Click_1);
            // 
            // raporToolStripMenuItem
            // 
            this.raporToolStripMenuItem.Name = "raporToolStripMenuItem";
            this.raporToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.raporToolStripMenuItem.Text = "Rapor";
            this.raporToolStripMenuItem.Click += new System.EventHandler(this.raporToolStripMenuItem_Click);
            // 
            // MainScreen1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 602);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.Name = "MainScreen1";
            this.Text = "MainScreen1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem testSayfasiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem receteAyarlariToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem haberlesmeAyarlariToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem programiKapatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem raporToolStripMenuItem;
    }
}
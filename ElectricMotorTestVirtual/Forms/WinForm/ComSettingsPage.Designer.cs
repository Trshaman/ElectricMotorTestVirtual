namespace ElectricMotorTestVirtual.Forms.WinForm
{
    partial class ComSettingsPage
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
            this.components = new System.ComponentModel.Container();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.LstbxComSttngs1 = new System.Windows.Forms.ListBox();
            this.LstbxComSttngs3 = new System.Windows.Forms.ListBox();
            this.LstbxComSttngs2 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LstbxComSttngs1
            // 
            this.LstbxComSttngs1.FormattingEnabled = true;
            this.LstbxComSttngs1.Location = new System.Drawing.Point(89, 81);
            this.LstbxComSttngs1.Name = "LstbxComSttngs1";
            this.LstbxComSttngs1.Size = new System.Drawing.Size(185, 30);
            this.LstbxComSttngs1.TabIndex = 0;
            // 
            // LstbxComSttngs3
            // 
            this.LstbxComSttngs3.FormattingEnabled = true;
            this.LstbxComSttngs3.Location = new System.Drawing.Point(89, 199);
            this.LstbxComSttngs3.Name = "LstbxComSttngs3";
            this.LstbxComSttngs3.Size = new System.Drawing.Size(185, 30);
            this.LstbxComSttngs3.TabIndex = 0;
            // 
            // LstbxComSttngs2
            // 
            this.LstbxComSttngs2.FormattingEnabled = true;
            this.LstbxComSttngs2.Location = new System.Drawing.Point(89, 140);
            this.LstbxComSttngs2.Name = "LstbxComSttngs2";
            this.LstbxComSttngs2.Size = new System.Drawing.Size(185, 30);
            this.LstbxComSttngs2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Com Settings1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Com Settings2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Com Settings3";
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(189, 310);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(164, 44);
            this.BtnSave.TabIndex = 2;
            this.BtnSave.Text = "Kaydet";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(19, 310);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(164, 44);
            this.BtnClose.TabIndex = 2;
            this.BtnClose.Text = "Çıkış";
            this.BtnClose.UseVisualStyleBackColor = true;
            // 
            // ComSettingsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 414);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LstbxComSttngs2);
            this.Controls.Add(this.LstbxComSttngs3);
            this.Controls.Add(this.LstbxComSttngs1);
            this.Name = "ComSettingsPage";
            this.Text = "ComSettingsPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ListBox LstbxComSttngs1;
        private System.Windows.Forms.ListBox LstbxComSttngs3;
        private System.Windows.Forms.ListBox LstbxComSttngs2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnClose;
    }
}
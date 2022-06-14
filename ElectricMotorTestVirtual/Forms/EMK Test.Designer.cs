namespace ElectricMotorTestVirtual.Forms
{
    partial class EMK_Test
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
            this.EmkTestActive = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.RmsMin = new System.Windows.Forms.TextBox();
            this.RmsMax = new System.Windows.Forms.TextBox();
            this.PeaktoPeakMin = new System.Windows.Forms.TextBox();
            this.PeaktoPeakMax = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.hvTestUserInterface1 = new ElectricMotorTestVirtual.Forms.HvTestUserInterface();
            this.lcrTest1 = new ElectricMotorTestVirtual.Forms.LCRTest();
            this.performansTest1 = new ElectricMotorTestVirtual.Forms.PerformansTest();
            this.performansTest2 = new ElectricMotorTestVirtual.Forms.PerformansTest();
            this.performansTest3 = new ElectricMotorTestVirtual.Forms.PerformansTest();
            this.lcrTest2 = new ElectricMotorTestVirtual.Forms.LCRTest();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // EmkTestActive
            // 
            this.EmkTestActive.AutoSize = true;
            this.EmkTestActive.Location = new System.Drawing.Point(42, 20);
            this.EmkTestActive.Name = "EmkTestActive";
            this.EmkTestActive.Size = new System.Drawing.Size(95, 17);
            this.EmkTestActive.TabIndex = 1;
            this.EmkTestActive.Text = "Emk Test Aktif";
            this.EmkTestActive.UseVisualStyleBackColor = true;
            this.EmkTestActive.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.RmsMin);
            this.groupBox1.Controls.Add(this.RmsMax);
            this.groupBox1.Controls.Add(this.PeaktoPeakMin);
            this.groupBox1.Controls.Add(this.PeaktoPeakMax);
            this.groupBox1.Location = new System.Drawing.Point(42, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(464, 275);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Test Limit Parametreleri";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(303, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 15);
            this.label5.TabIndex = 125;
            this.label5.Text = "Rms Min (V)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(303, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 15);
            this.label2.TabIndex = 125;
            this.label2.Text = "Peak to Peak Min (V)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(63, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 15);
            this.label4.TabIndex = 125;
            this.label4.Text = "Rms Max (V)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(63, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 15);
            this.label3.TabIndex = 125;
            this.label3.Text = "Peak to Peak Max (V)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RmsMin
            // 
            this.RmsMin.Location = new System.Drawing.Point(306, 183);
            this.RmsMin.Name = "RmsMin";
            this.RmsMin.Size = new System.Drawing.Size(101, 20);
            this.RmsMin.TabIndex = 0;
            // 
            // RmsMax
            // 
            this.RmsMax.Location = new System.Drawing.Point(66, 183);
            this.RmsMax.Name = "RmsMax";
            this.RmsMax.Size = new System.Drawing.Size(101, 20);
            this.RmsMax.TabIndex = 0;
            // 
            // PeaktoPeakMin
            // 
            this.PeaktoPeakMin.Location = new System.Drawing.Point(306, 115);
            this.PeaktoPeakMin.Name = "PeaktoPeakMin";
            this.PeaktoPeakMin.Size = new System.Drawing.Size(101, 20);
            this.PeaktoPeakMin.TabIndex = 0;
            // 
            // PeaktoPeakMax
            // 
            this.PeaktoPeakMax.Location = new System.Drawing.Point(66, 115);
            this.PeaktoPeakMax.Name = "PeaktoPeakMax";
            this.PeaktoPeakMax.Size = new System.Drawing.Size(101, 20);
            this.PeaktoPeakMax.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // hvTestUserInterface1
            // 
            this.hvTestUserInterface1.Location = new System.Drawing.Point(0, 0);
            this.hvTestUserInterface1.Name = "hvTestUserInterface1";
            this.hvTestUserInterface1.Size = new System.Drawing.Size(552, 362);
            this.hvTestUserInterface1.TabIndex = 3;
            // 
            // lcrTest1
            // 
            this.lcrTest1.Location = new System.Drawing.Point(0, 0);
            this.lcrTest1.Name = "lcrTest1";
            this.lcrTest1.Size = new System.Drawing.Size(543, 364);
            this.lcrTest1.TabIndex = 4;
            // 
            // performansTest1
            // 
            this.performansTest1.Location = new System.Drawing.Point(0, 0);
            this.performansTest1.Name = "performansTest1";
            this.performansTest1.Size = new System.Drawing.Size(561, 366);
            this.performansTest1.TabIndex = 5;
            // 
            // performansTest2
            // 
            this.performansTest2.Location = new System.Drawing.Point(0, 0);
            this.performansTest2.Name = "performansTest2";
            this.performansTest2.Size = new System.Drawing.Size(561, 366);
            this.performansTest2.TabIndex = 6;
            // 
            // performansTest3
            // 
            this.performansTest3.Location = new System.Drawing.Point(0, 0);
            this.performansTest3.Name = "performansTest3";
            this.performansTest3.Size = new System.Drawing.Size(561, 366);
            this.performansTest3.TabIndex = 7;
            // 
            // lcrTest2
            // 
            this.lcrTest2.Location = new System.Drawing.Point(0, 0);
            this.lcrTest2.Name = "lcrTest2";
            this.lcrTest2.Size = new System.Drawing.Size(543, 364);
            this.lcrTest2.TabIndex = 8;
            // 
            // EMK_Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lcrTest2);
            this.Controls.Add(this.performansTest3);
            this.Controls.Add(this.performansTest2);
            this.Controls.Add(this.performansTest1);
            this.Controls.Add(this.lcrTest1);
            this.Controls.Add(this.hvTestUserInterface1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.EmkTestActive);
            this.Name = "EMK_Test";
            this.Size = new System.Drawing.Size(555, 356);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox EmkTestActive;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox PeaktoPeakMax;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PeaktoPeakMin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox RmsMin;
        private System.Windows.Forms.TextBox RmsMax;
        private HvTestUserInterface hvTestUserInterface1;
        private LCRTest lcrTest1;
        private PerformansTest performansTest1;
        private PerformansTest performansTest2;
        private PerformansTest performansTest3;
        private LCRTest lcrTest2;
    }
}

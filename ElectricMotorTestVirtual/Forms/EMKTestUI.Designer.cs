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
            this.EmkTestActive = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.PeaktoPeakV_Max = new  System.Windows.Forms.TextBox();
            this.PeaktoPeakV_Min = new System.Windows.Forms.TextBox();
            this.RmsV_Max = new System.Windows.Forms.TextBox();
            this.RmsV_Min = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // EmkTestActive
            // 
            this.EmkTestActive.AutoSize = true;
            this.EmkTestActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmkTestActive.Location = new System.Drawing.Point(42, 20);
            this.EmkTestActive.Name = "EmkTestActive";
            this.EmkTestActive.Size = new System.Drawing.Size(123, 22);
            this.EmkTestActive.TabIndex = 1;
            this.EmkTestActive.Text = "Emk Test Aktif";
            this.EmkTestActive.UseVisualStyleBackColor = true;
            this.EmkTestActive.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RmsV_Min);
            this.groupBox1.Controls.Add(this.PeaktoPeakV_Min);
            this.groupBox1.Controls.Add(this.RmsV_Max);
            this.groupBox1.Controls.Add(this.PeaktoPeakV_Max);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(42, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(405, 256);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Test Limit Parametreleri";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(245, 56);
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
            this.label3.Location = new System.Drawing.Point(63, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 15);
            this.label3.TabIndex = 125;
            this.label3.Text = "Peak to Peak Max (V)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(245, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 15);
            this.label5.TabIndex = 125;
            this.label5.Text = "Rms Min (V)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PeaktoPeakV_Max
            // 
            this.PeaktoPeakV_Max.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PeaktoPeakV_Max.Location = new System.Drawing.Point(66, 81);
            this.PeaktoPeakV_Max.Name = "PeaktoPeakV_Max";
            this.PeaktoPeakV_Max.Size = new System.Drawing.Size(94, 24);
            this.PeaktoPeakV_Max.TabIndex = 126;
            this.PeaktoPeakV_Max.Text = "0.00";
            this.PeaktoPeakV_Max.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // PeaktoPeakV_Min
            // 
            this.PeaktoPeakV_Min.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PeaktoPeakV_Min.Location = new System.Drawing.Point(248, 81);
            this.PeaktoPeakV_Min.Name = "PeaktoPeakV_Min";
            this.PeaktoPeakV_Min.Size = new System.Drawing.Size(94, 24);
            this.PeaktoPeakV_Min.TabIndex = 126;
            this.PeaktoPeakV_Min.Text = "0.00";
            this.PeaktoPeakV_Min.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // RmsV_Max
            // 
            this.RmsV_Max.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RmsV_Max.Location = new System.Drawing.Point(66, 183);
            this.RmsV_Max.Name = "RmsV_Max";
            this.RmsV_Max.Size = new System.Drawing.Size(94, 24);
            this.RmsV_Max.TabIndex = 126;
            this.RmsV_Max.Text = "0.00";
            this.RmsV_Max.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // RmsV_Min
            // 
            this.RmsV_Min.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RmsV_Min.Location = new System.Drawing.Point(248, 183);
            this.RmsV_Min.Name = "RmsV_Min";
            this.RmsV_Min.Size = new System.Drawing.Size(94, 24);
            this.RmsV_Min.TabIndex = 127;
            this.RmsV_Min.Text = "0.00";
            this.RmsV_Min.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // EMK_Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.EmkTestActive);
            this.Name = "EMK_Test";
            this.Size = new System.Drawing.Size(482, 336);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox EmkTestActive;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox RmsV_Min;
        private System.Windows.Forms.TextBox PeaktoPeakV_Min;
        private System.Windows.Forms.TextBox RmsV_Max;
        private System.Windows.Forms.TextBox PeaktoPeakV_Max;
    }
}

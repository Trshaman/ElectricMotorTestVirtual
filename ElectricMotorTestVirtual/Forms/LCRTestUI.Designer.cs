namespace ElectricMotorTestVirtual.Forms
{
    partial class LCRTestUI
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LCRTestActive = new System.Windows.Forms.CheckBox();
            this.R1Ohm_Max = new System.Windows.Forms.TextBox();
            this.R2Ohm_Max = new System.Windows.Forms.TextBox();
            this.R3Ohm_Max = new System.Windows.Forms.TextBox();
            this.L1Inductance_Max = new System.Windows.Forms.TextBox();
            this.L2Inductance_Max = new System.Windows.Forms.TextBox();
            this.L3Inductance_Max = new System.Windows.Forms.TextBox();
            this.R1Ohm_Min = new System.Windows.Forms.TextBox();
            this.R2Ohm_Min = new System.Windows.Forms.TextBox();
            this.R3Ohm_Min = new System.Windows.Forms.TextBox();
            this.L1Inductance_Min = new System.Windows.Forms.TextBox();
            this.L2Inductance_Min = new System.Windows.Forms.TextBox();
            this.L3Inductance_Min = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.L3Inductance_Min);
            this.groupBox1.Controls.Add(this.L3Inductance_Max);
            this.groupBox1.Controls.Add(this.L2Inductance_Min);
            this.groupBox1.Controls.Add(this.L2Inductance_Max);
            this.groupBox1.Controls.Add(this.L1Inductance_Min);
            this.groupBox1.Controls.Add(this.L1Inductance_Max);
            this.groupBox1.Controls.Add(this.R3Ohm_Min);
            this.groupBox1.Controls.Add(this.R3Ohm_Max);
            this.groupBox1.Controls.Add(this.R2Ohm_Min);
            this.groupBox1.Controls.Add(this.R2Ohm_Max);
            this.groupBox1.Controls.Add(this.R1Ohm_Min);
            this.groupBox1.Controls.Add(this.R1Ohm_Max);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(39, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(467, 321);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Test Limit Parametreleri";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label13.Location = new System.Drawing.Point(289, 277);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(81, 15);
            this.label13.TabIndex = 125;
            this.label13.Text = "L3 Min (ohm)";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.Location = new System.Drawing.Point(289, 228);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 15);
            this.label11.TabIndex = 125;
            this.label11.Text = "L2 Min (ohm)";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(289, 176);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 15);
            this.label9.TabIndex = 125;
            this.label9.Text = "L1 Min (ohm)";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(290, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 15);
            this.label7.TabIndex = 125;
            this.label7.Text = "R3 Min (ohm)";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(288, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 15);
            this.label5.TabIndex = 125;
            this.label5.Text = "R2 Min (ohm)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(289, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 15);
            this.label2.TabIndex = 125;
            this.label2.Text = "R1 Min (ohm)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label12.Location = new System.Drawing.Point(55, 276);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(87, 15);
            this.label12.TabIndex = 125;
            this.label12.Text = "L3  Max (ohm)";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(56, 227);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 15);
            this.label10.TabIndex = 125;
            this.label10.Text = "L2  Max (ohm)";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(54, 174);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 15);
            this.label8.TabIndex = 125;
            this.label8.Text = "L1  Max (ohm)";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(54, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 15);
            this.label6.TabIndex = 125;
            this.label6.Text = "R3  Max (ohm)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(54, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 15);
            this.label4.TabIndex = 125;
            this.label4.Text = "R2  Max (ohm)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(54, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 15);
            this.label3.TabIndex = 125;
            this.label3.Text = "R1  Max (ohm)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // LCRTestActive
            // 
            this.LCRTestActive.AutoSize = true;
            this.LCRTestActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LCRTestActive.Location = new System.Drawing.Point(39, 12);
            this.LCRTestActive.Name = "LCRTestActive";
            this.LCRTestActive.Size = new System.Drawing.Size(122, 22);
            this.LCRTestActive.TabIndex = 3;
            this.LCRTestActive.Text = "LCR Test Aktif";
            this.LCRTestActive.UseVisualStyleBackColor = true;
            // 
            // R1Ohm_Max
            // 
            this.R1Ohm_Max.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.R1Ohm_Max.Location = new System.Drawing.Point(57, 44);
            this.R1Ohm_Max.Name = "R1Ohm_Max";
            this.R1Ohm_Max.Size = new System.Drawing.Size(101, 24);
            this.R1Ohm_Max.TabIndex = 126;
            this.R1Ohm_Max.Text = "0.00";
            this.R1Ohm_Max.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // R2Ohm_Max
            // 
            this.R2Ohm_Max.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.R2Ohm_Max.Location = new System.Drawing.Point(57, 95);
            this.R2Ohm_Max.Name = "R2Ohm_Max";
            this.R2Ohm_Max.Size = new System.Drawing.Size(101, 24);
            this.R2Ohm_Max.TabIndex = 126;
            this.R2Ohm_Max.Text = "0.00";
            this.R2Ohm_Max.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // R3Ohm_Max
            // 
            this.R3Ohm_Max.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.R3Ohm_Max.Location = new System.Drawing.Point(57, 142);
            this.R3Ohm_Max.Name = "R3Ohm_Max";
            this.R3Ohm_Max.Size = new System.Drawing.Size(101, 24);
            this.R3Ohm_Max.TabIndex = 126;
            this.R3Ohm_Max.Text = "0.00";
            this.R3Ohm_Max.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // L1Inductance_Max
            // 
            this.L1Inductance_Max.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.L1Inductance_Max.Location = new System.Drawing.Point(57, 192);
            this.L1Inductance_Max.Name = "L1Inductance_Max";
            this.L1Inductance_Max.Size = new System.Drawing.Size(101, 24);
            this.L1Inductance_Max.TabIndex = 126;
            this.L1Inductance_Max.Text = "0.00";
            this.L1Inductance_Max.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // L2Inductance_Max
            // 
            this.L2Inductance_Max.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.L2Inductance_Max.Location = new System.Drawing.Point(57, 244);
            this.L2Inductance_Max.Name = "L2Inductance_Max";
            this.L2Inductance_Max.Size = new System.Drawing.Size(101, 24);
            this.L2Inductance_Max.TabIndex = 126;
            this.L2Inductance_Max.Text = "0.00";
            this.L2Inductance_Max.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // L3Inductance_Max
            // 
            this.L3Inductance_Max.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.L3Inductance_Max.Location = new System.Drawing.Point(57, 292);
            this.L3Inductance_Max.Name = "L3Inductance_Max";
            this.L3Inductance_Max.Size = new System.Drawing.Size(101, 24);
            this.L3Inductance_Max.TabIndex = 126;
            this.L3Inductance_Max.Text = "0.00";
            this.L3Inductance_Max.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // R1Ohm_Min
            // 
            this.R1Ohm_Min.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.R1Ohm_Min.Location = new System.Drawing.Point(287, 44);
            this.R1Ohm_Min.Name = "R1Ohm_Min";
            this.R1Ohm_Min.Size = new System.Drawing.Size(101, 24);
            this.R1Ohm_Min.TabIndex = 126;
            this.R1Ohm_Min.Text = "0.00";
            this.R1Ohm_Min.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // R2Ohm_Min
            // 
            this.R2Ohm_Min.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.R2Ohm_Min.Location = new System.Drawing.Point(287, 95);
            this.R2Ohm_Min.Name = "R2Ohm_Min";
            this.R2Ohm_Min.Size = new System.Drawing.Size(101, 24);
            this.R2Ohm_Min.TabIndex = 126;
            this.R2Ohm_Min.Text = "0.00";
            this.R2Ohm_Min.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // R3Ohm_Min
            // 
            this.R3Ohm_Min.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.R3Ohm_Min.Location = new System.Drawing.Point(288, 142);
            this.R3Ohm_Min.Name = "R3Ohm_Min";
            this.R3Ohm_Min.Size = new System.Drawing.Size(101, 24);
            this.R3Ohm_Min.TabIndex = 126;
            this.R3Ohm_Min.Text = "0.00";
            this.R3Ohm_Min.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // L1Inductance_Min
            // 
            this.L1Inductance_Min.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.L1Inductance_Min.Location = new System.Drawing.Point(287, 192);
            this.L1Inductance_Min.Name = "L1Inductance_Min";
            this.L1Inductance_Min.Size = new System.Drawing.Size(101, 24);
            this.L1Inductance_Min.TabIndex = 126;
            this.L1Inductance_Min.Text = "0.00";
            this.L1Inductance_Min.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // L2Inductance_Min
            // 
            this.L2Inductance_Min.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.L2Inductance_Min.Location = new System.Drawing.Point(287, 244);
            this.L2Inductance_Min.Name = "L2Inductance_Min";
            this.L2Inductance_Min.Size = new System.Drawing.Size(101, 24);
            this.L2Inductance_Min.TabIndex = 126;
            this.L2Inductance_Min.Text = "0.00";
            this.L2Inductance_Min.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // L3Inductance_Min
            // 
            this.L3Inductance_Min.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.L3Inductance_Min.Location = new System.Drawing.Point(287, 292);
            this.L3Inductance_Min.Name = "L3Inductance_Min";
            this.L3Inductance_Min.Size = new System.Drawing.Size(101, 24);
            this.L3Inductance_Min.TabIndex = 126;
            this.L3Inductance_Min.Text = "0.00";
            this.L3Inductance_Min.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LCRTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LCRTestActive);
            this.Name = "LCRTest";
            this.Size = new System.Drawing.Size(581, 389);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox LCRTestActive;
        private System.Windows.Forms.TextBox L3Inductance_Min;
        private System.Windows.Forms.TextBox L3Inductance_Max;
        private System.Windows.Forms.TextBox L2Inductance_Min;
        private System.Windows.Forms.TextBox L2Inductance_Max;
        private System.Windows.Forms.TextBox L1Inductance_Min;
        private System.Windows.Forms.TextBox L1Inductance_Max;
        private System.Windows.Forms.TextBox R3Ohm_Min;
        private System.Windows.Forms.TextBox R3Ohm_Max;
        private System.Windows.Forms.TextBox R2Ohm_Min;
        private System.Windows.Forms.TextBox R2Ohm_Max;
        private System.Windows.Forms.TextBox R1Ohm_Min;
        private System.Windows.Forms.TextBox R1Ohm_Max;
    }
}

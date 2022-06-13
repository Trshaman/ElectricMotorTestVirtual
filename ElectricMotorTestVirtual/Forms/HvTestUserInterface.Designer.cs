namespace ElectricMotorTestVirtual.Forms
{
    partial class HvTestUserInterface
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
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LeakagemA_Min = new System.Windows.Forms.TextBox();
            this.LeakagemA_Max = new System.Windows.Forms.TextBox();
            this.HVTestActive = new System.Windows.Forms.CheckBox();
            this.IRResistance_Max = new System.Windows.Forms.TextBox();
            this.IRResistance_Min = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "HV Test";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.IRResistance_Min);
            this.groupBox1.Controls.Add(this.IRResistance_Max);
            this.groupBox1.Controls.Add(this.LeakagemA_Min);
            this.groupBox1.Controls.Add(this.LeakagemA_Max);
            this.groupBox1.Location = new System.Drawing.Point(44, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(464, 275);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Test Limit Parametreleri";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(303, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 15);
            this.label1.TabIndex = 125;
            this.label1.Text = "Kaçak Akım Min (mA)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(63, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 15);
            this.label3.TabIndex = 125;
            this.label3.Text = "Kaçak Akım Max (mA)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LeakagemA_Min
            // 
            this.LeakagemA_Min.Location = new System.Drawing.Point(306, 115);
            this.LeakagemA_Min.Name = "LeakagemA_Min";
            this.LeakagemA_Min.Size = new System.Drawing.Size(101, 20);
            this.LeakagemA_Min.TabIndex = 0;
            // 
            // LeakagemA_Max
            // 
            this.LeakagemA_Max.Location = new System.Drawing.Point(66, 115);
            this.LeakagemA_Max.Name = "LeakagemA_Max";
            this.LeakagemA_Max.Size = new System.Drawing.Size(101, 20);
            this.LeakagemA_Max.TabIndex = 0;
            // 
            // HVTestActive
            // 
            this.HVTestActive.AutoSize = true;
            this.HVTestActive.Location = new System.Drawing.Point(44, 32);
            this.HVTestActive.Name = "HVTestActive";
            this.HVTestActive.Size = new System.Drawing.Size(89, 17);
            this.HVTestActive.TabIndex = 3;
            this.HVTestActive.Text = "HV Test Aktif";
            this.HVTestActive.UseVisualStyleBackColor = true;
            // 
            // IRResistance_Max
            // 
            this.IRResistance_Max.Location = new System.Drawing.Point(66, 174);
            this.IRResistance_Max.Name = "IRResistance_Max";
            this.IRResistance_Max.Size = new System.Drawing.Size(101, 20);
            this.IRResistance_Max.TabIndex = 0;
            this.IRResistance_Max.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // IRResistance_Min
            // 
            this.IRResistance_Min.Location = new System.Drawing.Point(306, 174);
            this.IRResistance_Min.Name = "IRResistance_Min";
            this.IRResistance_Min.Size = new System.Drawing.Size(101, 20);
            this.IRResistance_Min.TabIndex = 0;
            this.IRResistance_Min.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(63, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 15);
            this.label4.TabIndex = 125;
            this.label4.Text = "IR Restistance Max (ohm)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(303, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 15);
            this.label5.TabIndex = 125;
            this.label5.Text = "IR Resistance Min (ohm)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // HvTestUserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.HVTestActive);
            this.Controls.Add(this.label2);
            this.Name = "HvTestUserInterface";
            this.Size = new System.Drawing.Size(552, 362);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox LeakagemA_Min;
        private System.Windows.Forms.TextBox LeakagemA_Max;
        private System.Windows.Forms.CheckBox HVTestActive;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox IRResistance_Min;
        private System.Windows.Forms.TextBox IRResistance_Max;
    }
}

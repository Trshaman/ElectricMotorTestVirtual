namespace ElectricMotorTestVirtual.Forms
{
    partial class PerformansTest
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.loadPerform_Min = new System.Windows.Forms.TextBox();
            this.loadPerform_Max = new System.Windows.Forms.TextBox();
            this.UnloadPerform_Min = new System.Windows.Forms.TextBox();
            this.UnloadPerform_Max = new System.Windows.Forms.TextBox();
            this.PerformTestActive = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Performans Test";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.loadPerform_Min);
            this.groupBox1.Controls.Add(this.loadPerform_Max);
            this.groupBox1.Controls.Add(this.UnloadPerform_Min);
            this.groupBox1.Controls.Add(this.UnloadPerform_Max);
            this.groupBox1.Location = new System.Drawing.Point(48, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(485, 275);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Test Limit Parametreleri";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(303, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(169, 15);
            this.label5.TabIndex = 125;
            this.label5.Text = "Yükte Perofrmans Max (Rpm)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(303, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 15);
            this.label2.TabIndex = 125;
            this.label2.Text = "Boşta Perofrmans Min (Rpm)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(63, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 15);
            this.label4.TabIndex = 125;
            this.label4.Text = "Yükte Perofrmans Min (Rpm)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(63, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 15);
            this.label3.TabIndex = 125;
            this.label3.Text = "Boşta Performans Max (Rpm)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // loadPerform_Min
            // 
            this.loadPerform_Min.Location = new System.Drawing.Point(306, 174);
            this.loadPerform_Min.Name = "loadPerform_Min";
            this.loadPerform_Min.Size = new System.Drawing.Size(101, 20);
            this.loadPerform_Min.TabIndex = 0;
            // 
            // loadPerform_Max
            // 
            this.loadPerform_Max.Location = new System.Drawing.Point(66, 174);
            this.loadPerform_Max.Name = "loadPerform_Max";
            this.loadPerform_Max.Size = new System.Drawing.Size(101, 20);
            this.loadPerform_Max.TabIndex = 0;
            // 
            // UnloadPerform_Min
            // 
            this.UnloadPerform_Min.Location = new System.Drawing.Point(306, 115);
            this.UnloadPerform_Min.Name = "UnloadPerform_Min";
            this.UnloadPerform_Min.Size = new System.Drawing.Size(101, 20);
            this.UnloadPerform_Min.TabIndex = 0;
            // 
            // UnloadPerform_Max
            // 
            this.UnloadPerform_Max.Location = new System.Drawing.Point(66, 115);
            this.UnloadPerform_Max.Name = "UnloadPerform_Max";
            this.UnloadPerform_Max.Size = new System.Drawing.Size(101, 20);
            this.UnloadPerform_Max.TabIndex = 0;
            // 
            // PerformTestActive
            // 
            this.PerformTestActive.AutoSize = true;
            this.PerformTestActive.Location = new System.Drawing.Point(48, 34);
            this.PerformTestActive.Name = "PerformTestActive";
            this.PerformTestActive.Size = new System.Drawing.Size(127, 17);
            this.PerformTestActive.TabIndex = 5;
            this.PerformTestActive.Text = "Performans Test Aktif";
            this.PerformTestActive.UseVisualStyleBackColor = true;
            // 
            // PerformansTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.PerformTestActive);
            this.Controls.Add(this.label1);
            this.Name = "PerformansTest";
            this.Size = new System.Drawing.Size(561, 366);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox loadPerform_Min;
        private System.Windows.Forms.TextBox loadPerform_Max;
        private System.Windows.Forms.TextBox UnloadPerform_Min;
        private System.Windows.Forms.TextBox UnloadPerform_Max;
        private System.Windows.Forms.CheckBox PerformTestActive;
    }
}

﻿namespace ElectricMotorTestVirtual.Forms
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
            System.Windows.Forms.TextBox Point1Load;
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Point2Load = new System.Windows.Forms.TextBox();
            this.loadPerform_Min = new System.Windows.Forms.TextBox();
            this.loadPerform_Max = new System.Windows.Forms.TextBox();
            this.UnloadPerform_Min = new System.Windows.Forms.TextBox();
            this.UnloadPerform_Max = new System.Windows.Forms.TextBox();
            this.PerformTestActive = new System.Windows.Forms.CheckBox();
            Point1Load = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Point1Load
            // 
            Point1Load.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Point1Load.Location = new System.Drawing.Point(94, 277);
            Point1Load.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            Point1Load.Name = "Point1Load";
            Point1Load.Size = new System.Drawing.Size(121, 24);
            Point1Load.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Point2Load);
            this.groupBox1.Controls.Add(Point1Load);
            this.groupBox1.Controls.Add(this.loadPerform_Min);
            this.groupBox1.Controls.Add(this.loadPerform_Max);
            this.groupBox1.Controls.Add(this.UnloadPerform_Min);
            this.groupBox1.Controls.Add(this.UnloadPerform_Max);
            this.groupBox1.Location = new System.Drawing.Point(21, 76);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(536, 337);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Test Limit Parametreleri";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(310, 249);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 15);
            this.label6.TabIndex = 125;
            this.label6.Text = "2. Yükleme Nok (Nm)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(310, 155);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
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
            this.label2.Location = new System.Drawing.Point(310, 73);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 15);
            this.label2.TabIndex = 125;
            this.label2.Text = "Boşta Perofrmans Min (Rpm)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(90, 249);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 15);
            this.label1.TabIndex = 125;
            this.label1.Text = "1.Yukleme Nok (Nm)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(90, 155);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
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
            this.label3.Location = new System.Drawing.Point(90, 73);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 15);
            this.label3.TabIndex = 125;
            this.label3.Text = "Boşta Performans Max (Rpm)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Point2Load
            // 
            this.Point2Load.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Point2Load.Location = new System.Drawing.Point(314, 277);
            this.Point2Load.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Point2Load.Name = "Point2Load";
            this.Point2Load.Size = new System.Drawing.Size(121, 24);
            this.Point2Load.TabIndex = 0;
            // 
            // loadPerform_Min
            // 
            this.loadPerform_Min.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadPerform_Min.Location = new System.Drawing.Point(314, 190);
            this.loadPerform_Min.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.loadPerform_Min.Name = "loadPerform_Min";
            this.loadPerform_Min.Size = new System.Drawing.Size(121, 24);
            this.loadPerform_Min.TabIndex = 0;
            // 
            // loadPerform_Max
            // 
            this.loadPerform_Max.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadPerform_Max.Location = new System.Drawing.Point(94, 190);
            this.loadPerform_Max.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.loadPerform_Max.Name = "loadPerform_Max";
            this.loadPerform_Max.Size = new System.Drawing.Size(121, 24);
            this.loadPerform_Max.TabIndex = 0;
            // 
            // UnloadPerform_Min
            // 
            this.UnloadPerform_Min.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UnloadPerform_Min.Location = new System.Drawing.Point(314, 102);
            this.UnloadPerform_Min.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.UnloadPerform_Min.Name = "UnloadPerform_Min";
            this.UnloadPerform_Min.Size = new System.Drawing.Size(121, 24);
            this.UnloadPerform_Min.TabIndex = 0;
            // 
            // UnloadPerform_Max
            // 
            this.UnloadPerform_Max.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UnloadPerform_Max.Location = new System.Drawing.Point(94, 102);
            this.UnloadPerform_Max.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.UnloadPerform_Max.Name = "UnloadPerform_Max";
            this.UnloadPerform_Max.Size = new System.Drawing.Size(121, 24);
            this.UnloadPerform_Max.TabIndex = 0;
            // 
            // PerformTestActive
            // 
            this.PerformTestActive.AutoSize = true;
            this.PerformTestActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PerformTestActive.Location = new System.Drawing.Point(56, 30);
            this.PerformTestActive.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PerformTestActive.Name = "PerformTestActive";
            this.PerformTestActive.Size = new System.Drawing.Size(170, 22);
            this.PerformTestActive.TabIndex = 5;
            this.PerformTestActive.Text = "Performans Test Aktif";
            this.PerformTestActive.UseVisualStyleBackColor = true;
            // 
            // PerformansTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.PerformTestActive);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PerformansTest";
            this.Size = new System.Drawing.Size(590, 447);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Point2Load;
    }
}

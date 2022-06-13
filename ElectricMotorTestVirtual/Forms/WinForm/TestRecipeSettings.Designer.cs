namespace ElectricMotorTestVirtual.Forms.WinForm
{
    partial class TestRecipeSettings
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
            this.HVTest = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.hvTestUserInterface1 = new ElectricMotorTestVirtual.Forms.HvTestUserInterface();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lcrTest1 = new ElectricMotorTestVirtual.Forms.LCRTest();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.performansTest1 = new ElectricMotorTestVirtual.Forms.PerformansTest();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.HVTest.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // HVTest
            // 
            this.HVTest.Controls.Add(this.tabPage1);
            this.HVTest.Controls.Add(this.tabPage2);
            this.HVTest.Controls.Add(this.tabPage3);
            this.HVTest.Location = new System.Drawing.Point(113, 95);
            this.HVTest.Name = "HVTest";
            this.HVTest.SelectedIndex = 0;
            this.HVTest.Size = new System.Drawing.Size(562, 406);
            this.HVTest.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.hvTestUserInterface1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(554, 380);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "HV Test";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // hvTestUserInterface1
            // 
            this.hvTestUserInterface1.Location = new System.Drawing.Point(0, 0);
            this.hvTestUserInterface1.Name = "hvTestUserInterface1";
            this.hvTestUserInterface1.Size = new System.Drawing.Size(552, 362);
            this.hvTestUserInterface1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lcrTest1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(554, 380);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "LCR Test";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lcrTest1
            // 
            this.lcrTest1.Location = new System.Drawing.Point(8, 3);
            this.lcrTest1.Name = "lcrTest1";
            this.lcrTest1.Size = new System.Drawing.Size(543, 374);
            this.lcrTest1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.performansTest1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(554, 380);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Performans Test";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // performansTest1
            // 
            this.performansTest1.Location = new System.Drawing.Point(-4, 8);
            this.performansTest1.Name = "performansTest1";
            this.performansTest1.Size = new System.Drawing.Size(561, 366);
            this.performansTest1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(768, 99);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Test ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(6, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 15);
            this.label1.TabIndex = 127;
            this.label1.Text = "Yorumlar";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(6, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 15);
            this.label3.TabIndex = 126;
            this.label3.Text = "Test İsmi";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(6, 74);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(756, 20);
            this.textBox2.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 35);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(158, 20);
            this.textBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(202, 507);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 29);
            this.button1.TabIndex = 2;
            this.button1.Text = "Kaydet";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(444, 507);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(144, 29);
            this.button2.TabIndex = 2;
            this.button2.Text = "Çıkış";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // TestRecipeSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 548);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.HVTest);
            this.Name = "TestRecipeSettings";
            this.Text = "TestRecipeSettings";
            this.HVTest.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl HVTest;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private HvTestUserInterface hvTestUserInterface1;
        private LCRTest lcrTest1;
        private PerformansTest performansTest1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
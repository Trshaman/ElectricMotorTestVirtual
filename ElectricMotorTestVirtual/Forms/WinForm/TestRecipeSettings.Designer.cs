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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TestDescription = new System.Windows.Forms.TextBox();
            this.TestName = new System.Windows.Forms.TextBox();
            this.Save = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.hvTestUserInterface2 = new ElectricMotorTestVirtual.Forms.HvTestUI();
            this.lcrTest2 = new ElectricMotorTestVirtual.Forms.LCRTestUI();
            this.performansTest2 = new ElectricMotorTestVirtual.Forms.PerformansTestUI();
            this.emK_Test1 = new ElectricMotorTestVirtual.Forms.EMK_Test();
            this.HVTest.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // HVTest
            // 
            this.HVTest.Controls.Add(this.tabPage1);
            this.HVTest.Controls.Add(this.tabPage2);
            this.HVTest.Controls.Add(this.tabPage3);
            this.HVTest.Controls.Add(this.tabPage4);
            this.HVTest.Location = new System.Drawing.Point(102, 160);
            this.HVTest.Name = "HVTest";
            this.HVTest.SelectedIndex = 0;
            this.HVTest.Size = new System.Drawing.Size(673, 491);
            this.HVTest.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.hvTestUserInterface2);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(665, 465);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "HV Test";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lcrTest2);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(665, 465);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "LCR Test";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.performansTest2);
            this.tabPage3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(665, 465);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Performans Test";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.emK_Test1);
            this.tabPage4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(665, 465);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "EMK Test";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TestDescription);
            this.groupBox1.Controls.Add(this.TestName);
            this.groupBox1.Location = new System.Drawing.Point(59, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(798, 142);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Test ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(6, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 18);
            this.label1.TabIndex = 127;
            this.label1.Text = "Yorumlar";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(6, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 18);
            this.label3.TabIndex = 126;
            this.label3.Text = "Test İsmi";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TestDescription
            // 
            this.TestDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TestDescription.Location = new System.Drawing.Point(6, 94);
            this.TestDescription.Name = "TestDescription";
            this.TestDescription.Size = new System.Drawing.Size(756, 26);
            this.TestDescription.TabIndex = 0;
            // 
            // TestName
            // 
            this.TestName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TestName.Location = new System.Drawing.Point(6, 35);
            this.TestName.Name = "TestName";
            this.TestName.Size = new System.Drawing.Size(158, 26);
            this.TestName.TabIndex = 0;

            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(169, 653);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(157, 45);
            this.Save.TabIndex = 2;
            this.Save.Text = "Kaydet";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(563, 653);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(158, 45);
            this.Exit.TabIndex = 2;
            this.Exit.Text = "Çıkış";
            this.Exit.UseVisualStyleBackColor = true;
            // 
            // hvTestUserInterface2
            // 
            this.hvTestUserInterface2.Location = new System.Drawing.Point(-27, -12);
            this.hvTestUserInterface2.Name = "hvTestUserInterface2";
            this.hvTestUserInterface2.Size = new System.Drawing.Size(692, 447);
            this.hvTestUserInterface2.TabIndex = 0;
            this.hvTestUserInterface2.Load += new System.EventHandler(this.hvTestUserInterface2_Load);
            // 
            // lcrTest2
            // 
            this.lcrTest2.Location = new System.Drawing.Point(-29, -13);
            this.lcrTest2.Name = "lcrTest2";
            this.lcrTest2.Size = new System.Drawing.Size(688, 472);
            this.lcrTest2.TabIndex = 0;
            this.lcrTest2.Load += new System.EventHandler(this.lcrTest2_Load);
            // 
            // performansTest2
            // 
            this.performansTest2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.performansTest2.Location = new System.Drawing.Point(52, 0);
            this.performansTest2.Margin = new System.Windows.Forms.Padding(4);
            this.performansTest2.Name = "performansTest2";
            this.performansTest2.Size = new System.Drawing.Size(561, 430);
            this.performansTest2.TabIndex = 0;
            // 
            // emK_Test1
            // 
            this.emK_Test1.Location = new System.Drawing.Point(7, 0);
            this.emK_Test1.Margin = new System.Windows.Forms.Padding(4);
            this.emK_Test1.Name = "emK_Test1";
            this.emK_Test1.Size = new System.Drawing.Size(624, 433);
            this.emK_Test1.TabIndex = 0;
            // 
            // TestRecipeSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 708);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.HVTest);
            this.Name = "TestRecipeSettings";
            this.Text = "TestRecipeSettings";
            this.HVTest.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
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
        private System.Windows.Forms.TextBox TestDescription;
        private System.Windows.Forms.TextBox TestName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private HvTestUI hvTestUserInterface2;
        private LCRTestUI lcrTest2;
        private PerformansTestUI performansTest2;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.TabPage tabPage4;
        private EMK_Test emK_Test1;
    }
}
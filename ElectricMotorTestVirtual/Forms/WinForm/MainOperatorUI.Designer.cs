namespace ElectricMotorTestVirtual.Forms.WinForm
{
    partial class MainOperatorUI
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
            this.TestResultTable = new System.Windows.Forms.DataGridView();
            this.ClmnTestParameter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmnUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmnUpperLimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmnResultValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmnLowLimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmnResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnClose = new System.Windows.Forms.Button();
            this.TxtbxSerialNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnStart = new System.Windows.Forms.Button();
            this.TxbxSelectedTest = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();;
            ((System.ComponentModel.ISupportInitialize)(this.TestResultTable)).BeginInit();
            this.SuspendLayout();
            // 
            // TestResultTable
            // 
            this.TestResultTable.AllowUserToAddRows = false;
            this.TestResultTable.AllowUserToDeleteRows = false;
            this.TestResultTable.AllowUserToOrderColumns = true;
            this.TestResultTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TestResultTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClmnTestParameter,
            this.ClmnUnit,
            this.ClmnUpperLimit,
            this.ClmnResultValue,
            this.ClmnLowLimit,
            this.ClmnResult});
            this.TestResultTable.Location = new System.Drawing.Point(469, 60);
            this.TestResultTable.Name = "TestResultTable";
            this.TestResultTable.ReadOnly = true;
            this.TestResultTable.Size = new System.Drawing.Size(591, 481);
            this.TestResultTable.TabIndex = 0;
            // 
            // ClmnTestParameter
            // 
            this.ClmnTestParameter.HeaderText = "Test Parametreleri";
            this.ClmnTestParameter.Name = "ClmnTestParameter";
            this.ClmnTestParameter.ReadOnly = true;
            // 
            // ClmnUnit
            // 
            this.ClmnUnit.HeaderText = "Birim";
            this.ClmnUnit.Name = "ClmnUnit";
            this.ClmnUnit.ReadOnly = true;
            this.ClmnUnit.Width = 50;
            // 
            // ClmnUpperLimit
            // 
            this.ClmnUpperLimit.HeaderText = "Üst Limit";
            this.ClmnUpperLimit.Name = "ClmnUpperLimit";
            this.ClmnUpperLimit.ReadOnly = true;
            // 
            // ClmnResultValue
            // 
            this.ClmnResultValue.HeaderText = "Ölçülen Değer";
            this.ClmnResultValue.Name = "ClmnResultValue";
            this.ClmnResultValue.ReadOnly = true;
            // 
            // ClmnLowLimit
            // 
            this.ClmnLowLimit.HeaderText = "Alt Limit";
            this.ClmnLowLimit.Name = "ClmnLowLimit";
            this.ClmnLowLimit.ReadOnly = true;
            // 
            // ClmnResult
            // 
            this.ClmnResult.HeaderText = "Sonuç";
            this.ClmnResult.Name = "ClmnResult";
            this.ClmnResult.ReadOnly = true;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(867, 547);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(263, 26);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(692, 543);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Test Durumu:";
            // 
            // BtnClose
            // 
            this.BtnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClose.Location = new System.Drawing.Point(905, 590);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(225, 34);
            this.BtnClose.TabIndex = 3;
            this.BtnClose.Text = "Çıkış";
            this.BtnClose.UseVisualStyleBackColor = true;
            // 
            // TxtbxSerialNumber
            // 
            this.TxtbxSerialNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtbxSerialNumber.Location = new System.Drawing.Point(118, 21);
            this.TxtbxSerialNumber.Name = "TxtbxSerialNumber";
            this.TxtbxSerialNumber.Size = new System.Drawing.Size(150, 26);
            this.TxtbxSerialNumber.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(823, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Seçili Reçete:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // BtnStart
            // 
            this.BtnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnStart.Location = new System.Drawing.Point(74, 588);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(225, 34);
            this.BtnStart.TabIndex = 3;
            this.BtnStart.Text = "Start Test";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // TxbxSelectedTest
            // 
            this.TxbxSelectedTest.Location = new System.Drawing.Point(927, 21);
            this.TxbxSelectedTest.Name = "TxbxSelectedTest";
            this.TxbxSelectedTest.ReadOnly = true;
            this.TxbxSelectedTest.Size = new System.Drawing.Size(133, 20);
            this.TxbxSelectedTest.TabIndex = 131;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(31, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Motor S/N:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MainOperatorUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 636);
            this.Controls.Add(this.TxbxSelectedTest);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtbxSerialNumber);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.TestResultTable);
            this.Name = "MainOperatorUI";
            this.Text = "MainOperatorUI";
            ((System.ComponentModel.ISupportInitialize)(this.TestResultTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView TestResultTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmnTestParameter;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmnUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmnUpperLimit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmnResultValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmnLowLimit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmnResult;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.TextBox TxtbxSerialNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.TextBox TxbxSelectedTest;
        private System.Windows.Forms.Label label3;
    }
}
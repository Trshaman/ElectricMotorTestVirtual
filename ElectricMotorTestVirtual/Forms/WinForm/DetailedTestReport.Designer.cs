namespace ElectricMotorTestVirtual.Forms.WinForm
{
    partial class DetailedTestReport
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
            this.TestResultTable.Location = new System.Drawing.Point(2, 2);
            this.TestResultTable.Name = "TestResultTable";
            this.TestResultTable.ReadOnly = true;
            this.TestResultTable.Size = new System.Drawing.Size(591, 481);
            this.TestResultTable.TabIndex = 1;
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
            // DetailedTestReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 487);
            this.Controls.Add(this.TestResultTable);
            this.Name = "DetailedTestReport";
            this.Text = "DetailedTestReport";
            ((System.ComponentModel.ISupportInitialize)(this.TestResultTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView TestResultTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmnTestParameter;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmnUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmnUpperLimit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmnResultValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmnLowLimit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmnResult;
    }
}
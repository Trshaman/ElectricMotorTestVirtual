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
            this.TestSerialNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxbxTestDate = new System.Windows.Forms.TextBox();
            this.ExportPdf = new System.Windows.Forms.Button();
            this.TestNOK = new UserInterface.LedDisplay();
            this.TestOK = new UserInterface.LedDisplay();
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
            this.TestResultTable.Location = new System.Drawing.Point(2, 53);
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
            // TestSerialNumber
            // 
            this.TestSerialNumber.Location = new System.Drawing.Point(12, 27);
            this.TestSerialNumber.Name = "TestSerialNumber";
            this.TestSerialNumber.Size = new System.Drawing.Size(253, 20);
            this.TestSerialNumber.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Serial No:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(308, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Test Tarihi:";
            // 
            // TxbxTestDate
            // 
            this.TxbxTestDate.Location = new System.Drawing.Point(311, 27);
            this.TxbxTestDate.Name = "TxbxTestDate";
            this.TxbxTestDate.Size = new System.Drawing.Size(150, 20);
            this.TxbxTestDate.TabIndex = 7;
            // 
            // ExportPdf
            // 
            this.ExportPdf.Location = new System.Drawing.Point(488, 15);
            this.ExportPdf.Name = "ExportPdf";
            this.ExportPdf.Size = new System.Drawing.Size(105, 32);
            this.ExportPdf.TabIndex = 9;
            this.ExportPdf.Text = "Excel Oluştur";
            this.ExportPdf.UseVisualStyleBackColor = true;
            this.ExportPdf.Click += new System.EventHandler(this.ExportPdf_Click);
            // 
            // TestNOK
            // 
            this.TestNOK.BackGradientColor = System.Drawing.Color.White;
            this.TestNOK.BackGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.TestNOK.Blink = UserInterface.LedDisplay.BlinkState.Off;
            this.TestNOK.BlinkPeriod = 1000;
            this.TestNOK.ChannelList = null;
            this.TestNOK.ContainerFormName = null;
            this.TestNOK.DesignModeActive = false;
            this.TestNOK.Header = "NOK";
            this.TestNOK.HeaderBackColor = System.Drawing.Color.WhiteSmoke;
            this.TestNOK.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TestNOK.HeaderForeColor = System.Drawing.Color.Black;
            this.TestNOK.HeaderPosition = UserInterface.HeaderPosition.Top;
            this.TestNOK.HeaderVisible = true;
            this.TestNOK.LedStyle = UserInterface.LedDisplay.LedDisplayStyle.Sphere;
            this.TestNOK.Location = new System.Drawing.Point(598, 116);
            this.TestNOK.Margin = new System.Windows.Forms.Padding(2);
            this.TestNOK.Name = "TestNOK";
            this.TestNOK.OffColor = System.Drawing.Color.Gainsboro;
            this.TestNOK.OnColor = System.Drawing.Color.Red;
            this.TestNOK.PropertyEditMode = false;
            this.TestNOK.Reflection = UserInterface.LedDisplay.ReflectionState.On;
            this.TestNOK.Selected = false;
            this.TestNOK.Size = new System.Drawing.Size(88, 106);
            this.TestNOK.TabIndex = 5;
            this.TestNOK.Value = false;
            // 
            // TestOK
            // 
            this.TestOK.BackGradientColor = System.Drawing.Color.White;
            this.TestOK.BackGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.TestOK.Blink = UserInterface.LedDisplay.BlinkState.Off;
            this.TestOK.BlinkPeriod = 1000;
            this.TestOK.ChannelList = null;
            this.TestOK.ContainerFormName = null;
            this.TestOK.DesignModeActive = false;
            this.TestOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TestOK.Header = "OK";
            this.TestOK.HeaderBackColor = System.Drawing.Color.WhiteSmoke;
            this.TestOK.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TestOK.HeaderForeColor = System.Drawing.Color.Black;
            this.TestOK.HeaderPosition = UserInterface.HeaderPosition.Top;
            this.TestOK.HeaderVisible = true;
            this.TestOK.LedStyle = UserInterface.LedDisplay.LedDisplayStyle.Sphere;
            this.TestOK.Location = new System.Drawing.Point(598, 332);
            this.TestOK.Margin = new System.Windows.Forms.Padding(2);
            this.TestOK.Name = "TestOK";
            this.TestOK.OffColor = System.Drawing.Color.Gainsboro;
            this.TestOK.OnColor = System.Drawing.Color.GreenYellow;
            this.TestOK.PropertyEditMode = false;
            this.TestOK.Reflection = UserInterface.LedDisplay.ReflectionState.On;
            this.TestOK.Selected = false;
            this.TestOK.Size = new System.Drawing.Size(88, 110);
            this.TestOK.TabIndex = 6;
            this.TestOK.Value = false;
            // 
            // DetailedTestReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 536);
            this.Controls.Add(this.ExportPdf);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxbxTestDate);
            this.Controls.Add(this.TestSerialNumber);
            this.Controls.Add(this.TestNOK);
            this.Controls.Add(this.TestOK);
            this.Controls.Add(this.TestResultTable);
            this.Name = "DetailedTestReport";
            this.Text = "DetailedTestReport";
            ((System.ComponentModel.ISupportInitialize)(this.TestResultTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmnTestParameter;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmnUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmnUpperLimit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmnResultValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmnLowLimit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmnResult;
        public System.Windows.Forms.DataGridView TestResultTable;
        public System.Windows.Forms.TextBox TestSerialNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public UserInterface.LedDisplay TestNOK;
        public UserInterface.LedDisplay TestOK;
        public System.Windows.Forms.TextBox TxbxTestDate;
        private System.Windows.Forms.Button ExportPdf;
    }
}
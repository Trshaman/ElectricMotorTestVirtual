namespace ElectricMotorTestVirtual.Forms.WinForm
{
    partial class TestResultDatabase
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.BtnClose = new System.Windows.Forms.Button();
            this.StartDateTime = new System.Windows.Forms.DateTimePicker();
            this.StopDateTime = new System.Windows.Forms.DateTimePicker();
            this.listBxMetod = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtbxSerialNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnGetData = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(62, 68);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(940, 418);
            this.dataGridView1.TabIndex = 0;
            // 
            // BtnClose
            // 
            this.BtnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClose.Location = new System.Drawing.Point(662, 511);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(225, 34);
            this.BtnClose.TabIndex = 4;
            this.BtnClose.Text = "Çıkış";
            this.BtnClose.UseVisualStyleBackColor = true;
            // 
            // StartDateTime
            // 
            this.StartDateTime.Location = new System.Drawing.Point(98, 25);
            this.StartDateTime.Name = "StartDateTime";
            this.StartDateTime.Size = new System.Drawing.Size(158, 20);
            this.StartDateTime.TabIndex = 5;
            // 
            // StopDateTime
            // 
            this.StopDateTime.Location = new System.Drawing.Point(301, 25);
            this.StopDateTime.Name = "StopDateTime";
            this.StopDateTime.Size = new System.Drawing.Size(158, 20);
            this.StopDateTime.TabIndex = 6;
            // 
            // listBxMetod
            // 
            this.listBxMetod.FormattingEnabled = true;
            this.listBxMetod.Items.AddRange(new object[] {
            "Tarihe Göre",
            "Seri Numarasına Göre",
            "Teste Göre"});
            this.listBxMetod.Location = new System.Drawing.Point(509, 25);
            this.listBxMetod.Name = "listBxMetod";
            this.listBxMetod.Size = new System.Drawing.Size(113, 17);
            this.listBxMetod.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(151, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Başlangıç";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(360, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Bitiş";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(518, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Arama Yöntemi";
            // 
            // TxtbxSerialNumber
            // 
            this.TxtbxSerialNumber.Location = new System.Drawing.Point(662, 25);
            this.TxtbxSerialNumber.Name = "TxtbxSerialNumber";
            this.TxtbxSerialNumber.Size = new System.Drawing.Size(133, 20);
            this.TxtbxSerialNumber.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(691, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Seri Numarası:";
            // 
            // BtnGetData
            // 
            this.BtnGetData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGetData.Location = new System.Drawing.Point(62, 511);
            this.BtnGetData.Name = "BtnGetData";
            this.BtnGetData.Size = new System.Drawing.Size(225, 34);
            this.BtnGetData.TabIndex = 13;
            this.BtnGetData.Text = "Listele";
            this.BtnGetData.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(346, 492);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(193, 20);
            this.textBox1.TabIndex = 14;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(346, 520);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(193, 20);
            this.textBox2.TabIndex = 14;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(346, 546);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(193, 20);
            this.textBox3.TabIndex = 14;
            // 
            // TestResultDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 600);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.BtnGetData);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtbxSerialNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBxMetod);
            this.Controls.Add(this.StopDateTime);
            this.Controls.Add(this.StartDateTime);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.dataGridView1);
            this.Name = "TestResultDatabase";
            this.Text = "TestResultDatabasecs";
            this.Load += new System.EventHandler(this.TestResultDatabase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.DateTimePicker StartDateTime;
        private System.Windows.Forms.DateTimePicker StopDateTime;
        private System.Windows.Forms.ListBox listBxMetod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtbxSerialNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnGetData;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
    }
}
namespace ElectricMotorTestVirtual.Forms.WinForm
{
    partial class RecipeSelectionPage
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
            this.TestList = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnAdjustRecipe = new System.Windows.Forms.Button();
            this.BtnAddRecipe = new System.Windows.Forms.Button();
            this.BtnCopyRecipe = new System.Windows.Forms.Button();
            this.BtnClose = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnSelectTest = new System.Windows.Forms.Button();
            this.TxbxSelectedTest = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TestList
            // 
            this.TestList.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TestList.FormattingEnabled = true;
            this.TestList.Location = new System.Drawing.Point(248, 72);
            this.TestList.Name = "TestList";
            this.TestList.Size = new System.Drawing.Size(204, 32);
            this.TestList.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(118, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 24);
            this.label3.TabIndex = 126;
            this.label3.Text = "Kayıtlı Testler:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BtnAdjustRecipe
            // 
            this.BtnAdjustRecipe.Location = new System.Drawing.Point(82, 158);
            this.BtnAdjustRecipe.Name = "BtnAdjustRecipe";
            this.BtnAdjustRecipe.Size = new System.Drawing.Size(116, 32);
            this.BtnAdjustRecipe.TabIndex = 127;
            this.BtnAdjustRecipe.Text = "Düzenle";
            this.BtnAdjustRecipe.UseVisualStyleBackColor = true;
            this.BtnAdjustRecipe.Click += new System.EventHandler(this.AdjustRecipe_Click);
            // 
            // BtnAddRecipe
            // 
            this.BtnAddRecipe.Location = new System.Drawing.Point(208, 158);
            this.BtnAddRecipe.Name = "BtnAddRecipe";
            this.BtnAddRecipe.Size = new System.Drawing.Size(116, 32);
            this.BtnAddRecipe.TabIndex = 127;
            this.BtnAddRecipe.Text = "Ekle";
            this.BtnAddRecipe.UseVisualStyleBackColor = true;
            this.BtnAddRecipe.Click += new System.EventHandler(this.AddRecipe_Click);
            // 
            // BtnCopyRecipe
            // 
            this.BtnCopyRecipe.Location = new System.Drawing.Point(339, 158);
            this.BtnCopyRecipe.Name = "BtnCopyRecipe";
            this.BtnCopyRecipe.Size = new System.Drawing.Size(116, 32);
            this.BtnCopyRecipe.TabIndex = 127;
            this.BtnCopyRecipe.Text = "Kopyala";
            this.BtnCopyRecipe.UseVisualStyleBackColor = true;
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(611, 158);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(116, 32);
            this.BtnClose.TabIndex = 128;
            this.BtnClose.Text = "Çıkış";
            this.BtnClose.UseVisualStyleBackColor = true;
            // 
            // BtnDelete
            // 
            this.BtnDelete.Location = new System.Drawing.Point(476, 158);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(116, 32);
            this.BtnDelete.TabIndex = 127;
            this.BtnDelete.Text = "Sil";
            this.BtnDelete.UseVisualStyleBackColor = true;
            // 
            // BtnSelectTest
            // 
            this.BtnSelectTest.Location = new System.Drawing.Point(476, 73);
            this.BtnSelectTest.Name = "BtnSelectTest";
            this.BtnSelectTest.Size = new System.Drawing.Size(116, 32);
            this.BtnSelectTest.TabIndex = 129;
            this.BtnSelectTest.Text = "Seç";
            this.BtnSelectTest.UseVisualStyleBackColor = true;
            this.BtnSelectTest.Click += new System.EventHandler(this.BtnSelectTest_Click);
            // 
            // TxbxSelectedTest
            // 
            this.TxbxSelectedTest.Location = new System.Drawing.Point(352, 32);
            this.TxbxSelectedTest.Name = "TxbxSelectedTest";
            this.TxbxSelectedTest.ReadOnly = true;
            this.TxbxSelectedTest.Size = new System.Drawing.Size(97, 20);
            this.TxbxSelectedTest.TabIndex = 130;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(288, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 131;
            this.label1.Text = "Seçili Test:";
            // 
            // RecipeSelectionPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 202);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxbxSelectedTest);
            this.Controls.Add(this.BtnSelectTest);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.BtnCopyRecipe);
            this.Controls.Add(this.BtnAddRecipe);
            this.Controls.Add(this.BtnAdjustRecipe);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TestList);
            this.Name = "RecipeSelectionPage";
            this.Text = "RecipeSelectionPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox TestList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnAdjustRecipe;
        private System.Windows.Forms.Button BtnAddRecipe;
        private System.Windows.Forms.Button BtnCopyRecipe;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnSelectTest;
        private System.Windows.Forms.TextBox TxbxSelectedTest;
        private System.Windows.Forms.Label label1;
    }
}
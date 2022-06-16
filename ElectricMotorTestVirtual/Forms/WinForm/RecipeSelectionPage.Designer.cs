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
            this.SuspendLayout();
            // 
            // TestList
            // 
            this.TestList.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TestList.FormattingEnabled = true;
            this.TestList.Location = new System.Drawing.Point(207, 34);
            this.TestList.Name = "TestList";
            this.TestList.Size = new System.Drawing.Size(384, 32);
            this.TestList.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(77, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 24);
            this.label3.TabIndex = 126;
            this.label3.Text = "Kayıtlı Testler:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BtnAdjustRecipe
            // 
            this.BtnAdjustRecipe.Location = new System.Drawing.Point(66, 92);
            this.BtnAdjustRecipe.Name = "BtnAdjustRecipe";
            this.BtnAdjustRecipe.Size = new System.Drawing.Size(156, 32);
            this.BtnAdjustRecipe.TabIndex = 127;
            this.BtnAdjustRecipe.Text = "Düzenle";
            this.BtnAdjustRecipe.UseVisualStyleBackColor = true;
            this.BtnAdjustRecipe.Click += new System.EventHandler(this.AdjustRecipe_Click);
            // 
            // BtnAddRecipe
            // 
            this.BtnAddRecipe.Location = new System.Drawing.Point(228, 92);
            this.BtnAddRecipe.Name = "BtnAddRecipe";
            this.BtnAddRecipe.Size = new System.Drawing.Size(156, 32);
            this.BtnAddRecipe.TabIndex = 127;
            this.BtnAddRecipe.Text = "Ekle";
            this.BtnAddRecipe.UseVisualStyleBackColor = true;
            this.BtnAddRecipe.Click += new System.EventHandler(this.AddRecipe_Click);
            // 
            // BtnCopyRecipe
            // 
            this.BtnCopyRecipe.Location = new System.Drawing.Point(390, 92);
            this.BtnCopyRecipe.Name = "BtnCopyRecipe";
            this.BtnCopyRecipe.Size = new System.Drawing.Size(156, 32);
            this.BtnCopyRecipe.TabIndex = 127;
            this.BtnCopyRecipe.Text = "Kopyala";
            this.BtnCopyRecipe.UseVisualStyleBackColor = true;
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(552, 92);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(156, 32);
            this.BtnClose.TabIndex = 128;
            this.BtnClose.Text = "Çıkış";
            this.BtnClose.UseVisualStyleBackColor = true;
            // 
            // RecipeSelectionPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 136);
            this.Controls.Add(this.BtnClose);
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
    }
}
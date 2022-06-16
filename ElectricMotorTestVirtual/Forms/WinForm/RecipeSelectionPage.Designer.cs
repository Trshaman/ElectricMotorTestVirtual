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
            this.AdjustRecipe = new System.Windows.Forms.Button();
            this.AddRecipe = new System.Windows.Forms.Button();
            this.CopyRecipe = new System.Windows.Forms.Button();
            this.CloseSettings = new System.Windows.Forms.Button();
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
            // AdjustRecipe
            // 
            this.AdjustRecipe.Location = new System.Drawing.Point(66, 92);
            this.AdjustRecipe.Name = "AdjustRecipe";
            this.AdjustRecipe.Size = new System.Drawing.Size(156, 32);
            this.AdjustRecipe.TabIndex = 127;
            this.AdjustRecipe.Text = "Düzenle";
            this.AdjustRecipe.UseVisualStyleBackColor = true;
            this.AdjustRecipe.Click += new System.EventHandler(this.AdjustRecipe_Click);
            // 
            // AddRecipe
            // 
            this.AddRecipe.Location = new System.Drawing.Point(228, 92);
            this.AddRecipe.Name = "AddRecipe";
            this.AddRecipe.Size = new System.Drawing.Size(156, 32);
            this.AddRecipe.TabIndex = 127;
            this.AddRecipe.Text = "Ekle";
            this.AddRecipe.UseVisualStyleBackColor = true;
            this.AddRecipe.Click += new System.EventHandler(this.AddRecipe_Click);
            // 
            // CopyRecipe
            // 
            this.CopyRecipe.Location = new System.Drawing.Point(390, 92);
            this.CopyRecipe.Name = "CopyRecipe";
            this.CopyRecipe.Size = new System.Drawing.Size(156, 32);
            this.CopyRecipe.TabIndex = 127;
            this.CopyRecipe.Text = "Kopyala";
            this.CopyRecipe.UseVisualStyleBackColor = true;
            // 
            // CloseSettings
            // 
            this.CloseSettings.Location = new System.Drawing.Point(552, 92);
            this.CloseSettings.Name = "CloseSettings";
            this.CloseSettings.Size = new System.Drawing.Size(156, 32);
            this.CloseSettings.TabIndex = 128;
            this.CloseSettings.Text = "Çıkış";
            this.CloseSettings.UseVisualStyleBackColor = true;
            // 
            // RecipeSelectionPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 136);
            this.Controls.Add(this.CloseSettings);
            this.Controls.Add(this.CopyRecipe);
            this.Controls.Add(this.AddRecipe);
            this.Controls.Add(this.AdjustRecipe);
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
        private System.Windows.Forms.Button AdjustRecipe;
        private System.Windows.Forms.Button AddRecipe;
        private System.Windows.Forms.Button CopyRecipe;
        private System.Windows.Forms.Button CloseSettings;
    }
}
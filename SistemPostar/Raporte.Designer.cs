namespace SistemPostar
{
    partial class Raporte
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
            this.shperdaresButton = new System.Windows.Forms.Button();
            this.transportuesButton = new System.Windows.Forms.Button();
            this.sportelistButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // shperdaresButton
            // 
            this.shperdaresButton.BackColor = System.Drawing.Color.Navy;
            this.shperdaresButton.ForeColor = System.Drawing.Color.Gold;
            this.shperdaresButton.Location = new System.Drawing.Point(423, 74);
            this.shperdaresButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.shperdaresButton.Name = "shperdaresButton";
            this.shperdaresButton.Size = new System.Drawing.Size(152, 120);
            this.shperdaresButton.TabIndex = 0;
            this.shperdaresButton.Text = "Shperndares";
            this.shperdaresButton.UseVisualStyleBackColor = false;
            this.shperdaresButton.Click += new System.EventHandler(this.shperdaresButton_Click);
            // 
            // transportuesButton
            // 
            this.transportuesButton.BackColor = System.Drawing.Color.Navy;
            this.transportuesButton.ForeColor = System.Drawing.Color.Gold;
            this.transportuesButton.Location = new System.Drawing.Point(423, 241);
            this.transportuesButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.transportuesButton.Name = "transportuesButton";
            this.transportuesButton.Size = new System.Drawing.Size(152, 120);
            this.transportuesButton.TabIndex = 1;
            this.transportuesButton.Text = "Transportues";
            this.transportuesButton.UseVisualStyleBackColor = false;
            this.transportuesButton.Click += new System.EventHandler(this.transportuesButton_Click);
            // 
            // sportelistButton
            // 
            this.sportelistButton.BackColor = System.Drawing.Color.Navy;
            this.sportelistButton.ForeColor = System.Drawing.Color.Gold;
            this.sportelistButton.Location = new System.Drawing.Point(423, 398);
            this.sportelistButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sportelistButton.Name = "sportelistButton";
            this.sportelistButton.Size = new System.Drawing.Size(152, 120);
            this.sportelistButton.TabIndex = 2;
            this.sportelistButton.Text = "Sportelist";
            this.sportelistButton.UseVisualStyleBackColor = false;
            this.sportelistButton.Click += new System.EventHandler(this.sportelistButton_Click);
            // 
            // Raporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.Controls.Add(this.sportelistButton);
            this.Controls.Add(this.transportuesButton);
            this.Controls.Add(this.shperdaresButton);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Raporte";
            this.Size = new System.Drawing.Size(1241, 865);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button shperdaresButton;
        private System.Windows.Forms.Button transportuesButton;
        private System.Windows.Forms.Button sportelistButton;
    }
}

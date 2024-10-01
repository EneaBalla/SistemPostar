namespace SistemPostar
{
    partial class Porosi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Porosi));
            this.addPorosiLabel = new System.Windows.Forms.Label();
            this.porosiListLabel = new System.Windows.Forms.Label();
            this.addPorosiButton = new System.Windows.Forms.Button();
            this.porosiListButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addPorosiLabel
            // 
            this.addPorosiLabel.AutoSize = true;
            this.addPorosiLabel.ForeColor = System.Drawing.Color.Gold;
            this.addPorosiLabel.Location = new System.Drawing.Point(660, 446);
            this.addPorosiLabel.Name = "addPorosiLabel";
            this.addPorosiLabel.Size = new System.Drawing.Size(86, 20);
            this.addPorosiLabel.TabIndex = 8;
            this.addPorosiLabel.Text = "Add Porosi";
            // 
            // porosiListLabel
            // 
            this.porosiListLabel.AutoSize = true;
            this.porosiListLabel.ForeColor = System.Drawing.Color.Gold;
            this.porosiListLabel.Location = new System.Drawing.Point(191, 446);
            this.porosiListLabel.Name = "porosiListLabel";
            this.porosiListLabel.Size = new System.Drawing.Size(82, 20);
            this.porosiListLabel.TabIndex = 7;
            this.porosiListLabel.Text = "Porosi List";
            // 
            // addPorosiButton
            // 
            this.addPorosiButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("addPorosiButton.BackgroundImage")));
            this.addPorosiButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addPorosiButton.Location = new System.Drawing.Point(562, 184);
            this.addPorosiButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addPorosiButton.Name = "addPorosiButton";
            this.addPorosiButton.Size = new System.Drawing.Size(256, 249);
            this.addPorosiButton.TabIndex = 6;
            this.addPorosiButton.UseVisualStyleBackColor = true;
            this.addPorosiButton.Click += new System.EventHandler(this.addPorosiButton_Click);
            // 
            // porosiListButton
            // 
            this.porosiListButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("porosiListButton.BackgroundImage")));
            this.porosiListButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.porosiListButton.Location = new System.Drawing.Point(92, 184);
            this.porosiListButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.porosiListButton.Name = "porosiListButton";
            this.porosiListButton.Size = new System.Drawing.Size(256, 249);
            this.porosiListButton.TabIndex = 5;
            this.porosiListButton.UseVisualStyleBackColor = true;
            this.porosiListButton.Click += new System.EventHandler(this.porosiListButton_Click);
            // 
            // Porosi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.Controls.Add(this.addPorosiLabel);
            this.Controls.Add(this.porosiListLabel);
            this.Controls.Add(this.addPorosiButton);
            this.Controls.Add(this.porosiListButton);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Porosi";
            this.Size = new System.Drawing.Size(1241, 821);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label addPorosiLabel;
        private System.Windows.Forms.Label porosiListLabel;
        private System.Windows.Forms.Button addPorosiButton;
        private System.Windows.Forms.Button porosiListButton;
    }
}

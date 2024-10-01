namespace SistemPostar
{
    partial class Pako
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pako));
            this.addPorosiLabel = new System.Windows.Forms.Label();
            this.porosiListLabel = new System.Windows.Forms.Label();
            this.addPakoButton = new System.Windows.Forms.Button();
            this.pakoListButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addPorosiLabel
            // 
            this.addPorosiLabel.AutoSize = true;
            this.addPorosiLabel.Location = new System.Drawing.Point(726, 496);
            this.addPorosiLabel.Name = "addPorosiLabel";
            this.addPorosiLabel.Size = new System.Drawing.Size(77, 20);
            this.addPorosiLabel.TabIndex = 12;
            this.addPorosiLabel.Text = "Add pako";
            // 
            // porosiListLabel
            // 
            this.porosiListLabel.AutoSize = true;
            this.porosiListLabel.Location = new System.Drawing.Point(245, 496);
            this.porosiListLabel.Name = "porosiListLabel";
            this.porosiListLabel.Size = new System.Drawing.Size(107, 20);
            this.porosiListLabel.TabIndex = 11;
            this.porosiListLabel.Text = "Manage Pako";
            // 
            // addPakoButton
            // 
            this.addPakoButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("addPakoButton.BackgroundImage")));
            this.addPakoButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addPakoButton.Location = new System.Drawing.Point(637, 234);
            this.addPakoButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addPakoButton.Name = "addPakoButton";
            this.addPakoButton.Size = new System.Drawing.Size(256, 249);
            this.addPakoButton.TabIndex = 10;
            this.addPakoButton.UseVisualStyleBackColor = true;
            this.addPakoButton.Click += new System.EventHandler(this.addPakoButton_Click);
            // 
            // pakoListButton
            // 
            this.pakoListButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pakoListButton.BackgroundImage")));
            this.pakoListButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pakoListButton.Location = new System.Drawing.Point(166, 234);
            this.pakoListButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pakoListButton.Name = "pakoListButton";
            this.pakoListButton.Size = new System.Drawing.Size(256, 249);
            this.pakoListButton.TabIndex = 9;
            this.pakoListButton.UseVisualStyleBackColor = true;
            this.pakoListButton.Click += new System.EventHandler(this.pakoListButton_Click);
            // 
            // Pako
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.Controls.Add(this.addPorosiLabel);
            this.Controls.Add(this.porosiListLabel);
            this.Controls.Add(this.addPakoButton);
            this.Controls.Add(this.pakoListButton);
            this.ForeColor = System.Drawing.Color.Gold;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Pako";
            this.Size = new System.Drawing.Size(1241, 865);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label addPorosiLabel;
        private System.Windows.Forms.Label porosiListLabel;
        private System.Windows.Forms.Button addPakoButton;
        private System.Windows.Forms.Button pakoListButton;
    }
}

namespace SistemPostar
{
    partial class ZonaMbulimi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZonaMbulimi));
            this.addZonaMbulimiLabel = new System.Windows.Forms.Label();
            this.zonaMbulimiListLabel = new System.Windows.Forms.Label();
            this.addZonaMbulimiButton = new System.Windows.Forms.Button();
            this.zonaMbulimiList = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addZonaMbulimiLabel
            // 
            this.addZonaMbulimiLabel.AutoSize = true;
            this.addZonaMbulimiLabel.ForeColor = System.Drawing.Color.Gold;
            this.addZonaMbulimiLabel.Location = new System.Drawing.Point(794, 542);
            this.addZonaMbulimiLabel.Name = "addZonaMbulimiLabel";
            this.addZonaMbulimiLabel.Size = new System.Drawing.Size(136, 20);
            this.addZonaMbulimiLabel.TabIndex = 8;
            this.addZonaMbulimiLabel.Text = "Add Zona Mbulimi";
            // 
            // zonaMbulimiListLabel
            // 
            this.zonaMbulimiListLabel.AutoSize = true;
            this.zonaMbulimiListLabel.ForeColor = System.Drawing.Color.Gold;
            this.zonaMbulimiListLabel.Location = new System.Drawing.Point(320, 542);
            this.zonaMbulimiListLabel.Name = "zonaMbulimiListLabel";
            this.zonaMbulimiListLabel.Size = new System.Drawing.Size(132, 20);
            this.zonaMbulimiListLabel.TabIndex = 7;
            this.zonaMbulimiListLabel.Text = "Zona Mbulimi List";
            // 
            // addZonaMbulimiButton
            // 
            this.addZonaMbulimiButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("addZonaMbulimiButton.BackgroundImage")));
            this.addZonaMbulimiButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addZonaMbulimiButton.Location = new System.Drawing.Point(704, 234);
            this.addZonaMbulimiButton.Name = "addZonaMbulimiButton";
            this.addZonaMbulimiButton.Size = new System.Drawing.Size(316, 305);
            this.addZonaMbulimiButton.TabIndex = 6;
            this.addZonaMbulimiButton.UseVisualStyleBackColor = true;
            this.addZonaMbulimiButton.Click += new System.EventHandler(this.addZonaMbulimiButton_Click);
            // 
            // zonaMbulimiList
            // 
            this.zonaMbulimiList.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("zonaMbulimiList.BackgroundImage")));
            this.zonaMbulimiList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.zonaMbulimiList.Location = new System.Drawing.Point(236, 234);
            this.zonaMbulimiList.Name = "zonaMbulimiList";
            this.zonaMbulimiList.Size = new System.Drawing.Size(316, 305);
            this.zonaMbulimiList.TabIndex = 5;
            this.zonaMbulimiList.UseVisualStyleBackColor = true;
            this.zonaMbulimiList.Click += new System.EventHandler(this.zonaMbulimiList_Click);
            // 
            // ZonaMbulimi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.Controls.Add(this.addZonaMbulimiLabel);
            this.Controls.Add(this.zonaMbulimiListLabel);
            this.Controls.Add(this.addZonaMbulimiButton);
            this.Controls.Add(this.zonaMbulimiList);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ZonaMbulimi";
            this.Size = new System.Drawing.Size(1239, 842);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label addZonaMbulimiLabel;
        private System.Windows.Forms.Label zonaMbulimiListLabel;
        private System.Windows.Forms.Button addZonaMbulimiButton;
        private System.Windows.Forms.Button zonaMbulimiList;
    }
}

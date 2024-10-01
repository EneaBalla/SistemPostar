namespace SistemPostar
{
    partial class PikaPostare
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PikaPostare));
            this.addPikaPostarelabel = new System.Windows.Forms.Label();
            this.pikaPostareLabel = new System.Windows.Forms.Label();
            this.addPikaPostareButton = new System.Windows.Forms.Button();
            this.pikaPostareListButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addPikaPostarelabel
            // 
            this.addPikaPostarelabel.AutoSize = true;
            this.addPikaPostarelabel.ForeColor = System.Drawing.Color.Gold;
            this.addPikaPostarelabel.Location = new System.Drawing.Point(870, 526);
            this.addPikaPostarelabel.Name = "addPikaPostarelabel";
            this.addPikaPostarelabel.Size = new System.Drawing.Size(131, 20);
            this.addPikaPostarelabel.TabIndex = 8;
            this.addPikaPostarelabel.Text = "Add Pika Postare";
            // 
            // pikaPostareLabel
            // 
            this.pikaPostareLabel.AutoSize = true;
            this.pikaPostareLabel.ForeColor = System.Drawing.Color.Gold;
            this.pikaPostareLabel.Location = new System.Drawing.Point(417, 526);
            this.pikaPostareLabel.Name = "pikaPostareLabel";
            this.pikaPostareLabel.Size = new System.Drawing.Size(98, 20);
            this.pikaPostareLabel.TabIndex = 7;
            this.pikaPostareLabel.Text = "Pika Postare";
            // 
            // addPikaPostareButton
            // 
            this.addPikaPostareButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("addPikaPostareButton.BackgroundImage")));
            this.addPikaPostareButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addPikaPostareButton.Location = new System.Drawing.Point(807, 263);
            this.addPikaPostareButton.Name = "addPikaPostareButton";
            this.addPikaPostareButton.Size = new System.Drawing.Size(256, 249);
            this.addPikaPostareButton.TabIndex = 6;
            this.addPikaPostareButton.UseVisualStyleBackColor = true;
            this.addPikaPostareButton.Click += new System.EventHandler(this.addPikaPostareButton_Click);
            // 
            // pikaPostareListButton
            // 
            this.pikaPostareListButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pikaPostareListButton.BackgroundImage")));
            this.pikaPostareListButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pikaPostareListButton.Location = new System.Drawing.Point(336, 263);
            this.pikaPostareListButton.Name = "pikaPostareListButton";
            this.pikaPostareListButton.Size = new System.Drawing.Size(256, 249);
            this.pikaPostareListButton.TabIndex = 5;
            this.pikaPostareListButton.UseVisualStyleBackColor = true;
            this.pikaPostareListButton.Click += new System.EventHandler(this.usresList_Click);
            // 
            // PikaPostare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.Controls.Add(this.addPikaPostarelabel);
            this.Controls.Add(this.pikaPostareLabel);
            this.Controls.Add(this.addPikaPostareButton);
            this.Controls.Add(this.pikaPostareListButton);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PikaPostare";
            this.Size = new System.Drawing.Size(1241, 865);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label addPikaPostarelabel;
        private System.Windows.Forms.Label pikaPostareLabel;
        private System.Windows.Forms.Button addPikaPostareButton;
        private System.Windows.Forms.Button pikaPostareListButton;
    }
}

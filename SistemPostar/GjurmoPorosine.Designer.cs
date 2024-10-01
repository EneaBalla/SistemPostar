namespace SistemPostar
{
    partial class GjurmoPorosine
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
            this.backButton = new System.Windows.Forms.Button();
            this.gjurmoTextBox = new System.Windows.Forms.TextBox();
            this.gjurmoButton = new System.Windows.Forms.Button();
            this.trackingInfo = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.Navy;
            this.backButton.ForeColor = System.Drawing.Color.Gold;
            this.backButton.Location = new System.Drawing.Point(14, 15);
            this.backButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(119, 55);
            this.backButton.TabIndex = 0;
            this.backButton.Text = "Mbrapa";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // gjurmoTextBox
            // 
            this.gjurmoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gjurmoTextBox.Location = new System.Drawing.Point(326, 31);
            this.gjurmoTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gjurmoTextBox.Name = "gjurmoTextBox";
            this.gjurmoTextBox.Size = new System.Drawing.Size(216, 43);
            this.gjurmoTextBox.TabIndex = 1;
            this.gjurmoTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // gjurmoButton
            // 
            this.gjurmoButton.BackColor = System.Drawing.Color.Navy;
            this.gjurmoButton.ForeColor = System.Drawing.Color.Gold;
            this.gjurmoButton.Location = new System.Drawing.Point(615, 26);
            this.gjurmoButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gjurmoButton.Name = "gjurmoButton";
            this.gjurmoButton.Size = new System.Drawing.Size(119, 55);
            this.gjurmoButton.TabIndex = 2;
            this.gjurmoButton.Text = "Gjurmo";
            this.gjurmoButton.UseVisualStyleBackColor = false;
            this.gjurmoButton.Click += new System.EventHandler(this.gjurmoButton_Click);
            // 
            // trackingInfo
            // 
            this.trackingInfo.FormattingEnabled = true;
            this.trackingInfo.ItemHeight = 20;
            this.trackingInfo.Location = new System.Drawing.Point(159, 131);
            this.trackingInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.trackingInfo.Name = "trackingInfo";
            this.trackingInfo.Size = new System.Drawing.Size(631, 464);
            this.trackingInfo.TabIndex = 3;
            // 
            // GjurmoPorosine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(990, 646);
            this.Controls.Add(this.trackingInfo);
            this.Controls.Add(this.gjurmoButton);
            this.Controls.Add(this.gjurmoTextBox);
            this.Controls.Add(this.backButton);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "GjurmoPorosine";
            this.Text = "GjurmoPorosine";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.TextBox gjurmoTextBox;
        private System.Windows.Forms.Button gjurmoButton;
        private System.Windows.Forms.ListBox trackingInfo;
    }
}
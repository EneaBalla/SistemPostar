namespace SistemPostar
{
    partial class AddZonaMbulimi
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
            this.pikePostareForm = new System.Windows.Forms.ComboBox();
            this.pikePostareFormLabel = new System.Windows.Forms.Label();
            this.nameForm = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.saveUserButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pikePostareForm
            // 
            this.pikePostareForm.FormattingEnabled = true;
            this.pikePostareForm.Location = new System.Drawing.Point(596, 137);
            this.pikePostareForm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pikePostareForm.Name = "pikePostareForm";
            this.pikePostareForm.Size = new System.Drawing.Size(242, 28);
            this.pikePostareForm.TabIndex = 23;
            // 
            // pikePostareFormLabel
            // 
            this.pikePostareFormLabel.AutoSize = true;
            this.pikePostareFormLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pikePostareFormLabel.ForeColor = System.Drawing.Color.Gold;
            this.pikePostareFormLabel.Location = new System.Drawing.Point(590, 102);
            this.pikePostareFormLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pikePostareFormLabel.Name = "pikePostareFormLabel";
            this.pikePostareFormLabel.Size = new System.Drawing.Size(149, 29);
            this.pikePostareFormLabel.TabIndex = 22;
            this.pikePostareFormLabel.Text = "Pika Postare";
            // 
            // nameForm
            // 
            this.nameForm.Location = new System.Drawing.Point(309, 137);
            this.nameForm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nameForm.Name = "nameForm";
            this.nameForm.Size = new System.Drawing.Size(242, 26);
            this.nameForm.TabIndex = 15;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.ForeColor = System.Drawing.Color.Gold;
            this.nameLabel.Location = new System.Drawing.Point(303, 102);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(78, 29);
            this.nameLabel.TabIndex = 14;
            this.nameLabel.Text = "Name";
            // 
            // saveUserButton
            // 
            this.saveUserButton.BackColor = System.Drawing.Color.Navy;
            this.saveUserButton.ForeColor = System.Drawing.Color.Gold;
            this.saveUserButton.Location = new System.Drawing.Point(501, 235);
            this.saveUserButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.saveUserButton.Name = "saveUserButton";
            this.saveUserButton.Size = new System.Drawing.Size(136, 68);
            this.saveUserButton.TabIndex = 13;
            this.saveUserButton.Text = "Save";
            this.saveUserButton.UseVisualStyleBackColor = false;
            this.saveUserButton.Click += new System.EventHandler(this.saveUserButton_Click);
            // 
            // AddZonaMbulimi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.Controls.Add(this.pikePostareForm);
            this.Controls.Add(this.pikePostareFormLabel);
            this.Controls.Add(this.nameForm);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.saveUserButton);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AddZonaMbulimi";
            this.Size = new System.Drawing.Size(1244, 838);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox pikePostareForm;
        private System.Windows.Forms.Label pikePostareFormLabel;
        private System.Windows.Forms.TextBox nameForm;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Button saveUserButton;
    }
}

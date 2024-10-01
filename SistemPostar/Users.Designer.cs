namespace SistemPostar
{
    partial class Users
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Users));
            this.usresList = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.usersListLabel = new System.Windows.Forms.Label();
            this.addUserLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // usresList
            // 
            this.usresList.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("usresList.BackgroundImage")));
            this.usresList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.usresList.Location = new System.Drawing.Point(219, 198);
            this.usresList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.usresList.Name = "usresList";
            this.usresList.Size = new System.Drawing.Size(256, 249);
            this.usresList.TabIndex = 0;
            this.usresList.UseVisualStyleBackColor = true;
            this.usresList.Click += new System.EventHandler(this.usresList_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(690, 198);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(256, 249);
            this.button2.TabIndex = 1;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // usersListLabel
            // 
            this.usersListLabel.AutoSize = true;
            this.usersListLabel.BackColor = System.Drawing.Color.Navy;
            this.usersListLabel.ForeColor = System.Drawing.Color.Gold;
            this.usersListLabel.Location = new System.Drawing.Point(318, 460);
            this.usersListLabel.Name = "usersListLabel";
            this.usersListLabel.Size = new System.Drawing.Size(80, 20);
            this.usersListLabel.TabIndex = 3;
            this.usersListLabel.Text = "Users List";
            // 
            // addUserLabel
            // 
            this.addUserLabel.AutoSize = true;
            this.addUserLabel.BackColor = System.Drawing.Color.Navy;
            this.addUserLabel.ForeColor = System.Drawing.Color.Gold;
            this.addUserLabel.Location = new System.Drawing.Point(788, 460);
            this.addUserLabel.Name = "addUserLabel";
            this.addUserLabel.Size = new System.Drawing.Size(76, 20);
            this.addUserLabel.TabIndex = 4;
            this.addUserLabel.Text = "Add User";
            // 
            // Users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.Controls.Add(this.addUserLabel);
            this.Controls.Add(this.usersListLabel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.usresList);
            this.ForeColor = System.Drawing.Color.Gold;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Users";
            this.Size = new System.Drawing.Size(1241, 865);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button usresList;
        private System.Windows.Forms.Label usersListLabel;
        private System.Windows.Forms.Label addUserLabel;
        private System.Windows.Forms.Button button2;
    }
}

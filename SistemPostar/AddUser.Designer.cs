namespace SistemPostar
{
    partial class AddUser
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
            this.saveUserButton = new System.Windows.Forms.Button();
            this.roleForm = new System.Windows.Forms.ComboBox();
            this.roleLabel = new System.Windows.Forms.Label();
            this.firstnameForm = new System.Windows.Forms.TextBox();
            this.firstnameLabel = new System.Windows.Forms.Label();
            this.lastnameForm = new System.Windows.Forms.TextBox();
            this.lastnameLabel = new System.Windows.Forms.Label();
            this.usernameForm = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.phoneForm = new System.Windows.Forms.TextBox();
            this.phoneLabel = new System.Windows.Forms.Label();
            this.passwordForm = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.pikePostareForm = new System.Windows.Forms.ComboBox();
            this.pikePostareLabel = new System.Windows.Forms.Label();
            this.zoneMbulimiForm = new System.Windows.Forms.ComboBox();
            this.zoneMbulimiLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // saveUserButton
            // 
            this.saveUserButton.BackColor = System.Drawing.Color.Navy;
            this.saveUserButton.ForeColor = System.Drawing.Color.Gold;
            this.saveUserButton.Location = new System.Drawing.Point(526, 456);
            this.saveUserButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.saveUserButton.Name = "saveUserButton";
            this.saveUserButton.Size = new System.Drawing.Size(136, 68);
            this.saveUserButton.TabIndex = 0;
            this.saveUserButton.Text = "Save";
            this.saveUserButton.UseVisualStyleBackColor = false;
            this.saveUserButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // roleForm
            // 
            this.roleForm.FormattingEnabled = true;
            this.roleForm.Location = new System.Drawing.Point(622, 251);
            this.roleForm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.roleForm.Name = "roleForm";
            this.roleForm.Size = new System.Drawing.Size(242, 28);
            this.roleForm.TabIndex = 18;
            this.roleForm.SelectedIndexChanged += new System.EventHandler(this.roleForm_SelectedIndexChanged_1);
            // 
            // roleLabel
            // 
            this.roleLabel.AutoSize = true;
            this.roleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roleLabel.ForeColor = System.Drawing.Color.Gold;
            this.roleLabel.Location = new System.Drawing.Point(616, 216);
            this.roleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.roleLabel.Name = "roleLabel";
            this.roleLabel.Size = new System.Drawing.Size(70, 29);
            this.roleLabel.TabIndex = 17;
            this.roleLabel.Text = "Role:";
            // 
            // firstnameForm
            // 
            this.firstnameForm.Location = new System.Drawing.Point(350, 79);
            this.firstnameForm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.firstnameForm.Name = "firstnameForm";
            this.firstnameForm.Size = new System.Drawing.Size(242, 26);
            this.firstnameForm.TabIndex = 20;
            // 
            // firstnameLabel
            // 
            this.firstnameLabel.AutoSize = true;
            this.firstnameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstnameLabel.ForeColor = System.Drawing.Color.Gold;
            this.firstnameLabel.Location = new System.Drawing.Point(344, 44);
            this.firstnameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.firstnameLabel.Name = "firstnameLabel";
            this.firstnameLabel.Size = new System.Drawing.Size(120, 29);
            this.firstnameLabel.TabIndex = 19;
            this.firstnameLabel.Text = "Firstname";
            // 
            // lastnameForm
            // 
            this.lastnameForm.Location = new System.Drawing.Point(622, 79);
            this.lastnameForm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lastnameForm.Name = "lastnameForm";
            this.lastnameForm.Size = new System.Drawing.Size(242, 26);
            this.lastnameForm.TabIndex = 22;
            // 
            // lastnameLabel
            // 
            this.lastnameLabel.AutoSize = true;
            this.lastnameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastnameLabel.ForeColor = System.Drawing.Color.Gold;
            this.lastnameLabel.Location = new System.Drawing.Point(616, 44);
            this.lastnameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lastnameLabel.Name = "lastnameLabel";
            this.lastnameLabel.Size = new System.Drawing.Size(117, 29);
            this.lastnameLabel.TabIndex = 21;
            this.lastnameLabel.Text = "Lastname";
            // 
            // usernameForm
            // 
            this.usernameForm.Location = new System.Drawing.Point(350, 164);
            this.usernameForm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.usernameForm.Name = "usernameForm";
            this.usernameForm.Size = new System.Drawing.Size(242, 26);
            this.usernameForm.TabIndex = 24;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.ForeColor = System.Drawing.Color.Gold;
            this.usernameLabel.Location = new System.Drawing.Point(344, 129);
            this.usernameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(124, 29);
            this.usernameLabel.TabIndex = 23;
            this.usernameLabel.Text = "Username";
            // 
            // phoneForm
            // 
            this.phoneForm.Location = new System.Drawing.Point(622, 164);
            this.phoneForm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.phoneForm.Name = "phoneForm";
            this.phoneForm.Size = new System.Drawing.Size(242, 26);
            this.phoneForm.TabIndex = 26;
            // 
            // phoneLabel
            // 
            this.phoneLabel.AutoSize = true;
            this.phoneLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phoneLabel.ForeColor = System.Drawing.Color.Gold;
            this.phoneLabel.Location = new System.Drawing.Point(616, 129);
            this.phoneLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.phoneLabel.Name = "phoneLabel";
            this.phoneLabel.Size = new System.Drawing.Size(83, 29);
            this.phoneLabel.TabIndex = 25;
            this.phoneLabel.Text = "Phone";
            // 
            // passwordForm
            // 
            this.passwordForm.Location = new System.Drawing.Point(350, 254);
            this.passwordForm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.passwordForm.Name = "passwordForm";
            this.passwordForm.PasswordChar = '*';
            this.passwordForm.Size = new System.Drawing.Size(242, 26);
            this.passwordForm.TabIndex = 28;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLabel.ForeColor = System.Drawing.Color.Gold;
            this.passwordLabel.Location = new System.Drawing.Point(344, 219);
            this.passwordLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(120, 29);
            this.passwordLabel.TabIndex = 27;
            this.passwordLabel.Text = "Password";
            // 
            // pikePostareForm
            // 
            this.pikePostareForm.FormattingEnabled = true;
            this.pikePostareForm.Location = new System.Drawing.Point(350, 342);
            this.pikePostareForm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pikePostareForm.Name = "pikePostareForm";
            this.pikePostareForm.Size = new System.Drawing.Size(242, 28);
            this.pikePostareForm.TabIndex = 30;
            this.pikePostareForm.SelectedIndexChanged += new System.EventHandler(this.pikePostareForm_SelectedIndexChanged);
            // 
            // pikePostareLabel
            // 
            this.pikePostareLabel.AutoSize = true;
            this.pikePostareLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pikePostareLabel.ForeColor = System.Drawing.Color.Gold;
            this.pikePostareLabel.Location = new System.Drawing.Point(344, 308);
            this.pikePostareLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pikePostareLabel.Name = "pikePostareLabel";
            this.pikePostareLabel.Size = new System.Drawing.Size(156, 29);
            this.pikePostareLabel.TabIndex = 29;
            this.pikePostareLabel.Text = "Pike Postare:";
            // 
            // zoneMbulimiForm
            // 
            this.zoneMbulimiForm.FormattingEnabled = true;
            this.zoneMbulimiForm.Location = new System.Drawing.Point(622, 342);
            this.zoneMbulimiForm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.zoneMbulimiForm.Name = "zoneMbulimiForm";
            this.zoneMbulimiForm.Size = new System.Drawing.Size(242, 28);
            this.zoneMbulimiForm.TabIndex = 32;
            this.zoneMbulimiForm.SelectedIndexChanged += new System.EventHandler(this.zoneMbulimiForm_SelectedIndexChanged);
            // 
            // zoneMbulimiLabel
            // 
            this.zoneMbulimiLabel.AutoSize = true;
            this.zoneMbulimiLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zoneMbulimiLabel.ForeColor = System.Drawing.Color.Gold;
            this.zoneMbulimiLabel.Location = new System.Drawing.Point(616, 308);
            this.zoneMbulimiLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.zoneMbulimiLabel.Name = "zoneMbulimiLabel";
            this.zoneMbulimiLabel.Size = new System.Drawing.Size(179, 29);
            this.zoneMbulimiLabel.TabIndex = 31;
            this.zoneMbulimiLabel.Text = "Zoone Mbulimi:";
            // 
            // AddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.Controls.Add(this.zoneMbulimiForm);
            this.Controls.Add(this.zoneMbulimiLabel);
            this.Controls.Add(this.pikePostareForm);
            this.Controls.Add(this.pikePostareLabel);
            this.Controls.Add(this.passwordForm);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.phoneForm);
            this.Controls.Add(this.phoneLabel);
            this.Controls.Add(this.usernameForm);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.lastnameForm);
            this.Controls.Add(this.lastnameLabel);
            this.Controls.Add(this.firstnameForm);
            this.Controls.Add(this.firstnameLabel);
            this.Controls.Add(this.roleForm);
            this.Controls.Add(this.roleLabel);
            this.Controls.Add(this.saveUserButton);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AddUser";
            this.Size = new System.Drawing.Size(1209, 762);
            this.Load += new System.EventHandler(this.AddUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveUserButton;
        private System.Windows.Forms.ComboBox roleForm;
        private System.Windows.Forms.Label roleLabel;
        private System.Windows.Forms.TextBox firstnameForm;
        private System.Windows.Forms.Label firstnameLabel;
        private System.Windows.Forms.TextBox lastnameForm;
        private System.Windows.Forms.Label lastnameLabel;
        private System.Windows.Forms.TextBox usernameForm;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox phoneForm;
        private System.Windows.Forms.Label phoneLabel;
        private System.Windows.Forms.TextBox passwordForm;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.ComboBox pikePostareForm;
        private System.Windows.Forms.Label pikePostareLabel;
        private System.Windows.Forms.ComboBox zoneMbulimiForm;
        private System.Windows.Forms.Label zoneMbulimiLabel;
    }
}

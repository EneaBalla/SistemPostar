namespace SistemPostar
{
    partial class UsersList
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
            this.enableUserButton = new System.Windows.Forms.Button();
            this.deleteUserButton = new System.Windows.Forms.Button();
            this.editUserButton = new System.Windows.Forms.Button();
            this.roleLabel = new System.Windows.Forms.Label();
            this.roleComboBox = new System.Windows.Forms.ComboBox();
            this.clearUsersList = new System.Windows.Forms.Button();
            this.phoneSearchBox = new System.Windows.Forms.TextBox();
            this.phoneLabel = new System.Windows.Forms.Label();
            this.usernameSearchBox = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.lastnameSearchBox = new System.Windows.Forms.TextBox();
            this.lastnameLabel = new System.Windows.Forms.Label();
            this.firstnameSearchBox = new System.Windows.Forms.TextBox();
            this.firstnameLabel = new System.Windows.Forms.Label();
            this.showUsers = new System.Windows.Forms.Button();
            this.usersGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.usersGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // enableUserButton
            // 
            this.enableUserButton.Location = new System.Drawing.Point(303, 774);
            this.enableUserButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.enableUserButton.Name = "enableUserButton";
            this.enableUserButton.Size = new System.Drawing.Size(146, 66);
            this.enableUserButton.TabIndex = 47;
            this.enableUserButton.Text = "Enable";
            this.enableUserButton.UseVisualStyleBackColor = true;
            this.enableUserButton.Click += new System.EventHandler(this.enableUserButton_Click_1);
            // 
            // deleteUserButton
            // 
            this.deleteUserButton.Location = new System.Drawing.Point(148, 774);
            this.deleteUserButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.deleteUserButton.Name = "deleteUserButton";
            this.deleteUserButton.Size = new System.Drawing.Size(146, 66);
            this.deleteUserButton.TabIndex = 46;
            this.deleteUserButton.Text = "Delete";
            this.deleteUserButton.UseVisualStyleBackColor = true;
            this.deleteUserButton.Click += new System.EventHandler(this.deleteUserButton_Click_1);
            // 
            // editUserButton
            // 
            this.editUserButton.Location = new System.Drawing.Point(-6, 774);
            this.editUserButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.editUserButton.Name = "editUserButton";
            this.editUserButton.Size = new System.Drawing.Size(146, 66);
            this.editUserButton.TabIndex = 45;
            this.editUserButton.Text = "Edit";
            this.editUserButton.UseVisualStyleBackColor = true;
            this.editUserButton.Click += new System.EventHandler(this.editUserButton_Click);
            // 
            // roleLabel
            // 
            this.roleLabel.AutoSize = true;
            this.roleLabel.BackColor = System.Drawing.Color.Navy;
            this.roleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roleLabel.ForeColor = System.Drawing.Color.Gold;
            this.roleLabel.Location = new System.Drawing.Point(16, 83);
            this.roleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.roleLabel.Name = "roleLabel";
            this.roleLabel.Size = new System.Drawing.Size(64, 29);
            this.roleLabel.TabIndex = 44;
            this.roleLabel.Text = "Role";
            // 
            // roleComboBox
            // 
            this.roleComboBox.FormattingEnabled = true;
            this.roleComboBox.Location = new System.Drawing.Point(21, 118);
            this.roleComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.roleComboBox.Name = "roleComboBox";
            this.roleComboBox.Size = new System.Drawing.Size(326, 28);
            this.roleComboBox.TabIndex = 43;
            this.roleComboBox.SelectedIndexChanged += new System.EventHandler(this.roleComboBox_SelectedIndexChanged_1);
            // 
            // clearUsersList
            // 
            this.clearUsersList.BackColor = System.Drawing.Color.Navy;
            this.clearUsersList.ForeColor = System.Drawing.Color.Gold;
            this.clearUsersList.Location = new System.Drawing.Point(897, 85);
            this.clearUsersList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.clearUsersList.Name = "clearUsersList";
            this.clearUsersList.Size = new System.Drawing.Size(146, 66);
            this.clearUsersList.TabIndex = 42;
            this.clearUsersList.Text = "Clear";
            this.clearUsersList.UseVisualStyleBackColor = false;
            this.clearUsersList.Click += new System.EventHandler(this.clearUsersList_Click_1);
            // 
            // phoneSearchBox
            // 
            this.phoneSearchBox.Location = new System.Drawing.Point(662, 38);
            this.phoneSearchBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.phoneSearchBox.Name = "phoneSearchBox";
            this.phoneSearchBox.Size = new System.Drawing.Size(202, 26);
            this.phoneSearchBox.TabIndex = 41;
            // 
            // phoneLabel
            // 
            this.phoneLabel.AutoSize = true;
            this.phoneLabel.BackColor = System.Drawing.Color.Navy;
            this.phoneLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phoneLabel.ForeColor = System.Drawing.Color.Gold;
            this.phoneLabel.Location = new System.Drawing.Point(656, 3);
            this.phoneLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.phoneLabel.Name = "phoneLabel";
            this.phoneLabel.Size = new System.Drawing.Size(83, 29);
            this.phoneLabel.TabIndex = 40;
            this.phoneLabel.Text = "Phone";
            // 
            // usernameSearchBox
            // 
            this.usernameSearchBox.Location = new System.Drawing.Point(448, 38);
            this.usernameSearchBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.usernameSearchBox.Name = "usernameSearchBox";
            this.usernameSearchBox.Size = new System.Drawing.Size(202, 26);
            this.usernameSearchBox.TabIndex = 39;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.BackColor = System.Drawing.Color.Navy;
            this.usernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.ForeColor = System.Drawing.Color.Gold;
            this.usernameLabel.Location = new System.Drawing.Point(442, 3);
            this.usernameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(124, 29);
            this.usernameLabel.TabIndex = 38;
            this.usernameLabel.Text = "Username";
            // 
            // lastnameSearchBox
            // 
            this.lastnameSearchBox.Location = new System.Drawing.Point(236, 38);
            this.lastnameSearchBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lastnameSearchBox.Name = "lastnameSearchBox";
            this.lastnameSearchBox.Size = new System.Drawing.Size(202, 26);
            this.lastnameSearchBox.TabIndex = 37;
            // 
            // lastnameLabel
            // 
            this.lastnameLabel.AutoSize = true;
            this.lastnameLabel.BackColor = System.Drawing.Color.Navy;
            this.lastnameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastnameLabel.ForeColor = System.Drawing.Color.Gold;
            this.lastnameLabel.Location = new System.Drawing.Point(230, 3);
            this.lastnameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lastnameLabel.Name = "lastnameLabel";
            this.lastnameLabel.Size = new System.Drawing.Size(117, 29);
            this.lastnameLabel.TabIndex = 36;
            this.lastnameLabel.Text = "Lastname";
            // 
            // firstnameSearchBox
            // 
            this.firstnameSearchBox.Location = new System.Drawing.Point(22, 38);
            this.firstnameSearchBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.firstnameSearchBox.Name = "firstnameSearchBox";
            this.firstnameSearchBox.Size = new System.Drawing.Size(202, 26);
            this.firstnameSearchBox.TabIndex = 35;
            // 
            // firstnameLabel
            // 
            this.firstnameLabel.AutoSize = true;
            this.firstnameLabel.BackColor = System.Drawing.Color.Navy;
            this.firstnameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstnameLabel.ForeColor = System.Drawing.Color.Gold;
            this.firstnameLabel.Location = new System.Drawing.Point(16, 3);
            this.firstnameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.firstnameLabel.Name = "firstnameLabel";
            this.firstnameLabel.Size = new System.Drawing.Size(120, 29);
            this.firstnameLabel.TabIndex = 34;
            this.firstnameLabel.Text = "Firstname";
            // 
            // showUsers
            // 
            this.showUsers.BackColor = System.Drawing.Color.Navy;
            this.showUsers.ForeColor = System.Drawing.Color.Gold;
            this.showUsers.Location = new System.Drawing.Point(1052, 85);
            this.showUsers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.showUsers.Name = "showUsers";
            this.showUsers.Size = new System.Drawing.Size(146, 66);
            this.showUsers.TabIndex = 33;
            this.showUsers.Text = "Show";
            this.showUsers.UseVisualStyleBackColor = false;
            this.showUsers.Click += new System.EventHandler(this.showUsers_Click_1);
            // 
            // usersGridView
            // 
            this.usersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usersGridView.Location = new System.Drawing.Point(-6, 160);
            this.usersGridView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.usersGridView.Name = "usersGridView";
            this.usersGridView.RowHeadersWidth = 62;
            this.usersGridView.Size = new System.Drawing.Size(1208, 588);
            this.usersGridView.TabIndex = 32;
            // 
            // UsersList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.Controls.Add(this.enableUserButton);
            this.Controls.Add(this.deleteUserButton);
            this.Controls.Add(this.editUserButton);
            this.Controls.Add(this.roleLabel);
            this.Controls.Add(this.roleComboBox);
            this.Controls.Add(this.clearUsersList);
            this.Controls.Add(this.phoneSearchBox);
            this.Controls.Add(this.phoneLabel);
            this.Controls.Add(this.usernameSearchBox);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.lastnameSearchBox);
            this.Controls.Add(this.lastnameLabel);
            this.Controls.Add(this.firstnameSearchBox);
            this.Controls.Add(this.firstnameLabel);
            this.Controls.Add(this.showUsers);
            this.Controls.Add(this.usersGridView);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UsersList";
            this.Size = new System.Drawing.Size(1196, 843);
            ((System.ComponentModel.ISupportInitialize)(this.usersGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button enableUserButton;
        private System.Windows.Forms.Button deleteUserButton;
        private System.Windows.Forms.Button editUserButton;
        private System.Windows.Forms.Label roleLabel;
        private System.Windows.Forms.ComboBox roleComboBox;
        private System.Windows.Forms.Button clearUsersList;
        private System.Windows.Forms.TextBox phoneSearchBox;
        private System.Windows.Forms.Label phoneLabel;
        private System.Windows.Forms.TextBox usernameSearchBox;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox lastnameSearchBox;
        private System.Windows.Forms.Label lastnameLabel;
        private System.Windows.Forms.TextBox firstnameSearchBox;
        private System.Windows.Forms.Label firstnameLabel;
        private System.Windows.Forms.Button showUsers;
        private System.Windows.Forms.DataGridView usersGridView;
    }
}

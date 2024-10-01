namespace SistemPostar
{
    partial class Orders
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Orders));
            this.addOrderLabel = new System.Windows.Forms.Label();
            this.ordersListLabel = new System.Windows.Forms.Label();
            this.addOrdersButton = new System.Windows.Forms.Button();
            this.usresList = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addOrderLabel
            // 
            this.addOrderLabel.AutoSize = true;
            this.addOrderLabel.Location = new System.Drawing.Point(620, 371);
            this.addOrderLabel.Name = "addOrderLabel";
            this.addOrderLabel.Size = new System.Drawing.Size(69, 16);
            this.addOrderLabel.TabIndex = 8;
            this.addOrderLabel.Text = "Add Order";
            // 
            // ordersListLabel
            // 
            this.ordersListLabel.AutoSize = true;
            this.ordersListLabel.Location = new System.Drawing.Point(203, 371);
            this.ordersListLabel.Name = "ordersListLabel";
            this.ordersListLabel.Size = new System.Drawing.Size(71, 16);
            this.ordersListLabel.TabIndex = 7;
            this.ordersListLabel.Text = "Orders List";
            // 
            // addOrdersButton
            // 
            this.addOrdersButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("addOrdersButton.BackgroundImage")));
            this.addOrdersButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addOrdersButton.Location = new System.Drawing.Point(533, 161);
            this.addOrdersButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addOrdersButton.Name = "addOrdersButton";
            this.addOrdersButton.Size = new System.Drawing.Size(228, 199);
            this.addOrdersButton.TabIndex = 6;
            this.addOrdersButton.UseVisualStyleBackColor = true;
            this.addOrdersButton.Click += new System.EventHandler(this.addOrdersButton_Click);
            // 
            // usresList
            // 
            this.usresList.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("usresList.BackgroundImage")));
            this.usresList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.usresList.Location = new System.Drawing.Point(115, 161);
            this.usresList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.usresList.Name = "usresList";
            this.usresList.Size = new System.Drawing.Size(228, 199);
            this.usresList.TabIndex = 5;
            this.usresList.UseVisualStyleBackColor = true;
            // 
            // Orders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.addOrderLabel);
            this.Controls.Add(this.ordersListLabel);
            this.Controls.Add(this.addOrdersButton);
            this.Controls.Add(this.usresList);
            this.Name = "Orders";
            this.Size = new System.Drawing.Size(876, 549);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label addOrderLabel;
        private System.Windows.Forms.Label ordersListLabel;
        private System.Windows.Forms.Button addOrdersButton;
        private System.Windows.Forms.Button usresList;
    }
}

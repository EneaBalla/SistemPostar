namespace SistemPostar
{
    partial class ShperndaresList
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
            this.viewButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.shperndaresGridView = new System.Windows.Forms.DataGridView();
            this.prioritetCheckBoxInput = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.shperndaresGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // viewButton
            // 
            this.viewButton.BackColor = System.Drawing.Color.Navy;
            this.viewButton.ForeColor = System.Drawing.Color.Gold;
            this.viewButton.Location = new System.Drawing.Point(376, 30);
            this.viewButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.viewButton.Name = "viewButton";
            this.viewButton.Size = new System.Drawing.Size(99, 58);
            this.viewButton.TabIndex = 27;
            this.viewButton.Text = "View";
            this.viewButton.UseVisualStyleBackColor = false;
            this.viewButton.Click += new System.EventHandler(this.viewButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.Navy;
            this.searchButton.ForeColor = System.Drawing.Color.Gold;
            this.searchButton.Location = new System.Drawing.Point(270, 30);
            this.searchButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(99, 58);
            this.searchButton.TabIndex = 26;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.BackColor = System.Drawing.Color.Navy;
            this.clearButton.ForeColor = System.Drawing.Color.Gold;
            this.clearButton.Location = new System.Drawing.Point(164, 30);
            this.clearButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(99, 58);
            this.clearButton.TabIndex = 25;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // shperndaresGridView
            // 
            this.shperndaresGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.shperndaresGridView.Location = new System.Drawing.Point(3, 192);
            this.shperndaresGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.shperndaresGridView.Name = "shperndaresGridView";
            this.shperndaresGridView.RowHeadersWidth = 51;
            this.shperndaresGridView.RowTemplate.Height = 24;
            this.shperndaresGridView.Size = new System.Drawing.Size(1267, 609);
            this.shperndaresGridView.TabIndex = 14;
            // 
            // prioritetCheckBoxInput
            // 
            this.prioritetCheckBoxInput.AutoSize = true;
            this.prioritetCheckBoxInput.BackColor = System.Drawing.Color.Navy;
            this.prioritetCheckBoxInput.ForeColor = System.Drawing.Color.Gold;
            this.prioritetCheckBoxInput.Location = new System.Drawing.Point(24, 62);
            this.prioritetCheckBoxInput.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.prioritetCheckBoxInput.Name = "prioritetCheckBoxInput";
            this.prioritetCheckBoxInput.Size = new System.Drawing.Size(89, 24);
            this.prioritetCheckBoxInput.TabIndex = 28;
            this.prioritetCheckBoxInput.Text = "Prioritet";
            this.prioritetCheckBoxInput.UseVisualStyleBackColor = false;
            this.prioritetCheckBoxInput.CheckedChanged += new System.EventHandler(this.prioritetCheckBoxInput_CheckedChanged);
            // 
            // ShperndaresList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.Controls.Add(this.prioritetCheckBoxInput);
            this.Controls.Add(this.viewButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.shperndaresGridView);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ShperndaresList";
            this.Size = new System.Drawing.Size(1274, 805);
            ((System.ComponentModel.ISupportInitialize)(this.shperndaresGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button viewButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.DataGridView shperndaresGridView;
        private System.Windows.Forms.CheckBox prioritetCheckBoxInput;
    }
}

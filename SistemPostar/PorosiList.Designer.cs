namespace SistemPostar
{
    partial class PorosiList
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
            this.editPorosiButton = new System.Windows.Forms.Button();
            this.klientLabel = new System.Windows.Forms.Label();
            this.klientForm = new System.Windows.Forms.ComboBox();
            this.clearPorosiList = new System.Windows.Forms.Button();
            this.showPorosiButton = new System.Windows.Forms.Button();
            this.porosiGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.pikePostareForm = new System.Windows.Forms.ComboBox();
            this.zonaMbulimiLabel = new System.Windows.Forms.Label();
            this.zonaMbulimiForm = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.porosiGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // editPorosiButton
            // 
            this.editPorosiButton.Location = new System.Drawing.Point(9, 778);
            this.editPorosiButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.editPorosiButton.Name = "editPorosiButton";
            this.editPorosiButton.Size = new System.Drawing.Size(145, 66);
            this.editPorosiButton.TabIndex = 71;
            this.editPorosiButton.Text = "Edit";
            this.editPorosiButton.UseVisualStyleBackColor = true;
            this.editPorosiButton.Click += new System.EventHandler(this.editPorosiButton_Click);
            // 
            // klientLabel
            // 
            this.klientLabel.AutoSize = true;
            this.klientLabel.BackColor = System.Drawing.Color.Navy;
            this.klientLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klientLabel.ForeColor = System.Drawing.Color.Gold;
            this.klientLabel.Location = new System.Drawing.Point(4, 36);
            this.klientLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.klientLabel.Name = "klientLabel";
            this.klientLabel.Size = new System.Drawing.Size(74, 29);
            this.klientLabel.TabIndex = 70;
            this.klientLabel.Text = "Klient";
            // 
            // klientForm
            // 
            this.klientForm.FormattingEnabled = true;
            this.klientForm.Location = new System.Drawing.Point(9, 71);
            this.klientForm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.klientForm.Name = "klientForm";
            this.klientForm.Size = new System.Drawing.Size(188, 28);
            this.klientForm.TabIndex = 69;
            this.klientForm.SelectedIndexChanged += new System.EventHandler(this.klientForm_SelectedIndexChanged);
            // 
            // clearPorosiList
            // 
            this.clearPorosiList.BackColor = System.Drawing.Color.Navy;
            this.clearPorosiList.ForeColor = System.Drawing.Color.Gold;
            this.clearPorosiList.Location = new System.Drawing.Point(912, 88);
            this.clearPorosiList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.clearPorosiList.Name = "clearPorosiList";
            this.clearPorosiList.Size = new System.Drawing.Size(145, 66);
            this.clearPorosiList.TabIndex = 68;
            this.clearPorosiList.Text = "Clear";
            this.clearPorosiList.UseVisualStyleBackColor = false;
            this.clearPorosiList.Click += new System.EventHandler(this.clearZonaMbulimiButton_Click);
            // 
            // showPorosiButton
            // 
            this.showPorosiButton.BackColor = System.Drawing.Color.Navy;
            this.showPorosiButton.ForeColor = System.Drawing.Color.Gold;
            this.showPorosiButton.Location = new System.Drawing.Point(1068, 88);
            this.showPorosiButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.showPorosiButton.Name = "showPorosiButton";
            this.showPorosiButton.Size = new System.Drawing.Size(145, 66);
            this.showPorosiButton.TabIndex = 65;
            this.showPorosiButton.Text = "Show";
            this.showPorosiButton.UseVisualStyleBackColor = false;
            this.showPorosiButton.Click += new System.EventHandler(this.showPorosiButton_Click);
            // 
            // porosiGridView
            // 
            this.porosiGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.porosiGridView.Location = new System.Drawing.Point(9, 164);
            this.porosiGridView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.porosiGridView.Name = "porosiGridView";
            this.porosiGridView.RowHeadersWidth = 51;
            this.porosiGridView.Size = new System.Drawing.Size(1207, 588);
            this.porosiGridView.TabIndex = 64;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Navy;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(218, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 29);
            this.label1.TabIndex = 75;
            this.label1.Text = "Pika Postare";
            // 
            // pikePostareForm
            // 
            this.pikePostareForm.FormattingEnabled = true;
            this.pikePostareForm.Location = new System.Drawing.Point(223, 71);
            this.pikePostareForm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pikePostareForm.Name = "pikePostareForm";
            this.pikePostareForm.Size = new System.Drawing.Size(188, 28);
            this.pikePostareForm.TabIndex = 74;
            this.pikePostareForm.SelectedIndexChanged += new System.EventHandler(this.pikePostareForm_SelectedIndexChanged);
            // 
            // zonaMbulimiLabel
            // 
            this.zonaMbulimiLabel.AutoSize = true;
            this.zonaMbulimiLabel.BackColor = System.Drawing.Color.Navy;
            this.zonaMbulimiLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zonaMbulimiLabel.ForeColor = System.Drawing.Color.Gold;
            this.zonaMbulimiLabel.Location = new System.Drawing.Point(432, 36);
            this.zonaMbulimiLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.zonaMbulimiLabel.Name = "zonaMbulimiLabel";
            this.zonaMbulimiLabel.Size = new System.Drawing.Size(159, 29);
            this.zonaMbulimiLabel.TabIndex = 77;
            this.zonaMbulimiLabel.Text = "Zone Mbulimi";
            // 
            // zonaMbulimiForm
            // 
            this.zonaMbulimiForm.FormattingEnabled = true;
            this.zonaMbulimiForm.Location = new System.Drawing.Point(436, 71);
            this.zonaMbulimiForm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.zonaMbulimiForm.Name = "zonaMbulimiForm";
            this.zonaMbulimiForm.Size = new System.Drawing.Size(188, 28);
            this.zonaMbulimiForm.TabIndex = 76;
            this.zonaMbulimiForm.SelectedIndexChanged += new System.EventHandler(this.zonaMbulimiForm_SelectedIndexChanged);
            // 
            // PorosiList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.Controls.Add(this.zonaMbulimiLabel);
            this.Controls.Add(this.zonaMbulimiForm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pikePostareForm);
            this.Controls.Add(this.editPorosiButton);
            this.Controls.Add(this.klientLabel);
            this.Controls.Add(this.klientForm);
            this.Controls.Add(this.clearPorosiList);
            this.Controls.Add(this.showPorosiButton);
            this.Controls.Add(this.porosiGridView);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PorosiList";
            this.Size = new System.Drawing.Size(1458, 881);
            ((System.ComponentModel.ISupportInitialize)(this.porosiGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button editPorosiButton;
        private System.Windows.Forms.Label klientLabel;
        private System.Windows.Forms.ComboBox klientForm;
        private System.Windows.Forms.Button clearPorosiList;
        private System.Windows.Forms.Button showPorosiButton;
        private System.Windows.Forms.DataGridView porosiGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox pikePostareForm;
        private System.Windows.Forms.Label zonaMbulimiLabel;
        private System.Windows.Forms.ComboBox zonaMbulimiForm;
    }
}

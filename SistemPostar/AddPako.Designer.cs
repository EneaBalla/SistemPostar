namespace SistemPostar
{
    partial class AddPako
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
            this.label1 = new System.Windows.Forms.Label();
            this.pikePostareComboBox = new System.Windows.Forms.ComboBox();
            this.porosiListBox = new System.Windows.Forms.ListBox();
            this.addToPakoButton = new System.Windows.Forms.Button();
            this.pakoListBox = new System.Windows.Forms.ListBox();
            this.removePorosiButton = new System.Windows.Forms.Button();
            this.createPakoButton = new System.Windows.Forms.Button();
            this.barCode = new System.Windows.Forms.PictureBox();
            this.koheZgjatjaValue = new System.Windows.Forms.Label();
            this.klientiLabel = new System.Windows.Forms.Label();
            this.pikePostareMberritjeValue = new System.Windows.Forms.Label();
            this.zoneMbulimiLabel = new System.Windows.Forms.Label();
            this.pikePostareNisjeValue = new System.Windows.Forms.Label();
            this.pikePostareLabel = new System.Windows.Forms.Label();
            this.statusValue = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.transportuesValue = new System.Windows.Forms.Label();
            this.pakoNumberValue = new System.Windows.Forms.Label();
            this.sportelistLabel = new System.Windows.Forms.Label();
            this.orderNumberLabel = new System.Windows.Forms.Label();
            this.priorityCheckbox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.barCode)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(36, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pike Postare";
            // 
            // pikePostareComboBox
            // 
            this.pikePostareComboBox.FormattingEnabled = true;
            this.pikePostareComboBox.Location = new System.Drawing.Point(36, 63);
            this.pikePostareComboBox.Name = "pikePostareComboBox";
            this.pikePostareComboBox.Size = new System.Drawing.Size(226, 28);
            this.pikePostareComboBox.TabIndex = 1;
            this.pikePostareComboBox.SelectedIndexChanged += new System.EventHandler(this.pikePostareComboBox_SelectedIndexChanged);
            // 
            // porosiListBox
            // 
            this.porosiListBox.FormattingEnabled = true;
            this.porosiListBox.ItemHeight = 20;
            this.porosiListBox.Location = new System.Drawing.Point(42, 123);
            this.porosiListBox.Name = "porosiListBox";
            this.porosiListBox.Size = new System.Drawing.Size(220, 364);
            this.porosiListBox.TabIndex = 2;
            // 
            // addToPakoButton
            // 
            this.addToPakoButton.BackColor = System.Drawing.Color.Navy;
            this.addToPakoButton.ForeColor = System.Drawing.Color.Gold;
            this.addToPakoButton.Location = new System.Drawing.Point(268, 257);
            this.addToPakoButton.Name = "addToPakoButton";
            this.addToPakoButton.Size = new System.Drawing.Size(99, 29);
            this.addToPakoButton.TabIndex = 3;
            this.addToPakoButton.Text = ">>>";
            this.addToPakoButton.UseVisualStyleBackColor = false;
            this.addToPakoButton.Click += new System.EventHandler(this.addToPakoButton_Click);
            // 
            // pakoListBox
            // 
            this.pakoListBox.BackColor = System.Drawing.Color.White;
            this.pakoListBox.FormattingEnabled = true;
            this.pakoListBox.ItemHeight = 20;
            this.pakoListBox.Location = new System.Drawing.Point(375, 123);
            this.pakoListBox.Name = "pakoListBox";
            this.pakoListBox.Size = new System.Drawing.Size(220, 364);
            this.pakoListBox.TabIndex = 4;
            // 
            // removePorosiButton
            // 
            this.removePorosiButton.BackColor = System.Drawing.Color.Navy;
            this.removePorosiButton.Location = new System.Drawing.Point(268, 294);
            this.removePorosiButton.Name = "removePorosiButton";
            this.removePorosiButton.Size = new System.Drawing.Size(99, 29);
            this.removePorosiButton.TabIndex = 5;
            this.removePorosiButton.Text = "<<<";
            this.removePorosiButton.UseVisualStyleBackColor = false;
            this.removePorosiButton.Click += new System.EventHandler(this.removePorosiButton_Click);
            // 
            // createPakoButton
            // 
            this.createPakoButton.BackColor = System.Drawing.Color.Navy;
            this.createPakoButton.Location = new System.Drawing.Point(375, 577);
            this.createPakoButton.Name = "createPakoButton";
            this.createPakoButton.Size = new System.Drawing.Size(111, 54);
            this.createPakoButton.TabIndex = 6;
            this.createPakoButton.Text = "Create Pako";
            this.createPakoButton.UseVisualStyleBackColor = false;
            this.createPakoButton.Click += new System.EventHandler(this.createPakoButton_Click);
            // 
            // barCode
            // 
            this.barCode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.barCode.ErrorImage = null;
            this.barCode.Location = new System.Drawing.Point(636, 443);
            this.barCode.Name = "barCode";
            this.barCode.Size = new System.Drawing.Size(358, 188);
            this.barCode.TabIndex = 52;
            this.barCode.TabStop = false;
            // 
            // koheZgjatjaValue
            // 
            this.koheZgjatjaValue.AutoSize = true;
            this.koheZgjatjaValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.koheZgjatjaValue.ForeColor = System.Drawing.Color.Gold;
            this.koheZgjatjaValue.Location = new System.Drawing.Point(922, 362);
            this.koheZgjatjaValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.koheZgjatjaValue.Name = "koheZgjatjaValue";
            this.koheZgjatjaValue.Size = new System.Drawing.Size(79, 29);
            this.koheZgjatjaValue.TabIndex = 51;
            this.koheZgjatjaValue.Text = "label2";
            // 
            // klientiLabel
            // 
            this.klientiLabel.AutoSize = true;
            this.klientiLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klientiLabel.ForeColor = System.Drawing.Color.Gold;
            this.klientiLabel.Location = new System.Drawing.Point(630, 357);
            this.klientiLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.klientiLabel.Name = "klientiLabel";
            this.klientiLabel.Size = new System.Drawing.Size(150, 29);
            this.klientiLabel.TabIndex = 50;
            this.klientiLabel.Text = "Kohezgjatja";
            // 
            // pikePostareMberritjeValue
            // 
            this.pikePostareMberritjeValue.AutoSize = true;
            this.pikePostareMberritjeValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pikePostareMberritjeValue.ForeColor = System.Drawing.Color.Gold;
            this.pikePostareMberritjeValue.Location = new System.Drawing.Point(922, 297);
            this.pikePostareMberritjeValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pikePostareMberritjeValue.Name = "pikePostareMberritjeValue";
            this.pikePostareMberritjeValue.Size = new System.Drawing.Size(79, 29);
            this.pikePostareMberritjeValue.TabIndex = 49;
            this.pikePostareMberritjeValue.Text = "label2";
            // 
            // zoneMbulimiLabel
            // 
            this.zoneMbulimiLabel.AutoSize = true;
            this.zoneMbulimiLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zoneMbulimiLabel.ForeColor = System.Drawing.Color.Gold;
            this.zoneMbulimiLabel.Location = new System.Drawing.Point(630, 292);
            this.zoneMbulimiLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.zoneMbulimiLabel.Name = "zoneMbulimiLabel";
            this.zoneMbulimiLabel.Size = new System.Drawing.Size(117, 29);
            this.zoneMbulimiLabel.TabIndex = 48;
            this.zoneMbulimiLabel.Text = "Mberritja";
            // 
            // pikePostareNisjeValue
            // 
            this.pikePostareNisjeValue.AutoSize = true;
            this.pikePostareNisjeValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pikePostareNisjeValue.ForeColor = System.Drawing.Color.Gold;
            this.pikePostareNisjeValue.Location = new System.Drawing.Point(922, 237);
            this.pikePostareNisjeValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pikePostareNisjeValue.Name = "pikePostareNisjeValue";
            this.pikePostareNisjeValue.Size = new System.Drawing.Size(79, 29);
            this.pikePostareNisjeValue.TabIndex = 47;
            this.pikePostareNisjeValue.Text = "label2";
            // 
            // pikePostareLabel
            // 
            this.pikePostareLabel.AutoSize = true;
            this.pikePostareLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pikePostareLabel.ForeColor = System.Drawing.Color.Gold;
            this.pikePostareLabel.Location = new System.Drawing.Point(630, 231);
            this.pikePostareLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pikePostareLabel.Name = "pikePostareLabel";
            this.pikePostareLabel.Size = new System.Drawing.Size(73, 29);
            this.pikePostareLabel.TabIndex = 46;
            this.pikePostareLabel.Text = "Nisja";
            // 
            // statusValue
            // 
            this.statusValue.AutoSize = true;
            this.statusValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusValue.ForeColor = System.Drawing.Color.Gold;
            this.statusValue.Location = new System.Drawing.Point(922, 177);
            this.statusValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.statusValue.Name = "statusValue";
            this.statusValue.Size = new System.Drawing.Size(79, 29);
            this.statusValue.TabIndex = 45;
            this.statusValue.Text = "label2";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.ForeColor = System.Drawing.Color.Gold;
            this.statusLabel.Location = new System.Drawing.Point(630, 171);
            this.statusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(85, 29);
            this.statusLabel.TabIndex = 44;
            this.statusLabel.Text = "Status";
            // 
            // transportuesValue
            // 
            this.transportuesValue.AutoSize = true;
            this.transportuesValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transportuesValue.ForeColor = System.Drawing.Color.Gold;
            this.transportuesValue.Location = new System.Drawing.Point(922, 118);
            this.transportuesValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.transportuesValue.Name = "transportuesValue";
            this.transportuesValue.Size = new System.Drawing.Size(79, 29);
            this.transportuesValue.TabIndex = 43;
            this.transportuesValue.Text = "label1";
            // 
            // pakoNumberValue
            // 
            this.pakoNumberValue.AutoSize = true;
            this.pakoNumberValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pakoNumberValue.ForeColor = System.Drawing.Color.Gold;
            this.pakoNumberValue.Location = new System.Drawing.Point(922, 58);
            this.pakoNumberValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pakoNumberValue.Name = "pakoNumberValue";
            this.pakoNumberValue.Size = new System.Drawing.Size(79, 29);
            this.pakoNumberValue.TabIndex = 42;
            this.pakoNumberValue.Text = "label3";
            // 
            // sportelistLabel
            // 
            this.sportelistLabel.AutoSize = true;
            this.sportelistLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sportelistLabel.ForeColor = System.Drawing.Color.Gold;
            this.sportelistLabel.Location = new System.Drawing.Point(630, 114);
            this.sportelistLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.sportelistLabel.Name = "sportelistLabel";
            this.sportelistLabel.Size = new System.Drawing.Size(175, 29);
            this.sportelistLabel.TabIndex = 41;
            this.sportelistLabel.Text = "Transportuesi";
            // 
            // orderNumberLabel
            // 
            this.orderNumberLabel.AutoSize = true;
            this.orderNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderNumberLabel.ForeColor = System.Drawing.Color.Gold;
            this.orderNumberLabel.Location = new System.Drawing.Point(630, 58);
            this.orderNumberLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.orderNumberLabel.Name = "orderNumberLabel";
            this.orderNumberLabel.Size = new System.Drawing.Size(72, 29);
            this.orderNumberLabel.TabIndex = 40;
            this.orderNumberLabel.Text = "Pako";
            // 
            // priorityCheckbox
            // 
            this.priorityCheckbox.AutoSize = true;
            this.priorityCheckbox.ForeColor = System.Drawing.Color.Gold;
            this.priorityCheckbox.Location = new System.Drawing.Point(272, 66);
            this.priorityCheckbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.priorityCheckbox.Name = "priorityCheckbox";
            this.priorityCheckbox.Size = new System.Drawing.Size(82, 24);
            this.priorityCheckbox.TabIndex = 54;
            this.priorityCheckbox.Text = "Priority";
            this.priorityCheckbox.UseVisualStyleBackColor = true;
            this.priorityCheckbox.CheckedChanged += new System.EventHandler(this.priorityCheckbox_CheckedChanged);
            // 
            // AddPako
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.Controls.Add(this.priorityCheckbox);
            this.Controls.Add(this.barCode);
            this.Controls.Add(this.koheZgjatjaValue);
            this.Controls.Add(this.klientiLabel);
            this.Controls.Add(this.pikePostareMberritjeValue);
            this.Controls.Add(this.zoneMbulimiLabel);
            this.Controls.Add(this.pikePostareNisjeValue);
            this.Controls.Add(this.pikePostareLabel);
            this.Controls.Add(this.statusValue);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.transportuesValue);
            this.Controls.Add(this.pakoNumberValue);
            this.Controls.Add(this.sportelistLabel);
            this.Controls.Add(this.orderNumberLabel);
            this.Controls.Add(this.createPakoButton);
            this.Controls.Add(this.removePorosiButton);
            this.Controls.Add(this.pakoListBox);
            this.Controls.Add(this.addToPakoButton);
            this.Controls.Add(this.porosiListBox);
            this.Controls.Add(this.pikePostareComboBox);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Gold;
            this.Name = "AddPako";
            this.Size = new System.Drawing.Size(1222, 905);
            this.Load += new System.EventHandler(this.AddPako_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox pikePostareComboBox;
        private System.Windows.Forms.ListBox porosiListBox;
        private System.Windows.Forms.Button addToPakoButton;
        private System.Windows.Forms.ListBox pakoListBox;
        private System.Windows.Forms.Button removePorosiButton;
        private System.Windows.Forms.Button createPakoButton;
        private System.Windows.Forms.PictureBox barCode;
        private System.Windows.Forms.Label koheZgjatjaValue;
        private System.Windows.Forms.Label klientiLabel;
        private System.Windows.Forms.Label pikePostareMberritjeValue;
        private System.Windows.Forms.Label zoneMbulimiLabel;
        private System.Windows.Forms.Label pikePostareNisjeValue;
        private System.Windows.Forms.Label pikePostareLabel;
        private System.Windows.Forms.Label statusValue;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label transportuesValue;
        private System.Windows.Forms.Label pakoNumberValue;
        private System.Windows.Forms.Label sportelistLabel;
        private System.Windows.Forms.Label orderNumberLabel;
        private System.Windows.Forms.CheckBox priorityCheckbox;
    }
}

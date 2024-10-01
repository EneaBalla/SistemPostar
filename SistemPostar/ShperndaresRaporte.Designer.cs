namespace SistemPostar
{
    partial class ShperndaresRaporte
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
            this.fromDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toDate = new System.Windows.Forms.DateTimePicker();
            this.shfaqButton = new System.Windows.Forms.Button();
            this.porosiTeDorezuaraLabel = new System.Windows.Forms.Label();
            this.porosiTeKthyera = new System.Windows.Forms.Label();
            this.klientiNukKaKthyerPergjigje = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // fromDate
            // 
            this.fromDate.Location = new System.Drawing.Point(86, 72);
            this.fromDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fromDate.Name = "fromDate";
            this.fromDate.Size = new System.Drawing.Size(224, 26);
            this.fromDate.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Navy;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(82, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "From:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Navy;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gold;
            this.label2.Location = new System.Drawing.Point(378, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 33);
            this.label2.TabIndex = 3;
            this.label2.Text = "To:";
            // 
            // toDate
            // 
            this.toDate.Location = new System.Drawing.Point(381, 72);
            this.toDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.toDate.Name = "toDate";
            this.toDate.Size = new System.Drawing.Size(224, 26);
            this.toDate.TabIndex = 2;
            // 
            // shfaqButton
            // 
            this.shfaqButton.BackColor = System.Drawing.Color.Navy;
            this.shfaqButton.ForeColor = System.Drawing.Color.Gold;
            this.shfaqButton.Location = new System.Drawing.Point(654, 52);
            this.shfaqButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.shfaqButton.Name = "shfaqButton";
            this.shfaqButton.Size = new System.Drawing.Size(111, 48);
            this.shfaqButton.TabIndex = 4;
            this.shfaqButton.Text = "Shfaq";
            this.shfaqButton.UseVisualStyleBackColor = false;
            this.shfaqButton.Click += new System.EventHandler(this.shfaqButton_Click);
            // 
            // porosiTeDorezuaraLabel
            // 
            this.porosiTeDorezuaraLabel.AutoSize = true;
            this.porosiTeDorezuaraLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.porosiTeDorezuaraLabel.Location = new System.Drawing.Point(83, 180);
            this.porosiTeDorezuaraLabel.Name = "porosiTeDorezuaraLabel";
            this.porosiTeDorezuaraLabel.Size = new System.Drawing.Size(0, 29);
            this.porosiTeDorezuaraLabel.TabIndex = 5;
            // 
            // porosiTeKthyera
            // 
            this.porosiTeKthyera.AutoSize = true;
            this.porosiTeKthyera.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.porosiTeKthyera.Location = new System.Drawing.Point(83, 258);
            this.porosiTeKthyera.Name = "porosiTeKthyera";
            this.porosiTeKthyera.Size = new System.Drawing.Size(0, 29);
            this.porosiTeKthyera.TabIndex = 6;
            // 
            // klientiNukKaKthyerPergjigje
            // 
            this.klientiNukKaKthyerPergjigje.AutoSize = true;
            this.klientiNukKaKthyerPergjigje.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klientiNukKaKthyerPergjigje.Location = new System.Drawing.Point(82, 329);
            this.klientiNukKaKthyerPergjigje.Name = "klientiNukKaKthyerPergjigje";
            this.klientiNukKaKthyerPergjigje.Size = new System.Drawing.Size(0, 29);
            this.klientiNukKaKthyerPergjigje.TabIndex = 7;
            // 
            // ShperndaresRaporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.Controls.Add(this.klientiNukKaKthyerPergjigje);
            this.Controls.Add(this.porosiTeKthyera);
            this.Controls.Add(this.porosiTeDorezuaraLabel);
            this.Controls.Add(this.shfaqButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.toDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fromDate);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ShperndaresRaporte";
            this.Size = new System.Drawing.Size(966, 734);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker fromDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker toDate;
        private System.Windows.Forms.Button shfaqButton;
        private System.Windows.Forms.Label porosiTeDorezuaraLabel;
        private System.Windows.Forms.Label porosiTeKthyera;
        private System.Windows.Forms.Label klientiNukKaKthyerPergjigje;
    }
}

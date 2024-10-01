namespace SistemPostar
{
    partial class PakoList
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
            this.pakoGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.pikaNisjeForm = new System.Windows.Forms.ComboBox();
            this.pikaMberritjesForm = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pakoNumberForm = new System.Windows.Forms.TextBox();
            this.pakoStatusForm = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.kohezgjataForm = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.viewButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pakoGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // pakoGridView
            // 
            this.pakoGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pakoGridView.Location = new System.Drawing.Point(0, 384);
            this.pakoGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pakoGridView.Name = "pakoGridView";
            this.pakoGridView.RowHeadersWidth = 51;
            this.pakoGridView.RowTemplate.Height = 24;
            this.pakoGridView.Size = new System.Drawing.Size(1042, 355);
            this.pakoGridView.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Navy;
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(21, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pika e Nisjes";
            // 
            // pikaNisjeForm
            // 
            this.pikaNisjeForm.FormattingEnabled = true;
            this.pikaNisjeForm.Location = new System.Drawing.Point(25, 39);
            this.pikaNisjeForm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pikaNisjeForm.Name = "pikaNisjeForm";
            this.pikaNisjeForm.Size = new System.Drawing.Size(181, 28);
            this.pikaNisjeForm.TabIndex = 2;
            this.pikaNisjeForm.SelectedIndexChanged += new System.EventHandler(this.pikaNisjeForm_SelectedIndexChanged);
            // 
            // pikaMberritjesForm
            // 
            this.pikaMberritjesForm.FormattingEnabled = true;
            this.pikaMberritjesForm.Location = new System.Drawing.Point(251, 39);
            this.pikaMberritjesForm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pikaMberritjesForm.Name = "pikaMberritjesForm";
            this.pikaMberritjesForm.Size = new System.Drawing.Size(181, 28);
            this.pikaMberritjesForm.TabIndex = 4;
            this.pikaMberritjesForm.SelectedIndexChanged += new System.EventHandler(this.pikaMberritjesForm_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Navy;
            this.label2.ForeColor = System.Drawing.Color.Gold;
            this.label2.Location = new System.Drawing.Point(248, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Pika e Mberritjes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Navy;
            this.label3.ForeColor = System.Drawing.Color.Gold;
            this.label3.Location = new System.Drawing.Point(21, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Pako Number";
            // 
            // pakoNumberForm
            // 
            this.pakoNumberForm.Location = new System.Drawing.Point(25, 110);
            this.pakoNumberForm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pakoNumberForm.Name = "pakoNumberForm";
            this.pakoNumberForm.Size = new System.Drawing.Size(181, 26);
            this.pakoNumberForm.TabIndex = 6;
            // 
            // pakoStatusForm
            // 
            this.pakoStatusForm.FormattingEnabled = true;
            this.pakoStatusForm.Location = new System.Drawing.Point(251, 110);
            this.pakoStatusForm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pakoStatusForm.Name = "pakoStatusForm";
            this.pakoStatusForm.Size = new System.Drawing.Size(181, 28);
            this.pakoStatusForm.TabIndex = 8;
            this.pakoStatusForm.SelectedIndexChanged += new System.EventHandler(this.pakoStatusForm_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Navy;
            this.label4.ForeColor = System.Drawing.Color.Gold;
            this.label4.Location = new System.Drawing.Point(248, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Status";
            // 
            // kohezgjataForm
            // 
            this.kohezgjataForm.FormattingEnabled = true;
            this.kohezgjataForm.Location = new System.Drawing.Point(457, 110);
            this.kohezgjataForm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.kohezgjataForm.Name = "kohezgjataForm";
            this.kohezgjataForm.Size = new System.Drawing.Size(181, 28);
            this.kohezgjataForm.TabIndex = 10;
            this.kohezgjataForm.SelectedIndexChanged += new System.EventHandler(this.kohezgjataForm_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Navy;
            this.label5.ForeColor = System.Drawing.Color.Gold;
            this.label5.Location = new System.Drawing.Point(453, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Kohezgjatja";
            // 
            // clearButton
            // 
            this.clearButton.BackColor = System.Drawing.Color.Navy;
            this.clearButton.ForeColor = System.Drawing.Color.Gold;
            this.clearButton.Location = new System.Drawing.Point(25, 224);
            this.clearButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(99, 58);
            this.clearButton.TabIndex = 11;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.Navy;
            this.searchButton.ForeColor = System.Drawing.Color.Gold;
            this.searchButton.Location = new System.Drawing.Point(130, 224);
            this.searchButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(99, 58);
            this.searchButton.TabIndex = 12;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // viewButton
            // 
            this.viewButton.BackColor = System.Drawing.Color.Navy;
            this.viewButton.ForeColor = System.Drawing.Color.Gold;
            this.viewButton.Location = new System.Drawing.Point(25, 319);
            this.viewButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.viewButton.Name = "viewButton";
            this.viewButton.Size = new System.Drawing.Size(99, 58);
            this.viewButton.TabIndex = 13;
            this.viewButton.Text = "View";
            this.viewButton.UseVisualStyleBackColor = false;
            this.viewButton.Click += new System.EventHandler(this.viewButton_Click);
            // 
            // PakoList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.Controls.Add(this.viewButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.kohezgjataForm);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pakoStatusForm);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pakoNumberForm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pikaMberritjesForm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pikaNisjeForm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pakoGridView);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PakoList";
            this.Size = new System.Drawing.Size(1042, 739);
            ((System.ComponentModel.ISupportInitialize)(this.pakoGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView pakoGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox pikaNisjeForm;
        private System.Windows.Forms.ComboBox pikaMberritjesForm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox pakoNumberForm;
        private System.Windows.Forms.ComboBox pakoStatusForm;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox kohezgjataForm;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button viewButton;
    }
}

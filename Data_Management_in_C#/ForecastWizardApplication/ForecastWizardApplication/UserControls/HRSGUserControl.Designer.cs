namespace ForecastWizardApplication.UserControls
{
    partial class HRSGUserControl
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.HRSGHeatRecoveryComBox = new System.Windows.Forms.ComboBox();
            this.txtDuctBurner = new System.Windows.Forms.TextBox();
            this.MaximumDuctBurnerLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxShortName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxLongName = new System.Windows.Forms.TextBox();
            this.HRSGTagsGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.HRSGHeatRecoveryComBox);
            this.groupBox1.Controls.Add(this.txtDuctBurner);
            this.groupBox1.Controls.Add(this.MaximumDuctBurnerLabel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxShortName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxLongName);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(499, 93);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Heat Recovery Steam Generator Attributes";
            // 
            // HRSGHeatRecoveryComBox
            // 
            this.HRSGHeatRecoveryComBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.HRSGHeatRecoveryComBox.FormattingEnabled = true;
            this.HRSGHeatRecoveryComBox.Items.AddRange(new object[] {
            "ft",
            "m"});
            this.HRSGHeatRecoveryComBox.Location = new System.Drawing.Point(287, 64);
            this.HRSGHeatRecoveryComBox.Margin = new System.Windows.Forms.Padding(2);
            this.HRSGHeatRecoveryComBox.Name = "HRSGHeatRecoveryComBox";
            this.HRSGHeatRecoveryComBox.Size = new System.Drawing.Size(50, 21);
            this.HRSGHeatRecoveryComBox.TabIndex = 8;
            // 
            // txtDuctBurner
            // 
            this.txtDuctBurner.Location = new System.Drawing.Point(218, 64);
            this.txtDuctBurner.Margin = new System.Windows.Forms.Padding(2);
            this.txtDuctBurner.Name = "txtDuctBurner";
            this.txtDuctBurner.Size = new System.Drawing.Size(60, 20);
            this.txtDuctBurner.TabIndex = 7;
            this.txtDuctBurner.Text = "7500";
            this.txtDuctBurner.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // MaximumDuctBurnerLabel
            // 
            this.MaximumDuctBurnerLabel.AutoSize = true;
            this.MaximumDuctBurnerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximumDuctBurnerLabel.Location = new System.Drawing.Point(5, 67);
            this.MaximumDuctBurnerLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MaximumDuctBurnerLabel.Name = "MaximumDuctBurnerLabel";
            this.MaximumDuctBurnerLabel.Size = new System.Drawing.Size(207, 13);
            this.MaximumDuctBurnerLabel.TabIndex = 6;
            this.MaximumDuctBurnerLabel.Text = "Maximum Duct Burner Fuel Gas Flow Rate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(284, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Short Name";
            // 
            // textBoxShortName
            // 
            this.textBoxShortName.Location = new System.Drawing.Point(286, 36);
            this.textBoxShortName.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxShortName.Name = "textBoxShortName";
            this.textBoxShortName.Size = new System.Drawing.Size(76, 20);
            this.textBoxShortName.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Long Name";
            // 
            // textBoxLongName
            // 
            this.textBoxLongName.Location = new System.Drawing.Point(5, 36);
            this.textBoxLongName.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxLongName.Name = "textBoxLongName";
            this.textBoxLongName.Size = new System.Drawing.Size(273, 20);
            this.textBoxLongName.TabIndex = 3;
            // 
            // HRSGTagsGroupBox
            // 
            this.HRSGTagsGroupBox.AutoSize = true;
            this.HRSGTagsGroupBox.Location = new System.Drawing.Point(3, 106);
            this.HRSGTagsGroupBox.Name = "HRSGTagsGroupBox";
            this.HRSGTagsGroupBox.Size = new System.Drawing.Size(499, 128);
            this.HRSGTagsGroupBox.TabIndex = 3;
            this.HRSGTagsGroupBox.TabStop = false;
            this.HRSGTagsGroupBox.Text = "Heat Recovery Steam Generator Tags";
            // 
            // HRSGUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.HRSGTagsGroupBox);
            this.Controls.Add(this.groupBox1);
            this.Name = "HRSGUserControl";
            this.Size = new System.Drawing.Size(516, 531);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox txtDuctBurner;
        private System.Windows.Forms.Label MaximumDuctBurnerLabel;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox textBoxShortName;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textBoxLongName;
        public System.Windows.Forms.ComboBox HRSGHeatRecoveryComBox;
        private System.Windows.Forms.GroupBox HRSGTagsGroupBox;
    }
}

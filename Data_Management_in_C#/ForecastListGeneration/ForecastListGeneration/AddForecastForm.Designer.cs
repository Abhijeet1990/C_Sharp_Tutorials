namespace ForecastListGeneration
{
    partial class AddForecastForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AddForecastCancelButton = new System.Windows.Forms.Button();
            this.AddForecastOKButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ShortNameTextBox = new System.Windows.Forms.TextBox();
            this.LongNameTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.AdditionalConditioningCheckBox = new System.Windows.Forms.CheckBox();
            this.SteamPowerAugmentationCheckBox = new System.Windows.Forms.CheckBox();
            this.DuctBurnersCheckBox = new System.Windows.Forms.CheckBox();
            this.PeakFiringCheckBox = new System.Windows.Forms.CheckBox();
            this.CombustionAutoTuningCheckBox = new System.Windows.Forms.CheckBox();
            this.InletAirCoolingCheckBox = new System.Windows.Forms.CheckBox();
            this.InletAirHeatingCheckBox = new System.Windows.Forms.CheckBox();
            this.AntiIcingCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddForecastCancelButton
            // 
            this.AddForecastCancelButton.Location = new System.Drawing.Point(300, 390);
            this.AddForecastCancelButton.Name = "AddForecastCancelButton";
            this.AddForecastCancelButton.Size = new System.Drawing.Size(75, 23);
            this.AddForecastCancelButton.TabIndex = 9;
            this.AddForecastCancelButton.Text = "Cancel";
            this.AddForecastCancelButton.UseVisualStyleBackColor = true;
            // 
            // AddForecastOKButton
            // 
            this.AddForecastOKButton.Location = new System.Drawing.Point(50, 390);
            this.AddForecastOKButton.Name = "AddForecastOKButton";
            this.AddForecastOKButton.Size = new System.Drawing.Size(75, 23);
            this.AddForecastOKButton.TabIndex = 8;
            this.AddForecastOKButton.Text = "OK";
            this.AddForecastOKButton.UseVisualStyleBackColor = true;
            this.AddForecastOKButton.Click += new System.EventHandler(this.AddForecastOKButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.ShortNameTextBox);
            this.groupBox3.Controls.Add(this.LongNameTextBox);
            this.groupBox3.Location = new System.Drawing.Point(13, 280);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(397, 88);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Names";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(299, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Short Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Long Name";
            // 
            // ShortNameTextBox
            // 
            this.ShortNameTextBox.Location = new System.Drawing.Point(299, 53);
            this.ShortNameTextBox.Name = "ShortNameTextBox";
            this.ShortNameTextBox.Size = new System.Drawing.Size(91, 20);
            this.ShortNameTextBox.TabIndex = 1;
            // 
            // LongNameTextBox
            // 
            this.LongNameTextBox.Location = new System.Drawing.Point(9, 53);
            this.LongNameTextBox.Name = "LongNameTextBox";
            this.LongNameTextBox.Size = new System.Drawing.Size(268, 20);
            this.LongNameTextBox.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.AdditionalConditioningCheckBox);
            this.groupBox2.Controls.Add(this.SteamPowerAugmentationCheckBox);
            this.groupBox2.Controls.Add(this.DuctBurnersCheckBox);
            this.groupBox2.Controls.Add(this.PeakFiringCheckBox);
            this.groupBox2.Controls.Add(this.CombustionAutoTuningCheckBox);
            this.groupBox2.Controls.Add(this.InletAirCoolingCheckBox);
            this.groupBox2.Controls.Add(this.InletAirHeatingCheckBox);
            this.groupBox2.Controls.Add(this.AntiIcingCheckBox);
            this.groupBox2.Location = new System.Drawing.Point(13, 83);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(397, 190);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Enhancements";
            // 
            // AdditionalConditioningCheckBox
            // 
            this.AdditionalConditioningCheckBox.AutoSize = true;
            this.AdditionalConditioningCheckBox.Enabled = false;
            this.AdditionalConditioningCheckBox.Location = new System.Drawing.Point(203, 150);
            this.AdditionalConditioningCheckBox.Name = "AdditionalConditioningCheckBox";
            this.AdditionalConditioningCheckBox.Size = new System.Drawing.Size(131, 17);
            this.AdditionalConditioningCheckBox.TabIndex = 15;
            this.AdditionalConditioningCheckBox.Text = "Additional Condensing";
            this.AdditionalConditioningCheckBox.UseVisualStyleBackColor = true;
            // 
            // SteamPowerAugmentationCheckBox
            // 
            this.SteamPowerAugmentationCheckBox.AutoSize = true;
            this.SteamPowerAugmentationCheckBox.Enabled = false;
            this.SteamPowerAugmentationCheckBox.Location = new System.Drawing.Point(6, 150);
            this.SteamPowerAugmentationCheckBox.Name = "SteamPowerAugmentationCheckBox";
            this.SteamPowerAugmentationCheckBox.Size = new System.Drawing.Size(157, 17);
            this.SteamPowerAugmentationCheckBox.TabIndex = 14;
            this.SteamPowerAugmentationCheckBox.Text = "Steam Power Augmentation";
            this.SteamPowerAugmentationCheckBox.UseVisualStyleBackColor = true;
            // 
            // DuctBurnersCheckBox
            // 
            this.DuctBurnersCheckBox.AutoSize = true;
            this.DuctBurnersCheckBox.Enabled = false;
            this.DuctBurnersCheckBox.Location = new System.Drawing.Point(203, 114);
            this.DuctBurnersCheckBox.Name = "DuctBurnersCheckBox";
            this.DuctBurnersCheckBox.Size = new System.Drawing.Size(88, 17);
            this.DuctBurnersCheckBox.TabIndex = 13;
            this.DuctBurnersCheckBox.Text = "Duct Burners";
            this.DuctBurnersCheckBox.UseVisualStyleBackColor = true;
            // 
            // PeakFiringCheckBox
            // 
            this.PeakFiringCheckBox.AutoSize = true;
            this.PeakFiringCheckBox.Enabled = false;
            this.PeakFiringCheckBox.Location = new System.Drawing.Point(6, 114);
            this.PeakFiringCheckBox.Name = "PeakFiringCheckBox";
            this.PeakFiringCheckBox.Size = new System.Drawing.Size(136, 17);
            this.PeakFiringCheckBox.TabIndex = 12;
            this.PeakFiringCheckBox.Text = "Peak Firing (OverFiring)";
            this.PeakFiringCheckBox.UseVisualStyleBackColor = true;
            // 
            // CombustionAutoTuningCheckBox
            // 
            this.CombustionAutoTuningCheckBox.AutoSize = true;
            this.CombustionAutoTuningCheckBox.Enabled = false;
            this.CombustionAutoTuningCheckBox.Location = new System.Drawing.Point(203, 77);
            this.CombustionAutoTuningCheckBox.Name = "CombustionAutoTuningCheckBox";
            this.CombustionAutoTuningCheckBox.Size = new System.Drawing.Size(142, 17);
            this.CombustionAutoTuningCheckBox.TabIndex = 11;
            this.CombustionAutoTuningCheckBox.Text = "Combustion Auto-Tuning";
            this.CombustionAutoTuningCheckBox.UseVisualStyleBackColor = true;
            // 
            // InletAirCoolingCheckBox
            // 
            this.InletAirCoolingCheckBox.AutoSize = true;
            this.InletAirCoolingCheckBox.Enabled = false;
            this.InletAirCoolingCheckBox.Location = new System.Drawing.Point(6, 77);
            this.InletAirCoolingCheckBox.Name = "InletAirCoolingCheckBox";
            this.InletAirCoolingCheckBox.Size = new System.Drawing.Size(98, 17);
            this.InletAirCoolingCheckBox.TabIndex = 10;
            this.InletAirCoolingCheckBox.Text = "Inlet Air cooling";
            this.InletAirCoolingCheckBox.UseVisualStyleBackColor = true;
            // 
            // InletAirHeatingCheckBox
            // 
            this.InletAirHeatingCheckBox.AutoSize = true;
            this.InletAirHeatingCheckBox.Enabled = false;
            this.InletAirHeatingCheckBox.Location = new System.Drawing.Point(203, 39);
            this.InletAirHeatingCheckBox.Name = "InletAirHeatingCheckBox";
            this.InletAirHeatingCheckBox.Size = new System.Drawing.Size(139, 17);
            this.InletAirHeatingCheckBox.TabIndex = 9;
            this.InletAirHeatingCheckBox.Text = "Inlet Air Heating (Glycol)";
            this.InletAirHeatingCheckBox.UseVisualStyleBackColor = true;
            // 
            // AntiIcingCheckBox
            // 
            this.AntiIcingCheckBox.AutoSize = true;
            this.AntiIcingCheckBox.Enabled = false;
            this.AntiIcingCheckBox.Location = new System.Drawing.Point(6, 39);
            this.AntiIcingCheckBox.Name = "AntiIcingCheckBox";
            this.AntiIcingCheckBox.Size = new System.Drawing.Size(164, 17);
            this.AntiIcingCheckBox.TabIndex = 8;
            this.AntiIcingCheckBox.Text = "Anti-Icing (Compressor Bleed)";
            this.AntiIcingCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Location = new System.Drawing.Point(13, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(397, 56);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuration";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(9, 20);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(228, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // AddForecastForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 432);
            this.Controls.Add(this.AddForecastCancelButton);
            this.Controls.Add(this.AddForecastOKButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "AddForecastForm";
            this.Text = "AddForecastForm";
            this.Load += new System.EventHandler(this.AddForecastForm_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddForecastCancelButton;
        private System.Windows.Forms.Button AddForecastOKButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ShortNameTextBox;
        private System.Windows.Forms.TextBox LongNameTextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox AdditionalConditioningCheckBox;
        private System.Windows.Forms.CheckBox SteamPowerAugmentationCheckBox;
        private System.Windows.Forms.CheckBox DuctBurnersCheckBox;
        private System.Windows.Forms.CheckBox PeakFiringCheckBox;
        private System.Windows.Forms.CheckBox CombustionAutoTuningCheckBox;
        private System.Windows.Forms.CheckBox InletAirCoolingCheckBox;
        private System.Windows.Forms.CheckBox InletAirHeatingCheckBox;
        private System.Windows.Forms.CheckBox AntiIcingCheckBox;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.ComboBox comboBox1;
    }
}
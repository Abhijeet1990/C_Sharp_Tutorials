namespace ForecastListGeneration
{
    partial class Form1
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxInletAirCool = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CombustionAutoTuningCheckBox = new System.Windows.Forms.CheckBox();
            this.SPIwithDuctBurners = new System.Windows.Forms.CheckBox();
            this.SteamPowerAugmentation = new System.Windows.Forms.CheckBox();
            this.DuctBurnerCheckBox = new System.Windows.Forms.CheckBox();
            this.PeakFiringCheckBox = new System.Windows.Forms.CheckBox();
            this.InletAirHeating = new System.Windows.Forms.CheckBox();
            this.AntiIcingcheckBox = new System.Windows.Forms.CheckBox();
            this.SeleteForecastButton = new System.Windows.Forms.Button();
            this.AddForecastButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Configuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LongName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShortName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Enhancements = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonAuxLoadTag = new System.Windows.Forms.Button();
            this.textBoxAuxLoadEngUnits = new System.Windows.Forms.TextBox();
            this.textBoxAuxLoadTag = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxGTType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxConfig = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.SaveEnhancementButton = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBoxInletAirCool);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.CombustionAutoTuningCheckBox);
            this.groupBox2.Controls.Add(this.SPIwithDuctBurners);
            this.groupBox2.Controls.Add(this.SteamPowerAugmentation);
            this.groupBox2.Controls.Add(this.DuctBurnerCheckBox);
            this.groupBox2.Controls.Add(this.PeakFiringCheckBox);
            this.groupBox2.Controls.Add(this.InletAirHeating);
            this.groupBox2.Controls.Add(this.AntiIcingcheckBox);
            this.groupBox2.Location = new System.Drawing.Point(23, 132);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(487, 143);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Block Enhancements";
            // 
            // comboBoxInletAirCool
            // 
            this.comboBoxInletAirCool.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxInletAirCool.FormattingEnabled = true;
            this.comboBoxInletAirCool.Items.AddRange(new object[] {
            "None",
            "Evaporative Coolers",
            "Foggers",
            "Chillers",
            "Chillers with Thermal Energy Storage",
            "Wet Compression"});
            this.comboBoxInletAirCool.Location = new System.Drawing.Point(247, 41);
            this.comboBoxInletAirCool.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxInletAirCool.Name = "comboBoxInletAirCool";
            this.comboBoxInletAirCool.Size = new System.Drawing.Size(236, 21);
            this.comboBoxInletAirCool.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(244, 25);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Inlet Air Cooling";
            // 
            // CombustionAutoTuningCheckBox
            // 
            this.CombustionAutoTuningCheckBox.AutoSize = true;
            this.CombustionAutoTuningCheckBox.Location = new System.Drawing.Point(4, 99);
            this.CombustionAutoTuningCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.CombustionAutoTuningCheckBox.Name = "CombustionAutoTuningCheckBox";
            this.CombustionAutoTuningCheckBox.Size = new System.Drawing.Size(142, 17);
            this.CombustionAutoTuningCheckBox.TabIndex = 6;
            this.CombustionAutoTuningCheckBox.Text = "Combustion Auto-Tuning";
            this.CombustionAutoTuningCheckBox.UseVisualStyleBackColor = true;
            // 
            // SPIwithDuctBurners
            // 
            this.SPIwithDuctBurners.AutoSize = true;
            this.SPIwithDuctBurners.Enabled = false;
            this.SPIwithDuctBurners.Location = new System.Drawing.Point(263, 120);
            this.SPIwithDuctBurners.Margin = new System.Windows.Forms.Padding(2);
            this.SPIwithDuctBurners.Name = "SPIwithDuctBurners";
            this.SPIwithDuctBurners.Size = new System.Drawing.Size(134, 17);
            this.SPIwithDuctBurners.TabIndex = 5;
            this.SPIwithDuctBurners.Text = "Only with Duct Burners";
            this.SPIwithDuctBurners.UseVisualStyleBackColor = true;
            // 
            // SteamPowerAugmentation
            // 
            this.SteamPowerAugmentation.AutoSize = true;
            this.SteamPowerAugmentation.Location = new System.Drawing.Point(247, 98);
            this.SteamPowerAugmentation.Margin = new System.Windows.Forms.Padding(2);
            this.SteamPowerAugmentation.Name = "SteamPowerAugmentation";
            this.SteamPowerAugmentation.Size = new System.Drawing.Size(157, 17);
            this.SteamPowerAugmentation.TabIndex = 4;
            this.SteamPowerAugmentation.Text = "Steam Power Augmentation";
            this.SteamPowerAugmentation.UseVisualStyleBackColor = true;
            // 
            // DuctBurnerCheckBox
            // 
            this.DuctBurnerCheckBox.AutoSize = true;
            this.DuctBurnerCheckBox.Location = new System.Drawing.Point(247, 76);
            this.DuctBurnerCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.DuctBurnerCheckBox.Name = "DuctBurnerCheckBox";
            this.DuctBurnerCheckBox.Size = new System.Drawing.Size(88, 17);
            this.DuctBurnerCheckBox.TabIndex = 3;
            this.DuctBurnerCheckBox.Text = "Duct Burners";
            this.DuctBurnerCheckBox.UseVisualStyleBackColor = true;
            this.DuctBurnerCheckBox.CheckedChanged += new System.EventHandler(this.DuctBurnerCheckBox_CheckedChanged);
            // 
            // PeakFiringCheckBox
            // 
            this.PeakFiringCheckBox.AutoSize = true;
            this.PeakFiringCheckBox.Location = new System.Drawing.Point(4, 121);
            this.PeakFiringCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.PeakFiringCheckBox.Name = "PeakFiringCheckBox";
            this.PeakFiringCheckBox.Size = new System.Drawing.Size(79, 17);
            this.PeakFiringCheckBox.TabIndex = 2;
            this.PeakFiringCheckBox.Text = "Peak Firing";
            this.PeakFiringCheckBox.UseVisualStyleBackColor = true;
            // 
            // InletAirHeating
            // 
            this.InletAirHeating.AutoSize = true;
            this.InletAirHeating.Location = new System.Drawing.Point(4, 62);
            this.InletAirHeating.Margin = new System.Windows.Forms.Padding(2);
            this.InletAirHeating.Name = "InletAirHeating";
            this.InletAirHeating.Size = new System.Drawing.Size(139, 17);
            this.InletAirHeating.TabIndex = 1;
            this.InletAirHeating.Text = "Inlet Air Heating (Glycol)";
            this.InletAirHeating.UseVisualStyleBackColor = true;
            // 
            // AntiIcingcheckBox
            // 
            this.AntiIcingcheckBox.AutoSize = true;
            this.AntiIcingcheckBox.Location = new System.Drawing.Point(4, 40);
            this.AntiIcingcheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.AntiIcingcheckBox.Name = "AntiIcingcheckBox";
            this.AntiIcingcheckBox.Size = new System.Drawing.Size(164, 17);
            this.AntiIcingcheckBox.TabIndex = 0;
            this.AntiIcingcheckBox.Text = "Anti-Icing (Compressor Bleed)";
            this.AntiIcingcheckBox.UseVisualStyleBackColor = true;
            // 
            // SeleteForecastButton
            // 
            this.SeleteForecastButton.Location = new System.Drawing.Point(435, 403);
            this.SeleteForecastButton.Name = "SeleteForecastButton";
            this.SeleteForecastButton.Size = new System.Drawing.Size(75, 23);
            this.SeleteForecastButton.TabIndex = 22;
            this.SeleteForecastButton.Text = "Remove";
            this.SeleteForecastButton.UseVisualStyleBackColor = true;
            // 
            // AddForecastButton
            // 
            this.AddForecastButton.Location = new System.Drawing.Point(348, 403);
            this.AddForecastButton.Name = "AddForecastButton";
            this.AddForecastButton.Size = new System.Drawing.Size(75, 23);
            this.AddForecastButton.TabIndex = 21;
            this.AddForecastButton.Text = "Add";
            this.AddForecastButton.UseVisualStyleBackColor = true;
            this.AddForecastButton.Click += new System.EventHandler(this.AddForecastButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Configuration,
            this.LongName,
            this.ShortName,
            this.Enhancements});
            this.dataGridView1.Location = new System.Drawing.Point(23, 442);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(487, 101);
            this.dataGridView1.TabIndex = 20;
            // 
            // Configuration
            // 
            this.Configuration.HeaderText = "Config";
            this.Configuration.Name = "Configuration";
            // 
            // LongName
            // 
            this.LongName.HeaderText = "Long Name";
            this.LongName.Name = "LongName";
            this.LongName.Width = 200;
            // 
            // ShortName
            // 
            this.ShortName.HeaderText = "Short Name";
            this.ShortName.Name = "ShortName";
            // 
            // Enhancements
            // 
            this.Enhancements.HeaderText = "Enhancements";
            this.Enhancements.Name = "Enhancements";
            this.Enhancements.Width = 600;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonAuxLoadTag);
            this.groupBox4.Controls.Add(this.textBoxAuxLoadEngUnits);
            this.groupBox4.Controls.Add(this.textBoxAuxLoadTag);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Location = new System.Drawing.Point(23, 307);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(446, 77);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Block Tags";
            // 
            // buttonAuxLoadTag
            // 
            this.buttonAuxLoadTag.Location = new System.Drawing.Point(406, 22);
            this.buttonAuxLoadTag.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAuxLoadTag.Name = "buttonAuxLoadTag";
            this.buttonAuxLoadTag.Size = new System.Drawing.Size(26, 19);
            this.buttonAuxLoadTag.TabIndex = 8;
            this.buttonAuxLoadTag.Text = "...";
            this.buttonAuxLoadTag.UseVisualStyleBackColor = true;
            // 
            // textBoxAuxLoadEngUnits
            // 
            this.textBoxAuxLoadEngUnits.Location = new System.Drawing.Point(327, 22);
            this.textBoxAuxLoadEngUnits.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxAuxLoadEngUnits.Name = "textBoxAuxLoadEngUnits";
            this.textBoxAuxLoadEngUnits.Size = new System.Drawing.Size(76, 20);
            this.textBoxAuxLoadEngUnits.TabIndex = 7;
            // 
            // textBoxAuxLoadTag
            // 
            this.textBoxAuxLoadTag.Location = new System.Drawing.Point(126, 22);
            this.textBoxAuxLoadTag.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxAuxLoadTag.Name = "textBoxAuxLoadTag";
            this.textBoxAuxLoadTag.Size = new System.Drawing.Size(198, 20);
            this.textBoxAuxLoadTag.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(13, 24);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Auxiliary Load";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxGTType);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBoxConfig);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(22, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(488, 116);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Block Attributes";
            // 
            // comboBoxGTType
            // 
            this.comboBoxGTType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGTType.FormattingEnabled = true;
            this.comboBoxGTType.Items.AddRange(new object[] {
            "Alstom GT24",
            "Alstom GT26",
            "General Electric 7FA",
            "General Electric 9FA",
            "Mitsubishi 501F",
            "Mitsubishi 501G",
            "Mitsubishi 501GAC",
            "Mitsubishi 701F",
            "Mitsubishi 701G",
            "Mitsubishi 701GAC",
            "Siemens Westinghouse 501F",
            "Siemens Westinghouse 501G",
            "Siemens Westinghouse 701F",
            "Siemens Westinghouse 701G"});
            this.comboBoxGTType.Location = new System.Drawing.Point(261, 83);
            this.comboBoxGTType.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxGTType.Name = "comboBoxGTType";
            this.comboBoxGTType.Size = new System.Drawing.Size(214, 21);
            this.comboBoxGTType.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(258, 67);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Gas Turbine Type";
            // 
            // comboBoxConfig
            // 
            this.comboBoxConfig.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxConfig.FormattingEnabled = true;
            this.comboBoxConfig.Items.AddRange(new object[] {
            "Simple Cycle Gas Turbine",
            "1X1 Single Shaft Combined Cycle",
            "1X1 Multi-Shaft Combined Cycle",
            "2X1 Multi-Shaft Combined Cycle",
            "3X1 Multi-Shaft Combined Cycle",
            ""});
            this.comboBoxConfig.Location = new System.Drawing.Point(7, 84);
            this.comboBoxConfig.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxConfig.Name = "comboBoxConfig";
            this.comboBoxConfig.Size = new System.Drawing.Size(236, 21);
            this.comboBoxConfig.TabIndex = 3;
            this.comboBoxConfig.SelectedIndexChanged += new System.EventHandler(this.comboBoxConfig_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 67);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Configuration";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(7, 39);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(236, 20);
            this.textBoxName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(13, 389);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(510, 166);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Base Load and Heat Rate Forecasts";
            // 
            // SaveEnhancementButton
            // 
            this.SaveEnhancementButton.Location = new System.Drawing.Point(401, 280);
            this.SaveEnhancementButton.Name = "SaveEnhancementButton";
            this.SaveEnhancementButton.Size = new System.Drawing.Size(109, 23);
            this.SaveEnhancementButton.TabIndex = 24;
            this.SaveEnhancementButton.Text = "Save Enhancement";
            this.SaveEnhancementButton.UseVisualStyleBackColor = true;
            this.SaveEnhancementButton.Click += new System.EventHandler(this.SaveEnhancementButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 571);
            this.Controls.Add(this.SaveEnhancementButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.SeleteForecastButton);
            this.Controls.Add(this.AddForecastButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.ComboBox comboBoxInletAirCool;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox CombustionAutoTuningCheckBox;
        private System.Windows.Forms.CheckBox SPIwithDuctBurners;
        private System.Windows.Forms.CheckBox SteamPowerAugmentation;
        private System.Windows.Forms.CheckBox DuctBurnerCheckBox;
        private System.Windows.Forms.CheckBox PeakFiringCheckBox;
        private System.Windows.Forms.CheckBox InletAirHeating;
        private System.Windows.Forms.CheckBox AntiIcingcheckBox;
        private System.Windows.Forms.Button SeleteForecastButton;
        private System.Windows.Forms.Button AddForecastButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Configuration;
        private System.Windows.Forms.DataGridViewTextBoxColumn LongName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShortName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Enhancements;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonAuxLoadTag;
        public System.Windows.Forms.TextBox textBoxAuxLoadEngUnits;
        public System.Windows.Forms.TextBox textBoxAuxLoadTag;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.ComboBox comboBoxGTType;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox comboBoxConfig;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button SaveEnhancementButton;
        public System.Windows.Forms.DataGridView dataGridView1;
    }
}


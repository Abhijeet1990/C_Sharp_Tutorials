namespace ForecastWizardApplication
{
    partial class BlockUserControl
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
            this.BlockTagsGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxInletAirCool = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CombustionAutoTuningCheckBox = new System.Windows.Forms.CheckBox();
            this.SPIWithDBCheckBox = new System.Windows.Forms.CheckBox();
            this.SPIWithoutDBCheckBox = new System.Windows.Forms.CheckBox();
            this.DuctBurnerCheckBox = new System.Windows.Forms.CheckBox();
            this.PeakFiringCheckBox = new System.Windows.Forms.CheckBox();
            this.InletAirHeatingCheckBox = new System.Windows.Forms.CheckBox();
            this.AntiIcingCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxGTType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxConfig = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Configuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewImageColumn();
            this.LongName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShortName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Enhancements = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddForecastButton = new System.Windows.Forms.Button();
            this.DeleteForecastButton = new System.Windows.Forms.Button();
            this.ForecastGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.ForecastGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // BlockTagsGroupBox
            // 
            this.BlockTagsGroupBox.AutoSize = true;
            this.BlockTagsGroupBox.Location = new System.Drawing.Point(9, 270);
            this.BlockTagsGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.BlockTagsGroupBox.Name = "BlockTagsGroupBox";
            this.BlockTagsGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.BlockTagsGroupBox.Size = new System.Drawing.Size(521, 54);
            this.BlockTagsGroupBox.TabIndex = 12;
            this.BlockTagsGroupBox.TabStop = false;
            this.BlockTagsGroupBox.Text = "Block Tags";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBoxInletAirCool);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.CombustionAutoTuningCheckBox);
            this.groupBox2.Controls.Add(this.SPIWithDBCheckBox);
            this.groupBox2.Controls.Add(this.SPIWithoutDBCheckBox);
            this.groupBox2.Controls.Add(this.DuctBurnerCheckBox);
            this.groupBox2.Controls.Add(this.PeakFiringCheckBox);
            this.groupBox2.Controls.Add(this.InletAirHeatingCheckBox);
            this.groupBox2.Controls.Add(this.AntiIcingCheckBox);
            this.groupBox2.Location = new System.Drawing.Point(13, 123);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(517, 143);
            this.groupBox2.TabIndex = 11;
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
            this.comboBoxInletAirCool.Location = new System.Drawing.Point(260, 34);
            this.comboBoxInletAirCool.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxInletAirCool.Name = "comboBoxInletAirCool";
            this.comboBoxInletAirCool.Size = new System.Drawing.Size(236, 21);
            this.comboBoxInletAirCool.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(257, 18);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Inlet Air Cooling";
            // 
            // CombustionAutoTuningCheckBox
            // 
            this.CombustionAutoTuningCheckBox.AutoSize = true;
            this.CombustionAutoTuningCheckBox.Location = new System.Drawing.Point(17, 92);
            this.CombustionAutoTuningCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.CombustionAutoTuningCheckBox.Name = "CombustionAutoTuningCheckBox";
            this.CombustionAutoTuningCheckBox.Size = new System.Drawing.Size(142, 17);
            this.CombustionAutoTuningCheckBox.TabIndex = 6;
            this.CombustionAutoTuningCheckBox.Text = "Combustion Auto-Tuning";
            this.CombustionAutoTuningCheckBox.UseVisualStyleBackColor = true;
            this.CombustionAutoTuningCheckBox.CheckedChanged += new System.EventHandler(this.OncheckBox3_CheckedChanged);
            // 
            // SPIWithDBCheckBox
            // 
            this.SPIWithDBCheckBox.AutoSize = true;
            this.SPIWithDBCheckBox.Enabled = false;
            this.SPIWithDBCheckBox.Location = new System.Drawing.Point(276, 113);
            this.SPIWithDBCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.SPIWithDBCheckBox.Name = "SPIWithDBCheckBox";
            this.SPIWithDBCheckBox.Size = new System.Drawing.Size(134, 17);
            this.SPIWithDBCheckBox.TabIndex = 5;
            this.SPIWithDBCheckBox.Text = "Only with Duct Burners";
            this.SPIWithDBCheckBox.UseVisualStyleBackColor = true;
            this.SPIWithDBCheckBox.CheckedChanged += new System.EventHandler(this.OncheckBox7_CheckedChanged);
            // 
            // SPIWithoutDBCheckBox
            // 
            this.SPIWithoutDBCheckBox.AutoSize = true;
            this.SPIWithoutDBCheckBox.Location = new System.Drawing.Point(260, 91);
            this.SPIWithoutDBCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.SPIWithoutDBCheckBox.Name = "SPIWithoutDBCheckBox";
            this.SPIWithoutDBCheckBox.Size = new System.Drawing.Size(157, 17);
            this.SPIWithoutDBCheckBox.TabIndex = 4;
            this.SPIWithoutDBCheckBox.Text = "Steam Power Augmentation";
            this.SPIWithoutDBCheckBox.UseVisualStyleBackColor = true;
            this.SPIWithoutDBCheckBox.CheckedChanged += new System.EventHandler(this.OncheckBox6_CheckedChanged);
            // 
            // DuctBurnerCheckBox
            // 
            this.DuctBurnerCheckBox.AutoSize = true;
            this.DuctBurnerCheckBox.Location = new System.Drawing.Point(260, 69);
            this.DuctBurnerCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.DuctBurnerCheckBox.Name = "DuctBurnerCheckBox";
            this.DuctBurnerCheckBox.Size = new System.Drawing.Size(88, 17);
            this.DuctBurnerCheckBox.TabIndex = 3;
            this.DuctBurnerCheckBox.Text = "Duct Burners";
            this.DuctBurnerCheckBox.UseVisualStyleBackColor = true;
            this.DuctBurnerCheckBox.CheckedChanged += new System.EventHandler(this.OncheckBox5_CheckedChanged);
            // 
            // PeakFiringCheckBox
            // 
            this.PeakFiringCheckBox.AutoSize = true;
            this.PeakFiringCheckBox.Location = new System.Drawing.Point(17, 114);
            this.PeakFiringCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.PeakFiringCheckBox.Name = "PeakFiringCheckBox";
            this.PeakFiringCheckBox.Size = new System.Drawing.Size(79, 17);
            this.PeakFiringCheckBox.TabIndex = 2;
            this.PeakFiringCheckBox.Text = "Peak Firing";
            this.PeakFiringCheckBox.UseVisualStyleBackColor = true;
            this.PeakFiringCheckBox.CheckedChanged += new System.EventHandler(this.OncheckBox4_CheckedChanged);
            // 
            // InletAirHeatingCheckBox
            // 
            this.InletAirHeatingCheckBox.AutoSize = true;
            this.InletAirHeatingCheckBox.Location = new System.Drawing.Point(17, 55);
            this.InletAirHeatingCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.InletAirHeatingCheckBox.Name = "InletAirHeatingCheckBox";
            this.InletAirHeatingCheckBox.Size = new System.Drawing.Size(139, 17);
            this.InletAirHeatingCheckBox.TabIndex = 1;
            this.InletAirHeatingCheckBox.Text = "Inlet Air Heating (Glycol)";
            this.InletAirHeatingCheckBox.UseVisualStyleBackColor = true;
            this.InletAirHeatingCheckBox.CheckedChanged += new System.EventHandler(this.OncheckBox2_CheckedChanged);
            // 
            // AntiIcingCheckBox
            // 
            this.AntiIcingCheckBox.AutoSize = true;
            this.AntiIcingCheckBox.Location = new System.Drawing.Point(17, 33);
            this.AntiIcingCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.AntiIcingCheckBox.Name = "AntiIcingCheckBox";
            this.AntiIcingCheckBox.Size = new System.Drawing.Size(164, 17);
            this.AntiIcingCheckBox.TabIndex = 0;
            this.AntiIcingCheckBox.Text = "Anti-Icing (Compressor Bleed)";
            this.AntiIcingCheckBox.UseVisualStyleBackColor = true;
            this.AntiIcingCheckBox.CheckedChanged += new System.EventHandler(this.OncheckBox1_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxGTType);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBoxConfig);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(518, 116);
            this.groupBox1.TabIndex = 10;
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
            this.comboBoxGTType.Location = new System.Drawing.Point(277, 75);
            this.comboBoxGTType.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxGTType.Name = "comboBoxGTType";
            this.comboBoxGTType.Size = new System.Drawing.Size(214, 21);
            this.comboBoxGTType.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(274, 59);
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
            this.comboBoxConfig.Location = new System.Drawing.Point(18, 76);
            this.comboBoxConfig.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxConfig.Name = "comboBoxConfig";
            this.comboBoxConfig.Size = new System.Drawing.Size(236, 21);
            this.comboBoxConfig.TabIndex = 3;
            this.comboBoxConfig.SelectedIndexChanged += new System.EventHandler(this.comboBoxConfig_SelectedIndexChanged_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 59);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Configuration";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(18, 31);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(236, 20);
            this.textBoxName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Configuration,
            this.Status,
            this.LongName,
            this.ShortName,
            this.Enhancements});
            this.dataGridView1.Location = new System.Drawing.Point(6, 48);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(518, 101);
            this.dataGridView1.TabIndex = 13;
            // 
            // Configuration
            // 
            this.Configuration.HeaderText = "Config";
            this.Configuration.Name = "Configuration";
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
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
            this.Enhancements.Width = 400;
            // 
            // AddForecastButton
            // 
            this.AddForecastButton.Location = new System.Drawing.Point(329, 19);
            this.AddForecastButton.Name = "AddForecastButton";
            this.AddForecastButton.Size = new System.Drawing.Size(75, 23);
            this.AddForecastButton.TabIndex = 14;
            this.AddForecastButton.Text = "Add";
            this.AddForecastButton.UseVisualStyleBackColor = true;
            this.AddForecastButton.Click += new System.EventHandler(this.AddForecastButton_Click);
            // 
            // DeleteForecastButton
            // 
            this.DeleteForecastButton.Location = new System.Drawing.Point(415, 19);
            this.DeleteForecastButton.Name = "DeleteForecastButton";
            this.DeleteForecastButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteForecastButton.TabIndex = 15;
            this.DeleteForecastButton.Text = "Remove";
            this.DeleteForecastButton.UseVisualStyleBackColor = true;
            this.DeleteForecastButton.Click += new System.EventHandler(this.DeleteForecastButton_Click);
            // 
            // ForecastGroupBox
            // 
            this.ForecastGroupBox.AutoSize = true;
            this.ForecastGroupBox.Controls.Add(this.AddForecastButton);
            this.ForecastGroupBox.Controls.Add(this.dataGridView1);
            this.ForecastGroupBox.Controls.Add(this.DeleteForecastButton);
            this.ForecastGroupBox.Location = new System.Drawing.Point(6, 353);
            this.ForecastGroupBox.Name = "ForecastGroupBox";
            this.ForecastGroupBox.Size = new System.Drawing.Size(534, 168);
            this.ForecastGroupBox.TabIndex = 16;
            this.ForecastGroupBox.TabStop = false;
            this.ForecastGroupBox.Text = "Base Load and Heat Rate Forecasts";
            this.ForecastGroupBox.Visible = false;
            // 
            // BlockUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.BlockTagsGroupBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ForecastGroupBox);
            this.Name = "BlockUserControl";
            this.Size = new System.Drawing.Size(557, 598);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ForecastGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox BlockTagsGroupBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox CombustionAutoTuningCheckBox;
        private System.Windows.Forms.CheckBox SPIWithDBCheckBox;
        private System.Windows.Forms.CheckBox SPIWithoutDBCheckBox;
        private System.Windows.Forms.CheckBox DuctBurnerCheckBox;
        private System.Windows.Forms.CheckBox PeakFiringCheckBox;
        private System.Windows.Forms.CheckBox InletAirHeatingCheckBox;
        private System.Windows.Forms.CheckBox AntiIcingCheckBox;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.ComboBox comboBoxGTType;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox comboBoxConfig;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AddForecastButton;
        private System.Windows.Forms.Button DeleteForecastButton;
        private System.Windows.Forms.GroupBox ForecastGroupBox;
        public System.Windows.Forms.ComboBox comboBoxInletAirCool;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Configuration;
        private System.Windows.Forms.DataGridViewImageColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn LongName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShortName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Enhancements;
    }
}

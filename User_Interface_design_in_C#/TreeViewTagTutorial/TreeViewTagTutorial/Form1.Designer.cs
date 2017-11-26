namespace TreeViewTagTutorial
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
            this.HighHeatingCheckBox = new System.Windows.Forms.CheckBox();
            this.UseMetricUnitsCheckBox = new System.Windows.Forms.CheckBox();
            this.GridFrequencyComboBox = new System.Windows.Forms.ComboBox();
            this.GasTurbineTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SiteAcronymTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.HeatRateUnitsComboBox = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.TimezoneComboBox = new System.Windows.Forms.ComboBox();
            this.SiteElevationTextBox = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.SiteLongitudeTextBox = new System.Windows.Forms.TextBox();
            this.SiteLatitudeTextBox = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.SiteLocationTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SiteName = new System.Windows.Forms.Label();
            this.SiteNameTextBox = new System.Windows.Forms.TextBox();
            this.BlockCount = new System.Windows.Forms.Label();
            this.BlockCountComboBox = new System.Windows.Forms.ComboBox();
            this.AddSiteButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.TraverseTree = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // HighHeatingCheckBox
            // 
            this.HighHeatingCheckBox.AutoSize = true;
            this.HighHeatingCheckBox.Location = new System.Drawing.Point(366, 270);
            this.HighHeatingCheckBox.Name = "HighHeatingCheckBox";
            this.HighHeatingCheckBox.Size = new System.Drawing.Size(118, 17);
            this.HighHeatingCheckBox.TabIndex = 123;
            this.HighHeatingCheckBox.Text = "High Heating Value";
            this.HighHeatingCheckBox.UseVisualStyleBackColor = true;
            // 
            // UseMetricUnitsCheckBox
            // 
            this.UseMetricUnitsCheckBox.AutoSize = true;
            this.UseMetricUnitsCheckBox.Location = new System.Drawing.Point(366, 293);
            this.UseMetricUnitsCheckBox.Name = "UseMetricUnitsCheckBox";
            this.UseMetricUnitsCheckBox.Size = new System.Drawing.Size(108, 17);
            this.UseMetricUnitsCheckBox.TabIndex = 122;
            this.UseMetricUnitsCheckBox.Text = "*Use Metric Units";
            this.UseMetricUnitsCheckBox.UseVisualStyleBackColor = true;
            // 
            // GridFrequencyComboBox
            // 
            this.GridFrequencyComboBox.FormattingEnabled = true;
            this.GridFrequencyComboBox.Items.AddRange(new object[] {
            "50",
            "60"});
            this.GridFrequencyComboBox.Location = new System.Drawing.Point(175, 291);
            this.GridFrequencyComboBox.Name = "GridFrequencyComboBox";
            this.GridFrequencyComboBox.Size = new System.Drawing.Size(121, 21);
            this.GridFrequencyComboBox.TabIndex = 121;
            // 
            // GasTurbineTypeComboBox
            // 
            this.GasTurbineTypeComboBox.FormattingEnabled = true;
            this.GasTurbineTypeComboBox.Location = new System.Drawing.Point(175, 251);
            this.GasTurbineTypeComboBox.Name = "GasTurbineTypeComboBox";
            this.GasTurbineTypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.GasTurbineTypeComboBox.TabIndex = 120;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(51, 291);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 119;
            this.label7.Text = "*Grid Frequency";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 254);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 118;
            this.label5.Text = "*Gas Turbine Type";
            // 
            // SiteAcronymTextBox
            // 
            this.SiteAcronymTextBox.Location = new System.Drawing.Point(314, 57);
            this.SiteAcronymTextBox.Name = "SiteAcronymTextBox";
            this.SiteAcronymTextBox.Size = new System.Drawing.Size(100, 20);
            this.SiteAcronymTextBox.TabIndex = 117;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(260, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 116;
            this.label1.Text = "*Acronym";
            // 
            // HeatRateUnitsComboBox
            // 
            this.HeatRateUnitsComboBox.FormattingEnabled = true;
            this.HeatRateUnitsComboBox.Items.AddRange(new object[] {
            "kJ/kWh",
            "MMBTU/MWh"});
            this.HeatRateUnitsComboBox.Location = new System.Drawing.Point(397, 211);
            this.HeatRateUnitsComboBox.Name = "HeatRateUnitsComboBox";
            this.HeatRateUnitsComboBox.Size = new System.Drawing.Size(121, 21);
            this.HeatRateUnitsComboBox.TabIndex = 115;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(308, 214);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(87, 13);
            this.label26.TabIndex = 114;
            this.label26.Text = "*Heat Rate Units";
            // 
            // TimezoneComboBox
            // 
            this.TimezoneComboBox.FormattingEnabled = true;
            this.TimezoneComboBox.Location = new System.Drawing.Point(129, 170);
            this.TimezoneComboBox.Name = "TimezoneComboBox";
            this.TimezoneComboBox.Size = new System.Drawing.Size(169, 21);
            this.TimezoneComboBox.TabIndex = 113;
            // 
            // SiteElevationTextBox
            // 
            this.SiteElevationTextBox.Location = new System.Drawing.Point(129, 133);
            this.SiteElevationTextBox.Name = "SiteElevationTextBox";
            this.SiteElevationTextBox.Size = new System.Drawing.Size(75, 20);
            this.SiteElevationTextBox.TabIndex = 112;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(51, 173);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(62, 13);
            this.label24.TabIndex = 111;
            this.label24.Text = "*Time Zone";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(51, 136);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(55, 13);
            this.label23.TabIndex = 110;
            this.label23.Text = "*Elevation";
            // 
            // SiteLongitudeTextBox
            // 
            this.SiteLongitudeTextBox.Location = new System.Drawing.Point(423, 88);
            this.SiteLongitudeTextBox.Name = "SiteLongitudeTextBox";
            this.SiteLongitudeTextBox.Size = new System.Drawing.Size(75, 20);
            this.SiteLongitudeTextBox.TabIndex = 109;
            // 
            // SiteLatitudeTextBox
            // 
            this.SiteLatitudeTextBox.Location = new System.Drawing.Point(286, 91);
            this.SiteLatitudeTextBox.Name = "SiteLatitudeTextBox";
            this.SiteLatitudeTextBox.Size = new System.Drawing.Size(71, 20);
            this.SiteLatitudeTextBox.TabIndex = 108;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(363, 94);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(58, 13);
            this.label22.TabIndex = 107;
            this.label22.Text = "*Longitude";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(235, 95);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(49, 13);
            this.label21.TabIndex = 106;
            this.label21.Text = "*Latitude";
            // 
            // SiteLocationTextBox
            // 
            this.SiteLocationTextBox.Location = new System.Drawing.Point(129, 92);
            this.SiteLocationTextBox.Name = "SiteLocationTextBox";
            this.SiteLocationTextBox.Size = new System.Drawing.Size(100, 20);
            this.SiteLocationTextBox.TabIndex = 105;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 104;
            this.label3.Text = "*Location";
            // 
            // SiteName
            // 
            this.SiteName.AutoSize = true;
            this.SiteName.Location = new System.Drawing.Point(51, 60);
            this.SiteName.Name = "SiteName";
            this.SiteName.Size = new System.Drawing.Size(60, 13);
            this.SiteName.TabIndex = 101;
            this.SiteName.Text = "*Site Name";
            // 
            // SiteNameTextBox
            // 
            this.SiteNameTextBox.Location = new System.Drawing.Point(129, 57);
            this.SiteNameTextBox.Name = "SiteNameTextBox";
            this.SiteNameTextBox.Size = new System.Drawing.Size(117, 20);
            this.SiteNameTextBox.TabIndex = 100;
            // 
            // BlockCount
            // 
            this.BlockCount.AutoSize = true;
            this.BlockCount.Location = new System.Drawing.Point(51, 214);
            this.BlockCount.Name = "BlockCount";
            this.BlockCount.Size = new System.Drawing.Size(72, 13);
            this.BlockCount.TabIndex = 102;
            this.BlockCount.Text = "*No of Blocks";
            // 
            // BlockCountComboBox
            // 
            this.BlockCountComboBox.FormattingEnabled = true;
            this.BlockCountComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.BlockCountComboBox.Location = new System.Drawing.Point(129, 206);
            this.BlockCountComboBox.Name = "BlockCountComboBox";
            this.BlockCountComboBox.Size = new System.Drawing.Size(121, 21);
            this.BlockCountComboBox.TabIndex = 103;
            // 
            // AddSiteButton
            // 
            this.AddSiteButton.Location = new System.Drawing.Point(366, 332);
            this.AddSiteButton.Name = "AddSiteButton";
            this.AddSiteButton.Size = new System.Drawing.Size(75, 23);
            this.AddSiteButton.TabIndex = 124;
            this.AddSiteButton.Text = "Add Site";
            this.AddSiteButton.UseVisualStyleBackColor = true;
            this.AddSiteButton.Click += new System.EventHandler(this.AddSiteButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(469, 332);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 125;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // TraverseTree
            // 
            this.TraverseTree.Location = new System.Drawing.Point(601, 1);
            this.TraverseTree.Name = "TraverseTree";
            this.TraverseTree.Size = new System.Drawing.Size(208, 370);
            this.TraverseTree.TabIndex = 127;
            this.TraverseTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TraverseTree_NodeMouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 369);
            this.Controls.Add(this.TraverseTree);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.AddSiteButton);
            this.Controls.Add(this.HighHeatingCheckBox);
            this.Controls.Add(this.UseMetricUnitsCheckBox);
            this.Controls.Add(this.GridFrequencyComboBox);
            this.Controls.Add(this.GasTurbineTypeComboBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.SiteAcronymTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.HeatRateUnitsComboBox);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.TimezoneComboBox);
            this.Controls.Add(this.SiteElevationTextBox);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.SiteLongitudeTextBox);
            this.Controls.Add(this.SiteLatitudeTextBox);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.SiteLocationTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SiteName);
            this.Controls.Add(this.SiteNameTextBox);
            this.Controls.Add(this.BlockCount);
            this.Controls.Add(this.BlockCountComboBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox HighHeatingCheckBox;
        private System.Windows.Forms.CheckBox UseMetricUnitsCheckBox;
        private System.Windows.Forms.ComboBox GridFrequencyComboBox;
        private System.Windows.Forms.ComboBox GasTurbineTypeComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox SiteAcronymTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox HeatRateUnitsComboBox;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ComboBox TimezoneComboBox;
        private System.Windows.Forms.TextBox SiteElevationTextBox;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox SiteLongitudeTextBox;
        private System.Windows.Forms.TextBox SiteLatitudeTextBox;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox SiteLocationTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label SiteName;
        private System.Windows.Forms.TextBox SiteNameTextBox;
        private System.Windows.Forms.Label BlockCount;
        private System.Windows.Forms.ComboBox BlockCountComboBox;
        private System.Windows.Forms.Button AddSiteButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.TreeView TraverseTree;
    }
}


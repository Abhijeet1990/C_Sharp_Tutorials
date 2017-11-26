namespace TreeViewApproach
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
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Site");
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.WizardTree = new System.Windows.Forms.TreeView();
            this.SiteTabControl = new System.Windows.Forms.TabControl();
            this.SitePage = new System.Windows.Forms.TabPage();
            this.SiteAcronymTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.UseMetricUnitsCheckBox = new System.Windows.Forms.CheckBox();
            this.AddSiteButton = new System.Windows.Forms.Button();
            this.SiteNameTextBox = new System.Windows.Forms.TextBox();
            this.HighHeatingCheckBox = new System.Windows.Forms.CheckBox();
            this.HeatRateComboBox = new System.Windows.Forms.ComboBox();
            this.HeatRateUnitLabel = new System.Windows.Forms.Label();
            this.TimezoneComboBox = new System.Windows.Forms.ComboBox();
            this.ElevationTextBox = new System.Windows.Forms.TextBox();
            this.TimezoneLabel = new System.Windows.Forms.Label();
            this.EDlevationLabel = new System.Windows.Forms.Label();
            this.LongitudeTextBox = new System.Windows.Forms.TextBox();
            this.LatitudeTextBox = new System.Windows.Forms.TextBox();
            this.LongitudeLabel = new System.Windows.Forms.Label();
            this.LatitudeLabel = new System.Windows.Forms.Label();
            this.GridFrequencyComboBox = new System.Windows.Forms.ComboBox();
            this.GasTurbinetypeComboBox = new System.Windows.Forms.ComboBox();
            this.BlockCountComboBox = new System.Windows.Forms.ComboBox();
            this.LocationTextBox = new System.Windows.Forms.TextBox();
            this.GridFrequencyLabel = new System.Windows.Forms.Label();
            this.GasTurbineType = new System.Windows.Forms.Label();
            this.BlockCountLabel = new System.Windows.Forms.Label();
            this.LocationLabel = new System.Windows.Forms.Label();
            this.SiteNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SiteTabControl.SuspendLayout();
            this.SitePage.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.WizardTree);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.SiteTabControl);
            this.splitContainer1.Size = new System.Drawing.Size(761, 442);
            this.splitContainer1.SplitterDistance = 215;
            this.splitContainer1.TabIndex = 0;
            // 
            // WizardTree
            // 
            this.WizardTree.Location = new System.Drawing.Point(3, 3);
            this.WizardTree.Name = "WizardTree";
            treeNode2.Name = "Site";
            treeNode2.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode2.Text = "Site";
            this.WizardTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.WizardTree.Size = new System.Drawing.Size(209, 435);
            this.WizardTree.TabIndex = 0;
            this.WizardTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.WizardTree_NodeMouseClick);
            // 
            // SiteTabControl
            // 
            this.SiteTabControl.Controls.Add(this.SitePage);
            this.SiteTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SiteTabControl.Location = new System.Drawing.Point(0, 0);
            this.SiteTabControl.Name = "SiteTabControl";
            this.SiteTabControl.SelectedIndex = 0;
            this.SiteTabControl.Size = new System.Drawing.Size(542, 442);
            this.SiteTabControl.TabIndex = 0;
            // 
            // SitePage
            // 
            this.SitePage.BackColor = System.Drawing.Color.PowderBlue;
            this.SitePage.Controls.Add(this.SiteAcronymTextBox);
            this.SitePage.Controls.Add(this.label1);
            this.SitePage.Controls.Add(this.UseMetricUnitsCheckBox);
            this.SitePage.Controls.Add(this.AddSiteButton);
            this.SitePage.Controls.Add(this.SiteNameTextBox);
            this.SitePage.Controls.Add(this.HighHeatingCheckBox);
            this.SitePage.Controls.Add(this.HeatRateComboBox);
            this.SitePage.Controls.Add(this.HeatRateUnitLabel);
            this.SitePage.Controls.Add(this.TimezoneComboBox);
            this.SitePage.Controls.Add(this.ElevationTextBox);
            this.SitePage.Controls.Add(this.TimezoneLabel);
            this.SitePage.Controls.Add(this.EDlevationLabel);
            this.SitePage.Controls.Add(this.LongitudeTextBox);
            this.SitePage.Controls.Add(this.LatitudeTextBox);
            this.SitePage.Controls.Add(this.LongitudeLabel);
            this.SitePage.Controls.Add(this.LatitudeLabel);
            this.SitePage.Controls.Add(this.GridFrequencyComboBox);
            this.SitePage.Controls.Add(this.GasTurbinetypeComboBox);
            this.SitePage.Controls.Add(this.BlockCountComboBox);
            this.SitePage.Controls.Add(this.LocationTextBox);
            this.SitePage.Controls.Add(this.GridFrequencyLabel);
            this.SitePage.Controls.Add(this.GasTurbineType);
            this.SitePage.Controls.Add(this.BlockCountLabel);
            this.SitePage.Controls.Add(this.LocationLabel);
            this.SitePage.Controls.Add(this.SiteNameLabel);
            this.SitePage.Location = new System.Drawing.Point(4, 22);
            this.SitePage.Name = "SitePage";
            this.SitePage.Padding = new System.Windows.Forms.Padding(3);
            this.SitePage.Size = new System.Drawing.Size(534, 416);
            this.SitePage.TabIndex = 1;
            this.SitePage.Text = "Site";
            // 
            // SiteAcronymTextBox
            // 
            this.SiteAcronymTextBox.Location = new System.Drawing.Point(372, 51);
            this.SiteAcronymTextBox.Name = "SiteAcronymTextBox";
            this.SiteAcronymTextBox.Size = new System.Drawing.Size(100, 20);
            this.SiteAcronymTextBox.TabIndex = 99;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(282, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 98;
            this.label1.Text = "*Site Acronym";
            // 
            // UseMetricUnitsCheckBox
            // 
            this.UseMetricUnitsCheckBox.AutoSize = true;
            this.UseMetricUnitsCheckBox.Location = new System.Drawing.Point(317, 255);
            this.UseMetricUnitsCheckBox.Name = "UseMetricUnitsCheckBox";
            this.UseMetricUnitsCheckBox.Size = new System.Drawing.Size(104, 17);
            this.UseMetricUnitsCheckBox.TabIndex = 97;
            this.UseMetricUnitsCheckBox.Text = "Use Metric Units";
            this.UseMetricUnitsCheckBox.UseVisualStyleBackColor = true;
            // 
            // AddSiteButton
            // 
            this.AddSiteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddSiteButton.Location = new System.Drawing.Point(397, 338);
            this.AddSiteButton.Name = "AddSiteButton";
            this.AddSiteButton.Size = new System.Drawing.Size(114, 34);
            this.AddSiteButton.TabIndex = 96;
            this.AddSiteButton.Text = "Add Site";
            this.AddSiteButton.UseVisualStyleBackColor = true;
            this.AddSiteButton.Click += new System.EventHandler(this.AddSiteButton_Click);
            // 
            // SiteNameTextBox
            // 
            this.SiteNameTextBox.Location = new System.Drawing.Point(139, 51);
            this.SiteNameTextBox.Name = "SiteNameTextBox";
            this.SiteNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.SiteNameTextBox.TabIndex = 95;
            // 
            // HighHeatingCheckBox
            // 
            this.HighHeatingCheckBox.AutoSize = true;
            this.HighHeatingCheckBox.Location = new System.Drawing.Point(317, 218);
            this.HighHeatingCheckBox.Name = "HighHeatingCheckBox";
            this.HighHeatingCheckBox.Size = new System.Drawing.Size(118, 17);
            this.HighHeatingCheckBox.TabIndex = 94;
            this.HighHeatingCheckBox.Text = "High Heating Value";
            this.HighHeatingCheckBox.UseVisualStyleBackColor = true;
            // 
            // HeatRateComboBox
            // 
            this.HeatRateComboBox.FormattingEnabled = true;
            this.HeatRateComboBox.Items.AddRange(new object[] {
            "kJ/kWh",
            "MMBTU/MWh"});
            this.HeatRateComboBox.Location = new System.Drawing.Point(403, 173);
            this.HeatRateComboBox.Name = "HeatRateComboBox";
            this.HeatRateComboBox.Size = new System.Drawing.Size(121, 21);
            this.HeatRateComboBox.TabIndex = 93;
            // 
            // HeatRateUnitLabel
            // 
            this.HeatRateUnitLabel.AutoSize = true;
            this.HeatRateUnitLabel.Location = new System.Drawing.Point(314, 180);
            this.HeatRateUnitLabel.Name = "HeatRateUnitLabel";
            this.HeatRateUnitLabel.Size = new System.Drawing.Size(83, 13);
            this.HeatRateUnitLabel.TabIndex = 92;
            this.HeatRateUnitLabel.Text = "Heat Rate Units";
            // 
            // TimezoneComboBox
            // 
            this.TimezoneComboBox.FormattingEnabled = true;
            this.TimezoneComboBox.Location = new System.Drawing.Point(139, 173);
            this.TimezoneComboBox.Name = "TimezoneComboBox";
            this.TimezoneComboBox.Size = new System.Drawing.Size(169, 21);
            this.TimezoneComboBox.TabIndex = 91;
            // 
            // ElevationTextBox
            // 
            this.ElevationTextBox.Location = new System.Drawing.Point(139, 131);
            this.ElevationTextBox.Name = "ElevationTextBox";
            this.ElevationTextBox.Size = new System.Drawing.Size(75, 20);
            this.ElevationTextBox.TabIndex = 90;
            // 
            // TimezoneLabel
            // 
            this.TimezoneLabel.AutoSize = true;
            this.TimezoneLabel.Location = new System.Drawing.Point(15, 180);
            this.TimezoneLabel.Name = "TimezoneLabel";
            this.TimezoneLabel.Size = new System.Drawing.Size(58, 13);
            this.TimezoneLabel.TabIndex = 89;
            this.TimezoneLabel.Text = "Time Zone";
            // 
            // EDlevationLabel
            // 
            this.EDlevationLabel.AutoSize = true;
            this.EDlevationLabel.Location = new System.Drawing.Point(15, 138);
            this.EDlevationLabel.Name = "EDlevationLabel";
            this.EDlevationLabel.Size = new System.Drawing.Size(51, 13);
            this.EDlevationLabel.TabIndex = 88;
            this.EDlevationLabel.Text = "Elevation";
            // 
            // LongitudeTextBox
            // 
            this.LongitudeTextBox.Location = new System.Drawing.Point(397, 95);
            this.LongitudeTextBox.Name = "LongitudeTextBox";
            this.LongitudeTextBox.Size = new System.Drawing.Size(75, 20);
            this.LongitudeTextBox.TabIndex = 87;
            // 
            // LatitudeTextBox
            // 
            this.LatitudeTextBox.Location = new System.Drawing.Point(285, 95);
            this.LatitudeTextBox.Name = "LatitudeTextBox";
            this.LatitudeTextBox.Size = new System.Drawing.Size(71, 20);
            this.LatitudeTextBox.TabIndex = 86;
            // 
            // LongitudeLabel
            // 
            this.LongitudeLabel.AutoSize = true;
            this.LongitudeLabel.Location = new System.Drawing.Point(362, 98);
            this.LongitudeLabel.Name = "LongitudeLabel";
            this.LongitudeLabel.Size = new System.Drawing.Size(31, 13);
            this.LongitudeLabel.TabIndex = 85;
            this.LongitudeLabel.Text = "Long";
            // 
            // LatitudeLabel
            // 
            this.LatitudeLabel.AutoSize = true;
            this.LatitudeLabel.Location = new System.Drawing.Point(257, 98);
            this.LatitudeLabel.Name = "LatitudeLabel";
            this.LatitudeLabel.Size = new System.Drawing.Size(22, 13);
            this.LatitudeLabel.TabIndex = 84;
            this.LatitudeLabel.Text = "Lat";
            // 
            // GridFrequencyComboBox
            // 
            this.GridFrequencyComboBox.FormattingEnabled = true;
            this.GridFrequencyComboBox.Items.AddRange(new object[] {
            "50",
            "60"});
            this.GridFrequencyComboBox.Location = new System.Drawing.Point(139, 296);
            this.GridFrequencyComboBox.Name = "GridFrequencyComboBox";
            this.GridFrequencyComboBox.Size = new System.Drawing.Size(121, 21);
            this.GridFrequencyComboBox.TabIndex = 83;
            // 
            // GasTurbinetypeComboBox
            // 
            this.GasTurbinetypeComboBox.FormattingEnabled = true;
            this.GasTurbinetypeComboBox.Items.AddRange(new object[] {
            "GT24",
            "7FA",
            "M501F",
            "M501G",
            "M501GAC",
            "W501F",
            "W501G"});
            this.GasTurbinetypeComboBox.Location = new System.Drawing.Point(139, 256);
            this.GasTurbinetypeComboBox.Name = "GasTurbinetypeComboBox";
            this.GasTurbinetypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.GasTurbinetypeComboBox.TabIndex = 82;
            // 
            // BlockCountComboBox
            // 
            this.BlockCountComboBox.FormattingEnabled = true;
            this.BlockCountComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.BlockCountComboBox.Location = new System.Drawing.Point(139, 214);
            this.BlockCountComboBox.Name = "BlockCountComboBox";
            this.BlockCountComboBox.Size = new System.Drawing.Size(121, 21);
            this.BlockCountComboBox.TabIndex = 81;
            this.BlockCountComboBox.SelectedIndexChanged += new System.EventHandler(this.BlockCountComboBox_SelectedIndexChanged_1);
            // 
            // LocationTextBox
            // 
            this.LocationTextBox.Location = new System.Drawing.Point(139, 95);
            this.LocationTextBox.Name = "LocationTextBox";
            this.LocationTextBox.Size = new System.Drawing.Size(100, 20);
            this.LocationTextBox.TabIndex = 80;
            // 
            // GridFrequencyLabel
            // 
            this.GridFrequencyLabel.AutoSize = true;
            this.GridFrequencyLabel.Location = new System.Drawing.Point(15, 296);
            this.GridFrequencyLabel.Name = "GridFrequencyLabel";
            this.GridFrequencyLabel.Size = new System.Drawing.Size(79, 13);
            this.GridFrequencyLabel.TabIndex = 79;
            this.GridFrequencyLabel.Text = "Grid Frequency";
            // 
            // GasTurbineType
            // 
            this.GasTurbineType.AutoSize = true;
            this.GasTurbineType.Location = new System.Drawing.Point(15, 259);
            this.GasTurbineType.Name = "GasTurbineType";
            this.GasTurbineType.Size = new System.Drawing.Size(96, 13);
            this.GasTurbineType.TabIndex = 78;
            this.GasTurbineType.Text = "*Gas Turbine Type";
            // 
            // BlockCountLabel
            // 
            this.BlockCountLabel.AutoSize = true;
            this.BlockCountLabel.Location = new System.Drawing.Point(15, 217);
            this.BlockCountLabel.Name = "BlockCountLabel";
            this.BlockCountLabel.Size = new System.Drawing.Size(72, 13);
            this.BlockCountLabel.TabIndex = 77;
            this.BlockCountLabel.Text = "*No of Blocks";
            // 
            // LocationLabel
            // 
            this.LocationLabel.AutoSize = true;
            this.LocationLabel.Location = new System.Drawing.Point(15, 98);
            this.LocationLabel.Name = "LocationLabel";
            this.LocationLabel.Size = new System.Drawing.Size(48, 13);
            this.LocationLabel.TabIndex = 76;
            this.LocationLabel.Text = "Location";
            // 
            // SiteNameLabel
            // 
            this.SiteNameLabel.AutoSize = true;
            this.SiteNameLabel.Location = new System.Drawing.Point(15, 59);
            this.SiteNameLabel.Name = "SiteNameLabel";
            this.SiteNameLabel.Size = new System.Drawing.Size(60, 13);
            this.SiteNameLabel.TabIndex = 75;
            this.SiteNameLabel.Text = "*Site Name";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 442);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.SiteTabControl.ResumeLayout(false);
            this.SitePage.ResumeLayout(false);
            this.SitePage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl SiteTabControl;
        private System.Windows.Forms.TabPage SitePage;
        private System.Windows.Forms.CheckBox HighHeatingCheckBox;
        private System.Windows.Forms.ComboBox HeatRateComboBox;
        private System.Windows.Forms.Label HeatRateUnitLabel;
        private System.Windows.Forms.ComboBox TimezoneComboBox;
        private System.Windows.Forms.TextBox ElevationTextBox;
        private System.Windows.Forms.Label TimezoneLabel;
        private System.Windows.Forms.Label EDlevationLabel;
        private System.Windows.Forms.TextBox LongitudeTextBox;
        private System.Windows.Forms.TextBox LatitudeTextBox;
        private System.Windows.Forms.Label LongitudeLabel;
        private System.Windows.Forms.Label LatitudeLabel;
        private System.Windows.Forms.ComboBox GridFrequencyComboBox;
        private System.Windows.Forms.ComboBox GasTurbinetypeComboBox;
        private System.Windows.Forms.ComboBox BlockCountComboBox;
        private System.Windows.Forms.TextBox LocationTextBox;
        private System.Windows.Forms.Label GridFrequencyLabel;
        private System.Windows.Forms.Label GasTurbineType;
        private System.Windows.Forms.Label BlockCountLabel;
        private System.Windows.Forms.Label LocationLabel;
        private System.Windows.Forms.Label SiteNameLabel;
        public System.Windows.Forms.TextBox SiteNameTextBox;
        public System.Windows.Forms.TextBox SiteAcronymTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox UseMetricUnitsCheckBox;
        private System.Windows.Forms.Button AddSiteButton;
        public System.Windows.Forms.TreeView WizardTree;
    }
}


namespace FormTransitionStatus
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.SitePage = new System.Windows.Forms.TabPage();
            this.BlockPage = new System.Windows.Forms.TabPage();
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
            this.button1 = new System.Windows.Forms.Button();
            this.GridFrequencyComboBox = new System.Windows.Forms.ComboBox();
            this.GasTurbinetypeComboBox = new System.Windows.Forms.ComboBox();
            this.BlockCountComboBox = new System.Windows.Forms.ComboBox();
            this.LocationTextBox = new System.Windows.Forms.TextBox();
            this.GridFrequencyLabel = new System.Windows.Forms.Label();
            this.GasTurbineType = new System.Windows.Forms.Label();
            this.BlockCountLabel = new System.Windows.Forms.Label();
            this.LocationLabel = new System.Windows.Forms.Label();
            this.SiteNameLabel = new System.Windows.Forms.Label();
            this.LowLoadForecast = new System.Windows.Forms.CheckBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.UnitConfiguration = new System.Windows.Forms.Label();
            this.TES = new System.Windows.Forms.CheckBox();
            this.CompressorMap = new System.Windows.Forms.CheckBox();
            this.HighLoadForecast = new System.Windows.Forms.CheckBox();
            this.label25 = new System.Windows.Forms.Label();
            this.DuctBurners = new System.Windows.Forms.CheckBox();
            this.SteamInjection = new System.Windows.Forms.CheckBox();
            this.PeakFiring = new System.Windows.Forms.CheckBox();
            this.InletAirHeating = new System.Windows.Forms.CheckBox();
            this.InletAirCooling = new System.Windows.Forms.CheckBox();
            this.BlockAliasTextBox = new System.Windows.Forms.TextBox();
            this.BlockAliasLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.BlockTypeLabel = new System.Windows.Forms.Label();
            this.BlockTypeComboBox = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.PlantObjectType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObjectIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.ObjectAlias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObjectType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ConfigureObject = new System.Windows.Forms.DataGridViewButtonColumn();
            this.button4 = new System.Windows.Forms.Button();
            this.ForecastPage = new System.Windows.Forms.TabPage();
            this.VariablePage = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.SitePage.SuspendLayout();
            this.BlockPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.SitePage);
            this.tabControl1.Controls.Add(this.BlockPage);
            this.tabControl1.Controls.Add(this.ForecastPage);
            this.tabControl1.Controls.Add(this.VariablePage);
            this.tabControl1.Location = new System.Drawing.Point(12, 85);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(601, 374);
            this.tabControl1.TabIndex = 52;
            // 
            // SitePage
            // 
            this.SitePage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.SitePage.Controls.Add(this.textBox1);
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
            this.SitePage.Controls.Add(this.button1);
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
            this.SitePage.Size = new System.Drawing.Size(593, 348);
            this.SitePage.TabIndex = 0;
            this.SitePage.Text = "Site";
            // 
            // BlockPage
            // 
            this.BlockPage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BlockPage.Controls.Add(this.button4);
            this.BlockPage.Controls.Add(this.LowLoadForecast);
            this.BlockPage.Controls.Add(this.comboBox4);
            this.BlockPage.Controls.Add(this.UnitConfiguration);
            this.BlockPage.Controls.Add(this.TES);
            this.BlockPage.Controls.Add(this.CompressorMap);
            this.BlockPage.Controls.Add(this.HighLoadForecast);
            this.BlockPage.Controls.Add(this.label25);
            this.BlockPage.Controls.Add(this.DuctBurners);
            this.BlockPage.Controls.Add(this.SteamInjection);
            this.BlockPage.Controls.Add(this.PeakFiring);
            this.BlockPage.Controls.Add(this.InletAirHeating);
            this.BlockPage.Controls.Add(this.InletAirCooling);
            this.BlockPage.Controls.Add(this.BlockAliasTextBox);
            this.BlockPage.Controls.Add(this.BlockAliasLabel);
            this.BlockPage.Controls.Add(this.label6);
            this.BlockPage.Controls.Add(this.BlockTypeLabel);
            this.BlockPage.Controls.Add(this.BlockTypeComboBox);
            this.BlockPage.Controls.Add(this.button3);
            this.BlockPage.Controls.Add(this.button2);
            this.BlockPage.Controls.Add(this.dataGridView2);
            this.BlockPage.Location = new System.Drawing.Point(4, 22);
            this.BlockPage.Name = "BlockPage";
            this.BlockPage.Padding = new System.Windows.Forms.Padding(3);
            this.BlockPage.Size = new System.Drawing.Size(593, 348);
            this.BlockPage.TabIndex = 1;
            this.BlockPage.Text = "Block";
            // 
            // HighHeatingCheckBox
            // 
            this.HighHeatingCheckBox.AutoSize = true;
            this.HighHeatingCheckBox.Location = new System.Drawing.Point(337, 195);
            this.HighHeatingCheckBox.Name = "HighHeatingCheckBox";
            this.HighHeatingCheckBox.Size = new System.Drawing.Size(118, 17);
            this.HighHeatingCheckBox.TabIndex = 73;
            this.HighHeatingCheckBox.Text = "High Heating Value";
            this.HighHeatingCheckBox.UseVisualStyleBackColor = true;
            // 
            // HeatRateComboBox
            // 
            this.HeatRateComboBox.FormattingEnabled = true;
            this.HeatRateComboBox.Items.AddRange(new object[] {
            "kJ/kWh",
            "MMBTU/MWh"});
            this.HeatRateComboBox.Location = new System.Drawing.Point(423, 150);
            this.HeatRateComboBox.Name = "HeatRateComboBox";
            this.HeatRateComboBox.Size = new System.Drawing.Size(121, 21);
            this.HeatRateComboBox.TabIndex = 72;
            // 
            // HeatRateUnitLabel
            // 
            this.HeatRateUnitLabel.AutoSize = true;
            this.HeatRateUnitLabel.Location = new System.Drawing.Point(334, 157);
            this.HeatRateUnitLabel.Name = "HeatRateUnitLabel";
            this.HeatRateUnitLabel.Size = new System.Drawing.Size(83, 13);
            this.HeatRateUnitLabel.TabIndex = 71;
            this.HeatRateUnitLabel.Text = "Heat Rate Units";
            // 
            // TimezoneComboBox
            // 
            this.TimezoneComboBox.FormattingEnabled = true;
            this.TimezoneComboBox.Location = new System.Drawing.Point(159, 150);
            this.TimezoneComboBox.Name = "TimezoneComboBox";
            this.TimezoneComboBox.Size = new System.Drawing.Size(169, 21);
            this.TimezoneComboBox.TabIndex = 69;
            // 
            // ElevationTextBox
            // 
            this.ElevationTextBox.Location = new System.Drawing.Point(159, 108);
            this.ElevationTextBox.Name = "ElevationTextBox";
            this.ElevationTextBox.Size = new System.Drawing.Size(75, 20);
            this.ElevationTextBox.TabIndex = 68;
            // 
            // TimezoneLabel
            // 
            this.TimezoneLabel.AutoSize = true;
            this.TimezoneLabel.Location = new System.Drawing.Point(35, 157);
            this.TimezoneLabel.Name = "TimezoneLabel";
            this.TimezoneLabel.Size = new System.Drawing.Size(58, 13);
            this.TimezoneLabel.TabIndex = 67;
            this.TimezoneLabel.Text = "Time Zone";
            // 
            // EDlevationLabel
            // 
            this.EDlevationLabel.AutoSize = true;
            this.EDlevationLabel.Location = new System.Drawing.Point(35, 115);
            this.EDlevationLabel.Name = "EDlevationLabel";
            this.EDlevationLabel.Size = new System.Drawing.Size(51, 13);
            this.EDlevationLabel.TabIndex = 66;
            this.EDlevationLabel.Text = "Elevation";
            // 
            // LongitudeTextBox
            // 
            this.LongitudeTextBox.Location = new System.Drawing.Point(417, 72);
            this.LongitudeTextBox.Name = "LongitudeTextBox";
            this.LongitudeTextBox.Size = new System.Drawing.Size(75, 20);
            this.LongitudeTextBox.TabIndex = 65;
            // 
            // LatitudeTextBox
            // 
            this.LatitudeTextBox.Location = new System.Drawing.Point(305, 72);
            this.LatitudeTextBox.Name = "LatitudeTextBox";
            this.LatitudeTextBox.Size = new System.Drawing.Size(71, 20);
            this.LatitudeTextBox.TabIndex = 64;
            // 
            // LongitudeLabel
            // 
            this.LongitudeLabel.AutoSize = true;
            this.LongitudeLabel.Location = new System.Drawing.Point(382, 75);
            this.LongitudeLabel.Name = "LongitudeLabel";
            this.LongitudeLabel.Size = new System.Drawing.Size(31, 13);
            this.LongitudeLabel.TabIndex = 63;
            this.LongitudeLabel.Text = "Long";
            // 
            // LatitudeLabel
            // 
            this.LatitudeLabel.AutoSize = true;
            this.LatitudeLabel.Location = new System.Drawing.Point(277, 75);
            this.LatitudeLabel.Name = "LatitudeLabel";
            this.LatitudeLabel.Size = new System.Drawing.Size(22, 13);
            this.LatitudeLabel.TabIndex = 62;
            this.LatitudeLabel.Text = "Lat";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(456, 287);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 61;
            this.button1.Text = "Next >>";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // GridFrequencyComboBox
            // 
            this.GridFrequencyComboBox.FormattingEnabled = true;
            this.GridFrequencyComboBox.Items.AddRange(new object[] {
            "50",
            "60"});
            this.GridFrequencyComboBox.Location = new System.Drawing.Point(159, 273);
            this.GridFrequencyComboBox.Name = "GridFrequencyComboBox";
            this.GridFrequencyComboBox.Size = new System.Drawing.Size(121, 21);
            this.GridFrequencyComboBox.TabIndex = 60;
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
            this.GasTurbinetypeComboBox.Location = new System.Drawing.Point(159, 233);
            this.GasTurbinetypeComboBox.Name = "GasTurbinetypeComboBox";
            this.GasTurbinetypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.GasTurbinetypeComboBox.TabIndex = 59;
            // 
            // BlockCountComboBox
            // 
            this.BlockCountComboBox.FormattingEnabled = true;
            this.BlockCountComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.BlockCountComboBox.Location = new System.Drawing.Point(159, 191);
            this.BlockCountComboBox.Name = "BlockCountComboBox";
            this.BlockCountComboBox.Size = new System.Drawing.Size(121, 21);
            this.BlockCountComboBox.TabIndex = 58;
            // 
            // LocationTextBox
            // 
            this.LocationTextBox.Location = new System.Drawing.Point(159, 72);
            this.LocationTextBox.Name = "LocationTextBox";
            this.LocationTextBox.Size = new System.Drawing.Size(100, 20);
            this.LocationTextBox.TabIndex = 57;
            // 
            // GridFrequencyLabel
            // 
            this.GridFrequencyLabel.AutoSize = true;
            this.GridFrequencyLabel.Location = new System.Drawing.Point(35, 273);
            this.GridFrequencyLabel.Name = "GridFrequencyLabel";
            this.GridFrequencyLabel.Size = new System.Drawing.Size(79, 13);
            this.GridFrequencyLabel.TabIndex = 56;
            this.GridFrequencyLabel.Text = "Grid Frequency";
            // 
            // GasTurbineType
            // 
            this.GasTurbineType.AutoSize = true;
            this.GasTurbineType.Location = new System.Drawing.Point(35, 236);
            this.GasTurbineType.Name = "GasTurbineType";
            this.GasTurbineType.Size = new System.Drawing.Size(96, 13);
            this.GasTurbineType.TabIndex = 55;
            this.GasTurbineType.Text = "*Gas Turbine Type";
            // 
            // BlockCountLabel
            // 
            this.BlockCountLabel.AutoSize = true;
            this.BlockCountLabel.Location = new System.Drawing.Point(35, 194);
            this.BlockCountLabel.Name = "BlockCountLabel";
            this.BlockCountLabel.Size = new System.Drawing.Size(72, 13);
            this.BlockCountLabel.TabIndex = 54;
            this.BlockCountLabel.Text = "*No of Blocks";
            // 
            // LocationLabel
            // 
            this.LocationLabel.AutoSize = true;
            this.LocationLabel.Location = new System.Drawing.Point(35, 75);
            this.LocationLabel.Name = "LocationLabel";
            this.LocationLabel.Size = new System.Drawing.Size(48, 13);
            this.LocationLabel.TabIndex = 53;
            this.LocationLabel.Text = "Location";
            // 
            // SiteNameLabel
            // 
            this.SiteNameLabel.AutoSize = true;
            this.SiteNameLabel.Location = new System.Drawing.Point(35, 36);
            this.SiteNameLabel.Name = "SiteNameLabel";
            this.SiteNameLabel.Size = new System.Drawing.Size(60, 13);
            this.SiteNameLabel.TabIndex = 52;
            this.SiteNameLabel.Text = "*Site Name";
            // 
            // LowLoadForecast
            // 
            this.LowLoadForecast.AutoSize = true;
            this.LowLoadForecast.Location = new System.Drawing.Point(214, 90);
            this.LowLoadForecast.Name = "LowLoadForecast";
            this.LowLoadForecast.Size = new System.Drawing.Size(117, 17);
            this.LowLoadForecast.TabIndex = 43;
            this.LowLoadForecast.Text = "Low Load Forecast";
            this.LowLoadForecast.UseVisualStyleBackColor = true;
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(87, 118);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(80, 21);
            this.comboBox4.TabIndex = 42;
            // 
            // UnitConfiguration
            // 
            this.UnitConfiguration.AutoSize = true;
            this.UnitConfiguration.Location = new System.Drawing.Point(2, 126);
            this.UnitConfiguration.Name = "UnitConfiguration";
            this.UnitConfiguration.Size = new System.Drawing.Size(83, 13);
            this.UnitConfiguration.TabIndex = 41;
            this.UnitConfiguration.Text = "*Configure Units";
            // 
            // TES
            // 
            this.TES.AutoSize = true;
            this.TES.Location = new System.Drawing.Point(439, 90);
            this.TES.Name = "TES";
            this.TES.Size = new System.Drawing.Size(140, 17);
            this.TES.TabIndex = 40;
            this.TES.Text = "Thermal Energy Storage";
            this.TES.UseVisualStyleBackColor = true;
            // 
            // CompressorMap
            // 
            this.CompressorMap.AutoSize = true;
            this.CompressorMap.Location = new System.Drawing.Point(335, 90);
            this.CompressorMap.Name = "CompressorMap";
            this.CompressorMap.Size = new System.Drawing.Size(105, 17);
            this.CompressorMap.TabIndex = 39;
            this.CompressorMap.Text = "Compressor Map";
            this.CompressorMap.UseVisualStyleBackColor = true;
            // 
            // HighLoadForecast
            // 
            this.HighLoadForecast.AutoSize = true;
            this.HighLoadForecast.Location = new System.Drawing.Point(99, 90);
            this.HighLoadForecast.Name = "HighLoadForecast";
            this.HighLoadForecast.Size = new System.Drawing.Size(119, 17);
            this.HighLoadForecast.TabIndex = 38;
            this.HighLoadForecast.Text = "High Load Forecast";
            this.HighLoadForecast.UseVisualStyleBackColor = true;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(2, 91);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(102, 13);
            this.label25.TabIndex = 37;
            this.label25.Text = "Block Functionality: ";
            // 
            // DuctBurners
            // 
            this.DuctBurners.AutoSize = true;
            this.DuctBurners.Location = new System.Drawing.Point(488, 59);
            this.DuctBurners.Name = "DuctBurners";
            this.DuctBurners.Size = new System.Drawing.Size(88, 17);
            this.DuctBurners.TabIndex = 36;
            this.DuctBurners.Text = "Duct Burners";
            this.DuctBurners.UseVisualStyleBackColor = true;
            // 
            // SteamInjection
            // 
            this.SteamInjection.AutoSize = true;
            this.SteamInjection.Location = new System.Drawing.Point(383, 59);
            this.SteamInjection.Name = "SteamInjection";
            this.SteamInjection.Size = new System.Drawing.Size(99, 17);
            this.SteamInjection.TabIndex = 35;
            this.SteamInjection.Text = "Steam Injection";
            this.SteamInjection.UseVisualStyleBackColor = true;
            // 
            // PeakFiring
            // 
            this.PeakFiring.AutoSize = true;
            this.PeakFiring.Location = new System.Drawing.Point(298, 60);
            this.PeakFiring.Name = "PeakFiring";
            this.PeakFiring.Size = new System.Drawing.Size(79, 17);
            this.PeakFiring.TabIndex = 34;
            this.PeakFiring.Text = "Peak Firing";
            this.PeakFiring.UseVisualStyleBackColor = true;
            // 
            // InletAirHeating
            // 
            this.InletAirHeating.AutoSize = true;
            this.InletAirHeating.Location = new System.Drawing.Point(191, 59);
            this.InletAirHeating.Name = "InletAirHeating";
            this.InletAirHeating.Size = new System.Drawing.Size(101, 17);
            this.InletAirHeating.TabIndex = 33;
            this.InletAirHeating.Text = "Inlet Air Heating";
            this.InletAirHeating.UseVisualStyleBackColor = true;
            // 
            // InletAirCooling
            // 
            this.InletAirCooling.AutoSize = true;
            this.InletAirCooling.Location = new System.Drawing.Point(87, 60);
            this.InletAirCooling.Name = "InletAirCooling";
            this.InletAirCooling.Size = new System.Drawing.Size(99, 17);
            this.InletAirCooling.TabIndex = 32;
            this.InletAirCooling.Text = "Inlet Air Cooling";
            this.InletAirCooling.UseVisualStyleBackColor = true;
            // 
            // BlockAliasTextBox
            // 
            this.BlockAliasTextBox.Location = new System.Drawing.Point(335, 26);
            this.BlockAliasTextBox.Name = "BlockAliasTextBox";
            this.BlockAliasTextBox.Size = new System.Drawing.Size(136, 20);
            this.BlockAliasTextBox.TabIndex = 31;
            // 
            // BlockAliasLabel
            // 
            this.BlockAliasLabel.AutoSize = true;
            this.BlockAliasLabel.Location = new System.Drawing.Point(270, 29);
            this.BlockAliasLabel.Name = "BlockAliasLabel";
            this.BlockAliasLabel.Size = new System.Drawing.Size(63, 13);
            this.BlockAliasLabel.TabIndex = 30;
            this.BlockAliasLabel.Text = "*Block Alias";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Block Capability: ";
            // 
            // BlockTypeLabel
            // 
            this.BlockTypeLabel.AutoSize = true;
            this.BlockTypeLabel.Location = new System.Drawing.Point(2, 29);
            this.BlockTypeLabel.Name = "BlockTypeLabel";
            this.BlockTypeLabel.Size = new System.Drawing.Size(65, 13);
            this.BlockTypeLabel.TabIndex = 28;
            this.BlockTypeLabel.Text = "*Block Type";
            // 
            // BlockTypeComboBox
            // 
            this.BlockTypeComboBox.FormattingEnabled = true;
            this.BlockTypeComboBox.Items.AddRange(new object[] {
            "Simple",
            "1 x 1 Single Shaft",
            "1 x 1 Dual Shaft",
            "2 x 1",
            "3 x 1"});
            this.BlockTypeComboBox.Location = new System.Drawing.Point(69, 26);
            this.BlockTypeComboBox.Name = "BlockTypeComboBox";
            this.BlockTypeComboBox.Size = new System.Drawing.Size(175, 21);
            this.BlockTypeComboBox.TabIndex = 27;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(504, 303);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 26;
            this.button3.Text = "Next >>";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(322, 303);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 25;
            this.button2.Text = "Add Block";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PlantObjectType,
            this.ObjectIcon,
            this.ObjectAlias,
            this.ObjectType,
            this.ConfigureObject});
            this.dataGridView2.Location = new System.Drawing.Point(15, 165);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(564, 132);
            this.dataGridView2.TabIndex = 24;
            // 
            // PlantObjectType
            // 
            this.PlantObjectType.HeaderText = "Object Type";
            this.PlantObjectType.Name = "PlantObjectType";
            // 
            // ObjectIcon
            // 
            this.ObjectIcon.HeaderText = "Icon";
            this.ObjectIcon.Name = "ObjectIcon";
            this.ObjectIcon.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ObjectIcon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ObjectIcon.Width = 40;
            // 
            // ObjectAlias
            // 
            this.ObjectAlias.HeaderText = "*Alias";
            this.ObjectAlias.Name = "ObjectAlias";
            this.ObjectAlias.Width = 160;
            // 
            // ObjectType
            // 
            this.ObjectType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.ObjectType.HeaderText = "*Type";
            this.ObjectType.Name = "ObjectType";
            this.ObjectType.Width = 125;
            // 
            // ConfigureObject
            // 
            this.ConfigureObject.HeaderText = "Configure";
            this.ConfigureObject.Name = "ConfigureObject";
            this.ConfigureObject.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(403, 303);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(95, 23);
            this.button4.TabIndex = 44;
            this.button4.Text = "Delete Block";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // ForecastPage
            // 
            this.ForecastPage.Location = new System.Drawing.Point(4, 22);
            this.ForecastPage.Name = "ForecastPage";
            this.ForecastPage.Padding = new System.Windows.Forms.Padding(3);
            this.ForecastPage.Size = new System.Drawing.Size(593, 348);
            this.ForecastPage.TabIndex = 2;
            this.ForecastPage.Text = "Forecast";
            this.ForecastPage.UseVisualStyleBackColor = true;
            // 
            // VariablePage
            // 
            this.VariablePage.Location = new System.Drawing.Point(4, 22);
            this.VariablePage.Name = "VariablePage";
            this.VariablePage.Padding = new System.Windows.Forms.Padding(3);
            this.VariablePage.Size = new System.Drawing.Size(593, 348);
            this.VariablePage.TabIndex = 3;
            this.VariablePage.Text = "Variable";
            this.VariablePage.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(159, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 74;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 471);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.SitePage.ResumeLayout(false);
            this.SitePage.PerformLayout();
            this.BlockPage.ResumeLayout(false);
            this.BlockPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox GridFrequencyComboBox;
        private System.Windows.Forms.ComboBox GasTurbinetypeComboBox;
        private System.Windows.Forms.ComboBox BlockCountComboBox;
        private System.Windows.Forms.TextBox LocationTextBox;
        private System.Windows.Forms.Label GridFrequencyLabel;
        private System.Windows.Forms.Label GasTurbineType;
        private System.Windows.Forms.Label BlockCountLabel;
        private System.Windows.Forms.Label LocationLabel;
        private System.Windows.Forms.Label SiteNameLabel;
        private System.Windows.Forms.TabPage BlockPage;
        private System.Windows.Forms.CheckBox LowLoadForecast;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Label UnitConfiguration;
        private System.Windows.Forms.CheckBox TES;
        private System.Windows.Forms.CheckBox CompressorMap;
        private System.Windows.Forms.CheckBox HighLoadForecast;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.CheckBox DuctBurners;
        private System.Windows.Forms.CheckBox SteamInjection;
        private System.Windows.Forms.CheckBox PeakFiring;
        private System.Windows.Forms.CheckBox InletAirHeating;
        private System.Windows.Forms.CheckBox InletAirCooling;
        private System.Windows.Forms.TextBox BlockAliasTextBox;
        private System.Windows.Forms.Label BlockAliasLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label BlockTypeLabel;
        private System.Windows.Forms.ComboBox BlockTypeComboBox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlantObjectType;
        private System.Windows.Forms.DataGridViewImageColumn ObjectIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObjectAlias;
        private System.Windows.Forms.DataGridViewComboBoxColumn ObjectType;
        private System.Windows.Forms.DataGridViewButtonColumn ConfigureObject;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TabPage ForecastPage;
        private System.Windows.Forms.TabPage VariablePage;
    }
}


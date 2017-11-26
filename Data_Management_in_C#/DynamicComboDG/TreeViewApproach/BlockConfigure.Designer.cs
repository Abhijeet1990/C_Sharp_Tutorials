namespace TreeViewApproach
{
    partial class BlockConfigure
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
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.ConfigureUnitComboBox = new System.Windows.Forms.ComboBox();
            this.UnitConfiguration = new System.Windows.Forms.Label();
            this.TES = new System.Windows.Forms.CheckBox();
            this.CompressorMap = new System.Windows.Forms.CheckBox();
            this.Forecast = new System.Windows.Forms.CheckBox();
            this.label25 = new System.Windows.Forms.Label();
            this.DuctBurners = new System.Windows.Forms.CheckBox();
            this.SteamInjection = new System.Windows.Forms.CheckBox();
            this.PeakFiring = new System.Windows.Forms.CheckBox();
            this.InletAirHeating = new System.Windows.Forms.CheckBox();
            this.InletAirCooling = new System.Windows.Forms.CheckBox();
            this.BlockAliasTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BlockTypeComboBox = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.PlantObjectType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObjectIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.ObjectAlias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConfigureObject = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(135, 151);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(117, 17);
            this.checkBox2.TabIndex = 43;
            this.checkBox2.Text = "Low Load Forecast";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // ConfigureUnitComboBox
            // 
            this.ConfigureUnitComboBox.FormattingEnabled = true;
            this.ConfigureUnitComboBox.Location = new System.Drawing.Point(107, 184);
            this.ConfigureUnitComboBox.Name = "ConfigureUnitComboBox";
            this.ConfigureUnitComboBox.Size = new System.Drawing.Size(80, 21);
            this.ConfigureUnitComboBox.TabIndex = 42;
            // 
            // UnitConfiguration
            // 
            this.UnitConfiguration.AutoSize = true;
            this.UnitConfiguration.Location = new System.Drawing.Point(22, 192);
            this.UnitConfiguration.Name = "UnitConfiguration";
            this.UnitConfiguration.Size = new System.Drawing.Size(83, 13);
            this.UnitConfiguration.TabIndex = 41;
            this.UnitConfiguration.Text = "*Configure Units";
            // 
            // TES
            // 
            this.TES.AutoSize = true;
            this.TES.Location = new System.Drawing.Point(360, 151);
            this.TES.Name = "TES";
            this.TES.Size = new System.Drawing.Size(140, 17);
            this.TES.TabIndex = 40;
            this.TES.Text = "Thermal Energy Storage";
            this.TES.UseVisualStyleBackColor = true;
            this.TES.CheckedChanged += new System.EventHandler(this.TES_CheckedChanged);
            // 
            // CompressorMap
            // 
            this.CompressorMap.AutoSize = true;
            this.CompressorMap.Location = new System.Drawing.Point(256, 151);
            this.CompressorMap.Name = "CompressorMap";
            this.CompressorMap.Size = new System.Drawing.Size(105, 17);
            this.CompressorMap.TabIndex = 39;
            this.CompressorMap.Text = "Compressor Map";
            this.CompressorMap.UseVisualStyleBackColor = true;
            this.CompressorMap.CheckedChanged += new System.EventHandler(this.CompressorMap_CheckedChanged);
            // 
            // Forecast
            // 
            this.Forecast.AutoSize = true;
            this.Forecast.Location = new System.Drawing.Point(20, 151);
            this.Forecast.Name = "Forecast";
            this.Forecast.Size = new System.Drawing.Size(119, 17);
            this.Forecast.TabIndex = 38;
            this.Forecast.Text = "High Load Forecast";
            this.Forecast.UseVisualStyleBackColor = true;
            this.Forecast.CheckedChanged += new System.EventHandler(this.Forecast_CheckedChanged);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(17, 126);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(102, 13);
            this.label25.TabIndex = 37;
            this.label25.Text = "Block Functionality: ";
            // 
            // DuctBurners
            // 
            this.DuctBurners.AutoSize = true;
            this.DuctBurners.Location = new System.Drawing.Point(421, 88);
            this.DuctBurners.Name = "DuctBurners";
            this.DuctBurners.Size = new System.Drawing.Size(88, 17);
            this.DuctBurners.TabIndex = 36;
            this.DuctBurners.Text = "Duct Burners";
            this.DuctBurners.UseVisualStyleBackColor = true;
            this.DuctBurners.CheckedChanged += new System.EventHandler(this.DuctBurners_CheckedChanged);
            // 
            // SteamInjection
            // 
            this.SteamInjection.AutoSize = true;
            this.SteamInjection.Location = new System.Drawing.Point(316, 88);
            this.SteamInjection.Name = "SteamInjection";
            this.SteamInjection.Size = new System.Drawing.Size(99, 17);
            this.SteamInjection.TabIndex = 35;
            this.SteamInjection.Text = "Steam Injection";
            this.SteamInjection.UseVisualStyleBackColor = true;
            this.SteamInjection.CheckedChanged += new System.EventHandler(this.SteamInjection_CheckedChanged);
            // 
            // PeakFiring
            // 
            this.PeakFiring.AutoSize = true;
            this.PeakFiring.Location = new System.Drawing.Point(231, 89);
            this.PeakFiring.Name = "PeakFiring";
            this.PeakFiring.Size = new System.Drawing.Size(79, 17);
            this.PeakFiring.TabIndex = 34;
            this.PeakFiring.Text = "Peak Firing";
            this.PeakFiring.UseVisualStyleBackColor = true;
            this.PeakFiring.CheckedChanged += new System.EventHandler(this.PeakFiring_CheckedChanged);
            // 
            // InletAirHeating
            // 
            this.InletAirHeating.AutoSize = true;
            this.InletAirHeating.Location = new System.Drawing.Point(124, 88);
            this.InletAirHeating.Name = "InletAirHeating";
            this.InletAirHeating.Size = new System.Drawing.Size(101, 17);
            this.InletAirHeating.TabIndex = 33;
            this.InletAirHeating.Text = "Inlet Air Heating";
            this.InletAirHeating.UseVisualStyleBackColor = true;
            this.InletAirHeating.CheckedChanged += new System.EventHandler(this.InletAirHeating_CheckedChanged);
            // 
            // InletAirCooling
            // 
            this.InletAirCooling.AutoSize = true;
            this.InletAirCooling.Location = new System.Drawing.Point(20, 89);
            this.InletAirCooling.Name = "InletAirCooling";
            this.InletAirCooling.Size = new System.Drawing.Size(99, 17);
            this.InletAirCooling.TabIndex = 32;
            this.InletAirCooling.Text = "Inlet Air Cooling";
            this.InletAirCooling.UseVisualStyleBackColor = true;
            this.InletAirCooling.CheckedChanged += new System.EventHandler(this.InletAirCooling_CheckedChanged);
            // 
            // BlockAliasTextBox
            // 
            this.BlockAliasTextBox.Location = new System.Drawing.Point(350, 29);
            this.BlockAliasTextBox.Name = "BlockAliasTextBox";
            this.BlockAliasTextBox.Size = new System.Drawing.Size(136, 20);
            this.BlockAliasTextBox.TabIndex = 31;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(285, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "*Block Alias";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Block Capability: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "*Block Type";
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
            this.BlockTypeComboBox.Location = new System.Drawing.Point(84, 29);
            this.BlockTypeComboBox.Name = "BlockTypeComboBox";
            this.BlockTypeComboBox.Size = new System.Drawing.Size(175, 21);
            this.BlockTypeComboBox.TabIndex = 27;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(451, 372);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 26;
            this.button3.Text = "Next >>";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(370, 372);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 25;
            this.button2.Text = "New Block";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PlantObjectType,
            this.ObjectIcon,
            this.ObjectAlias,
            this.ConfigureObject});
            this.dataGridView2.Location = new System.Drawing.Point(20, 222);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(504, 132);
            this.dataGridView2.TabIndex = 24;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // PlantObjectType
            // 
            this.PlantObjectType.HeaderText = "Object Type";
            this.PlantObjectType.Name = "PlantObjectType";
            this.PlantObjectType.Width = 120;
            // 
            // ObjectIcon
            // 
            this.ObjectIcon.HeaderText = "Icon";
            this.ObjectIcon.Name = "ObjectIcon";
            this.ObjectIcon.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ObjectIcon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ObjectIcon.Width = 80;
            // 
            // ObjectAlias
            // 
            this.ObjectAlias.HeaderText = "*Alias";
            this.ObjectAlias.Name = "ObjectAlias";
            this.ObjectAlias.Width = 150;
            // 
            // ConfigureObject
            // 
            this.ConfigureObject.HeaderText = "Configure";
            this.ConfigureObject.Name = "ConfigureObject";
            this.ConfigureObject.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ConfigureObject.Width = 110;
            // 
            // BlockConfigure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.ConfigureUnitComboBox);
            this.Controls.Add(this.UnitConfiguration);
            this.Controls.Add(this.TES);
            this.Controls.Add(this.CompressorMap);
            this.Controls.Add(this.Forecast);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.DuctBurners);
            this.Controls.Add(this.SteamInjection);
            this.Controls.Add(this.PeakFiring);
            this.Controls.Add(this.InletAirHeating);
            this.Controls.Add(this.InletAirCooling);
            this.Controls.Add(this.BlockAliasTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BlockTypeComboBox);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView2);
            this.Name = "BlockConfigure";
            this.Size = new System.Drawing.Size(536, 414);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.ComboBox ConfigureUnitComboBox;
        private System.Windows.Forms.Label UnitConfiguration;
        private System.Windows.Forms.CheckBox TES;
        private System.Windows.Forms.CheckBox CompressorMap;
        private System.Windows.Forms.CheckBox Forecast;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.CheckBox DuctBurners;
        private System.Windows.Forms.CheckBox SteamInjection;
        private System.Windows.Forms.CheckBox PeakFiring;
        private System.Windows.Forms.CheckBox InletAirHeating;
        private System.Windows.Forms.CheckBox InletAirCooling;
        private System.Windows.Forms.TextBox BlockAliasTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox BlockTypeComboBox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlantObjectType;
        private System.Windows.Forms.DataGridViewImageColumn ObjectIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObjectAlias;
        private System.Windows.Forms.DataGridViewButtonColumn ConfigureObject;
    }
}

namespace ForecastWizardApplication.Views
{
    partial class AddMasterVariableForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.addNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.addDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.selectPlantObject = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.saveAddVariableButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name ";
            // 
            // addNameTextBox
            // 
            this.addNameTextBox.Location = new System.Drawing.Point(137, 39);
            this.addNameTextBox.Name = "addNameTextBox";
            this.addNameTextBox.Size = new System.Drawing.Size(186, 20);
            this.addNameTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Description";
            // 
            // addDescriptionTextBox
            // 
            this.addDescriptionTextBox.Location = new System.Drawing.Point(137, 74);
            this.addDescriptionTextBox.Multiline = true;
            this.addDescriptionTextBox.Name = "addDescriptionTextBox";
            this.addDescriptionTextBox.Size = new System.Drawing.Size(186, 62);
            this.addDescriptionTextBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Plant Object";
            // 
            // selectPlantObject
            // 
            this.selectPlantObject.FormattingEnabled = true;
            this.selectPlantObject.Items.AddRange(new object[] {
            "None",
            "Site",
            "Block",
            "Generator",
            "Gas Turbine",
            "HRSG",
            "SteamTurbine",
            "Condenser"});
            this.selectPlantObject.Location = new System.Drawing.Point(137, 154);
            this.selectPlantObject.Name = "selectPlantObject";
            this.selectPlantObject.Size = new System.Drawing.Size(123, 21);
            this.selectPlantObject.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Category";
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(137, 187);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(138, 21);
            this.categoryComboBox.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Search Shortcut";
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(137, 228);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(138, 20);
            this.searchTextBox.TabIndex = 9;
            // 
            // saveAddVariableButton
            // 
            this.saveAddVariableButton.Location = new System.Drawing.Point(137, 267);
            this.saveAddVariableButton.Name = "saveAddVariableButton";
            this.saveAddVariableButton.Size = new System.Drawing.Size(75, 23);
            this.saveAddVariableButton.TabIndex = 10;
            this.saveAddVariableButton.Text = "Save";
            this.saveAddVariableButton.UseVisualStyleBackColor = true;
            this.saveAddVariableButton.Click += new System.EventHandler(this.saveAddVariableButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(274, 267);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(49, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "OK";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(22, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(313, 249);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Variable";
            // 
            // AddMasterVariableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 312);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.saveAddVariableButton);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.categoryComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.selectPlantObject);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.addDescriptionTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.addNameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "AddMasterVariableForm";
            this.Text = "AddMasterVariableForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox addNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox addDescriptionTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox selectPlantObject;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button saveAddVariableButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
namespace TreeViewUserControl
{
    partial class ChildUserControl
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
            this.Status = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.childNameTextBox = new System.Windows.Forms.TextBox();
            this.childSaveButton = new System.Windows.Forms.Button();
            this.TestingGroupBox = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.isCompleteCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.TestingGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Location = new System.Drawing.Point(41, 46);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(35, 13);
            this.Status.TabIndex = 0;
            this.Status.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Child Name: ";
            // 
            // childNameTextBox
            // 
            this.childNameTextBox.Location = new System.Drawing.Point(117, 94);
            this.childNameTextBox.Name = "childNameTextBox";
            this.childNameTextBox.Size = new System.Drawing.Size(150, 20);
            this.childNameTextBox.TabIndex = 2;
            this.childNameTextBox.TextChanged += new System.EventHandler(this.childNameTextBox_TextChanged);
            // 
            // childSaveButton
            // 
            this.childSaveButton.Location = new System.Drawing.Point(192, 130);
            this.childSaveButton.Name = "childSaveButton";
            this.childSaveButton.Size = new System.Drawing.Size(75, 23);
            this.childSaveButton.TabIndex = 3;
            this.childSaveButton.Text = "Save";
            this.childSaveButton.UseVisualStyleBackColor = true;
            this.childSaveButton.Click += new System.EventHandler(this.childSaveButton_Click);
            // 
            // TestingGroupBox
            // 
            this.TestingGroupBox.Controls.Add(this.textBox1);
            this.TestingGroupBox.Controls.Add(this.label2);
            this.TestingGroupBox.Enabled = false;
            this.TestingGroupBox.Location = new System.Drawing.Point(27, 235);
            this.TestingGroupBox.Name = "TestingGroupBox";
            this.TestingGroupBox.Size = new System.Drawing.Size(200, 100);
            this.TestingGroupBox.TabIndex = 4;
            this.TestingGroupBox.TabStop = false;
            this.TestingGroupBox.Text = "TestingGroupBox";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(49, 41);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "label2";
            // 
            // isCompleteCheckBox
            // 
            this.isCompleteCheckBox.AutoSize = true;
            this.isCompleteCheckBox.Location = new System.Drawing.Point(27, 342);
            this.isCompleteCheckBox.Name = "isCompleteCheckBox";
            this.isCompleteCheckBox.Size = new System.Drawing.Size(141, 17);
            this.isCompleteCheckBox.TabIndex = 5;
            this.isCompleteCheckBox.Text = "Configuration Complete?";
            this.isCompleteCheckBox.UseVisualStyleBackColor = true;
            this.isCompleteCheckBox.CheckedChanged += new System.EventHandler(this.isCompleteCheckBox_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Number of Grand Child Node";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboBox1.Location = new System.Drawing.Point(178, 189);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // ChildUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.isCompleteCheckBox);
            this.Controls.Add(this.TestingGroupBox);
            this.Controls.Add(this.childSaveButton);
            this.Controls.Add(this.childNameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Status);
            this.Name = "ChildUserControl";
            this.Size = new System.Drawing.Size(390, 424);
            this.TestingGroupBox.ResumeLayout(false);
            this.TestingGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label Status;
        public System.Windows.Forms.TextBox childNameTextBox;
        private System.Windows.Forms.Button childSaveButton;
        public System.Windows.Forms.GroupBox TestingGroupBox;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox isCompleteCheckBox;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox comboBox1;
    }
}

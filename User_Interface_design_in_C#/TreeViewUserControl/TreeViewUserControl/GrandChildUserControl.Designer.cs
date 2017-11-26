namespace TreeViewUserControl
{
    partial class GrandChildUserControl
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
            this.isCompleteCheckBox = new System.Windows.Forms.CheckBox();
            this.TestingGroupBox = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.GrandchildSaveButton = new System.Windows.Forms.Button();
            this.GrandchildNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Status = new System.Windows.Forms.Label();
            this.TestingGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // isCompleteCheckBox
            // 
            this.isCompleteCheckBox.AutoSize = true;
            this.isCompleteCheckBox.Location = new System.Drawing.Point(40, 340);
            this.isCompleteCheckBox.Name = "isCompleteCheckBox";
            this.isCompleteCheckBox.Size = new System.Drawing.Size(141, 17);
            this.isCompleteCheckBox.TabIndex = 11;
            this.isCompleteCheckBox.Text = "Configuration Complete?";
            this.isCompleteCheckBox.UseVisualStyleBackColor = true;
            // 
            // TestingGroupBox
            // 
            this.TestingGroupBox.Controls.Add(this.textBox1);
            this.TestingGroupBox.Controls.Add(this.label2);
            this.TestingGroupBox.Enabled = false;
            this.TestingGroupBox.Location = new System.Drawing.Point(40, 233);
            this.TestingGroupBox.Name = "TestingGroupBox";
            this.TestingGroupBox.Size = new System.Drawing.Size(200, 100);
            this.TestingGroupBox.TabIndex = 10;
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
            // GrandchildSaveButton
            // 
            this.GrandchildSaveButton.Location = new System.Drawing.Point(204, 180);
            this.GrandchildSaveButton.Name = "GrandchildSaveButton";
            this.GrandchildSaveButton.Size = new System.Drawing.Size(75, 23);
            this.GrandchildSaveButton.TabIndex = 9;
            this.GrandchildSaveButton.Text = "Save";
            this.GrandchildSaveButton.UseVisualStyleBackColor = true;
            // 
            // GrandchildNameTextBox
            // 
            this.GrandchildNameTextBox.Location = new System.Drawing.Point(186, 88);
            this.GrandchildNameTextBox.Name = "GrandchildNameTextBox";
            this.GrandchildNameTextBox.Size = new System.Drawing.Size(150, 20);
            this.GrandchildNameTextBox.TabIndex = 8;
            this.GrandchildNameTextBox.TextChanged += new System.EventHandler(this.GrandchildNameTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Grand Child Name: ";
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Location = new System.Drawing.Point(54, 44);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(35, 13);
            this.Status.TabIndex = 6;
            this.Status.Text = "label1";
            // 
            // GrandChildUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.isCompleteCheckBox);
            this.Controls.Add(this.TestingGroupBox);
            this.Controls.Add(this.GrandchildSaveButton);
            this.Controls.Add(this.GrandchildNameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Status);
            this.Name = "GrandChildUserControl";
            this.Size = new System.Drawing.Size(430, 474);
            this.TestingGroupBox.ResumeLayout(false);
            this.TestingGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox isCompleteCheckBox;
        public System.Windows.Forms.GroupBox TestingGroupBox;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button GrandchildSaveButton;
        public System.Windows.Forms.TextBox GrandchildNameTextBox;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label Status;
    }
}

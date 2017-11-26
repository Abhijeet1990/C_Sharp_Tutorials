namespace TreeViewUserControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.blockSaveButton = new System.Windows.Forms.Button();
            this.TestingCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 226);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Block Node Name";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(152, 220);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(195, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
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
            this.comboBox1.Location = new System.Drawing.Point(159, 262);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 270);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Number of Child Node";
            // 
            // blockSaveButton
            // 
            this.blockSaveButton.Location = new System.Drawing.Point(272, 350);
            this.blockSaveButton.Name = "blockSaveButton";
            this.blockSaveButton.Size = new System.Drawing.Size(75, 23);
            this.blockSaveButton.TabIndex = 6;
            this.blockSaveButton.Text = "Save";
            this.blockSaveButton.UseVisualStyleBackColor = true;
            this.blockSaveButton.Click += new System.EventHandler(this.blockSaveButton_Click);
            // 
            // TestingCheckBox
            // 
            this.TestingCheckBox.AutoSize = true;
            this.TestingCheckBox.Location = new System.Drawing.Point(45, 333);
            this.TestingCheckBox.Name = "TestingCheckBox";
            this.TestingCheckBox.Size = new System.Drawing.Size(110, 17);
            this.TestingCheckBox.TabIndex = 7;
            this.TestingCheckBox.Text = "TestingCheckBox";
            this.TestingCheckBox.UseVisualStyleBackColor = true;
            this.TestingCheckBox.CheckedChanged += new System.EventHandler(this.TestingCheckBox_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(100, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Children not configured";
            // 
            // BlockUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TestingCheckBox);
            this.Controls.Add(this.blockSaveButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "BlockUserControl";
            this.Size = new System.Drawing.Size(407, 474);
            this.Load += new System.EventHandler(this.BlockUserControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button blockSaveButton;
        private System.Windows.Forms.CheckBox TestingCheckBox;
        private System.Windows.Forms.Label label3;
    }
}

namespace TestDelegate
{
    partial class Publisher
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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.One = new System.Windows.Forms.CheckBox();
            this.Two = new System.Windows.Forms.CheckBox();
            this.Three = new System.Windows.Forms.CheckBox();
            this.Four = new System.Windows.Forms.CheckBox();
            this.Check = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(20, 79);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(20, 53);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "One",
            "Two",
            "Three"});
            this.comboBox1.Location = new System.Drawing.Point(135, 53);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(85, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Check);
            this.groupBox1.Controls.Add(this.Four);
            this.groupBox1.Controls.Add(this.Three);
            this.groupBox1.Controls.Add(this.Two);
            this.groupBox1.Controls.Add(this.One);
            this.groupBox1.Location = new System.Drawing.Point(20, 114);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 173);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // One
            // 
            this.One.AutoSize = true;
            this.One.Location = new System.Drawing.Point(7, 20);
            this.One.Name = "One";
            this.One.Size = new System.Drawing.Size(46, 17);
            this.One.TabIndex = 0;
            this.One.Text = "One";
            this.One.UseVisualStyleBackColor = true;
            // 
            // Two
            // 
            this.Two.AutoSize = true;
            this.Two.Location = new System.Drawing.Point(7, 44);
            this.Two.Name = "Two";
            this.Two.Size = new System.Drawing.Size(47, 17);
            this.Two.TabIndex = 1;
            this.Two.Text = "Two";
            this.Two.UseVisualStyleBackColor = true;
            // 
            // Three
            // 
            this.Three.AutoSize = true;
            this.Three.Location = new System.Drawing.Point(7, 68);
            this.Three.Name = "Three";
            this.Three.Size = new System.Drawing.Size(54, 17);
            this.Three.TabIndex = 2;
            this.Three.Text = "Three";
            this.Three.UseVisualStyleBackColor = true;
            // 
            // Four
            // 
            this.Four.AutoSize = true;
            this.Four.Location = new System.Drawing.Point(6, 140);
            this.Four.Name = "Four";
            this.Four.Size = new System.Drawing.Size(47, 17);
            this.Four.TabIndex = 3;
            this.Four.Text = "Four";
            this.Four.UseVisualStyleBackColor = true;
            // 
            // Check
            // 
            this.Check.Location = new System.Drawing.Point(7, 91);
            this.Check.Name = "Check";
            this.Check.Size = new System.Drawing.Size(75, 23);
            this.Check.TabIndex = 4;
            this.Check.Text = "Check";
            this.Check.UseVisualStyleBackColor = true;
            this.Check.Click += new System.EventHandler(this.Check_Click);
            // 
            // Publisher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.checkBox1);
            this.Name = "Publisher";
            this.Size = new System.Drawing.Size(242, 305);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox Four;
        private System.Windows.Forms.CheckBox Three;
        private System.Windows.Forms.CheckBox Two;
        private System.Windows.Forms.CheckBox One;
        private System.Windows.Forms.Button Check;
    }
}

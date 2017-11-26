namespace UsePerformanceDLLforAzureTable
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CreateAzureTable = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.FilterByVariableButton = new System.Windows.Forms.Button();
            this.FilteredDGV = new System.Windows.Forms.DataGridView();
            this.FilterByTimeButton = new System.Windows.Forms.Button();
            this.FilterByValueRangeButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.selectVariableComboBox = new System.Windows.Forms.ComboBox();
            this.selectVariableforValueFilterComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker4 = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FilteredDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 84);
            this.dataGridView1.TabIndex = 0;
            // 
            // CreateAzureTable
            // 
            this.CreateAzureTable.Location = new System.Drawing.Point(12, 173);
            this.CreateAzureTable.Name = "CreateAzureTable";
            this.CreateAzureTable.Size = new System.Drawing.Size(159, 23);
            this.CreateAzureTable.TabIndex = 1;
            this.CreateAzureTable.Text = "Create Azure Table";
            this.CreateAzureTable.UseVisualStyleBackColor = true;
            this.CreateAzureTable.Click += new System.EventHandler(this.OnClickCreateAzureTable);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(627, 164);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(66, 20);
            this.textBox1.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(597, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Min";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(730, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Max";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(763, 164);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(66, 20);
            this.textBox2.TabIndex = 12;
            // 
            // FilterByVariableButton
            // 
            this.FilterByVariableButton.Location = new System.Drawing.Point(590, 192);
            this.FilterByVariableButton.Name = "FilterByVariableButton";
            this.FilterByVariableButton.Size = new System.Drawing.Size(239, 23);
            this.FilterByVariableButton.TabIndex = 14;
            this.FilterByVariableButton.Text = "Filter By Variable";
            this.FilterByVariableButton.UseVisualStyleBackColor = true;
            this.FilterByVariableButton.Click += new System.EventHandler(this.FilterByVariableButton_Click);
            // 
            // FilteredDGV
            // 
            this.FilteredDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FilteredDGV.Location = new System.Drawing.Point(12, 230);
            this.FilteredDGV.Name = "FilteredDGV";
            this.FilteredDGV.Size = new System.Drawing.Size(837, 314);
            this.FilteredDGV.TabIndex = 15;
            // 
            // FilterByTimeButton
            // 
            this.FilterByTimeButton.Location = new System.Drawing.Point(590, 33);
            this.FilterByTimeButton.Name = "FilterByTimeButton";
            this.FilterByTimeButton.Size = new System.Drawing.Size(239, 23);
            this.FilterByTimeButton.TabIndex = 16;
            this.FilterByTimeButton.Text = "Filter By Time";
            this.FilterByTimeButton.UseVisualStyleBackColor = true;
            this.FilterByTimeButton.Click += new System.EventHandler(this.FilterByTimeButton_Click);
            // 
            // FilterByValueRangeButton
            // 
            this.FilterByValueRangeButton.Location = new System.Drawing.Point(590, 135);
            this.FilterByValueRangeButton.Name = "FilterByValueRangeButton";
            this.FilterByValueRangeButton.Size = new System.Drawing.Size(239, 23);
            this.FilterByValueRangeButton.TabIndex = 17;
            this.FilterByValueRangeButton.Text = "Filter By Value Range";
            this.FilterByValueRangeButton.UseVisualStyleBackColor = true;
            this.FilterByValueRangeButton.Click += new System.EventHandler(this.FilterByValueRangeButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(597, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Max";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(627, 101);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(182, 20);
            this.textBox3.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(597, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Min";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(627, 66);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(185, 20);
            this.textBox4.TabIndex = 18;
            
            // 
            // selectVariableComboBox
            // 
            this.selectVariableComboBox.FormattingEnabled = true;
            this.selectVariableComboBox.Items.AddRange(new object[] {
            "All",
            "Ambient Air Density",
            "Ambient Air Dew Point",
            "Ambient Air Kappa",
            "Ambient Air Molar Mass",
            "Ambent Air Press",
            "Ambient Air Rel Humidity",
            "Ambient Air Speed of Sound",
            "Ambient Air Temp"});
            this.selectVariableComboBox.Location = new System.Drawing.Point(437, 194);
            this.selectVariableComboBox.Name = "selectVariableComboBox";
            this.selectVariableComboBox.Size = new System.Drawing.Size(121, 21);
            this.selectVariableComboBox.TabIndex = 22;
            // 
            // selectVariableforValueFilterComboBox
            // 
            this.selectVariableforValueFilterComboBox.FormattingEnabled = true;
            this.selectVariableforValueFilterComboBox.Items.AddRange(new object[] {
            "Ambient Air Density",
            "Ambient Air Dew Point",
            "Ambient Air Kappa",
            "Ambient Air Molar Mass",
            "Ambent Air Press",
            "Ambient Air Rel Humidity",
            "Ambient Air Speed of Sound",
            "Ambient Air Temp"});
            this.selectVariableforValueFilterComboBox.Location = new System.Drawing.Point(437, 138);
            this.selectVariableforValueFilterComboBox.Name = "selectVariableforValueFilterComboBox";
            this.selectVariableforValueFilterComboBox.Size = new System.Drawing.Size(121, 21);
            this.selectVariableforValueFilterComboBox.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "To";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(48, 144);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(188, 20);
            this.textBox5.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "From";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(48, 114);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(188, 20);
            this.textBox6.TabIndex = 24;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(234, 114);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(18, 20);
            this.dateTimePicker1.TabIndex = 28;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(234, 144);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(18, 20);
            this.dateTimePicker2.TabIndex = 29;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Location = new System.Drawing.Point(794, 67);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(18, 20);
            this.dateTimePicker3.TabIndex = 30;
            this.dateTimePicker3.ValueChanged += new System.EventHandler(this.dateTimePicker3_ValueChanged);
            // 
            // dateTimePicker4
            // 
            this.dateTimePicker4.Location = new System.Drawing.Point(794, 101);
            this.dateTimePicker4.Name = "dateTimePicker4";
            this.dateTimePicker4.Size = new System.Drawing.Size(18, 20);
            this.dateTimePicker4.TabIndex = 31;
            this.dateTimePicker4.ValueChanged += new System.EventHandler(this.dateTimePicker4_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(406, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(443, 211);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter Azure Table";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 556);
            this.Controls.Add(this.dateTimePicker4);
            this.Controls.Add(this.dateTimePicker3);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.selectVariableforValueFilterComboBox);
            this.Controls.Add(this.selectVariableComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.FilterByValueRangeButton);
            this.Controls.Add(this.FilterByTimeButton);
            this.Controls.Add(this.FilteredDGV);
            this.Controls.Add(this.FilterByVariableButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.CreateAzureTable);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FilteredDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button CreateAzureTable;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button FilterByVariableButton;
        private System.Windows.Forms.DataGridView FilteredDGV;
        private System.Windows.Forms.Button FilterByTimeButton;
        private System.Windows.Forms.Button FilterByValueRangeButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.ComboBox selectVariableComboBox;
        private System.Windows.Forms.ComboBox selectVariableforValueFilterComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.DateTimePicker dateTimePicker4;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}


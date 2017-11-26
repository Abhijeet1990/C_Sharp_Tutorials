namespace PlantSettingForm
{
    partial class VariableSettingForm
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
            this.StandardVariable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EngUnits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TagNames = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StandardVariable,
            this.EngUnits,
            this.TagNames});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(494, 302);
            this.dataGridView1.TabIndex = 0;
            // 
            // StandardVariable
            // 
            this.StandardVariable.HeaderText = "Standard Variables";
            this.StandardVariable.Name = "StandardVariable";
            this.StandardVariable.Width = 200;
            // 
            // EngUnits
            // 
            this.EngUnits.HeaderText = "Eng Units";
            this.EngUnits.Name = "EngUnits";
            this.EngUnits.Width = 50;
            // 
            // TagNames
            // 
            this.TagNames.HeaderText = "Tag Names";
            this.TagNames.Name = "TagNames";
            this.TagNames.Width = 200;
            // 
            // VariableSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 302);
            this.Controls.Add(this.dataGridView1);
            this.Name = "VariableSettingForm";
            this.Text = "VariableSettingForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn StandardVariable;
        private System.Windows.Forms.DataGridViewTextBoxColumn EngUnits;
        private System.Windows.Forms.DataGridViewTextBoxColumn TagNames;
    }
}
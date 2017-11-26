namespace ForecastWizardApplication.Views
{
    partial class LookUpTableForm
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
            this.AddTable = new System.Windows.Forms.Button();
            this.SaveTable = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AddTable
            // 
            this.AddTable.Location = new System.Drawing.Point(13, 13);
            this.AddTable.Name = "AddTable";
            this.AddTable.Size = new System.Drawing.Size(100, 23);
            this.AddTable.TabIndex = 0;
            this.AddTable.Text = "Add Table";
            this.AddTable.UseVisualStyleBackColor = true;
            this.AddTable.Click += new System.EventHandler(this.AddTable_Click);
            // 
            // SaveTable
            // 
            this.SaveTable.Location = new System.Drawing.Point(197, 12);
            this.SaveTable.Name = "SaveTable";
            this.SaveTable.Size = new System.Drawing.Size(75, 23);
            this.SaveTable.TabIndex = 1;
            this.SaveTable.Text = "Save";
            this.SaveTable.UseVisualStyleBackColor = true;
            this.SaveTable.Click += new System.EventHandler(this.SaveTable_Click);
            // 
            // LookUpTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.SaveTable);
            this.Controls.Add(this.AddTable);
            this.Name = "LookUpTableForm";
            this.Text = "LookUpTableForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddTable;
        private System.Windows.Forms.Button SaveTable;
    }
}
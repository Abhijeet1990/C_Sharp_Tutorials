namespace ForecastWizardApplication.UserControls
{
    partial class GetPITagUserControl
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
            this.VariableMasterLabel = new System.Windows.Forms.Label();
            this.TagTextBox = new System.Windows.Forms.TextBox();
            this.EngUnitsTextBox = new System.Windows.Forms.TextBox();
            this.SelectPITagButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // VariableMasterLabel
            // 
            this.VariableMasterLabel.AutoSize = true;
            this.VariableMasterLabel.Location = new System.Drawing.Point(12, 10);
            this.VariableMasterLabel.Name = "VariableMasterLabel";
            this.VariableMasterLabel.Size = new System.Drawing.Size(35, 13);
            this.VariableMasterLabel.TabIndex = 0;
            this.VariableMasterLabel.Text = "label1";
            // 
            // TagTextBox
            // 
            this.TagTextBox.Location = new System.Drawing.Point(137, 2);
            this.TagTextBox.Name = "TagTextBox";
            this.TagTextBox.Size = new System.Drawing.Size(209, 20);
            this.TagTextBox.TabIndex = 1;
            // 
            // EngUnitsTextBox
            // 
            this.EngUnitsTextBox.Location = new System.Drawing.Point(352, 2);
            this.EngUnitsTextBox.Name = "EngUnitsTextBox";
            this.EngUnitsTextBox.Size = new System.Drawing.Size(69, 20);
            this.EngUnitsTextBox.TabIndex = 2;
            // 
            // SelectPITagButton
            // 
            this.SelectPITagButton.Location = new System.Drawing.Point(427, 0);
            this.SelectPITagButton.Name = "SelectPITagButton";
            this.SelectPITagButton.Size = new System.Drawing.Size(23, 23);
            this.SelectPITagButton.TabIndex = 3;
            this.SelectPITagButton.Text = "...";
            this.SelectPITagButton.UseVisualStyleBackColor = true;
            this.SelectPITagButton.Click += new System.EventHandler(this.SelectPITagButton_Click);
            // 
            // GetPITagUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SelectPITagButton);
            this.Controls.Add(this.EngUnitsTextBox);
            this.Controls.Add(this.TagTextBox);
            this.Controls.Add(this.VariableMasterLabel);
            this.Name = "GetPITagUserControl";
            this.Size = new System.Drawing.Size(453, 27);
            //            this.Load += new System.EventHandler(this.GetPITagUserControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label VariableMasterLabel;
        public System.Windows.Forms.TextBox TagTextBox;
        public System.Windows.Forms.TextBox EngUnitsTextBox;
        public System.Windows.Forms.Button SelectPITagButton;
    }
}

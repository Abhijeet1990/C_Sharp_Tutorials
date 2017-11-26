namespace FWA_13.UserControls
{
    partial class TagCollectorUserControl
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
            this.SelectTagButton = new System.Windows.Forms.Button();
            this.EngUnitsTextBox = new System.Windows.Forms.TextBox();
            this.TagTextBox = new System.Windows.Forms.TextBox();
            this.VariableName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SelectTagButton
            // 
            this.SelectTagButton.Location = new System.Drawing.Point(448, 2);
            this.SelectTagButton.Name = "SelectTagButton";
            this.SelectTagButton.Size = new System.Drawing.Size(30, 23);
            this.SelectTagButton.TabIndex = 7;
            this.SelectTagButton.Text = "...";
            this.SelectTagButton.UseVisualStyleBackColor = true;
            this.SelectTagButton.Click += new System.EventHandler(this.SelectTagButton_Click);
            // 
            // EngUnitsTextBox
            // 
            this.EngUnitsTextBox.Location = new System.Drawing.Point(365, 4);
            this.EngUnitsTextBox.Name = "EngUnitsTextBox";
            this.EngUnitsTextBox.Size = new System.Drawing.Size(77, 20);
            this.EngUnitsTextBox.TabIndex = 6;
            // 
            // TagTextBox
            // 
            this.TagTextBox.Location = new System.Drawing.Point(168, 4);
            this.TagTextBox.Name = "TagTextBox";
            this.TagTextBox.Size = new System.Drawing.Size(191, 20);
            this.TagTextBox.TabIndex = 5;
            // 
            // VariableName
            // 
            this.VariableName.AutoSize = true;
            this.VariableName.Location = new System.Drawing.Point(3, 7);
            this.VariableName.Name = "VariableName";
            this.VariableName.Size = new System.Drawing.Size(35, 13);
            this.VariableName.TabIndex = 4;
            this.VariableName.Text = "label1";
            // 
            // TagCollectorUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SelectTagButton);
            this.Controls.Add(this.EngUnitsTextBox);
            this.Controls.Add(this.TagTextBox);
            this.Controls.Add(this.VariableName);
            this.Name = "TagCollectorUserControl";
            this.Size = new System.Drawing.Size(486, 27);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SelectTagButton;
        private System.Windows.Forms.TextBox EngUnitsTextBox;
        private System.Windows.Forms.TextBox TagTextBox;
        public System.Windows.Forms.Label VariableName;
    }
}

namespace FWA
{
    partial class ForecastTypeUC
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
            this.ForecastTypeCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ForecastTypeCheckBox
            // 
            this.ForecastTypeCheckBox.AutoSize = true;
            this.ForecastTypeCheckBox.Location = new System.Drawing.Point(3, 12);
            this.ForecastTypeCheckBox.Name = "ForecastTypeCheckBox";
            this.ForecastTypeCheckBox.Size = new System.Drawing.Size(80, 17);
            this.ForecastTypeCheckBox.TabIndex = 0;
            this.ForecastTypeCheckBox.Text = "checkBox1";
            this.ForecastTypeCheckBox.UseVisualStyleBackColor = true;
            // 
            // ForecastTypeUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ForecastTypeCheckBox);
            this.Name = "ForecastTypeUC";
            this.Size = new System.Drawing.Size(422, 40);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.CheckBox ForecastTypeCheckBox;
    }
}

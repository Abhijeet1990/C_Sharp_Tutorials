namespace ForecastWizardApplication.UserControls
{
    partial class CondenserUserControl
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxShortName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxLongName = new System.Windows.Forms.TextBox();
            this.SteamCondenserTagsGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxShortName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxLongName);
            this.groupBox1.Location = new System.Drawing.Point(12, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(488, 93);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Steam Condenser Attributes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(284, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Short Name";
            // 
            // textBoxShortName
            // 
            this.textBoxShortName.Location = new System.Drawing.Point(286, 36);
            this.textBoxShortName.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxShortName.Name = "textBoxShortName";
            this.textBoxShortName.Size = new System.Drawing.Size(76, 20);
            this.textBoxShortName.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Long Name";
            // 
            // textBoxLongName
            // 
            this.textBoxLongName.Location = new System.Drawing.Point(5, 36);
            this.textBoxLongName.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxLongName.Name = "textBoxLongName";
            this.textBoxLongName.Size = new System.Drawing.Size(221, 20);
            this.textBoxLongName.TabIndex = 3;
            // 
            // SteamCondenserTagsGroupBox
            // 
            this.SteamCondenserTagsGroupBox.AutoSize = true;
            this.SteamCondenserTagsGroupBox.Location = new System.Drawing.Point(12, 108);
            this.SteamCondenserTagsGroupBox.Name = "SteamCondenserTagsGroupBox";
            this.SteamCondenserTagsGroupBox.Size = new System.Drawing.Size(488, 63);
            this.SteamCondenserTagsGroupBox.TabIndex = 3;
            this.SteamCondenserTagsGroupBox.TabStop = false;
            this.SteamCondenserTagsGroupBox.Text = "Steam Condenser Tag";
            // 
            // CondenserUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SteamCondenserTagsGroupBox);
            this.Controls.Add(this.groupBox1);
            this.Name = "CondenserUserControl";
            this.Size = new System.Drawing.Size(516, 531);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox textBoxShortName;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textBoxLongName;
        private System.Windows.Forms.GroupBox SteamCondenserTagsGroupBox;
    }
}

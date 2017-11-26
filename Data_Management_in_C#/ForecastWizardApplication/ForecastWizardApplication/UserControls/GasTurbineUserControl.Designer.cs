namespace ForecastWizardApplication.UserControls
{
    partial class GasTurbineUserControl
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
            this.GasTurbineAttributeGroupBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGasTurbineShortName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGasTurbineLongName = new System.Windows.Forms.TextBox();
            this.GasTurbineTagsGroupBox = new System.Windows.Forms.GroupBox();
            this.nameGroupBox = new System.Windows.Forms.GroupBox();
            this.GasTurbineAttributeGroupBox.SuspendLayout();
            this.nameGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // GasTurbineAttributeGroupBox
            // 
            this.GasTurbineAttributeGroupBox.AutoSize = true;
            this.GasTurbineAttributeGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GasTurbineAttributeGroupBox.Controls.Add(this.nameGroupBox);
            this.GasTurbineAttributeGroupBox.Location = new System.Drawing.Point(14, 3);
            this.GasTurbineAttributeGroupBox.Name = "GasTurbineAttributeGroupBox";
            this.GasTurbineAttributeGroupBox.Size = new System.Drawing.Size(513, 101);
            this.GasTurbineAttributeGroupBox.TabIndex = 0;
            this.GasTurbineAttributeGroupBox.TabStop = false;
            this.GasTurbineAttributeGroupBox.Text = "Gas Turbine Attributes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(304, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Short Name";
            // 
            // txtGasTurbineShortName
            // 
            this.txtGasTurbineShortName.Location = new System.Drawing.Point(307, 24);
            this.txtGasTurbineShortName.Margin = new System.Windows.Forms.Padding(2);
            this.txtGasTurbineShortName.Name = "txtGasTurbineShortName";
            this.txtGasTurbineShortName.Size = new System.Drawing.Size(93, 20);
            this.txtGasTurbineShortName.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Long Name";
            // 
            // txtGasTurbineLongName
            // 
            this.txtGasTurbineLongName.Location = new System.Drawing.Point(8, 24);
            this.txtGasTurbineLongName.Margin = new System.Windows.Forms.Padding(2);
            this.txtGasTurbineLongName.Name = "txtGasTurbineLongName";
            this.txtGasTurbineLongName.Size = new System.Drawing.Size(267, 20);
            this.txtGasTurbineLongName.TabIndex = 3;
            // 
            // GasTurbineTagsGroupBox
            // 
            this.GasTurbineTagsGroupBox.AutoSize = true;
            this.GasTurbineTagsGroupBox.Location = new System.Drawing.Point(14, 469);
            this.GasTurbineTagsGroupBox.Name = "GasTurbineTagsGroupBox";
            this.GasTurbineTagsGroupBox.Size = new System.Drawing.Size(507, 686);
            this.GasTurbineTagsGroupBox.TabIndex = 10;
            this.GasTurbineTagsGroupBox.TabStop = false;
            this.GasTurbineTagsGroupBox.Text = "Gas Turbine Tag";
            // 
            // nameGroupBox
            // 
            this.nameGroupBox.Controls.Add(this.txtGasTurbineLongName);
            this.nameGroupBox.Controls.Add(this.label1);
            this.nameGroupBox.Controls.Add(this.label2);
            this.nameGroupBox.Controls.Add(this.txtGasTurbineShortName);
            this.nameGroupBox.Location = new System.Drawing.Point(7, 20);
            this.nameGroupBox.Name = "nameGroupBox";
            this.nameGroupBox.Size = new System.Drawing.Size(500, 62);
            this.nameGroupBox.TabIndex = 6;
            this.nameGroupBox.TabStop = false;
            // 
            // GasTurbineUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.Controls.Add(this.GasTurbineTagsGroupBox);
            this.Controls.Add(this.GasTurbineAttributeGroupBox);
            this.Name = "GasTurbineUserControl";
            this.Size = new System.Drawing.Size(538, 1158);
            this.GasTurbineAttributeGroupBox.ResumeLayout(false);
            this.nameGroupBox.ResumeLayout(false);
            this.nameGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GasTurbineAttributeGroupBox;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtGasTurbineLongName;
        public System.Windows.Forms.TextBox txtGasTurbineShortName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox GasTurbineTagsGroupBox;
        private System.Windows.Forms.GroupBox nameGroupBox;
    }
}

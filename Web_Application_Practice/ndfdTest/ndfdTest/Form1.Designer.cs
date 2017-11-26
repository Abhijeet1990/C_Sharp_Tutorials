namespace ndfdTest
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
            this.getWeatherButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LatitudeText = new System.Windows.Forms.TextBox();
            this.LongitudeText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.startTimeDP = new System.Windows.Forms.DateTimePicker();
            this.endTimeDP = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // getWeatherButton
            // 
            this.getWeatherButton.Location = new System.Drawing.Point(540, 402);
            this.getWeatherButton.Name = "getWeatherButton";
            this.getWeatherButton.Size = new System.Drawing.Size(93, 23);
            this.getWeatherButton.TabIndex = 0;
            this.getWeatherButton.Text = "Get Weather";
            this.getWeatherButton.UseVisualStyleBackColor = true;
            this.getWeatherButton.Click += new System.EventHandler(this.getWeatherButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Latitude";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Longitude";
            // 
            // LatitudeText
            // 
            this.LatitudeText.Location = new System.Drawing.Point(86, 31);
            this.LatitudeText.Name = "LatitudeText";
            this.LatitudeText.Size = new System.Drawing.Size(126, 20);
            this.LatitudeText.TabIndex = 3;
            // 
            // LongitudeText
            // 
            this.LongitudeText.Location = new System.Drawing.Point(86, 56);
            this.LongitudeText.Name = "LongitudeText";
            this.LongitudeText.Size = new System.Drawing.Size(126, 20);
            this.LongitudeText.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "startDate";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "endDate";
            // 
            // startTimeDP
            // 
            this.startTimeDP.Location = new System.Drawing.Point(86, 89);
            this.startTimeDP.Name = "startTimeDP";
            this.startTimeDP.Size = new System.Drawing.Size(200, 20);
            this.startTimeDP.TabIndex = 7;
            // 
            // endTimeDP
            // 
            this.endTimeDP.Location = new System.Drawing.Point(86, 116);
            this.endTimeDP.Name = "endTimeDP";
            this.endTimeDP.Size = new System.Drawing.Size(200, 20);
            this.endTimeDP.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 473);
            this.Controls.Add(this.endTimeDP);
            this.Controls.Add(this.startTimeDP);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LongitudeText);
            this.Controls.Add(this.LatitudeText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.getWeatherButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button getWeatherButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox LatitudeText;
        private System.Windows.Forms.TextBox LongitudeText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker startTimeDP;
        private System.Windows.Forms.DateTimePicker endTimeDP;
    }
}


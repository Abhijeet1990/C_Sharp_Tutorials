namespace WindowsFormsApplication3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.imageMap1 = new DotNetOpenSource.Controls.ImageMap();
            this.SuspendLayout();
            // 
            // imageMap1
            // 
            this.imageMap1.Image = ((System.Drawing.Image)(resources.GetObject("imageMap1.Image")));
            this.imageMap1.Location = new System.Drawing.Point(54, 90);
            this.imageMap1.Name = "imageMap1";
            this.imageMap1.Size = new System.Drawing.Size(541, 218);
            this.imageMap1.TabIndex = 0;
            this.imageMap1.RegionClick += new DotNetOpenSource.Controls.ImageMap.RegionClickDelegate(this.imageMap1_RegionClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 450);
            this.Controls.Add(this.imageMap1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private DotNetOpenSource.Controls.ImageMap imageMap1;
    }
}


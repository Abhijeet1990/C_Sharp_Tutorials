using System.Drawing;
using System.Windows.Forms;

namespace PlantSettingForm
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.siteSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blockSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(584, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.siteSettingsToolStripMenuItem,
            this.blockSettingsToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(61, 20);
            this.toolStripMenuItem1.Text = "Settings";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // siteSettingsToolStripMenuItem
            // 
            this.siteSettingsToolStripMenuItem.Name = "siteSettingsToolStripMenuItem";
            this.siteSettingsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.siteSettingsToolStripMenuItem.Text = "Site Settings";
            this.siteSettingsToolStripMenuItem.Click += new System.EventHandler(this.siteSettingsToolStripMenuItem_Click);
            // 
            // blockSettingsToolStripMenuItem
            // 
            this.blockSettingsToolStripMenuItem.Name = "blockSettingsToolStripMenuItem";
            this.blockSettingsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.blockSettingsToolStripMenuItem.Text = "Block Settings";
            this.blockSettingsToolStripMenuItem.Click += new System.EventHandler(this.blockSettingsToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
            this.Load += (s, ea) => {
                var wa = Screen.PrimaryScreen.WorkingArea;
                this.Location = new Point(wa.Left, wa.Top);
            };

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem siteSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blockSettingsToolStripMenuItem;
    }
}
namespace ForecastWizardApplication
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TraverseTreeView = new System.Windows.Forms.TreeView();
            this.saveButton = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DeleteBlockMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddBlockMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addVariables = new System.Windows.Forms.MenuStrip();
            this.addVariablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addVariablesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addGasTurbineTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.addVariables.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.TraverseTreeView);
            this.splitContainer1.Panel1.Controls.Add(this.addVariables);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.saveButton);
            this.splitContainer1.Size = new System.Drawing.Size(939, 537);
            this.splitContainer1.SplitterDistance = 313;
            this.splitContainer1.TabIndex = 0;
            // 
            // TraverseTreeView
            // 
            this.TraverseTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TraverseTreeView.Location = new System.Drawing.Point(3, 27);
            this.TraverseTreeView.Name = "TraverseTreeView";
            this.TraverseTreeView.Size = new System.Drawing.Size(307, 488);
            this.TraverseTreeView.TabIndex = 0;
            this.TraverseTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TraverseTreeView_AfterSelect);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(535, 431);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeleteBlockMenuItem,
            this.AddBlockMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(140, 48);
            // 
            // DeleteBlockMenuItem
            // 
            this.DeleteBlockMenuItem.Name = "DeleteBlockMenuItem";
            this.DeleteBlockMenuItem.Size = new System.Drawing.Size(139, 22);
            this.DeleteBlockMenuItem.Text = "Delete Block";
            // 
            // AddBlockMenuItem
            // 
            this.AddBlockMenuItem.Name = "AddBlockMenuItem";
            this.AddBlockMenuItem.Size = new System.Drawing.Size(139, 22);
            this.AddBlockMenuItem.Text = "Add Block";
            this.AddBlockMenuItem.Click += new System.EventHandler(this.AddBlockMenuItem_Click);
            // 
            // addVariables
            // 
            this.addVariables.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addVariablesToolStripMenuItem});
            this.addVariables.Location = new System.Drawing.Point(0, 0);
            this.addVariables.Name = "addVariables";
            this.addVariables.Size = new System.Drawing.Size(313, 24);
            this.addVariables.TabIndex = 1;
            this.addVariables.Text = "Add Variables";
            // 
            // addVariablesToolStripMenuItem
            // 
            this.addVariablesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addVariablesToolStripMenuItem1,
            this.addGasTurbineTypeToolStripMenuItem});
            this.addVariablesToolStripMenuItem.Name = "addVariablesToolStripMenuItem";
            this.addVariablesToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.addVariablesToolStripMenuItem.Text = "Add Elements";
            // 
            // addVariablesToolStripMenuItem1
            // 
            this.addVariablesToolStripMenuItem1.Name = "addVariablesToolStripMenuItem1";
            this.addVariablesToolStripMenuItem1.Size = new System.Drawing.Size(191, 22);
            this.addVariablesToolStripMenuItem1.Text = "Add Variables";
            this.addVariablesToolStripMenuItem1.Click += new System.EventHandler(this.addVariablesToolStripMenuItem1_Click);
            // 
            // addGasTurbineTypeToolStripMenuItem
            // 
            this.addGasTurbineTypeToolStripMenuItem.Name = "addGasTurbineTypeToolStripMenuItem";
            this.addGasTurbineTypeToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.addGasTurbineTypeToolStripMenuItem.Text = "Add Gas Turbine Type";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(939, 537);
            this.Controls.Add(this.splitContainer1);
            this.MainMenuStrip = this.addVariables;
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.addVariables.ResumeLayout(false);
            this.addVariables.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem DeleteBlockMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddBlockMenuItem;
        public System.Windows.Forms.TreeView TraverseTreeView;
        private System.Windows.Forms.MenuStrip addVariables;
        private System.Windows.Forms.ToolStripMenuItem addVariablesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addVariablesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addGasTurbineTypeToolStripMenuItem;
    }
}


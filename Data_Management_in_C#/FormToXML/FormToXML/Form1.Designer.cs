namespace FormToXML
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
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Site");
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.saveButton = new System.Windows.Forms.Button();
            this.AddBlockMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddBlock = new System.Windows.Forms.ToolStripMenuItem();
            this.AddObjectMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddPlantObjectMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.AddBlockMenuStrip.SuspendLayout();
            this.AddObjectMenuStrip.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.saveButton);
            this.splitContainer1.Size = new System.Drawing.Size(670, 404);
            this.splitContainer1.SplitterDistance = 174;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(3, 3);
            this.treeView1.Name = "treeView1";
            treeNode2.Name = "Root";
            treeNode2.Text = "Site";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.treeView1.Size = new System.Drawing.Size(175, 398);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(405, 369);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // AddBlockMenuStrip
            // 
            this.AddBlockMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddBlock});
            this.AddBlockMenuStrip.Name = "AddBlockMenuStrip";
            this.AddBlockMenuStrip.Size = new System.Drawing.Size(129, 26);
            // 
            // AddBlock
            // 
            this.AddBlock.Name = "AddBlock";
            this.AddBlock.Size = new System.Drawing.Size(128, 22);
            this.AddBlock.Text = "Add Block";
            this.AddBlock.Click += new System.EventHandler(this.AddBlock_Click);
            // 
            // AddObjectMenuStrip
            // 
            this.AddObjectMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddPlantObjectMenuItem});
            this.AddObjectMenuStrip.Name = "AddObjectMenuStrip";
            this.AddObjectMenuStrip.Size = new System.Drawing.Size(165, 48);
            // 
            // AddPlantObjectMenuItem
            // 
            this.AddPlantObjectMenuItem.Name = "AddPlantObjectMenuItem";
            this.AddPlantObjectMenuItem.Size = new System.Drawing.Size(164, 22);
            this.AddPlantObjectMenuItem.Text = "Add Plant Object";
            this.AddPlantObjectMenuItem.Click += new System.EventHandler(this.AddPlantObjectMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 404);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.AddBlockMenuStrip.ResumeLayout(false);
            this.AddObjectMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ContextMenuStrip AddBlockMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem AddBlock;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.ContextMenuStrip AddObjectMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem AddPlantObjectMenuItem;
    }
}


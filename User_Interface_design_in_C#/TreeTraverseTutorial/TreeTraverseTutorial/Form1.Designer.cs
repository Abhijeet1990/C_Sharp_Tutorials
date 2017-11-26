namespace TreeTraverseTutorial
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
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Site");
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.SitePage = new System.Windows.Forms.TabPage();
            this.BlockPage = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.SiteAttrib1TextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.siteAttrib2TextBox = new System.Windows.Forms.TextBox();
            this.AddSiteButton = new System.Windows.Forms.Button();
            this.blockAttrib2TextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.blockAttrib1TextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.unitAttrib2textBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.unitAttrib1TextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.AddBlockButton = new System.Windows.Forms.Button();
            this.AddUnitButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.SitePage.SuspendLayout();
            this.BlockPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(3, 4);
            this.treeView1.Name = "treeView1";
            treeNode2.Name = "Root";
            treeNode2.Text = "Site";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.treeView1.Size = new System.Drawing.Size(121, 413);
            this.treeView1.TabIndex = 0;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.SitePage);
            this.tabControl1.Controls.Add(this.BlockPage);
            this.tabControl1.Location = new System.Drawing.Point(131, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(266, 413);
            this.tabControl1.TabIndex = 1;
            // 
            // SitePage
            // 
            this.SitePage.Controls.Add(this.AddSiteButton);
            this.SitePage.Controls.Add(this.siteAttrib2TextBox);
            this.SitePage.Controls.Add(this.label2);
            this.SitePage.Controls.Add(this.SiteAttrib1TextBox);
            this.SitePage.Controls.Add(this.label1);
            this.SitePage.Location = new System.Drawing.Point(4, 22);
            this.SitePage.Name = "SitePage";
            this.SitePage.Padding = new System.Windows.Forms.Padding(3);
            this.SitePage.Size = new System.Drawing.Size(258, 387);
            this.SitePage.TabIndex = 0;
            this.SitePage.Text = "Site";
            this.SitePage.UseVisualStyleBackColor = true;
            // 
            // BlockPage
            // 
            this.BlockPage.Controls.Add(this.AddUnitButton);
            this.BlockPage.Controls.Add(this.AddBlockButton);
            this.BlockPage.Controls.Add(this.unitAttrib2textBox);
            this.BlockPage.Controls.Add(this.label5);
            this.BlockPage.Controls.Add(this.unitAttrib1TextBox);
            this.BlockPage.Controls.Add(this.label6);
            this.BlockPage.Controls.Add(this.blockAttrib2TextBox);
            this.BlockPage.Controls.Add(this.label3);
            this.BlockPage.Controls.Add(this.blockAttrib1TextBox);
            this.BlockPage.Controls.Add(this.label4);
            this.BlockPage.Location = new System.Drawing.Point(4, 22);
            this.BlockPage.Name = "BlockPage";
            this.BlockPage.Padding = new System.Windows.Forms.Padding(3);
            this.BlockPage.Size = new System.Drawing.Size(258, 387);
            this.BlockPage.TabIndex = 1;
            this.BlockPage.Text = "Block";
            this.BlockPage.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "attrib1";
            // 
            // SiteAttrib1TextBox
            // 
            this.SiteAttrib1TextBox.Location = new System.Drawing.Point(61, 20);
            this.SiteAttrib1TextBox.Name = "SiteAttrib1TextBox";
            this.SiteAttrib1TextBox.Size = new System.Drawing.Size(100, 20);
            this.SiteAttrib1TextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "attrib2";
            // 
            // siteAttrib2TextBox
            // 
            this.siteAttrib2TextBox.Location = new System.Drawing.Point(61, 46);
            this.siteAttrib2TextBox.Name = "siteAttrib2TextBox";
            this.siteAttrib2TextBox.Size = new System.Drawing.Size(100, 20);
            this.siteAttrib2TextBox.TabIndex = 3;
            // 
            // AddSiteButton
            // 
            this.AddSiteButton.Location = new System.Drawing.Point(156, 143);
            this.AddSiteButton.Name = "AddSiteButton";
            this.AddSiteButton.Size = new System.Drawing.Size(75, 23);
            this.AddSiteButton.TabIndex = 4;
            this.AddSiteButton.Text = "Add Site";
            this.AddSiteButton.UseVisualStyleBackColor = true;
            this.AddSiteButton.Click += new System.EventHandler(this.AddSiteButton_Click);
            // 
            // blockAttrib2TextBox
            // 
            this.blockAttrib2TextBox.Location = new System.Drawing.Point(78, 61);
            this.blockAttrib2TextBox.Name = "blockAttrib2TextBox";
            this.blockAttrib2TextBox.Size = new System.Drawing.Size(100, 20);
            this.blockAttrib2TextBox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "attrib2";
            // 
            // blockAttrib1TextBox
            // 
            this.blockAttrib1TextBox.Location = new System.Drawing.Point(78, 35);
            this.blockAttrib1TextBox.Name = "blockAttrib1TextBox";
            this.blockAttrib1TextBox.Size = new System.Drawing.Size(100, 20);
            this.blockAttrib1TextBox.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "attrib1";
            // 
            // unitAttrib2textBox
            // 
            this.unitAttrib2textBox.Location = new System.Drawing.Point(89, 165);
            this.unitAttrib2textBox.Name = "unitAttrib2textBox";
            this.unitAttrib2textBox.Size = new System.Drawing.Size(100, 20);
            this.unitAttrib2textBox.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Unit Attrib2";
            // 
            // unitAttrib1TextBox
            // 
            this.unitAttrib1TextBox.Location = new System.Drawing.Point(89, 136);
            this.unitAttrib1TextBox.Name = "unitAttrib1TextBox";
            this.unitAttrib1TextBox.Size = new System.Drawing.Size(100, 20);
            this.unitAttrib1TextBox.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Unit Attrib1";
            // 
            // AddBlockButton
            // 
            this.AddBlockButton.Location = new System.Drawing.Point(136, 97);
            this.AddBlockButton.Name = "AddBlockButton";
            this.AddBlockButton.Size = new System.Drawing.Size(75, 23);
            this.AddBlockButton.TabIndex = 12;
            this.AddBlockButton.Text = "Add block";
            this.AddBlockButton.UseVisualStyleBackColor = true;
            this.AddBlockButton.Click += new System.EventHandler(this.AddBlockButton_Click);
            // 
            // AddUnitButton
            // 
            this.AddUnitButton.Location = new System.Drawing.Point(136, 211);
            this.AddUnitButton.Name = "AddUnitButton";
            this.AddUnitButton.Size = new System.Drawing.Size(75, 23);
            this.AddUnitButton.TabIndex = 13;
            this.AddUnitButton.Text = "Add Unit";
            this.AddUnitButton.UseVisualStyleBackColor = true;
            this.AddUnitButton.Click += new System.EventHandler(this.AddUnitButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 429);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.treeView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.SitePage.ResumeLayout(false);
            this.SitePage.PerformLayout();
            this.BlockPage.ResumeLayout(false);
            this.BlockPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage SitePage;
        private System.Windows.Forms.Button AddSiteButton;
        private System.Windows.Forms.TextBox siteAttrib2TextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SiteAttrib1TextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage BlockPage;
        private System.Windows.Forms.Button AddBlockButton;
        private System.Windows.Forms.TextBox unitAttrib2textBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox unitAttrib1TextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox blockAttrib2TextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox blockAttrib1TextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button AddUnitButton;
    }
}


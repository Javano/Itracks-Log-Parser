namespace ItracksLogParser
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
            this.treeView = new System.Windows.Forms.TreeView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.iAF1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pREIAF1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.switchToPreRackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextNodeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolTraceError = new System.Windows.Forms.ToolStripMenuItem();
            this.toolExpandAll = new System.Windows.Forms.ToolStripMenuItem();
            this.lstLogs = new System.Windows.Forms.ListBox();
            this.menuStrip1.SuspendLayout();
            this.contextNodeMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView.HideSelection = false;
            this.treeView.HotTracking = true;
            this.treeView.Location = new System.Drawing.Point(148, 28);
            this.treeView.Name = "treeView";
            this.treeView.ShowNodeToolTips = true;
            this.treeView.Size = new System.Drawing.Size(540, 329);
            this.treeView.TabIndex = 0;
            this.treeView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeView_MouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iAF1ToolStripMenuItem,
            this.pREIAF1ToolStripMenuItem,
            this.switchToPreRackToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(699, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // iAF1ToolStripMenuItem
            // 
            this.iAF1ToolStripMenuItem.Name = "iAF1ToolStripMenuItem";
            this.iAF1ToolStripMenuItem.Size = new System.Drawing.Size(130, 20);
            this.iAF1ToolStripMenuItem.Text = "Switch to Production";
            this.iAF1ToolStripMenuItem.Click += new System.EventHandler(this.iAF1ToolStripMenuItem_Click);
            // 
            // pREIAF1ToolStripMenuItem
            // 
            this.pREIAF1ToolStripMenuItem.Name = "pREIAF1ToolStripMenuItem";
            this.pREIAF1ToolStripMenuItem.Size = new System.Drawing.Size(152, 20);
            this.pREIAF1ToolStripMenuItem.Text = "Switch to Pre-Production";
            this.pREIAF1ToolStripMenuItem.Click += new System.EventHandler(this.pREIAF1ToolStripMenuItem_Click);
            // 
            // switchToPreRackToolStripMenuItem
            // 
            this.switchToPreRackToolStripMenuItem.Name = "switchToPreRackToolStripMenuItem";
            this.switchToPreRackToolStripMenuItem.Size = new System.Drawing.Size(118, 20);
            this.switchToPreRackToolStripMenuItem.Text = "Switch to Pre-Rack";
            this.switchToPreRackToolStripMenuItem.Click += new System.EventHandler(this.switchToPreRackToolStripMenuItem_Click);
            // 
            // contextNodeMenu
            // 
            this.contextNodeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolTraceError,
            this.toolExpandAll});
            this.contextNodeMenu.Name = "contextNodeMenu";
            this.contextNodeMenu.Size = new System.Drawing.Size(132, 48);
            this.contextNodeMenu.Opening += new System.ComponentModel.CancelEventHandler(this.contextNodeMenu_Opening);
            // 
            // toolTraceError
            // 
            this.toolTraceError.Name = "toolTraceError";
            this.toolTraceError.Size = new System.Drawing.Size(131, 22);
            this.toolTraceError.Text = "Trace Error";
            this.toolTraceError.Visible = false;
            this.toolTraceError.Click += new System.EventHandler(this.toolTraceError_Click);
            // 
            // toolExpandAll
            // 
            this.toolExpandAll.Name = "toolExpandAll";
            this.toolExpandAll.Size = new System.Drawing.Size(131, 22);
            this.toolExpandAll.Text = "Expand All";
            this.toolExpandAll.Click += new System.EventHandler(this.toolExpandAll_Click);
            // 
            // lstLogs
            // 
            this.lstLogs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstLogs.FormattingEnabled = true;
            this.lstLogs.Location = new System.Drawing.Point(12, 28);
            this.lstLogs.Name = "lstLogs";
            this.lstLogs.Size = new System.Drawing.Size(130, 329);
            this.lstLogs.TabIndex = 2;
            this.lstLogs.SelectedValueChanged += new System.EventHandler(this.lstLogs_SelectedValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 369);
            this.Controls.Add(this.lstLogs);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Test Studio Log Parser";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextNodeMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextNodeMenu;
        private System.Windows.Forms.ToolStripMenuItem toolExpandAll;
        private System.Windows.Forms.ToolStripMenuItem toolTraceError;
        private System.Windows.Forms.ListBox lstLogs;
        private System.Windows.Forms.ToolStripMenuItem iAF1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pREIAF1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem switchToPreRackToolStripMenuItem;
    }
}


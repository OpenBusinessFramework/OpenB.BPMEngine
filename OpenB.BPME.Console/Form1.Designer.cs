namespace OpenB.BPME.Console
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Configuration");
            this.configurationTreeView = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // configurationTreeView
            // 
            this.configurationTreeView.Location = new System.Drawing.Point(12, 12);
            this.configurationTreeView.Name = "configurationTreeView";
            treeNode1.Name = "treeNodeConfiguration";
            treeNode1.Text = "Configuration";
            this.configurationTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.configurationTreeView.Size = new System.Drawing.Size(209, 393);
            this.configurationTreeView.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 417);
            this.Controls.Add(this.configurationTreeView);
            this.Name = "MainForm";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView configurationTreeView;
    }
}


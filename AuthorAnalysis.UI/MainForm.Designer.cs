namespace AuthorAnalysis.UI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.authorSummaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.authorAnalysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.RosyBrown;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.authorSummaryToolStripMenuItem,
            this.authorAnalysisToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1485, 34);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // authorSummaryToolStripMenuItem
            // 
            this.authorSummaryToolStripMenuItem.Font = new System.Drawing.Font("Berlin Sans FB", 12F, System.Drawing.FontStyle.Bold);
            this.authorSummaryToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.authorSummaryToolStripMenuItem.Name = "authorSummaryToolStripMenuItem";
            this.authorSummaryToolStripMenuItem.Size = new System.Drawing.Size(185, 30);
            this.authorSummaryToolStripMenuItem.Text = "Author Summary";
            this.authorSummaryToolStripMenuItem.Click += new System.EventHandler(this.authorSummaryToolStripMenuItem_Click);
            // 
            // authorAnalysisToolStripMenuItem
            // 
            this.authorAnalysisToolStripMenuItem.Font = new System.Drawing.Font("Berlin Sans FB", 12F, System.Drawing.FontStyle.Bold);
            this.authorAnalysisToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.authorAnalysisToolStripMenuItem.Name = "authorAnalysisToolStripMenuItem";
            this.authorAnalysisToolStripMenuItem.Size = new System.Drawing.Size(174, 30);
            this.authorAnalysisToolStripMenuItem.Text = "Author Analysis";
            this.authorAnalysisToolStripMenuItem.Click += new System.EventHandler(this.authorAnalysisToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1485, 653);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Britannic Bold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Author Analysis Tool";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem authorSummaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem authorAnalysisToolStripMenuItem;
    }
}
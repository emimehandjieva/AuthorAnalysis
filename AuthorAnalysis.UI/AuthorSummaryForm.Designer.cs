namespace AuthorAnalysis.UI
{
    partial class AuthorSummaryForm
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
            this.textBoxAuthorName = new System.Windows.Forms.TextBox();
            this.buttonGO = new System.Windows.Forms.Button();
            this.richTextBoxSummary = new System.Windows.Forms.RichTextBox();
            this.richTextBoxArticle = new System.Windows.Forms.RichTextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // textBoxAuthorName
            // 
            this.textBoxAuthorName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBoxAuthorName.Location = new System.Drawing.Point(336, 72);
            this.textBoxAuthorName.Name = "textBoxAuthorName";
            this.textBoxAuthorName.Size = new System.Drawing.Size(309, 22);
            this.textBoxAuthorName.TabIndex = 1;
            this.toolTip1.SetToolTip(this.textBoxAuthorName, "Input author text here and press the GO button");
            // 
            // buttonGO
            // 
            this.buttonGO.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonGO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGO.Location = new System.Drawing.Point(454, 100);
            this.buttonGO.Name = "buttonGO";
            this.buttonGO.Size = new System.Drawing.Size(75, 35);
            this.buttonGO.TabIndex = 2;
            this.buttonGO.Text = "GO";
            this.buttonGO.UseVisualStyleBackColor = true;
            this.buttonGO.Click += new System.EventHandler(this.buttonGO_Click);
            // 
            // richTextBoxSummary
            // 
            this.richTextBoxSummary.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.richTextBoxSummary.Location = new System.Drawing.Point(527, 170);
            this.richTextBoxSummary.Name = "richTextBoxSummary";
            this.richTextBoxSummary.ReadOnly = true;
            this.richTextBoxSummary.Size = new System.Drawing.Size(446, 363);
            this.richTextBoxSummary.TabIndex = 3;
            this.richTextBoxSummary.Text = "";
            // 
            // richTextBoxArticle
            // 
            this.richTextBoxArticle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.richTextBoxArticle.Location = new System.Drawing.Point(31, 170);
            this.richTextBoxArticle.Name = "richTextBoxArticle";
            this.richTextBoxArticle.ReadOnly = true;
            this.richTextBoxArticle.Size = new System.Drawing.Size(446, 375);
            this.richTextBoxArticle.TabIndex = 4;
            this.richTextBoxArticle.Text = "";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.progressBar1.Location = new System.Drawing.Point(336, 141);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(309, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 5;
            this.progressBar1.Visible = false;
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 1;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ReshowDelay = 1;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "I see you\'re hesitating";
            // 
            // AuthorSummaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(985, 545);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.richTextBoxArticle);
            this.Controls.Add(this.richTextBoxSummary);
            this.Controls.Add(this.buttonGO);
            this.Controls.Add(this.textBoxAuthorName);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AuthorSummaryForm";
            this.ShowIcon = false;
            this.Text = "Summary";
            this.Load += new System.EventHandler(this.AuthorSummaryForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxAuthorName;
        private System.Windows.Forms.Button buttonGO;
        private System.Windows.Forms.RichTextBox richTextBoxSummary;
        private System.Windows.Forms.RichTextBox richTextBoxArticle;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}


namespace AuthorAnalysis.UI
{
    partial class FeedBackForm
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
            this.checkBoxGender = new System.Windows.Forms.CheckBox();
            this.checkBoxEducation = new System.Windows.Forms.CheckBox();
            this.checkBoxNationality = new System.Windows.Forms.CheckBox();
            this.checkBoxPeriod = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkBoxGender
            // 
            this.checkBoxGender.AutoSize = true;
            this.checkBoxGender.Location = new System.Drawing.Point(73, 54);
            this.checkBoxGender.Name = "checkBoxGender";
            this.checkBoxGender.Size = new System.Drawing.Size(78, 21);
            this.checkBoxGender.TabIndex = 4;
            this.checkBoxGender.Text = "Gender";
            this.checkBoxGender.UseVisualStyleBackColor = true;
            // 
            // checkBoxEducation
            // 
            this.checkBoxEducation.AutoSize = true;
            this.checkBoxEducation.Location = new System.Drawing.Point(73, 108);
            this.checkBoxEducation.Name = "checkBoxEducation";
            this.checkBoxEducation.Size = new System.Drawing.Size(93, 21);
            this.checkBoxEducation.TabIndex = 5;
            this.checkBoxEducation.Text = "Education";
            this.checkBoxEducation.UseVisualStyleBackColor = true;
            // 
            // checkBoxNationality
            // 
            this.checkBoxNationality.AutoSize = true;
            this.checkBoxNationality.Location = new System.Drawing.Point(73, 81);
            this.checkBoxNationality.Name = "checkBoxNationality";
            this.checkBoxNationality.Size = new System.Drawing.Size(96, 21);
            this.checkBoxNationality.TabIndex = 6;
            this.checkBoxNationality.Text = "Nationality";
            this.checkBoxNationality.UseVisualStyleBackColor = true;
            // 
            // checkBoxPeriod
            // 
            this.checkBoxPeriod.AutoSize = true;
            this.checkBoxPeriod.Location = new System.Drawing.Point(73, 135);
            this.checkBoxPeriod.Name = "checkBoxPeriod";
            this.checkBoxPeriod.Size = new System.Drawing.Size(71, 21);
            this.checkBoxPeriod.TabIndex = 7;
            this.checkBoxPeriod.Text = "Period";
            this.checkBoxPeriod.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(76, 177);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FeedBackForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 267);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBoxPeriod);
            this.Controls.Add(this.checkBoxNationality);
            this.Controls.Add(this.checkBoxEducation);
            this.Controls.Add(this.checkBoxGender);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FeedBackForm";
            this.Text = "FeedBackForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxGender;
        private System.Windows.Forms.CheckBox checkBoxEducation;
        private System.Windows.Forms.CheckBox checkBoxNationality;
        private System.Windows.Forms.CheckBox checkBoxPeriod;
        private System.Windows.Forms.Button button1;
    }
}
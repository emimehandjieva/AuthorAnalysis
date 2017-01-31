namespace AuthorAnalysis.UI
{
    partial class AuthorAnalysisForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxEdu = new System.Windows.Forms.ComboBox();
            this.educationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.authorAnalysisDataDataSet = new AuthorAnalysis.UI.AuthorAnalysisDataDataSet();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxPeriod = new System.Windows.Forms.ComboBox();
            this.periodBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxAuthorName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxNationality = new System.Windows.Forms.ComboBox();
            this.nationalityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxGender = new System.Windows.Forms.ComboBox();
            this.genderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.authorAnalysisDataDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.buttonTrain = new System.Windows.Forms.Button();
            this.buttonEvaluate = new System.Windows.Forms.Button();
            this.genderTableAdapter = new AuthorAnalysis.UI.AuthorAnalysisDataDataSetTableAdapters.GenderTableAdapter();
            this.periodTableAdapter = new AuthorAnalysis.UI.AuthorAnalysisDataDataSetTableAdapters.PeriodTableAdapter();
            this.nationalityTableAdapter = new AuthorAnalysis.UI.AuthorAnalysisDataDataSetTableAdapters.NationalityTableAdapter();
            this.educationTableAdapter = new AuthorAnalysis.UI.AuthorAnalysisDataDataSetTableAdapters.EducationTableAdapter();
            this.buttonSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.educationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.authorAnalysisDataDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.periodBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nationalityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.genderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.authorAnalysisDataDataSetBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.comboBoxEdu);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.comboBoxPeriod);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxAuthorName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBoxNationality);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxGender);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(13, 422);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1162, 124);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Author Information";
            // 
            // comboBoxEdu
            // 
            this.comboBoxEdu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxEdu.DataSource = this.educationBindingSource;
            this.comboBoxEdu.DisplayMember = "Description";
            this.comboBoxEdu.FormattingEnabled = true;
            this.comboBoxEdu.Location = new System.Drawing.Point(803, 84);
            this.comboBoxEdu.Name = "comboBoxEdu";
            this.comboBoxEdu.Size = new System.Drawing.Size(167, 24);
            this.comboBoxEdu.TabIndex = 9;
            this.comboBoxEdu.ValueMember = "EdicationLevelID";
            // 
            // educationBindingSource
            // 
            this.educationBindingSource.DataMember = "Education";
            this.educationBindingSource.DataSource = this.authorAnalysisDataDataSet;
            // 
            // authorAnalysisDataDataSet
            // 
            this.authorAnalysisDataDataSet.DataSetName = "AuthorAnalysisDataDataSet";
            this.authorAnalysisDataDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(528, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Education";
            // 
            // comboBoxPeriod
            // 
            this.comboBoxPeriod.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxPeriod.DataSource = this.periodBindingSource;
            this.comboBoxPeriod.DisplayMember = "PeriodName";
            this.comboBoxPeriod.FormattingEnabled = true;
            this.comboBoxPeriod.Location = new System.Drawing.Point(803, 54);
            this.comboBoxPeriod.Name = "comboBoxPeriod";
            this.comboBoxPeriod.Size = new System.Drawing.Size(167, 24);
            this.comboBoxPeriod.TabIndex = 7;
            this.comboBoxPeriod.ValueMember = "PeriodID";
            // 
            // periodBindingSource
            // 
            this.periodBindingSource.DataMember = "Period";
            this.periodBindingSource.DataSource = this.authorAnalysisDataDataSet;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(528, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Period of writing career";
            // 
            // textBoxAuthorName
            // 
            this.textBoxAuthorName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxAuthorName.Location = new System.Drawing.Point(447, 19);
            this.textBoxAuthorName.Name = "textBoxAuthorName";
            this.textBoxAuthorName.Size = new System.Drawing.Size(289, 22);
            this.textBoxAuthorName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(281, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Name";
            // 
            // comboBoxNationality
            // 
            this.comboBoxNationality.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxNationality.DataSource = this.nationalityBindingSource;
            this.comboBoxNationality.DisplayMember = "Name";
            this.comboBoxNationality.FormattingEnabled = true;
            this.comboBoxNationality.Location = new System.Drawing.Point(240, 87);
            this.comboBoxNationality.Name = "comboBoxNationality";
            this.comboBoxNationality.Size = new System.Drawing.Size(175, 24);
            this.comboBoxNationality.TabIndex = 3;
            this.comboBoxNationality.ValueMember = "NationalityID";
            // 
            // nationalityBindingSource
            // 
            this.nationalityBindingSource.DataMember = "Nationality";
            this.nationalityBindingSource.DataSource = this.authorAnalysisDataDataSet;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(25, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nationality";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(25, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Gender";
            // 
            // comboBoxGender
            // 
            this.comboBoxGender.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxGender.DataSource = this.genderBindingSource;
            this.comboBoxGender.DisplayMember = "Name";
            this.comboBoxGender.FormattingEnabled = true;
            this.comboBoxGender.Location = new System.Drawing.Point(240, 58);
            this.comboBoxGender.Name = "comboBoxGender";
            this.comboBoxGender.Size = new System.Drawing.Size(175, 24);
            this.comboBoxGender.TabIndex = 0;
            this.comboBoxGender.ValueMember = "GenderID";
            // 
            // genderBindingSource
            // 
            this.genderBindingSource.DataMember = "Gender";
            this.genderBindingSource.DataSource = this.authorAnalysisDataDataSetBindingSource;
            // 
            // authorAnalysisDataDataSetBindingSource
            // 
            this.authorAnalysisDataDataSetBindingSource.DataSource = this.authorAnalysisDataDataSet;
            this.authorAnalysisDataDataSetBindingSource.Position = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.richTextBox1);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox2.Location = new System.Drawing.Point(12, 178);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1134, 238);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Text";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(129, 40);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(871, 170);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // buttonTrain
            // 
            this.buttonTrain.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonTrain.BackColor = System.Drawing.Color.Transparent;
            this.buttonTrain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTrain.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonTrain.Location = new System.Drawing.Point(317, 97);
            this.buttonTrain.Name = "buttonTrain";
            this.buttonTrain.Size = new System.Drawing.Size(153, 35);
            this.buttonTrain.TabIndex = 2;
            this.buttonTrain.Text = "Train the system";
            this.buttonTrain.UseVisualStyleBackColor = false;
            this.buttonTrain.Click += new System.EventHandler(this.buttonTrain_Click);
            // 
            // buttonEvaluate
            // 
            this.buttonEvaluate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonEvaluate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEvaluate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonEvaluate.Location = new System.Drawing.Point(638, 97);
            this.buttonEvaluate.Name = "buttonEvaluate";
            this.buttonEvaluate.Size = new System.Drawing.Size(165, 35);
            this.buttonEvaluate.TabIndex = 3;
            this.buttonEvaluate.Text = "Analyze the author";
            this.buttonEvaluate.UseVisualStyleBackColor = true;
            this.buttonEvaluate.Click += new System.EventHandler(this.buttonEvaluate_Click);
            // 
            // genderTableAdapter
            // 
            this.genderTableAdapter.ClearBeforeFill = true;
            // 
            // periodTableAdapter
            // 
            this.periodTableAdapter.ClearBeforeFill = true;
            // 
            // nationalityTableAdapter
            // 
            this.nationalityTableAdapter.ClearBeforeFill = true;
            // 
            // educationTableAdapter
            // 
            this.educationTableAdapter.ClearBeforeFill = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonSave.BackColor = System.Drawing.Color.Transparent;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonSave.Location = new System.Drawing.Point(509, 564);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(153, 35);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // AuthorAnalysisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(1199, 611);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonEvaluate);
            this.Controls.Add(this.buttonTrain);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AuthorAnalysisForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "AuthorAnalysisForm";
            this.Load += new System.EventHandler(this.AuthorAnalysisForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.educationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.authorAnalysisDataDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.periodBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nationalityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.genderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.authorAnalysisDataDataSetBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button buttonTrain;
        private System.Windows.Forms.Button buttonEvaluate;
        private System.Windows.Forms.ComboBox comboBoxNationality;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxGender;
        private System.Windows.Forms.ComboBox comboBoxEdu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxPeriod;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxAuthorName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource authorAnalysisDataDataSetBindingSource;
        private AuthorAnalysisDataDataSet authorAnalysisDataDataSet;
        private System.Windows.Forms.BindingSource genderBindingSource;
        private AuthorAnalysisDataDataSetTableAdapters.GenderTableAdapter genderTableAdapter;
        private System.Windows.Forms.BindingSource periodBindingSource;
        private AuthorAnalysisDataDataSetTableAdapters.PeriodTableAdapter periodTableAdapter;
        private System.Windows.Forms.BindingSource nationalityBindingSource;
        private AuthorAnalysisDataDataSetTableAdapters.NationalityTableAdapter nationalityTableAdapter;
        private System.Windows.Forms.BindingSource educationBindingSource;
        private AuthorAnalysisDataDataSetTableAdapters.EducationTableAdapter educationTableAdapter;
        private System.Windows.Forms.Button buttonSave;
    }
}
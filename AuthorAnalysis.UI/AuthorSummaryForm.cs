using AuthorAnalysis.Summarizer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuthorAnalysis.UI
{
    public partial class AuthorSummaryForm : Form
    {
        private const string _emptyResultMessage = "The requested author yielded no wikipedia article,please try again";
        string result;

        public AuthorSummaryForm()
        {
            InitializeComponent();
        }

        private async void buttonGO_Click(object sender, EventArgs e)
        {
            richTextBoxArticle.Text = string.Empty;
            richTextBoxSummary.Text = string.Empty;
            if (textBoxAuthorName.Text == string.Empty)
            {
                return;
            }
            var initial = SummarizeManager.GetArticle(textBoxAuthorName.Text);
            if(initial == string.Empty)
            {
                MessageBox.Show(_emptyResultMessage, "No information found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            richTextBoxArticle.Text = initial;

            progressBar1.Visible = true;
            // Run operation in another thread
            await Task.Run(() => DoWork());
            progressBar1.Visible = false;
            richTextBoxSummary.Text = result;
            MessageBox.Show("Summarization ready!");
            
        }

        private void DoWork()
        {
            result = SummarizeManager.Summarize(textBoxAuthorName.Text);
        }

        private void AuthorSummaryForm_Load(object sender, EventArgs e)
        {
            richTextBoxArticle.Focus();
        }
    }
}

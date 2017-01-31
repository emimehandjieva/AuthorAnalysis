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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);
        }

        private void authorSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<AuthorSummaryForm>().Any())
            {
                Application.OpenForms.OfType<AuthorSummaryForm>().First().BringToFront();
            }
            else
            {
                AuthorSummaryForm form = new AuthorSummaryForm();
                form.Size = this.Size;
                form.MdiParent = this;
                form.Show();
            }
        }

        private void authorAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<AuthorAnalysisForm>().Any())
            {
                Application.OpenForms.OfType<AuthorAnalysisForm>().First().BringToFront();
            }
            else
            {
                AuthorAnalysisForm form = new AuthorAnalysisForm();
                form.Size = this.Size;
                form.MdiParent = this;
                form.Show();
            }
        }
    }
}

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
            AuthorSummaryForm  form = new AuthorSummaryForm();
            form.MdiParent = this;
            form.Show();
        }

        private void authorAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AuthorAnalysisForm form = new AuthorAnalysisForm();
            form.MdiParent = this;
            form.Show();
        }
    }
}

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
    public partial class FeedBackForm : Form
    {
        public bool Gender;
        public bool Nationality;
        public bool Education;
        public bool Period;

        public FeedBackForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Gender = checkBoxGender.Checked;
            this.Education = checkBoxEducation.Checked;
            this.Nationality = checkBoxNationality.Checked;
            this.Period = checkBoxPeriod.Checked;
            this.Close();
        }
    }
}

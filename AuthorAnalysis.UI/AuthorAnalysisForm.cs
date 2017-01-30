using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AuthorAnalysis.Data;
using AuthorAnalysis.TextProcessor;
using System.Data.Entity.Validation;

namespace AuthorAnalysis.UI
{
    public partial class AuthorAnalysisForm : Form
    {
        AuthorAnalysisDataEntities context;
        Book CurrentBook;
        Author CurrentAuthor;

        public AuthorAnalysisForm()
        {
            InitializeComponent();
            context = new AuthorAnalysisDataEntities();
        }

        private void buttonTrain_Click(object sender, EventArgs e)
        {

            int education =Convert.ToInt32( (comboBoxEdu.SelectedItem as DataRowView)[0]);
            int period = Convert.ToInt32((comboBoxPeriod.SelectedItem as DataRowView)[0]);
            int nationality = Convert.ToInt32((comboBoxNationality.SelectedItem as DataRowView)[0]); 
            int gender = Convert.ToInt32((comboBoxGender.SelectedItem as DataRowView)[0]);
            string name = textBoxAuthorName.Text;

            CurrentAuthor = new Author();
            CurrentAuthor.Name = name;

            if(context.Authors.Any(a=>a.Name==name))
            {
                MessageBox.Show("author already present in database, input a new one!");
                return;
            }
            CurrentAuthor.Education = context.Educations.Where(ed => ed.EdicationLevelID == education).First();
            CurrentAuthor.AuthorID = context.Authors.Max(a => a.AuthorID) + 1;
            CurrentAuthor.EducationLevelID = education;
            CurrentAuthor.Period = context.Periods.Where(p => p.PeriodID == period).First();
            CurrentAuthor.PeriodID = period;
            CurrentAuthor.Nationality = context.Nationalities.Where(n => n.NationalityID == nationality).First();
            CurrentAuthor.NationalityID = nationality;
            CurrentAuthor.Gender = context.Genders.Where(g => g.GenderID == gender).First();
            CurrentAuthor.GenderID = gender;

            CurrentBook = new Book();
            CurrentBook.BookID = context.Books.Max(b => b.BookID) + 1;
            CurrentBook.Text = richTextBox1.Text;
            TextManager.AnalyzeText(CurrentBook);


            CurrentBook.Author = CurrentAuthor;
            context.Books.Add(CurrentBook);
            context.Authors.Add(CurrentAuthor);
            try
            {
                context.SaveChanges();
                MessageBox.Show("New author is analized!");
            }
            catch  (DbEntityValidationException ex)
            {

                throw;
            }
            
        }

        private void AuthorAnalysisForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'authorAnalysisDataDataSet.Education' table. You can move, or remove it, as needed.
            this.educationTableAdapter.Fill(this.authorAnalysisDataDataSet.Education);
            // TODO: This line of code loads data into the 'authorAnalysisDataDataSet.Nationality' table. You can move, or remove it, as needed.
            this.nationalityTableAdapter.Fill(this.authorAnalysisDataDataSet.Nationality);
            // TODO: This line of code loads data into the 'authorAnalysisDataDataSet.Period' table. You can move, or remove it, as needed.
            this.periodTableAdapter.Fill(this.authorAnalysisDataDataSet.Period);
            // TODO: This line of code loads data into the 'authorAnalysisDataDataSet.Gender' table. You can move, or remove it, as needed.
            this.genderTableAdapter.Fill(this.authorAnalysisDataDataSet.Gender);

        }
    }
}

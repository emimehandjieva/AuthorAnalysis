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
using LinqToExcel;

namespace AuthorAnalysis.UI
{
    public partial class AuthorAnalysisForm : Form
    {
        AuthorAnalysisDataEntities context;
        Book CurrentBook;
        Author CurrentAuthor;
        double correctGender;
        double correctEducation;
        double correctNationality;
        double correctPeriod;
        double total;


        public AuthorAnalysisForm()
        {
            InitializeComponent();
            context = new AuthorAnalysisDataEntities();
            
        }

        private bool FormHasEmptyFields
        {
            get
            {

                return richTextBox1.Text == string.Empty || textBoxAuthorName.Text == string.Empty;
            }
        }

        private void ProcessBookText()
        {

            CurrentBook = new Book();
            CurrentBook.BookID = context.Books.Max(b => b.BookID) + 1;
            CurrentBook.Text = richTextBox1.Text;
            TextManager.AnalyzeText(CurrentBook);
            //int counter = context.NamedEntities.Max(e => e.NamedEntityID) + 1;
            //foreach (var entiry in CurrentBook.NamedEntities)
            //{
            //    entiry.NamedEntityID = counter;counter++;
            //}

            CurrentBook.Author = CurrentAuthor;
        }

        private void TakeAuthorData()
        {
            int education = Convert.ToInt32((comboBoxEdu.SelectedItem as DataRowView)[0]);
            int period = Convert.ToInt32((comboBoxPeriod.SelectedItem as DataRowView)[0]);
            int nationality = Convert.ToInt32((comboBoxNationality.SelectedItem as DataRowView)[0]);
            int gender = Convert.ToInt32((comboBoxGender.SelectedItem as DataRowView)[0]);
            string name = textBoxAuthorName.Text;

            CurrentAuthor = new Author();
            CurrentAuthor.Name = name;

            if (context.Authors.Any(a => a.Name == name))
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
        }


        private void buttonTrain_Click(object sender, EventArgs e)
        {
            if (FormHasEmptyFields)
            {
                MessageBox.Show("Author's name or text to analyze are empty,try again!");
                return;
            }

            TakeAuthorData();

            ProcessBookText();

            CurrentBook.Author = CurrentAuthor;
            context.Books.Add(CurrentBook);
            context.Authors.Add(CurrentAuthor);

            MessageBox.Show("Book Analyzed!");

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

        private void buttonEvaluate_Click(object sender, EventArgs e)
        {
            if (FormHasEmptyFields)
            {
                MessageBox.Show("Author's name or text to analyze are empty,try again!");
                return;
            }

            string name = textBoxAuthorName.Text;

            CurrentAuthor = new Author();
            CurrentAuthor.Name = name;
            CurrentAuthor.AuthorID = context.Authors.Max(a => a.AuthorID) + 1;


            ProcessBookText();

            TextAnalysisTrainer.Classify(CurrentBook, context.Books.ToList(),CurrentAuthor);
            CurrentAuthor.Gender = context.Genders.Where(g => g.GenderID == CurrentAuthor.GenderID).First();
            
            comboBoxGender.SelectedIndex = comboBoxGender.FindString( CurrentAuthor.Gender.Name);
            comboBoxNationality.SelectedIndex = comboBoxNationality.FindString(CurrentAuthor.Nationality.Name);
            comboBoxPeriod.SelectedIndex = comboBoxPeriod.FindString(CurrentAuthor.Period.PeriodName);
            comboBoxEdu.SelectedIndex = comboBoxEdu.FindString(CurrentAuthor.Education.Description);


            FeedBackForm form = new FeedBackForm();
            form.ShowDialog();

            if(form.Education)
            {
                this.correctEducation++;
            }

            if (form.Gender)
            {
                this.correctGender++;
            }
            if (form.Period)
            {
                this.correctPeriod++;
            }
            if (form.Nationality)
            {
                this.correctNationality++;
            }
            total++;
            
            context.Books.Add(CurrentBook);
            context.Authors.Add(CurrentAuthor);
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    var docPath = openFileDialog1.FileName;
                    var source = new ExcelQueryFactory(docPath);
                    List<Author> authors = new List<Author>();
                    var authorId = context.Authors.Max(a => a.AuthorID) + 1;
                    foreach (var row in source.Worksheet(0).AsEnumerable())
                    {
                        Author au = new Author()
                        {
                            AuthorID = authorId,
                            Name = row[0].Cast<string>().Trim(),
                            GenderID = row[1].Cast<int>(),
                            EducationLevelID = row[2].Cast<int>(),
                            PeriodID = row[3].Cast<int>(),
                            NationalityID = row[4].Cast<int>(),

                        };

                        authors.Add(au);
                        authorId++;
                    }


                    List<Book> books = new List<Book>();
                    int bookId = context.Books.Max(a => a.BookID) + 1;
                    foreach (var row in source.Worksheet(0).AsEnumerable())
                    {
                        Book book = new Book()
                        {
                            BookID = bookId,
                            Text = row[5].Cast<string>(),
                            TempAuthorName = row[0].Cast<string>().Trim()
                        };

                        books.Add(book);
                        bookId++;
                    }

                    foreach (Book book in books)
                    {
                        TextManager.AnalyzeText(book);
                        book.AuthorID = authors.Where(a => a.Name == book.TempAuthorName).FirstOrDefault().AuthorID;
                    }

                    context.Authors.AddRange(authors);
                    context.Books.AddRange(books);
                    context.SaveChanges();
                   
                }
            }
            catch (DbEntityValidationException)
            {

                throw;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                TakeAuthorData();


                context.SaveChanges();
                context = new AuthorAnalysisDataEntities();
                MessageBox.Show("Data Saved!");
            }
            catch (DbEntityValidationException)
            {

                throw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string resultG = string.Format("Correctly classified gender: {0} %", (correctGender*100 / total).ToString());
            string resultE = string.Format("Correctly classified education: {0} %", (correctEducation * 100 / total).ToString());
            string resultN = string.Format("Correctly classified nationality: {0} %", (correctNationality * 100 / total).ToString());
            string resultP = string.Format("Correctly classified period: {0} %", (correctPeriod * 100 / total).ToString());
            MessageBox.Show(resultG + Environment.NewLine + resultE + Environment.NewLine + resultN + Environment.NewLine + resultP + Environment.NewLine);
        }
    }
}

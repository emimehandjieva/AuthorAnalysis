using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorAnalysis.Data
{
    public partial class Book
    {
        private double similarity;
        public double Similarity
        {
            get
            {
                return similarity;
            }

            set
            {
                similarity = value;
            }
        }
    }
}

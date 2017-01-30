using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorAnalysis.Summarizer
{
    public struct SentenceEntity
    {
        public string Text { get; set; }
        public int Position { get; set; }
        public double Weight { get; set; }
    }
}

﻿using AuthorAnalysis.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AuthorAnalysis.TextProcessor
{
    public static class TextAnalysisTrainer
    {
        private static List<string> _stopWords;

        private static int K = 10;
        

        public static void KNearestNEighbours(Book newBook, List<Book> oldBooks)
        {
            foreach (Book book in oldBooks)
            {
                book.Similarity =  CompareSimilarity(newBook, book)/ CompareDifferences(newBook, book);
            }

            var chosen = oldBooks.OrderBy(b => b.Similarity).Take(K);

            newBook.Author.Gender = chosen.Select(b => b.Author.Gender).GroupBy(item => item).OrderByDescending(g => g.Count()).Select(g => g.Key).First();
            newBook.Author.Nationality = chosen.Select(b => b.Author.Nationality).GroupBy(item => item).OrderByDescending(g => g.Count()).Select(g => g.Key).First();
            newBook.Author.Period = chosen.Select(b => b.Author.Period).GroupBy(item => item).OrderByDescending(g => g.Count()).Select(g => g.Key).First();
            newBook.Author.Education = chosen.Select(b => b.Author.Education).GroupBy(item => item).OrderByDescending(g => g.Count()).Select(g => g.Key).First();


        }

        private static double CompareDifferences(Book newBook, Book oldBook)
        {
            return Math.Abs((newBook.AverageSentenceWordCount - oldBook.AverageSentenceWordCount) +
                            (newBook.PunctoationToWordRatio - oldBook.PunctoationToWordRatio) +
                            (newBook.NounToWordRatio - oldBook.NounToWordRatio) +
                            (newBook.VerbToWordRatio - oldBook.VerbToWordRatio) +
                            (newBook.AdjectiveToWordRatio - oldBook.AdjectiveToWordRatio) +
                            (newBook.AdverbToWordRatio - oldBook.AdverbToWordRatio));
        }

        public static double CompareSimilarity(Book newBook, Book oldBook)
        {
            string[] words1 = EatWhiteChar(newBook.Text);
            string[] words2 = EatWhiteChar(oldBook.Text);


            Dictionary<string, double> frequencyTable1 = PrepareFrequency(words1);
            Dictionary<string, double> frequencyTable2 = PrepareFrequency(words2);

            //foreach (KeyValuePair<string, double> kv in frequencyTable1)
            //{
            //    Console.WriteLine("The word : {0} has repeated {1}", kv.Key, kv.Value);
            //}

            Dictionary<string, double> tfTable1 = TfFactorized(frequencyTable1);
            Dictionary<string, double> tfTable2 = TfFactorized(frequencyTable2);

            Dictionary<string, double>[] tables = new Dictionary<string, double>[2];
            tables[0] = tfTable1;
            tables[1] = tfTable2;

            PrepareAllHashTables(tables);
            return CosineSimilarity(tfTable1, tfTable2);

        }

        private static string[] EatWhiteChar(string sentence)
        {
            char[] cSentence = sentence.ToCharArray();

            ArrayList wordList = new ArrayList();
            int index = 0;

            string word = "";
            while (index < sentence.Length)
            {

                while (index < sentence.Length && ((cSentence[index] == ' ' || cSentence[index] == '\n' || cSentence[index] == '\r' || cSentence[index] == '\t')))
                    index++;

                while (index < cSentence.Length && ((cSentence[index] != ' ' && cSentence[index] != '\n' && cSentence[index] != '\r' && cSentence[index] != '\t')))
                    word += cSentence[index++];

                if (word != "" && !_stopWords.Contains(word))
                {
                    wordList.Add(word);
                    word = "";
                }


            }

            return (string[])wordList.ToArray(typeof(string));
        }
        private static string FromSource(string source)
        {
            StreamReader rdr = new StreamReader(source);
            string text = rdr.ReadToEnd();

            rdr.Close();

            return text;
        }


        private static Dictionary<string, double> PrepareFrequency(string[] words)
        {
            Dictionary<string, double> table = new Dictionary<string, double>();

            foreach (string word in words)
            {
                if (table.ContainsKey(word))
                    table[word]++;
                else
                    table.Add(word, 1);
            }

            return table;
        }

        private static Dictionary<string, double> TfFactorized(Dictionary<string, double> table)
        {
            double sum = 0;

            foreach (KeyValuePair<string, double> kv in table)
            {
                sum += kv.Value;
            }


            Dictionary<string, double> tfTable = new Dictionary<string, double>();
            foreach (KeyValuePair<string, double> kv in table)
            {
                tfTable.Add(kv.Key, kv.Value / sum);
            }

            return tfTable;

        }

        private static Dictionary<string, double> IDFDocumentTable(Dictionary<string, double>[] PreparedTables)
        {
            if (PreparedTables == null)
                throw new InvalidOperationException("Prepared Tables can not be null..");

            Dictionary<string, double> tfidfTable = new Dictionary<string, double>();

            //number of documents that contain the word
            int di = 0;

            //number of documents
            int nDoc = PreparedTables.Length;


            foreach (KeyValuePair<string, double> kv in PreparedTables[0])
            {
                foreach (Dictionary<string, double> table in PreparedTables)
                {
                    if (table.ContainsKey(kv.Key))
                        di++;
                }
                tfidfTable.Add(kv.Key, (Math.Log(nDoc / di)) + 1);
                di = 0;
            }

            return tfidfTable;

        }

        private static Dictionary<string, double>[] GetPreparedTFIDFTables(Dictionary<string, double> tfidfTable, params Dictionary<string, double>[] Tables)
        {
            if (Tables == null)
                throw new InvalidOperationException("Tables can not be null..");

            ArrayList tableList = new ArrayList();

            foreach (Dictionary<string, double> table in Tables)
            {
                Dictionary<string, double> newTable = new Dictionary<string, double>();
                foreach (KeyValuePair<string, double> kv in table)
                {
                    newTable.Add(kv.Key, tfidfTable[kv.Key] * kv.Value);
                }
                tableList.Add(newTable);
            }

            return (Dictionary<string, double>[])tableList.ToArray(typeof(Dictionary<string, double>));

        }



        private static void PrepareAllHashTables(Dictionary<string, double>[] tables)
        {
            for (int i = 0; i < tables.Length; i++)
            {
                for (int j = 1; j < tables.Length; j++)
                    PrepareTwoHashTable(tables[i], tables[j]);
            }
        }

        private static void PrepareTwoHashTable(Dictionary<string, double> table1, Dictionary<string, double> table2)
        {
            //for table1
            foreach (KeyValuePair<string, double> kv in table1)
            {
                if (!table2.ContainsKey(kv.Key))
                    table2.Add(kv.Key, 0);
            }

            //for table2
            foreach (KeyValuePair<string, double> kv in table2)
            {
                if (!table1.ContainsKey(kv.Key))
                    table1.Add(kv.Key, 0);
            }

        }

        private static double CosineSimilarity(Dictionary<string, double> table1, Dictionary<string, double> table2)
        {
            if (table1.Count != table2.Count)
                throw new InvalidOperationException("Table sizes must be equal");

            //length of table 1
            double length1 = 0;
            double length2 = 0;

            //double firstValue;
            double secValue;

            //sum of vector multiplication
            double svMul = 0;

            foreach (KeyValuePair<string, double> kv in table1)
            {

                length1 += Math.Pow(kv.Value, 2);

                secValue = table2[kv.Key];
                length2 += Math.Pow(secValue, 2);

                svMul += secValue * kv.Value;




            }

            length1 = Math.Sqrt(length1);
            length2 = Math.Sqrt(length2);

            return svMul / (length1 * length2);
        }



        private static void IncludeStopWords()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"StopWords.txt");
            _stopWords = new List<string>();
            string line;
            using (System.IO.StreamReader file = new System.IO.StreamReader(path))
            {
                while ((line = file.ReadLine()) != null)
                {
                    _stopWords.Add(line.Trim());
                }
            }
        }
    }
}
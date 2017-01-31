using edu.stanford.nlp.ling;
using edu.stanford.nlp.pipeline;
using edu.stanford.nlp.time;
using edu.stanford.nlp.util;
using java.io;
using java.util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace AuthorAnalysis.Summarizer
{
    public static class SummarizeManager
    {
        #region Variables
        private static List<SentenceEntity> _structuredData;
        private static string rawText;
        private static List<string> _bonusWords;
        private static List<string> _stopWords;
        private static string query = "http://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&explaintext=1&titles=";

        private static List<string> endMarks = new List<string>()
        {
            "== External links ==",
            "=== Books ===",
            "=== Articles ===",
            "== Further reading ==",
            "== References ==",
            "== Sources ==",
            "== See also ==",
            "== Notes ==",
            "== References ==",
             "== Bibliography =="
        };
        #endregion

        public static string Summarize(string authorName)
        {
            _structuredData = new List<SentenceEntity>();
            IncludeSignificantWords();
            IncludeStopWords();
            rawText = GetArticle(authorName);
            rawText = RemoveBetween(rawText,"==","==");
            rawText = RemoveBetween(rawText, "===", "===");

            ProcessText();

            return String.Join(" ", _structuredData.Where(data=>!data.Text.StartsWith("The"))
                .Where(data => !data.Text.StartsWith("The "))
                .OrderByDescending(data => data.Weight)
                .Take(_structuredData.Count / 3)
                .OrderBy(entity => entity.Position)
                .Select(data => data.Text));
        }


        public static string GetArticle(string name)
        {
            WebClient client = new WebClient();
            string fullQuery = query + name.Replace(' ', '_');
            StringBuilder builder = new StringBuilder();
            using (Stream stream = client.OpenRead(fullQuery))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    Result result = serializer.Deserialize<Result>(new JsonTextReader(reader));
                    foreach (Page page in result.Query.Pages.Values)
                    {
                        builder.Append(page.Extract);
                    }
                }
            }
            string rawText = builder.ToString();

            foreach (string mark in endMarks)
            {
                int index = rawText.IndexOf(mark);
                if (index > 0)
                {
                    rawText = rawText.Substring(0, index);
                }
            }

            return rawText;
        }

       

        private static void ProcessText()
        {
            Dictionary<string, int> frequencies = GetWordFrequency(CleanPunctoation(rawText));

            //These lines are intended to work with a randomly reoccuring issue with java's libraries which is, currently, not happening
            //var t = typeof(com.sun.codemodel.@internal.ClassType); // IKVM.OpenJDK.Tools
            //t = typeof(com.sun.org.apache.xalan.@internal.xsltc.trax.TransformerFactoryImpl); // IKVM.OpenJDK.XML.Transform
            //t = typeof(com.sun.org.glassfish.external.amx.AMX); // IKVM.OpenJDK.XML.WebServices

            // Apparently a known isue, this little gimmick seems to solve a nasty System.TypeInitializationException that hopefully won't reappear again
            SetCulture();
            
            var pipeline = PipelineBuilder.GetPipeLine();

            // Annotation
            var annotation = new Annotation(rawText);
            pipeline.annotate(annotation);

            // these are all the sentences in this document
            // a CoreMap is essentially a Map that uses class objects as keys and has values with custom types (this comment comes from the original code but I kept it to ensure readability of code)


            var rawSentences = annotation.get(new CoreAnnotations.SentencesAnnotation().getClass()) as ArrayList;
            int counter = 1;
            int frequency;
            foreach (CoreMap sentence in rawSentences)
            {
                SentenceEntity newEntity = new SentenceEntity();
                newEntity.Text = sentence.get(new CoreAnnotations.TextAnnotation().getClass()) as string;
                newEntity.Position = counter;
                var tokens = sentence.get(new CoreAnnotations.TokensAnnotation().getClass()) as ArrayList;
                double multiplier = 1;
                foreach (CoreLabel token in tokens)
                {
                    var word = token.get(new CoreAnnotations.TextAnnotation().getClass()) as string;
                    word = CleanPunctoation(word);
                    if (_bonusWords.Contains(word))
                    {
                        multiplier++;
                    }
                    var pos = token.get(new CoreAnnotations.PartOfSpeechAnnotation().getClass()) as string;

                    int posValue = DetermineSignificance(pos);

                    if (frequencies.TryGetValue(word.ToLower(), out frequency))
                    {
                        newEntity.Weight += posValue * frequency;
                    }
                    else
                    {
                        newEntity.Weight += posValue;
                    }
                }
                newEntity.Weight = (newEntity.Weight * multiplier) / rawText.Length;

                _structuredData.Add(newEntity);
                counter++;
            }

        }


        private static int DetermineSignificance(string pos)
        {
            //Was to be an enumeration but transferring from string to enum to int multiple times per word seemed horrible
            switch (pos)
            {
                case "VB":
                case "VBD":
                case "VBG":
                case "VBN":
                case "VBP":
                case "VBZ":
                    return 5;
                case "NN":
                case "NNS":
                case "NNP":
                case "NNPS":
                    return 3;
                case "RB":
                case "RBR":
                case "RBS":
                    return 3;
                case "JJ":
                case "JJR":
                case "JJS":
                    return 3;
                case "WDT":
                    return 1;
                case "WP$":
                    return 1;
                case "WP":
                    return 1;
                case "WRB":
                    return 1;
                case "CC":
                    return 1;
                case "CD":
                    return 3;
                case "DT":
                    return 0;
                case "EX":
                    return 1;
                case "FW":
                    return 2;
                case "IN":
                    return 2;
                case "LS":
                    return 1;
                case "MD":
                    return 1;
                case "PDT":
                    return 1;
                case "POS":
                    return 1;
                case "PRP":
                    return 2;
                case "PRP$":
                    return 2;
                case "RP":
                    return 1;
                case "SYM":
                    return 1;
                case "TO":
                    return 0;
                case "UH":
                    return 0;
                default: return 0;
            }

        }


        private static void IncludeSignificantWords()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data.txt");
            _bonusWords = new List<string>();
            string line;
            using (System.IO.StreamReader file = new System.IO.StreamReader(path))
            {
                while ((line = file.ReadLine()) != null)
                {
                    _bonusWords.Add(line.Trim());
                }
            }
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


        private static string CleanPunctoation(string text)
        {
            return text.Replace(".", string.Empty).Replace(",", string.Empty).Replace("?", string.Empty).Replace("!", string.Empty).Replace(";", string.Empty).Replace("-", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty);

        }

        private static string RemoveBetween(string s, string begin, string end)
        {
            Regex regex = new Regex(string.Format("\\{0}.*?\\{1}", begin, end));
            return regex.Replace(s, string.Empty).Replace("\n", string.Empty);
        }

        private static Dictionary<string, int> GetWordFrequency(string text)
        {
            return text.ToLower().Split(new char[] { ' ' })
                        .Where(x => x != string.Empty && !_stopWords.Contains(x))
                        .GroupBy(x => x)
                        .ToDictionary(x => x.Key.ToLower(), x => x.Count());
        }


        private static void SetCulture()
        {
            CultureInfo ci = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }

    }
}

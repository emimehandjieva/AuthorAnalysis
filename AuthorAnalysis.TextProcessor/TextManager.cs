﻿using AuthorAnalysis.Data;
using AuthorAnalysis.Summarizer;
using edu.stanford.nlp.ling;
using edu.stanford.nlp.pipeline;
using edu.stanford.nlp.time;
using edu.stanford.nlp.util;
using java.util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorAnalysis.TextProcessor
{
    public static class TextManager
    {

        #region Private Variables
        private static double wordCount;
        private static double verbCount;
        private static double nounCount;
        private static double adjCount;
        private static double advCount;
        private static double punctCount;
        #endregion


        public static void AnalyzeText(Book book)
        {
            ResetVariables();
            wordCount = book.Text.Split(' ').Count(word =>!String.IsNullOrEmpty(word));
            //Dictionary<string, int> entities = new Dictionary<string, int>();
            punctCount = book.Text.Count(c => Char.IsPunctuation(c));
            
            var pipeline = PipelineBuilder.GetPipeLine();

            // Annotation
            var annotation = new Annotation(book.Text);
            pipeline.annotate(annotation);

            // these are all the sentences in this document
            // a CoreMap is essentially a Map that uses class objects as keys and has values with custom types
            var sentences = annotation.get(new CoreAnnotations.SentencesAnnotation().getClass()) as ArrayList;

            if (sentences == null)
            {
                return;
            }

           
            foreach (CoreMap sentence in sentences)
            {
                var tokens = sentence.get(new CoreAnnotations.TokensAnnotation().getClass()) as ArrayList;
                foreach (CoreLabel token in tokens)
                {

                    var word = token.get(new CoreAnnotations.TextAnnotation().getClass()) as string;
                    var pos = token.get(new CoreAnnotations.PartOfSpeechAnnotation().getClass()) as string;
                    var ner = token.get(new  CoreAnnotations.NamedEntityTagAnnotation().getClass()) as string;
                    //if (entities.ContainsKey(ner))
                    //{
                    //    entities[ner]++;
                    //}
                    //else
                    //{
                    //    entities.Add(ner, 1);
                    //}
                    AnalyzePOSTag(pos);
                }
            }


            //foreach (var entity in entities)
            //{
            //    book.NamedEntities.Add(new NamedEntity() { BookID = book.BookID, NamedEntity1 = entity.Key, NumberOfOccurences = entity.Value });
            //}

            book.AdjectiveToWordRatio = adjCount / wordCount;
            book.AdverbToWordRatio = advCount / wordCount;
            book.NounToWordRatio = nounCount / wordCount;
            book.VerbToWordRatio = verbCount / wordCount;
            book.PunctoationToWordRatio = punctCount / wordCount;
            book.AverageSentenceWordCount = wordCount / sentences.size();

        }

        private static void AnalyzePOSTag(string pos)
        {
            switch(pos)
            {
                case "VB":
                case "VBD":
                case "VBG":
                case "VBN":
                case "VBP":
                case "VBZ":
                    verbCount++;
                    return;
                case "NN":
                case "NNS":
                case "NNP":
                case "NNPS":
                    nounCount++;
                    return;
                case "RB":
                case "RBR":
                case "RBS":
                    advCount++;
                    return;
                case "JJ":
                case "JJR":
                case "JJS":
                    adjCount++;
                    return;
                default: return;
            }
        }

        private static void ResetVariables()
        {
            wordCount =0;
            verbCount = 0;
            nounCount = 0;
            adjCount = 0;
            advCount = 0;
            punctCount = 0;

        }

        public static void AddNamedEntity(List<Book> books)
        {
            var pipeline = PipelineBuilder.GetPipeLineWithNamedEntities();
            int counter = 1;
            foreach (var book in books)
            {
                Dictionary<string, int> entities = new Dictionary<string, int>();
                var annotation = new Annotation(book.Text);
                pipeline.annotate(annotation);
                var sentences = annotation.get(new CoreAnnotations.SentencesAnnotation().getClass()) as ArrayList;
                foreach (CoreMap sentence in sentences)
                {
                    var tokens = sentence.get(new
                    CoreAnnotations.TokensAnnotation().getClass()) as ArrayList;
                    foreach (CoreLabel token in tokens)
                    {
                        
                        var ner = token.get(new
                        CoreAnnotations.NamedEntityTagAnnotation().getClass()) as string;
                        if(entities.ContainsKey(ner))
                        {
                            entities[ner]++;
                        }
                        else
                        {
                            entities.Add(ner, 1);
                        }
                    }
                }

                foreach(var entity in entities)
                {
                    book.NamedEntities.Add(new NamedEntity() { NamedEntityID = counter, BookID = book.BookID, NamedEntity1 = entity.Key, NumberOfOccurences = entity.Value });
                    counter++;
                }
            }
        }
    }
}

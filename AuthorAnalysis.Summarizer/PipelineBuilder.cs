using edu.stanford.nlp.pipeline;
using java.util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorAnalysis.Summarizer
{
    public static class PipelineBuilder
    {
         public static StanfordCoreNLP GetPipeLine()
        {
            var t = typeof(com.sun.codemodel.@internal.ClassType); // IKVM.OpenJDK.Tools
            t = typeof(com.sun.org.apache.xalan.@internal.xsltc.trax.TransformerFactoryImpl); // IKVM.OpenJDK.XML.Transform
            t = typeof(com.sun.org.glassfish.external.amx.AMX); // IKVM.OpenJDK.XML.WebServices

            var jarRoot = @"..\..\..\..\stanford-corenlp-3.7.0-models";
            Properties props = new Properties();
            props.setProperty("annotators", "tokenize, ssplit, pos");
            props.setProperty("sutime.binders", "0");
            var curDir = Environment.CurrentDirectory;
            Directory.SetCurrentDirectory(jarRoot);
            var pipeline = new StanfordCoreNLP(props);
            Directory.SetCurrentDirectory(curDir);
            return pipeline;
        }

        public static StanfordCoreNLP GetPipeLineWithNamedEntities()
        {
            var t = typeof(com.sun.codemodel.@internal.ClassType); // IKVM.OpenJDK.Tools
            t = typeof(com.sun.org.apache.xalan.@internal.xsltc.trax.TransformerFactoryImpl); // IKVM.OpenJDK.XML.Transform
            t = typeof(com.sun.org.glassfish.external.amx.AMX); // IKVM.OpenJDK.XML.WebServices

            var jarRoot = @"..\..\..\..\stanford-corenlp-3.7.0-models";
            Properties props = new Properties();
            props.setProperty("annotators", "tokenize, ssplit, pos, lemma, ner");
            props.setProperty("sutime.binders", "0");
            var curDir = Environment.CurrentDirectory;
            Directory.SetCurrentDirectory(jarRoot);
            var pipeline = new StanfordCoreNLP(props);
            Directory.SetCurrentDirectory(curDir);
            return pipeline;
        }
    }
}

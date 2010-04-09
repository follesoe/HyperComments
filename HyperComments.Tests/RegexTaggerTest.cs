using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HyperComments.Tests.Stubs;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Tagging;

using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HyperComments.Tests
{
    [TestClass]
    public class RegexTaggerTest : BDD<RegexTaggerTest>
    {
        [TestMethod]
        public void Creates_no_tags_if_no_spans_to_check()
        {
            When.we_get_the_tags();
            
            Assert.AreEqual(0, tags.Count(), "No tags should be created if empty document.");
        }

        [TestMethod]
        public void Creates_tag_if_matching_text_is_found()
        {
            Given.we_got_one_span_matching_search_expression();            
            When.we_get_the_tags();

            Assert.AreEqual(1, tags.Count(), "Expect one tag to be created.");
        }

        [TestInitialize]
        public void Setup()
        {
            spans = new NormalizedSnapshotSpanCollection();
            classificationSpans = new List<ClassificationSpan>();            
            
            classifier = new Mock<IClassifier>();
            classifier.Setup(c => c.GetClassificationSpans(It.IsAny<SnapshotSpan>())).Returns(classificationSpans);

            tagger = new TestTagger(classifier.Object, Regex);
        }

        private void we_got_one_span_matching_search_expression()
        {            
            var snapshot = new Mock<ITextSnapshot>();
            snapshot.Setup(s => s.Length).Returns(5);
            snapshot.Setup(s => s.LineCount).Returns(1);
            snapshot.Setup(s => s.GetText(It.IsAny<Span>())).Returns("this is a test");
            
            var snapshotSpan = new SnapshotSpan(snapshot.Object, 0, 5);
            spans = new NormalizedSnapshotSpanCollection(snapshotSpan);
            
            var classificationSpan = new ClassificationSpan(snapshotSpan, new Mock<IClassificationType>().Object);            
            classificationSpans.Add(classificationSpan);
        }

        private void we_get_the_tags()
        {
            tags = tagger.GetTags(spans);
        }

        private const string Regex = "test";
        private TestTagger tagger;
        private NormalizedSnapshotSpanCollection spans;
        private Mock<IClassifier> classifier;
        private IEnumerable<ITagSpan<TestTag>> tags;
        private IList<ClassificationSpan> classificationSpans;
    }
}

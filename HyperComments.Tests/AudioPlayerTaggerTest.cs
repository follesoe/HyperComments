using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HyperComments.Tests.Builders;
using HyperComments.Tests.Stubs;

using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Tagging;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace HyperComments.Tests
{
    [TestClass]
    public class AudioPlayerTaggerTest : BDD<AudioPlayerTaggerTest>
    {
        [TestMethod]
        public void Creates_tag_if_audio_file_comment_is_found()
        {
            Given.we_have_one_span_matching_audio_comment();
            When.we_get_the_tags();

            Assert.AreEqual(1, tags.Count());            
        }

        [TestMethod]
        public void Tag_should_contain_audio_filename()
        {
            Given.we_have_one_span_matching_audio_comment();
            When.we_get_the_tags();

            Assert.AreEqual(@"c:\comment.mp3", tags.First().Tag.Filename);
        }

        [TestInitialize]
        public void Setup()
        {
            spans = new NormalizedSnapshotSpanCollection();
            classificationSpans = new List<ClassificationSpan>();            

            classifier = new Mock<IClassifier>();
            classifier.Setup(c => c.GetClassificationSpans(It.IsAny<SnapshotSpan>())).Returns(classificationSpans);

            tagger = new AudioPlayerTagger(classifier.Object);
        }

        private void we_get_the_tags()
        {
            tags = tagger.GetTags(spans);
        }

        private void we_have_one_span_matching_audio_comment()
        {
            create_spans(@"// {audio: c:\comment.mp3}");
        }

        private void create_spans(params string[] lines)
        {
            classificationSpans.AddRange(ClassificationSpanBuilder.FromStrings(lines));
            spans = new NormalizedSnapshotSpanCollection(classificationSpans.Select(c => c.Span).First());
        }

        private AudioPlayerTagger tagger;
        private NormalizedSnapshotSpanCollection spans;
        private Mock<IClassifier> classifier;
        private IEnumerable<ITagSpan<AudioPlayerTag>> tags;
        private List<ClassificationSpan> classificationSpans;
    }
}

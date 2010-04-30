using System.Linq;
using System.Collections.Generic;

using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.Text.Classification;

using Moq;
using HyperComments.Tests.Builders;

namespace HyperComments.Tests
{
    public abstract class TaggerTest<T, TTag> : BDD<T> 
        where T : TaggerTest<T, TTag> 
        where TTag : ITag
    {
        protected void we_get_the_tags()
        {
            tags = tagger.GetTags(spans).ToList();
        }

        protected void create_spans(params string[] lines)
        {
            classificationSpans.AddRange(ClassificationSpanBuilder.FromStrings(lines));
            spans = new NormalizedSnapshotSpanCollection(classificationSpans.Select(c => c.Span).First());
        }

        protected TaggerTest()
        {
            spans = new NormalizedSnapshotSpanCollection();
            classificationSpans = new List<ClassificationSpan>();

            classifier = new Mock<IClassifier>();
            classifier.Setup(c => c.GetClassificationSpans(It.IsAny<SnapshotSpan>())).Returns(classificationSpans);
        }

        protected IEnumerable<ITagSpan<TTag>> tags;
        protected ITagger<TTag> tagger;
        protected NormalizedSnapshotSpanCollection spans;
        protected Mock<IClassifier> classifier;
        protected List<ClassificationSpan> classificationSpans;
    }
}

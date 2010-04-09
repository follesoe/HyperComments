using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using System.Text.RegularExpressions;


namespace HyperComments.Tests.Stubs
{
    public class TestTagger : RegexTagger<TestTag>
    {
        public TestTagger(IClassifier classifier, string regex) : base(classifier, regex)
        {
            
        }

        public override TestTag CreateTag(Match regexMatch, SnapshotSpan span)
        {
            return new TestTag(regexMatch, span);
        }
    }
}

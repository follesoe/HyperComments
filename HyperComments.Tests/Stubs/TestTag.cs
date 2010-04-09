using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Tagging;
using System.Text.RegularExpressions;

namespace HyperComments.Tests.Stubs
{
    public class TestTag : ITag
    {
        public Match Match;
        public SnapshotSpan Span;

        public TestTag(Match match, SnapshotSpan span)
        {
            Match = match;
            Span = span;
        }
    }
}

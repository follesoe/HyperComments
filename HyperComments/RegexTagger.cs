using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Tagging;

namespace HyperComments
{
    public abstract class RegexTagger<T> : ITagger<T> where T : ITag
    {
        public event EventHandler<SnapshotSpanEventArgs> TagsChanged;

        private readonly IClassifier _classifier;
        private readonly Regex _regex;

        protected RegexTagger(IClassifier classifier, string regex)
        {
            _classifier = classifier; 
            _regex = new Regex(regex, RegexOptions.IgnoreCase);
        }

        public abstract T CreateTag(Match regexMatch, SnapshotSpan span);

        public IEnumerable<ITagSpan<T>> GetTags(NormalizedSnapshotSpanCollection spans)
        {
            foreach(var span in spans)
            {
                foreach(var classification in _classifier.GetClassificationSpans(span))
                {
                    var match = _regex.Match(classification.Span.GetText());
                    if(!match.Success) continue;

                    var snapshotSpan = classification.Span;

                    var tag = new TagSpan<T>(snapshotSpan, CreateTag(match, snapshotSpan));
                    yield return tag;
                }
            }
        }        
    }
}

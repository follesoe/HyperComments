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

        private readonly Dictionary<SnapshotSpan, TagSpan<T>> _cache;
        private readonly IClassifier _classifier;
        private readonly Regex _regex;

        protected RegexTagger(IClassifier classifier, string regex)
        {
            _classifier = classifier; 
            _regex = new Regex(regex, RegexOptions.IgnoreCase);
            _cache = new Dictionary<SnapshotSpan, TagSpan<T>>();
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

                    if(_cache.ContainsKey(classification.Span))
                    {
                        yield return _cache[classification.Span];
                    }
                    else
                    {
                        int length = match.Value.Length;
                        int index = classification.Span.GetText().IndexOf(match.Value);
                        var snapshotSpan = new SnapshotSpan(classification.Span.Start + index, length);

                        var tag = new TagSpan<T>(snapshotSpan, CreateTag(match, snapshotSpan));
                        _cache.Add(classification.Span, tag);
                        yield return tag;   
                    }
                }
            }
        }        
    }
}

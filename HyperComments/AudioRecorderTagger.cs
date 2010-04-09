using System.Text.RegularExpressions;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;

namespace HyperComments
{
    public class AudioRecorderTagger : RegexTagger<AudioRecorderTag>
    {
        public AudioRecorderTagger(IClassifier classifier, string regex) : base(classifier, regex)
        {
        }

        public override AudioRecorderTag CreateTag(Match regexMatch, SnapshotSpan span)
        {
            return new AudioRecorderTag();            
        }
    }
}

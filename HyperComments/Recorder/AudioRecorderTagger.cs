using System.Text.RegularExpressions;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;

namespace HyperComments.Recorder
{
    public class AudioRecorderTagger : RegexTagger<AudioRecorderTag>
    {
        public AudioRecorderTagger(IClassifier classifier) : base(classifier, "// {recorder}")
        {
        }

        public override AudioRecorderTag CreateTag(Match regexMatch, SnapshotSpan span)
        {
            return new AudioRecorderTag();            
        }
    }
}

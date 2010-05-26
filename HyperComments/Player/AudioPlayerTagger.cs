using System.Text.RegularExpressions;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;

namespace HyperComments.Player
{
    public class AudioPlayerTaggerJonas : RegexTaggerJonas<AudioPlayerTag>
    {
        public AudioPlayerTaggerJonas(IClassifier classifier) : base(classifier, "// {audio: (.*)}")
        {
            
        }

        public override AudioPlayerTag CreateTag(Match regexMatch, SnapshotSpan span)
        {
            return new AudioPlayerTag(regexMatch.Groups[1].Value);
        }
    }
}

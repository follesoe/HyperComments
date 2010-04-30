using System.Text.RegularExpressions;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Shell;

namespace HyperComments.Recorder
{
    public class AudioRecorderTagger : RegexTagger<AudioRecorderTag>
    {
        private readonly ITextBuffer _buffer;
        private readonly SVsServiceProvider _serviceProvider;

        public AudioRecorderTagger(SVsServiceProvider serviceProvider, ITextBuffer buffer, IClassifier classifier) : base(classifier, "// {recorder}")
        {
            _buffer = buffer;
            _serviceProvider = serviceProvider;
        }

        public override AudioRecorderTag CreateTag(Match regexMatch, SnapshotSpan span)
        {
            string recordingDirectory = "";
            string activeDocument = "";
            return new AudioRecorderTag(_buffer, span, recordingDirectory, activeDocument);
        }
    }
}

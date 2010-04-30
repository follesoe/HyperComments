using System.IO;
using System.Text.RegularExpressions;

using EnvDTE;
using EnvDTE80;

using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Text.Classification;


namespace HyperComments.Recorder
{
    public class AudioRecorderTagger : RegexTagger<AudioRecorderTag>
    {
        private readonly ITextBuffer _buffer;
        private readonly SVsServiceProvider _serviceProvider;
        private readonly IAccessFiles _fileAccess;
        
        public AudioRecorderTagger(SVsServiceProvider serviceProvider, ITextBuffer buffer, IClassifier classifier) : 
            this(new FileSystemAdapter(), serviceProvider, buffer, classifier)
        {            
        }


        public AudioRecorderTagger(IAccessFiles fileAccess, SVsServiceProvider serviceProvider, ITextBuffer buffer, IClassifier classifier) : base(classifier, "// {recorder}")
        {
            _buffer = buffer;
            _serviceProvider = serviceProvider;
            _fileAccess = fileAccess;
        }

        public override AudioRecorderTag CreateTag(Match regexMatch, SnapshotSpan span)
        {
            return new AudioRecorderTag(_buffer, span, GetRecordingDirectory(), GetActiveDocument());
        }

        private string GetRecordingDirectory()
        {
            var dte2 = (DTE2)_serviceProvider.GetService(typeof(DTE));
            var solution = (Solution2)dte2.Solution;

            string recordingDirectory = Path.Combine(Path.GetDirectoryName(solution.FileName), "Audio Comments");

            if(!_fileAccess.DirectoryExists(recordingDirectory))
            {
                _fileAccess.CreateDirectory(recordingDirectory);
            }

            return recordingDirectory;
        }

        private string GetActiveDocument()
        {
            var dte2 = (DTE2) _serviceProvider.GetService(typeof (DTE));
            return dte2.ActiveDocument.Name;
        }
    }
}

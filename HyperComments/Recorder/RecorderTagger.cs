using System.IO;
using System.Text.RegularExpressions;

using EnvDTE;
using EnvDTE80;

using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Shell;

namespace HyperComments.Recorder
{
    public class RcorderTagger : RegexTagger<RecorderTag>
    {
        private readonly SVsServiceProvider _serviceProvider;
        private readonly IAccessFiles _fileAccess;
        
        public RcorderTagger(SVsServiceProvider serviceProvider, ITextBuffer buffer) : 
            this(new FileSystemAdapter(), serviceProvider, buffer)
        {            
        }


        public RcorderTagger(IAccessFiles fileAccess, SVsServiceProvider serviceProvider, ITextBuffer buffer) : 
            base(buffer, new[] { new Regex("// {recorder}", RegexOptions.Compiled |  RegexOptions.IgnoreCase) })
        {
            _serviceProvider = serviceProvider;
            _fileAccess = fileAccess;
        }

        protected override RecorderTag TryCreateTagForMatch(Match match)
        {
            return new RecorderTag(GetRecordingDirectory(), GetActiveDocument());            
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

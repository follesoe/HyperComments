using System.IO;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.Shell;

namespace HyperComments
{
    public class AudioDirectory
    {
        private readonly SVsServiceProvider _serviceProvider;

        public AudioDirectory(SVsServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public string GetRecordingDirectory()
        {
            var dte2 = (DTE2)_serviceProvider.GetService(typeof(DTE));
            var solution = (Solution2)dte2.Solution;

            string recordingDirectory = Path.Combine(Path.GetDirectoryName(solution.FileName), "Voice Comments");

            if (!Directory.Exists(recordingDirectory))
            {
                Directory.CreateDirectory(recordingDirectory);
            }

            return recordingDirectory;
        }
    }
}

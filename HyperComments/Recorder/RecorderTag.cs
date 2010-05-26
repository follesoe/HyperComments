using Microsoft.VisualStudio.Text.Tagging;

namespace HyperComments.Recorder
{
    public class RecorderTag : ITag
    {
        public AudioRecorder RecorderView
        {
            get { return null; }
        }

        public string RecordingDirectory { get; private set; }
        public string ActiveDocument { get; private set; }
        
        public RecorderTag(string recordingDirectory, string activeDoctument)
        {
            RecordingDirectory = recordingDirectory;
            ActiveDocument = activeDoctument;
        }
    }
}
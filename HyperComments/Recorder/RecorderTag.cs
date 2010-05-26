using System.Windows;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Tagging;

namespace HyperComments.Recorder
{
    public class RecorderTag : ITag
    {
        private readonly ITextBuffer _textBuffer;
        private readonly SnapshotSpan _span;

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

        public RecorderTag(ITextBuffer textBuffer, SnapshotSpan span, string recordingDirectory, string activeDoctument)
        {
            _span = span;
            _textBuffer = textBuffer;

            RecorderView.ViewModel.RecordingDirectory = recordingDirectory;
            RecorderView.ViewModel.ActiveDocument = activeDoctument;
            RecorderView.ViewModel.RecordingComplete += OnRecordingComplete;
        }

        private void OnRecordingComplete(object sender, RecordingCompleteEventArgs e)
        {
            _textBuffer.Replace(_span, "// {audio: " + e.Filename + "}");
        }
    }
}
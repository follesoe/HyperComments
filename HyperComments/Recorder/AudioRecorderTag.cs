using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;

namespace HyperComments.Recorder
{
    public class AudioRecorderTag : IntraTextAdornmentTag
    {
        private readonly ITextBuffer _textBuffer;
        private readonly SnapshotSpan _span;

        public AudioRecorder RecorderView
        {
            get { return (AudioRecorder) Adornment; }
        }

        public AudioRecorderTag(ITextBuffer textBuffer, SnapshotSpan span, string recordingDirectory, string activeDoctument) : base(new AudioRecorder(), null)
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
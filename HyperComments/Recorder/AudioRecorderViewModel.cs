using System;

namespace HyperComments.Recorder
{
    public class AudioRecorderViewModel : BaseViewModel
    {
        public event EventHandler<RecordingCompleteEventArgs> RecordingComplete;
        public RecordingCommand RecordingCommand { get; set; }

        private string _durationText;

        public string DurationText
        {
            get { return _durationText; }
            set
            {
                _durationText = value;
                OnPropertyChanged("DurationText");
            }
        }

        public AudioRecorderViewModel()
        {            
            RecordingCommand = new RecordingCommand(RecordingCompleteCallback);
            RecordingCommand.AudioRecorder = new Mp3AudioRecorder();
            DurationText = "00:00:00";
        }

        private void RecordingCompleteCallback(string filename)
        {
            if(RecordingComplete != null)
                RecordingComplete(this, new RecordingCompleteEventArgs(filename));
        }
    }
}
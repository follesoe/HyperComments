using System;

namespace HyperComments.Recorder
{
    public class AudioRecorderViewModel : BaseViewModel
    {
        public event EventHandler<RecordingCompleteEventArgs> RecordingComplete;
        public RecordingCommand RecordingCommand { get; set; }

        private string _durationText;

        public string RecordingDirectory
        {
            get { return RecordingCommand.RecordingDirectory; }
            set { RecordingCommand.RecordingDirectory = value; }
        }

        public string ActiveDocument
        {
            get { return RecordingCommand.ActiveDocument; }
            set { RecordingCommand.ActiveDocument = value; }
        }

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
            DurationText = "00:00:00";
        }

        private void RecordingCompleteCallback(string filename)
        {
            if(RecordingComplete != null)
                RecordingComplete(this, new RecordingCompleteEventArgs(filename));
        }
    }
}
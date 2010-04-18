namespace HyperComments.Recorder
{
    public class AudioRecorderViewModel : BaseViewModel
    {
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
            RecordingCommand = new RecordingCommand();
            RecordingCommand.AudioRecorder = new Mp3AudioRecorder();
            DurationText = "00:00:00";
        }
    }
}
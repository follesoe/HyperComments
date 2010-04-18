namespace HyperComments.Recorder
{
    public class AudioRecorderViewModel : BaseViewModel
    {
        public IAccessFiles FileAccess { get; set; }
        public IRecordAudio AudioRecorder { get; set; }

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
            FileAccess = new FileSystemAdapter();
            AudioRecorder = new Mp3AudioRecorder();
            DurationText = "00:00:00";
        }
    }
}

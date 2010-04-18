namespace HyperComments.Recorder
{
    public partial class AudioRecorder
    {
        public AudioRecorderViewModel ViewModel
        {
            get { return (AudioRecorderViewModel) DataContext; }
        }

        public AudioRecorder()
        {
            InitializeComponent();
        }
    }
}

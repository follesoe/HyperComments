using System.Windows;

namespace HyperComments.Recorder
{
    public partial class AudioRecorder
    {
        private const string CollapsedState = "Collapsed";
        private const string ExpandedState = "Expanded";
        private const string RecordState = "Record";
        private const string StopState = "Stop";

        public AudioRecorderViewModel ViewModel
        {
            get { return (AudioRecorderViewModel) DataContext; }
        }

        public AudioRecorder()
        {
            InitializeComponent();

            _record.Click += OnRecorderClick;

            VisualStateManager.GoToState(this, CollapsedState, false);
        }

        public void OnRecorderClick(object sender, RoutedEventArgs e)
        {
            if(VisualStateGroup.CurrentState.Name == CollapsedState)
            {
                VisualStateManager.GoToState(this, ExpandedState, true);
                VisualStateManager.GoToState(_record, StopState, true);
            }
            else
            {
                VisualStateManager.GoToState(this, CollapsedState, true);
                VisualStateManager.GoToState(_record, RecordState, true);
            }
        }
    }
}

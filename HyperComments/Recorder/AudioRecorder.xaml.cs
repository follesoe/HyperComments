using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Threading;

namespace HyperComments.Recorder
{
    public partial class AudioRecorder
    {
        private const string CollapsedState = "Collapsed";
        private const string ExpandedState = "Expanded";
        private const string RecordState = "Record";
        private const string StopState = "Stop";

        private readonly DispatcherTimer _timer;
        private readonly Stopwatch _stopwatch; 

        public AudioRecorderViewModel ViewModel
        {
            get { return (AudioRecorderViewModel) DataContext; }
        }

        public AudioRecorder()
        {
            InitializeComponent();

            _record.Click += OnRecorderClick;

            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 0, 1);
            _timer.Tick += OnUpdateRecordingTime;

            _stopwatch = new Stopwatch();

            VisualStateManager.GoToState(this, CollapsedState, false);
            VisualStateManager.GoToState(_record, RecordState, false);            
        }

        private void OnUpdateRecordingTime(object sender, EventArgs e)
        {
            ViewModel.DurationText = string.Format("{0:00}:{1:00}:{2:00}",
                                                   _stopwatch.Elapsed.Hours, _stopwatch.Elapsed.Minutes,
                                                   _stopwatch.Elapsed.Seconds);
        }

        public void OnRecorderClick(object sender, RoutedEventArgs e)
        {
            if(VisualStateGroup.CurrentState.Name == CollapsedState)
            {
                _stopwatch.Start();
                _timer.Start();                
                VisualStateManager.GoToState(this, ExpandedState, true);
                VisualStateManager.GoToState(_record, StopState, true);
            }
            else
            {                
                _timer.Stop();
                _stopwatch.Stop();   
                VisualStateManager.GoToState(this, CollapsedState, true);
                VisualStateManager.GoToState(_record, RecordState, true);
            }
        }
    }
}

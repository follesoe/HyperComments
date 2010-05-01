using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace HyperComments.Player
{
	public partial class AudioPlayer
	{
	    private const string HiddenState = "Hidden";
	    private const string VisibleState = "Visible";
	    private const string CollapsedState = "Collapsed";
	    private const string ExpandedState = "Expanded";
	    private const string PlayState = "Play";
	    private const string PauseState = "Pause";

        private readonly DispatcherTimer _timer;

	    public AudioPlayerViewModel ViewModel
	    {
	        get { return (AudioPlayerViewModel) DataContext; }
	    }
             
	    public AudioPlayer()
		{
			InitializeComponent();

            _playPause.Click += OnPlayPauseClick;
            _mediaElement.MediaOpened += OnMediaOpened;
            _positionSlider.ValueChanged += OnScrubberPositionChanged;

            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 0, 1);
            _timer.Tick += OnUpdatePosition;

            MouseEnter += OnMouseEnter;
            MouseLeave += OnMouseLeave;

		    VisualStateManager.GoToState(this, HiddenState, false);
		    VisualStateManager.GoToState(this, CollapsedState, false);
		}

        private void OnUpdatePosition(object sender, EventArgs e)
        {
            ViewModel.CurrentPositionText = string.Format("{0:00}:{1:00}",
                    _mediaElement.Position.Minutes,
                    _mediaElement.Position.Seconds);

            _positionSlider.Value = _mediaElement.Position.TotalMilliseconds;
        }

        private void OnScrubberPositionChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if(Math.Abs(e.NewValue - e.OldValue) > 1000)
            {
                _mediaElement.Position = TimeSpan.FromMilliseconds(e.NewValue);
            }
        }

        private void OnMediaOpened(object sender, RoutedEventArgs e)
        {
            ViewModel.Duration = _mediaElement.NaturalDuration;
        }

        private void OnPlayPauseClick(object sender, RoutedEventArgs e)
        {
            if(VisualStateGroup.CurrentState.Name == CollapsedState)
            {
                _timer.Start();
                _mediaElement.Play();
                VisualStateManager.GoToState(this, ExpandedState, true);
                VisualStateManager.GoToState(_playPause, PauseState, true);
            }
            else
            {
                _timer.Stop();
                _mediaElement.Pause();
                VisualStateManager.GoToState(this, HiddenState, false);
                VisualStateManager.GoToState(this, CollapsedState, true);                
                VisualStateManager.GoToState(_playPause, PlayState, true);
            }
        }

        private void OnMouseEnter(object sender, MouseEventArgs e)
        {
            if (VisualStateGroup.CurrentState.Name == ExpandedState)
            {
                VisualStateManager.GoToState(this, VisibleState, true);
            }
        }

        private void OnMouseLeave(object sender, MouseEventArgs e)
        {
            if (VisualStateGroup.CurrentState.Name == ExpandedState)
            {
                VisualStateManager.GoToState(this, HiddenState, true);
            }
        }
	}
}
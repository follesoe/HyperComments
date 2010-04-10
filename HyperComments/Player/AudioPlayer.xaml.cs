using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HyperComments.Player
{
	public partial class AudioPlayer : UserControl
	{
	    private const string HiddenState = "Hidden";
	    private const string VisibleState = "Visible";
	    private const string CollapsedState = "Collapsed";
	    private const string ExpandedState = "Expanded";
	    private const string PlayState = "Play";
	    private const string PauseState = "Pause";

		public AudioPlayer()
		{
			InitializeComponent();

            _playPause.Click += OnPlayPauseClick;

            MouseEnter += OnMouseEnter;
            MouseLeave += OnMouseLeave;

		    VisualStateManager.GoToState(this, HiddenState, false);
		    VisualStateManager.GoToState(this, CollapsedState, false);
		}

        private void OnPlayPauseClick(object sender, RoutedEventArgs e)
        {
            if(VisualStateGroup.CurrentState.Name == CollapsedState)
            {
                VisualStateManager.GoToState(this, ExpandedState, true);
                VisualStateManager.GoToState(_playPause, PauseState, true);
            }
            else
            {
                VisualStateManager.GoToState(this, CollapsedState, true);
                VisualStateManager.GoToState(this, HiddenState, true);
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
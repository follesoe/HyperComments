using System.Windows;
using System.Windows.Controls;

namespace HyperComments.Player
{
	public partial class AudioPlayer : UserControl
	{
	    private const string CollapsedState = "Collapsed";
	    private const string ExpandedState = "Expanded";
	    private const string PlayState = "Play";
	    private const string PauseState = "Pause";

		public AudioPlayer()
		{
			InitializeComponent();

            _playPause.Click += OnPlayPauseClick;            

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
                VisualStateManager.GoToState(_playPause, PlayState, true);
            }
        }
	}
}
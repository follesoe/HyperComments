using Microsoft.VisualStudio.Text.Editor;

namespace HyperComments.Player
{
    public class AudioPlayerTag : IntraTextAdornmentTag
    {
        public string Filename { get { return PlayerView.ViewModel.Filename; } }

        public AudioPlayer PlayerView
        {
            get { return (AudioPlayer) Adornment; }
        }

        public AudioPlayerTag(string filename) : base(new AudioPlayer(), null)
        {
            PlayerView.ViewModel.Filename = filename;
        }
    }
}

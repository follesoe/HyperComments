using System.Windows;
using Microsoft.VisualStudio.Text.Editor;

namespace HyperComments.Player
{
    public class AudioPlayerTag : IntraTextAdornmentTag
    {
        public string Filename { get { return Player.Filename; } }

        public AudioPlayer Player
        {
            get { return (AudioPlayer) Adornment; }
        }

        public AudioPlayerTag(string filename) : base(new AudioPlayer(), null)
        {
            Player.Filename = filename;
            Player.RenderSize = new Size(350, 18);
        }
    }
}

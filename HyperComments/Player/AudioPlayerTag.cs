using Microsoft.VisualStudio.Text.Editor;

namespace HyperComments.Player
{
    public class AudioPlayerTag : IntraTextAdornmentTag
    {
        public string Filename { get; set; }

        public AudioPlayerTag(string filename) : base(new AudioPlayer(), null)
        {
            Filename = filename;
        }
    }
}

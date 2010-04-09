using System.Windows;
using Microsoft.VisualStudio.Text.Editor;

namespace HyperComments.Player
{
    public class AudioPlayerTag : IntraTextAdornmentTag
    {
        public string Filename { get; set; }

        public AudioPlayerTag(string filename) : base(new UIElement(), null)
        {
            Filename = filename;
        }
    }
}

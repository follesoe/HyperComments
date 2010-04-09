using System.Windows;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Tagging;

namespace HyperComments
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

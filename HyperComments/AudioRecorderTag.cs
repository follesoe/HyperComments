using System.Windows;
using Microsoft.VisualStudio.Text.Editor;

namespace HyperComments
{
    public class AudioRecorderTag : IntraTextAdornmentTag
    {
        public AudioRecorderTag() : base(new UIElement(), null)
        {
            
        }
    }
}

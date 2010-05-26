using Microsoft.VisualStudio.Text.Tagging;

namespace HyperComments.Player
{
    public class PlayerTag : ITag
    {
        public string Filename { get; private set; }
        
        public PlayerTag(string filename)
        {
            Filename = filename;
        }
    }
}

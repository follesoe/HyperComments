using System.Text.RegularExpressions;
using Microsoft.VisualStudio.Text;

namespace HyperComments.Player
{
    public class PlayerTagger : RegexTagger<PlayerTag>
    {
        public PlayerTagger(ITextBuffer buffer)
            : base(buffer, new[] { new Regex("// {audio: (.*)}", RegexOptions.Compiled | RegexOptions.IgnoreCase) })
        {
            
        }

        protected override PlayerTag TryCreateTagForMatch(Match match)
        {
            return new PlayerTag(match.Groups[1].Value);
        }
    }
}

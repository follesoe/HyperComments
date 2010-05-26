using System;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Tagging;

namespace HyperComments.Player
{
    public class PlayerAdornmentTagger : IntraTextAdornmentTagTransformer<PlayerTag, AudioPlayer>
    {
        public PlayerAdornmentTagger(IWpfTextView view, ITagAggregator<PlayerTag> dataTagger) : base(view, dataTagger)
        {
        }

        public static ITagger<IntraTextAdornmentTag> GetTagger(IWpfTextView view, Lazy<ITagAggregator<PlayerTag>> playerTagger)
        {
            return view.Properties.GetOrCreateSingletonProperty(
                () => new PlayerAdornmentTagger(view, playerTagger.Value));
        }

        protected override AudioPlayer CreateAdornment(PlayerTag data, SnapshotSpan span)
        {
            var player = new AudioPlayer();
            player.ViewModel.Filename = data.Filename;
            return player;            
        }

        protected override bool UpdateAdornment(AudioPlayer adornment, PlayerTag data)
        {
            adornment.ViewModel.Filename = data.Filename;
            return true;
        }

        public override void Dispose()
        {
            view.Properties.RemoveProperty(typeof(PlayerAdornmentTagger));
        }
    }
}

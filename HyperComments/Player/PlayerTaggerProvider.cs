using System;
using System.ComponentModel.Composition;

using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.Text.Classification;

using Microsoft.VisualStudio.Utilities;

namespace HyperComments.Player
{
    [Export(typeof(ITaggerProvider))]
    [ContentType("code")]
    [TagType(typeof(PlayerTag))]
    public class PlayerTaggerProvider : ITaggerProvider
    {
        [Import]
        internal IClassifierAggregatorService AggregatorService;

        public ITagger<T> CreateTagger<T>(ITextBuffer buffer) where T : ITag
        {
            if(buffer == null) throw new ArgumentException("buffer");

            return buffer.Properties.GetOrCreateSingletonProperty(() => new PlayerTagger(buffer)) as ITagger<T>;
        }
    }
}

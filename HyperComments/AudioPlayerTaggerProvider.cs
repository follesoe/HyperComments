using System;
using System.ComponentModel.Composition;

using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.Text.Classification;

using Microsoft.VisualStudio.Utilities;

namespace HyperComments
{
    [Export(typeof(ITaggerProvider))]
    [ContentType("code")]
    [TagType(typeof(AudioPlayerTag))]
    public class AudioPlayerTaggerProvider : ITaggerProvider
    {
        [Import]
        internal IClassifierAggregatorService AggregatorService;

        public ITagger<T> CreateTagger<T>(ITextBuffer buffer) where T : ITag
        {
            if(buffer == null) throw new ArgumentException("buffer");

            return new AudioPlayerTagger(AggregatorService.GetClassifier(buffer)) as ITagger<T>;
        }
    }
}

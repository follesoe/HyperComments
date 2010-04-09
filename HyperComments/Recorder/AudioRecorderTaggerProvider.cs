using System;
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.Utilities;

namespace HyperComments.Recorder
{
    [Export(typeof(ITaggerProvider))]
    [ContentType("code")]
    [TagType(typeof(AudioRecorderTag))]
    public class AudioRecorderTaggerProvider : ITaggerProvider
    {
        [Import]
        internal IClassifierAggregatorService AggregatorService;

        public ITagger<T> CreateTagger<T>(ITextBuffer buffer) where T : ITag
        {
            if (buffer == null) throw new ArgumentException("buffer");

            return new AudioRecorderTagger(AggregatorService.GetClassifier(buffer)) as ITagger<T>;
        }
    }
}

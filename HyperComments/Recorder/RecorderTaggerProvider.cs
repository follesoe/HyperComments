using System;
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.Utilities;

namespace HyperComments.Recorder
{
    [Export(typeof(ITaggerProvider))]
    [ContentType("code")]
    [TagType(typeof(RecorderTag))]
    public class RecorderTaggerProvider : ITaggerProvider
    {
        [Import]
        internal IClassifierAggregatorService AggregatorService;

        [Import]
        internal SVsServiceProvider ServiceProvider;

        public ITagger<T> CreateTagger<T>(ITextBuffer buffer) where T : ITag
        {
            if (buffer == null) throw new ArgumentException("buffer");


            return buffer.Properties.GetOrCreateSingletonProperty(
                () => new RcorderTagger(ServiceProvider, buffer)) as ITagger<T>;
        }
    }
}

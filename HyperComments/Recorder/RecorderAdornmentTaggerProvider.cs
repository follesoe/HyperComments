using System;
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.Utilities;

namespace HyperComments.Recorder
{
    [Export(typeof(IViewTaggerProvider))]
    [ContentType("code")]
    [TagType(typeof(IntraTextAdornmentTag))]
    public class RecorderAdornmentTaggerProvider : IViewTaggerProvider
    {
        [Import]
        internal IBufferTagAggregatorFactoryService BufferTagAggregatorFactoryService;

        public ITagger<T> CreateTagger<T>(ITextView textView, ITextBuffer buffer) where T : ITag
        {
            return RecorderAdornmentTagger.GetTagger(
                (IWpfTextView)textView,
                new Lazy<ITagAggregator<RecorderTag>>(
                    () => BufferTagAggregatorFactoryService.CreateTagAggregator<RecorderTag>(textView.TextBuffer))) as ITagger<T>;
            
        }
    }
}

using System;
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.Utilities;

namespace HyperComments.Player
{
    [Export(typeof(IViewTaggerProvider))]
    [ContentType("code")]
    [TagType(typeof(IntraTextAdornmentTag))]
    public class PlayerAdornmentTaggerProvider : IViewTaggerProvider
    {
        [Import]
        internal IBufferTagAggregatorFactoryService BufferTagAggregatorFactoryService;

        public ITagger<T> CreateTagger<T>(ITextView textView, ITextBuffer buffer) where T : ITag
        {
            return PlayerAdornmentTagger.GetTagger(
                (IWpfTextView)textView,
                new Lazy<ITagAggregator<PlayerTag>>(
                        () => BufferTagAggregatorFactoryService.CreateTagAggregator<PlayerTag>(textView.TextBuffer))) as ITagger<T>;
        }
    }
}

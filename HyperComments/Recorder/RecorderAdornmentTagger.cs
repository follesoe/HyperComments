using System;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Tagging;

namespace HyperComments.Recorder
{
    public class RecorderAdornmentTagger : IntraTextAdornmentTagTransformer<RecorderTag, AudioRecorder>
    {
        public RecorderAdornmentTagger(IWpfTextView view, ITagAggregator<RecorderTag> dataTagger) : base(view, dataTagger)
        {
        }

        public static ITagger<IntraTextAdornmentTag> GetTagger(IWpfTextView view, Lazy<ITagAggregator<RecorderTag>> recorderTagger)
        {
            return view.Properties.GetOrCreateSingletonProperty(
                () => new RecorderAdornmentTagger(view, recorderTagger.Value));
        }

        protected override AudioRecorder CreateAdornment(RecorderTag data, SnapshotSpan span)
        {
            return new AudioRecorder();
        }

        protected override bool UpdateAdornment(AudioRecorder adornment, RecorderTag data)
        {
            return true;
        }

        public override void Dispose()
        {
            view.Properties.RemoveProperty(typeof (RecorderAdornmentTagger));
        }
    }
}

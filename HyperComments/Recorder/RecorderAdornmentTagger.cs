﻿using System;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Tagging;

namespace HyperComments.Recorder
{
    public class RecorderAdornmentTagger : IntraTextAdornmentTagTransformer<RecorderTag, AudioRecorder>
    {
        private readonly IWpfTextView _view;

        public RecorderAdornmentTagger(IWpfTextView view, ITagAggregator<RecorderTag> dataTagger) : base(view, dataTagger)
        {
            _view = view;
        }

        public static ITagger<IntraTextAdornmentTag> GetTagger(IWpfTextView view, Lazy<ITagAggregator<RecorderTag>> recorderTagger)
        {
            return view.Properties.GetOrCreateSingletonProperty(
                () => new RecorderAdornmentTagger(view, recorderTagger.Value));
        }

        protected override AudioRecorder CreateAdornment(RecorderTag data, SnapshotSpan span)
        {
            var recorder = new AudioRecorder();
            recorder.ViewModel.RecordingComplete += (o, e) => _view.TextBuffer.Replace(span, "// {audio: " + e.Filename + "}");
            recorder.ViewModel.ActiveDocument = data.ActiveDocument;
            recorder.ViewModel.RecordingDirectory = data.RecordingDirectory;
            return recorder;
        }        

        protected override bool UpdateAdornment(AudioRecorder adornment, RecorderTag data)
        {
            adornment.ViewModel.ActiveDocument = data.ActiveDocument;
            adornment.ViewModel.RecordingDirectory = data.RecordingDirectory;
            return true;
        }

        public override void Dispose()
        {
            view.Properties.RemoveProperty(typeof (RecorderAdornmentTagger));
        }
    }
}

using System;

namespace HyperComments.Recorder
{
    public class RecordingCompleteEventArgs : EventArgs
    {
        public string Filename { get; private set; }

        public RecordingCompleteEventArgs(string filename)
        {
            Filename = filename;
        }
    }
}

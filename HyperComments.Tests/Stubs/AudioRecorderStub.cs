using System;
using HyperComments.Recorder;

namespace HyperComments.Tests.Stubs
{
    public class AudioRecorderStub : IRecordAudio
    {
        private string _filename; 

        public void Start(string filename)
        {
            _filename = filename;    
        }

        public void Stop(Action<string> saveCallback)
        {
            saveCallback(_filename);
        }
    }
}

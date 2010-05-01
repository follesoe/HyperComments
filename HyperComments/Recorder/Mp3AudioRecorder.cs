using System;
using Istrib.Sound;
using Istrib.Sound.Formats;

namespace HyperComments.Recorder
{
    public class Mp3AudioRecorder : IRecordAudio     
    {
        private readonly Mp3SoundCapture _soundCapture;
        private Action<string> _saveCallback;

        public Mp3AudioRecorder()
        {
            _soundCapture = new Mp3SoundCapture();
            _soundCapture.NormalizeVolume = true;
            _soundCapture.CaptureDevice = SoundCaptureDevice.Default;
            _soundCapture.OutputType = Mp3SoundCapture.Outputs.Mp3;
            _soundCapture.WaveFormat = PcmSoundFormat.Pcm48kHz16bitStereo;
            _soundCapture.Mp3BitRate = Mp3BitRate.BitRate128;
            _soundCapture.Stopped += OnRecordingStopped;
            _soundCapture.WaitOnStop = true;
        }

        public void Start(string filename)
        {
            _soundCapture.Start(filename);            
        }

        public void Stop(Action<string> saveCallback)
        {
            _saveCallback = saveCallback;
            _soundCapture.Stop();   
        }

        private void OnRecordingStopped(object sender, Mp3SoundCapture.StoppedEventArgs e)
        {
            if (e.Exception == null && _saveCallback != null)
            {
                _saveCallback(e.OutputFileName);
            }
        }
    }
}

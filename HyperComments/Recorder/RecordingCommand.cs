using System;
using System.IO;
using System.Threading;
using System.Windows.Input;

namespace HyperComments.Recorder
{
    public class RecordingCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly Action<string> _recordingCompletedCallback;

        public IRecordAudio AudioRecorder { get; set; }
        public string RecordingDirectory { get; set; }
        public string ActiveDocument { get; set; }        

        private bool _isRecording;
        private string _filename;

        public RecordingCommand(Action<string> recordingCompletedCallback)
        {
            _isRecording = false;
            _recordingCompletedCallback = recordingCompletedCallback;

            AudioRecorder = new Mp3AudioRecorder();
        }

        public void Execute(object parameter)
        {
            if(_isRecording)
            {
                _isRecording = false;
                AudioRecorder.Stop();
                _recordingCompletedCallback(_filename);
            }
            else
            {
                _isRecording = true;
                _filename = GetRecordingFilename();
                AudioRecorder.Start(_filename);    
            }            
        }

        private string GetRecordingFilename()
        {
            string user = GetCurrentUser();
            string document = Path.GetFileNameWithoutExtension(ActiveDocument);
            string filename = string.Format("{0}-{1}-{2}.mp3",  SystemTime.Now().ToString("ddMMyy-hhmmss"), document, user);
            return Path.Combine(RecordingDirectory, filename);
        }

        public string GetCurrentUser()
        {
            string user = Thread.CurrentPrincipal.Identity.Name;

            if (user.Contains("\\"))
            {
                user = user.Substring(user.LastIndexOf("\\") + 1);
            }

            return user;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
using System;
using System.IO;
using System.Windows;

namespace HyperComments.Player
{
    public class AudioPlayerViewModel : BaseViewModel
    {
        public IAccessFiles FileAccess { get; set; }

        private string _filename;     
   
        public string Filename
        {
            get { return _filename;}
            set
            {
                _filename = value;
                OnPropertyChanged("Filename");
                OnPropertyChanged("Message");
            }
        }

        public string Message
        {
            get
            {
                if(string.IsNullOrEmpty(_filename))
                {
                    return "Filename not set...";
                }

                if(FileAccess.Exists(_filename))
                {
                    return Path.GetFileName(_filename);
                }

                return string.Format("File {0} does not exist...", _filename);
            }
        }

        private string _currentPositionText;

        public string CurrentPositionText
        {
            get { return _currentPositionText; }
            set
            {
                _currentPositionText = value;
                OnPropertyChanged("CurrentPositionText");
            }
        }

        private Duration _duration;
        
        public Duration Duration
        {
            get { return _duration; }
            set
            {
                _duration = value;
                OnPropertyChanged("Duration");
                OnPropertyChanged("ScrubberMaxValue");
            }
        }

        public double ScrubberMaxValue
        {
            get 
            {
                return Duration.HasTimeSpan ? Duration.TimeSpan.TotalMilliseconds : 0;
            }
        }
        
        public AudioPlayerViewModel()
        {
            FileAccess = new FileSystemAdapter();
            _currentPositionText = "00:00";
        }
    }
}

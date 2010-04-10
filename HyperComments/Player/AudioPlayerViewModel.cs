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

        public string CurrentPosition
        {
            get { return "00:00:00"; }
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
            get { return Duration.TimeSpan.TotalMilliseconds; }
        }
        
        public AudioPlayerViewModel()
        {
            FileAccess = new FileSystemAdapter();    
        }
    }
}

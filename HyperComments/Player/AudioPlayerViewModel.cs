using System.IO;

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
        
        public AudioPlayerViewModel()
        {
            FileAccess = new FileSystemAdapter();    
        }
    }
}

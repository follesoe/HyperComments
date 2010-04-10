using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HyperComments.Player
{
    public class AudioPlayerViewModel : BaseViewModel
    {
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
                return Path.GetFileName(_filename);
            }
        }
        
        public AudioPlayerViewModel()
        {
            
        }
    }
}

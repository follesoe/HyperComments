using System.Windows;
using System.Windows.Forms;
using HyperComments.Recorder;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;

namespace HyperComments.UITestSurface
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            _pickButton.Click += OnPickClick;
            _pickDirectoryButton.Click += OnPickDirectoryClick;

            _recorder.ViewModel.ActiveDocument = "TestDocument";
            _recorder.ViewModel.RecordingComplete += OnRecordingCompleted;
        }

        private void OnPickClick(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();            
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "MP3 files (*.mp3)|*.mp3";
            
            if(openFileDialog.ShowDialog(this).Value)
            {
                _player.ViewModel.Filename = openFileDialog.FileName;
            }
        }

        private void OnPickDirectoryClick(object sender, RoutedEventArgs e)
        {
            var openDirectoryDialog = new FolderBrowserDialog ();
            if(openDirectoryDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _recorder.ViewModel.RecordingDirectory = openDirectoryDialog.SelectedPath;
            }
        }

        private void OnRecordingCompleted(object sender, RecordingCompleteEventArgs e)
        {
            _player.ViewModel.Filename = e.Filename;
        }
    }
}

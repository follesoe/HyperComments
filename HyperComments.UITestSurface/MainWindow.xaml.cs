using System.Windows;
using Microsoft.Win32;

namespace HyperComments.UITestSurface
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            _pickButton.Click += OnPickClick;
        }

        private void OnPickClick(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();            
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "MP3 files (*.mp3)|*.mp3";
            
            if(openFileDialog.ShowDialog(this).Value)
            {
                _player.Filename = openFileDialog.FileName;
            }
        }
    }
}

using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.Win32;
using System.ComponentModel;
using Parakeet.Services;

namespace Parakeet.Ui.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        internal static readonly Uri Uri = new Uri(@"..\Views\Home.xaml", UriKind.RelativeOrAbsolute);

        private IConfigurationService _configurationService;

        public RelayCommand CreateNewFileCommand { get; private set; }
        public RelayCommand OpenExistingFileCommand { get; private set; }

        private string selectedFile;
        public string SelectedFile {
            get { return selectedFile; }
            private set {
                Set(nameof(SelectedFile), ref selectedFile, value);
                OpenExistingFileCommand.RaiseCanExecuteChanged();
                CreateNewFileCommand.RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// Initializes a new instance of the IntroductionViewModel class.
        /// </summary>
        public HomeViewModel(IConfigurationService configurationService)
        {
            _configurationService = configurationService;

            selectedFile = _configurationService.IsFileLoaded() ? "hi" : "";

            CreateNewFileCommand = new RelayCommand(() => {
                var saveFileDialog = new SaveFileDialog();
                saveFileDialog.AddExtension = true;
                saveFileDialog.DefaultExt = "pktd";
                saveFileDialog.Filter = "Parakeet File|*.pktd;*.pkd";
                saveFileDialog.FileOk += SaveFileDialog_FileOk;
                saveFileDialog.ShowDialog();
            }, () => string.IsNullOrEmpty(SelectedFile));

            OpenExistingFileCommand = new RelayCommand(() => {
                var openFileDialog = new OpenFileDialog();
                openFileDialog.AddExtension = true;
                openFileDialog.DefaultExt = "pktd";
                openFileDialog.Filter = "Parakeet File|*.pktd;*.pkd";
                openFileDialog.Multiselect = false;
                openFileDialog.FileOk += OpenFileDialog_FileOk;
                openFileDialog.ShowDialog();
            }, () => string.IsNullOrEmpty(SelectedFile));
        }

        private void OpenFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            var openFileDialog = sender as OpenFileDialog;

            SelectedFile = openFileDialog.SafeFileName;

            var success = _configurationService.SetSavefilePath(openFileDialog.FileName, createIfFileDne: false);

            if (success)
                MessengerInstance.Send(new Messages.FileOpenedEventMessage());
        }

        private void SaveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            var saveFileDialog = sender as SaveFileDialog;

            SelectedFile = saveFileDialog.SafeFileName;

            var success = _configurationService.SetSavefilePath(saveFileDialog.FileName, createIfFileDne: true);

            if (success)
                MessengerInstance.Send(new Messages.FileOpenedEventMessage());
        }
    }
}
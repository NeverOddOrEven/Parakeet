using Parakeet.Ui.ViewModel;
using System.Windows;

namespace Parakeet.Ui.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool IsNavigationEnabled = false;
        public string wtf = "wtf";
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            this.MainFrame.Navigate(HomeViewModel.Uri);

            Closing += (s, e) => ViewModelLocator.Cleanup();
        }
    }
}
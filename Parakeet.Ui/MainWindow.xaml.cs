using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Parakeet.Ui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnOpenDatabaseFile(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnOpenDatabaseFile(object sender, TouchEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnCreateDatabaseFile(object sender, RoutedEventArgs e)
        {
            WelcomeCanvas.Visibility = System.Windows.Visibility.Hidden;
        }

        private void OnCreateDatabaseFile(object sender, TouchEventArgs e)
        {
            WelcomeCanvas.Visibility = System.Windows.Visibility.Hidden;
        }
    }
}

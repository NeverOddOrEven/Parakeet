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
    /// Interaction logic for NavigationBar.xaml
    /// </summary>
    public partial class NavigationBar : UserControl
    {
        public NavigationBar()
        {
            this.Loaded += OnLoaded;
            InitializeComponent();
        }

        public void OnLoaded(object sender, RoutedEventArgs args)
        {
            var allPages = this.GetType().Assembly.GetTypes().ToList();
            allPages = allPages.Where(x => typeof(IApplicationPage).IsAssignableFrom(x) && x != typeof(IApplicationPage)).ToList();
            
            var buttonsToAllPages = allPages.Select(x =>
            {
                var button = new Button();
                button.Content = x.Name;
                return button;
            });
            
            foreach(var btn in buttonsToAllPages.AsParallel()) {
                this.NavigationBarPanel.Children.Add(btn);
            }
            
        }
    }
}

using System;
using GalaSoft.MvvmLight;

namespace Parakeet.Ui.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        internal static readonly Uri Uri = new Uri(@"..\Views\Home.xaml", UriKind.RelativeOrAbsolute);

        /// <summary>
        /// Initializes a new instance of the IntroductionViewModel class.
        /// </summary>
        public HomeViewModel()
        {
        }
    }
}
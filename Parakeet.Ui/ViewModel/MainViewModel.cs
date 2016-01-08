using GalaSoft.MvvmLight;
using Parakeet.Ui.Messages;
using System;

namespace Parakeet.Ui.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        //private readonly IDataService _dataService;
        
        public const string WelcomeTitlePropertyName = "WelcomeTitle";
        public const string NavigationEnabledPropertyName = "NavigationEnabled";

        private bool _navigationEnabled = false;
        private string _welcomeTitle = string.Empty;
        
        public bool NavigationEnabled
        {
            get { return _navigationEnabled; }
            set
            {
                if (_navigationEnabled == value)
                    return;
                Set(NavigationEnabledPropertyName, ref _navigationEnabled, value);
            }
        }


        public string WelcomeTitle
        {
            get
            {
                return _welcomeTitle;
            }
            set
            {
                Set(ref _welcomeTitle, value);
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(/*IDataService dataService*/)
        {
            MessengerInstance.Register(this, new Action<FileOpenedEventMessage>(x => {
                NavigationEnabled = true;
            }));

            //_dataService = dataService;
            //_dataService.GetData(
            //    (item, error) =>
            //    {
            //        if (error != null)
            //        {
            //            // Report error here
            //            return;
            //        }
            //
            //        WelcomeTitle = item.Title;
            //    });
        }
    }
}
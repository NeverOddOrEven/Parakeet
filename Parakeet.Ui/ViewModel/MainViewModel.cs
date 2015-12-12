using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HelloWorld.Model;

namespace HelloWorld.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;

        /// <summary>
        /// The <see cref="WelcomeTitle" /> property's name.
        /// </summary>
        public const string WelcomeTitlePropertyName = "WelcomeTitle";
        public const string CounterPropertyName = "Counter";

        private string _welcomeTitle = string.Empty;
        private uint _counter = 0;
        public uint Counter
        {
            get
            {
                return _counter;
            }
            set
            {
                if (_counter == value)
                {
                    return;
                }

                _counter = value;
                RaisePropertyChanged(CounterPropertyName);
                IncrementByOneCmd.RaiseCanExecuteChanged();
            }
        }
        public RelayCommand IncrementByOneCmd { get; private set; }

        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
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
        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;
            _dataService.GetData(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    WelcomeTitle = item.Title;
                });

            IncrementByOneCmd = new RelayCommand(() => Counter++, () => Counter % 2 == 0);
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}
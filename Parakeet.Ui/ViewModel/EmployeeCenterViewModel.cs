using GalaSoft.MvvmLight;
using HelloWorld.Model;

namespace HelloWorld.ViewModel
{
    public class EmployeeCenterViewModel : ViewModelBase
    {
        private IDataService _dataService;

        private string _searchField;
        public string SearchField
        {
            get
            {
                return _searchField;
            }
            set
            {
                Set(ref _searchField, value);
            }
        }

        private Employee _employee;
        public Employee Employee
        {
            get
            {
                return _employee;
            }
            set
            {
                Set(ref _employee, value);
            }
        }

        /// <summary>
        /// Initializes a new instance of the EmployeeCenterViewModel class.
        /// </summary>
        public EmployeeCenterViewModel(IDataService dataService)
        {
            _dataService = dataService;
            Employee = new Employee { FirstName = "Jeeb" };
        }
    }
}
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Parakeet.Services;
using Parakeet.Services.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Parakeet.Ui.ViewModel
{
    public class EmployeeCenterViewModel : ViewModelBase
    {
        private IEmployeeService _employeeService;

        public RelayCommand SearchForEmployeeCommand { get; set; }
        public RelayCommand SaveEmployeeCommand { get; set; }

        private bool _showMatchingEmployees;
        public bool ShowMatchingEmployees
        {
            get
            {
                return _showMatchingEmployees;
            }
            set
            {
                Set(ref _showMatchingEmployees, value);
            }
        }

        private string _selectedEmployee;
        public string SelectedEmployee
        {
            get
            {
                return _selectedEmployee;
            }
            set
            {
                Set(ref _selectedEmployee, value);
            }
        }

        private ObservableCollection<string> _employeesFound;
        public ObservableCollection<string> EmployeesFound
        {
            get
            {
                return _employeesFound;
            }
            set
            {
                Set(ref _employeesFound, value);
                ShowMatchingEmployees = true;
            }
        }

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
        public EmployeeCenterViewModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;

            InitializeView();
        }

        private void InitializeView()
        {
            Employee = new Employee
            {
                HireDate = DateTime.Now,
                SeparationDate = null,

            };
            SearchField = string.Empty;

            SearchForEmployeeCommand = new RelayCommand(
                () => {
                    var found = _employeeService.Find(SearchField);
                    EmployeesFound = new ObservableCollection<string>(found.Select(x => x.FirstName));
                }, 
                () => {
                    return SearchField.Length > 1;
                }    
            );

            SaveEmployeeCommand = new RelayCommand(
                () => _employeeService.Save(Employee),
                () => true
            );
        }
    }
}
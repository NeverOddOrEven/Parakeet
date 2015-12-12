using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using HelloWorld.Model;
using Parakeet.Services;
using System;
using System.Windows.Controls;

namespace HelloWorld.ViewModel
{
    public class EmployeeCenterViewModel : ViewModelBase
    {
        private IEmployeeService _employeeService;

        public RelayCommand<TextChangedEventArgs> SearchForEmployeeCommand { get; set; }

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
            Employee = new Employee();
            SearchField = string.Empty;

            SearchForEmployeeCommand = new RelayCommand<TextChangedEventArgs>(
                (textChangedEvent) => {
                    Console.WriteLine("Test");
                }, 
                (textChangedEvent) => {
                    Console.WriteLine(SearchField);
                    return SearchField.Length > 2;
                }    
            );
        }
    }
}
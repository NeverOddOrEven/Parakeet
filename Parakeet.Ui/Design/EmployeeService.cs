using System;
using System.Collections.Generic;
using Parakeet.Data.Entities;
using Parakeet.Services;
using Parakeet.Services.Models;

namespace Parakeet.Ui.Design
{
    public class EmployeeService : IEmployeeService
    {
        public List<Employee> Find(string searchString)
        {
            return new List<Employee>
            {
                new Employee { FirstName = "First", LastName = "Last" },
                new Employee { FirstName = "First", LastName = "Last" },
                new Employee { FirstName = "First", LastName = "Last" },
                new Employee { FirstName = "First", LastName = "Last" },
                new Employee { FirstName = "First", LastName = "Last" },
                new Employee { FirstName = "First", LastName = "Last" },
                new Employee { FirstName = "First", LastName = "Last" },
                new Employee { FirstName = "First", LastName = "Last" }
            };
        }

        public bool Save(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}

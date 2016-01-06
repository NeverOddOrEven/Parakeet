using System;
using System.Collections.Generic;
using Parakeet.Data.Entities;
using Parakeet.Services;

namespace Parakeet.Ui.Design
{
    public class EmployeeService : IEmployeeService
    {
        public List<Person> Find(string searchString)
        {
            return new List<Person>
            {
                new Person { FirstName = "First", LastName = "Last" },
                new Person { FirstName = "First", LastName = "Last" },
                new Person { FirstName = "First", LastName = "Last" },
                new Person { FirstName = "First", LastName = "Last" },
                new Person { FirstName = "First", LastName = "Last" },
                new Person { FirstName = "First", LastName = "Last" },
                new Person { FirstName = "First", LastName = "Last" },
                new Person { FirstName = "First", LastName = "Last" }
            };
        }

        public bool Save(Person person)
        {
            throw new NotImplementedException();
        }
    }
}

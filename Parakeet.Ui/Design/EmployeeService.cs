using System.Collections.Generic;
using Parakeet.Data.Entities;
using Parakeet.Services;

namespace HelloWorld.Design
{
    internal class EmployeeService : IEmployeeService
    {
        public List<Person> FindEmployee(string searchString)
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
    }
}

using Parakeet.Data.Entities;
using System.Collections.Generic;
using System;

namespace Parakeet.Services
{
    public interface IEmployeeService
    {
        List<Person> FindEmployee(string searchString);
    }

    public class EmployeeService : IEmployeeService
    {
        public List<Person> FindEmployee(string searchString)
        {
            throw new NotImplementedException();
        }
    }
}

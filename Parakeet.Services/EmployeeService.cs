using Parakeet.Data.Entities;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Parakeet.Services
{
    public interface IEmployeeService
    {
        List<Person> FindEmployee(string searchString);
    }

    public class EmployeeService : IEmployeeService
    {
        private List<string> temp = new List<string>
        {
            "aa", "ab", "aac", "aad", "abc"
        };

        public List<Person> FindEmployee(string searchString)
        {
            return temp.Where(x => x.Contains(searchString))
                       .Select(x => new Person {FirstName = x}).ToList();
        }
    }
}

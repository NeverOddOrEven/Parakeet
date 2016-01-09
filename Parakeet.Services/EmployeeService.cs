using Parakeet.Data.Entities;
using System.Collections.Generic;
using System;
using System.Linq;
using Parakeet.Data.Repositories;
using Parakeet.Services.Models;
using Parakeet.Services.Mappers;

namespace Parakeet.Services
{
    public interface IEmployeeService
    {
        List<Employee> Find(string searchString);
        bool Save(Employee person);
    }

    public class EmployeeService : IEmployeeService
    {
        private IPeopleRepository _peopleRepository;

        public EmployeeService(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }

        public List<Employee> Find(string searchString)
        {
            var firstNameMatches = _peopleRepository.Where(x => x.FirstName.Contains(searchString));
            var lastNameMatches = _peopleRepository.Where(x => x.LastName.Contains(searchString));

            var searchResults = firstNameMatches.Concat(lastNameMatches).Select(EmployeeMapper.ToModel);

            return searchResults.ToList();
        }

        public bool Save(Employee employee)
        {
            var person = EmployeeMapper.ToEntity(employee);

            if (person.Id != null)
            {
                _peopleRepository.Update(person);
            }
            else {
                _peopleRepository.Add(person);
            }

            return person.Id != null;
        }
    }
}

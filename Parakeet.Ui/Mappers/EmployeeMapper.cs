using Parakeet.Data.Entities;
using Parakeet.Services.Models;

namespace Parakeet.Ui.Mapper
{
    public static class EmployeeMapper
    {
        public static Person ToEntity(this Employee employee)
        {
            return new Person
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                HireDate = employee.HireDate,
                SeparationDate = employee.SeparationDate,
            };
        }

        public static Employee ToModel(this Person person)
        {
            return new Employee
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                SeparationDate = person.SeparationDate,
                HireDate = person.HireDate
            };
        }
    }
}

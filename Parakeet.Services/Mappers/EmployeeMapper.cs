using Parakeet.Data.Entities;
using Parakeet.Services.Models;

namespace Parakeet.Services.Mappers
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
    }
}

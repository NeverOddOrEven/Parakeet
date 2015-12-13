using Parakeet.Data.Entities;
using Parakeet.Ui.Model;

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
    }
}

using System;
using System.Collections.Generic;

namespace Parakeet.Services.Models
{
    [Serializable]
    public class Employee
    {
        public Employee()
        {
            Positions = new List<Position>(); 
        }

        public long? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? HireDate { get; set; }
        public DateTime? SeparationDate { get; set; }
        
        public IList<Position> Positions { get; set; }
        
    }
}

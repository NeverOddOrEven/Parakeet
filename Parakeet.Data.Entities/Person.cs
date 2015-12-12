using System;

namespace Parakeet.Data.Entities
{
    public class Person
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual DateTime HireDate { get; set; }
        public virtual DateTime SeparationDate { get; set; }
    }
}

using System;

namespace Parakeet.Data.Entities
{
    public class Person : IEntity
    {
        public virtual long? Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual DateTime? HireDate { get; set; }
        public virtual DateTime? SeparationDate { get; set; }
    }
}

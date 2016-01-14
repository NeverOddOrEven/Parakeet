using System;

namespace Parakeet.Data.Entities
{
    public class PersonQualification : IEntity
    {
        public virtual long? Id { get; set; }
        public virtual Person Person { get; set; }
        public virtual Qualification Qualification { get; set; }
        public virtual DateTime Acquired { get; set; }
        public virtual DateTime Expired { get; set; }
        public virtual string Notes { get; set; }
    }
}

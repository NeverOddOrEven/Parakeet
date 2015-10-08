using FluentNHibernate.Mapping;
using Parakeet.Data.Entities;

namespace Parakeet.Data.Mappings
{
    public class PersonMap : ClassMap<Person>
    {
        public PersonMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.SeparationDate);
            Map(x => x.HireDate);
        }
    }
}

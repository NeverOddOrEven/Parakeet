using FluentNHibernate.Mapping;
using Parakeet.Data.Entities;

namespace Parakeet.Data.Mappings
{
    public class PersonMap : ClassMap<Person>
    {
        public PersonMap()
        {
            Id(x => x.Id);
            Map(x => x.FirstName);
            Map(x => x.LastName);
        }
    }
}

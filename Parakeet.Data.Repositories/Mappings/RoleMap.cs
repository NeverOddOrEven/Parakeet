using Parakeet.Data.Entities;
using FluentNHibernate.Mapping;

namespace Parakeet.Data.Mappings
{
    public class RoleMap : ClassMap<Role>
    {
        public RoleMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name);
            Map(x => x.Description);
        }
    }
}

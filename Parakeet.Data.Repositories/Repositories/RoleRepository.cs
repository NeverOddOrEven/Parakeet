using Parakeet.Data.Entities;

namespace Parakeet.Data.Repositories
{
    public interface IRoleRepository : IRepository<Role>
    {

    }

    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository()
        {

        }
    }
}

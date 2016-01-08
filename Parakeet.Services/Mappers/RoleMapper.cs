using Parakeet.Data.Entities;
using Parakeet.Services.Models;

namespace Parakeet.Services.Mappers
{
    public static class RoleeMapper
    {
        public static Role ToEntity(this Position position)
        {
            return new Role
            {
                Id = position.Id,
                Description = position.Description,
                Name = position.Title
            };
        }
    }
}

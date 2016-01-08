using Parakeet.Data.Entities;
using Parakeet.Services.Models;

namespace Parakeet.Ui.Mapper
{
    public static class RoleMapper
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

        public static Position ToModel(this Role role)
        {
            return new Position
            {
                Id = role.Id,
                Description = role.Description,
                Title = role.Name
            };
        }
    }
}

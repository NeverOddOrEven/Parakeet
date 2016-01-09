using Parakeet.Data.Entities;
using Parakeet.Services.Models;

namespace Parakeet.Services.Mappers
{
    public static class PositionMapper
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
